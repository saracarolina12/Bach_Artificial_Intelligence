IC_varianza = function(desv_std, n, coef_conf) {
  alfa = 1 - coef_conf
  ji2_alfa_medios = qchisq(alfa/2, n-1, lower.tail=FALSE)
  ji2_1_menos_alfa_medios = qchisq(1 - alfa/2, n-1, lower.tail=FALSE)
  
  LIC = (n-1)*desv_std^2/ji2_alfa_medios
  LSC = (n-1)*desv_std^2/ji2_1_menos_alfa_medios
  
  resultado = list(lim_inf_conf=LIC, lim_sup_conf=LSC)
  
  return(resultado)
}
# -----
# n = 7
# #s = 1.8
# coefConf = 0.90
# 
# IC1_var = IC_varianza(s, n, coefConf)
# IC1_var
# 

IC2_var = IC_varianza(sd(c(2.3,1.9,2.1,2.8,2.3,3.6,1.4)), 7, .90)
IC2_var