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
    /// Control de administradores
    /// </summary>
    public class AdminController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene lista administradores.
        /// </summary>
        /// <returns>Json lista de Administradores</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET api/values
        public IEnumerable<Administrador> Get()
        {
            return db.Administradores;
        }

        /// <summary>
        /// Metodo para obtener administrador por id.
        /// </summary>
        /// <returns>Json Administrador</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null) 
            {
                return NotFound();
            }
            return Ok(administrador);
        }


        /// <summary>
        /// Metodo para agregar un administrador.
        /// </summary>
        /// <returns>Json Administrador</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST api/values
        public IHttpActionResult Post(Administrador newAdministrador)
        {
            db.Administradores.Add(newAdministrador);
            db.SaveChanges();
            return Ok(newAdministrador);
        }


        /// <summary>
        /// Metodo para modificar un administrador.
        /// </summary>
        /// <returns>Json administrador</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT api/values/5
        public IHttpActionResult Put(int id, Administrador administrador)
        {
            db.Entry(administrador).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(administrador);
        }

        /// <summary>
        /// Metodo para eliminar un administrador.
        /// </summary>
        /// <returns>Json administrador</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null) 
            {
                return NotFound();
            }
            db.Administradores.Remove(administrador);
            db.SaveChanges();
            return Ok(administrador);
        }
    }
}
