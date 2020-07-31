using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MockProjectSolution.Application.Products.Dtos
{
    public class ProductDeleteRequest
    {
        [Display(Name = "Id")]
        public int Id { set; get; }
        [Display(Name = "Tài khoản")]
        public string Account { set; get; }
        [Display(Name = "Mật khẩu")]
        public string Password { set; get; }
        [Display(Name = "Giá")]
        public decimal Price { set; get; }
        [Display(Name = "Mã sản phẩm")]
        public string Name { set; get; }
        [Display(Name = "Mô tả")]
        public string Description { set; get; }
        [Display(Name = "Ảnh")]
        public string Image { set; get; }
        [Display(Name = "Mã danh mục sản phẩm")]
        public int CategoryId { set; get; }
    }
}
