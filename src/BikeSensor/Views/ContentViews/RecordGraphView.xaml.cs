using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;

namespace BikeSensor.Views.ContentViews
{
    public partial class RecordGraphView : ContentView
    {
        public RecordGraphView()
        {
            InitializeComponent();

            var entries = new List<ChartEntry>()
            {
                new ChartEntry(0)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "0",
                    ValueLabel = "0%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                new ChartEntry(0)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "5",
                    ValueLabel = "0%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                new ChartEntry(0)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "10",
                    ValueLabel = "0%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                new ChartEntry(10)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "15",
                    ValueLabel = "10%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                 new ChartEntry(4)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "20",
                    ValueLabel = "4%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                  new ChartEntry(12)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "25",
                    ValueLabel = "12%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                },
                   new ChartEntry(9)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    Label = "30",
                    ValueLabel = "9%",
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                }

            };

            charLine.Chart = new LineChart()
            {
                Entries = entries,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelTextSize = 36,
                
            };
        }
    }
}
