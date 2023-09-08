
using CefetPark.Domain.Interfaces.Models;

namespace CefetPark.Domain.Models
{
    public class CommonModelCaching : IModelCaching
    {
        public int Id { get; set; }

        public CommonModelCaching(int id)
        {
            Id = id;
        }
        public string ObterKey()
        {
            string key = $"{GetType()}-{Id}";
            return key;
        }
    }
}
