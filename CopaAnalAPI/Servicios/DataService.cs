using CopaAnalAPI.Entidades;
using CopaAnalAPI.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace CopaAnalAPI.Servicios
{
    public class DataService : ExecuteDataSet
    {
        private string _cnnString;
        //-------------DATA PRUEBA-------------

        //-------------FIN DATA PRUEBA-------------
        public DataService(string cnnString = "Server=DESKTOP-0J12S18;Database=TorneoAnal;Integrated Security=True;") :base(cnnString) { 
            this._cnnString = cnnString;
        }
        public async Task<List<Grupo>> getGrupos(string usuario)
        {
            var rt = new List<Grupo>();
            var entidadesGrupos = new List<GrupoET>();
            var prams = new Dictionary<string, string>();
            prams.Add("@usuario", usuario);

            var ds = await this.ExecuteStoredProcedure("ObtenerGrupos",prams);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var grupo = new GrupoET();
                    grupo.IdGrupo = row["idGrupo"].ToString();
                    grupo.nombreGrupo = row["nombreGrupo"].ToString();
                    grupo.grupoCerrado = Boolean.Parse(row["grupoCerrado"].ToString());
                    grupo.puntos = row["puntos"].ToString();
                    grupo.opcionCorrecta = row["opcionCorrecta"].ToString();

                    grupo.idOpcion = row["idOpcion"].ToString();
                    grupo.nombreOpcion = row["nombreOpcion"].ToString();
                    grupo.opcionSeleccionada = Boolean.Parse(row["opcionSeleccionada"].ToString());
                    entidadesGrupos.Add(grupo);
                }

                rt = entidadesGrupos
                    .GroupBy(groupBy => new { groupBy.IdGrupo, groupBy.nombreGrupo,groupBy.grupoCerrado,groupBy.puntos,groupBy.opcionCorrecta })
                    .Select(sGrupo => new Grupo() { id = sGrupo.Key.IdGrupo, nombre = sGrupo.Key.nombreGrupo,grupoCerrado=sGrupo.Key.grupoCerrado,puntos=sGrupo.Key.puntos,opcionCorrecta = sGrupo.Key.opcionCorrecta, opciones = sGrupo.ToList().Select(sOpc => new Opcion() { id = sOpc.idOpcion,opcionSeleccionada =sOpc.opcionSeleccionada ,nombre = sOpc.nombreOpcion }).ToList() }).ToList();
            
            
            }

            return rt;
        }
        public List<Grupo> getPredicciones()
        {
            //this.exampleData.ForEach(x => x.opciones[0] = this.opciones[0]);

            return null;
        }
        public Usuario GetUsuario(string idUsuario) {
            return null;
        }

        public async Task<bool> ActualizarPrediccion(string usuario, string idGrupo, string idOpcion)
        {
            var rt = false;
            var prams = new Dictionary<string, string>();
            prams.Add("@usuario", usuario);
            prams.Add("@idGrupo", idGrupo);
            prams.Add("@idOpcion", idOpcion);
            var ds = await this.ExecuteStoredProcedure("ActualizarPrediccion",prams);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rt = true;
            }

            return rt;
        }
    }
}
