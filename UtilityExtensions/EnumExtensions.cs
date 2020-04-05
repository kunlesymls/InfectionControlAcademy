using System.ComponentModel;
using System.Linq;

namespace System
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum enumValue)
        {
            return Enum.GetName(enumValue.GetType(), enumValue);
        }

        public static string GetDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.GetName());
            return !(field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() is DescriptionAttribute descriptionAttribute) ? enumValue.GetName() : descriptionAttribute.Description;
        }
    }
}
