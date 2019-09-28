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
        }

        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCep.Text))
                    throw new InvalidOperationException("Digite CEP");


                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync($"http://viacep.com.br/ws/{txtCep.Text}/json/"))
                    {
                        if (!response.IsSuccessStatusCode)
                            throw new InvalidOperationException("Algo de errado aconteceu.");

                        var result = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            await DisplayAlert("Resultado", result, "OK");
                        }

                    }
                };

            }
            catch (Exception ex)
            {

                await DisplayAlert("ah não", ex.Message, "ok");
            }
        }
    }
}
