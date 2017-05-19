using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }

        public override string ToString()
        {
            return GenreName;
        }
    }
}
