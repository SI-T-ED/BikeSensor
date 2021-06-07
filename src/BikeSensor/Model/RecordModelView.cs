using System;
namespace BikeSensor.Model
{
    public class RecordModelView : RecordModel
    {
        public RecordModelView(RecordModel recordModel)
        {
            Id = recordModel.Id;
            Duration = recordModel.Duration;
            Datas = recordModel.Datas;
            Date = recordModel.Date;
            MaxIntensityMean = recordModel.MaxIntensityMean;
            PartitionToken = recordModel.PartitionToken;
            Success = recordModel.Success;
        }
        public string MaxMeanPourcentage
        {
            get {
                return ((int)(((float)MaxIntensityMean / 120.0) * 100)).ToString() + "%";
            }
        }
        public string MaxPourcentage
        {
            get
            {
                return ((int)(((float)MaxIntensity / 120.0) * 100)).ToString() + "%";
            }
        }
        public string MaxMeanText
        {
            get
            {
                return "Intensité moyenne: " + MaxMeanPourcentage;
            }
        }

        public string DurationText
        {
            get
            {
                return Duration.ToString(@"hh\:mm\:ss");
            }
        }

        public string DurationMessage
        {
            get
            {
                return  "Durée: " + Duration.Hours.ToString() + "h " + Duration.Minutes.ToString() + " min " + Duration.Seconds.ToString() + "s";
            }
        }
    }
}
