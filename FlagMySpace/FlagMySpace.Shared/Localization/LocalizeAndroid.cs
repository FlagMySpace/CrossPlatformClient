using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace FlagMySpace.Shared.Localization
{
    [Localizable(false)]
    public class LocalizeAndroid : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns pt_BR into pt-BR
            if ("in-ID".Equals(netLanguage))
            {
                netLanguage = "id-ID";
            }
            CultureInfo cultureInfo;
            try
            {
                cultureInfo = new CultureInfo(netLanguage);
            }
            catch (Exception)
            {
                cultureInfo = new CultureInfo("en-US");
            }
            return cultureInfo;
        }
    }
}
