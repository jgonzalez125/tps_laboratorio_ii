﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Archivos
{
    public class Xml<T> : InterfazArchivos<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool aux = false;
            using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
                aux = true;
            }
            return aux;
        }

        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            try
            {
                using (reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(reader);
                    return true;
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
