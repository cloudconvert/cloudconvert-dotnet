using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using JetBrains.Annotations;

namespace CloudConvert.API.Extensions
{
  public static class StringExtensions
  {
    public static string TrimLengthWithEllipsis([NotNull] this string str, int maxLength)
    {
      if (str.Length <= maxLength)
      {
        return str;
      }

      return str.Substring(0, maxLength) + "...";
    }

    public static string GetEnumDescription<TEnum>(this TEnum source) where TEnum : struct, Enum
    {
      var s = source.ToString();

      FieldInfo fi = source.GetType().GetField(s);

      if (fi == null)
      {
        throw new MissingFieldException(nameof(s));
      }

      DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

      if (attributes.Length == 0)
      {
        throw new KeyNotFoundException(nameof(DescriptionAttribute));
      }

      return attributes[0].Description;
    }

  }  
}
