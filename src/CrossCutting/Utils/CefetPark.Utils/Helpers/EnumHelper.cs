using System.ComponentModel;
using System.Reflection;

namespace CefetPark.Utils.Helpers
{
    public static class EnumHelper
    {
        public static string ObterDescricao(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
