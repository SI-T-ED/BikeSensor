using System;
using System.Diagnostics;
using BikeSensor.Interfaces;
using BikeSensor.Views;
using BikeSensor.Views.Pages;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BikeSensor
{
    public partial class App : Application
    {
        bool connected = false;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new TabPage());
            if(!connected)
            {
                MainPage.Navigation.PushAsync(new RegisterPage());
            }
        }

        protected override void OnStart()
        {
            BluetoothCommunication();
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

        void BluetoothCommunication()
        {
            try
            {
                // At startup, I load all paired devices
                DependencyService.Get<IBth>().Start("BikeSensor", 10, true);
                Debug.WriteLine("test");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Attention", ex.Message, "Ok");
            }



        }
    }
}
