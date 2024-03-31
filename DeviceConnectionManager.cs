using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;

namespace ReConnUWP
{

	public class DeviceConnectionManager
	{
		public ObservableCollection<ManagedBluetoothDevice> Devices = new ObservableCollection<ManagedBluetoothDevice>();
		bool isDevicesScanned = false;

		public class DeviceStatuses
		{
			public static readonly string PAIRED = "paired";
			public static readonly string CONNECTED = "connected";
			public static readonly string DISCONNECTED = "disconnected";
			public static readonly string NEW = "new";  // and unpaired as well
		}
		public DeviceConnectionManager(){}

		public async void ConnectByName(string name)
        {
			ManagedBluetoothDevice target = Devices.Where((ManagedBluetoothDevice device) => device.Name == name).First();
            await target.RePairDevice();
		}

		public async Task<string> DiscoverPairedDevices()
		{
			// TODO: List Devices
			if (isDevicesScanned)
				return "Already Scanned!";

            DeviceInformationCollection pairedBluetoothDevices = await DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelector());
            IEnumerable<ManagedBluetoothDevice> convertedDevices = pairedBluetoothDevices.Select((device) =>  new ManagedBluetoothDevice(device));
			foreach (ManagedBluetoothDevice device in convertedDevices)
            {
				Devices.Add(device);
			}	
			isDevicesScanned = true;
            return "Scan complete";
		}

		/*		public async InterruptConnection()
				{
					// Try to interrupt connection before it succeeds or fails
					// Shoud disconnect if it has already successfully connected, using DisconnectDevice
				}

				public async DisconnectDevice()
				{
					// Try to disconnect device
				}
			}*/

	}
}

