using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuckooStore.Models
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            BallotImportDetails = new HashSet<BallotImportDetail>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [DisplayName("Tên Sản Phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(200, ErrorMessage = "Tên sản phẩm phải bao gồm từ 3 đến 200 ký tự.", MinimumLength = 3)]
        public string ProductName { get; set; }

        [DisplayName("Ảnh")]
        [StringLength(100)]
        public string Image { get; set; }

        [DisplayName("Bảo Hành")]
        [Required(ErrorMessage = "Thời gian bảo hành không được để trống")]
        public int BaoHanh { get; set; }

        [DisplayName("Màu")]
        [Required(ErrorMessage = "Màu sắc không được để trống")]
        [StringLength(30)]
        public string MauSac { get; set; }

        [DisplayName("Giá")]
        [Required(ErrorMessage = "Giá không được để trống")]
        [DisplayFormat(DataFormatString = "{0:0,0} đ")]
        public decimal Price { get; set; }

        [DisplayName("Giá khuyến mãi")]
        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
        [DisplayFormat(DataFormatString = "{0:0,0} đ")]
        public decimal? UnitPrice { get; set; }

        [DisplayName("Mô tả")]
        [StringLength(2000, ErrorMessage = "Mô tả phải bao gồm từ 20 đến 2000 ký tự.", MinimumLength = 20)]
        public string Description { get; set; }

        [DisplayName("Số lượng")]
        public int? Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<BallotImportDetail> BallotImportDetails { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
