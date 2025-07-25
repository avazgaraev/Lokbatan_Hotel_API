using Lokbatan_Hotel.Data;
using Lokbatan_Hotel.Models;

namespace Lokbatan_Hotel.Services
{
    public class HomeService : IHomeService
    {
        public async Task<List<Home>> GetAvailableHomesAsync(DateTime startDate, DateTime endDate)
        {
            return await Task.Run(() =>
            {
                var range = Enumerable.Range(0, (endDate - startDate).Days + 1)
                    .Select(x => startDate.AddDays(x).ToString("yyyy-MM-dd"))
                    .ToList();

                var homes = InMemoryData.Homes.Values
                    .Where(home => range.All(date => home.availableSlots.Contains(date)))
                    .ToList();

                return homes;
            });
        }
    }
}