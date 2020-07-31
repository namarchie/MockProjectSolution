using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MockProjectSolution.Application.Catalog.Products.Dtos
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Mời bạn nhập tài khoản")]
        [Display(Name = "Tài khoản")]
        public string Account { set; get; }
        [Required(ErrorMessage = "Mời bạn nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { set; get; }
        [Required(ErrorMessage = "Mời bạn nhập giá bán")]
        [Display(Name = "Giá bán")]
        public decimal Price { set; get; }
        [Required(ErrorMessage = "Mời bạn nhập mã sản phẩm")]
        [Display(Name = "Mã sản phẩm")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Mời bạn nhập mô tả sản phẩm")]
        [Display(Name = "Mô tả sản phẩm")]
        public string Description { set; get; }
        [Required(ErrorMessage = "Mời bạn chọn ảnh")]
        [Display(Name = "Ảnh")]
        public IFormFile Image { set; get; }
        public int CategoryId { set; get; }
        [Required(ErrorMessage = "Mời bạn chọn danh mục sản phẩm")]
        [Display(Name = "Danh mục sản phẩm")]
        public string CategoryName { set; get; }
    }
}
