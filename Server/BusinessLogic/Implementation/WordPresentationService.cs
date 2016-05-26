using System;
using System.Linq;
using System.Collections.Generic;

namespace Server.BusinessLogic.Implementation
{
    internal class WordPresentationService : IWordPresentationService
    {
        #region Supporting dictionary

        private readonly IDictionary<int, string> numbers = new Dictionary<int, string>
        {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" }
        };

        private readonly IDictionary<int, string> rangs = new Dictionary<int, string>
        {
            { 0, "" },
            { 1, "thousand" },
            { 2, "million" }
        };

        #endregion

        public string GetWordPresentation(decimal currency)
        {
            var cents = this.GetCents(currency);
            var dollars = this.GetDollars(currency);

            return String.IsNullOrWhiteSpace(cents) ? dollars : dollars + " " + cents;
        }

        #region Private methods

        /// <summary>
        ///     Returns dollars presentation
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        private string GetDollars(decimal currency)
        {
            var dollars = (int)Math.Truncate(currency);

            var result = dollars == 1 ? "dollar" : "dollars";

            result = this.GetNumber(dollars) + result;

            return result;
        }

        /// <summary>
        ///     Returns cents presentation
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        private string GetCents(decimal currency)
        {
            var cents = (int)Math.Truncate((currency * 100) % 100);

            if (cents == 0)
            {
                return String.Empty;
            }

            var result = cents == 1 ? "cent" : "cents";

            result = this.GetNumber(cents) + result;

            return "and " + result;
        }

        /// <summary>
        ///     Split number by triad
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        private List<int> GetChunks(int currency)
        {
            var result = new List<int>();

            do
            {
                var last = currency % 1000;
                result.Add(last);
                currency = (currency - last) / 1000;
            }
            while (currency > 0);

            return result;
        }

        /// <summary>
        ///     Return number's word presentation
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        private string GetNumber(int currency)
        {
            var result = String.Empty;

            var chunks = this.GetChunks(currency);

            var rangChank = 0;
            foreach (var chunk in chunks)
            {
                if (chunk != 0 && rangChank > 0)
                {
                    result = rangs[rangChank] + " " + result;
                }
                rangChank++;                

                if (chunk == 0 && chunk != chunks.Last())
                {
                    continue;
                }

                if (chunk <= 20)
                {
                    result = numbers[chunk] + " " + result;
                    continue;
                }

                var first = chunk % 10;
                var second = (chunk / 10) % 10;
                var third = (chunk / 100) % 100;

                if (first > 0)
                {
                    result = numbers[first] + " " + result;
                }

                if (second > 0)
                {
                    result = numbers[second * 10] + " " + result;
                }

                if (third > 0)
                {
                    result = numbers[third] + " hundred " + result;
                }                
            }

            return result;
        }

        #endregion
    }
}