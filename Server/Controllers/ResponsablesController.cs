using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantillaEjemplo.Server.Data;
using PlantillaEjemplo.Shared;

namespace PlantillaEjemplo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsableController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ResponsableController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Responsable>>> GetResponsable()
        {
            var lista = await _context.Responsables.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Responsable>>> GetSingleResponsable(int id)
        {
            var miobjeto = await _context.Responsables.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Responsable>> CreateResponsable(Responsable objeto)
        {

            _context.Responsables.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbResponsable());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Responsable>>> UpdateResponsable(Responsable objeto)
        {

            var DbObjeto = await _context.Responsables.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.Nombre = objeto.Nombre;


            await _context.SaveChangesAsync();

            return Ok(await _context.Responsables.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Responsable>>> DeleteResponsable(int id)
        {
            var DbObjeto = await _context.Responsables.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Responsables.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbResponsable());
        }


        private async Task<List<Responsable>> GetDbResponsable()
        {
            return await _context.Responsables.ToListAsync();
        }
    }
}
