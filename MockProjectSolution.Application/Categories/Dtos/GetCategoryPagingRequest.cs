using MockProjectSolution.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Categories.Dtos
{
    public class GetCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
