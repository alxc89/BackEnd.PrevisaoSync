using BackEnd.PrevisaoSync.Core.Entities;
using BackEnd.PrevisaoSync.Core.Interface.Repositories;
using BackEnd.PrevisaoSync.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.PrevisaoSync.Infra.Repository;
public class FavoriteCityRepository(DataContext context) : IFavoriteCityRepository
{
    private readonly DataContext _context = context;

    public async Task<FavoriteCity> Add(FavoriteCity favoriteCity)
    {
        try
        {
            await _context.FavoriteCities.AddAsync(favoriteCity);
            await _context.SaveChangesAsync();
            return favoriteCity;
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao adicionar a cidade nos favoritos", e);
        }
    }

    public async Task<bool> Delete(int id, int userId)
    {
        try
        {
            var favoriteCity = await _context
                .FavoriteCities
                .FirstOrDefaultAsync(fc => fc.Id.Equals(id) && fc.UserId.Equals(userId));

            if (favoriteCity is not null)
                _context.FavoriteCities.Remove(favoriteCity);
            else
                throw new Exception("Cidade Favorita não localizada ou não pertence ao usuário!");
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao deletar a cidade dos favoritos", e);
        }
    }

    public async Task<bool> Exists(string code)
    {
        try
        {
            return await _context
                .FavoriteCities
                .AnyAsync(fc => fc.Code.Equals(code));
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao deletar a cidade dos favoritos", e);
        }
    }

    public async Task<IEnumerable<FavoriteCity>> FavoriteCities(int userId)
    {
        try
        {
            return await _context
                .FavoriteCities
                .Where(fc => fc.UserId.Equals(userId))
                .ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao retornar todas as cidades favoritas do usuário!", e);
        }
    }

    public async Task<FavoriteCity?> GetById(int id, int userId)
    {
        try
        {
            return await _context
                .FavoriteCities
                .FirstOrDefaultAsync(fc => fc.Id.Equals(id) && fc.UserId.Equals(userId));
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao retornar a cidade favorita do usuário!", e);
        }
    }

    public async Task<FavoriteCity> Update(FavoriteCity favoriteCity, int userId)
    {
        try
        {
            var favoriteCityUpdated = await _context
                .FavoriteCities
                .FirstOrDefaultAsync(fc => fc.Id.Equals(favoriteCity.Id) && fc.UserId.Equals(userId));
            if (favoriteCityUpdated == null)
                throw new Exception("Cidade Favorita não localizada ou não pertence ao usuário!");

            _context.Entry(favoriteCityUpdated).CurrentValues.SetValues(favoriteCity);
            await _context.SaveChangesAsync();
            return favoriteCityUpdated;
        }
        catch (Exception e)
        {
            throw new Exception("Erro ao atualizar a cidade favorita do usuário!", e);
        }
    }
}

