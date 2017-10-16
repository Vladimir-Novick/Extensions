
using Newtonsoft.Json;
using System;

namespace Utils
{
    /// <summary>
    ///
    ///   Serialization Object To Json string
    ///
    ///  string str = obj.ToJson();
    ///
    /// </summary>

    public static class ExtensionJsonSerialization
    {
        // 
        public static String ToJson<T>(this T a)
        {
            return JsonConvert.SerializeObject(a);
        }
    }
}


