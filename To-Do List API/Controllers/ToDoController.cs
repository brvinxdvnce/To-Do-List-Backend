using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Data;
using To_Do_List_API.Models.Entities;

namespace To_Do_List_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;
        public ToDoController(AppDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _dbcontext.ToDoItems.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ToDoItem item)
        {
            _dbcontext.ToDoItems.Add(item);
            await _dbcontext.SaveChangesAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _dbcontext.ToDoItems.FindAsync(id);
            if (item == null) return NotFound();
            _dbcontext.ToDoItems.Remove(item);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}/title")]
        public async Task<IActionResult> UpdateTitle(int id, [FromBody] string newTitle)
        {
            var item = await _dbcontext.ToDoItems.FindAsync(id);
            if (item == null) return NotFound();
            item.Title = newTitle;
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}/description")]
        public async Task<IActionResult> UpdateDescription(int id, [FromBody] string newDescription)
        {
            var item = await _dbcontext.ToDoItems.FindAsync(id);
            if (item == null) return NotFound();
            item.Description = newDescription;
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}/completion")]
        public async Task<IActionResult> ChangeCompletion(int id)
        {
            var item = await _dbcontext.ToDoItems.FindAsync(id);
            if (item == null) return NotFound();
            item.IsCompleted = !item.IsCompleted;
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
    }
}
