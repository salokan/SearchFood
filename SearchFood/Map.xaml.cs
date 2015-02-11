using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238
using SearchFood.Webservices;

namespace SearchFood
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Map : Page
    {
        Services _service = new Services();

        public Map()
        {
            this.InitializeComponent();
        }
    }
}
