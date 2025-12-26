using KyrsClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace KyrsClient.Services
{
    public class ProductService : BaseService<Product>
    {
        private HttpClient httpClient;

        public ProductService()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization",
               "Bearer " + RegisterUser.access_token);
        }

        public override async Task Add(Product obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await httpClient.PostAsync("https://localhost:7229/api/Products", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Product resp = JsonSerializer.Deserialize<Product>(responseText)!;
                    if (resp == null) MessageBox.Show(responseText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
            }
        }

        public override async Task Delete(Product obj)
        {
            try
            {
                using var response = await httpClient.DeleteAsync($"https://localhost:7229/api/Products/{obj.ProductId}");
                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Ошибка удаления: {error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении товара: {ex.Message}");
            }
        }

        public override async Task<List<Product>> GetAll()
        {
            try
            {
                return (await httpClient.GetFromJsonAsync<List<Product>>("https://localhost:7229/api/Products"))!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении списка товаров: {ex.Message}");
                return new List<Product>();
            }
        }

        public override Task<List<Product>> Search(string str)
        {
            throw new NotImplementedException();
        }

        public override async Task Update(Product obj)
        {
            try
            {
                JsonContent content = JsonContent.Create(obj);
                using var response = await httpClient.PutAsync($"https://localhost:7229/api/Products/{obj.ProductId}", content);
                string responseText = await response.Content.ReadAsStringAsync();
                if (responseText != null)
                {
                    Product resp = JsonSerializer.Deserialize<Product>(responseText)!;
                    if (resp == null) MessageBox.Show(responseText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении товара: {ex.Message}");
            }
        }
    }
}