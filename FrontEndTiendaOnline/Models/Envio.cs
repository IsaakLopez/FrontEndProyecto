﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace FrontEndTiendaOnline.Models
{
    public class Envio
    {
        private int _id;
        private int _idPago;
        private Pago _pago;
        private int _idPedido;
        private Pedido _pedido;
        private DateTime _fechaEnvio;
        private DateTime _fechaEntregaEstimada;
        private string _estado;

        public Envio() { }

        public Envio(int id, int idpago, int idpedido, DateTime fechaEnvio, DateTime fechaEntregaEstimada, string estado)
        {
            Id = id;
            FechaEnvio = fechaEnvio;
            FechaEntregaEstimada = fechaEntregaEstimada;
            Estado = estado;
            Idpago = idpago;
            Idpedido = idpedido;
        }

        public int Id { get => _id; set => _id = value; }
        public DateTime FechaEnvio { get => _fechaEnvio; set => _fechaEnvio = value; }
        public DateTime FechaEntregaEstimada { get => _fechaEntregaEstimada; set => _fechaEntregaEstimada = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public int Idpago { get => _idPago; set => _idPago = value; }
        public int Idpedido { get => _idPedido; set => _idPedido = value; }
        public Pago Pago { get => _pago; set => _pago = value; }
        public Pedido Pedido { get => _pedido; set => _pedido = value; }
    }
}