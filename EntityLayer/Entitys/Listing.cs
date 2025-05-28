using System;
using System.Collections.Generic;

namespace EntityLayer.Entitys
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ListingDate { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int VehicleId { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
} 