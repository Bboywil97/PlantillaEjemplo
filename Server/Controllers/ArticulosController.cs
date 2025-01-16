using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantillaEjemplo.Server.Data;
using PlantillaEjemplo.Shared;
namespace PlantillaArticulo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ArticuloController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Articulo>>> GetArticulo()
        {
            var lista = await _context.Articulos.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Articulo>>> GetSingleArticulo(int id)
        {
            var miobjeto = await _context.Articulos.FirstOrDefaultAsync((System.Linq.Expressions.Expression<Func<Articulo, bool>>)(ob => ob.Id == id));
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Articulo>> CreateArticulo(Articulo objeto)
        {

            _context.Articulos.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbArticulo());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Articulo>>> UpdateArticulo(Articulo objeto)
        {

            var DbObjeto = await _context.Articulos.FindAsync((object)objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.Nombre = objeto.Nombre;


            await _context.SaveChangesAsync();

            return Ok(await _context.Articulos.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Articulo>>> DeleteArticulo(int id)
        {
            var DbObjeto = await _context.Articulos.FirstOrDefaultAsync((System.Linq.Expressions.Expression<Func<Articulo, bool>>)(Ob => Ob.Id == id));
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Articulos.Remove((Articulo)DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbArticulo());
        }


        private async Task<List<Articulo>> GetDbArticulo()
        {
            return await _context.Articulos.ToListAsync();
        }
    }
}
