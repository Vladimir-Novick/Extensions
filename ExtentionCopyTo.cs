using System;
using System.Reflection;

namespace Extentions
{
    public static class ExtentionCopyTo
    {
        public static void CopyTo<T>(this T source, T distanation)
        {
            var properties = typeof(T).GetProperties();
            if (distanation != null)
            {
               
                foreach (var item in properties)
                {
                    Object data = item.GetValue(source);
                    item.SetValue(distanation, data);
                }
            }

        }

    }
}
