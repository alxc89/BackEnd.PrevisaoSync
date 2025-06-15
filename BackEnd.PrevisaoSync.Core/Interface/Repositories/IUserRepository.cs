using BackEnd.PrevisaoSync.Core.Entities;

namespace BackEnd.PrevisaoSync.Core.Interface.Repositories;
public interface IUserRepository
{
    Task<User?> GetById(int id);
    Task<bool> Delete(int id);
    Task<User> Add(User user);
    Task<User> Update(User user, int id);
}
