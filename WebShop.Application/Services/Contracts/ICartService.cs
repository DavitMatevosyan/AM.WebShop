using WebShop.Application.Dtos;

namespace WebShop.Application.Services.Contracts;

public interface ICartService
{
    Task<List<CartDto>> GetCartItemsAsync(int cartId);
    Task<bool> AddToCartAsync(int cartId, ItemDto item);
    Task RemoveFromCartAsync(int cartId, ItemDto item);
}