using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Net;


namespace ProyectoDeArqui
{
    class Paralelo
    {

        private PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        double valueCPUSecuencial;
        

        static Stopwatch  cronoBusquedaLink;
        static long tiempoBusquedaLink;


        public ArrayList recorrerListaDeFormaParalela(ArrayList lista, String palabra)
        {

            Globales global = new Globales();


            Console.WriteLine("una busqueda: " + palabra);

            ArrayList prueba = new ArrayList();


            valueCPUSecuencial = this.theCPUCounter.NextValue();
            if (valueCPUSecuencial != 0)
            {
                global.agregarPuntos(valueCPUSecuencial);
            }


            foreach (String elementoEnLista in lista)
            {
                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }


                Console.WriteLine("palabra3: " + palabra);
                cronoBusquedaLink = Stopwatch.StartNew();


                using (WebClient wc = new WebClient())
                {


                    string html = wc.DownloadString(elementoEnLista);

                    Console.WriteLine("inicio busqueda de palabra");
                    char[] delimiterChars = { ' ', ';', ',', ':', '.', '{', '}', '[', ']', '/', '>', '<', '"', '(', ')',
                                                '?','¿','!','¡', '-', '_', '=', '+', '#', '$','%','&','@','*','°','|','¬',
                                             '≈', '¶','~'};



                    string[] words = html.Split(delimiterChars);
                    Console.WriteLine("palabra5: " + palabra);


                    int contadorDEPalabras = 0;
                    foreach (string s in words)
                    {
                        valueCPUSecuencial = this.theCPUCounter.NextValue();
                        if (valueCPUSecuencial != 0)
                        {
                            global.agregarPuntos(valueCPUSecuencial);
                        }

                        if (s.Equals(palabra))
                        {


                            Console.WriteLine("es igual a palabra: " + palabra);
                            contadorDEPalabras = contadorDEPalabras + 1;

                        }


                    }
                    if (contadorDEPalabras != 0)
                    {
                        valueCPUSecuencial = this.theCPUCounter.NextValue();
                        if (valueCPUSecuencial != 0)
                        {
                            global.agregarPuntos(valueCPUSecuencial);
                        }

                        String link = elementoEnLista;
                        String palabraBuscada = palabra;
                        valueCPUSecuencial = this.theCPUCounter.NextValue();
                        global.agregarPuntos(valueCPUSecuencial);

                        String contador = contadorDEPalabras.ToString();

                        tiempoBusquedaLink = cronoBusquedaLink.ElapsedMilliseconds;


                        String tiempo = tiempoBusquedaLink.ToString();
                        Globales.imprimirInformacionGrafico.Add(palabra + ";" + link + ";" + contador);

                        prueba.Add(palabraBuscada + "          " + contador + "          " + link + "          " + tiempo);


                    }


                    Console.WriteLine("fin busqueda de palabra");



                }

            }

            valueCPUSecuencial = this.theCPUCounter.NextValue();
            if (valueCPUSecuencial != 0)
            {
                global.agregarPuntos(valueCPUSecuencial);
            }


            return prueba;
            
        }
      







    }
}
