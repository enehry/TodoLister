using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todolister.Data;
using Todolister.Models;

namespace Todolister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly DataContext _context;
        public TodoController(DataContext context)
        {
            _context = context;
        }
        
        private readonly List<Todo> _todoRepository = new()
        {
            new Todo
            {
                Id = 1,
                Title = "Learn C#",
                Description = "Learn C# and .NET",
                DateCreated = DateTime.Now
            },
            new Todo
            {
                Id = 2,
                Title = "Learn Java",
                Description ="Learn Java and Sprint",
                DateCreated = DateTime.Now.AddDays(30),
            }
    
        };
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> Get()
        {
            
            return await _context.Todos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Todo todo)
        {
            
            _context.Todos.Add(todo);
            int result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return BadRequest("Data not inserted");
            }

            return Ok("Todo added successfully");
        }

        [HttpPut]
        public async Task<ActionResult> Update(Todo request)
        {
           Todo? todo = await _context.Todos.FindAsync(request.Id);

            if (todo == null) return BadRequest("Todo not found");

            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.DateCreated = request.DateCreated;

            await _context.SaveChangesAsync();

            return Ok(
                new 
                { message = "Todo Updated", request});
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            Todo? todo = await _context.Todos.FindAsync(id);
            if (todo == null) return BadRequest("Not Found");

            _context.Todos.Remove(todo);
            
            await _context.SaveChangesAsync();

            return Ok(
                new { mesage = "Todo Successfully deleted", todo }
                );

        }


    }
}
