using System;

namespace Tatu.Marchesan.Ideias.App.Core.Extensions
{
    public static class EnumExtensions
    {
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
    }
}