namespace WebAppMobil.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string LicensePlate { get; set; }
        public int DriverID { get; set; } // Foreign key
        public Driver? Driver { get; set; } // Navigation property
    }
}
