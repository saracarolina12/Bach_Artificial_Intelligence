myFile = read.delim(file.choose(), header = FALSE, sep = " ")
nOperaciones = myFile[1, 1]
nMaquinas = myFile[1, 2]
rows = 1 + nMaquinas
#unlist(myFile[2: 4, 1: 10])
tOperaciones = matrix(unlist(myFile[2: rows, 1: nOperaciones]), byrow = FALSE, nrow = nMaquinas)
tAjuste = list()

for(i in 1: nMaquinas){
  nRow = 2 + nMaquinas + nOperaciones*(i - 1)
  nRowE = nRow + nOperaciones - 1
  m = matrix(unlist(myFile[nRow: nRowE, 1: nOperaciones]), byrow = FALSE, nrow = nOperaciones)
  tAjuste[[i]] = m
}
print(nOperaciones)
print(nMaquinas)
print(tOperaciones)
print(tAjuste)
top = 3
matAvg = Reduce('+', tAjuste)/nMaquinas
vecAvg = colSums(tOperaciones)/nMaquinas
matAvg = matAvg + vecAvg[col(matAvg)]
diag(matAvg) = Inf
minOp = arrayInd(which.min(tOperaciones), dim(tOperaciones))
#which(tOperaciones == min(tOperaciones), arr.ind = TRUE)
assignedOp = c()
sol = vector(mode = "list", length = nMaquinas)
times = rep(0, nMaquinas)
currOp = minOp[2]
print(matAvg)
repeat {
  assignedOp = c(assignedOp, currOp)
  assignedM = which.min(times + tOperaciones[, currOp])
  sol[[assignedM]] = c(sol[[assignedM]], currOp)
  times[assignedM] = times[assignedM] + tOperaciones[assignedM, currOp]
  nOM = length(sol[[assignedM]]) #Número de operaciones en la máquina asignada
  if(nOM > 1)
    times[assignedM] = times[assignedM] + tAjuste[[assignedM]][sol[[assignedM]][nOM - 1], sol[[assignedM]][nOM]]
  vecFila = sort(matAvg[currOp, ])
  print(vecFila)
  neighborhood = c()
  for(i in 1: nOperaciones){
    element = vecFila[i]
    if(!(which(element == matAvg[currOp, ]) %in% assignedOp))
      neighborhood = c(neighborhood, element)
  }
  cat("Neigh", neighborhood, "\n")
  ranElement = sample(neighborhood[1: min(c(length(neighborhood), top))], 1)
  currOp = which(ranElement == matAvg[currOp, ])
  if(length(assignedOp) == nOperaciones) break
}
sol

