using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    public class Dalmanager
    {
        public static ManagementObjectCollection User()
        {
            return Dal.User();
        }
        public static ManagementObjectCollection BootDevice()
        {
            return Dal.BootDevice();
        }
        public static List<string> PopulateDisk()
        {
            return Dal.PopulateDisk();
        }
        public static ManagementObjectCollection Mainstorage()
        {
            return Dal.Mainstorage();
        }
        public static ManagementObjectCollection DiskMetaData()
        {
            return Dal.DiskMetaData();
        }
        public static string HardDiskSerialNumber()
        {
            return Dal.HardDiskSerialNumber();
        }
        public static ManagementObjectCollection ListAllServices()
        {
            return Dal.LISTALLServices();
        }        
    }
}

