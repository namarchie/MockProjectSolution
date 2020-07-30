using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MockProjectSolution.Application.Catalog.Products.Dtos
{
    public class ProductViewModel
    {
        public int Id { set; get; }
        [Display(Name = "Tài khoản")]
        public string Account { set; get; }
        [Display(Name = "Mật khẩu")]
        public string Password { set; get; }
        [Display(Name = "Giá bán")]
        [DataType(DataType.Currency)]
        public decimal Price { set; get; }
        [Display(Name = "Mã sản phẩm")]
        public string Name { set; get; }
        [Display(Name = "Mô tả")]
        public string Description { set; get; }
        public DateTime DateCreated { set; get; }
        [Display(Name = "Ảnh")]
        public string Image { set; get; }
        public int CategoryId { set; get; }
        [Display(Name = "Danh mục")]
        public string Category { set; get; }
    }
}
