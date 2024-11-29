namespace CopaAnalAPI.Modelos
{
    public class EstadoPanel<T>
    {
        public bool estado { get; set; }
        public string texto { get; set; }
        public T resp { get; set; }
        public EstadoPanel(bool _estado, string _texto, T _resp = default)
        {
            this.estado = _estado;
            this.texto = _texto;
            this.resp = _resp;
        }
    }
}
