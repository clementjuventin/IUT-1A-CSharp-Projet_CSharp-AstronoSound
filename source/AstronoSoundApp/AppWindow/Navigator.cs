using AppWindow.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using Menu = AppWindow.UC.Menu;

namespace AppWindow
{
    public class Navigator: INotifyPropertyChanged
    {
        public const string MENU = "Menu";
        public const string DETAIL_FOR_PLAYLIST = "DetailForPlaylist";
        public const string RESEARCH = "Research";
        public const string DETAIL_FOR_CASUAL_PLAYLIST = "DetailForCasualPlaylist";

        public static Dictionary<string, Func<UserControl>> WindowParts { get; set; } = new Dictionary<string, Func<UserControl>>()
        {
            [MENU] = () => new Menu(),
            [DETAIL_FOR_PLAYLIST] = () => new DetailForPlaylist(),
            [RESEARCH] = () => new Research(),
            [DETAIL_FOR_CASUAL_PLAYLIST] = () => new DetailForCasualPlaylist()
        };

        private KeyValuePair<string, Func<UserControl>> selectedUC;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public KeyValuePair<string, Func<UserControl>> SelectedUC
        { 
            get => selectedUC; 
            set 
            { 
                if (selectedUC.Equals(value)) return; 
                selectedUC = value; 
                OnPropertyChanged(); 
            } 
        }

        public Navigator()
        {
            SelectedUC = WindowParts.First();
        }

        public void GoTo(string partName)
        {
            if (WindowParts.ContainsKey(partName))
            {
                SelectedUC = WindowParts.Single(keyValuePair => keyValuePair.Key == partName);
            }
        }
    }
}
