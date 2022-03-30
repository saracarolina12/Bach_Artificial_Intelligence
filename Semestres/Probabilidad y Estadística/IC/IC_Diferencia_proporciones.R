ic_dif_proporciones = function(p1, p2, pr, n1, n2){
  alfa = 1 - pr
  z_alfa_medios = qnorm(alfa/2, lower.tail=FALSE)
  
  LIC = (p1-p2) - z_alfa_medios * sqrt( ((p1*(1-p1))/n1) + ((p2*(1-p2))/n2)  )
  LSC = (p1-p2) + z_alfa_medios * sqrt( ((p1*(1-p1))/n1) + ((p2*(1-p2))/n2)  )
  
  resultado = list(lim_inf_conf=LIC, lim_sup_conf=LSC)

  return(resultado)
}



p1 = 30/200
p2 = 180/600
pr = .99
n1 = 200
n2 = 600

ic = ic_dif_proporciones(p1,p2,pr,n1,n2)
ic
 
