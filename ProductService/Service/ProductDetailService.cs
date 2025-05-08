using Newtonsoft.Json;
using ProductService.Model;

namespace ProductService.Service
{
    public class ProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductModel>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/Product");
            if (response.IsSuccessStatusCode)
            {
                var productsJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductModel>>(productsJson);
            }
            else
            {
                throw new Exception($"Failed to retrieve products. Status code: {response.StatusCode}");
            }
        }
    }
}
