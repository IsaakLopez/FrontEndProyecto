using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using Swashbuckle.Swagger.Annotations;
using Tienda_Online.Models;

namespace Tienda_Online.Controllers
{
    /// <summary>
    /// Clase que administra los clientes.
    /// </summary>
    public class ClienteController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene una lista de clientes.
        /// </summary>
        /// <returns>Json Cliente</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Cliente
        public IEnumerable<Cliente> Get()
        {
            return db.Clientes;
        }


        /// <summary>
        /// Metodo para obtener cliente por id.
        /// </summary>
        /// <returns>Json cliente</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Cliente/5
        public IHttpActionResult Get(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }


        /// <summary>
        /// Metodo para obtener antiguedad de clientes.
        /// </summary>
        /// <returns>Json lista de clientes</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/getAntiguedadClientes
        [HttpGet]
        [SwaggerOperation("getAntiguedadClientes")]
        [Route("api/getAntiguedadClientes")]
        public IHttpActionResult getAntiguedadClientes()
        {
            var query = from cliente in db.Clientes
                        where cliente.FechaRegistro != null
                        orderby cliente.FechaRegistro
                        select new 
                        {
                            NombreCompleto = cliente.Nombre + " " + cliente.Apellido,
                            cliente.Telefono,
                            cliente.Correo,
                            cliente.Pais,
                            cliente.FechaRegistro,
                            Antiguedad = DbFunctions.DiffDays(cliente.FechaRegistro, DateTime.Now),
                        };
            return Ok(query);
        }

        /// <summary>
        /// Metodo para obtener clientes freceuntes.
        /// </summary>
        /// <returns>Json lista de clientes</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/getClientesfrecuentes
        [HttpGet]
        [SwaggerOperation("getClientesfrecuentes")]
        [Route("api/getClientesfrecuentes")]
        public IHttpActionResult getClientesfrecuentes()
        {
            var query = from cliente in db.Clientes
                        join pedido in db.Pedidos
                        on cliente.Id equals pedido.Carritos.Cliente.Id
                        group cliente by cliente.Id into grupoClientes
                        where grupoClientes.Count() >= 1
                        select new
                        {
                            ClienteId = grupoClientes.Key,
                            nombreCliente = grupoClientes.FirstOrDefault(),
                            TotalPedido = grupoClientes.Count(),
                        };
                       
            return Ok(query);
        }

        /// <summary>
        /// Metodo para obtener clientes por pais.
        /// </summary>
        /// <returns>Json lista de clientes</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/getClientesPorPais
        [HttpGet]
        [SwaggerOperation("getClientesPorPais")]
        [Route("api/getClientesPorPais")]
        public IHttpActionResult getClientesPorPais()
        {
            var query = from cliente in db.Clientes
                        group cliente by cliente.Pais into grupoClientes
                        select new
                        {
                            Pais = grupoClientes.Key,
                            Clientes = grupoClientes.ToList(),
                        };

            return Ok(query);
        }



        /// <summary>
        /// Metodo para agregar un cliente.
        /// </summary>
        /// <returns>Json cliente</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Cliente
        public IHttpActionResult Post(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();
            return Ok(cliente);

        }

        /// <summary>
        /// Metodo para modificar un cliente.
        /// </summary>
        /// <returns>Json cliente</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Cliente/5
        public IHttpActionResult Put(int id, Cliente cliente)
        {
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(cliente);
        }

        /// <summary>
        /// Metodo para eliminar un cliente.
        /// </summary>
        /// <returns>Json cliente</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Cliente/5
        public IHttpActionResult Delete(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return Ok(cliente);
        }
    }
}
