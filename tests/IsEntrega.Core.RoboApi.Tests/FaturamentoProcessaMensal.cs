namespace IsEntrega.WebApi.Tests
{
    using Autofac.Extensions.DependencyInjection;
    using ISEntrega.Core.RoboAPI;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.Configuration;    
    using System.Net.Http;    
    using System.Threading.Tasks;
    using Xunit;

    public class FaturamentoProcessaMensal
    {
        private readonly TestServer server;
        private readonly HttpClient client;

        public FaturamentoProcessaMensal()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    IHostingEnvironment env = builderContext.HostingEnvironment;
                    config.AddJsonFile("autofac.json")
                    .AddEnvironmentVariables();
                })
                .ConfigureServices(services => services.AddAutofac());

            server = new TestServer(webHostBuilder);
            client = server.CreateClient();
        }

        [Fact]
        public async Task Processa_Mensal()
        {            
            await EmiteFaturamentoMensal();         
        }

        private async Task EmiteFaturamentoMensal()
        {
            var result = await client.GetStringAsync("/api/faturamento/");
        }        
    }

    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = content
            };

            var response = await client.SendAsync(request);
            return response;
        }
    }
}
