using Server.BusinessLogic;

namespace Server
{    
    public class CurrencyToWordService : ICurrencyToWordService
    {
        private readonly IWordPresentationService wordPresentationService;

        public CurrencyToWordService(IWordPresentationService wordPresentationService)
        {
            this.wordPresentationService = wordPresentationService;
        }

        public string CurrencyToWord(decimal currency)
        {
            System.Threading.Thread.Sleep(1000); // Simulate a remote server work
            return this.wordPresentationService.GetWordPresentation(currency);
        }
    }
}
