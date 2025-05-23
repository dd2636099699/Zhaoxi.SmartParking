﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Effects;

namespace Zhaoxi.SmartParking.Client.Common.Converters
{
    public class Bool2BlurConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            if (value != null && bool.TryParse(value.ToString(), out result))
            {
                if (result)
                    return new BlurEffect() { Radius = 10 };
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
