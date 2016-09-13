<Query Kind="Expression">
  <Connection>
    <ID>f689a76e-7b44-4904-aa25-39aa637bfae0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Items
from x in Items
where x.CurrentPrice > 5
select new {x.CurrentPrice, x.Description}
		