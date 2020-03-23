using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_OLC1
{
    class Estado
    {

        private int numero;
        private List<Transiciones> listTrans;
        private Boolean estadoInicial;
        private Boolean estadoAceptacion;
        public Estado(int numero)
        {
            this.numero = numero;
            listTrans = new List<Transiciones>();
        }

        public List<Transiciones> getListTrans()
        {
            return listTrans;

        }

        public int getNumero()
        {
            return numero;
        }

        public Boolean isEstInicial()
        {
            return estadoInicial;
        }

        public Boolean isEstAceptacion()
        {
            return estadoAceptacion;
        }

        public void setListTrans(List<Transiciones> listTrans)
        {
            this.listTrans = listTrans;
        }
        public void setNumero(int numero)
        {
            this.numero = numero;
        }

        public void setEstInicial(Boolean estadoInicial)
        {
            this.estadoInicial = estadoInicial;
        }

        public void setEstAceptacion(Boolean estadoAceptacion)
        {
            this.estadoAceptacion = estadoAceptacion;
        }
    }
}
