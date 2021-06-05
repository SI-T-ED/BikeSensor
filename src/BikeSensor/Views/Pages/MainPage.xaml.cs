using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BikeSensor.API;
using BikeSensor.Classes;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class MainPage : ContentPage
    {
        private bool isRunning = false;
        private String token = "";
        public MainPage()
        {
            InitializeComponent();
        }

        void TriggerBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            TriggerBtn.IsEnabled = false;
            if (isRunning)
            {
                new Thread(new ThreadStart(async () =>
                {
                    string token = await BluetoothManager.StopRecording();
                    RecordModel record = await BluetoothManager.RequestData(token);
                    if (record.Success)
                        Persistence.AddRecord(record);
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        TriggerBtn.Text = "Démarrer";
                        TriggerBtn.IsEnabled = true;
                        TriggerBtn.BackgroundColor = (Color)Application.Current.Resources["MainGreen"];
                    });
                })).Start();


            }
            else
            {
                new System.Threading.Thread(new System.Threading.ThreadStart(async () =>
                {
                    await BluetoothManager.StartRecording();

                })).Start();
                TriggerBtn.Text = "Arrêter";
                TriggerBtn.BackgroundColor = Color.Red;
                TriggerBtn.IsEnabled = true;

            }
            isRunning = !isRunning;
        }


    }
}
