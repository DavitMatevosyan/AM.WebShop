using LiteDB;
using WebShop.Application.Entities;
using WebShop.Application.Repositories.Contracts;

namespace WebShop.Application.Repositories.Implementations;

public class CartRepository(string connectionString) : BaseRepository<Cart>(connectionString), ICartRepository
{
    private readonly string _connectionString = connectionString;

    public Task<bool> AddItemToCart(Cart cart, Item item)
    {
        using var dbConn = new LiteDatabase(_connectionString);

        cart.Items.Add(item);
        
        dbConn.GetCollection<Cart>().Update(cart.Id, cart);
        
        return Task.FromResult(true);
        
    }
}