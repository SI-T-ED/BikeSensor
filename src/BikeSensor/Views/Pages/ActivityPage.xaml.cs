using System;
using System.Collections.Generic;
using BikeSensor.Model;
using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage(RecordModelView recordModelView)
        {
            InitializeComponent();
            GraphContent.RecordModel = recordModelView;
            GraphContent.LoadGraph();
        }

        void BackBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
