using CefetPark.Application.ViewModels.Request.Common.Put;
using System;

using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Convidado.Put
{
    public class AtualizarConvidadoRequest : AtualizarCommonRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Cor_Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Modelo_Id { get; set; }
    }
}
