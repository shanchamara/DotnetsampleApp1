using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamplePRojectOverleap.DatabaseConnection
{
    public class TblSeller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }



        public ICollection<TblProducts> TblProducts { get; set; }
    }
}
