namespace CefetPark.WebApi.Models
{
    public class CustomResponseSuccess
    {
        public object Data { get; private set; }

        public CustomResponseSuccess(object data)
        {
            Data = data;
        }
    }
}
