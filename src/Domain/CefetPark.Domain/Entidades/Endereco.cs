using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Entidades
{
    public class Endereco : CommonEntity
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int TipoLogradouro_Id { get; set; }
        public TipoLogradouro TipoLogradouro { get; set; }
        public int? Estacionamento_Id { get; set; }
        public Estacionamento? Estacionamento { get; set; }
    }
}
