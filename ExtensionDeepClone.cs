
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SGCombo.Utils
{
 /// <summary>
 ///
 ///   Clone Object
 ///
 ///  Please marked as [Serializable] with a DeepClone method
 ///
 ///  MyClass copy = obj.DeepClone();
 ///
 /// </summary>

   public static class ExtensionDeepCloneMethods
   {
    // Clone object
    public static T DeepClone<T>(this T a)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, a);
            stream.Position = 0;
            return (T) formatter.Deserialize(stream);
        }
    }
   }
}

 
