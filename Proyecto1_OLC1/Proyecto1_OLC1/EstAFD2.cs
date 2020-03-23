using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_OLC1
{
    class EstAFD2
    {
        private int nombre;
        private List<Estado> estadosAFN;
        private List<TransAFD2> transiciones;
        private Boolean agregado;
        private Boolean inicial;
        private Boolean aceptacion;
        public EstAFD2(int nombre)
        {
            this.nombre = nombre;
            agregado = false;
            inicial = false;
            aceptacion = false;
            estadosAFN = new List<Estado>();
            transiciones = new List<TransAFD2>();
        }

        public int getNombre()
        {
            return nombre;
        }

        public List<Estado> getEstadosAFN()
        {
            return estadosAFN;
        }

        public List<TransAFD2> getListTrans()
        {
            return transiciones;
        }

        public Boolean isAgregado()
        {
            return agregado;
        }

        public Boolean isInicial()
        {
            return inicial;
        }

        public Boolean isAceptacion()
        {
            return aceptacion;
        }

        public void setNombre(int nombre)
        {
            this.nombre = nombre;
        }

        public void setAgregado(Boolean agregado)
        {
            this.agregado = agregado;
        }

        public void setInicial(Boolean inicial)
        {
            this.inicial = inicial;
        }

        public void setAceptacion(Boolean aceptacion)
        {
            this.aceptacion = aceptacion;
        }


    }
}
