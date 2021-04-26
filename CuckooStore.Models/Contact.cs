using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuckooStore.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactID { get; set; }

        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        [StringLength(200, ErrorMessage = "Tên khách hàng phải bao gồm từ 3 đến 200 ký tự.", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email không đúng định dạng!")]
        [Required(ErrorMessage = "Tên email không được để trống")]
        [StringLength(50)]
        public string Email { get; set; }

        [DisplayName("Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(2000, ErrorMessage = "Nội dung phải bao gồm từ 3 đến 2000 ký tự.", MinimumLength = 3)]
        public string Content { get; set; }

        [DisplayName("Ngày")]
        public DateTime Date { get; set; }
    }
}
