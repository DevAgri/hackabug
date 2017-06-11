using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HackaBug.App.Model;
using Newtonsoft.Json;

namespace HackaBug.App.Controller
{
    public class CulturaController
    {
        public async void Cadastrar(Cultura cultura)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(cultura);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://drogaterra.com.br/api/culturas", content);
                App.Current.MainPage.DisplayAlert("Mensagem", "Cadastrado com sucesso", "Ok");
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Mensagem", "Não foi possivel realizar o cadastro", "Ok");

            }
        }

        public async void Update(Cultura cultura)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(cultura);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://drogaterra.com.br/api/culturas/" + cultura.Id, content);
                App.Current.MainPage.DisplayAlert("Mensagem", "Alterado com sucesso", "Ok");
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Mensagem", "Não foi possivel realizar a execução", "Ok");

            }
        }

       
    }
}