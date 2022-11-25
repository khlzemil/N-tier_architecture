using Core.Constant;
using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        [Display(Name = "Photo")]
        public string? MainPhotoPath { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Weigth { get; set; }
        public ProductStatus Status { get; set; }
        [Display(Name = "Sub Photos")]

        public ICollection<ProductPhoto>? ProductPhotos { get; set; } 
    }
}
