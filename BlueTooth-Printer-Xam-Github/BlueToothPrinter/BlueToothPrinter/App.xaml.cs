using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BlueToothPrinter.DependencyServices;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BlueToothPrinter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BlueToothPrinter.Pages.giris();
        }

        protected override void OnStart()
        {
        
        }

        protected override void OnSleep()
        {
        
        }

        protected override void OnResume()
        {
        
        }
    }
}
