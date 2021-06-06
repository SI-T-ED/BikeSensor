using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BikeSensor.Model;
using Xamarin.Forms;

namespace BikeSensor.Views.Pages
{
    public partial class ActivityPage : ContentPage
    {
        private RecordModelView modelView;
        int vector = 50*50;
        int Lmin = 0;
        int Lpos = 0;
        int pos = 0;
        bool lastEnded = true;
        DateTime lastUpdate = DateTime.Now;
        public ActivityPage(RecordModelView recordModelView)
        {
            InitializeComponent();
            modelView = recordModelView;
            GraphContent.RecordModel = recordModelView;
            int max = (recordModelView.Datas.Count > 100) ? 100 : recordModelView.Datas.Count - 1;
            GraphContent.LoadGraph(0, max);
            DateLb.Text = recordModelView.Date.ToShortDateString();
            DurationLb.Text = recordModelView.DurationText;
            MeanIntensityLb.Text = recordModelView.MaxMeanPourcentage;

            
        }

        void BackBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        async void ScrollGraph_Scrolled(System.Object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
            if (!lastEnded)
                return;

            if((lastUpdate - DateTime.Now).TotalSeconds > 3)
                return;
            lastUpdate = DateTime.Now;
            pos += ((int)(e.ScrollX - Lpos));
            int minPos = pos - vector;
            minPos = (minPos < 0) ? 0 : minPos;

            int maxPos = pos + vector;
            Lpos = (int)e.ScrollX;
            maxPos = (maxPos > modelView.Datas.Count * 50) ? modelView.Datas.Count * 50 : maxPos;
            Lmin = minPos;
            lastEnded = false;
            lastEnded = await GraphContent.LoadGraph(minPos / 50, maxPos / 50);
        }
    }
}
