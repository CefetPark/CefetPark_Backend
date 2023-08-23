using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Entidades
{
    public class Cor : CommonEntity
    {
        public string Nome { get; set; }
        public ICollection<Carro> Carros { get; set; }
    }
}
