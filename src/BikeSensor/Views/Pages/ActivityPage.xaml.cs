using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage(int id)
        {
            InitializeComponent();
        }

        void BackBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
