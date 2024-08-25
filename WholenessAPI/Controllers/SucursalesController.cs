using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholenessAPI.DTOs;

namespace WholenessAPI.Controllers
{
    [ApiController]
    [Route("api/Sucursal")]
    public class SucursalesController
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
    }
}
