using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalBoard.ExternClasses
{
    public class ActionClassVibrationPage
    {
        private readonly DataStorage _storage;

        public ActionClassVibrationPage(DataStorage dataStorage)
        {
            _storage = dataStorage;

        }

        public void StartVibration()
        {
            Vibration.Default.Vibrate(TimeSpan.FromSeconds(3));

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
