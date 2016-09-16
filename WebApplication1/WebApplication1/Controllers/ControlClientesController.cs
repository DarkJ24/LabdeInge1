using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net;

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

        public ActionResult Details(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes cliente = baseDatos.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            List<Telefonos> telefonos = baseDatos.Telefonos.Where(a => a.cliente == cliente.cedula).ToList();
            List<Cuentas> cuentas = baseDatos.Cuentas.Where(a => a.cliente == cliente.cedula).ToList();
            ClientesModeloIntermedio modelo = new ClientesModeloIntermedio();
            modelo.listaClientes = new List<Clientes>();
            modelo.listaClientes.Add(cliente);
            modelo.listaTelefonos = telefonos;
            modelo.listaCuentas = cuentas;
            return View(modelo);
        }

        public ActionResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes cliente = baseDatos.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            List<Telefonos> telefonos = baseDatos.Telefonos.Where(a => a.cliente == cliente.cedula).ToList();
            List<Cuentas> cuentas = baseDatos.Cuentas.Where(a => a.cliente == cliente.cedula).ToList();
            ClientesModeloIntermedio modelo = new ClientesModeloIntermedio();
            modelo.listaClientes = new List<Clientes>();
            modelo.listaClientes.Add(cliente);
            modelo.listaTelefonos = telefonos;
            modelo.listaCuentas = cuentas;
            modelo.modeloClientes = cliente;
            modelo.modeloTelefono1 = telefonos.ElementAt(0);
            modelo.modeloTelefono2 = telefonos.ElementAt(1);
            modelo.modeloCuenta1 = cuentas.ElementAt(0);
            modelo.modeloCuenta2 = cuentas.ElementAt(1);
            modelo.modeloCuenta3 = cuentas.ElementAt(2);
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientesModeloIntermedio modelo, string id)
        {
            if (ModelState.IsValid)
            {
                Clientes cliente = baseDatos.Clientes.Find(id);
                modelo.modeloClientes.cedula = id;
                baseDatos.Entry(cliente).CurrentValues.SetValues(modelo.modeloClientes);
                baseDatos.SaveChanges();
                IEnumerable<Telefonos> telefonos = baseDatos.Telefonos.Where(a => a.cliente == cliente.cedula).ToList();
                IEnumerable<Cuentas> cuentas = baseDatos.Cuentas.Where(a => a.cliente == cliente.cedula).ToList();
                baseDatos.Telefonos.RemoveRange(telefonos);
                baseDatos.Cuentas.RemoveRange(cuentas);
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

        [HttpPost]
        public Clientes Delete(string id)
        {
            Clientes cliente = baseDatos.Clientes.Find(id);
            baseDatos.Clientes.Remove(cliente);
            baseDatos.SaveChanges();
            return cliente;
        }

    }
}