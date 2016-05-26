using SimpleInjector.Integration.Wcf;
using System;
using System.ServiceModel;

namespace Server.DI
{
    public class WcfServiceFactory : SimpleInjectorServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new SimpleInjectorServiceHost(
                Bootstrapper.Container,
                serviceType,
                baseAddresses);
        }
    }
}