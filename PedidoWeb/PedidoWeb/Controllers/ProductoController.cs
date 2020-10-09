using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Newtonsoft.Json;
using PedidoWeb.Models;
using RestSharp;

namespace PedidoWeb.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("productos")]
        public JsonResult ObtenerProductos() 
        {
            var client = new RestClient(WebConfigurationManager.AppSettings["URLAPIPedido"] );
            var request = new RestRequest("/api/producto", Method.GET);
            var response = client.Execute(request);
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(response.Content);
            return Json(productos,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("producto")]
        public JsonResult ObtenerProducto(int id)
        {
            var client = new RestClient(WebConfigurationManager.AppSettings["URLAPIPedido"]);
            var request = new RestRequest("/api/producto", Method.GET);
            var response = client.Execute(request);
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(response.Content);
            Producto producto = productos.FirstOrDefault(p => p.ProductoId == id);
            return Json(producto, JsonRequestBehavior.AllowGet);
        }
    }
}