using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public abstract class Persona
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _correo;
        private int _telefono;

        public Persona()
        {

        }

        public Persona(int id, string nombre, string apellido, int telefono, string correo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public int Telefono { get => _telefono; set => _telefono = value; }

        public string Correo { get => _correo; set => _correo = value; }
    }
}