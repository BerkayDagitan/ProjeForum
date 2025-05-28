using System;
using System.Collections.Generic;

namespace EntityLayer.Entitys
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public int ViewCount { get; set; }
        public bool IsSolved { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? VehicleId { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
} 