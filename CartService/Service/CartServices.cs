using CartService.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CartService.Service
{
    public class CartServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _filepath;
        private List<CartModel> _orders;

        public CartServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _filepath = "Orders.json";
            _orders = LoadOrders();
        }

        public async Task<List<ProductModel>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/Product");
            if (response.IsSuccessStatusCode)
            {
                var ordersJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductModel>>(ordersJson);
            }
            else
            {
                throw new Exception($"Failed to retrieve products. Status code: {response.StatusCode}");
            }
        }

        private List<CartModel> LoadOrders()
        {
            try
            {
                string jsonData = File.ReadAllText(_filepath);
                return JsonConvert.DeserializeObject<List<CartModel>>(jsonData) ?? new List<CartModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading products: {ex.Message}");
                return new List<CartModel>();
            }
        }

        private void SaveOrders()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(_orders);
                File.WriteAllText(_filepath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving products: {ex.Message}");
            }
        }

        public List<CartModel> GetAllOrders()
        {
            foreach (var order in _orders)
            {
                order.Products = GetProductsAsync().Result.Where(p => order.ProductId.Contains(p.ID)).ToList();
            }
            return _orders;
        }

        public CartModel GetOrderById(int id)
        {
            var order = _orders.FirstOrDefault(p => p.CartId == id);
            if (order != null)
            {
                order.Products = GetProductsAsync().Result.Where(p => order.ProductId.Contains(p.ID)).ToList();
            }
            return order;
        }

        public void AddOrder(CartModel order)
        {
            try
            {
                order.CartId = _orders.Count > 0 ? _orders.Max(p => p.CartId) + 1 : 1;
                order.OrderDate = DateTime.Now;
                order.ExpectedDeliveryDate = DateTime.Now.AddDays(7);
                _orders.Add(order);
                SaveOrders();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding product: {ex.Message}");
            }
        }
    }
}
