using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public abstract class Usuario : Persona
    {
        private int _id;
        private string _contrasena;
        private DateTime _fechaRegistro;

        public Usuario()
        {
        }

        public Usuario(int id, string nombre, string apellido, int telefono, string correo, string contrasena, DateTime fechaRegistro) : base(id, nombre, apellido, telefono, correo)
        {
            Id = id;
            Contrasena = contrasena;
            FechaRegistro = fechaRegistro;
        }

        public int Id { get => _id; set => _id = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public DateTime FechaRegistro { get => _fechaRegistro; set => _fechaRegistro = value; }
    }
}