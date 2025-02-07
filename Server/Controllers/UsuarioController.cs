﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantillaEjemplo.Shared;
using PlantillaEjemplo.Server.Data;


namespace PlantillaEjemplo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuario()
        {
            var lista = await _context.Usuarios.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Usuario>>> GetSingleUsuario(int id)
        {
            var miobjeto = await _context.Usuarios.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario objeto)
        {

            _context.Usuarios.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbUsuario());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Usuario>>> UpdateUsuario(Usuario objeto)
        {

            var DbObjeto = await _context.Usuarios.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.Name = objeto.Name;


            await _context.SaveChangesAsync();

            return Ok(await _context.Usuarios.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Usuario>>> DeleteUsuario(int id)
        {
            var DbObjeto = await _context.Usuarios.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Usuarios.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbUsuario());
        }


        private async Task<List<Usuario>> GetDbUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
