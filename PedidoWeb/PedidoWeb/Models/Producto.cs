using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidoWeb.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public int Existencia { get; set; }
    }
}