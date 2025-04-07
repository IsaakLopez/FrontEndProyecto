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
    public class CarritoController : ApiController
    {
        private DbContextProject db = new DbContextProject();
        /// <summary>
        /// Obtiene lista de carritos.
        /// </summary>
        /// <returns>Json lista de Carritos</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Carrito
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// carrito por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Carrito/5
        public IHttpActionResult Get(int id)
        {
            Carrito carrito = db.Carritos.Find(id);
            if (carrito == null)
            {
                return NotFound();
            }
            return Ok(carrito);
        }

        // POST: api/Carrito
        public IHttpActionResult Post(Carrito carrito, int productoId)
        {
            Producto newp = db.Productos.Find(productoId);
            if (newp == null) 
            {
                return NotFound();
            }
            newp.CantidadDisponible = carrito.Cantidad;
            carrito.Productos.Add(newp);


            if (db.Carritos.Find(carrito.Id) == null)
            {
                db.Carritos.Add(carrito);
                db.SaveChanges();
                return Ok(carrito);
            }
            else {

                db.Entry(carrito).State = EntityState.Modified;
                db.SaveChanges();
                return Ok(carrito);
            }

            
        }

        // PUT: api/Carrito/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Carrito/5
        public void Delete(int id)
        {
        }
    }
}
