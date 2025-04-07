using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public class Inventario
    {
        private int _id;
        private Administrador _administrador;
        private DateTime _fechaRealizacion;
        private List<Producto> _productos;

        public Inventario() 
        { 
            Productos = new List<Producto>();
        }

        public Inventario(int id, Administrador administrador, DateTime fechaRealizacion)
        {
            Id = id;
            Administrador = administrador;
            FechaRealizacion = fechaRealizacion;
            Productos = new List<Producto>();
        }

        public int Id { get => _id; set => _id = value; }
        public Administrador Administrador { get => _administrador; set => _administrador = value; }
        public DateTime FechaRealizacion { get => _fechaRealizacion; set => _fechaRealizacion = value; }
        public List<Producto> Productos { get => _productos; set => _productos = value; }
    }
}