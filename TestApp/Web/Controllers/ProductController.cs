using Microsoft.AspNetCore.Mvc;
using Web.Services.Abstract;
using Web.ViewModels.Product;
using Web.ViewModels.Product.ProductPhoto;

namespace Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {

            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _productService.GetCreateModelAsync();
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Create(ProductCreateVM model)
        {


            var isSucceeded = await _productService.CreateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));
            model = await _productService.GetCreateModelAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _productService.GetUpdateModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductUpdateVM model)
        {
            if (id != model.Id) return NotFound();

            var isSucceeded = await _productService.UpdateAsync(model);
            if (isSucceeded) return RedirectToAction(nameof(Index));

            model = await _productService.GetUpdateModelAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var isSucceded = await _productService.DeleteProductAsync(id);
            if (isSucceded)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

        }

        [HttpGet]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            var isSucceed = await _productService.DeleteProductPhotosAsync(id);
            if (isSucceed)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            
        }


        [HttpGet]
        public async Task<IActionResult> UpdatePhoto(int id)
        {
            
            var model = await _productService.GetUpdateProductPhotosModelAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePhoto(int id, ProductPhotoUpdateVM model)
        {
            var isSucceded = await _productService.UpdateProductPhotosAsync(model);

            if (!isSucceded) return View(model);

            return RedirectToAction(nameof(Index));
            
        }
    }
}
