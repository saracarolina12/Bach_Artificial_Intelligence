IC_mu_sigma_desconocida = function(x_barra, s, n, coef_conf) 
{
  alfa = 1 - coef_conf
  
  t = qt(alfa/2,n-1,lower.tail=FALSE)
  
  LIC = x_barra - t*s/sqrt(n)
  LSC = x_barra + t*s/sqrt(n)
  
  resultado = list(lim_inf_conf = LIC, lim_sup_conf = LSC)
  
  return(resultado)
}

#datos = c(15.0,20.6,16.0,12.8,14.1,86.1,7.5,0.9,6.0,26.2,4.2,3.0,2.4,66.9,4.7,29.0,95.1,2.7,29.7,10.9)
datos = c(2.3,1.9,2.1,2.8,2.3,3.6,1.4)

x_barra = 2.342        #Media
n = 7                #Tamaño de muestra
coefConf = 0.90       #Coeficiente de confianza

s = sqrt(var(datos))  #Desviación estándar obtenida de la varianza
s

IC1 = IC_mu_sigma_desconocida(x_barra, s, n, coefConf)
IC1