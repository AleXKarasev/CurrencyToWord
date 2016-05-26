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
            return this.wordPresentationService.GetWordPresentation(currency);
        }
    }
}
