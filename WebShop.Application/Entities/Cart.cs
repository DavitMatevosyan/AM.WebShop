namespace WebShop.Application.Entities;

public class Cart : BaseEntity
{
    public List<Item> Items { get; set; } = [];
}