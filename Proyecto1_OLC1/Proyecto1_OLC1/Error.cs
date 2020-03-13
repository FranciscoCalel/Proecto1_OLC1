using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_OLC1
{
    class Error
    {

        private String lexema;
        private int fila, columna;

        public Error(String lexema, int fila, int columna)
        {
            this.lexema = lexema;
            this.fila = fila;
            this.columna = columna;
        }

        public String getLexema()
        {
            return lexema;
        }
        public int getFila()
        {
            return fila;
        }
        public int getColumna()
        {
            return columna;
        }

        public void setLexema(String lexema)
        {
            this.lexema = lexema;
        }
        public void setFila(int fila)
        {
            this.fila = fila;
        }
        public void setColumna(int columna)
        {
            this.columna = columna;
        }

    }
}
