using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public class Administrador : Usuario
    {
        private int _id;
        private string _rol;

        public Administrador()
        {
        }

        public Administrador(int id, string rol, string nombre, string apellido, int telefono, string correo, string contrasena, DateTime fechaRegistro) : base(id, nombre, apellido, telefono, correo, contrasena, fechaRegistro)
        {
            Id = id;
            Rol = rol;
        }

        public int Id { get => _id; set => _id = value; }
        public string Rol { get => _rol; set => _rol = value; }
    }
}