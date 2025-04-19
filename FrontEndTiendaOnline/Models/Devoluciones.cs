using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndTiendaOnline.Models
{
    public class Devoluciones
    {
        private int _id;
        private int _idPedido;
        private Pedido _pedido;
        private string _motivo;

        public Devoluciones() { }
        public Devoluciones(int id, int idPedido, string motivo)
        {
            Id = id;
            IdPedido = idPedido;
            Motivo = motivo;
        }

        public int Id { get => _id; set => _id = value; }
        public int IdPedido { get => _idPedido; set => _idPedido = value; }
        public string Motivo { get => _motivo; set => _motivo = value; }
        public Pedido Pedido { get => _pedido; set => _pedido = value; }
    }
}