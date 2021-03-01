using System;
using BikeSensor.Views;
using BikeSensor.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeSensor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new RegisterPage());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
