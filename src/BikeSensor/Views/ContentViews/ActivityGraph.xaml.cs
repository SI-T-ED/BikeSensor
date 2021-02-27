using System;
using System.Collections.Generic;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using Xamarin.Forms;

namespace BikeSensor.Views.ContentViews
{
    public partial class ActivityGraph : ContentView
    {
        public ActivityGraph()
        {
            InitializeComponent();

            var entries = new List<ChartEntry>()
            {
                new ChartEntry(0)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "V",
                    ValueLabel = "0%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                new ChartEntry(0)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "S",
                    ValueLabel = "0%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                new ChartEntry(0)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "D",
                    ValueLabel = "0%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                new ChartEntry(10)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "L",
                    ValueLabel = "10%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                 new ChartEntry(4)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "M",
                    ValueLabel = "4%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                  new ChartEntry(12)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "M",
                    ValueLabel = "12%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                   new ChartEntry(9)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "J",
                    ValueLabel = "9%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                }

            };
            //var chartView = new ChartView();
            chartView.Chart = new BarChart() { Entries = entries, IsAnimated = true, LabelTextSize = 40, LabelOrientation = Orientation.Horizontal, PointSize = 5, ValueLabelOrientation = Orientation.Horizontal, MaxValue = 100, MinValue=0};
            chartView.Chart.BackgroundColor = SKColor.Parse("#3DAE5E");
            chartView.Chart.LabelColor = SKColor.Parse("#8ACF9E");
        


        }
    }
}
