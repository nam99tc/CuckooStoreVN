using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuckooStore.Models
{
    [Table("Coupon")]
    public class Coupon
    {
        public Coupon()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [DisplayName("Mã giảm giá")]
        public string Code { get; set; }

        [DisplayName("Phần trăm giảm giá")]
        [Required(ErrorMessage = "Phần trăm giảm giá không được để trống")]
        public decimal Discount { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}