using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantillaEjemplo.Server.Data;
using PlantillaEjemplo.Shared;

namespace PlantillaArticulo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Articulos>>> GetArticulo()
        {
            var lista = await _context.Articulos.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Articulos>> GetSingleArticulo(int id)
        {
            var miobjeto = await _context.Articulos.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost]
        public async Task<ActionResult<List<Articulos>>> CreateArticulo(Articulos objeto)
        {
            _context.Articulos.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbArticulo());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Articulos>>> UpdateArticulo(int id, Articulos objeto)
        {
            var DbObjeto = await _context.Articulos.FindAsync(id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");

            DbObjeto.Nombre = objeto.Nombre;
            await _context.SaveChangesAsync();

            return Ok(await _context.Articulos.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Articulos>>> DeleteArticulo(int id)
        {
            var DbObjeto = await _context.Articulos.FirstOrDefaultAsync(ob => ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Articulos.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbArticulo());
        }

        private async Task<List<Articulos>> GetDbArticulo()
        {
            return await _context.Articulos.ToListAsync();
        }
    }
}

