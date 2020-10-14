using AppWindow.UC;
using AstronoSound;
using AstronoSound.ListesDeMusiques;
using Modele;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager LeManager { get; private set; } = GetTheCurrent.Mgr;
        public Navigator Navigator { get; private set; } = new Navigator();


        private void Application_Exit(object sender, ExitEventArgs e)
        {
            GetTheCurrent.Mgr.Donnee.OnClose();
        }
    }
}
