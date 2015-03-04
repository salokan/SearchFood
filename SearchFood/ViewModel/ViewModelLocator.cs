using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SearchFood.Navigation;

namespace SearchFood.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INavigationService, DesignNavigationService>();
            }
            else
            {
                SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());
            }
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LogViewModel Log
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogViewModel>();
            }
        }

        public SearchModelView Search
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchModelView>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SearchModelView>();
            SimpleIoc.Default.Register<LogViewModel>();
        }
    }
}