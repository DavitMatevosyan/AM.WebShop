using LiteDB;
using WebShop.Application.Entities;
using WebShop.Application.Repositories.Contracts;

namespace WebShop.Application.Repositories.Implementations;

// connection string should be retrieved from appsettings/secrets/KeyVault
public class BaseRepository<T>(string connectionString) : IBaseRepository<T> where T : BaseEntity
{
    
    public Task<List<T>> GetAsync(int id)
    {
        using var dbConn = new LiteDatabase(connectionString);
        
        var data = dbConn
            .GetCollection<T>()
            .Query()
            .Where(e => e.Id == id)
            .ToList();

        return Task.FromResult(data);
    }

    public Task AddAsync(T entity)
    {
        using var dbConn = new LiteDatabase(connectionString);
        
        dbConn.GetCollection<T>().Insert(entity);
        
        return Task.CompletedTask;
    }

    public Task RemoveAsync(int entityId)
    {
        using var dbConn = new LiteDatabase(connectionString);
        
        dbConn.GetCollection<T>().Delete(entityId);

        var x = dbConn.GetCollection<T>().Query().ToList();
        
        return Task.CompletedTask;    
    }
}