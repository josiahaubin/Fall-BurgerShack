using Fall_BurgerShack.Interfaces;

namespace Fall_BurgerShack.Models
{
  public class Order : IOrder
  {
    public string CustomerName { get; set; }
    public int Id { get; set; }
  }
}