using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Entidades
{
    public class Modelo : CommonEntity
    {
        public string Nome { get; set; }
        public int Marca_Id { get; set; }
        public Marca Marca { get; set; }
        public ICollection<Carro> Carros { get; set; }
    }
}
