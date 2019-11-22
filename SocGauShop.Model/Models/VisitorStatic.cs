using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocGauShop.Model.Models
{
    [Table("VisitorStatics")]
    public class VisitorStatic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public DateTime VisitedDate { set; get; }

        [MaxLength(50)]
        public string IPAddress { set; get; }
    }
}