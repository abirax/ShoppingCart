using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartFunctionality.Data;

namespace ShoppingCartFunctionality.Controllers
{
    [Route("api/itemapi")]
    [ApiController]
    public class ItemDetailsController : ControllerBase
    {
        private readonly ShoppingDbContext _context;

        public ItemDetailsController(ShoppingDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemDetails
        [HttpGet]
        [Route("Details")]
        public IEnumerable<ItemDetails> GetItemDetails()
        {
            return _context.ItemDetails;
        }

        // GET: api/ItemDetails/5
        [HttpGet("Details/{id}")]
        public IEnumerable<ItemDetails> GetItemDetails([FromRoute] int id)
        {
          

            var itemDetails =  _context.ItemDetails.Where<ItemDetails>(i=>i.Item_ID==id);

       

            return itemDetails;
        }

        // PUT: api/ItemDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDetails([FromRoute] int id, [FromBody] ItemDetails itemDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemDetails.Item_ID)
            {
                return BadRequest();
            }

            _context.Entry(itemDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailsExists(id))
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

        // POST: api/ItemDetails
        [HttpPost]
        public async Task<IActionResult> PostItemDetails([FromBody] ItemDetails itemDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ItemDetails.Add(itemDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemDetails", new { id = itemDetails.Item_ID }, itemDetails);
        }

        // DELETE: api/ItemDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemDetails = await _context.ItemDetails.FindAsync(id);
            if (itemDetails == null)
            {
                return NotFound();
            }

            _context.ItemDetails.Remove(itemDetails);
            await _context.SaveChangesAsync();

            return Ok(itemDetails);
        }

        private bool ItemDetailsExists(int id)
        {
            return _context.ItemDetails.Any(e => e.Item_ID == id);
        }
    }
}