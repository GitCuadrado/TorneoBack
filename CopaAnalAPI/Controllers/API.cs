using CopaAnalAPI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CopaAnalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class API : ControllerBase
    {
        [HttpGet("grupos/{usuario}")]
        public async Task<JsonResult> grupos(string usuario)
        {
            var ds = new DataService();
            return new JsonResult(await ds.getGrupos(usuario));
        }
        [HttpGet("predicciones")]
        public JsonResult predicciones()
        {
            var ds = new DataService();
            return new JsonResult(ds.getPredicciones());
        }
        [HttpGet("actualizarPrediccion/{usuario}/{idGrupo}/{idOpcion}")]
        public async Task<JsonResult> usuario(string usuario,string idGrupo,string idOpcion)
        {
            var ds = new DataService();
            return new JsonResult(await ds.ActualizarPrediccion(usuario,idGrupo,idOpcion));
        }
        [HttpGet("usuario/{usuario}")]
        public JsonResult usuario(string usuario)
        {
            var ds = new DataService();
            return new JsonResult(ds.GetUsuario(""));
        }
    }
}
