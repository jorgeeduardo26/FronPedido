using Newtonsoft.Json;
using PedidoWeb.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PedidoWeb.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("generaPedido")]
        public JsonResult GeneraPedido(Pedido pedido) 
        {
            var client = new RestClient(WebConfigurationManager.AppSettings["URLAPIPedido"]);
            var request = new RestRequest("/api/pedido", Method.POST);
            var jsonPedido = JsonConvert.SerializeObject(pedido);
            request.AddJsonBody(jsonPedido);

            var response = client.Execute(request);           
            return Json(response.Content, JsonRequestBehavior.AllowGet);

        }

      
    }
}