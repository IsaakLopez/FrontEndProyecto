using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tienda_Online.Models;

namespace Tienda_Online.Controllers
{
    /// <summary>
    /// Control de pedidos
    /// </summary>
    public class PedidoController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene una lista de pedidos.
        /// </summary>
        /// <returns>Json lista de pedidos</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Pedido
        public IEnumerable<Pedido> Get()
        {
            return db.Pedidos;
        }

        /// <summary>
        /// Metodo para obtener pedido por id.
        /// </summary>
        /// <returns>Json pedido</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Pedido/5
        public IHttpActionResult Get(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        /// <summary>
        /// Metodo para agregar un pedido.
        /// </summary>
        /// <returns>Json pedido</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Pedido
        public IHttpActionResult Post(Pedido pedido)
        {
            Carrito carrito = db.Carritos.Find(pedido.CarritoId);
            if (carrito == null)
            {
                return NotFound();
            }
            pedido.Carritos = carrito;
            db.Pedidos.Add(pedido);
            db.SaveChanges();
            return Ok(pedido);
        }

        /// <summary>
        /// Metodo para modifacar un pedido.
        /// </summary>
        /// <returns>Json pedido</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Pedido/5
        public IHttpActionResult Put(int id, Pedido pedido)
        {
            db.Entry(pedido).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(pedido);
        }

        /// <summary>
        /// Metodo para eliminar un pedido.
        /// </summary>
        /// <returns>Json pedido</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Pedido/5
        public IHttpActionResult Delete(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }
            db.Pedidos.Remove(pedido);
            db.SaveChanges();
            return Ok(pedido);
        }
    }
}
