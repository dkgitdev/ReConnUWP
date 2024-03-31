using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;

namespace ReConnUWP
{

	public class DeviceConnectionManager
	{
		public IObservable<ManagedBluetoothDevice>

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
            DeviceInformation target = devices.Where((DeviceInformation device) => device.Name == name).First();
            await RePairDevice(target);
		}

		public async Task<string> DiscoverPairedDevices()
		{
			// TODO: List Devices
			if (devices != null)
				return "Already Scanned!";

            DeviceInformationCollection deviceInformationCollection = await DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelector());
			this.devices = deviceInformationCollection;
			return "Scan complete";
		}


		async Task<string> RePairDevice(DeviceInformation deviceInformation)
		{
			// TODO: Connect to Specific device
			// Should return some interruptable thing
			try
			{
				await deviceInformation.Pairing.UnpairAsync();
				await deviceInformation.Pairing.PairAsync();
				return DeviceStatuses.PAIRED;
			}
			catch (Exception e)
			{
				return $"Error: {e.Message}";
			}
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

