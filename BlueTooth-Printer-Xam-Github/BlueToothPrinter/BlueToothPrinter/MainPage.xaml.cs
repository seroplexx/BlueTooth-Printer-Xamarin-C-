using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using BlueToothPrinter.Pages;
using Plugin.Connectivity;

namespace BlueToothPrinter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }



        private void Button_Clicked(object sender, EventArgs e)
        {

            if (pic1.SelectedItem == null)
            {
             
                //----------------------------------------------------------------------------------------------------------------------------------------
                DisplayAlert("Hata Adı - Hata", "Lütfen Yazıcı Seçimi Yapınız","Tamam");
                return;
                
            }

            var isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected == false)
            {

                DisplayAlert("Hata Adı - Hata", "Internet bağlantınız bulunmamaktadır. Lütfen Kontrol edniniz.", "OK");
                return;
            }


            Navigation.PushModalAsync(new Pages.PrintPage());
        
            MessagingCenter.Send<MainPage, string>(this, "EntryValue", pic1.SelectedItem.ToString());

        }

      

        private async void btn2_Clicked(object sender, EventArgs e)
        {
            FirebaseClient fc = new FirebaseClient("firebase client adress");
            Navigation.PushModalAsync(new msearch());

        }
    }
}

