using System;
using System.Collections.Generic;

namespace EntityLayer.Entitys
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int? ParentCommentId { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> SubComments { get; set; }
    }
} 