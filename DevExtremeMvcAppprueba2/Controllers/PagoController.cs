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
    /// Control de pagos
    /// </summary>
    public class PagoController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene una lista de pagos.
        /// </summary>
        /// <returns>Json lista de pagos</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Pago
        public IEnumerable<Pago> Get()
        {
            return db.Pagos;
        }

        /// <summary>
        /// Metodo para obtener un pago por id.
        /// </summary>
        /// <returns>Json pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Pago/5
        public IHttpActionResult Get(int id)
        {
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return NotFound();
            }
            return Ok(pago);
        }

        /// <summary>
        /// Metodo para agregar pago.
        /// </summary>
        /// <returns>Json pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Pago
        public IHttpActionResult Post(Pago pago)
        {
            db.Pagos.Add(pago);
            db.SaveChanges();
            return Ok(pago);
        }

        /// <summary>
        /// Metodo para modificar un pago.
        /// </summary>
        /// <returns>Json pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Pago/5
        public IHttpActionResult Put(int id, Pago pago)
        {
            db.Entry(pago).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(pago);

        }

        /// <summary>
        /// Metodo para eliminar un pago
        /// </summary>
        /// <returns>Json pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Pago/5
        public IHttpActionResult Delete(int id)
        {
            Pago pago = db.Pagos.Find(id);
            if (pago == null)
            {
                return NotFound();
            }
            db.Pagos.Remove(pago);
            db.SaveChanges();
            return Ok(pago);
        }
    }
}
