﻿using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Common.Post
{
    public class CadastrarCommonRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
    }
}
