using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual Publisher Publisher { get; set; }
        public int Pages { get; set; }
        public virtual Language Language { get; set; }
        public virtual Genre Genre { get; set; }
        public string Location { get; set; }
        public virtual List<Author> Authors { get; set;}
    }
}
