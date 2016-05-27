using System.Threading.Tasks;

namespace Client.Clients
{
    public interface IServerClient
    {
        Task<string> CurrencyToWord(decimal currency);
    }
}
