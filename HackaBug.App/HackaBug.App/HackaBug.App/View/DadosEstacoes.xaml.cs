using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackaBug.App.ViewModel;
using Xamarin.Forms;

namespace HackaBug.App.View
{
    public partial class DadosEstacoes : ContentPage
    {
        public DadosEstacoes(int id)
        {
            InitializeComponent();

            BindingContext = new EstacaoViewModel(id);
        }
    }
}
