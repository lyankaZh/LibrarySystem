using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("BorrowInfo")]
    public class BorrowInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        public virtual Reader Reader { get; set; }
        [Required]
        public virtual Book Book { get; set; }
        public DateTime? BorrowDate { get; set; }
        public int BorrowPeriodInDays { get; set; }
        public DateTime? ReturningDate { get; set; }
     }
}
