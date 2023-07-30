
using CefetPark.Application.ViewModels.Response.Common.Get;
using CefetPark.Domain.Entidades;

namespace CefetPark.Application.ViewModels.Response.Usuario.Get
{
    public class ObterUsuarioResponse
    {
        public string AspNetUsers_Id { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string TelefonePrincipal { get; set; }
        public string? TelefoneSecundario { get; set; }
        public string EmailPrincipal { get; set; }
        public string? EmailSecundario { get; set; }
        public ObterCommonResponse Departamento { get; set; }
        public ObterCommonResponse TipoUsuario { get; set; }
    }
}
