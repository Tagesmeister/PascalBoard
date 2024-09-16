using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalBoard.ExternClasses
{
   public class ActionClassMainPage
    {
        private IAudioManager audioManager;
        private readonly DataStorage _storage;


        public ActionClassMainPage(IAudioManager audioManager, DataStorage storage)
        {
            this.audioManager = audioManager;
            _storage = storage;
        }

        public async void PlaySound()
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("VilligerSound.wav"));

            player.Play();
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
