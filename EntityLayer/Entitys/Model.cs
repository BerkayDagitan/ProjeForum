using System.Collections.Generic;

namespace EntityLayer.Entitys
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool IsActive { get; set; }

        // Foreign Keys
        public int BrandId { get; set; }

        // Navigation Properties
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
} 