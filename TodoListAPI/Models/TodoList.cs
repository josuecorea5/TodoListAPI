using System;
using System.Collections.Generic;

#nullable disable

namespace TodoListAPI.Models
{
    public partial class TodoList
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
