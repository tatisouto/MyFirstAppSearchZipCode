using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyAppBuscarCEP.Clients
{
    public class ViaCepHttpClient
    {
        private static Lazy<ViaCepHttpClient> _Lazy = new Lazy<ViaCepHttpClient>(() => new ViaCepHttpClient());
        public static ViaCepHttpClient Current { get => _Lazy.Value; }

        private ViaCepHttpClient()
        {
            _httpClient = new HttpClient();
        }

        private readonly HttpClient _httpClient;

        public async Task<BuscaCepResult> BuscarCep(string cep)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cep))
                    throw new InvalidOperationException("Digite CEP");


                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync($"http://viacep.com.br/ws/{cep}/json/"))
                    {
                        if (!response.IsSuccessStatusCode)
                            throw new InvalidOperationException("Algo de errado aconteceu.");

                        var result = await response.Content.ReadAsStringAsync();

                        if (string.IsNullOrWhiteSpace(result))
                            throw new InvalidOperationException("Algo de errado ao onsultar cep.");


                        return JsonConvert.DeserializeObject<BuscaCepResult>(result);

                    }
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class BuscaCepResult
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }

    }
}

