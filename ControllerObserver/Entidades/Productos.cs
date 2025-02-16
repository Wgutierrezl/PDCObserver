using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ControllerObserver.Entidades
{
    public class Productos
    {
        [Key] 
        public int ProductoID {  get; set; }
        public string? NombreProducto { get; set; }
        public decimal Precio {  get; set; }
    }
}
