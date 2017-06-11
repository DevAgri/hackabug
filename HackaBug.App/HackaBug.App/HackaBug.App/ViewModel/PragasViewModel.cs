using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using HackaBug.App.Controller;
using HackaBug.App.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HackaBug.App.ViewModel
{
    public class PragasViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command ButtonCadastrar { get; }

        public List<Pragas> listaPragas {
            get { return _listaPragas; }
            set
            {
                _listaPragas = value;
                OnPropertyChanged();
            } }

        public string nomePraga { get { return _pragas; } set { _pragas = value; OnPropertyChanged(); } }
        public string _pragas { get; set; }
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        public int _id { get; set; }


        public List<Pragas> _listaPragas { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PragasViewModel()
        {
            ButtonCadastrar = new Command(ExecutaButton, OnExecuteButton);
            CarregaLista();
        }

        private bool OnExecuteButton()
        {
            return true; 
        }

        async void ExecutaButton()
        {
            if (String.IsNullOrEmpty(nomePraga))
            {
                await App.Current.MainPage.DisplayAlert("Atenção!!!",
                    "Para realizar o Cadastro é necessário preencher o campo", "OK");
            }
            else
            {
                Pragas praga = new Pragas();
                praga.Id = Id;
                praga.Nome = nomePraga;
                praga.Status = true;
                if (praga.Id != null && praga.Id != 0)
                {
                    new PragasController().Update(praga);
                    CarregaLista();
                }
                else
                {
                    new PragasController().Cadastrar(praga);
                    CarregaLista();
                }
                nomePraga = "";
            }
        }

        async void CarregaLista()
        {
            listaPragas = null;
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://drogaterra.com.br/api/pragas");
                listaPragas =  JsonConvert.DeserializeObject<List<Pragas>>(json);
            }
        }

        
    }
}