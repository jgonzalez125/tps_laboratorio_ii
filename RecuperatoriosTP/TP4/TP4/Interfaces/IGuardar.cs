using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{

    /// <summary>
    /// Esta interfaz se encarga de declarar la propiedad 
    /// <see cref="RutaDeArchivo"/> y a su vez declara los metodos
    /// <see cref="Guardar"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public interface IGuardar<T>
    {
        string RutaDeArchivo
        {
            get;
            set;
        }


        bool Guardar(T elemento);
    }
}
