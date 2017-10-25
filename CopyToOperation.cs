using System;
using System.Collections.Generic;
using System.Reflection;

namespace Data.Operation
{
    /// <summary>
    ///    Copy/Move Child objects reference from source object to distanation object
    ///       multi-object operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CopyToOperation<T>
    {

        public class PropertyInfoData
        {
            public PropertyInfo Info { get; set;  }
            public bool IsValueType { get; set; }
        }

        public List<PropertyInfoData> properties {  set; get; }

        public CopyToOperation()
        {
            properties = new List<PropertyInfoData>();
            PropertyInfo[] prop = typeof(T).GetProperties();
            foreach (var info in prop)
            {
                PropertyInfoData infoData = new PropertyInfoData()
                {
                    Info = info,
                    IsValueType = info.GetType().IsValueType
                };
                properties.Add(infoData);
            }
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
                    item.Info.SetValue(distanation, item.Info.GetValue(source));
                }
            }

        }


        /// <summary>
        ///     Move Child objects reference from source object to distanation object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="distanation"></param>
        public void MoveTo( T source, T distanation)
        {
          
            if (distanation != null)
            {

                foreach (var item in properties)
                {

                    item.Info.SetValue(distanation, item.Info.GetValue(source));

                    if ( !item.IsValueType)
                    {
                        item.Info.SetValue(source, null);
                    }


                }
            }

        }


    }








}
