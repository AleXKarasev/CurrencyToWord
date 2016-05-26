using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.BusinessLogic.Implementation;

namespace ServerTests.BusinessLogic
{
    [TestClass]
    public class WordPresentationServiceTests
    {
        [TestMethod]
        public void CurrencyToWord_0_MustReturnZeroDollars()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(0);

            Assert.AreEqual("zero dollars", result);
        }

        [TestMethod]
        public void CurrencyToWord_1_MustReturnOneDollar()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(1);

            Assert.AreEqual("one dollar", result);
        }

        [TestMethod]
        public void CurrencyToWord_25and1_MustReturnTwentyFiveDollarsAndTenCents()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(25.1m);

            Assert.AreEqual("twenty five dollars and ten cents", result);
        }

        [TestMethod]
        public void CurrencyToWord_0and01_MustReturnZeroDollarsAndOneCent()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(0.01m);

            Assert.AreEqual("zero dollars and one cent", result);
        }

        [TestMethod]
        public void CurrencyToWord_0and12_MustReturnZeroDollarsAndTwelveCents()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(0.12m);

            Assert.AreEqual("zero dollars and twelve cents", result);
        }

        [TestMethod]
        public void CurrencyToWord_0and54_MustReturnZeroDollarsAndTwelveCents()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(0.54m);

            Assert.AreEqual("zero dollars and fifty four cents", result);
        }

        [TestMethod]
        public void CurrencyToWord_45100_MustReturnFortyFiveThousandOneHundredDollars()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(45100);

            Assert.AreEqual("forty five thousand one hundred dollars", result);
        }

        [TestMethod]
        public void CurrencyToWord_1000000_MustReturnOneMillionDollars()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(1000000);

            Assert.AreEqual("one million dollars", result);
        }

        [TestMethod]
        public void CurrencyToWord_1000001_MustReturnOneMillionOneDollars()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(1000001);

            Assert.AreEqual("one million one dollars", result);
        }

        [TestMethod]
        public void CurrencyToWord_999999999and99_MustReturnNineHundredNinetyNineMillionNineHundredNinetyNineThousandNineHundredNinetyNineDollarsAndNinetyNineCents()
        {
            var target = new WordPresentationService();

            var result = target.GetWordPresentation(999999999.99m);

            Assert.AreEqual("nine hundred ninety nine million nine hundred ninety nine thousand nine hundred ninety nine dollars and ninety nine cents", result);
        }
    }
}
