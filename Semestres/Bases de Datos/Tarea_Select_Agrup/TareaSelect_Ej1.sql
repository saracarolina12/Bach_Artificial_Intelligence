--use AdventureWorks2017

--Tablas a usar:
	--Purchasing.PurchaseOrderDetail
	--Production.Product
	--Sales.SalesOrderHeader
	--Purchasing.ShipMethod
	--Sales.SalesTerritory

--Ejercicio 1. Monto total de compras por año, ordenadas por año de mayor a menor
	select year(DueDate) Año, sum(LineTotal) line_total
	from Purchasing.PurchaseOrderDetail group by year(DueDate)
	order by year(DueDate) desc

--Ejercicio 2. Total de productos comprados por nombre de productos ordenados por la cantidad de productos recibidos de menor a mayor
	select Production.Product.Name, sum(Purchasing.PurchaseOrderDetail.ReceivedQty) ReceivedQty from Production.Product
	join Purchasing.PurchaseOrderDetail on Purchasing.PurchaseOrderDetail.ProductID = Production.Product.ProductID
	group by Production.Product.Name
	order by sum(Purchasing.PurchaseOrderDetail.ReceivedQty)

--Ejercicio 3.  Total de productos comprados por nombre de productos ordenados por la cantidad de productos recibidos de menor a mayor
	select Purchasing.ShipMethod.Name name, count(1) total from Purchasing.ShipMethod
	join Sales.SalesOrderHeader on Sales.SalesOrderHeader.ShipMethodID = Purchasing.ShipMethod.ShipMethodID
	group by Purchasing.ShipMethod.Name

--Ejercicio 4. Impuestos pagados por año ordenados año de menor a mayor.
	select year(OrderDate) year, sum(TaxAmt) TaxAmt from Sales.SalesOrderHeader
	group by year(OrderDate)
	order by year(OrderDate)

--Ejercicio 5. Ventas por nombre de territorio y año, ordenados por nombre de territorio y año de mayor a menor
	select t.Name Name, year(s.OrderDate) year, sum(s.TotalDue) TotalDue from Sales.SalesTerritory t
	join Sales.SalesOrderHeader s on s.TerritoryID = t.TerritoryID
	group by t.Name, year(s.OrderDate)
	order by t.Name, year(s.OrderDate) desc