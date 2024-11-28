namespace CopaAnalAPI.Modelos
{
    public class Grupo
    {
        public string nombre { get; set; }
        public string id { get; set; }
        public List<Opcion> opciones { get; set; }
        public Grupo() { 
            this.opciones = new List<Opcion>();
        }  
    }
}
