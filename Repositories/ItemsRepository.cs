using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Fall_BurgerShack.Models;

namespace Fall_BurgerShack.Repositories
{
  public class ItemsRepository
  {
    private readonly IDbConnection _db;
    public ItemsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Item> Get()
    {
      string sql = "SELECT * FROM items";
      return _db.Query<Item>(sql);
    }

    internal Item Get(string id)
    {
      string sql = "SELECT * FROM items WHERE id = @id";
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }

    internal Item Exists(string property, string value)
    {
      string sql = "SELECT * FROM items WHERE @property = @value";
      return _db.QueryFirstOrDefault<Item>(sql, new { property, value });
    }

    internal void Create(Item newItem)
    {
      string sql = @"
      INSERT INTO items
      (id, name, description, price)
      VALUES
      (@Id, @Name, @Description, @Price)
      ";
      _db.Execute(sql, newItem);
    }

    internal void Edit(Item editedItem)
    {
      string sql = @"
      UPDATE items
      SET
      name = @Name,
      description = @Description,
      price = @Price
      WHERE id = @Id
      ";
      _db.Execute(sql, editedItem);
    }

    internal void Remove(string id)
    {
      string sql = "DELETE FROM items WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}