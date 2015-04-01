/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SearchFood"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SearchFood.Navigation;

namespace SearchFood.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
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

        public SearchViewModel Search
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        public AccountViewModel Account
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccountViewModel>();
            }
        }

        public RestauViewModel Restau
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RestauViewModel>();
            }
        }

        public CreateRestaurantViewModel CreateRestaurant
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreateRestaurantViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<LogViewModel>();
            SimpleIoc.Default.Register<RestauViewModel>();
            SimpleIoc.Default.Register<AccountViewModel>();
            SimpleIoc.Default.Register<CreateRestaurantViewModel>();
        }
    }
}