using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndTiendaOnline.Models
{
    public class Pago
    {
        private int _id;
        private int _idPedido;
        private Pedido _pedido;
        private int _idMetodo;
        private MetodoPago _metodoPago;
        private double _totalpagar;
        private DateTime _fechaPago;

        public Pago() { }

        public Pago(int id, DateTime fechaPago, int idpedido, int idmetodo, double totalpagar)
        {
            Id = id;
            IdMetodo = idmetodo;
            FechaPago = fechaPago;
            IdPedido = idpedido;
            Totalpagar = totalpagar;
        }

        public int Id { get => _id; set => _id = value; }
        public MetodoPago MetodoPago { get => _metodoPago; set => _metodoPago = value; }
        public DateTime FechaPago { get => _fechaPago; set => _fechaPago = value; }
        public Pedido Pedido { get => _pedido; set => _pedido = value; }
        public int IdPedido { get => _idPedido; set => _idPedido = value; }
        public int IdMetodo { get => _idMetodo; set => _idMetodo = value; }
        public double Totalpagar { get => _totalpagar; set => _totalpagar = value; }
    }
}