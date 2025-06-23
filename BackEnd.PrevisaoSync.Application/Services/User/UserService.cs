using BackEnd.PrevisaoSync.Application.Dtos.User;
using BackEnd.PrevisaoSync.Application.ModelView.User;
using BackEnd.PrevisaoSync.Application.Shared;
using BackEnd.PrevisaoSync.Core.Interface.Repositories;

namespace BackEnd.PrevisaoSync.Application.Services.User;
public class UserService(IUserRepository repository) : IUserService
{
    private readonly IUserRepository _repository = repository;

    public async Task<ServiceResponse<UserViewModel>> CreateUserAsync(UserDto userDto)
    {
        try
        {
            var exists = await _repository.Exists(userDto.Email);
            if (exists)
                return ServiceResponseHelper.Error<UserViewModel>("Já usuário com esse e-mail!");

            var entity = new Core.Entities.User(userDto.FullName, userDto.Email, userDto.Password);
            var saved = await _repository.Add(entity);
            if (saved is null)
                return ServiceResponseHelper.Error<UserViewModel>("Erro ao salvar o usuário!");
            return ServiceResponseHelper.Success(new UserViewModel
            {
                Id = saved.Id,
                FullName = saved.FullName,
                Email = saved.Email
            }, "Usuário criado com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<UserViewModel>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<bool>> DeleteUserAsync(int userId)
    {
        try
        {
            var user = await _repository.GetById(userId);
            if (user is null)
                return ServiceResponseHelper.Error<bool>("Já usuário com esse e-mail!");

            var removed = await _repository.Delete(userId);
            if (!removed)
                return ServiceResponseHelper.Error<bool>("Erro ao deletar o usuário!");
            return ServiceResponseHelper.Success(true, "Usuário deletado com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<bool>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<UserViewModel>> GetUserAsync(int userId)
    {
        try
        {
            var user = await _repository.GetById(userId);
            if (user is null)
                return ServiceResponseHelper.Error<UserViewModel>("Nenhuma cidade favorita encontrada!");
            return ServiceResponseHelper.Success(new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
            }, "Usuário encontrado com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<UserViewModel>($"Erro: {e.Message}");
        }
    }

    public async Task<ServiceResponse<UserViewModel>> UpdateUserAsync(int userId, UserDto userDto)
    {
        try
        {
            var user = await _repository.GetById(userId);
            if (user is null)
                return ServiceResponseHelper.Error<UserViewModel>("Nenhum usuário encontrado!");
            user.Update(userDto.FullName, userDto.Email);
            
            var updated = await _repository.Update(user, userId);
            if (updated is null)
                return ServiceResponseHelper.Error<UserViewModel>("Erro ao salvar o usuário!");
            return ServiceResponseHelper.Success(new UserViewModel
            {
                Id = updated.Id,
                FullName = updated.FullName,
                Email = updated.Email,
            }, "Usuário alterado com sucesso!");
        }
        catch (Exception e)
        {
            return ServiceResponseHelper.Error<UserViewModel>($"Erro: {e.Message}");
        }
    }
}
