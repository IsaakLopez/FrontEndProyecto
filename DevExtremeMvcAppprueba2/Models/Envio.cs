using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public class Envio
    {
        private int _id;
        private Pago _pago;
        private Pedido _pedido;
        private DateTime _fechaEnvio;
        private DateTime _fechaEntregaEstimada;
        private string _estado;

        public Envio()
        {
        }

        public Envio(int id, Pago pago, Pedido pedido, DateTime fechaEnvio, DateTime fechaEntregaEstimada, string estado)
        {
            Id = id;
            FechaEnvio = fechaEnvio;
            FechaEntregaEstimada = fechaEntregaEstimada;
            Estado = estado;
            Pago = pago;
            Pedido = pedido;
        }

        public int Id { get => _id; set => _id = value; }
        public DateTime FechaEnvio { get => _fechaEnvio; set => _fechaEnvio = value; }
        public DateTime FechaEntregaEstimada { get => _fechaEntregaEstimada; set => _fechaEntregaEstimada = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public Pago Pago { get => _pago; set => _pago = value; }
        public Pedido Pedido { get => _pedido; set => _pedido = value; }
    }
}