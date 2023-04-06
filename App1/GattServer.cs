using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Bluetooth;
using static App1.GattServer;
using Windows.Storage.Streams;

namespace App1
{
    public class GattServer
    {
        async void t()
        {
            GattServiceProviderResult result = await GattServiceProvider.CreateAsync(new Guid("00002A19-0000-1000-8000-00805F9B34FB"));

            if (result.Error == BluetoothError.Success)
            {
                GattServiceProvider serviceProvider = result.ServiceProvider;
            }
        }
    }

}