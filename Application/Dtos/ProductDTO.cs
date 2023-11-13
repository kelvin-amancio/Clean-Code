using Clean.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Clean.Application.Dtos
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get;  set; } = null!;
        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get;  set; } = null!;
        [Required(ErrorMessage = "The Price is Required")]
        [DisplayName("Price")]
        public decimal Price { get;  set; }
        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1,9999)]
        [DisplayName("Stock")]
        public int Stock { get;  set; }
        [Required(ErrorMessage = "The Image is Required")]
        [DisplayName("Product Image")]
        [MaxLength(250)]
        public string Image { get;  set; } = null!;
        [DisplayName("Categories")]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; } = null!;
    }
}
