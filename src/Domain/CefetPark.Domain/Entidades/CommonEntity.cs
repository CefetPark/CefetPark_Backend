
namespace CefetPark.Domain.Entidades
{
    public class CommonEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int CriadoPor { get; set; }
        public int? AtualizadoPor { get; set; }

        public bool EstaAtivo { get; set; }

        public CommonEntity()
        {
            EstaAtivo = true;
        }


        public void Desativar()
        {
            EstaAtivo = false;
        }


        protected string ObterKey()
        {
            string key = $"{GetType().Name}-{Id}";
            return key;
        }
    }
}
