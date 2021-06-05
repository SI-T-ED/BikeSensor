using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using BikeSensor.Classes;

namespace BikeSensor.Views.ContentViews
{
    public partial class RecordGraphView : ContentView
    {
        public RecordModel RecordModel { get; set; }
        public RecordGraphView()
        {
            RecordModel = new RecordModel();
            InitializeComponent();
          
        }

        public void LoadGraph()
        {
            var entries = new List<ChartEntry>();

            foreach (var item in RecordModel.Datas)
            {
                entries.Add(new ChartEntry(item.Max)
                {
                   // ValueLabel = item.Max.ToString(),
                    Color = SKColor.Parse("#CBE9D4"),
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                });
                entries.Add(new ChartEntry(item.Min)
                {
                    Color = SKColor.Parse("#CBE9D4"),
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E"),
                    Label = item.Min.ToString(),

                });
            }


            charLine.Chart = new LineChart()
            {
                Entries = entries,
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelTextSize = 36,
                LineMode = LineMode.Spline

            };

            charLine.WidthRequest = 50 * RecordModel.Datas.Count;
        }
    }
}
