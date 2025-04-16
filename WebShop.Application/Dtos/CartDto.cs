namespace WebShop.Application.Dtos;

public class CartDto
{
    public int Id { get; set; }
    public List<ItemDto> items { get; set; } = [];
}