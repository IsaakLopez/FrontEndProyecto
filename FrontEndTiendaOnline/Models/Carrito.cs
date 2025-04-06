using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndTiendaOnline.Models
{
    public class Carrito
    {
        private int _id;
        private Cliente _cliente;
        private List<Producto> _productos;
        private int _cantidad;
        private float _subTotal;
        private int _totalProductos;
        private string _estado = "Activo";

        public Carrito()
        {
            Productos = new List<Producto>();
        }

        public Carrito(int id, Cliente cliente, int cantidad, float subTotal, int totalProductos)
        {
            Id = id;
            Cantidad = cantidad;
            SubTotal = subTotal;
            Cliente = cliente;
            Productos = new List<Producto>();
            TotalProductos = totalProductos;

        }

        public int Id { get => _id; set => _id = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public float SubTotal { get => _subTotal; set => _subTotal = value; }
        internal Cliente Cliente { get => _cliente; set => _cliente = value; }
        internal List<Producto> Productos { get => _productos; set => _productos = value; }
        public int TotalProductos { get => _totalProductos; set => _totalProductos = value; }
        public string Estado { get => _estado; set => _estado = value; }
    }
}