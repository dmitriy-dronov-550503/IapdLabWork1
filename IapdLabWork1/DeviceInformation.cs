using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IapdLabWork1
{
    class DeviceInformation
    {
        private string name { get; set; }
        private string description;
        private Dictionary<string, string> parameters;

        public void setName(string name)
        {
            this.name = name;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setParameters(Dictionary<string, string> parameters)
        {
            this.parameters = parameters;
        }

        public string getName()
        {
            return name;
        }

        public string getDesription()
        {
            return description;
        }

        public Dictionary<string, string> getParameters()
        {
            return parameters;
        }
    }
}
