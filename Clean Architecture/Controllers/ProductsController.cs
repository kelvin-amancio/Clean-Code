using Clean.Application.Dtos;
using Clean.Application.Interfaces;
using Clean.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace Clean_Architecture.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMemoryCache _memoryCache;

        public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, IMemoryCache memoryCache)
        {
            _productService = productService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if(!_memoryCache.TryGetValue("Productss", out IEnumerable<ProductDTO> product))
            {
                 product = await _productService.GetProducts();
                _memoryCache.Set("Productss", product);
            }
           
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productService.GetProductCategory(id);
            var wwwRoot = _webHostEnvironment.WebRootPath;
            var image = Path.Combine(wwwRoot, "images\\" + product.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var products = await _productService.GetProductById(id);
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var products = await _productService.GetProductById(id);
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Create(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteId(Guid id)
        {
            await _productService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _productService.Update(product);
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
                return View(product);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
