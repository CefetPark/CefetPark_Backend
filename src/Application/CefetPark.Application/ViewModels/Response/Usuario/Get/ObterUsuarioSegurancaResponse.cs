using CefetPark.Application.ViewModels.Response.Auth.Post;

namespace CefetPark.Application.ViewModels.Response.Usuario.Get
{
    public class ObterUsuarioSegurancaResponse
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string TelefonePrincipal { get; set; }
        public string TelefoneSecundario { get; set; }
        public string EmailPrincipal { get; set; }
        public string EmailSecundario { get; set; }
        public string Departamento { get; set; }
        public string TipoUsuario { get; set; }
        public ICollection<LoginCarroAuthResponse> Carros { get; set; }
    }
}
