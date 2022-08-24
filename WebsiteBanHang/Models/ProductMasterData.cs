using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace WebsiteBanHang.Models
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Giá")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShortDescription { get; set; }
        [Display(Name = "Mô tả dài")]
        public string FullDescription { get; set; }
        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> Typeld { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedUser { get; set; }
        public Nullable<System.DateTime> UpdateUser { get; set; }


    }
}