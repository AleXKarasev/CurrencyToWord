using System;

namespace Server.BusinessLogic.Implementation
{
    public class WordPresentationService : IWordPresentationService
    {
        public string GetWordPresentation(decimal currency)
        {
            return currency.ToString();
        }
    }
}