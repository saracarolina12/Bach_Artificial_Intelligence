import numpy as np

# Objective function
def rules(solution, breaks, areas, inventario, people, domingos, desc = False):
    if desc: print(solution)
    faults = []
    fitness = 0
    descanso = np.where(breaks == "Descansa")[0]
    manana = np.where(breaks == "Mañana")[0]
    tarde = np.where(breaks == "Tarde")[0]
    comida = np.where(breaks == "Comida")[0]
    highPriority, mediumPriority, lowPriority = 100, 10, 1
    for i, p in enumerate(solution):
        # Inventario
        if inventario == areas[i][-1]:
            if p[2] in [descanso, manana, tarde]:
                faults.append("Persona {} descansa el miercoles y tiene inventario".format(i))
                fitness -= highPriority
            if p[3] in [descanso, manana, tarde]:
                faults.append("Persona {} descansa el jueves y tiene inventario".format(i))
                fitness -= highPriority

        # Specificas de la semana
        if people[i] == "Samanta" and p[5] != descanso:
            fitness -= mediumPriority
            faults.append("Samanta necesita los sabados")
        if people[i] == "Maira" and p[2] != descanso:
            fitness -= mediumPriority
            faults.append("Maira quiere el miercoles")
        if people[i] == "Elena" and p[0] != descanso:
            fitness -= mediumPriority
            faults.append("Elena descansa los lunes")
        if people[i] == "Nancy" and p[4] != descanso:
            fitness -= mediumPriority
            faults.append("Nancy quiere el viernes")
        if people[i] == "Marisol" and p[1] != descanso:
            fitness -= mediumPriority 
            faults.append("Marisol quiere el martes")
        if people[i] == "Marlette" and p[0] != descanso:
            fitness -= mediumPriority
            faults.append("Marlette necesita lunes")

    # Maximize time by area
    tArea = dict() # Stores by area the day that is the most empty, so the greater it is, the more spread will people be
    for d in range(solution.shape[1]):
        for h in range(solution.shape[0]):
            if not areas[h][0] in tArea:
                tArea[areas[h][0]] = []
            if len(tArea[areas[h][0]]) == d:
                tArea[areas[h][0]].append(0)
            if solution[h, d] == comida:
                tArea[areas[h][0]][-1] += 2*lowPriority
            if solution[h, d] == manana or solution[h, d] == tarde:
                tArea[areas[h][0]][-1] += lowPriority
    fitness += np.sum([np.min(tArea[a])*lowPriority for a in tArea])

    if desc: return fitness, faults
    return fitness

# Second approach
#breaks = np.array(["12 - 2", "2 - 4", "4 - 6", "MañanaDomingo", "Descansa", "Mañana", "Tarde"])
#codigos = np.array(["12", "2", "4", "M", "D", "M", "T"])

# Third approach
#breaks = np.array(["Comida", "MañanaDomingo", "Descansa", "Mañana", "Tarde"])
#codigos = np.array(["C", "M", "D", "M", "T"])

# Fourth approach
breaks = np.array(["Comida", "Descansa", "Mañana", "Tarde"])
codigos = np.array(["C", "D", "M", "T"])
domingos = ["Sonia", "Nancy", "Alberto", "Diana", "Susy"]

#people = ["Samanta", "Luz", "Sonia", "Laura", "Maira", "Gloria", "Fernanda", "Marisol", "Susy", "Diana", "Brayan", "Nallely", "Marlette", "Lucia", "Fabian", "Alberto", "Elena", "Nancy", "Andrea", "Alma"]
people = ["Samanta", "Luz", "Laura", "Maira", "Gloria", "Fernanda", "Marisol", "Susy", "Diana", "Brayan", "Nallely", "Marlette", "Lucia", "Fabian", "Alberto", "Elena", "Nancy", "Andrea"]
areas = [
    ["Damas", "Lenceria"],              #Samanta
    ["Damas", "Ninas"],                 #Luz
    #["Damas", "Moda joven"],            #Sonia
    ["Damas", "Moda joven"],            #Laura
    ["Damas", "Dama madura"],           #Maira
    ["Zapateria", "Zapateria damas"],   #Gloria
    ["Zapateria", "Zapato deportivo"],  #Fernanda
    ["Caballeros", "Bebes"],            #Marisol
    ["Zapateria", "Zapato caballero"],  #Susy
    ["Jugueteria"],                     #Diana
    ["Perfumeria"],                     #Brayan
    ["Cajas ropa"],                     #Nallely   
    ["Cajas ropa"],                     #Marlette
    ["Caballeros"],                     #Lucia
    ["Caballeros"],                     #Fabian
    ["Zapateria", "Zapato caballero"],  #Alberto
    ["Paqueteria"],                     #Elena
    ["Caballeros", "Ninos"],            #Nancy
    ["Caballeros", "Bebes"],            #Andrea
    #["Auxiliar"]                        #Alma
]

# A que departamento le toca inventario esta semana
inventario = "Caballeros"