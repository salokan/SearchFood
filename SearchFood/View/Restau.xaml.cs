using Windows.UI.Xaml.Navigation;
using SearchFood.Navigation;

namespace SearchFood.View
{
    public sealed partial class Restau : IView
    {
        public Restau()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                ViewModel.GetParameter(e.Parameter);
            }
        }      
    }
}