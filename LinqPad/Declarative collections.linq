<Query Kind="Statements">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
  <NuGetReference>Microsoft.Extensions.Caching.Memory</NuGetReference>
  <RuntimeVersion>9.0</RuntimeVersion>
</Query>

int[] source = [1,2,3,4,5,6,7,8,9];

#region method syntax
source
 .Where(x => x % 2 == 0)            .Dump("Filtered: ") 
 .Sum()                             .Dump("The sum:");
#endregion

 
 
#region query expression
var spenders =  from invoice in Invoices
				where invoice.Total > 10
				select invoice.Customer;
				
spenders.Dump();
#endregion
				
