using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WavesOfFoodDemo.Server.Dtos;

namespace WavesOfFoodDemo.Server.Services;

public interface IUserInfoService
{
    Task<List<UserInfoDto>> GetUserInfoDtosAsync();
    Task<bool> AddUserInfoAsync(UserInfoCreateDto userInfoCreateDto);
    Task<bool?> EditUserInfoAsync(UserInfoDto userInfoDto);
    Task<bool?> RemoveUserInfoDtosAsync(Guid id);
}
