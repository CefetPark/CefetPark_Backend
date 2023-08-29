using CefetPark.Application.ViewModels.Request.Common.Put;
using CefetPark.Application.ViewModels.Request.Endereco.Post;
using CefetPark.Application.ViewModels.Request.Endereco.Put;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CefetPark.Application.ViewModels.Request.Estacionamento.Put
{
    public class AtualizarEstacionamentoRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QtdVagasTotal { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public AtualizarEnderecoRequest Endereco { get; set; }
    }
}
