using Clean.Application.Dtos;
using Clean.Application.Interfaces;
using Clean.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Clean_Architecture.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMemoryCache _memoryCache;
        public CategoriesController(ICategoryService categoryService, IMemoryCache memoryCache)
        {
           _categoryService = categoryService;
           _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if(!_memoryCache.TryGetValue("categories", out IEnumerable<CategoryDTO> categorie))
            {
                categorie = await _categoryService.GetCategories();
                _memoryCache.Set("categories", categorie);
            }

            return View(categorie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categorieById = await _categoryService.GetById(id);
            if (categorieById == null) return NotFound();
            return View(categorieById);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {          
            var categorieById = await _categoryService.GetById(id);
            if (categorieById == null) return NotFound();
            return View(categorieById);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var categorieById = await _categoryService.GetById(id);
            if (categorieById == null) return NotFound();

            return View(categorieById);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Create(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.Update(category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch (Exception)
            {
                throw;
            }     
        }

        [HttpPost]
        public async Task<IActionResult> DeleteId(Guid id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
