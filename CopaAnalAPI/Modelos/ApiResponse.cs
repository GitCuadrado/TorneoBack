namespace CopaAnalAPI.Modelos
{
    public class ApiResponse<T>
    {
        public bool estado { get; set; }
        public string errMsg { get; set; }
        public T resp { get; set; } 
        public ApiResponse(bool _estado, string _errMsg, T resp = default)
        {
            this.estado = _estado;
            this.errMsg = _errMsg;
            this.resp = resp;
        }
    }
}
