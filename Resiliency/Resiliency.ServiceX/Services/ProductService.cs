﻿namespace Resiliency.ServiceX.Services
{
    public class ProductService
    {
        private readonly HttpClient _client;
        private readonly ILogger<ProductService> _logger;

        public ProductService(HttpClient client, ILogger<ProductService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _client.GetFromJsonAsync<Product>($"{id}");

            _logger.LogInformation("products:{@id}-{@name}", product.Id, product.Name);

            return product;
        }
    }
}
