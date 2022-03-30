#
#Distribución uniforme
#Sea X ~ U(13,26)
#a) Obtenga la fdp de X y esboce su gráfica
#b) Calcule P(15 ??? X ??? 20) R= 0.3848
#c) Calcule P(X ??? 19.5) R = 0.5000
#d) Calcule P( X ??? 23.4) R = 0.2000
#e) Obtenga E(X) R = 19.5
#f) Obtenga Var(X) R = 14.0833

#a) fdp
a = 13
b = 26
fdp = 1/(b-a)
fdp

#b) P(15 ??? X ??? 20) === P(c <= X <= d)
c = 15
d = 20
P = (d-c)/(b-a)
P

#c) P(X ??? 19.5)
c = 13
d = 19.5
P = (d-c)/(b-a)
P

#d) P( X ??? 23.4)
c = 23.4
d= 26
P = (d-c)/(b-a)
P

#e) E(x)
E = (a+b)/2
E

#f) Var
Var = ((b-a)^2)/12
Var