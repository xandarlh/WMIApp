using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{
    public static class Dal
    {
        
        public static ManagementObjectCollection User()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            return results;
        }       
        public static ManagementObjectCollection BootDevice()
        {
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");          
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection queryCollection = searcher.Get();
            return queryCollection;
        }        
        public static List<string> PopulateDisk()
        {
            List<string> disk = new List<string>();
            SelectQuery selectQuery = new SelectQuery("Win32_LogicalDisk");
            ManagementObjectSearcher mnagementObjectSearcher = new ManagementObjectSearcher(selectQuery);
            foreach (ManagementObject managementObject in mnagementObjectSearcher.Get())
            {
                disk.Add(managementObject.ToString());
            }
            return disk;
        }       
        public static ManagementObjectCollection Mainstorage()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            return results;
        }       
        public static ManagementObjectCollection DiskMetaData()
        {
            System.Management.ManagementScope managementScope = new System.Management.ManagementScope();
            System.Management.ObjectQuery objectQuery = new System.Management.ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
            return managementObjectCollection;
        }       
        public static string HardDiskSerialNumber(string drive = "C")
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
            managementObject.Get();
            return managementObject["VolumeSerialNumber"].ToString();
        }        
        public static ManagementObjectCollection LISTALLServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();
            return objectCollection;
        }      
        
    }
}