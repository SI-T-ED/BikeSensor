using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using BikeSensor.Classes;
using System.Threading.Tasks;

namespace BikeSensor.Views.ContentViews
{
    public partial class RecordGraphView : ContentView
    {
        public RecordModel RecordModel { get; set; }
        public RecordGraphView()
        {
            RecordModel = new RecordModel();
            InitializeComponent();
            charLine.Chart = new LineChart()
            {
                Entries = new List<ChartEntry>(),
                LabelOrientation = Orientation.Horizontal,
                ValueLabelOrientation = Orientation.Horizontal,
                LabelColor = SKColor.Parse(((Color)Application.Current.Resources["White"]).ToHex()),
                LabelTextSize = 36,
                IsAnimated = false,
                AnimationDuration = TimeSpan.Zero,
                AnimationProgress = 1.0f,
                LineMode = LineMode.Spline,
                BackgroundColor = SKColor.Parse(((Color) Application.Current.Resources["White"]).ToHex())

            };
        }

        public Task<bool> LoadGraph(int from = 0, int to = 100)
        {
            to = (to > RecordModel.Datas.Count - 1) ? RecordModel.Datas.Count - 1 : to;
            var entries = new List<ChartEntry>();
            for (int i = from; i <= to; i++)
            {
                entries.Add(new ChartEntry(RecordModel.Datas[i].Max)
                {
                    Label = RecordModel.Datas[i].Max.ToString(),
                    ValueLabel = RecordModel.Datas[i].Max.ToString(),
                    Color = SKColor.Parse("#CBE9D4"),
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")
                });
                entries.Add(new ChartEntry(RecordModel.Datas[i].Min)
                {
                    Label = RecordModel.Datas[i].Min.ToString(),
                    ValueLabel = RecordModel.Datas[i].Min.ToString(),
                    Color = SKColor.Parse("#CBE9D4"),
                    TextColor = SKColor.Parse("#8ACF9E"),
                    ValueLabelColor = SKColor.Parse("#8ACF9E")

                });
            }



            charLine.Chart.Entries = entries;


            charLine.WidthRequest =  50 * ( to- from);

            return Task.FromResult(true);
        }
    }
}
