using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackaBug.App.View;
using Xamarin.Forms;

namespace HackaBug.App
{
    public class App : Application
    {

        public static MasterDetailPage MasterDetail { get; set; }

        public async static Task MasterDetailPage(Page page)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(page);
        }

        public App()
        {
            
            MainPage = new MasterPage();
            MainPage.Icon = null;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
