using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic;

public static class ListExtensions
{
    public static string ItemsToString<T>(this List<T> list)
    {
        var sb = new StringBuilder();
        sb.Append("{ ");
        foreach (var item in list)
        {
            sb.Append($"{item}; ");
        }
        sb.Append("}");
        return sb.ToString();
    }
}
