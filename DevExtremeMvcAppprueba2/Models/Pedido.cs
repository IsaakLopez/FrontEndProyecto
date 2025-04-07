using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public class Pedido
    {
        private int _id;
        private Carrito _carrito;
        private int _carritoId;
        private float _total;

        public Pedido()
        {
        }

        public Pedido(int id, int carritoId, float total)
        {
            Id = id;
            Total = total;
            CarritoId = carritoId;
        }

        public int Id { get => _id; set => _id = value; }
        public float Total { get => _total; set => _total = value; }
        public Carrito Carritos { get => _carrito; set => _carrito = value; }
        public int CarritoId { get => _carritoId; set => _carritoId = value; }
    }
}