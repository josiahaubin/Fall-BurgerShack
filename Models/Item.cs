using BurgerShack.Interfaces;

namespace Fall_BurgerShack.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Id { get; set; }
  }
}