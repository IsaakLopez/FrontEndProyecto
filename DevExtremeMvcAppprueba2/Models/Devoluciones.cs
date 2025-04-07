using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public class Devoluciones
    {
        private int _id;
        private Pedido _pedido;
        private int _idProducto;
        private int _cantidad;
        private string _motivo;

        public Devoluciones(int id, Pedido pedido, int idProducto, int cantidad, string motivo)
        {
            Id = id;
            Pedido = pedido;
            IdProducto = idProducto;
            Cantidad = cantidad;
            Motivo = motivo;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Motivo { get => _motivo; set => _motivo = value; }
        public Pedido Pedido { get => _pedido; set => _pedido = value; }
    }
}