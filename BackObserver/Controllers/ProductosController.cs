using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControllerObserver.Entidades;
using BackObserver.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Data;

namespace BackObserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductos(int id)
        {
            var producto=await _context.Productos.FindAsync(id);
            if(producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Productos>> PostProductos(Productos productos)
        {
            _context.Productos.Add(productos);
            await _context.SaveChangesAsync();
            return Ok(productos);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Productos>> PutProductos(int id, Productos productos)
        {
            if (id != productos.ProductoID)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }catch(DBConcurrencyException)
            {
                if(!Verificarexistencia(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProvedores(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if(producto==null)
            {
                return NotFound();
            }

            _context.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool Verificarexistencia(int id)
        {
            return _context.Productos.Any(e => e.ProductoID == id);
        }


    }
}
