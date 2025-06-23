using BackEnd.PrevisaoSync.Application.Dtos.User;
using BackEnd.PrevisaoSync.Application.ModelView.User;
using BackEnd.PrevisaoSync.Application.Shared;

namespace BackEnd.PrevisaoSync.Application.Services.User;
public interface IUserService
{
    Task<ServiceResponse<UserViewModel>> GetUserAsync(int userId);
    Task<ServiceResponse<UserViewModel>> CreateUserAsync(UserDto userDto);
    Task<ServiceResponse<UserViewModel>> UpdateUserAsync(int userId, UserDto userDto);
    Task<ServiceResponse<bool>> DeleteUserAsync(int userId);
}
