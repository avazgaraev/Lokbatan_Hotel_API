using Lokbatan_Hotel.Models;

namespace Lokbatan_Hotel.Services
{
    public interface IHomeService
    {
        Task<List<Home>> GetAvailableHomesAsync(DateTime startDate, DateTime endDate);
    }
}
