using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuckooStore.Models
{
    [Table("BallotImportDetail")]
    public class BallotImportDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BallotImportDetailID { get; set; }

        public int ProductID { get; set; }

        public int BallotImportID { get; set; }

        public int Quantity { get; set; }
        
        public virtual Product Product { get; set; }

        public virtual BallotImport BallotImport { get; set; }
    }
}
