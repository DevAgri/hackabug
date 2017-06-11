using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackaBug.App.Model;
using HackaBug.App.ViewModel;
using Xamarin.Forms;

namespace HackaBug.App.View
{
    public partial class PrincipalView : ContentPage
    {
        public PrincipalView()
        {
            InitializeComponent();

            BindingContext  = new PrincipalViewModel();

            this.listEstacoes.ItemTapped += async (sender, e) =>
            {
                var estacao = e.Item as Estacoes;
                await App.MasterDetailPage(new DadosEstacoes(estacao.Id));

            };
        }
    }
}
