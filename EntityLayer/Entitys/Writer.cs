using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Entitys
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string WriterSurname { get; set; }
        [StringLength(100)]
        public string WriterImage { get; set; }
        [StringLength(100)]
        public string WriterMail { get; set; }
        [MinLength(12)]
        public string WriterPassword { get; set; }

        public ICollection<Heading> Headings { get; set; }
    }
}