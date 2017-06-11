using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackaBug.App.ViewModel;
using Xamarin.Forms;

namespace HackaBug.App.View
{
    public partial class Pragas : ContentPage
    {
        public Pragas()
        {
            InitializeComponent();
            BindingContext = new PragasViewModel();

            listPragas.ItemTapped += async (sender, e) =>
            {
                var praga = e.Item as Model.Pragas;
                PragasViewModel model = new PragasViewModel();
                model.nomePraga = praga.Nome;
                model.Id = praga.Id;
                BindingContext = model;
            };
        }
    }
}
