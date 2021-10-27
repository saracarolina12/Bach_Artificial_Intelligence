#
#
#Distribución de Bernoulli
# X ~ Ber(p)
#-------------------------
#Fmp (masa de probabilidad)
#      f(x) = (p^x) * (1-p)^(1-x) 
prob = 0.5
print((paste("f(x) =  ", prob,"^x *(1-", prob,"^(1-x)")))

#Valor esperado E(x) = p
print(prob)


#Varianza Var(x)=p(1-p)
print(prob*(1-prob))
