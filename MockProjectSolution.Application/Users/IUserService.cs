using Microsoft.AspNetCore.Identity;
using MockProjectSolution.Application.Catalog.Products.Dtos;
using MockProjectSolution.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockProjectSolution.Application.Catalog.Users
{
    public interface IUserService
    {
        Task<string> Authenticate (LoginRequest request);
        Task<bool> Register (RegisterRequest request);
        Task<PagedResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);
    }
}
