using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholenessAPI.DTOs;
using WholenessAPI.Entities;

namespace WholenessAPI.Controllers
{
    [ApiController]
    [Route("api/Sucursal")]
    public class SucursalesController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public SucursalesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ActionResult<List<SucursalDTO>>> Get()
        {
            var sucursales = await context.Sucursales.ToListAsync();
            var sucursalesDTO = mapper.Map<List<SucursalDTO>>(sucursales);

            return sucursalesDTO;
        }

        [HttpGet("{id:int}", Name = "obtenerSucursal")]
        public async Task<ActionResult<List<SucursalDTO>>> Get(int id)
        {
            var sucursales = await context.Sucursales.FirstOrDefaultAsync(x => x.Id == id);

            if(sucursales == null)
            {
                return NotFound();
            }

            var sucursalesDTO = mapper.Map<List<SucursalDTO>>(sucursales);

            return sucursalesDTO;
        }



        // Para el método POST, enviamos en el cuerpo de la petición el DTO a crear que luego se mapea a la entidad propiamente dicha.        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SucursalCreacionDTO sucursalCreacionDTO)
        {
            var entidad = mapper.Map<Sucursal>(sucursalCreacionDTO);
            context.Add(entidad);
            await context.SaveChangesAsync();
            
            // Vamos a mapear ahora esta "entidad" hacia un SucursalDTO para así poder retornar este SucursalDTO en el cuerpo de la respuesta HTTP.

            var sucursalDTO = mapper.Map<SucursalDTO>(entidad);

            // Como respuesta devolvemos un CreatedAtRouteResult
            return new CreatedAtRouteResult("obtenerSucursal", new { id = sucursalDTO.Id }, sucursalDTO);
        }


        // En este método Put reutilizamos la clase SucursalCreacionDTO
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] SucursalCreacionDTO sucursalCreacionDTO)
        {
            var entidad = mapper.Map<Sucursal>(sucursalCreacionDTO);
            entidad.Id = id;

            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Sucursales.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Sucursal() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
