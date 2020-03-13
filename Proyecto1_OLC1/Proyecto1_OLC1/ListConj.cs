using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_OLC1
{
    class ListConj
    {
        private String nombre;
        private LinkedList<String> conjunto;

        public ListConj(String nombre, LinkedList<String> conjunto)
        {
            this.nombre = nombre;
            this.conjunto = conjunto;
        }

        public ListConj()
        {
            conjunto = new LinkedList<String>();
        }


        public String getNombre()
        {
            return nombre;
        }

        public LinkedList<String> getConjunto()
        {
            return conjunto;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public void setConjunto(LinkedList<String> conjunto)
        {
            this.conjunto = conjunto;
        }
    }
}
