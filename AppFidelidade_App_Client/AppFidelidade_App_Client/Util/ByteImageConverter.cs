using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace AppFidelidade_App_Client.Util
{
    public class ByteImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            var image = value as byte[];
            if (image == null)
                return null;
            return ImageSource.FromStream(() => new MemoryStream(image));
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
