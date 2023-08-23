using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Entidades
{
    public class Usuario : CommonEntity
    {
        public string AspNetUsers_Id { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string TelefonePrincipal { get; set; }
        public string? TelefoneSecundario { get; set; }
        public string EmailPrincipal { get; set; }
        public string? EmailSecundario { get; set; }
        public int Departamento_Id { get; set; }
        public Departamento Departamento { get; set; }
        public int TipoUsuario_Id { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public ICollection<RegistroEntradaSaida> RegistrosEntradasSaidas { get; set; }
        public ICollection<Carro> Carros { get; set; }
    }
}
