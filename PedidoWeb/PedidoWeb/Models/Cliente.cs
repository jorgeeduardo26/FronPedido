using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidoWeb.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}