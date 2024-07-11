using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuaoriosControllers : ControllerBase
    {
        //GET: api/Usuarios
        [HttpGet]
        public string RequererUsuarios() {
            return "Lista de usuários";
        }
    }
}
