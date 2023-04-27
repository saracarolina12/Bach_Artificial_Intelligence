#	numeros, precios de producto (cambia de precio)
#	ordenados
#	devuelve: índice donde conviene comprar, índice donde conviene vender
#		máxima ganancia posible
#		[5, 9, 1, 4]
#		comprar = 5 [0]
#		vende = 9 [1]
#		
#		[10, 5, 9, 1, 4]
#       comprar = 5 [0]
#		vende = 9 [1]
#
#		[1,2,3,4,5]
#		comprar = 1 [0]  
#		vender = 5 [4]  
#		ganancia = 4
		
#		[2,5,1,8]
#		c = 2
#		v = 8
#		g = 6
def max_gan(arr):
    c = arr[0] #2
    v = arr[1] #5
    g = v-c #3
    i_compra = 0
    i_venta = 1
    for i in range(len(arr)): # compra
        for j in range(i,len(arr)):	# venta
            c = arr[i] # 2
            v = arr[j] # 1
            if( v - c > g):
                i_compra = i
                i_venta = j
                g = v - c  
    return i_compra, i_venta


print(max_gan([10, 5, 9, 1, 4]))

def optimized(arr):
    minimo = arr[0]
    n = len(arr)
    profit = 0
    for i in range(1, n):
        profit = max(profit, arr[i] - minimo)
        minimo = min(minimo, arr[i])
    return profit
