using Clean.Domain.Validation;

namespace Clean.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; } = null!;
        public ICollection<Product> Products { get; set; } = null!;

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(Guid id, string name)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "Invalid id Guid value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string nome)
        {
            ValidateDomain(nome);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name.Name minimum 3 charecters");
            Name = name;
        }
    }
}
