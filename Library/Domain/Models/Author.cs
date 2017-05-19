using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual List<Book> Books { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(MiddleName))
            {
                return $"{LastName} {FirstName}";
            }
            return $"{LastName} {FirstName[0]}. {MiddleName[0]}.";
        }
    }
}
