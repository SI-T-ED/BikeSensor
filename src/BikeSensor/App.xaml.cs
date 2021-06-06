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

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabPage());
           
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
