using System;
using System.ComponentModel;
using System.Globalization;

namespace Apress.Recipes.WebApi
{
    public class SearchQueryConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            if (value is string)
            {
                var parts = ((string)value).Split(',');
                if (parts.Length == 3)
                {
                    int firstParsed;
                    int secondParsed;
                    if (Int32.TryParse(parts[0], out firstParsed) && Int32.TryParse(parts[1], out secondParsed))
                    {
                        return new ConvertedSearchQuery()
                        {
                            PageIndex = firstParsed,
                            PageSize = secondParsed,
                            StartsWith = parts[2]
                        };
                    }
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}