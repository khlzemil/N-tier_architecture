using Web.ViewModels.Product;
using Web.ViewModels.Product.ProductPhoto;

namespace Web.Services.Abstract
{
    public interface IProductService
    {

        Task<ProductIndexVM> GetAllAsync();
        Task<ProductCreateVM> GetCreateModelAsync();
        Task<bool> CreateAsync(ProductCreateVM model);

        Task<ProductUpdateVM> GetUpdateModelAsync(int id);

        Task<bool> UpdateAsync(ProductUpdateVM model);

        Task<bool> DeleteProductAsync(int id);
        Task<bool> DeleteProductPhotosAsync(int id);
        Task<ProductPhotoUpdateVM> GetUpdateProductPhotosModelAsync(int id);
        Task<bool> UpdateProductPhotosAsync(ProductPhotoUpdateVM model);


    }
}
