using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Models
{
    public class ClientesModeloIntermedio
    {
        public Clientes modeloClientes { get; set; }
        public Telefonos modeloTelefono1 { get; set; }
        public Telefonos modeloTelefono2 { get; set; }
        public Cuentas modeloCuenta1 { get; set; }
        public Cuentas modeloCuenta2 { get; set; }
        public Cuentas modeloCuenta3 { get; set; }
        public ApplicationUser modeloUsuario { get; set; }

        public List<Clientes> listaClientes { get; set; }
        public List<Telefonos> listaTelefonos { get; set; }
        public List<Cuentas> listaCuentas { get; set; }
        public List<ApplicationUser> listaUsuarios { get; set; }
    }
}
