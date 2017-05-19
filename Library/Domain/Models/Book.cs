using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual Publisher Publisher { get; set; }
        public int Pages { get; set; }
        public virtual Language Language { get; set; }
        public virtual Genre Genre { get; set; }
        public string Location { get; set; }
        public virtual List<Author> Authors { get; set;}

        public override string ToString()
        {
            var stringToReturn = new StringBuilder();
            stringToReturn.Append(Name + ", ");
            foreach (var author in Authors)
            {
                stringToReturn.Append(author + ",");
            }
            stringToReturn = stringToReturn.Remove(stringToReturn.Length - 1, 1);
            return stringToReturn.ToString();
        }
    }
}
