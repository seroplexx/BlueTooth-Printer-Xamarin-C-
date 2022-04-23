using Android.Bluetooth;
using Android.Content.Res;
using Android.Graphics;
using BlueToothPrinter.DependencyServices;
using BlueToothPrinter.Droid.DependencyServices;
using Java.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
using Zebra.Sdk;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
*/

[assembly: Xamarin.Forms.Dependency(typeof(AndroidBlueToothService))]


namespace BlueToothPrinter.Droid.DependencyServices
{
    class AndroidBlueToothService : IBlueToothService
    {
        
        public IList<string> GetDeviceList()
        {
            using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
            {
                var btdevice = bluetoothAdapter?.BondedDevices.Select(i => i.Name).ToList();
                return btdevice;
            }
        }
        
        
        public async Task Print(string deviceName, string text, string text1, string text2, string text3, string text4, string text5, string text6)
            {
           using (BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter)
            {
                BluetoothDevice device = (from bd in bluetoothAdapter?.BondedDevices
                                          where bd?.Name == deviceName
                                          select bd).FirstOrDefault();
                try
                {
                    using (BluetoothSocket bluetoothSocket = device?.
                        CreateRfcommSocketToServiceRecord(
                        UUID.FromString("00001101-0000-1000-8000-00805f9b34fb")))
                    {
                        bluetoothSocket?.Connect();
                        await Task.Delay(250);
                       

                        byte[] buffer = Encoding.UTF8.GetBytes(text);
                        byte[] buffer1 = Encoding.UTF8.GetBytes(text1);
                        byte[] buffer2 = Encoding.UTF8.GetBytes(text2);
                        byte[] buffer3 = Encoding.UTF8.GetBytes(text3);
                        byte[] buffer4 = Encoding.UTF8.GetBytes(text4);
                        byte[] buffer5 = Encoding.UTF8.GetBytes(text5);
                        byte[] buffer6 = Encoding.UTF8.GetBytes(text6);

                        


                        bluetoothSocket?.OutputStream.Write(buffer, 0, buffer.Length);
                        bluetoothSocket?.OutputStream.Write(buffer1, 0, buffer1.Length);
                        bluetoothSocket?.OutputStream.Write(buffer2, 0, buffer2.Length);
                        bluetoothSocket?.OutputStream.Write(buffer3, 0, buffer3.Length);
                        bluetoothSocket?.OutputStream.Write(buffer4, 0, buffer4.Length);
                        bluetoothSocket?.OutputStream.Write(buffer5, 0, buffer5.Length);
                        bluetoothSocket?.OutputStream.Write(buffer6, 0, buffer6.Length);
                        
                        buffer = null; buffer1 = null; buffer2 = null;
                        buffer3 = null; buffer4 = null; buffer5 = null;
                        buffer6 = null;
                        
                        bluetoothSocket.Close();
                        bluetoothSocket.Dispose();
                        bluetoothAdapter.Dispose();
                        deviceName = null;
                        device = null;

                    }
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        
    }
}