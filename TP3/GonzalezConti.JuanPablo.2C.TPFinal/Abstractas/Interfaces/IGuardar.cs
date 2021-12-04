using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractas.Interfaces
{
    public interface IGuardar<T>
    {
        bool Guardar();
        T Leer();
    }
}
