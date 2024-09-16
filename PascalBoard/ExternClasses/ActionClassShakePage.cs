using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;

namespace PascalBoard.ExternClasses
{
    public class ActionClassShakePage
    {
        private readonly DataStorage _storage;

        // Propertys for Events
        public Action UpdateCountLabelAction { get; set; }
        public Action<string, Color> UpdateIndicatorLabelAction { get; set; }

        public static bool IsSupported { get; }

        private bool IsFlashlightOn = false;

        SensorSpeed speed = SensorSpeed.Game;


        public ActionClassShakePage(DataStorage dataStorage)
        {
            _storage = dataStorage;
        }

        public async void Navigate(string navigationLink)
        {
            await Shell.Current.GoToAsync($"///{navigationLink}");

        }

        public void AddEventToAccelerometer()
        {
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Default.Start(SensorSpeed.Game);
        }
        public void RemoveEventToAccelerometer()
        {
            Accelerometer.Default.ShakeDetected -= Accelerometer_ShakeDetected;
            Accelerometer.Default.Stop();
        }
        private async void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            if (await Flashlight.IsSupportedAsync() && IsFlashlightOn == false)
            {
                await Flashlight.Default.TurnOnAsync();
                IsFlashlightOn = true;
                UpdateIndicatorLabelAction?.Invoke("On", Colors.Blue);

            }
            else
            {
                await Flashlight.Default.TurnOffAsync();
                IsFlashlightOn = false;

                UpdateIndicatorLabelAction?.Invoke("Off", Colors.Red);
            }

            SaveData(LoadData() + 1);

            UpdateCountLabelAction?.Invoke();
        }
        public void SaveData(int number)
        {
            _storage.SaveData(number);
        }
        public int LoadData()
        {
            return _storage.LoadData();
        }
    }
}
