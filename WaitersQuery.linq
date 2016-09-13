<Query Kind="Expression">
  <Connection>
    <ID>f689a76e-7b44-4904-aa25-39aa637bfae0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Waiters
var results = from x in Waiters;
where x.FirstName.Contains("a")
orderby x.LastName
select x.LastName + ", " + x.FirstName;
results.Dump();