using InventoryService.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InventoryService.Service
{
    public class ProductService
    {
        private readonly string filePath;
        private List<ProductModel> _products;

        public ProductService(string filePath)
        {
            this.filePath = filePath;
            _products = LoadProducts();
        }

        private List<ProductModel> LoadProducts()
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<ProductModel>>(jsonData) ?? new List<ProductModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading products: {ex.Message}");
                return new List<ProductModel>();
            }
        }

        private void SaveProducts()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(_products);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving products: {ex.Message}");
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            return _products;
        }

        public ProductModel GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            return product;
        }

        public void AddProduct(ProductModel product)
        {
            try
            {
                product.ID = _products.Count > 0 ? _products.Max(p => p.ID) + 1 : 1;
                _products.Add(product);
                SaveProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding product: {ex.Message}");
            }
        }

        public void UpdateProduct(int id, ProductModel updatedProduct)
        {
            try
            {
                var existingProduct = _products.FirstOrDefault(p => p.ID == id);
                if (existingProduct != null)
                {
                    existingProduct.Size = updatedProduct.Size;
                    existingProduct.Price = updatedProduct.Price;
                    existingProduct.Design = updatedProduct.Design;
                    SaveProducts();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating product: {ex.Message}");
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _products.RemoveAll(p => p.ID == id);
                SaveProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting product: {ex.Message}");
            }
        }
    }
}
