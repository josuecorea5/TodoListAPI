using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListAPI.Models.Request
{
    public class TodoRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
