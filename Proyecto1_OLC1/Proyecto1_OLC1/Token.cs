using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_OLC1
{
    class Token
    {
        public enum Tipo
        {
            ID,
            COMENTARIO,
            CADENA,
            LLAVE_IZQ,
            LLAVE_DER,
            PARENTESIS_IZQ,
            PARENTESIS_DER,
            SIGNO_MAS,
            ASTERISCO,
            PORCENTAJE,
            DOS_PUNTOS,
            GUION,
            PUNTO,
            SIGNO_DISYUNCION,
            SIGNO_INTERROGACION,
            ERROR,
        }
    }
}
