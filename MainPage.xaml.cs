using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace ReConnUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly DeviceConnectionManager dm;
        public MainPage()
        {
            this.InitializeComponent();
            dm = new DeviceConnectionManager();
        }

        private void BtnScan_Click(object sender, RoutedEventArgs e)
        {
            _ = dm.DiscoverPairedDevices();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            dm.ConnectByName("Joy-Con (R)");
        }
    }
}
