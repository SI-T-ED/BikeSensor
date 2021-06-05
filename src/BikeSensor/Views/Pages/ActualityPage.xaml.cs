using System;
using System.Collections.Generic;
using System.Linq;
using BikeSensor.Classes;
using BikeSensor.Model;
using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class ActualityPage : ContentPage
    {
        public List<RecordModelView> RecordModelsView { get; set; }
        public ActualityPage()
        {
            InitializeComponent();
            Persistence.LoadRecords();
            var RecordModels = Persistence.GetRecords();
            RecordModelsView = new List<RecordModelView>();
            foreach (var item in RecordModels)
            {
                RecordModelsView.Add(new RecordModelView(item));
            }
            RecordModelsView = RecordModelsView.OrderBy(o => o.Date).Reverse().ToList();
            ListView.ItemsSource = RecordModelsView;
        }
     
        protected override void OnDisappearing()
        {
            ListView.SelectedItem = null;
        }

        void ListView_Refreshing(System.Object sender, System.EventArgs e)
        {
            ListView.IsRefreshing = true;

            var RecordModels = Persistence.GetRecords();
            RecordModelsView = new List<RecordModelView>();
            foreach (var item in RecordModels)
            {
                RecordModelsView.Add(new RecordModelView(item));
            }
            RecordModelsView = RecordModelsView.OrderBy(o => o.Date).Reverse().ToList();
            ListView.ItemsSource = RecordModelsView;
            ListView.IsRefreshing = false;
        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ActivityPage(RecordModelsView[e.ItemIndex]));

        }
    }
}
