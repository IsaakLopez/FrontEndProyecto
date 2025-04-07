using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using Tienda_Online.Models;

namespace Tienda_Online.Controllers
{
    /// <summary>
    /// Control de productos
    /// </summary>
    public class ProductoController : ApiController
    {
        private DbContextProject db = new DbContextProject();

        /// <summary>
        /// Obtiene lista de productos.
        /// </summary>
        /// <returns>Json lista de productos</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Producto
        public IHttpActionResult Get()
        {
            var productos = from producto in db.Productos
                            select new
                            {
                                producto.Id,
                                producto.NombreProducto,
                                producto.Descripcion,
                                producto.Precio,
                                producto.CantidadDisponible,
                                categoria = producto.Categoria.Nombre,
                                proveedor = producto.Proveedor1.Nombre + " " + producto.Proveedor1.Apellido
                            };
            return Ok(productos);
        }

        /// <summary>
        /// Metodo para obtener producto por id.
        /// </summary>
        /// <returns>Json producto</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/Producto/5
        public IHttpActionResult Get(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        /// <summary>
        /// Metodo para obtener productos por proveedor.
        /// </summary>
        /// <returns>Json lista de productos</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/getProductosPorProveedor
        [HttpGet]
        [SwaggerOperation("getProductosPorProveedor")]
        [Route("api/getProductosPorProveedor")]
        public IHttpActionResult getProductosPorProveedor(int Id)
        {
            var query = from proveedor in db.Proveedores
                        join producto in db.Productos
                        on proveedor.Id equals producto.ProveedorId
                        where proveedor.Id == Id
                        select new
                        {
                            proveedor.Id,
                            proveedor.Nombre,
                            proveedor.TipoProveedor,
                            proveedor.Telefono,
                            producto.NombreProducto,
                            producto.Descripcion,
                            producto.CantidadDisponible,
                            producto.Precio,
                        };
            return Ok(query);
        }

        /// <summary>
        /// Metodo para obtener productos con poca existencia.
        /// </summary>
        /// <returns>Json lista de productos</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/getProductosPocaExistencia
        [HttpGet]
        [SwaggerOperation("getProductosPocaExistencia")]
        [Route("api/getProductosPocaExistencia")]
        public IHttpActionResult getProductosPocaExistencia()
        {
            var query = from proveedor in db.Proveedores
                        join producto in db.Productos
                        on proveedor.Id equals producto.ProveedorId
                        where producto.CantidadDisponible <= 20
                        select new
                        {
                            IdProducto = producto.Id,
                            producto.NombreProducto,
                            DescripcionProducto = producto.Descripcion,
                            producto.Precio,
                            producto.CantidadDisponible,
                            Categoria = producto.Categoria.Nombre,
                            ProveedorId = proveedor.Id,
                            ProveedorNombre = proveedor.Nombre,
                            ProveedorTelefono = proveedor.Telefono,
                        };
            return Ok(query);
        }

        /// <summary>
        /// Metodo para obtener productos agotados.
        /// </summary>
        /// <returns>Json lista de productos</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/getProductosAgotados
        [HttpGet]
        [SwaggerOperation("getProductosAgotados")]
        [Route("api/getProductosAgotados")]
        public IHttpActionResult getProductosAgotados()
        {
            var query = from proveedor in db.Proveedores
                        join producto in db.Productos
                        on proveedor.Id equals producto.ProveedorId
                        where producto.CantidadDisponible == 0
                        select new
                        {
                            IdProducto = producto.Id,
                            producto.NombreProducto,
                            DescripcionProducto = producto.Descripcion,
                            producto.Precio,
                            producto.CantidadDisponible,
                            Categoria = producto.Categoria.Nombre,
                            ProveedorId = proveedor.Id,
                            ProveedorNombre = proveedor.Nombre,
                            ProveedorTelefono = proveedor.Telefono,
                        };
            return Ok(query);
        }

        /// <summary>
        /// Metodo para obtener productos por rango de precios.
        /// </summary>
        /// <returns>Json lista de productos</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // GET: api/getProductosAgotados
        [HttpGet]
        [SwaggerOperation("getProductosRangoPrecios")]
        [Route("api/getProductosRangoPrecios")]
        public IHttpActionResult getProductosRangoPrecios(float min, float max)
        {
            var query = from proveedor in db.Proveedores
                        join producto in db.Productos
                        on proveedor.Id equals producto.ProveedorId
                        where producto.Precio >= min && producto.Precio<= max
                        select new
                        {
                            IdProducto = producto.Id,
                            producto.NombreProducto,
                            DescripcionProducto = producto.Descripcion,
                            producto.CantidadDisponible,
                            producto.Precio,
                            Categoria = producto.Categoria.Nombre,
                            ProveedorNombre = proveedor.Nombre,
                        };
            return Ok(query);
        }


        /// <summary>
        /// Metodo para agregar un producto.
        /// </summary>
        /// <returns>Json pago</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // POST: api/Producto
        public IHttpActionResult Post(Producto producto)
        {
            var proveedorExistente = db.Proveedores.Find(producto.ProveedorId);

            if (proveedorExistente == null)
            {
                return BadRequest("El proveedor no existe.");
            }

            var categoriaexistente = db.Categorias.Find(producto.CategoriaId);
            if (categoriaexistente == null) 
            {
                return BadRequest("La categoria no existe");
            }

            producto.Proveedor1 = proveedorExistente;
            producto.Categoria = categoriaexistente;
            db.Productos.Add(producto);
            db.SaveChanges();

            return Ok(producto);
        }

        /// <summary>
        /// Metodo para modifacar un producto.
        /// </summary>
        /// <returns>Json producto</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // PUT: api/Producto/5
        public IHttpActionResult Put(int id, Producto producto)
        {

            db.Entry(producto).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(producto);
        }

        /// <summary>
        /// Metodo para eliminar un producto.
        /// </summary>
        /// <returns>Json producto</returns>
        /// <response code="200">Devuelve el valor encontrado</response>
        /// <response code="404">Si el valor no es encontrado</response>
        // DELETE: api/Producto/5
        public IHttpActionResult Delete(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            db.Productos.Remove(producto);
            db.SaveChanges();
            return Ok(producto);
        }
    }
}
