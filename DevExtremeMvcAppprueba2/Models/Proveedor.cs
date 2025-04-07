using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tienda_Online.Models
{
    public class Proveedor : Persona
    {
        private int _id;
        private int _numeroContrato;
        private DateTime fechaInicioContrato;
        private DateTime _fechaFinContrato;
        private string _tipoProveedor;

        public Proveedor()
        {
        }

        public Proveedor(int id, string nombre, string apellido, int telefono, string correo, int numeroContrato, DateTime fechaInicioContrato, DateTime fechaFinContrato, string tipoProveedor)
            : base(id, nombre, apellido, telefono, correo)
        {
            Id = id;
            NumeroContrato = numeroContrato;
            FechaInicioContrato = fechaInicioContrato;
            FechaFinContrato = fechaFinContrato;
            TipoProveedor = tipoProveedor;
        }

        public int Id { get => _id; set => _id = value; }
        public int NumeroContrato { get => _numeroContrato; set => _numeroContrato = value; }
        public DateTime FechaInicioContrato { get => fechaInicioContrato; set => fechaInicioContrato = value; }
        public DateTime FechaFinContrato { get => _fechaFinContrato; set => _fechaFinContrato = value; }
        public string TipoProveedor { get => _tipoProveedor; set => _tipoProveedor = value; }
    }
}