using BackEnd.PrevisaoSync.Core.Entities;
using BackEnd.PrevisaoSync.Core.Interface.Repositories;
using BackEnd.PrevisaoSync.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.PrevisaoSync.Infra.Repository;
public class UserRepository(DataContext context) : IUserRepository
{
    private readonly DataContext _context = context;
    public async Task<User> Add(User user)
    {
        try
        {
            var userCreated = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return userCreated.Entity;
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao adicionar um usuário", e);
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var user = await _context
                .Users
                .FirstOrDefaultAsync(fc => fc.Id.Equals(id));

            if (user is not null)
                _context.Users.Remove(user);
            else
                throw new Exception("Usuário não localizado!");
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao deletar o usuário", e);
        }
    }

    public async Task<User?> GetById(int id)
    {
        try
        {
            return await _context
                .Users
                .FirstOrDefaultAsync(fc => fc.Id.Equals(id));
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao retornar o usuário!", e);
        }
    }

    public async Task<User> Update(User user, int id)
    {
        try
        {
            var userUpdated = await _context
                .Users
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
            if (userUpdated == null)
                throw new Exception("Usuário não localizado!");

            _context.Entry(userUpdated).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
            return userUpdated;
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao atualizar o usuário!", e);
        }
    }
}
