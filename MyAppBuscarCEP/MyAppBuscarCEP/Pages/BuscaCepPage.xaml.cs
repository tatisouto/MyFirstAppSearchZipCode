using MyAppBuscarCEP.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyAppBuscarCEP.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaCepPage : ContentPage
    {
        public BuscaCepPage()
        {
            InitializeComponent();

            BindingContext = new BuscaCepViewModel();
        }
    }
}