using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Lokbatan_Hotel.Tests.Integration
{


    public class BookingIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        [Fact]
        public async Task GetAvailableHomes_InvalidDate_ShouldReturnBadRequest()
        {
            var url = "/api/booking/available-homes?startDate=invalid&endDate=2025-08-16";
            var response = await _client.GetAsync(url);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        private readonly HttpClient _client;

        public BookingIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAvailableHomes_ShouldReturnSuccessAndValidStructure()
        {
            // Arrange
            var url = "/api/booking/available-homes?startDate=2025-08-15&endDate=2025-08-16";

            // Act
            var response = await _client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = await response.Content.ReadFromJsonAsync<AvailableHomesResponse>();
            Assert.Equal("OK", data.status);
            Assert.NotNull(data.homes);
        }
    }

    public class AvailableHomesResponse
    {
        public string status { get; set; }
        public List<HomeDto> homes { get; set; }
    }

    public class HomeDto
    {
        public string homeId { get; set; }
        public string homeName { get; set; }
        public List<string> availableSlots { get; set; }
    }
}