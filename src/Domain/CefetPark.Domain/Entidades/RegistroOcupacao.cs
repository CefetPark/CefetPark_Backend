namespace CefetPark.Domain.Entidades
{
    public class RegistroOcupacao : CommonEntity
    {
        public int QuantidadeVagasLivresEntrada { get; set; }
        public int? QuantidadeVagasLivreSaida { get; set; }
        public int RegistroEntradaSaida_Id { get; set; }
        public RegistroEntradaSaida RegistroEntradaSaida {get;set;}
        public int Estacionamento_Id { get; set; }
        public Estacionamento Estacionamento { get; set; }
    }
}
