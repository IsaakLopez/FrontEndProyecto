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
    /// Control de proveedores
    /// </summary>
    public class ProveedorController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene una lista de proveedores.
        /// </summary>
        /// <returns>Json lista de proveedores</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Proveedor
        public IEnumerable<Proveedor> Get()
        {
            return db.Proveedores;
        }

        /// <summary>
        /// Metodo para obtener un proveedor por id.
        /// </summary>
        /// <returns>Json proveedor</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Proveedor/5
        public IHttpActionResult Get(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        /// <summary>
        /// Metodo para agregar un proveedor.
        /// </summary>
        /// <returns>Json proveedor</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Proveedor
        public IHttpActionResult Post(Proveedor proveedor)
        {
            db.Proveedores.Add(proveedor);
            db.SaveChanges();
            return Ok(proveedor);
        }

        /// <summary>
        /// Metodo para modifacar un proveedor.
        /// </summary>
        /// <returns>Json proveedor</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Proveedor/5
        public IHttpActionResult Put(int id, Proveedor proveedor)
        {
            db.Entry(proveedor).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(proveedor);
        }

        /// <summary>
        /// Metodo para eliminar un proveedor.
        /// </summary>
        /// <returns>Json proveedor</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Proveedor/5
        public IHttpActionResult Delete(int id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {  
                return NotFound(); 
            }
            db.Proveedores.Remove(proveedor);
            db.SaveChanges();
            return Ok(proveedor);
        }
    }
}
