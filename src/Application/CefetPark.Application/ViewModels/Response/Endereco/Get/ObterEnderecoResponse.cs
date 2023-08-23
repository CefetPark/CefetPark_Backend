using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Response.Endereco.Get
{
    public class ObterEnderecoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string TipoLogradouro { get; set; }
    }
}
