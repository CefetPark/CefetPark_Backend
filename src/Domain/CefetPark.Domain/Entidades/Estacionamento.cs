namespace CefetPark.Domain.Entidades
{
    public class Estacionamento : CommonEntity
    {
        public string Nome { get; set; }
        public int QtdVagasTotal { get; set; }
        public int QtdVagasLivres { get; set; }
        public int Endereco_Id { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<RegistroEntradaSaida> RegistrosEntradasSaidas { get; set; }
    }
}
