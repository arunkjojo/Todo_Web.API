using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo_Web.API.Data;
using Todo_Web.API.Models.Domain;
using Todo_Web.API.Models.DTO;

namespace Todo_Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public TodoController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        // GET : https://localhost:portNumber/api/todo
        [HttpGet]
        public IActionResult GetAllTodos()
        {
            var todosDomain = _dbContext.Todos.ToList();
            var todoDto = new List<TodoDto>();
            foreach (var todo in todosDomain)
            {
                todoDto.Add(new TodoDto()
                {
                    Id = todo.Id,
                    Label = todo.Label,
                    Description = todo.Description,
                    Status = todo.Status
                });
            }

            return Ok(todoDto);
        }

        // GET : https://localhost:portNumber/api/todo/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetTodoById(Guid id)
        {
            // var regions = _dbContext.Todo.Find(id);
            var todosDomain = _dbContext.Todos.FirstOrDefault(t => t.Id == id);
            if (todosDomain == null) return NotFound();
            var todoDto = new TodoDto()
            {
                Id = todosDomain.Id,
                Label = todosDomain.Label,
                Description = todosDomain.Description,
                Status = todosDomain.Status
            };
            return Ok(todoDto);
        }


        // POST : https://localhost:portNumber/api/todo
        [HttpPost]
        public IActionResult CreateTodo([FromBody] AddTodoRequestDto addTodoRequestDto)
        {
            var todosDomain = new Todo()
            {
                Label = addTodoRequestDto.Label,
                Description = addTodoRequestDto.Description,
                Status = addTodoRequestDto.Status
            };
            _dbContext.Todos.Add(todosDomain);
            _dbContext.SaveChanges();
            var todoDto = new TodoDto()
            {
                Id = todosDomain.Id,
                Label = todosDomain.Label,
                Description = todosDomain.Description,
                Status = todosDomain.Status
            };
            return CreatedAtAction(nameof(GetTodoById), new { id = todoDto.Id}, todoDto);
        }

        // PUT : https://localhost:portNumber/api/todo/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateTodo(Guid id, [FromBody] AddTodoRequestDto updateTodoRequestDto)
        {
            var todosDomain = _dbContext.Todos.FirstOrDefault(t => t.Id == id);
            if (todosDomain == null) return NotFound();

            todosDomain.Label = updateTodoRequestDto.Label;
            todosDomain.Description = updateTodoRequestDto.Description;
            todosDomain.Status = updateTodoRequestDto.Status;

            _dbContext.SaveChanges();
            return Ok(todosDomain);
        }

        // DELETE: https://localhost:portNumber/api/todo/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteTodo(Guid id)
        {
            var todosDomain = _dbContext.Todos.FirstOrDefault(t => t.Id == id);
            if (todosDomain == null) return NotFound();

            _dbContext.Todos.Remove(todosDomain);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
