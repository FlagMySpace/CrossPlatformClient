using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FlagMySpace.Portable.Converters
{
    public class ImageSourceCachedConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var source = value as string;

            if (!String.IsNullOrEmpty(source))
            {
                return new UriImageSource { CachingEnabled = false, Uri = new Uri(source) };
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
