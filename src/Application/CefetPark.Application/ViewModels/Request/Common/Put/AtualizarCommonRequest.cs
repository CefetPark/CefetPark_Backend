
using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Common.Put
{
    public class AtualizarCommonRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
        
    }
}
