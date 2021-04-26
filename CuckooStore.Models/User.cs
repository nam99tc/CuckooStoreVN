using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuckooStore.Models
{
    [Table("User")]
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Comments = new HashSet<Comment>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [DisplayName("Họ Và Tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(50)]
        public string FullName { get; set; }

        [DisplayName("Email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email không đúng định dạng!")]
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(50)]
        public string Email { get; set; }

        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(30)]
        public string PassWord { get; set; }

        [DisplayName("Địa Chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(200)]
        public string Address { get; set; }

        [DisplayName("Số Điện Thoại")]
        [Required(ErrorMessage = "Số Điện Thoại không được để trống")]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không đúng")]
        [StringLength(30)]
        public string Phone { get; set; }

        [DisplayName("Quyền")]
        public Role Role { get; set; }

        [DisplayName("Trạng thái")]
        public StatusUser StatusUser { get; set; }

        [DisplayName("Ảnh")]
        [StringLength(100)]
        public string Image { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}