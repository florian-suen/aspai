using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace api.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController(TodoContext context) : ControllerBase
    {
        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
        
        
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            return await context.TodoItems.Select(x => ItemToDTO(x))
                .ToListAsync();
            //return await context.TodoItems.ToListAsync();
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
           
            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO todoDTO)
        {
            if (id != todoDTO.Id)
            {
                return BadRequest();
            }

            var todoItem = await context.TodoItems.FindAsync(id);
            //context.Entry(todoDTO).State = EntityState.Modified;

            if (todoItem == null)
            {
                return NotFound();
            }
            
            todoItem.Name = todoDTO.Name;
            todoItem.IsComplete = todoDTO.IsComplete;
            
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)  when (!TodoItemExists(id))
            {
        
                    return NotFound();
          
           
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
        {
            
            var todoItem = new TodoItem
            {
                IsComplete = todoDTO.IsComplete,
                Name = todoDTO.Name
            };

            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id },
                ItemToDTO(todoItem));
            
          
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            context.TodoItems.Remove(todoItem);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoItemExists(long id)
        {
            return context.TodoItems.Any(e => e.Id == id);
        }
    }
}
