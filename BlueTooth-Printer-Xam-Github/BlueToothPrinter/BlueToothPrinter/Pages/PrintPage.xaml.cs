using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System;
using Plugin.Media;
using Xamarin.Essentials;
using BlueToothPrinter.ViewModels;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System.Linq;

namespace BlueToothPrinter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrintPage : ContentPage
	{
        public PrintPage ()
		{
			InitializeComponent ();
            btn1.IsEnabled = false;
            Plugin.Media.CrossMedia.Current.Initialize();
            MessagingCenter.Subscribe<MainPage, string>(this, "EntryValue", (sender, value) => {
               lbl1.Text = value.ToString();
                MessagingCenter.Unsubscribe<MainPage, string>(this, "EntryValue");
            });
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            
            await CrossMedia.Current.Initialize();
            var imgdata = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());
         
            
            var stroageimage = new FirebaseStorage("fotoğraf depolama firebase satorage adres ekle")
                .Child("klasör ismi yarat")
                .Child(ad.Text +".jpg")
                .PutAsync(imgdata.GetStream());
            
        }
        #region sil
        public int contl = 0;
        public int cont2 = 0;

        private void chan(object sender, CheckedChangedEventArgs e)
        {
            if (rd1var.IsChecked == true || rd2yok.IsChecked == true)
            {
                if (rd1var.IsChecked == true)
                {
                    lbl2.Text = rd1var.Content.ToString();
                    contl = 1;
                    if (cont2 == 1)
                    {
                        btn1.IsEnabled = true;

                    }


                }
            
                if (rd2yok.IsChecked == true)
                {
                    lbl2.Text = rd2yok.Content.ToString();
                    contl = 1;
                    if (cont2 == 1)
                    {
                        btn1.IsEnabled = true;

                    }

                }
            }
            else
            {
                contl = 0;
            }
        }

        

        private void degisimkontrol(object sender, CheckedChangedEventArgs e)
        {
            if ((ad.Text == null || gsm.Text == null ||  adres.Text == null || marka.Text == null || ariza.Text == null) || (ad.Text == "" || gsm.Text == "" || adres.Text == "" || marka.Text == "" || ariza.Text == ""))
            {

                btn1.IsEnabled = false;
                cont2 = 0;
                
            }
            else
            {
                cont2 = 1;

                if (contl == 1)
                {
                    btn1.IsEnabled = true;
                }
                
            }
        }

        string syc;
        int syca = 0;
        private async void btn1_Clicked(object sender, EventArgs e)
        {
            DateTime ths = DateTime.Today;
            if (syc != ad.Text)
            {
                FirebaseClient fc = new FirebaseClient("https://goc-xm-default-rtdb.firebaseio.com/");

                var result = await fc
                    .Child("Müşteri Bilgi")
                    .PostAsync(new NewsTable() { Adsoyad = ad.Text, tel = gsm.Text, adres = adres.Text, marka = marka.Text, ariza = ariza.Text, tarih = ths.ToString("dd/MM/yyyy"), garanti = lbl2.Text });
                fc.Dispose();
                syc = ad.Text;
                
            }

            if (syca == 1)
            {
                ad.Text = "";
                gsm.Text = "";
                adres.Text = "";
                marka.Text = "";
                ariza.Text = "";
                rd1var.IsChecked = false;
                rd2yok.IsChecked = false;
                syca = 0;
                return;
            }
            syca = 1;


        }
        #endregion

    }
}