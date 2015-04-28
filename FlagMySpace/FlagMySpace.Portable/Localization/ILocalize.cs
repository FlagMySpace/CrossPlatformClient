using System.Globalization;

namespace FlagMySpace.Portable.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
