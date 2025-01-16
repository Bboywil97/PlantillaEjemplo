﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantillaEjemplo.Server.Data;
using PlantillaEjemplo.Shared;

namespace PlantillaEjemplo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdscripcionController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public AdscripcionController(ApplicationDbContext context)
        {

            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Adscripcion>>> GetAdscripcion()
        {
            var lista = await _context.Adscripciones.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Adscripcion>>> GetSingleAdscripcion(int id)
        {
            var miobjeto = await _context.Adscripciones.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }
        [HttpPost]

        public async Task<ActionResult<Adscripcion>> CreateAdscripcion(Adscripcion objeto)
        {

            _context.Adscripciones.Add(objeto);
            await _context.SaveChangesAsync();
            return Ok(await GetDbAdscripcion());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Adscripcion>>> UpdateAdscripcion(Adscripcion objeto)
        {

            var DbObjeto = await _context.Adscripciones.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            DbObjeto.Nombre = objeto.Nombre;


            await _context.SaveChangesAsync();

            return Ok(await _context.Adscripciones.ToListAsync());


        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Adscripcion>>> DeleteAdscripcion(int id)
        {
            var DbObjeto = await _context.Adscripciones.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            _context.Adscripciones.Remove(DbObjeto);
            await _context.SaveChangesAsync();

            return Ok(await GetDbAdscripcion());
        }


        private async Task<List<Adscripcion>> GetDbAdscripcion()
        {
            return await _context.Adscripciones.ToListAsync();
        }
    }
}