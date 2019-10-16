using System;
using System.Collections.Generic;
using Fall_BurgerShack.Models;
using Fall_BurgerShack.Repositories;

namespace Fall_BurgerShack.Services
{
  public class OrdersService
  {
    private readonly OrdersRepository _repo;

    public OrdersService(OrdersRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Order> Get()
    {
      return _repo.Get();
    }

    public Order Get(int id)
    {
      Order exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }

    public Order Create(Order newOrder)
    {
      throw new NotImplementedException();
    }

    public Order Edit(Order editOrder)
    {
      throw new NotImplementedException();
    }

    public string Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}