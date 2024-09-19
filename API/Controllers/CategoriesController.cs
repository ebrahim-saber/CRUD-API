using API.Data;
using API.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //Connetion To Database
        private readonly AppDbContext _db;
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }



        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var Cat = await _db.Categories.ToListAsync();
            return Ok(Cat);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategories(string name)
        {
            Category category = new() { Name = name };  // initializerObject
            await _db.Categories.AddAsync(category);
             _db.SaveChanges();
            return Ok(category);
        }


        [HttpPut]
        public async Task<IActionResult> EditCategories(Category category)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);
            if (c == null)
            {
                return NotFound("Category Id not correct ");
            }
            c.Name = category.Name;
            _db.SaveChanges();
            return Ok(category);
        }


        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCategories(int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c == null)
            {
                return NotFound("Category Id not correct ");
            }
            _db.Categories.Remove(c);
            _db.SaveChanges();
            return Ok(c);
        }
    }
}
