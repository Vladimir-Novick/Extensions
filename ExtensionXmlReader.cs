using System;
using System.IO;
using System.Xml.Serialization;


////////////////////////////////////////////////////////////////////////////
//	Copyright 2010 - 2017 : Vladimir Novick    https://www.linkedin.com/in/vladimirnovick/  
//        
//             https://github.com/Vladimir-Novick/Extensions
//
//    NO WARRANTIES ARE EXTENDED. USE AT YOUR OWN RISK. 
//
// To contact the author with suggestions or comments, use  :vlad.novick@gmail.com
//
////////////////////////////////////////////////////////////////////////////
namespace XmlUtils
{
    /// <summary>
    ///      Extention:  Convert XML to Class instance
    /// </summary>
    public static class ExtensionXmlReader
    {
        private static T Deserialize<T>(String strXMLAreas)
        {
            T ret;

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader rdr = new StringReader(strXMLAreas))
            {
                ret = (T)serializer.Deserialize(rdr);
            }
            serializer = null;
            return ret;
        }


        private static T DeserializeFile<T>(String strXMLFileName)
        {
            string strXMLAreas = File.ReadAllText(strXMLFileName, System.Text.Encoding.UTF8);
            T ret = Deserialize<T>(strXMLAreas);
            strXMLAreas = null;
            return ret;
        }

        /// <summary>
        ///    Extention Convert XML to Class instance
        ///   
        /// Example :
        ///        RootAreas rootAreas = new RootAreas(); 
        ///        rootAreas.ReadXMLFile(ref rootAreas,  "AREAS.xml");
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="outputData"></param>
        /// <param name="fileName"></param>
        public static void ReadXMLFile<T>(this T ClassInstance, ref T outputData,String fileName)
        {
            T ret = DeserializeFile<T>(fileName);
            outputData = ret;
        }

        /// <summary>
        ///   Extention Convert XML to Class instance
        ///   
        /// Example :
        /// 
        ///        RootAreas rootAreas = new RootAreas(); 
        ///        RootAreas newObject = rootAreas.ReadXMLFile(ref rootAreas, "AREAS.xml");      /// 
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T ReadXMLFile<T>(this T a, String fileName)
        {
            T ret = DeserializeFile<T>(fileName);
            return ret;
        }


    }
}
