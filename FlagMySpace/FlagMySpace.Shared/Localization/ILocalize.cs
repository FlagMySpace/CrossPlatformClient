using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FlagMySpace.Shared.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
