using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListAPI.Models;
using TodoListAPI.Models.Request;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class TodoListController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (todoListContext db = new todoListContext())
            {
                var lista = (from d in db.TodoLists
                             select d).ToList();
                return Ok(lista);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] TodoRequest model)
        {
            using (todoListContext db = new todoListContext())
            {
                TodoList oTodoList = new TodoList();
                oTodoList.Nombre = model.Nombre;
                oTodoList.Descripcion = model.Descripcion;
                db.TodoLists.Add(oTodoList);
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] TodoEditRequest model)
        {
            using (todoListContext db = new todoListContext())
            {
                TodoList oTodoList = db.TodoLists.Find(model.Id);
                oTodoList.Nombre = model.Nombre;
                oTodoList.Descripcion = model.Descripcion;
                db.Entry(oTodoList).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(int Id)
        {
            using(todoListContext db = new todoListContext())
            {
                TodoList oTodoList = db.TodoLists.Find(Id);
                db.TodoLists.Remove(oTodoList);
                db.SaveChanges();
            }
            return Ok();
        }
    }
}
