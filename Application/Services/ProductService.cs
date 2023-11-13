using AutoMapper;
using Clean.Application.Dtos;
using Clean.Application.Interfaces;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;

namespace Clean.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRepositoryEF<Product> _repositoryEF;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper, IRepositoryEF<Product> repositoryEF)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _repositoryEF = repositoryEF;
        }
        public async Task<ProductDTO> GetProductById(Guid id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(Guid id)
        {
            var productEntity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity); 
        }
        public async Task Create(ProductDTO entity)
        {
            var productEntity = _mapper.Map<Product>(entity);
            await _repositoryEF.Create(productEntity);
        }

        public async Task Remove(Guid id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            await _repositoryEF.Remove(productEntity);
        }

        public async Task Update(ProductDTO entity)
        {
            var productEntity = _mapper.Map<Product>(entity);
            productEntity.Id = entity.Id;
            await _repositoryEF.Update(productEntity);
        }
    }
}
