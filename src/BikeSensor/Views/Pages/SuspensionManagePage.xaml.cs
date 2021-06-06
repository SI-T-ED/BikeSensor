using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeSensor.API;
using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class SuspensionManagePage : ContentPage
    {
        public bool isConnected = true;
        public SuspensionManagePage()
        {
            InitializeComponent();
           
        }

        private Task GetBattery()
        {
            BatteryLb.Text = "Batterie: " + BluetoothManager.RequestBattery() + "%";
            return Task.CompletedTask;
        }

        protected override void OnAppearing()
        {
            if (BluetoothManager.IsConnected())
            {
                ConnectedLayout.IsVisible = true;
                DisconectedLayout.IsVisible = false;
                SuspensionImage.Source = "SuspensionSelected.png";
                GetBattery();
            }
            else
            {
                DisconectedLayout.IsVisible = true;
                ConnectedLayout.IsVisible = false;

                SuspensionImage.Source = "SuspensionNoSelected.png";
            }

        }

        void AddSuspensionBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PreferencePage());
        }

    }
}
