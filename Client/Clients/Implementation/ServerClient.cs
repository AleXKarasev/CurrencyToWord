using System.Threading.Tasks;

namespace Client.Clients.Implementation
{
    public class ServerClient : IServerClient
    {
        public async Task<string> CurrencyToWord(decimal currency)
        {
            using (var client = new RemoteServer.CurrencyToWordServiceClient())
            {
                return await client.CurrencyToWordAsync(currency).ConfigureAwait(false);
            }
        }
    }
}
