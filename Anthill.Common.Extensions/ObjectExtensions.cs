using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static Boolean IsNumericType(this Type type)
        {
            var typeCode = Type.GetTypeCode(Nullable.GetUnderlyingType(type));

            if (typeCode == TypeCode.Empty)
            {
                typeCode = Type.GetTypeCode(type);
            }

            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
