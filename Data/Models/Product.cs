using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        public int? SmallImageId { get; set; }

        [DisplayName("Ảnh nhỏ")]
        public Image SmallImage { get; set; }

        [DisplayName("Ảnh nhỏ")]
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile SmallImageFile { get; set; }

        public int? BannerImageId { get; set; }

        [DisplayName("Ảnh lớn")]
        public Image BannerImage { get; set; }

        [DisplayName("Ảnh nhỏ")]
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile BannerImageFile { get; set; }

        [DisplayName("Tên loại")]
        public int CategoryId { get; set; }

        [DisplayName("Tên loại")]
        public Category Category { get; set; }

        [Required]
        [DefaultValue(0)]
        [DisplayName("Giá bán")]
        public int Price { get; set; }

        [DefaultValue(0)]
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DisplayName("Khối lượng")]
        public double Weight { get;set; }
    }
}
