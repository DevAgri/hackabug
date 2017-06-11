using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HackaBug.App.Annotations;
using HackaBug.App.Controller;
using HackaBug.App.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HackaBug.App.ViewModel
{
    public class DadosPlantioViewModel: INotifyPropertyChanged
    {
        public Command ButtonCadastrar { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public DadosPlantio DadoPlantio { get { return _DadosPlantio; }set
        {
            _DadosPlantio = value; OnPropertyChanged();}}
        public DadosPlantio _DadosPlantio { get; set; }

        public List<DadosPlantio> ListaDadosPlantios { get { return _listaDadosPlantio; } set { _listaDadosPlantio = value; OnPropertyChanged(); } }
        public List<DadosPlantio> _listaDadosPlantio { get; set; }
        public List<Cultura> Culturas { get { return _Culturas; } set { _Culturas = value; OnPropertyChanged(); } }
        public List<Cultura> _Culturas { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DadosPlantioViewModel()
        {
            ButtonCadastrar = new Command(ExecutaButton, Onexecute);
            CarregaView();
            ListCulturas();
        }
        

        public bool Onexecute()
        {
            return true;
        }

        public async void ExecutaButton()
        {
            if (String.IsNullOrEmpty(DadoPlantio.Tecnologia))
            {
                await App.Current.MainPage.DisplayAlert("Atenção!!!",
                    "Para realizar o Cadastro é necessário preencher o campo", "OK");
            }
            else
            {
                DadosPlantio dado = new DadosPlantio();
                dado = DadoPlantio;

                if (dado.Id != null)
                {
                    new DadosPlantioController().Update(dado);
                }
                else
                {
                    new DadosPlantioController().Cadastrar(dado);
                }
            }
            DadoPlantio.Tecnologia = null;

        }

        public async void CarregaView()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://drogaterra.com.br/api/plantio");
                ListaDadosPlantios = JsonConvert.DeserializeObject<List<DadosPlantio>>(json);
            }
        }

        public async void ListCulturas()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://drogaterra.com.br/api/culturas");
                Culturas = JsonConvert.DeserializeObject<List<Cultura>>(json);
            }
        }

    }
}
