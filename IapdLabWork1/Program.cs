using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.Runtime.InteropServices;

namespace IapdLabWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            var PCIinfo = new PCIDevices();
            var devices = PCIinfo.getDevices();
            foreach (DeviceInformation device in devices)
            {
                Console.WriteLine("Description: {0}", device.getDesription());
                Console.WriteLine("VendorID: " + device.getParameters()["vendorId"]);
                Console.WriteLine("DeviceID: " + device.getParameters()["deviceId"]);
                Console.WriteLine("SubsystemID: " + device.getParameters()["subsystemId"]);
                Console.WriteLine("ReviviosnID: " + device.getParameters()["revisionId"]);
                Console.WriteLine("Other data: " + device.getParameters()["otherId"]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
