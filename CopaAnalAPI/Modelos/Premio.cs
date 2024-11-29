namespace CopaAnalAPI.Modelos
{
    public class Premio
    {
        public string nombre { get; set; }
        public List<Grupo> gruposGanados { get; set; }
        public Premio() { 
            this.gruposGanados = new List<Grupo>();
        }
    }
}
