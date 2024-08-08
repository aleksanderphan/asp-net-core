namespace WebAppMobil.Models
{
    public class Logbook
    {
        public int ID { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public int CarID { get; set; }
        public Car? Car { get; set; } // Navigation property for the Car

        public int DriverID { get; set; }
        public Driver? Driver { get; set; } // Navigation property for the Driver

        public string Destination { get; set; }
        public string PermitNo { get; set; }
    }
}
