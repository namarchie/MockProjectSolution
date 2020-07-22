using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Catalog.Products.Dtos
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIds { get; set; }
    }
}
