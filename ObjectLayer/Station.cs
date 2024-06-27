using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Tube.ObjectLayer
{

    /*
     Station Class that holds details of a metro station as well as a method to display the details of a station
   */

    public class Station
    {

        // Create private variables
        private string id;
        private string name;
        private int zone;
        private int started;
        private int ended;
       
        // Create a public string method for name, line and ID with getters and setters

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public int Started
        {
            get { return started; }
            set { started = value; }
        }

        public int Ended
        {
            get { return ended; }
            set { ended = value; }
        }
        // ToString to return station objects data
        public override string ToString()
        {
            return id + ", " + name + ", zone " + zone + ". " + started + ", " + ended;
        }
    }
}
