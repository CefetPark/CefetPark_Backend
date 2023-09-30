namespace CefetPark.Domain.Models
{
    public class IntegranteFilaEstacionamento
    {
        public int Carro_Id { get; set; }
        public int Usuario_Id { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataEntrada { get; private set; }
        public int Posicao { get; set; }
        
        public IntegranteFilaEstacionamento()
        {
            DataEntrada = DateTime.Now;
        } 
    }
}
