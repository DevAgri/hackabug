using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HackaBug.App.Controller;
using HackaBug.App.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HackaBug.App.ViewModel
{
   public class CulturaViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CulturaViewModel()
        {
            CarregaDados();
            ButtonCadastrar = new Command(ExeCadastrar, OnExecute);
        }

        public Command ButtonCadastrar { get; }
        public List<Cultura> _listaCultura { get; set; }
        public List<Cultura> listaCultura
        {
            get { return _listaCultura; }
            set
            {
                _listaCultura = value;
                OnPropertyChanged();
            }
        }

        public string nomeCultura { get { return _cultura; } set { _cultura = value; OnPropertyChanged(); } }
        public string _cultura { get; set; }
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }
        public int _id { get; set; }

        private async void CarregaDados()
        {
            listaCultura = null;
            using (var cliente = new HttpClient())
            {
                var json = await cliente.GetStringAsync("http://drogaterra.com.br/api/culturas");
                listaCultura = JsonConvert.DeserializeObject<List<Cultura>>(json);

            }
        }

        public async void ExeCadastrar()
        {
            if (String.IsNullOrEmpty(nomeCultura))
            {
                await App.Current.MainPage.DisplayAlert("Atenção!!!",
                    "Para realizar o Cadastro é necessário preencher o campo", "OK");
            }
            else
            {
                Cultura cultura = new Cultura();
                cultura.Id = Id;
                cultura.Nome = nomeCultura;
                cultura.Status = true;
                if (cultura.Id != null && cultura.Id != 0)
                {
                    new CulturaController().Update(cultura);
                    CarregaDados();
                }
                else
                {
                    new CulturaController().Cadastrar(cultura);
                    CarregaDados();
                }
                nomeCultura = "";
            }
        }

        public void Altera(Cultura cultura)
        {
            nomeCultura = cultura.Nome;
            Id = cultura.Id;
        }

        public bool OnExecute()
        {
            return true;
        }
    }
}
