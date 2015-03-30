using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238
using SearchFood.Navigation;

namespace SearchFood.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Restau : Page, IView
    {
        public Restau()
        {
            this.InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return this.DataContext as IViewModel; }
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