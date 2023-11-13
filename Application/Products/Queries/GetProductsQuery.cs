using Clean.Domain.Entities;
using MediatR;

namespace Clean.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
