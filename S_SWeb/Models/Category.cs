using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace S_SWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display Order must be between 1-100")]
        public required int DisplayOrder { get; set; }
    }
}
