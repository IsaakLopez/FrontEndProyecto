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
    /// control de metodos de pago.
    /// </summary>
    public class MetodoPagoController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene una lista de metodos de pago.
        /// </summary>
        /// <returns>Json lista de metodos pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/MetodoPago
        public IEnumerable<MetodoPago> Get()
        {
            return db.MetodosPago;
        }

        /// <summary>
        /// metodo para obtener un metodo de pago por id.
        /// </summary>
        /// <returns>Json metodo pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/MetodoPago/5
        public IHttpActionResult Get(int id)
        {
            MetodoPago metodopago = db.MetodosPago.Find(id);
            if (metodopago == null) 
            {
                return NotFound();
            }
            return Ok(metodopago);

        }

        /// <summary>
        /// metodo para agregar un metodo de pago.
        /// </summary>
        /// <returns>Json metodo pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/MetodoPago
        public IHttpActionResult Post(MetodoPago metodopago)
        {
            db.MetodosPago.Add(metodopago);
            db.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// metodo para modificar un metodo de pago.
        /// </summary>
        /// <returns>Json metodo pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/MetodoPago/5
        public IHttpActionResult Put(int id, MetodoPago metodopago)
        {
            db.Entry(metodopago).State = EntityState.Modified;
            db.SaveChanges();   
            return Ok(metodopago);
        }

        /// <summary>
        /// metodo para borrar un metodo de pago.
        /// </summary>
        /// <returns>Json metodo pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/MetodoPago/5
        public IHttpActionResult Delete(int id)
        {
            MetodoPago metodopago = db.MetodosPago.Find(id);
            if (metodopago == null) 
            {
                return NotFound();
            }
            db.MetodosPago.Remove(metodopago);
            db.SaveChanges();
            return Ok(metodopago);

        }
    }
}
