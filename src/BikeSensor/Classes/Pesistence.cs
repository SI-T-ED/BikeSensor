using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BikeSensor.Classes
{
    public static class Persistence
    {
        private static List<RecordModel> Records { get; set; }

        public static void AddRecord(RecordModel record)
        { 
            Records.Add(record);
            SaveRecord();

        }
        public static List<RecordModel> GetRecords()
        {
            return Records;
        }
        public static void LoadRecords()
        {
            Records = new List<RecordModel>();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "records.json");
            using (var file = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            using (var strm = new StreamReader(file))
            {
                Records = JsonConvert.DeserializeObject<List<RecordModel>>(strm.ReadToEnd());
                if(Records is null)
                {
                    Records = new List<RecordModel>();
                }
            }
        }

        private static void SaveRecord()
        {
            string json = JsonConvert.SerializeObject(Records);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "records.json");
            using (var file = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            using (var strm = new StreamWriter(file))
            {
                strm.Write(json);
            }


        }
    }
}
