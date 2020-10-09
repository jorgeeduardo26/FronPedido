using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidoWeb.Models
{
    public class Pedido
    {
        public Pedido()
        {
            //instancia de pedido producto 
            PedidoProducto = new List<PedidoProducto>();
        }

        public int PedidoId { get; set; }
        public decimal Total { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<PedidoProducto> PedidoProducto { get; set; }
    }
}