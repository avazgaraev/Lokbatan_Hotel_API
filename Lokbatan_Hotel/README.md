Technoly stack:
1) .net 8 / asp.net core web api
2) in-memory data
3. async filtering
4. solid archtecture 
5. tests done by xunit and webapplicationfactory


## Filtering Logic:
A date range is generated Enumerable.Range. And tt checks if all dates in that range exist in the home's availableSlots. so particular home is returned only if every date in the range is available.

## Note on Filtering Logic:
The API works on only if it is contained on every single date within the requested range, as it was required in the file you shared with me(�available slots fully match the user�s requested date range�), but 
on my mind, it would be correct the requirement have been to include homes available on any date within the range, the filtering logic would have been adjusted better.(i mean for example if the available dat efor the is 15/07 and 16/07, and the range in api request start date and end date is 15/07 and 16/07, it works perfectly, but if write startdate as 31/06 and enddate 01/08, it will not work, but actually between these dates this home is available.)
I hope it is clear what i mean. this is just sincere observation while creating the project.


## In-Memory Storage Strategy:
Home and slot data are stored in a Dictionary<string, Home>. And i configured past date slots automatically filtered out in InMemoryData.cs using:String.Compare(date, today) >= 0

## homeId Uniqueness:
Each home has a homeId, which is a unique. How i do it ? So in-memory data: Dictionary<string, Home>  Since keys must be unique in dictionaries, same homeIds cannot exist. This satisfies the requirement:


## To run the application
git clone https://github.com/avazgaraev/lokbatan-hotel-api.git
cd lokbatan-hotel-api
dotnet run --project Lokbatan_Hotel
Visit http://localhost:5243/swagger

Run Integration Tests
dotnet test


## Sources:

HomeService.cs
https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.run?view=net-9.0
https://stackoverflow.com/questions/14286665/changing-meta-search-parameters/14286936#14286936

InMemoryData.cs
https://stackoverflow.com/questions/51833864/delay-a-method-of-a-class-in-java/51836582#51836582

BookingIntegrationTests.cs
https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0&pivots=xunit

Overall discussion with gpt
https://chatgpt.com/share/68836b48-99e4-800d-a7dc-f6d51370b9e0