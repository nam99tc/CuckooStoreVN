using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuckooStore.Models
{
    [Table("BallotImport")]
    public class BallotImport
    {
        public BallotImport()
        {
            BallotImportDetails = new HashSet<BallotImportDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BallotImportID { get; set; }

        [DisplayName("Người Nhận")]
        [Required(ErrorMessage = "Tên người nhận không được để trống")]
        [StringLength(200, ErrorMessage = "Tên người nhận phải bao gồm từ 3 đến 200 ký tự.", MinimumLength = 3)]
        public string NguoiNhan { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(200, ErrorMessage = "Tên đại chỉ phải bao gồm từ 3 đến 200 ký tự.", MinimumLength = 3)]
        public string FromAdd { get; set; }

        [DisplayName("Tên kho")]
        [Required(ErrorMessage = "Tên kho không được để trống")]
        [StringLength(200, ErrorMessage = "Tên kho phải bao gồm từ 3 đến 200 ký tự.", MinimumLength = 3)]
        public string Kho { get; set; }

        [DisplayName("Ngày nhập")]
        public DateTime NgayNhap { get; set; }

        public virtual ICollection<BallotImportDetail> BallotImportDetails { get; set; }
    }
}