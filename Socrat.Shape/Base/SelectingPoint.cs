using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Socrat.Shape
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.ComponentModel.EnumConverter" />
    public class SelectingPointConverter : EnumConverter
    {
        private Type _enumType;
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectingPointConverter"/> class.
        /// </summary>
        /// <param name="type">A <see cref="T:System.Type" /> that represents the type of enumeration to associate with this enumeration converter.</param>
        public SelectingPointConverter(Type type) : base(type)
        {
            _enumType = type;
        }

        /// <summary>
        /// Determines whether this instance [can convert to] the specified Context.
        /// </summary>
        /// <param name="Context">The Context.</param>
        /// <param name="destType">Type of the dest.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can convert to] the specified Context; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext Context,
            Type destType)
        {
            return destType == typeof(string);
        }
        /// <summary>
        /// Converts to.
        /// </summary>
        /// <param name="Context">The Context.</param>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <param name="destType">Type of the dest.</param>
        /// <returns></returns>
        public override object ConvertTo(ITypeDescriptorContext Context,
            CultureInfo culture,
            object value, Type destType)
        {
            FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, value));
            DescriptionAttribute dna =
                (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

            if (dna != null)
                return dna.Description;
            else
                return value.ToString();
        }
        /// <summary>
        /// Determines whether this instance [can convert from] the specified Context.
        /// </summary>
        /// <param name="Context">The Context.</param>
        /// <param name="srcType">Type of the source.</param>
        /// <returns>
        ///   <c>true</c> if this instance [can convert from] the specified Context; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext Context,
        Type srcType)
        {
            return srcType == typeof(string);
        }
        /// <summary>
        /// Converts the specified value object to an enumeration object.
        /// </summary>
        /// <param name="Context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format Context.</param>
        /// <param name="culture">An optional <see cref="T:System.Globalization.CultureInfo" />. If not supplied, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object" /> that represents the converted <paramref name="value" />.
        /// </returns>
        public override object ConvertFrom(ITypeDescriptorContext Context,
            CultureInfo culture,
            object value)
        {
            foreach (FieldInfo fi in _enumType.GetFields())
            {
                DescriptionAttribute dna =
                (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

                if ((dna != null) && ((string)value == dna.Description))
                    return Enum.Parse(_enumType, fi.Name);
            }
            return Enum.Parse(_enumType, (string)value);
        }
    }
}
