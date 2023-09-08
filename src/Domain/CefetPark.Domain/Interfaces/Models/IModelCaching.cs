
namespace CefetPark.Domain.Interfaces.Models
{
    public interface IModelCaching
    {
        int Id { get; set; }
        public string ObterKey();
    }
}
