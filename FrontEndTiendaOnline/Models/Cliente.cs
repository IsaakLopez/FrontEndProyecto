using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndTiendaOnline.Models
{
    public class Cliente : Usuario
    {
        private int _id;
        private string _pais;
        private string _direccionExacta;
        private string _ciudad;
        private int _codigoPostal;

        public Cliente()
        {
        }
        public Cliente(int id, string nombre, string apellido, int telefono, string correo, string contrasena, DateTime fechaRegistro, string pais, string direccionExacta, string ciudad, int codigoPostal)
            : base(id, nombre, apellido, telefono, correo, contrasena, fechaRegistro)
        {
            Id = id;
            Pais = pais;
            DireccionExacta = direccionExacta;
            Ciudad = ciudad;
            CodigoPostal = codigoPostal;
        }

        public int Id { get => _id; set => _id = value; }
        public string Pais { get => _pais; set => _pais = value; }
        public string DireccionExacta { get => _direccionExacta; set => _direccionExacta = value; }
        public string Ciudad { get => _ciudad; set => _ciudad = value; }
        public int CodigoPostal { get => _codigoPostal; set => _codigoPostal = value; }
    }
}