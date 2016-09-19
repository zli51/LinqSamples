<Query Kind="Statements">
  <Connection>
    <ID>1c0e85d8-b476-48d6-946e-6aa79b8ca67a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// which waiter has the most bills
var maxbill = (from x in Waiters
				select x.Bills.Count()).Max();

var mostBill = from x in Waiters
				// where x.Bills.Count() == maxbill
				select new {
							Name = x.FirstName + " " + x.LastName,
							// BillCount = x.Bills.Count()
							// tbills = x.Bills.Count()
						};
mostBill.Dump();

// create a dataset which contains the summary bills info by waiter
var WaiterBills = from x in Waiters
				  orderby x.LastName, x.FirstName
				  select new {
				  			  Name = x.LastName + ", " + x.FirstName,
							  BillInfo = (from y in x.Bills
							  			  where y.BillItems.Count() > 0
							  			  select new{
										  			 BillID = y.BillID,
													 BillDate = y.BillDate,
													 TableID = y.TableID,
													 Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
													 }
										)
							  };
WaiterBills.Dump();