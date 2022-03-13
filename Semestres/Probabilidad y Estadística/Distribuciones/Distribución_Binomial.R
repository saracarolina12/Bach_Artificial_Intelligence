#
#Distribución binomial 
#
#
#X ~ Bin(10, 0.25)
#a) P(x=0)
# (x,size,prob)
p0 = dbinom(0, 15, 0.05)
p0


#b) P(x>0)
p_mayor_que_0 = 1 - p0
p_mayor_que_0

#c) Prob. de que apruebe si 7 es la calificación mínima aprobatoria
p_apruebe = sum(dbinom(6:15, size=9, prob = 0.05))
p_apruebe


#Número esperado de respuestas correctar
E_X = 15*0.05 
E_X
