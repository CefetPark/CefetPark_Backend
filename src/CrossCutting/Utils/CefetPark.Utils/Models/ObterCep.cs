

namespace CefetPark.Utils.Models
{
    public class ObterCep
    {
        public ICollection<AddressComponentResponse> address_components { get; set; }

        public GeometryResponse geometry { get; set; }

    }

    public class AddressComponentResponse
    {
        public string long_name { get; set; }
    }

    public class GeometryResponse
    {
        public LocationResponse location { get; set; }
    }
    public class LocationResponse
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

}


