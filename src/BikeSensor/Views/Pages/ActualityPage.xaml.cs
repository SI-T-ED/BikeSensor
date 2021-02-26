using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class ActualityPage : ContentPage
    {
        public ActualityPage()
        {
            InitializeComponent();
        }
        void ListView_ItemSelected(ListView sender, SelectedItemChangedEventArgs e)
        {
            int id = 0;
            var item = e.SelectedItem;
            
            if(item != null)
                Navigation.PushAsync(new ActivityPage(id));

        }
        protected override void OnDisappearing()
        {
            ListView.SelectedItem = null;
        }
    }
}
