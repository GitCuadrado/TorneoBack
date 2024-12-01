using CopaAnalAPI.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace CopaAnalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class API : ControllerBase
    {
        private DataService _dataSvc;
        public API(DataService dataSvc) {
            this._dataSvc = dataSvc;
        }
        [HttpGet("grupos/{usuario}")]
        public async Task<JsonResult> grupos(string usuario)
        {
            return new JsonResult(await _dataSvc.getGrupos(usuario));
        }
        [HttpGet("ranking")]
        public async Task<JsonResult> ranking()
        {
            return new JsonResult(await _dataSvc.getRanking());
        }
        [HttpGet("premios")]
        public async Task<JsonResult> premios()
        {
            return new JsonResult(await _dataSvc.getPremios());
        }
        [HttpGet("predicciones")]
        public JsonResult predicciones()
        {
            return new JsonResult(_dataSvc.getPredicciones());
        }
        [HttpGet("actualizarPrediccion/{usuario}/{idGrupo}/{idOpcion}")]
        public async Task<JsonResult> usuario(string usuario,string idGrupo,string idOpcion)
        {
            return new JsonResult(await _dataSvc.ActualizarPrediccion(usuario,idGrupo,idOpcion));
        }
        [HttpGet("usuario/{usuario}")]
        public JsonResult usuario(string usuario)
        {
            return new JsonResult(_dataSvc.GetUsuario(""));
        }
    }
}
