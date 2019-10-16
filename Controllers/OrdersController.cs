using System;
using System.Collections.Generic;
using Fall_BurgerShack.Models;
using Fall_BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fall_BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OrdersController : ControllerBase
  {
    private readonly OrdersService _os;
    public OrdersController(OrdersService os)
    {
      _os = os;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Order>> Get()
    {
      try
      {
        return Ok(_os.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Order>> Get(int id)
    {
      try
      {
        return Ok(_os.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Order> Post([FromBody] Order newOrder)
    {
      try
      {
        return Ok(_os.Create(newOrder));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Order> Put(int id, [FromBody] Order editOrder)
    {
      try
      {
        editOrder.Id = id;
        return Ok(_os.Edit(editOrder));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_os.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}