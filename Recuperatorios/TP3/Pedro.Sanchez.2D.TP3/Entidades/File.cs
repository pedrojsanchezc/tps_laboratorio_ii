using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Entidades
{
    public static class File <T>
    {
        private static string routeFile;

        static File()
        {
            routeFile = AppDomain.CurrentDomain.BaseDirectory;
        }

        public static void WriteFileTxt(string fileName, string saveData)
        {
            string fileRoute = routeFile + fileName + ".txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(fileRoute))
                {
                    sw.WriteLine(saveData);
                }
            }
            catch (Exception ex)
            {
                throw new FileException($"Error al escribir archivo TXT {fileRoute}", ex);
            }
        }

        public static string ReadFileTxt(string fileName)
        {
            string fileRoute = routeFile + fileName + ".txt";
            string data = String.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(fileRoute))
                {
                    data = sr.ReadToEnd();
                }
                return data;
            }
            catch (Exception ex) 
            {
                throw new FileException($"Error al leer archivo TXT {fileRoute}", ex);
            }
        }

        public static void WriteJson(string fileName, T saveData)
        {
            string fileRoute = routeFile + fileName + ".json";
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string dataSerializer = JsonSerializer.Serialize(saveData, options);
                File.WriteAllText(fileRoute, dataSerializer);
            }
            catch (Exception ex)
            {
                throw new FileException($"Error al escribir archivo json. {fileRoute}", ex);
            }
        }

        public static T ReadJson(string fileName)
        {
            string fileRoute = routeFile + fileName + ".json";
            T data = default;
            try
            {
                string file = File.ReadAllText(fileRoute);
                data = JsonSerializer.Deserialize<T>(file);

                return data;
            }
            catch (Exception ex)
            {
                throw new FileException($"Error al leer archivo json. {fileRoute}", ex);
            }
        }

        public static void WriteXml(string fileName, T saveData)
        {
            string fileRoute = routeFile + fileName + ".xml";
            try
            {
                using (XmlTextWriter tw = new XmlTextWriter(fileRoute, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    tw.Formatting = Formatting.Indented;
                    serializer.Serialize(tw, saveData);
                }
            }
            catch (Exception ex)
            {
                throw new FileException($"Error al escribir archivo XML. {fileRoute}", ex);
            }
        }

        public static T ReadXml(string fileName)
        {
            string fileRoute = routeFile + fileName + ".xml";
            T data = default;
            try
            {
                using (XmlTextReader tw = new XmlTextReader(fileRoute))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    data = (T)serializer.Deserialize(tw);
                }

                return data;
            }
            catch (Exception ex)
            {
                throw new FileException($"Error al leer archivo XML. {fileRoute}", ex);
            }
        }
    }
}
