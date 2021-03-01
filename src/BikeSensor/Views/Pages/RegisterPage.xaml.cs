using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void RegisterBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TabPage());
        }

        void LoginPageBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }
    }
}
