using System;
using System.Net.Http;
using System.Threading.Tasks;
using Skunkworks.Werk;

namespace Skunkworks.Werk
{
    public sealed class HttpServiceClient : IServiceClient
    {
        private static readonly Lazy<IServiceClient> instanceProducer = new Lazy<IServiceClient>(() => new HttpServiceClient());
        private readonly HttpClient httpClient;

        private HttpServiceClient()
        {
            this.httpClient = new HttpClient();
        }

        public static IServiceClient Instance => instanceProducer.Value;

        public async Task PostAsync<T>(string uri, T message)
        {
            using (var response = await httpClient.PostAsJsonAsync(uri, message))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.httpClient.Dispose();
            }
        }
    }
}
