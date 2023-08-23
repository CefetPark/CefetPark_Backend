using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Entidades
{
    public class Departamento : CommonEntity
    {
        public string Nome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
