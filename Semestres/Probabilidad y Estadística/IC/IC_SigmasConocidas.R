IC_mu1_mu2_sigmas_conocidas = function(x_barra1, n1, sigma1, x_barra2, n2, sigma2, coef_conf) {
  alfa = 1 - coef_conf
  z_alfa_medios = qnorm(alfa/2, lower.tail=FALSE)
  
  LIC = (x_barra1 - x_barra2) - z_alfa_medios*sqrt(sigma1^2/n1 + sigma2^2/n2)
  LSC = (x_barra1 - x_barra2) + z_alfa_medios*sqrt(sigma1^2/n1 + sigma2^2/n2)
  
  resultado = list(lim_inf_conf=LIC, lim_sup_conf=LSC)
  
  return(resultado)
}
# En un artículo de Consumer Reports de noviembre de 1983 se comparan varios tipos de baterías
# Los tiempos de vida promedio de baterías AA alcalinas Duracell y baterías AA alcalinas Eveready Energizer se dieron como 4.1 horas y 4.5 horas, respectivamente
# En ambos casos, la muestra fue de 100 baterías
# Suponga que las desviaciones estándar poblacionales del tiempo de vida son 1.8 horas para las baterías Duracell y 2.0 para las baterías Eveready Energizer
# Calcule un IC de 90% para la diferencia entre los tiempos promedio de vida de ambos tipos de baterías
# R = P([-0.843, 0.043] ni (mu1 - mu2)) = 0.90
x_barra1 = 4.1
x_barra2 = 4.5
n1 = 100
n2 = 100
sigma1 = 1.8
sigma2 = 2
coefConf = 0.9

IC1_mu1_mu2 = IC_mu1_mu2_sigmas_conocidas(x_barra1, n1, sigma1, x_barra2, n2, sigma2, coefConf)
IC1_mu1_mu2
