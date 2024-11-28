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
        private List<Opcion> opciones = new List<Opcion>() {
            new Opcion(){
                 id="1",
                 nombre="Lucas"
            },
            new Opcion(){
                 id="2",
                 nombre="Gaston"
            },
            new Opcion(){
                 id="3",
                 nombre="Alex"
            },
            new Opcion(){
                 id="4",
                 nombre="Uvetio"
            },
            new Opcion(){
                 id="1",
                 nombre="Cana"
            },
            new Opcion(){
                 id="2",
                 nombre="Cerda"
            },
            new Opcion(){
                 id="3",
                 nombre="Bruno"
            },
            new Opcion(){
                 id="4",
                 nombre="Cris"
            },
            new Opcion(){
                 id="1",
                 nombre="Guille"
            },
            new Opcion(){
                 id="2",
                 nombre="Joel"
            },
            new Opcion(){
                 id="3",
                 nombre="Viroga"
            },
            new Opcion(){
                 id="4",
                 nombre="Bri"
            }
        };
        private List<Grupo> exampleData = new List<Grupo>()
        {
           new Grupo()
           {
               id="1",
               nombre="Partida mas rapida"               
           },
           new Grupo()
           {
               id="2",
               nombre="Partida mas lenta"
           },
           new Grupo()
           {
               id="3",
               nombre="Campeon anal"
           },
           new Grupo()
           {
               id="4",
               nombre="Primero en irse"
           }

        };
        private Usuario usuarioPrueba = new Usuario() {
            id="1",
            nombre="pichula",
            puntos="0"
        };
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
                    grupo.idOpcion = row["idOpcion"].ToString();
                    grupo.nombreOpcion = row["nombreOpcion"].ToString();
                    grupo.estado = row["estado"].ToString();
                    entidadesGrupos.Add(grupo);
                }

                rt = entidadesGrupos
                    .GroupBy(groupBy => new { groupBy.IdGrupo, groupBy.nombreGrupo })
                    .Select(sGrupo => new Grupo() { id = sGrupo.Key.IdGrupo, nombre = sGrupo.Key.nombreGrupo, opciones = sGrupo.ToList().Select(sOpc => new Opcion() { id = sOpc.idOpcion,estado =sOpc.estado ,nombre = sOpc.nombreOpcion }).ToList() }).ToList();
            
            
            }

            return rt;
        }
        public List<Grupo> getPredicciones()
        {
            this.exampleData.ForEach(x => x.opciones[0] = this.opciones[0]);

            return this.exampleData;
        }
        public Usuario GetUsuario(string idUsuario) {
            return this.usuarioPrueba;
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
