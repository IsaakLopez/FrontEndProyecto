using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndTiendaOnline.Models
{
    public class Resenia
    {
        private int _id;
        private Cliente _cliente;
        private string _info;

        public Resenia(int id, Cliente cliente, string info)
        {
            Id = id;
            Cliente = cliente;
            Info = info;
        }

        public int Id { get => _id; set => _id = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public string Info { get => _info; set => _info = value; }
    }
}