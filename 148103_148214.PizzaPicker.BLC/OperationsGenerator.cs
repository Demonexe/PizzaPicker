using _148103_148214.PizzaPicker.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _148103_148214.PizzaPicker
{
    public static class OperationsGenerator
    {
        public static List<string> GetOperationsForType(Type type)
        {
            if(type == typeof(string))
                return new List<string>() { "Equal", "Contains" };
            if (type == typeof(int))
                return new List<string>() { "Equal", "Less", "Greater", "NotEqual" };
            if ((type.IsEnum))
                return new List<string>() { "Equal", "NotEqual" };
            else return null;
        }

        public static QueryBuilderOperation StringToEnum(string value)
        {
            return (QueryBuilderOperation)Enum.Parse(typeof(QueryBuilderOperation), value);
        }

        public static string EnumToString(QueryBuilderOperation value)
        {
            return value.ToString();
        }
    }
}
