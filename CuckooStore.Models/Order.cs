using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CuckooStore.Models
{
    [Table("Order")]
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DisplayName("Mã Đơn Hàng")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [DisplayName("Ngày Đặt")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Trạng Thái")]
        public Status Status { get; set; }

        [DisplayName("Người nhận")]
        [StringLength(200, ErrorMessage = "Tên người nhận phải bao gồm từ 3 đến 200 ký tự.", MinimumLength = 3)]
        public string ToName { get; set; }

        [DisplayName("Địa chỉ nhận")]
        [StringLength(200, ErrorMessage = "Địa chỉ nhận phải bao gồm từ 3 đến 200 ký tự.", MinimumLength = 3)]
        public string ToAddr { get; set; }

        [DisplayName("Số Điện Thoại")]
        [Required(ErrorMessage = "Số Điện Thoại không được để trống")]
        [RegularExpression(@"(84|0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không đúng")]
        [StringLength(30)]
        public string ToPhone { get; set; }

        [ForeignKey("User")]
        [DisplayName("mã người dùng")]
        public int? UserID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Coupon")]
        [DisplayName("Mã giảm giá")]
        public string Code { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        //Total Cart
        public double Total_Money()
        {
            var total = OrderDetails.Sum(s => s.Product.Price * s.Quantity);
            return (double)total;
        }
    }
}
