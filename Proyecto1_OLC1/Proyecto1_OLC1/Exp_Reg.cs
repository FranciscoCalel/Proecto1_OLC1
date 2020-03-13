using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1_OLC1
{
    class Exp_Reg
    {
        private String nombre;
        private LinkedList<Token> expresion;


        public Exp_Reg(String nombre, LinkedList<Token> expresion)
        {
            this.nombre = nombre;
            this.expresion = expresion;
        }

        public Exp_Reg()
        {
            expresion = new LinkedList<Token>();
        }

        public String getNombre()
        {
            return nombre;
        }

        public LinkedList<Token> getExpresion()
        {
            return expresion;
        }


        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public void setExpresion(LinkedList<Token> exprecion)
        {
            this.expresion = exprecion;
        }
    }
}
