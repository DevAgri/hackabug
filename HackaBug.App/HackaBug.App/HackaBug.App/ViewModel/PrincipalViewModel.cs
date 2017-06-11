using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using HackaBug.App.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace HackaBug.App.ViewModel
{
    public class PrincipalViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
           
        }
        public List<Estacoes> ListaEstacoes {
            get { return _listaEstadoes; }
            set { _listaEstadoes = value; OnPropertyChanged(); }
        }
        public List<Estacoes> _listaEstadoes { get; set;}

        public PrincipalViewModel()
        {
            CarregadaDados();
        }

        public async void CarregadaDados()
        {
            ListaEstacoes = null;
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://drogaterra.com.br/api/estacoes");
                ListaEstacoes = JsonConvert.DeserializeObject<List<Estacoes>>(json);
            }
        }

        
    }
}