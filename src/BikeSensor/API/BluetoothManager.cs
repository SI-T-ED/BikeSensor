using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BluetoothClassic.Abstractions;
using Xamarin.Forms;

namespace BikeSensor.API
{
    public static class BluetoothManager
    {
        private static IBluetoothAdapter bluetoothAdapter;

        private static IBluetoothManagedConnection connection;

        private static String actualLine;

        private static List<String> Replies = new List<String>();

        private static List<String> Request = new List<String>();

        private static bool requestMode = false;

        private const int TIMEOUT = 20;

        private static RecordModel RecordModel = new RecordModel();

        private static DateTime startRecording;

        private static int SumMax = 0;


        public static void Init()
        {
            bluetoothAdapter = DependencyService.Resolve<IBluetoothAdapter>();
            List<BluetoothDeviceModel> devices = bluetoothAdapter.BondedDevices.ToList();
            connection = bluetoothAdapter.CreateManagedConnection(devices.FirstOrDefault(item => item.Name.Contains("BikeSensor")));
            try
            {
                connection.Connect();
            }
            catch (BluetoothConnectionException)
            {

            }
            catch (Exception)
            {

            }

            connection.OnRecived += OnReceived;
        }

        public static void SendCommand(String command)
        {
            Memory<byte> data = new Memory<byte>(Encoding.ASCII.GetBytes(command));
            connection.Transmit(data);

        }

        private static void OnReceived(object sender, RecivedEventArgs recivedEventArgs)
        {
            String content = (Encoding.ASCII.GetString(recivedEventArgs.Buffer.ToArray()));
            foreach(char c in content)
            {
                if(c == '\n')
                {
                    if (actualLine.Contains("reply"))
                    {
                        requestMode = false;
                    }
                    else if(actualLine.Contains("request"))
                    {
                        requestMode = true;
                    }

                    if (requestMode)
                    {
                        Request.Add(actualLine);
                    }else
                    {
                        Replies.Add(actualLine);
                    }
                    Debug.WriteLine(actualLine);
                    actualLine = "";
                }
                else
                {
                    actualLine += c;
                }
            }
        }
        public static bool IsConnected()
        {
            if(connection is null)
            {
                return false;
            }
            switch (connection.ConnectionState)
            {
                case ConnectionState.Connected:
                    return true;
                default:
                    return false;
            }
             
        }
        public static Task<bool> StartRecording()
        {
            SendCommand("start/end\n");
            bool ans = false;
            DateTime startTime = DateTime.Now;
            while (!ans)
            {
                TimeSpan timeSpan = new TimeSpan(0, 0, TIMEOUT);
                if (DateTime.Now - startTime > timeSpan)
                {
                    return Task.FromResult(false);
                }
                else if (Replies.Count > 0 && Replies[0].Contains("start/1"))
                {
                    Replies.RemoveAt(0);
                    ans = true;
                    startRecording = DateTime.Now;
                }

            }
            RecordModel = new RecordModel() { Date = DateTime.Now, Success = false };

            return Task.FromResult(true);
        }

        public static Task<string> StopRecording()
        {
            SendCommand("stop/end\n");
            bool ans = false;
            DateTime startTime = DateTime.Now;
            TimeSpan duration = (DateTime.Now - startRecording);
            RecordModel.Duration = "Durée: " + duration.Hours.ToString() + "h " + duration.Minutes.ToString() + " min " + duration.Seconds.ToString() + "s";

            while (!ans)
            {
                TimeSpan timeSpan = new TimeSpan(0, 0, TIMEOUT);
                if (DateTime.Now - startTime > timeSpan)
                {
                    return Task.FromResult("TimeOut");
                }
                else if (Replies.Count > 0 && Replies[0].Contains("stopped"))
                {
                    ans = true;


                }

            }
            String token = Replies[0].Split('/')[3];
            Replies.RemoveAt(0);

            return Task.FromResult(token);
        }

        public static Task<RecordModel> RequestData(String token)
        {
            SendCommand("send/"+ token + "/end\n");
            bool ans = false;
            SumMax = 0;
            RecordModel.PartitionToken = token;
            DateTime startTime = DateTime.Now;
            while (!ans)
            {
                TimeSpan timeSpan = new TimeSpan(0, 0, TIMEOUT*2);
                if (DateTime.Now - startTime > timeSpan)
                {
                    ans = true;
                }
                if (Replies.Count > 0 && Replies[0] != null && Replies[0].Contains("send/"+ token))
                {
                    Replies.RemoveAt(0);
                    bool ended = false;
                    while (!ended)
                    {
                        if (Replies != null && Replies.Count > 0)
                        {
                            if (Replies[0] != null && Replies[0].Count(item => item == ';') > 3)
                            {
                                var parameters = Replies[0].Split(';');
                                // id ; max ; min ; grow_rate ; decline_rate
                                if(parameters.Count() > 4)
                                {
               
                                    DataModel data = new DataModel();
                                    data.Id = Int32.Parse(parameters[0]);

                                    data.Max = Int32.Parse(parameters[1]);
                                    data.Min = Int32.Parse(parameters[2]);
                                    data.Accurate = float.Parse(parameters[3], CultureInfo.InvariantCulture.NumberFormat);
                                    data.Decline = float.Parse(parameters[4], CultureInfo.InvariantCulture.NumberFormat);
                                    SumMax += data.Max;

                                    RecordModel.Datas.Add(data);
                                }
                                startTime = DateTime.Now;

                            }
                            else if (Replies[0] != null && Replies[0].Contains("sended/" + token))
                            {
                                ended = true;
                                RecordModel.Success = true;
                                startTime = DateTime.Now;

                            }
                            else if (DateTime.Now - startTime > timeSpan)
                            {
                                ended = true;
                            }
                            Replies.RemoveAt(0);
                        }
                        else if (DateTime.Now - startTime > timeSpan)
                        {
                            ended = true;
                        }
                        else
                        {
                            Task.Delay(10);
                        }
                    }
                    ans = true;

                }

            }
            RecordModel.MaxIntensityMean = SumMax / RecordModel.Datas.Count;
            return Task.FromResult(RecordModel);
        }
    }
}


