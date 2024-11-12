using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.Model;

namespace NorthwindApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.category.ToListAsync();
        }



        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.categoryid }, category);
        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.categoryid)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
