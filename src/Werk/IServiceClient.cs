using System;
using System.Threading.Tasks;

namespace Skunkworks.Werk
{
    public interface IServiceClient : IDisposable
    {
        Task PostAsync<T>(string uri, T message);
    }
}
