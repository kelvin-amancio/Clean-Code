using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public Guid Id { get; set; }

        public ProductRemoveCommand(Guid id)
        {
          Id = id;
        }
    }
}
