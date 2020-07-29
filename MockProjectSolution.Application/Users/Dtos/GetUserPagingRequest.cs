using MockProjectSolution.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockProjectSolution.Application.Users.Dtos
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { set; get; }
    }
}
