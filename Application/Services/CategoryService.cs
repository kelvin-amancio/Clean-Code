using AutoMapper;
using Clean.Application.Dtos;
using Clean.Application.Interfaces;
using Clean.Domain.Entities;
using Clean.Domain.Interfaces;

namespace Clean.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRepositoryEF<Category> _repositoryEF;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IRepositoryEF<Category> repositoryEF)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _repositoryEF = repositoryEF;
        }

        public async Task<CategoryDTO> GetById(Guid id)
        {
          var categoryEntity = await _categoryRepository.GetById(id);
          return _mapper.Map<CategoryDTO>(categoryEntity);  
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
           var categoriesEntity = await _categoryRepository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);     
        }
        public async Task Create(CategoryDTO entity)
        {
            var mapperEntity = _mapper.Map<Category>(entity);
            await _repositoryEF.Create(mapperEntity);
        }
        public async Task Remove(Guid id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            await _repositoryEF.Remove(categoryEntity);
        }

        public async Task Update(CategoryDTO entity)
        {
            var mapperEntity = _mapper.Map<Category>(entity);
            await _repositoryEF.Update(mapperEntity);
        }
    }
}
