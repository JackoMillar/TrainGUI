using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tube.ObjectLayer;

namespace Tube
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Init Underground singleton class
        Dictionary<int, Station> stations = new Dictionary<int, Station>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            // Init London Underground variable
            Underground London = Underground.Instance;
            London.Clear();

            // Read both files
            CSVReader station_Reader = new CSVReader("C:\\Users\\Jack Millar\\OneDrive - Edinburgh Napier University\\Year2-A\\Object Orientated Software Design\\Practical\\Coursework2\\Task2\\Tube\\Tube\\DataLayer\\Stations.csv");
            CSVReader journey_Reader = new CSVReader("C:\\Users\\Jack Millar\\OneDrive - Edinburgh Napier University\\Year2-A\\Object Orientated Software Design\\Practical\\Coursework2\\Task2\\Tube\\Tube\\DataLayer\\journeys.csv");

            // Init count variable
            int count = 1;
            // Init stations Dictionary
            

            // Init variables
            var journeyData = journey_Reader.ReadFile().ToList();
            string _id = "";
            string name = "";
            int zone;

            // Loop through each in in station reader
            foreach (String[] line_1 in station_Reader.ReadFile())
            {
                // set variables to relevant elements
                _id = line_1[0];
                name = line_1[1];
                zone = int.Parse(line_1[2]);

                // Init the station directly using count as the key
                stations[count] = new Station();

                stations[count].Id = _id;
                stations[count].Name = name;
                stations[count].Zone = zone;
                // Count Journey data where id = start/end station
                stations[count].Started = journeyData.Count(line_2 => line_2[1] == _id);
                stations[count].Ended = journeyData.Count(line_2 => line_2[3] == _id);

                // Add initalised station to Underground class
                London.AddStation(stations[count]);
                count++;
            }

        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            // Clear previous text from textbox
            txtOutout.Text = string.Empty;

            //  
            Underground London_Test = Underground.Instance;
            London_Test.Clear();

            Station station1 = new Station();
            station1.Id = "940GZZLUALD";
            station1.Name = "Aldgate";
            station1.Zone = 1;

            Station station2 = new Station();                                                        
            station2.Id = "910GCFPK";
            station2.Name = "Crofton Park";
            station2.Zone = 3;

            Station station3 = new Station();
            station3.Id = "940GZZLUGGH";
            station3.Name = "Grange Hill";
            station3.Zone = 4;

            Station station4 = new Station();
            station4.Id = "940GZZLUSJW";
            station4.Name = "St John's Wood";
            station4.Zone = 2;

            Station station5 = new Station();
            station5.Id = "S0005";
            station5.Name = "Heathrow Terminal 4";
            station5.Zone = 6;

            London_Test.AddStation(station1);
            London_Test.AddStation(station2);
            London_Test.AddStation(station3);
            London_Test.AddStation(station4);
            London_Test.AddStation(station5);


            // Display stations
            txtOutout.Text += London_Test.ToString();
        }

        private void btnFindStation_Click(object sender, RoutedEventArgs e)
        {
            Underground London = Underground.Instance;

            // Init id from txtInput
            string id = txtInput.Text;

            // Call the find function in London Underground class
            Station station = London.Find(id);

            // Check if station is valid, if not then print error
            if (station == null)
            {
                txtOutout.Text = "No station found!";
            }
            else
            {
                // Display station object
                txtOutout.Text = station.ToString();
            }
           

        }

        private void btnFindCard_Click(object sender, RoutedEventArgs e)
        {
            // Read journey file
            CSVReader journey_Reader = new CSVReader("C:\\Users\\Jack Millar\\OneDrive - Edinburgh Napier University\\Year2-A\\Object Orientated Software Design\\Practical\\Coursework2\\Task2\\Tube\\Tube\\DataLayer\\journeys.csv");

            // Init variables
            string _id = txtInput.Text;
            int count = 0;
            var journeyData = journey_Reader.ReadFile();

            // Clear output textbox
            txtOutout.Text = "";

            // loop through each line in journeyData
            foreach (String[] line_1 in journeyData)
            {
                // if _id = line_1[0] then display and add 1 to counter
                if (_id == line_1[0])
                {   
                    txtOutout.Text += line_1[0] + " made journey from station " + line_1[1] + " to station " + line_1[3] + ".\r\n";
                    count++; 
                }
            }

            // Staff cards begin with 9 and shouldnt be charged, reset counter
            if (_id[0] == '9')
            {
                count = 0;
            }

            // Display overall price of journeys
            txtOutout.Text += "£" + count.ToString();
        }
    }
}
