using CefetPark.Application.ViewModels.Request.Common.Put;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefetPark.Application.ViewModels.Request.Endereco.Put
{
    public class AtualizarEnderecoRequest
    {
        
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Longitude { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TipoLogradouro { get; set; }
    }
}
