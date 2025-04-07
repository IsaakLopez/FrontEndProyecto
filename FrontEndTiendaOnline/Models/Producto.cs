using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndTiendaOnline.Models
{
    public class Producto
    {
        private int _id;
        private string _nombreProducto;
        private string _descripcion;
        private float _precio;
        private int _cantidadDisponible;
        private Categoria _categoria;
        private int _proveedorId;
        private int _categoriaId;
        private Proveedor _proveedor;

        public Producto() { }
        public Producto(int id, string nombreProducto, string descripcion, float precio, int cantidad, int proveedorId, int categoriaId)
        {
            Id = id;
            NombreProducto = nombreProducto;
            Descripcion = descripcion;
            Precio = precio;
            CantidadDisponible = cantidad;
            ProveedorId = proveedorId;
            CategoriaId = categoriaId;
        }

        public int Id { get => _id; set => _id = value; }
        public string NombreProducto { get => _nombreProducto; set => _nombreProducto = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public float Precio { get => _precio; set => _precio = value; }
        public int CantidadDisponible { get => _cantidadDisponible; set => _cantidadDisponible = value; }

        public int ProveedorId { get => _proveedorId; set => _proveedorId = value; } // Nueva propiedad para el ID
        public Proveedor Proveedor1 { get => _proveedor; set => _proveedor = value; }
        public int CategoriaId { get => _categoriaId; set => _categoriaId = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }
    }
}