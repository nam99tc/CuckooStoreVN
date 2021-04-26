using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuckooStore.Models
{
    [Table("Categoty")]
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Vui lòng điền tên danh mục.")]
        [Display(Name = "Tên danh mục")]
        [StringLength(200, ErrorMessage = "Tên danh mục phải bao gồm từ 3 đến 200 ký tự.", MinimumLength = 3)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Vui lòng điền mô tả.")]
        [Display(Name = "Mô tả")]
        [StringLength(2000, ErrorMessage = "Tên danh mục phải bao gồm từ 20 đến 2000 ký tự.", MinimumLength = 20)]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
