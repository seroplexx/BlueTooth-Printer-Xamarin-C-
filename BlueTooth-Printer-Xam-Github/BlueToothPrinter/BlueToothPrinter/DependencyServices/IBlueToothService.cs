using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueToothPrinter.DependencyServices
{
    /// <summary>
    /// We need to create an interface for DependencyService (Android-iOS-UWP)
    /// </summary>
    public interface IBlueToothService
    {
        IList<string> GetDeviceList();
        Task Print(string deviceName, string text, string text1, string text2, string text3, string text4, string text5, string text6);
        
    }
}