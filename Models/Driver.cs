namespace WebAppMobil.Models
{
    public class Driver
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<Car>? Cars { get; set; }
    }
}
