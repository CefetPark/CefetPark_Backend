using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Convidado.Post;
using System;

using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Convidado.Put
{
    public class AtualizarConvidadoRequest : AtualizarCommonRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }
    }
}
