using Windows.UI.Xaml.Controls; 
 
using SearchFood.SearchFoodServiceReference;

namespace SearchFood
{ 
    public sealed partial class MainPage : Page
    {
        SearchFoodServiceClient client = new SearchFoodServiceClient();

        public MainPage()
        {
            this.InitializeComponent();
        } 
    }
}
