using WebShop.Application.Entities;

namespace WebShop.Application.Repositories.Contracts;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<bool> AddItemToCart(Cart cart, Item item);
}