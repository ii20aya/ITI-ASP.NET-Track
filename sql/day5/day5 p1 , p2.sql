--day 5 , p1 "advanture"

-- 1
select salesorderid, shipdate
from sales.salesorderheader
where shipdate between '2002-07-28' and '2014-07-29';


-- 2.
select ProductID, [Name]
from Production.Product
where StandardCost < 110.00;


-- 3. 
select ProductID, [Name]
from Production.Product
where [Weight] IS NULL;


-- 4. Display all Products with a Silver, Black, or Red Color
select *
from Production.Product
where Color IN ('Silver', 'Black', 'Red');


-- 5. Display any Product with a Name starting with the letter B
select ProductID, [Name]
from Production.Product
where [Name] LIKE 'B%';


-- 6. Run the following Query
UPDATE Production.ProductDescription
SET [Description] = 'Chromoly steel_High of defects'
where ProductDescriptionID = 3;

--Then write a query that displays any Product description with underscore value in its description.
select ProductDescriptionID, [Description]
from Production.ProductDescription
where [Description] LIKE '%[_]%';


-- 7.
select OrderDate, SUM(TotalDue) AS Total_Due
from Sales.SalesOrderHeader
where OrderDate BETWEEN '2001-07-01' AND '2014-07-31'
GROUP BY OrderDate


-- 8. 
select DISTINCT HireDate
from HumanResources.Employee

-- 9. 
select AVG(DISTINCT ListPrice) AS Avg_Unique_ListPrice
from Production.Product;


--10
select 'The ' + [Name] + ' is only! ' + CAST(ListPrice AS NVARCHAR(20)) AS Product_Info
from Production.Product
where ListPrice BETWEEN 100 AND 120



--11

select rowguid, [Name], SalesPersonID, Demographics
into store_Archive
from Sales.Store;

-- b)Try the previous query but without transferring the data? 
select * from store_Archive
create table store_Archive2 (
    rowguid uniqueidentifier NOT NULL,  
    [Name] nvarchar(50) NOT NULL,
    SalesPersonID int,
    Demographics xml 
);
select * from store_Archive2


-- 12
select convert(VARCHAR, GETDATE(), 1)
UNION
select convert(VARCHAR, GETDATE(), 23)
UNION
select format(GETDATE(), 'yyyy-dd-mm')
UNION
select format(GETDATE(), 'dd/MM/yyyy');

