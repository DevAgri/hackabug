using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HackaBug.App.Model;
using Newtonsoft.Json;

namespace HackaBug.App.ViewModel
{
    public class EstacaoViewModel: INotifyPropertyChanged
    {
        public List<Estacoes> listaEstacoes { get; set; }
        public Estacoes _estacoes { get; set; }
        public Estacoes Estacoes { get { return _estacoes; }
            set { _estacoes = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EstacaoViewModel(int id)
        {
            CarregaDados(id);
        }

        private async void CarregaDados(int id)
        {
            using (var cliente = new HttpClient())
            {
                string link = String.Format("http://drogaterra.com.br/api/estacoes/{0}",id);
                var json = await cliente.GetStringAsync(link);
                Estacoes = JsonConvert.DeserializeObject<Estacoes>(json);
            }
        }

    }
}