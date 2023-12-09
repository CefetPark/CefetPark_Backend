namespace CefetPark.Domain.Entidades
{
    public class RegistroEntradaSaida : CommonEntity
    {
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public int Estacionamento_Id { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public int? Usuario_Id { get; set; }
        public Usuario Usuario { get; set; }
        public int Carro_Id { get; set; }
        public Carro Carro { get; set; }
        public int? Convidado_Id { get; set; }
        public Convidado Convidado { get; set; }
    }
}
