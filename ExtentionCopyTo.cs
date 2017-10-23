using System;

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
                    item.SetValue(distanation, item.GetValue(source));
                }
            }

        }

        public static void MoveTo<T>(this T source, T distanation)
        {
            var properties = typeof(T).GetProperties();
            if (distanation != null)
            {

                foreach (var item in properties)
                {
                   
                    item.SetValue(distanation, item.GetValue(source));
                    Object isBoxing = item.GetValue(source) as Object;
                    if (isBoxing != null)
                    {
                        item.SetValue(source, null);
                    }
                    

                }
            }

        }

    }
}
