using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using Entidades.Interfaces;

namespace Entidades.Archivos
{
    public class JsonManager<T> : IGuardar<T>
    {
        private string archivo;

        public JsonManager()
        {

        }

        public string RutaDeArchivo
        {
            get => Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\entradas.json";
            set => this.archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// Guarda el archivo json en el escritorio utilizando StreamWriter
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public bool Guardar(T elemento)
        {
            string path = this.RutaDeArchivo;
            bool aux = false;


            using (StreamWriter writer = new StreamWriter(path))
            {
                string jsonString = JsonSerializer.Serialize(elemento);
                writer.WriteLine(jsonString);

                aux = true;
            }

            return aux;
        }
    }
}
