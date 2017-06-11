﻿using System;
using System.Net.Http;
using System.Text;
using HackaBug.App.Model;
using Newtonsoft.Json;

namespace HackaBug.App.Controller
{
    public class DadosPlantioController
    {
        public async void Cadastrar(DadosPlantio dado)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(dado);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://drogaterra.com.br/api/culturas", content);
                App.Current.MainPage.DisplayAlert("Mensagem", "Cadastrado com sucesso", "Ok");
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Mensagem", "Não foi possivel realizar o cadastro", "Ok");

            }
        }

        public async void Update(DadosPlantio dado)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(dado);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("http://drogaterra.com.br/api/culturas/"+dado.Id, content);
                App.Current.MainPage.DisplayAlert("Mensagem", "Alterado com sucesso", "Ok");
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Mensagem", "Não foi possivel realizar a execução", "Ok");

            }
        }
    }
}