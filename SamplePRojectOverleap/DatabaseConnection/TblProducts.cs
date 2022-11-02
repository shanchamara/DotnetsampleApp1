using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SamplePRojectOverleap.DatabaseConnection
{
    public class TblProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("FKSellerID")]
        public int FKSellerID { get; set; }
        [ForeignKey("FKSellerID")]
        public TblSeller TblSeller { get; set; }

        public decimal Cost { get; set; }
    }
}
