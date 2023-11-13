using System.ComponentModel;

namespace Clean.Domain.Core
{
    public class DisplayCoreAttribute : DisplayNameAttribute
    {
        public DisplayCoreAttribute(string value) : base(FormatValue(value)) { }

        private static string FormatValue(string value)
        {
            return string.Format("My attribute ({0})",value);
        }
    }
}
