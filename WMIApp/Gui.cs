using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WMIApp
{

    public class Gui
    {
        public void User()
        {
            foreach (ManagementObject result in Dalmanager.User())
            {
                Console.WriteLine("User:\t{0}", result["RegisteredUser"]);
                Console.WriteLine("Org.:\t{0}", result["Organization"]);
                Console.WriteLine("O/S :\t{0}", result["Name"]);
            }
        }
        private void BootDevice()
        {
            foreach (ManagementObject m in Dalmanager.BootDevice())
            {
                // access properties of the WMI object
                Console.WriteLine("BootDevice : {0}", m["BootDevice"]);
            }
        }
        private void PopulateDisk()
        {
            foreach (string item in Dalmanager.PopulateDisk())
            {
                Console.WriteLine(item);
            }
        }
        private void Mainstorage()
        {
            foreach (ManagementObject result in Dalmanager.Mainstorage())
            {
                Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
            }
        }
        private void DiskMetaData()
        {
            foreach (ManagementObject managementObject in Dalmanager.DiskMetaData())
            {
                Console.WriteLine("Disk Name : " + managementObject["Name"].ToString());
                Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"].ToString());
                Console.WriteLine("Disk Size: " + managementObject["Size"].ToString());
            }
        }
        private void HardDiskSerialNumber()
        {
            Console.WriteLine(Dalmanager.HardDiskSerialNumber());
        }
        private void ListAllServices()
        {
            Console.WriteLine("There are {0} Windows services: ", Dalmanager.ListAllServices().Count);
            foreach (ManagementObject windowsService in Dalmanager.ListAllServices())
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
        }
        
        public void menu()
        {
            int userinput;
            do
            {
                Console.Clear();
                Console.WriteLine("Press:");
                Console.WriteLine("1 - User");
                Console.WriteLine("2 - BootDevice");
                Console.WriteLine("3 - Populatedisk");
                Console.WriteLine("4 - Mainstorage");
                Console.WriteLine("5 - DiskMetaData");
                Console.WriteLine("6 - Harddiskserialnumber");
                Console.WriteLine("7 - All services");
                userinput = int.Parse(Console.ReadLine());
                switch (userinput)
                {
                    case 1:
                        Console.Clear();
                        User();
                        Console.WriteLine("");
                        Console.WriteLine("Tap enter to return");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        BootDevice();
                        Console.WriteLine("");
                        Console.WriteLine("Tap enter to return");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        PopulateDisk();
                        Console.WriteLine("");
                        Console.WriteLine("Tap enter to return");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        Mainstorage();
                        Console.WriteLine("");
                        Console.WriteLine("Tap enter to return");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        DiskMetaData();
                        Console.WriteLine("");
                        Console.WriteLine("Tap enter to return");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        HardDiskSerialNumber();
                        Console.WriteLine("");
                        Console.WriteLine("Tap enter to return");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        ListAllServices();
                        Console.WriteLine("");
                        Console.WriteLine("Tap enter to return");
                        Console.ReadLine();
                        break;
                }
            } while (userinput != 9);
        }
    }
}

