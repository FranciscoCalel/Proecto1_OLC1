using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_OLC1
{
    class TransAFD2
    {


        private EstAFD2 inicial;
        private EstAFD2 final;
        private String simbolo;

        public TransAFD2(EstAFD2 inicial, EstAFD2 final, String simbolo)
        {
            this.inicial = inicial;
            this.final = final;
            this.simbolo = simbolo;
        }

        public EstAFD2 getInicial()
        {
            return inicial;
        }

        public EstAFD2 getFinal()
        {
            return final;
        }

        public String getSimbolo()
        {
            return simbolo;
        }

        public void setInicial(EstAFD2 inicial)
        {
            this.inicial = inicial;
        }

        public void setFinal(EstAFD2 final)
        {
            this.final = final;
        }

        public void setSimbolo(String simbolo)
        {
            this.simbolo = simbolo;
        }


    }
}
