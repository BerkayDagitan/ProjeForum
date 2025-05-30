using System;
using System.Collections.Generic;

namespace EntityLayer.Entitys
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
} 