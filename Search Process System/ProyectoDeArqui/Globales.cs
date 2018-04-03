using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;
namespace ProyectoDeArqui
{
    class Globales
    {


        public Globales instancia;

        public static ArrayList imprimirInformacionGrafico = new ArrayList();
        private static  ArrayList MyGlobalList = new ArrayList();
        public static ArrayList  Puntos = new ArrayList();


        public ArrayList retornarLista2()
        {
            return Globales.imprimirInformacionGrafico;
        }

        public ArrayList retornarPuntos()
        {
            return Globales.Puntos;
        }

        public void agregarPuntos(double valor)
        {
            Puntos.Add(valor);
        }



        public ArrayList retornarLista()
        {
            return Globales.MyGlobalList;
        }


        public Globales instanciacion()
        {
            if(instancia == null)
            {
                instancia = new Globales();
            }
            return instancia;
        }

        public void agregar(String link)
        {
            Globales.MyGlobalList.Add(link);

        }


        
    }
}
