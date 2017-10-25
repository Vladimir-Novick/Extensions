using System;
using System.Reflection;

namespace Data.Utils
{
    /// <summary>
    ///    Copy/Move Child objects reference from source object to distanation object
    ///    
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CopyToOperation<T>
    {
        public PropertyInfo[] properties { private set; get; }

        public CopyToOperation()
        {
            properties = typeof(T).GetProperties();
        }

        /// <summary>
        ///    Copy Child objects reference from source object to distanation object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="distanation"></param>
        public void CopyTo( T source, T distanation)
        {

        
            if (distanation != null)
            {
                foreach (var item in properties)
                {
                    item.SetValue(distanation, item.GetValue(source));
                }
            }

        }


        /// <summary>
        ///     Move Child objects from source object to distanation object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="distanation"></param>
        public void MoveTo( T source, T distanation)
        {
          
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
