using CefetPark.Application.ViewModels.Response.Common.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Response.Carro.Get
{
    public class ObterCarroUsuarioResponse
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
    }
}
