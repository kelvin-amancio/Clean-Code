using Clean.Domain.Entities;
using FluentAssertions;

namespace Clean.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(Guid.NewGuid(), "Category Name");
            action.Should()
                  .NotThrow<Clean.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(Guid.Empty, "Category Name");
            action.Should()
                  .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid id Guid value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExcepetionShortName()
        {
            Action action = () => new Category(Guid.Empty, "Ca");
            action.Should()
                  .Throw<Clean.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid name.Name minimum 3 charecters");
        }
    }
}