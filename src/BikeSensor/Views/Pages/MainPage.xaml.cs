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
        private DateTime startTime;
        public MainPage()
        {
            InitializeComponent();
        }
        public async Task Timer()
        {
            DurationLb.Text = "00:00:00";

            DurationLb.IsVisible = true;
            while (isRunning)
            {
                DurationLb.Text = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");
                await Task.Delay(1000);
            }
            DurationLb.IsVisible = false;
            DurationLb.Text = "00:00:00";

        }


        void TriggerBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            if (!BluetoothManager.IsConnected())
            {
                BluetoothManager.ConnectAsync();
                DisplayAlert("Attention!", "Veuillez vous connecter à l'appareil pour démarrer un enregistrement.", "Ok");
                return;
            }
            ActivityIndicatorBtn.IsVisible = true;
            TriggerBtn.IsVisible = false;

            if (isRunning)
            {
                new Thread(new ThreadStart(async () =>
                {
                    string token = await BluetoothManager.StopRecording();
                    if(token == "TimeOut")
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            DisplayAlert("Erreur!", "L'envoi des données a échoué. TimeOut", "Ok");
                        });
                    }
                    else
                    {
                        RecordModel record = await BluetoothManager.RequestData(token);
                        if (record.Success)
                            Persistence.AddRecord(record);
                        else
                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                DisplayAlert("Erreur!", "L'envoi des données a échoué.", "Ok");
                            });
                    }
                  
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        TriggerBtn.Text = "Démarrer";
                        TriggerBtn.IsVisible = true;
                        ActivityIndicatorBtn.IsVisible = false;

                        TriggerBtn.BackgroundColor = (Color)Application.Current.Resources["MainGreen"];
                    });
                })).Start();
                isRunning = !isRunning;


            }
            else
            {
                isRunning = !isRunning;
                startTime = DateTime.Now;
                Timer();
                new System.Threading.Thread(new System.Threading.ThreadStart(async () =>
                {
                    await BluetoothManager.StartRecording();

                })).Start();
                TriggerBtn.Text = "Arrêter";
                TriggerBtn.BackgroundColor = Color.Red;
                TriggerBtn.IsVisible = true;
                ActivityIndicatorBtn.IsVisible = false;

            }
        }


    }
}
