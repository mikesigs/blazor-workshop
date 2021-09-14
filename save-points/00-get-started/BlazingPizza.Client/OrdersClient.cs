using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
    public class OrdersClient
    {
        private readonly HttpClient _http;

        public OrdersClient(HttpClient http)
        {
            _http = http;
        }

        public Task<IEnumerable<OrderWithStatus>> GetOrders() => 
            _http.GetFromJsonAsync<IEnumerable<OrderWithStatus>>("orders");
        public Task<OrderWithStatus> GetOrder(int orderId) => 
            _http.GetFromJsonAsync<OrderWithStatus>($"orders/{orderId}");

        public async Task<int> PlaceOrder(Order order)
        {
            var response = await _http.PostAsJsonAsync("orders", order);
            response.EnsureSuccessStatusCode();
            var orderId = await response.Content.ReadFromJsonAsync<int>();
            return orderId;
        }

        public async Task SubscribeToNotifications(NotificationSubscription subscription)
        {
            var response = await _http.PutAsJsonAsync("notifications/subscribe", subscription);
            response.EnsureSuccessStatusCode();
        }
    }
}