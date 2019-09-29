using MyAppBuscarCEP.Clients;
using MyAppBuscarCEP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyAppBuscarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new BuscaCepViewModel();
        }

        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await ViaCepHttpClient.Current.BuscarCep(((BuscaCepViewModel)BindingContext).CEP);

                if (string.IsNullOrWhiteSpace(result.cep))
                {
                    await DisplayAlert("eita", result.cep, "OK");
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("ah não", ex.Message, "ok");
            }
        }
    }
}
