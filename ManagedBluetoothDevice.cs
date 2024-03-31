using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Enumeration;

namespace ReConnUWP
{
    public class ManagedBluetoothDevice : IComparable
    {
        // <Shitcode>
        public class RePairCommand : ICommand
        {
            // TODO: move this class into presentation layer
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter) => !(parameter == null || ((ManagedBluetoothDevice)parameter).IsTakingAction);

            public async void Execute(object parameter)
            {
                if (CanExecute(parameter))
                    await ((ManagedBluetoothDevice)parameter).RePairDevice();
            }
        }
        public RePairCommand RePairCommandInstance = new RePairCommand();
        public ManagedBluetoothDevice DataContext;
        
        // </Shitcode>

        public bool IsTakingAction = false;

        readonly DeviceInformation device;
        public string Name => device.Name;
        public bool IsConnected => device.IsEnabled;
        public bool IsPaired => device.Pairing.IsPaired;
        public string Id => device.Id;
        public ManagedBluetoothDevice(DeviceInformation device)
        {
            this.device = device;
            DataContext = this;
        }

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

        public async Task RePairDevice()
        {
            try
            {
                this.IsTakingAction = true;
                await this.device.Pairing.UnpairAsync();
                await this.device.Pairing.PairAsync(DevicePairingProtectionLevel.None);
            }
            catch
            {
                // TODO: log
            }
            finally
            {
                this.IsTakingAction = false;
            }
        }
    }


}