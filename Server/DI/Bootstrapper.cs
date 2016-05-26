using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using Server.BusinessLogic;
using Server.BusinessLogic.Implementation;

namespace Server.DI
{
    public static class Bootstrapper
    {
        public static readonly Container Container;

        static Bootstrapper()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();
                        
            RegisterServices(container);
            RegisterBusinessLogicServices(container);

            container.Verify();

            Container = container;
        }

        private static void RegisterServices(Container container)
        {
            container.Register<ICurrencyToWordService, CurrencyToWordService>();
        }       
        
        private static void RegisterBusinessLogicServices(Container container)
        {
            container.Register<IWordPresentationService, WordPresentationService>();
        }
    }
}