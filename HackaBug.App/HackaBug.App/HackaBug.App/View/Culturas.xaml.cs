using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackaBug.App.Controller;
using HackaBug.App.Model;
using HackaBug.App.ViewModel;
using Xamarin.Forms;

namespace HackaBug.App.View
{
    public partial class Culturas : ContentPage
    {
        public Culturas()
        {
            InitializeComponent();
            BindingContext = new CulturaViewModel();

            listcultura.ItemTapped += async (sender, e)=>
            {
                var cultura = e.Item as Model.Cultura;
                CulturaViewModel model = new CulturaViewModel();
                model.nomeCultura = cultura.Nome;
                model.Id = cultura.Id;
                BindingContext = model;
            };
        }
    }
}
