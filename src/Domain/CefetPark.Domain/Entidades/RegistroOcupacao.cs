namespace CefetPark.Domain.Entidades
{
    public class RegistroOcupacao : CommonEntity
    {
        public int QuantidadeVagasLivresEntrada { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public int Estacionamento_Id { get; set; }
        public Estacionamento Estacionamento { get; set; }
    }
    
}
