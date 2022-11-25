using Core.Constant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Product
{
    public class ProductCreateVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
         public IFormFile MainPhoto { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Weight { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem>? Categories { get; set; }
        public ProductStatus Status { get; set; }

        public List<IFormFile>? Photos { get; set; }
    }
}
