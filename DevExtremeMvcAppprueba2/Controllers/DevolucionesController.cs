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
    /// Control de devoluciones.
    /// </summary>
    public class DevolucionesController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene una lista de devoluciones.
        /// </summary>
        /// <returns>Json devoluciones</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Devoluciones
        public IEnumerable<Devoluciones> Get()
        {
            return db.Devoluciones;
        }

        /// <summary>
        /// Metodo para obtener una devolucion por id.
        /// </summary>
        /// <returns>Json Devolucion</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Devoluciones/5
        public IHttpActionResult Get(int id)
        {
            Devoluciones devoluciones  = db.Devoluciones.Find(id);
            if (devoluciones == null) 
            {
                return NotFound();
            }
            return Ok(devoluciones);
        }

        /// <summary>
        /// Metodo para Agregar una devolucion.
        /// </summary>
        /// <returns>Json Devolucion</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Devoluciones
        public IHttpActionResult Post(Devoluciones devoluciones)
        {
            db.Devoluciones.Add(devoluciones);
            db.SaveChanges();
            return Ok(devoluciones);
        }

        /// <summary>
        /// Metodo para editar una devolucion.
        /// </summary>
        /// <returns>Json Devolucion</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Devoluciones/5
        public IHttpActionResult Put(int id, Devoluciones devoluciones)
        {
            db.Entry(devoluciones).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(devoluciones);
        }

        /// <summary>
        /// Metodo para eliminar una devolucion.
        /// </summary>
        /// <returns>Json Devolucion</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Devoluciones/5
        public IHttpActionResult Delete(int id)
        {
            Devoluciones devoluciones = db.Devoluciones.Find(id);
            if (devoluciones == null)
            {
                return NotFound();
            }
            db.Devoluciones.Remove(devoluciones);
            db.SaveChanges();
            return Ok(devoluciones);
        }
    }
}
