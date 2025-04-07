using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public class Pago
    {
        private int _id;
        private Pedido _pedido;
        private MetodoPago _metodoPago;
        private DateTime _fechaPago;

        public Pago()
        {

        }

        public Pago(int id, DateTime fechaPago, Pedido pedido, MetodoPago metodoPago)
        {
            Id = id;
            MetodoPago = metodoPago;
            FechaPago = fechaPago;
            Pedido = pedido;
        }

        public int Id { get => _id; set => _id = value; }
        public MetodoPago MetodoPago { get => _metodoPago; set => _metodoPago = value; }
        public DateTime FechaPago { get => _fechaPago; set => _fechaPago = value; }
        public Pedido Pedido { get => _pedido; set => _pedido = value; }

    }
}