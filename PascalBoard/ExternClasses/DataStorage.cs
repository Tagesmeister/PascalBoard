using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PascalBoard.ExternClasses
{
    public class DataStorage
    {
        private const string CountKey = "clickCount";

        public void SaveData(int count)
        {
            Preferences.Set(CountKey, count);
        }
        public int LoadData()
        {
            return Preferences.Get(CountKey, 0);
        }

    }
}
