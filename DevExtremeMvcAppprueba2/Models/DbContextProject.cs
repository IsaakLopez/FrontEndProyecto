using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public class DbContextProject : DbContext
    {
        public DbContextProject() : base ("MyDbConnectionString") { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Devoluciones> Devoluciones { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Resenia> Resenias { get; set; }


    }
}