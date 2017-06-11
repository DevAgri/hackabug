using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace HackaBug.App.View
{
    public class Navigation : NavigationPage
    {
        public Navigation()
            : base()
        {
            BarBackgroundColor = Color.FromHex("#2f3032");
            BarTextColor = Color.FromHex("#2f3032");
        }


        public Navigation(Page root)
            : base(root)
        {
            BarBackgroundColor = Color.FromHex("#2f3032");
            BarTextColor = Color.FromHex("#2f3032");
            
        }
    }
}
