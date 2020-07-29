using Microsoft.AspNetCore.Identity;
using MockProjectSolution.Application.Common;
using MockProjectSolution.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MockProjectSolution.Application.Catalog.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authenticate (LoginRequest request);
        Task<ApiResult<bool>> Register (RegisterRequest request);
        Task<ApiResult<bool>> Update(Guid id, UpdateRequest request);
        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request);
        Task<ApiResult<UserViewModel>> GetById(Guid Id);
        Task<ApiResult<bool>> Delete(Guid id);
    }
}
