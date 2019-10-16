using System;
using System.Collections.Generic;
using Fall_BurgerShack.Models;
using Fall_BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fall_BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly ItemsService _is;

    public ItemsController(ItemsService iserv)
    {
      _is = iserv;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get()
    {
      try
      {
        return Ok(_is.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Item> Get(string id)
    {
      try
      {
        return Ok(_is.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Item> Post([FromBody] Item newItem)
    {
      try
      {
        return Ok(_is.Create(newItem));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Item> Put(string id, [FromBody] Item editedItem)
    {
      try
      {
        editedItem.Id = id;
        return Ok(_is.Edit(editedItem));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        return Ok(_is.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}