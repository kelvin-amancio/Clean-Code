using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; } = null!;
        public Guid CategoryId { get; set; }
    }
}
