using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BikeSensor.API;
using BikeSensor.Classes;
using BikeSensor.Views;
using BikeSensor.Views.Pages;

using Plugin.BluetoothClassic.Abstractions;
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
                MainPage.Navigation.PushAsync(new TabPage());
            }
        }

        protected override void OnStart()
        {
            Persistence.LoadRecords();
            BluetoothManager.Init();

        }

 

        protected override void OnResume()
        {
        }

      

      

       
    }
}
