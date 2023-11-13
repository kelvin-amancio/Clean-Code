using Clean.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Clean.Application.Dtos
{
    public class CategoryDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayCore("Name")]
        public string Name { get; set; } = null!;
    }
}
