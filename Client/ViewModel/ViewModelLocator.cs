using Client.Clients;
using Client.Clients.Implementation;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Client.ViewModel
{    
    public class ViewModelLocator
    {        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // viewModels
            SimpleIoc.Default.Register<MainViewModel>();

            // clients
            SimpleIoc.Default.Register<IServerClient, ServerClient>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            
        }
    }
}