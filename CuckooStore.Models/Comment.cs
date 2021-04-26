using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuckooStore.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        public int ProductID { get; set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Vui lòng điền nội dung bình luận.")]
        [Display(Name = "Bình luận")]
        [StringLength(2000)]
        public string Content { get; set; }

        public DateTime CommentDate { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
