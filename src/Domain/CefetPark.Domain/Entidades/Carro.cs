using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Domain.Entidades
{
    public class Carro : CommonEntity
    {
        public string Placa { get; set; }
        public int Cor_Id { get; set; }
        public Cor Cor { get; set; }
        public int Modelo_Id { get; set; }
        public Modelo Modelo { get; set; }
        public ICollection<RegistroEntradaSaida> RegistrosEntradasSaidas { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

        public ICollection<Convidado> Convidados { get; set; }
    }
}
