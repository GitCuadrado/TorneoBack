namespace CopaAnalAPI.Modelos
{
    public class Ranking
    {
        public string nombre { get; set; }
        public string puntos { get;set; }
        public string aciertos { get; set; }
        public List<Grupo> gruposAcertados { get; set; }
        public Ranking()
        {
            this.gruposAcertados = new List<Grupo>();
        }
    }
}
