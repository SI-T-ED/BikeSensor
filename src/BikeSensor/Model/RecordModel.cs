using System;
using System.Collections.Generic;

namespace BikeSensor
{
    public class RecordModel
    {
        public int Id { get; set; }

        public String PartitionToken {get; set;}
        
        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }

        public int MaxIntensityMean { get; set; }


        public List<DataModel> Datas = new List<DataModel>();

        public bool Success { get; set; }
    }
}
