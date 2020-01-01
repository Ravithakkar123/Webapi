using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi.Models;

namespace Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly RestaurantDataContext _context;

        public OrderController(RestaurantDataContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //  Add item to existing order
      /*  public IActionResult EditOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }
            else
            {
                try
                {

                    _context.Orders.Update(order);
                    _context.SaveChanges();
                    return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
                }
                catch
                {
                    return BadRequest();
                }
            }
        }*/

        // POST: api/Order
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var result = _context.Orders.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(result);

            try
            {
                _context.SaveChanges();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
