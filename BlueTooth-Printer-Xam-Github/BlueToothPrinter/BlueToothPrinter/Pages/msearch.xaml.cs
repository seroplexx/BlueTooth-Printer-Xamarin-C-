using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace BlueToothPrinter.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class msearch : ContentPage
    {

        public ObservableCollection<NewsTable> DatabaseItems { get; set; } = new ObservableCollection<NewsTable>();

        public msearch()
        {
            InitializeComponent();

            BindingContext = this;
            FirebaseClient firebaseClient = new FirebaseClient("firebase clint ekle");

            var collection = firebaseClient
                .Child("realtime database-ana başlık")
                .AsObservable<NewsTable>()
                .Subscribe((dbevent) =>
                {
                    
                        DatabaseItems.Add(dbevent.Object);
                    
                });
        }
    }
}