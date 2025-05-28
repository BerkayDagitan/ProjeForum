using System;

namespace EntityLayer.Entitys
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }

        // Foreign Keys
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        // Navigation Properties
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
} 