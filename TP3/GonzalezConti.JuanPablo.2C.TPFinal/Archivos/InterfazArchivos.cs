using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface InterfazArchivos<T>
    {
        bool Guardar(string archivo, T data);

        bool Leer(string archivo, out T data);
    }
}
