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
    /// Control de categorias
    /// </summary>
    public class CategoriaController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene lista de CAtegorias.
        /// </summary>
        /// <returns>Json lista de Categorias</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Categoria
        public IEnumerable<Categoria> Get()
        {
            return db.Categorias;
        }


        /// <summary>
        /// Metodo para obtener categoria por id.
        /// </summary>
        /// <returns>Json Categoria</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Categoria/5
        public IHttpActionResult Get(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        /// <summary>
        /// Metodo para agregar Categorias.
        /// </summary>
        /// <returns>Json Categoria</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Categoria
        public IHttpActionResult Post(Categoria newcategoria)
        {
            db.Categorias.Add(newcategoria);
            db.SaveChanges();
            return Ok(newcategoria);
        }

        /// <summary>
        /// Metodo para modificar una categoria.
        /// </summary>
        /// <returns>Json Categoria</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Categoria/5
        public IHttpActionResult Put(int id, Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(categoria);
        }

        /// <summary>
        /// Metodo para eliminar una categoria.
        /// </summary>
        /// <returns>Json Categoria</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Categoria/5
        public IHttpActionResult Delete(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null) 
            {
                return NotFound();
            }
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return Ok(categoria);    
        }
    }
}
