using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tube.ObjectLayer
{

      public class Underground
    {
        // Init List variable to store multiple stations
        Dictionary<string, Station> stations = new Dictionary<string, Station>();

        // Stop the object being instantiated using new
        private Underground(){}
        // Holds the reference to the only instance of singleton
        private static Underground? instance;

        public static Underground Instance
        {
            // Used instead of a construtor, creates only one instance
            get
            {
                if (instance == null)
                {
                    instance = new Underground(); 
                }
                return instance;
            }
        }

        // Method to add station to list variable and carry along to station class 
        public void AddStation(Station station)
        {
            stations[station.Id] = station;
        }

        // Method to clear the stations dictionary 
        public void Clear()
        {
            stations.Clear();
        }

        // Method to find station based of id
        public Station Find(string id)
        {
            if (stations.TryGetValue(id, out Station station))
            {
                return station;
            }

            return null;
        }

        // Method to print every station in Underground
        public override string ToString()
        {
                return string.Join("\r\n", stations.Values);  
        }
    }
}
