using BlueToothPrinter.DependencyServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BlueToothPrinter.ViewModels
{
    public class PrintPageViewModel
    {

        
        private readonly IBlueToothService _blueToothService;
        private string _rdbtn,_printMessage, _printMessage1, _printMessage2, _printMessage3, _printMessage4;
        public string agece,a2;
        private string _selectedDevice;

        DateTime thisDay = DateTime.Today;
        string ab1;


        private IList<string> _deviceList;

        public string rdbtn
        {
            get
            {
                return _rdbtn;
            }
            set
            {
                _rdbtn = "\n\n\r    Garanti Durumu: " + value + "\n\n\r -----------------------------------------------" + "\n\n\r";
            }
        }

        public string SelectedDevice
        {
            get
            {
                return _selectedDevice;
            }
            set
            {
                _selectedDevice = value;
            }
        }
        public IList<string> DeviceList
        {
            get
            {
                if (_deviceList == null)
                    _deviceList = new ObservableCollection<string>();
                return _deviceList;
            }
            set
            {
                _deviceList = value;
            }
        }

        #region Print Message
        public string PrintMessage
        {
            get
            {
                return _printMessage;
            }
            set
            {
                _printMessage = "\n\n\r -----------------------------------------------    \n\r    Adi ve Soyadi: " +  value;
            }
        }

        public string PrintMessage1
        {
            get
            {
                return _printMessage1;
            }
            set
            {
                _printMessage1 ="\n\n\r    Telefon: " + value;
            }
        }
        public string PrintMessage2
        {
            get
            {
                return _printMessage2;
            }
            set
            {
                _printMessage2 = "\n\n\r    Adres: " + value;
            }
        }
        public string PrintMessage3
        {
            get
            {
                return _printMessage3;
            }
            set
            {
                _printMessage3 = "\n\n\r    Marka: " + value;
            }
        }
        public string PrintMessage4
        {
            get
            {
                return _printMessage4;
            }
            set
            {
                _printMessage4 = "\n\n\r    Ariza: " + value;
            }
        }

        #endregion
        
        /// <summary>
        /// Print text-message
        /// </summary>
        public ICommand PrintCommand => new Command(async () =>
        {
            ab1 = "\n\n\r    Tarih: " + thisDay.ToString("dd/MM/yyyy");
            
            
            await _blueToothService.Print(SelectedDevice,PrintMessage,PrintMessage1,PrintMessage2,PrintMessage3,PrintMessage4,ab1,rdbtn);

        });

        public PrintPageViewModel()
        {
            _blueToothService = DependencyService.Get<IBlueToothService>();
            BindDeviceList();
        }


        void BindDeviceList()
        {
         
            var list = _blueToothService.GetDeviceList();
            DeviceList.Clear();
           
            foreach (var item in list)
                DeviceList.Add(item);
         
        }

    }
}