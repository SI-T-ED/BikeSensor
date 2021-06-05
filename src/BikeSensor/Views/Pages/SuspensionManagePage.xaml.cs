using System;
using System.Collections.Generic;
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

        protected override void OnAppearing()
        {
            if (BluetoothManager.IsConnected())
            {
                ConnectedLayout.IsVisible = true;
                DisconectedLayout.IsVisible = false;
                SuspensionImage.Source = "SuspensionSelected.png";
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
