using System;
using System.Collections.Generic;
using BikeSensor.API;
using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class PreferencePage : ContentPage
    {
        public PreferencePage()
        {
            InitializeComponent();
            UpdateUI();
        }

        public void UpdateUI()
        {
            if (BluetoothManager.IsConnected())
            {
                DisconnectBtn.Text = "Se déconnecter";
                DisconnectBtn.TextColor = Color.Red;
            }
            else
            {
                DisconnectBtn.Text = "Se connecter";
                DisconnectBtn.TextColor = Color.Blue;

            }

        }
        void DisconnectBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (BluetoothManager.IsConnected())
            {
                BluetoothManager.Disconnect();

            }
            else
            {
                BluetoothManager.Connect();
            }
            UpdateUI();
        }

    }
}
