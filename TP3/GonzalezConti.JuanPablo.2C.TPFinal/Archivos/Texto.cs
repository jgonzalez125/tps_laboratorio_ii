using System;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : InterfazArchivos<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = new StreamWriter(archivo);
            try
            {
                writer.WriteLine(datos);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                writer.Close();
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = new StreamReader(archivo);
            try
            {
                datos = streamReader.ReadToEnd();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                streamReader.Close();
            }
        }

    }
}
