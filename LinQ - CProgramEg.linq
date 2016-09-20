<Query Kind="Program">
  <Connection>
    <ID>1c0e85d8-b476-48d6-946e-6aa79b8ca67a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	// a list of bill counts for all waiters
	// This query will create a flat dataset
	// The columns are native data types (ie int, string, ...)
	// One is not concerned with repeated data in a column
	// Instead of using an anonymous datatype (new{...})
	// We wish to use a defined class definition
	var mostBill = from x in Waiters
					select new WaiterBillCounts {
								Name = x.FirstName + " " + x.LastName,
								TCount = x.Bills.Count()
					};
	mostBill.Dump();
	
	var paramMonth = 4;
	var paramYear = 2016;
	var WaiterBills = from x in Waiters
					where x.LastName.Contains("k")
				  	orderby x.LastName, x.FirstName
				  	select new WaiterBills {
				  			  	Name = x.LastName + ", " + x.FirstName,
								TCount = x.Bills.Count(),
							  	BillInfo = (from y in x.Bills
							  			  	where y.BillItems.Count() > 0
											&& y.BillDate.Month == DateTime.Today.Month - paramMonth
											&& y.BillDate.Year == paramYear
							  			 	select new BillItemSummary {
										  				BillID = y.BillID,
														BillDate = y.BillDate,
														TableID = y.TableID,
													 	Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
											}
								).ToList()
				  	};
	WaiterBills.Dump();
}

// Define other methods and classes here
// An example of a POCO class (flat)
public class WaiterBillCounts
{
	// whatever recieving field on your query in your select
	// appears as a property in this class
	public string Name { get; set; }
	public int TCount { get; set; }
}

public class BillItemSummary
{
	public int BillID { get; set; }
	public DateTime BillDate { get; set; }
	public int? TableID { get; set; }
	public decimal Total { get; set; }
}

// An example of a DTO class (structured)
public class WaiterBills
{
	public string Name { get; set; }
	public int TCount { get; set; }
	public List<BillItemSummary> BillInfo { get; set; }
}