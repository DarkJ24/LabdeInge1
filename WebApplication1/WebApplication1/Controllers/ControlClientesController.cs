using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ControlClientesController : Controller
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

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientesModeloIntermedio modelo)
        {
            if (ModelState.IsValid)
            {
                baseDatos.Clientes.Add(modelo.modeloClientes);
                baseDatos.SaveChanges();
                if (modelo.modeloTelefono1.numero != null)
                {
                    modelo.modeloTelefono1.cliente = modelo.modeloClientes.cedula;
                    baseDatos.Telefonos.Add(modelo.modeloTelefono1);
                }
                if (modelo.modeloTelefono2.numero != null)
                {
                    modelo.modeloTelefono2.cliente = modelo.modeloClientes.cedula;
                    baseDatos.Telefonos.Add(modelo.modeloTelefono2);
                }
                if (modelo.modeloCuenta1.numero != null)
                {
                    modelo.modeloCuenta1.cliente = modelo.modeloClientes.cedula;
                    baseDatos.Cuentas.Add(modelo.modeloCuenta1);
                }
                if (modelo.modeloCuenta2.numero != null)
                {
                    modelo.modeloCuenta2.cliente = modelo.modeloClientes.cedula;
                    baseDatos.Cuentas.Add(modelo.modeloCuenta2);
                }
                if (modelo.modeloCuenta3.numero != null)
                {
                    modelo.modeloCuenta3.cliente = modelo.modeloClientes.cedula;
                    baseDatos.Cuentas.Add(modelo.modeloCuenta3);
                }
                baseDatos.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Debe completar toda la información necesaria.");
                return View(modelo);
            }
        }
    }
}