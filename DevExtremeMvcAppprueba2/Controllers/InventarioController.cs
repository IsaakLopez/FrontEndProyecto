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
    /// control para inventario.
    /// </summary>

    public class InventarioController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene una lista de inventarios.
        /// </summary>
        /// <returns>Json lista de invetario</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Inventario
        public IEnumerable<Inventario> Get()
        {
            return db.Inventarios;
        }

        /// <summary>
        /// metodo para obtener un inventario por id.
        /// </summary>
        /// <returns>Json inventario</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Inventario/5
        public IHttpActionResult Get(int id)
        {
            Inventario inventario = db.Inventarios.Find(id);
            if (inventario == null) 
            { 
                return NotFound();
            }
            return Ok(inventario);
        }

        /// <summary>
        /// metodo para agregar un inventario.
        /// </summary>
        /// <returns>Json inventario</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Inventario
        public IHttpActionResult Post(Inventario inventario)
        {
            db.Inventarios.Add(inventario);
            db.SaveChanges();
            return Ok(inventario);
        }

        /// <summary>
        /// Ometodo para modificar un invntario.
        /// </summary>
        /// <returns>Json inventario</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Inventario/5
        public IHttpActionResult Put( int id, Inventario inventario)
        { 
           db.Entry(inventario).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(inventario);
        }

        /// <summary>
        /// metodo para borrar un inventario.
        /// </summary>
        /// <returns>Json inventario</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Inventario/5
        public IHttpActionResult Delete(int id)
        {
            Inventario inventario =db.Inventarios.Find(id);
            if (inventario == null) 
            {
                return NotFound();
            }
            db.Inventarios.Remove(inventario);
            db.SaveChanges();
            return Ok(inventario);
        }
    }
}
