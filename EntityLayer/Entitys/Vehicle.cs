using System.Collections.Generic;

namespace EntityLayer.Entitys
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string EngineSize { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string DriveType { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public decimal? Price { get; set; }

        // Navigation Properties
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
} 