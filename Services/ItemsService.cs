using System;
using System.Collections;
using System.Collections.Generic;
using Fall_BurgerShack.Models;
using Fall_BurgerShack.Repositories;

namespace Fall_BurgerShack.Services
{
  public class ItemsService
  {
    private readonly ItemsRepository _repo;
    public ItemsService(ItemsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Item> Get()
    {
      return _repo.Get();
    }

    public Item Get(string id)
    {
      Item exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }

    public Item Create(Item newItem)
    {
      Item exists = _repo.Exists("name", newItem.Name);
      if (exists != null) { throw new Exception("We already have that item"); }
      newItem.Id = Guid.NewGuid().ToString();
      _repo.Create(newItem);
      return newItem;
    }

    public Item Edit(Item editedItem)
    {
      Item item = _repo.Get(editedItem.Id);
      if (item == null) { throw new Exception("Invalid ID"); }
      item.Name = editedItem.Name;
      item.Price = editedItem.Price;
      item.Description = editedItem.Description;
      _repo.Edit(editedItem);
      return editedItem;
    }

    public string Delete(string id)
    {
      Item exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      _repo.Remove(id);
      return "Successfully Removed";
    }
  }
}