using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Management;

namespace IapdLabWork1
{
    class PCIDevices
    {
        private List<DeviceInformation> devices;

        public PCIDevices()
        {
            devices = new List<DeviceInformation>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT DeviceID, Description FROM Win32_PnPEntity WHERE DeviceID LIKE '%PCI\\\\%'");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                var device = new DeviceInformation();
                device.setName("PCI device");
                device.setDescription((string)queryObj["Description"]);
                device.setParameters(parseQueryResult((string)queryObj["DeviceID"]));
                devices.Add(device);
            }
        }

        private Dictionary<string, string> parseQueryResult(string queryResult)
        {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info["deviceType"] = new Regex("(.*?)(?=\\\\)").Match(queryResult).Value;
            info["vendorId"] = new Regex("(?<=VEN_)(.{0,4})(?=&)").Match(queryResult).Value;
            info["deviceId"] = new Regex("(?<=DEV_)(.{0,4})(?=&)").Match(queryResult).Value;
            info["subsystemId"] = new Regex("(?<=SUBSYS_)(.{0,8})(?=&)").Match(queryResult).Value;
            info["revisionId"] = new Regex("(?<=REV_)(.{0,2})(?=\\\\)").Match(queryResult).Value;
            info["otherId"] = new Regex("(?<=\\\\)(?!VEN_)(.*)").Match(queryResult).Value;
            return info;
        }

        public List<DeviceInformation> getDevices()
        {
            return devices;
        }
    }
}
