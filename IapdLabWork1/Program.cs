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
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                foreach (PropertyData property in queryObj.Properties)
                {
                    Console.WriteLine("{0}: {1}", property.Name, property.Value);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
