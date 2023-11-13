using Clean.Domain.Validation;

namespace Clean.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; } = null!;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(Guid id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "Invalid id Guid value");
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, Guid id)
        {
            ValidateDomain(name, description, price, stock, image);
            Id = id;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Name minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");

            DomainExceptionValidation.When(price < 0, "Price less than zero");
            DomainExceptionValidation.When(stock < 0, "Stock less than zero");
            DomainExceptionValidation.When(image.Length < 3, "Image minimum 3 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
