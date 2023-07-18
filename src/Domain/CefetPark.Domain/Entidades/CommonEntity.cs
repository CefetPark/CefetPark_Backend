
namespace CefetPark.Domain.Entidades
{
    public class CommonEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string CriadoPor { get; set; }
        public string AtualizadoPor { get; set; }

        public bool EstaAtivo { get; set; }

        public CommonEntity()
        {
            EstaAtivo = true;
        }


        public void Desativar()
        {
            EstaAtivo = false;
        }
    }
}
