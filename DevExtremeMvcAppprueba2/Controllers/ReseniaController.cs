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
    /// Control de resenias
    /// </summary>
    public class ReseniaController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene una lista de resenias.
        /// </summary>
        /// <returns>Json lista de resenias</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Resenia
        public IEnumerable<Resenia> Get()
        {
            return db.Resenias;
        }

        /// <summary>
        /// Metodo para obtener una resenia por id.
        /// </summary>
        /// <returns>Json resenia</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Resenia/5
        public IHttpActionResult Get(int id)
        {
            Resenia resenia = db.Resenias.Find(id);
            if (resenia == null)
            {
                return NotFound();
            }
            return Ok(resenia);
        }

        /// <summary>
        /// Metodo para agregar una resenia.
        /// </summary>
        /// <returns>Json resenia</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Resenia
        public IHttpActionResult Post(Resenia resenia)
        {
            db.Resenias.Add(resenia);
            db.SaveChanges();
            return Ok(resenia);    
        }

        /// <summary>
        /// Metodo para modificar una resenia.
        /// </summary>
        /// <returns>Json resenia</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Resenia/5
        public IHttpActionResult Put(int id, Resenia resenia)
        {
            db.Entry(resenia).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(resenia);
        }

        /// <summary>
        /// Metodo para eliminar una resenia.
        /// </summary>
        /// <returns>Json resenia</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Resenia/5
        public IHttpActionResult Delete(int id)
        {
            Resenia resenia = db.Resenias.Find(id);
            if (resenia == null)
            {
                return NotFound();
            }
            db.Resenias.Remove(resenia);
            db.SaveChanges();
            return Ok(resenia);
        }
    }
}
