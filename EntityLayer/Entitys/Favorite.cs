using System;

namespace EntityLayer.Entitys
{
    public class Favorite
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int ListingId { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Listing Listing { get; set; }
    }
} 