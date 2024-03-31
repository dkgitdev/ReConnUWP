using System;
using Windows.Devices.Enumeration;

namespace ReConnUWP
{
    internal class ManagedBluetoothDevice : IComparable
    {
        DeviceInformation device;

        public int CompareTo(ManagedBluetoothDevice obj)
        {
            if (device.Id == obj.device.Id)
                return 0;
            else
                return 1;
        }

        public int CompareTo(object obj)
        {
            return 1;
        }
    }


}