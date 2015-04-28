using System;
using System.ComponentModel;
using System.Globalization;
using Android.Provider;
using FlagMySpace.Droid.Localization;
using FlagMySpace.Portable.Localization;
using Xamarin.Forms;

[assembly:Dependency(typeof(LocalizeAndroid))]
namespace FlagMySpace.Droid.Localization
{
    [Localizable(false)]
    public class LocalizeAndroid : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
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
