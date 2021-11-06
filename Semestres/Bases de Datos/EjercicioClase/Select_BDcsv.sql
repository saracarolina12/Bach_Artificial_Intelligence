--create database RamenReview

----use ramenreview
--create table country
--(
--	IdCountry int identity(1,1) primary key,
--	CountryName nvarchar(100)
--)


--Create table Brand
--(
--	IdBrand int identity(1,1) primary key,
--	BrandName nvarchar(200)
--)

--create table Style
--(
--	IdStyle int identity(1,1) primary key,
--	StyleName nvarchar(200)
--)

--create table Ramen
--(
--	IdRamenReview int primary key,
--	Variety nvarchar(200),
--	Stars float, 
--	Topten nvarchar(20),
--	IdCountry int not null,
--	IdBrand int not null,
--	IdStyle int not null,
--	foreign key (IdCountry) references country(IdCountry),
--	foreign key (IdBrand) references brand(IdBrand),
--	foreign key (IdStyle) references style(IdStyle)
--)

-------------------------------------------------------------------------
--select * from ramenratings 

--valores distintos del campo country
--select distinct country from ramenratings

--ordenar según el país(A->Z)
--select distinct country from ramenratings order by country
--select country from ramenratings group by country order by country

--inserta los 38 elementos (paises)
--insert into Country
--(CountryName)
--select country from ramenratings group by country order by country 

--select * from Country

--select distinct Brand from ramenratings order by brand
--insert into Brand
--(BrandName)
--select distinct Brand from ramenratings order by brand

--insert into Style
--(StyleName)
--select distinct isnull(style,'Unknown') style from ramenratings 
--order by isnull(style, 'Unknown')

--delete Style

--select * from style
--select * from brand
--select * from Country

/*
Id
*/
--select * from ramen
--select * from ramen 

--cuántos reviews hay por país
--select * from (
--	select CountryName, count(1) totalreview 
--	from ramen r
--	join Country c on r.IdCountry=c.IdCountry
--	group by CountryName
--) t
--where totalreview<20
--order by totalreview desc
--order by totalreview desc	

--select * from ramen

--select CountryName, count(1) totalreview 
--	from ramen r
--	join Country c on r.IdCountry=c.IdCountry
--	group by CountryName
--	having count(1)<20  --filtrar sobre el contenido del grupo
--	order by totalreview desc


--Promedio de calificaicón por marca función avg

--select BrandName,count(1) total, avg(stars) average 
--from Ramen r
--join brand  b on b.IdBrand=r.IdBrand
--where stars>-1
--group by BrandName
--order by BrandName


--select CountryName, BrandName, Variety, StyleName, Stars, Topten
--from Ramen r
--join Country c on r.IdCountry=c.IdCountry
--join Brand b on b.IdBrand=r.IdBrand
--join Style s on r.IdStyle=s.IdStyle
--where topten is not null and topten like '2013%'
--order by Topten

select top 10
CountryName, BrandName, Variety, StyleName, Stars, Topten
from Ramen r
join Country c on r.IdCountry=c.IdCountry
join Brand b on b.IdBrand=r.IdBrand
join Style s on r.IdStyle=s.IdStyle
where stars != -1
order by stars
