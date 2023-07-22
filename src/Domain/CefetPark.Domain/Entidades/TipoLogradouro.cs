using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Entidades
{
    public class TipoLogradouro : CommonEntity
    {
        public string Nome { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
