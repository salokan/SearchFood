using GalaSoft.MvvmLight;
using SearchFood.Navigation;

namespace SearchFood.ViewModel
{
    public class SearchModelView : ViewModelBase
    {
        private INavigationService _navigationService;

        public SearchModelView(INavigationService navigation)
        {
            _navigationService = navigation;
        }
    }
}
