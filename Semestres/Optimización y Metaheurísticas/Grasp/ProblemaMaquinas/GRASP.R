#Lectura
myFile = read.delim(file.choose(), header = FALSE, sep = " ")
nOperaciones = myFile[1, 1]
nMaquinas = myFile[1, 2]
rows = 1 + nMaquinas
tOperaciones = matrix(unlist(myFile[2: rows, 1: nOperaciones]), byrow = FALSE, nrow = nMaquinas)
tAjuste = list()
for(i in 1: nMaquinas){
  nRow = 2 + nMaquinas + nOperaciones*(i - 1)
  nRowE = nRow + nOperaciones - 1
  m = matrix(unlist(myFile[nRow: nRowE, 1: nOperaciones]), byrow = FALSE, nrow = nOperaciones)
  tAjuste[[i]] = m
}

#Fase #1. Greedy Randomized Adaptive
Greedy <- function(){
  #alpha
  top = 3 
  #matriz de promedios
  matAvg = Reduce('+', tAjuste)/nMaquinas  
  vecAvg = colSums(tOperaciones)/nMaquinas 
  matAvg = matAvg + vecAvg[col(matAvg)] 
  diag(matAvg) = Inf
  #Guarda el indice de la operación más rápida en la maquina mas rapida
  minOp = arrayInd(which.min(tOperaciones), dim(tOperaciones))
  assignedOp = c() 
  sol = vector(mode = "list", length = nMaquinas)
  times = rep(0, nMaquinas)
  currOp = minOp[2]
  repeat {
    #Operación elegida 
    assignedOp = c(assignedOp, currOp)
    vecValidation = c()
    #Se guarda la operación en cada maquina
    for(i in 1: nMaquinas){
      suma = times[i] + tOperaciones[1, currOp]
      nOM = length(sol[[i]])
      if(nOM > 0) suma = suma + tAjuste[[i]][sol[[i]][nOM - 1], currOp]
      vecValidation = c(vecValidation, suma)
    }
    assignedM = which.min(vecValidation)
    sol[[assignedM]] = c(sol[[assignedM]], currOp)
    times[assignedM] = times[assignedM] + tOperaciones[assignedM, currOp]
    nOM = length(sol[[assignedM]]) #Numero de operaciones en la maquina asignada
    if(nOM > 1)
      times[assignedM] = times[assignedM] + tAjuste[[assignedM]][sol[[assignedM]][nOM - 1], sol[[assignedM]][nOM]]
    if(length(assignedOp) == nOperaciones) break
    
    #Crea lista de vecinos
    vecFila = matAvg[currOp, ]
    neighborhood = c()
    for(i in 1: nOperaciones){
      if(!(i %in% assignedOp)){
        neighborhood = cbind(neighborhood, c(vecFila[i], i))
      }
    }
    if(ncol(neighborhood) > 1)
      neighborhood = neighborhood[, order(neighborhood[1, ])]
    ranElement = 0
    
    if(ncol(neighborhood) < top) ranElement = neighborhood[2, 1]
    else ranElement = sample(neighborhood[2, 1:top], 1)
    currOp = ranElement
  }
  return(sol)
}

#Tiempo que toma cada maquina 
timeList <- function(solution, prosecutionTime, adjustmentTime){
  times = c()
  for(i in 1:length(solution)){
    time = 0
    for(j in 1:length(solution[[i]]))
    {
      time = time + prosecutionTime[i,solution[[i]][j]]
      if(j >= 2)
      {
        time = time + adjustmentTime[[i]][solution[[i]][j-1],solution[[i]][j]]
      }
    }
    times = c(times, time)
  }
  return(times)
}

#Tiempo que toma una maquina en específico
evaluar <- function(vec, indice, prosecutionTime, maquinas){
  tiempo = 0
  for(i in 1: length(vec)){
    tiempo = tiempo + prosecutionTime[indice, vec[i]]
    if(i!=length(vec)){                                     #No agrego el tiempo de ajuste de la ultima operacion
      tiempo = tiempo + maquinas[[indice]][vec[i],vec[i+1]]
    }
  }
  return (tiempo)
}


# Fase 2. Busqueda local con Tabu
local_search_tabu <- function(iter, initialSol, tenor){
  lista_tabu = c()
  tenor_tabu = tenor
  
  best_of_the_best = initialSol #la solucion inicial es la mejor solucion hasta ahora
  
  for(i in 1:iter){
    index_peor = which.max(timeList(initialSol,tOperaciones,tAjuste))
    index_mejor = which.min(timeList(initialSol,tOperaciones,tAjuste))
    
    best = 100000000
    sol = c()
    operacion = 0
    quitar = 0
    
    for(i in 1:length(initialSol[[index_peor]])){  
      for(j in 0:length(initialSol[[index_mejor]])){ 
        
        if(!(initialSol[[index_peor]][i] %in% lista_tabu)){
          vec_aux = initialSol[[index_mejor]]  
          vec_aux = append(vec_aux, initialSol[[index_peor]][i] ,j)      #Agrega operacion a una posicion de la maquina menor
          
          aux = evaluar(vec_aux, index_mejor, tOperaciones, tAjuste)
          
          #si es mejor que el mejor anterior, lo tomamos y actualizamos 
          if(aux < best){ 
            quitar = i
            operacion = initialSol[[index_peor]][i]
            best = aux
            sol = vec_aux
          }
        }
      }
    }
    
    mejor_solucion = initialSol
    index = c(quitar)
    mejor_solucion[[index_peor]] <- mejor_solucion[[index_peor]][-index]    #Le quita a la peor maquina la operacion
    mejor_solucion[[index_mejor]] = sol
    initialSol = mejor_solucion
    
    #Comparacion
    maximo1 = max(timeList(initialSol,tOperaciones,tAjuste))
    maximo2 = max(timeList(best_of_the_best,tOperaciones,tAjuste))
    if(maximo1<maximo2)best_of_the_best = initialSol
    
    
    #Añade la operacion a la lista tabu para evitar repetir
    lista_tabu <- append(lista_tabu, operacion)
    if(length(lista_tabu) > tenor_tabu){
      indice <- c(1)
      lista_tabu <- lista_tabu[-indice]
    }
    
  }
  
  return (best_of_the_best) #regresa la mejor solucion
}

soluciones = c()
bSolution = c()
#Se repite el proceso 50 veces
for(i in 1: 50){ 
  mejor = local_search_tabu(150, Greedy(), 2)
  tiempo = max(timeList(mejor,tOperaciones,tAjuste))
  soluciones = c(soluciones, tiempo)
  if(tiempo == min(soluciones)) 
    bSolution = mejor
}
soluciones


#Graficas de Gantt

#Instalar las siguientes dos líneas:
# install.packages('devtools')
# devtools::install_github('Kitware/candela', subdir='R/candela', dependencies = TRUE)
library(candela)
buildDiagrms <- function(solution, prosecutionTime, adjustmentTime)
{
  data = list()
  i = 1
  different = 0
  for(n in 1:length(solution))
  {
    time = 0
    if(n %% 2 == 1) different = 1
    else different = 2
    for(m in 1:length(solution[[n]]))
    {
      if(m >= 2)
      {
        data[[i]] = list(name=gsub(" ", "", paste("A",solution[[n]][m-1])), level=different, start=time, end=time+adjustmentTime[[n]][solution[[n]][m-1],solution[[n]][m]])
        time = time + adjustmentTime[[n]][solution[[n]][m-1],solution[[n]][m]]
        i = i + 1
      }
      data[[i]] = list(name=gsub(" ", "", paste("O",solution[[n]][m])), level=different, start=time, end=time+prosecutionTime[n,solution[[n]][m]])
      time = time + prosecutionTime[n,solution[[n]][m]]
      i = i + 1
    }
  }
  return(data)
}

data = buildDiagrms(bSolution,tOperaciones,tAjuste)

candela('GanttChart',
        data=data, label='name',
        start='start', end='end', level='level')
cat(mean(soluciones), sd(soluciones), min(soluciones), max(soluciones))
