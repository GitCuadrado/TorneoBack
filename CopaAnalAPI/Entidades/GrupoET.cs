namespace CopaAnalAPI.Entidades
{
    public class GrupoET
    {
        //grupo
        public string IdGrupo { get; set; }
        public string nombreGrupo { get; set; } 
        public bool grupoCerrado { get; set; }
        public string puntos { get;set; }
        public string opcionCorrecta { get; set; }
        //opciones
        public string idOpcion {  get; set; }
        public string nombreOpcion { get; set; }   
        public bool opcionSeleccionada { get; set; }
    }
}
