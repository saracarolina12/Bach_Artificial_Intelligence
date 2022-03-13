#En la inspección de hojalata producida por un proceso electrolítico continuo, se identifican 0.2 imperfecciones en promedio por minuto. Determine las probabilidades de identificar

##### a) Exactamente una imperfección en un minuto
##### b) Al menos una imperfección en un minuto
##### c) Exactamente una imperfección en 3 minutos
##### d) Al menos dos imperfecciones en 5 minutos
##### e) Cuando mucho una imperfección en 15 minutos


lambdaA = 0.2 #imperfecciones 

#a) P(x=1)
igual_uno = dpois(1, lambdaA)
igual_uno


#b) P(x>=1)
mayor_uno = 1-dpois(0,lambdaA)
mayor_uno


#c) P(x=1) 
lambdaC = 0.2*3 #3 minutos
igual_a_uno = dpois(1, lambdaC)
igual_a_uno


#d) P(x>=2) = P(x > 1)       ****
lambdaD = 0.2*5 #5 minutos
may_dos = 1- (dpois(0, lambdaD)+dpois(1, lambdaD))
may_dos

#e) P(x<=1)
lamdaE = 0.2*15
men_uno = dpois(0,lamdaE) + dpois(1, lamdaE)
men_uno
