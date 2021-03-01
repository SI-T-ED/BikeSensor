using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        void RegisterBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        void LoginBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TabPage());
        }
    }
}
