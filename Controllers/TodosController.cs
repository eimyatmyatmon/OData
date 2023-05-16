using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataTutorial.Models;
using ODataTutorial.Data;

namespace ODataTutorial.Controllers
{
    public class TodosController : ODataController
    {
        private readonly DataContext _db;

        private readonly ILogger<TodosController> _logger;

        public TodosController(DataContext dbContext, ILogger<TodosController> logger)
        {
            _logger = logger;
            _db = dbContext;
        }

        [EnableQuery(PageSize = 15)]
        public IQueryable<Todo> Get()
        {
            return _db.Todos;
        }

        [EnableQuery]
        public SingleResult<Todo> Get([FromODataUri] Guid key)
        {
            var result = _db.Todos.Where(c => c.Id == key);
            return SingleResult.Create(result);
        }

        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();
            return Created(todo);
        }

        [EnableQuery]
        public async Task<IActionResult> Patch([FromODataUri] Guid key, Delta<Todo> Todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingTodo = await _db.Todos.FindAsync(key);
            if (existingTodo == null)
            {
                return NotFound();
            }

            Todo.Patch(existingTodo);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(existingTodo);
        }

        [EnableQuery]
        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {
            var existingTodo = await _db.Todos.FindAsync(key);
            if (existingTodo == null)
            {
                return NotFound();
            }

            _db.Todos.Remove(existingTodo);
            await _db.SaveChangesAsync();
            return StatusCode(StatusCodes.Status204NoContent);
        }

        private bool TodoExists(Guid key)
        {
            return _db.Todos.Any(p => p.Id == key);
        }
    }
}