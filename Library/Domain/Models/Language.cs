using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Language
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LanguageId { get; set; }
        [Required]
        public string LanguageName { get; set; }

        public override string ToString()
        {
            return LanguageName;
        }
    }
}
