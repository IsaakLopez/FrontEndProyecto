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
    /// Control de envios.
    /// </summary>
    public class EnvioController : ApiController
    {
        private DbContextProject db = new DbContextProject();
        
        /// <summary>
        /// Obtiene una lista de envios.
        /// </summary>
        /// <returns>Json lista de envios</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Envio
        public IEnumerable<Envio> Get()
        {
            return db.Envios;
        }

        /// <summary>
        /// Metodo para obtener envio por id.
        /// </summary>
        /// <returns>Json envio</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Envio/5
        public IHttpActionResult Get(int id)
        {
            Envio envio = db.Envios.Find(id);
            if (envio == null) 
            {
                return NotFound();  
            }
            return Ok(envio);
        }


        /// <summary>
        /// Metodo para agregar un envio.
        /// </summary>
        /// <returns>Json envio</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Envio
        public IHttpActionResult Post(Envio envio)
        {
            db.Envios.Add(envio);
            db.SaveChanges();
            return Ok(envio);
        }


        /// <summary>
        /// Metodo para modificar un envio
        /// </summary>
        /// <returns>Json envios</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Envio/5
        public IHttpActionResult Put(int id, Envio envio)
        {
            db.Entry(envio).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(envio);
        }


        /// <summary>
        /// Metodo para borrar un envio.
        /// </summary>
        /// <returns>Json envio</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Envio/5
        public IHttpActionResult Delete(int id)
        {
            Envio envio = db.Envios.Find(id);
            if (envio == null) 
            {
                return NotFound();
            }
            db.Envios.Remove(envio);
            db.SaveChanges();
            return Ok(envio);
        }
    }
}
