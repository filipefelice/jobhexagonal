using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISEntrega.Core.Jobs.Helpers
{
    public interface IRoboAPI
    {
        Task<string> ProcessaFaturamento();
    }

    public class RoboAPI : IRoboAPI
    {
        private readonly HttpClient _client;

        public RoboAPI(IConfiguration configuration)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(configuration.GetSection("URIs").GetValue<string>(nameof(RoboAPI)))
            };

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = httpClient;
        }

        public async Task<string> ProcessaFaturamento()
        {
            using (var response = _client.GetAsync("/api/faturamento").Result)
            {
                if (response.IsSuccessStatusCode)
                    return await response.Content.ReadAsStringAsync();
                else                
                    throw new Exception($"{(int)response.StatusCode} - {await response.Content.ReadAsStringAsync()}");                
            }
        }
    }
}
