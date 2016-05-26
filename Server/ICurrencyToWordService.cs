using System.ServiceModel;

namespace Server
{
    /// <summary>
    ///     Service for currency
    /// </summary>
    [ServiceContract]
    public interface ICurrencyToWordService
    {
        /// <summary>
        ///     Return word precentation of currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns></returns>
        [OperationContract]
        string CurrencyToWord(decimal currency);
    }    
}
