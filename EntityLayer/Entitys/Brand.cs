using System.Collections.Generic;

namespace EntityLayer.Entitys
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
} 