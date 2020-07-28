using MockProjectSolution.Application.Catalog.Products.Dtos;
using MockProjectSolution.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockProjectSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);
        Task<bool> RegisterUser(RegisterRequest request);
    }
}
