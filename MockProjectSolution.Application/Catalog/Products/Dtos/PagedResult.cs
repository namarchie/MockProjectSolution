using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Catalog.Products.Dtos
{
    public class PagedResult<T> : PagesResultBase
    {
        public List<T> Items { set; get; }
    }
}
