<Query Kind="Statements">
  <Connection>
    <ID>1c0e85d8-b476-48d6-946e-6aa79b8ca67a</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// when you need to use multiple steps
// to solve a problem, switch your Language
// choice to either Statement(s) or Program

// the results of each query will now be save in a variable
// the variable can then be used in future queries

var maxcount = (from x in MediaTypes
	select x.Tracks.Count()).Max();
	
// to display the contents of a variable in LinqPad
// you use the method .Dump()
maxcount.Dump();

// use a value in a preceeding create variable
var popularMediaType = from x in MediaTypes
						where x.Tracks.Count() == maxcount
						select new {
									Type = x.Name,
									TCount = x.Tracks.Count()
						};
popularMediaType.Dump();

// can this set of statements be been as one complete query
// the answer is possibly, and in this case "yes"
// in this example, maxcount could be exchanged for the query that
//  actually create the value in the first place
//  this subsituted query is a subquery
var popularMediaTypeSubQuery = from x in MediaTypes
						where x.Tracks.Count() == (from y in MediaTypes
													select y.Tracks.Count()).Max()
						select new {
									Type = x.Name,
									TCount = x.Tracks.Count()
						};
popularMediaTypeSubQuery.Dump();

// using the method syntax to determine the count value for the where expression
// this demonstrates that queries can be constructed using both query syntax and method syntax
var popularMediaTypeSubMethod = from x in MediaTypes
						where x.Tracks.Count() == MediaTypes.Select(mt => mt.Tracks.Count()).Max()
						select new {
									Type = x.Name,
									TCount = x.Tracks.Count()
						};
popularMediaTypeSubMethod.Dump();