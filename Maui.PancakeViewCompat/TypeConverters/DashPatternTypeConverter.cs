﻿using System.ComponentModel;
using System.Globalization;

namespace PancakeView.TypeConverters
{
    [TypeConverter(typeof(DashPattern))]
    public class DashPatternTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertFromInvariantString(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        public DashPattern ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] values = value.Split(',');
                bool[] areValidIntegers = values.Select(s => Int32.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var x)).ToArray();

                if (Array.TrueForAll(areValidIntegers, x => x))
                {
                    return new DashPattern(values.Select(s => int.Parse(s, NumberStyles.Number, CultureInfo.InvariantCulture)).ToArray());
                }
            }

            throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(DashPattern)));
        }
    }
}
