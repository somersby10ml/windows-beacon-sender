using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Threading;
using Windows.Storage.Streams;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.UI.Core;

namespace App1
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BluetoothLEAdvertisementPublisher publisher;

        byte[] SecApply = new byte[] {
   0,0,0,0,0,
          0,0,0,0,
          0,0,0,0,
        0,0,0,0,
          0,0,0,0,

    //      0xe2, 0xc5, 0x6d, 0xb5,
    //0xdf, 0xfb, 0x48, 0xd2,
    //0xb0, 0x60, 0xd0, 0xf5,
    //0xa7, 0x10, 0x96, 0xe0,
    // Major
    0x01, 0xF5, // 501
    // Minor
     0x0B, 0xB8,
     //0x1b, 0x58,
    // TX power
    0
};

        byte[] SecCancel = new byte[] {
   0,0,0,0,0,
      0,0,0,0,
          0,0,0,0,
          0,0,0,0,
        0,0,0,0,
    //   0xe2, 0xc5, 0x6d, 0xb5,
    //0xdf, 0xfb, 0x48, 0xd2,
    //0xb0, 0x60, 0xd0, 0xf5,
    //0xa7, 0x10, 0x96, 0xe0,
    // Major
    0x01, 0xF5, // 501
    // Minor
     //0x0B, 0xB8,
     0x1b, 0x58,
    // TX power
    0
};

        public MainPage()
        {
            this.InitializeComponent();

            publisher = new BluetoothLEAdvertisementPublisher();
            //publisher.IsAnonymous = false;

            Thread a = new Thread(thread1);
            a.IsBackground = true;
            a.Start();
        }

        async void thread1()
        {
            while (true)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    textBlock.Text = publisher.Status.ToString();
                });

                Thread.Sleep(1000);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //publisher.Stop();


            DataWriter writer = new DataWriter();
            writer.WriteBytes(SecApply);

            BluetoothLEManufacturerData manufacturerData = new BluetoothLEManufacturerData();
            manufacturerData.CompanyId = 0xFFFE;
            manufacturerData.Data = writer.DetachBuffer();

            publisher.Advertisement.ManufacturerData.Clear();
            publisher.Advertisement.ManufacturerData.Add(manufacturerData);


            //publisher.Start();

            publisher.Start();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            //publisher.Stop();


            DataWriter writer = new DataWriter();
            writer.WriteBytes(SecCancel);

            BluetoothLEManufacturerData manufacturerData = new BluetoothLEManufacturerData();
            //manufacturerData.CompanyId = 0xFFFE;
            //manufacturerData.CompanyId = 0xFFFE;

            manufacturerData.Data = writer.DetachBuffer();
            publisher.Advertisement.ManufacturerData.Clear();
            publisher.Advertisement.ManufacturerData.Add(manufacturerData);
            //publisher.Start();
            publisher.Start();

            //Debug.WriteLine(publisher.Status.ToString());
        }
    }
}
