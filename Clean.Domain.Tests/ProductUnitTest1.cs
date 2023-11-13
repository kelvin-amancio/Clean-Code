using Clean.Domain.Entities;
using FluentAssertions;

namespace Clean.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreatePedido_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Product Name","Description name", 200,100,"Image name");
            action.Should()
                  .NotThrow<Clean.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
