using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Entidades
{
    public class UsuarioCarro : CommonEntity
    {
        public int Usuario_Id { get; set; }
        public Usuario Usuario { get; set; }
        public int Carro_Id { get; set; }
        public Carro Carro { get; set; }
    }
}
