using MockProjectSolution.Application.Common;
using MockProjectSolution.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockProjectSolution.AdminApp.Services
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);
        Task<ApiResult<bool>> UpdateUser(Guid Id, UpdateRequest request);
        Task<ApiResult<UserViewModel>> GetById(Guid Id);
        Task<ApiResult<bool>> Delete(Guid id);
    }
}
