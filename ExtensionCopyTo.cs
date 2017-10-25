using System;
using System.Reflection;

namespace Data.Extensions
{


    public static class ExtensionCopyTo
    {

        /// <summary>
        ///     Copy Child objects reference from source object to distanation object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="distanation"></param>
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


        /// <summary>
        ///     Move Child objects reference from source object to distanation object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="distanation"></param>
        public static void MoveTo<T>(this T source, T distanation)
        {
            var properties = typeof(T).GetProperties();
            if (distanation != null)
            {

                foreach (var item in properties)
                {

                    item.SetValue(distanation, item.GetValue(source));
                   
                    if (!item.GetType().IsValueType )
                    {
                        item.SetValue(source, null); // Remove object reference from source object
                    }


                }
            }

        }

    }
}
