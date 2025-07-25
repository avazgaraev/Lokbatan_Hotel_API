using Lokbatan_Hotel.Models;

namespace Lokbatan_Hotel.Data
{

    public static class InMemoryData
    {
        static InMemoryData()
        {
            var today = DateTime.Today.ToString("yyyy-MM-dd");

            foreach (var home in Homes.Values)
            {
                home.availableSlots = home.availableSlots
                    .Where(date => String.Compare(date, today) >= 0)
                    .ToList();
            }
        }
        public static Dictionary<string, Home> Homes = new()
        {
            ["123"] = new Home
            {
                homeId = "123",
                homeName = "Lokbatan Deluxe Suite",
                availableSlots = new List<string> { "2025-08-15", "2025-08-16", "2025-08-17" }
            },
            ["124"] = new Home
            {
                homeId = "124",
                homeName = "Lokbatan Economy Room",
                availableSlots = new List<string> { "2025-07-17", "2025-07-18" }
            }
        };
    }
}
