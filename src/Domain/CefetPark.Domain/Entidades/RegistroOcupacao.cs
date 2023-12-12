namespace CefetPark.Domain.Entidades
{
    public class RegistroOcupacao : CommonEntity
    {
        public int QuantidadeVagasLivres { get; set; }
        public DateTime Data { get; set; }
        public int RegistroEntradaSaida_Id { get; set; }
        public RegistroEntradaSaida RegistroEntradaSaida { get; set; }
    }
    
}
