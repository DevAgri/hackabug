using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace HackaBug.App.View
{
    public partial class Menus : ContentPage
    {
        public Menus()
        {
            InitializeComponent();
        }


        public async void Pragas(object sender, EventArgs e)
        {
            await App.MasterDetailPage(new Pragas());
        }

        public async void Culturas(object sender, EventArgs e)
        {
            await App.MasterDetailPage(new Culturas());
        }

        public async void Plantios(object sender, EventArgs e)
        {
            await App.MasterDetailPage(new Plantios());
        }
    }
}
