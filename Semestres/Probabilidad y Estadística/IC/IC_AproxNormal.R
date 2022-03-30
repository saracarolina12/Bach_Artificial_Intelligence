IC_p_aprox_normal = function(x, n, coef_conf){
  alfa = 1 - coef_conf
  z_alfa_medios = qnorm(alfa/2, lower.tail=FALSE)
  p = x/n
  LIC = p - z_alfa_medios*sqrt( (p*(1-p))/n  )
  LSC = p + z_alfa_medios*sqrt( (p*(1-p))/n  )
  
  resultado = list(lim_inf_conf=LIC, limp_sup_conf=LSC)
  return(resultado)
}
  
x = 486
n = 1100
coefConf = 0.99



IC1 = IC_p_aprox_normal(x,n,coefConf)
IC1
