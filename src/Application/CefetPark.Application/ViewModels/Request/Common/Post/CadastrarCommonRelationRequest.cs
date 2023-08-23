using System.ComponentModel.DataAnnotations;

namespace CefetPark.Application.ViewModels.Request.Common.Post
{
    public class CadastrarCommonRelationRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }
    }
}
