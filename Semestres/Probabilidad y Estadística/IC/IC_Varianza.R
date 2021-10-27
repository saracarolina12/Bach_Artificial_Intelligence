IC_varianza = function(desv_std, n, coef_conf) {
  alfa = 1 - coef_conf
  ji2_alfa_medios = qchisq(alfa/2, n-1, lower.tail=FALSE)
  ji2_1_menos_alfa_medios = qchisq(1 - alfa/2, n-1, lower.tail=FALSE)
  
  LIC = (n-1)*desv_std^2/ji2_alfa_medios
  LSC = (n-1)*desv_std^2/ji2_1_menos_alfa_medios
  
  resultado = list(lim_inf_conf=LIC, lim_sup_conf=LSC)
  
  return(resultado)
}
# Suponga que cierta máquina fabrica resistencias eléctricas cuyo valor sigue una distribución normal con una desviación estándar por determinar
# Una muestra de tamaño 36 produce una resistencia que tiene una desviación estándar de 1.8
# Obtenga un Intervalo de Confianza de 99% para la verdadera varianza de las resistencias
# -----
n = 20
s = 1.8
coefConf = 0.98

IC1_var = IC_varianza(s, n, coefConf)
IC1_var


IC2_var = IC_varianza(sd(c(18, 21, 16, 22, 19,24,17,21,23,18,14,16,16,19,18,20,12,22,15,17)), 20, .98)
IC2_var