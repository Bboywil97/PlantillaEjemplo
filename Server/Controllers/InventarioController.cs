using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantillaEjemplo.Server.Data;
using PlantillaEjemplo.Shared;

namespace PlantillaInventario1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Inventario1Controller : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public Inventario1Controller(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Inventario1>>> GetInventario1()
        {
            var lista = await _context.Inventario.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Inventario1>>> GetSingleInventario1(int id)
        {
            var miobjeto = await _context.Inventario.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Inventario1>> CreateInventario1(Inventario1 objeto)
        {

            _context.Inventario.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbInventario1());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Inventario1>>> UpdateInventario1(Inventario1 objeto)
        {

            var DbObjeto = await _context.Inventario.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.Nombre = objeto.Nombre;


            await _context.SaveChangesAsync();

            return Ok(await _context.Inventario.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Inventario1>>> DeleteInventario1(int id)
        {
            var DbObjeto = await _context.Inventario.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Inventario.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbInventario1());
        }


        private async Task<List<Inventario1>> GetDbInventario1()
        {
            return await _context.Inventario.ToListAsync();
        }
    }
}
