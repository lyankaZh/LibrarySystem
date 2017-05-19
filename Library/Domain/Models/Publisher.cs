using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Publisher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PublisherId { get; set; }
        [Required]
        public string PublisherName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return PublisherName;
        }
    }
}
