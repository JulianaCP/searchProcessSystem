using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net; //nuevo
using System.Diagnostics;


namespace ProyectoDeArqui
{
    class Secuencial
    {

        private PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");


        static Stopwatch cronoTotal, cronoBusquedaLink; 
        static long tiempoTotal, tiempoBusquedaLink;
        double valueCPUSecuencial;

        public ArrayList recorrerListaDeFormaSecuencial(ArrayList lista, String palabra)
        {
            Globales global = new Globales();
            

            ArrayList prueba = new ArrayList();


            valueCPUSecuencial = this.theCPUCounter.NextValue();
            if (valueCPUSecuencial != 0)
            {
                global.agregarPuntos(valueCPUSecuencial);
            }



            cronoTotal = Stopwatch.StartNew();

            foreach (String elementoEnLista in lista)
            {

                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }

                cronoBusquedaLink = Stopwatch.StartNew();

                using (WebClient wc = new WebClient())
                {
                    

                    string html = wc.DownloadString(elementoEnLista);
                    global.agregarPuntos(5);
                    Console.WriteLine("inicio busqueda de palabra");
                    char[] delimiterChars = { ' ', ';', ',', ':', '.', '{', '}', '[', ']', '/', '>', '<', '"', '(', ')',
                                                '?','¿','!','¡', '-', '_', '=', '+', '#', '$','%','&','@','*','°','|','¬',
                                             '≈', '¶','~'};

                    string[] words = html.Split(delimiterChars);

                    

                    int cont = 0;
                    foreach (string s in words)
                    {
                        valueCPUSecuencial = this.theCPUCounter.NextValue();
                        if (valueCPUSecuencial != 0)
                        {
                            global.agregarPuntos(valueCPUSecuencial);
                        }

                        if (s.Equals(palabra))
                        {
                           

                            cont = cont + 1;
                            
                        }
                        

                    }
                    if (cont!=0)
                    {
                        valueCPUSecuencial = this.theCPUCounter.NextValue();
                        if (valueCPUSecuencial != 0)
                        {
                            global.agregarPuntos(valueCPUSecuencial);
                        }

                        String link = elementoEnLista;
                        String palabraBuscada = palabra;
                        String contador = cont.ToString();
                        tiempoBusquedaLink = cronoBusquedaLink.ElapsedMilliseconds;
                        String tiempo = tiempoBusquedaLink.ToString();

                       

                        Globales.imprimirInformacionGrafico.Add(palabra + ";" + link + ";" + contador);


                        prueba.Add(palabraBuscada +"          "+ contador +"          "+ link + "          "+ tiempo);

                        

                    }
                    valueCPUSecuencial = this.theCPUCounter.NextValue();
                    if (valueCPUSecuencial != 0)
                    {
                        global.agregarPuntos(valueCPUSecuencial);
                    }
                    Console.WriteLine("fin busqueda de palabra");

                }

            }

            
            return prueba;

        }

    }
}
