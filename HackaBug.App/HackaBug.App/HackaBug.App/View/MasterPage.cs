using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace HackaBug.App.View
{
    public class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            this.Master = new Menus();
            this.Detail = new Navigation(new PrincipalView());
            App.MasterDetail = this;
        }
    }
}
