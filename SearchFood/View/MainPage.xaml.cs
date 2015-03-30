using Windows.UI.Xaml.Navigation;
using SearchFood.Navigation;

namespace SearchFood.View
{
    public sealed partial class MainPage : IView
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.OnNavigatedTo();
        }   
    }
}
