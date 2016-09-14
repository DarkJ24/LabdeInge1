using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        Entities baseDatos = new Entities();
        // GET: Clientes
        public ActionResult Index()
        {
            ClientesModeloIntermedio modelo = new ClientesModeloIntermedio();
            modelo.listaClientes = baseDatos.Clientes.ToList();
            modelo.listaTelefonos = baseDatos.Telefonos.ToList();
            modelo.listaCuentas = baseDatos.Cuentas.ToList();
            return View(modelo);
        }
    }
}