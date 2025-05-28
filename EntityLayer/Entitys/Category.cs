using System.Collections.Generic;

namespace EntityLayer.Entitys
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }

        // Foreign Keys
        public int? ParentCategoryId { get; set; }

        // Navigation Properties
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
} 