using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //nuevo
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace ProyectoDeArqui
{
    public partial class Form1 : Form
    {
        private PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        double valueCPUSecuencial;

        int verficacionBoton = 0;
        int tickStart = 0;
        Timer timer1 = new Timer();

        double displaySeconds = 10;
        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane myPane = DiagramaDinamicoTiempoReal.GraphPane;
            RollingPointPairList list = new RollingPointPairList(1200);
            LineItem curve = myPane.AddCurve("Voltage", list, Color.Blue, SymbolType.None);
            timer1.Interval = 50;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            int numberOfDivisions = 4;

            myPane.XAxis.Scale.MinorStep = (int)displaySeconds / numberOfDivisions;
            myPane.XAxis.Scale.MajorStep = (int)displaySeconds / numberOfDivisions;

            myPane.XAxis.Scale.Format = "HH:mm:ss";
            //myPane.XAxis.Scale.MajorStepAuto = false;
            //myPane.XAxis.Scale.MinorStepAuto = false;
            myPane.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane.XAxis.Scale.MinorUnit = DateUnit.Second;
            DiagramaDinamicoTiempoReal.AxisChange();
            tickStart = Environment.TickCount;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LineItem curve = DiagramaDinamicoTiempoReal.GraphPane.CurveList[0] as LineItem;
            IPointListEdit list = curve.Points as IPointListEdit;
            double time = (Environment.TickCount - tickStart) / 1000.0;
            Globales global = new Globales();

            valueCPUSecuencial = this.theCPUCounter.NextValue();


            list.Add(DateTime.Now.ToOADate(), valueCPUSecuencial);
            DateTime now = DateTime.Now;
            DiagramaDinamicoTiempoReal.GraphPane.XAxis.Scale.Max = now.ToOADate();
            DiagramaDinamicoTiempoReal.GraphPane.XAxis.Scale.Min = DateTime.Now.AddSeconds(-displaySeconds).ToOADate();
            DiagramaDinamicoTiempoReal.AxisChange();
            DiagramaDinamicoTiempoReal.Invalidate();
        }


        public Form1()
        {

            InitializeComponent();

           

            CreateGraph(diagramaDinamico);
            agregarLinksALaLista();


            

        }


        public void agregarLinksALaLista()
        {
            Globales global = new Globales();
            global.agregar("https://norfipc.com/web/javascript-facil-paginas-web-ejemplos.html");
            global.agregar("https://es.answers.yahoo.com/question/index?qid=20100417134501AA281Vs");
            global.agregar("http://www.comocreartuweb.com/ejemplo-con-divs/web-paso-a-paso/mirando-el-html.html");

        }



        //prueba.Add(palabraBuscada +"          "+ contador +"          "+ link + "          "+ tiempo);
        public void imprimir(ArrayList lista)
        {
            if (lista.Count == 0)
            {
                return;
            }

            foreach (String result in lista)

            {

                listaResultados.Items.Add(result + "\n");
            }

        }

        ArrayList listaDeTodosLosResultadosParalelo = new ArrayList();
        ArrayList listaTemporal = new ArrayList();
        ArrayList listaTempora2 = new ArrayList();
        ArrayList listaDeTodasLasPalabras = new ArrayList();


        public void recursivoLlamado(ArrayList listaPalabras)

        {
            listaDeTodasLasPalabras.Clear();

            foreach (String var in listaPalabras)
            {
                listaDeTodasLasPalabras.Add(var);
            }


            listaTemporal.Clear();
            listaTempora2.Clear();




            listaTemporal.Clear();
            Console.WriteLine("busqueda RECURSIVA");

            int cont = 0;
            Console.WriteLine("largo de lista palabras..............." + listaDeTodasLasPalabras.Count);

            foreach (string palabra in listaDeTodasLasPalabras)
            {
                if (cont > 3)
                {
                    listaTempora2.Add(palabra);
                }
                listaTemporal.Add(palabra);

                cont = cont + 1;
            }



            Console.WriteLine("aaaaaa2222: " + listaTempora2.Count);

            string palabraBuscar1 = "";
            string palabraBuscar2 = "";
            string palabraBuscar3 = "";
            string palabraBuscar4 = "";


            Globales global = new Globales();
            ArrayList lista2 = global.retornarLista();

            Paralelo llamarFuncionParalela = new Paralelo();



            var process = System.Diagnostics.Process.GetCurrentProcess();
            process.ProcessorAffinity = new IntPtr(0x0009);



            int cont2 = 0;
            foreach (String var in listaTemporal)
            {
                if (cont2 == 0)
                {
                    palabraBuscar1 = var;
                }

                else if (cont2 == 1)
                {
                    palabraBuscar2 = var;
                }
                else if (cont2 == 2)
                {
                    palabraBuscar3 = var;
                }

                else if (cont2 == 3)
                {
                    palabraBuscar4 = var;
                }

                cont2 = cont2 + 1;

            }

            Parallel.Invoke(() =>
            {


                listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar1);
                agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
            },

             () =>

             {


                 listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar2);
                 agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
             },

             () =>

             {


                 listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar3);
                 agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
             },

             () =>

             {
                 listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar4);
                 agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
             });

            Console.WriteLine("largo de lista temporal: " + listaTempora2.Count);

            int contP = 0;
            foreach (string var in listaDeTodasLasPalabras)
            {
                Console.WriteLine(contP + "  " + var);
                contP = contP + 1;
            }


            if (listaTempora2.Count > 4)
            {

                intermediario(listaTempora2);


            }
            else
            {
                llamadoDeFuncionMenosDe4(listaTempora2);
            }






        }

        public void intermediario(ArrayList listaTempora2)
        {

            recursivoLlamado(listaTempora2);
        }


        ArrayList listaPalabrasImprimir = new ArrayList();


        public void agregarElementoAListaimprimir(ArrayList lista)
        {

            Console.WriteLine(" <<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<");
            if (lista.Count == 0)
            {
                return;
            }
            foreach (String var in lista)
            {
                if (var == null)
                {
                    break;
                }
                listaPalabrasImprimir.Add(var);
            }
        }
        public void llamadoDeFuncionMenosDe4(ArrayList listaPalabras)
        {

            listaDeTodosLosResultadosParalelo.Clear();

            Globales global = new Globales();
            int cantidadPalabras = listaPalabras.Count;

            Console.WriteLine("LARGO DE LA LISTA DESDE FUNION<3" + cantidadPalabras);

            string palabraBuscar1 = "";
            string palabraBuscar2 = "";
            string palabraBuscar3 = "";
            string palabraBuscar4 = "";

            ArrayList lista2 = global.retornarLista();

            Paralelo llamarFuncionParalela = new Paralelo();







            if (cantidadPalabras == 1)
            {

                var process = System.Diagnostics.Process.GetCurrentProcess();
                process.ProcessorAffinity = new IntPtr(0x0001);

                int cont = 0;
                foreach (String var in listaPalabras)
                {
                    if (cont == 0)
                    {
                        palabraBuscar1 = var;
                        Console.WriteLine("Palabra: " + palabraBuscar1);
                    }
                    cont = cont + 1;
                }

                Parallel.Invoke(() =>
                {

                    listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar1);
                    agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                });


            }
            else if (cantidadPalabras == 2)
            {

                var process = System.Diagnostics.Process.GetCurrentProcess();
                process.ProcessorAffinity = new IntPtr(0x0003);

                int cont = 0;
                foreach (String var in listaPalabras)
                {
                    if (cont == 0)
                    {
                        palabraBuscar1 = var;
                    }

                    else if (cont == 1)
                    {
                        palabraBuscar2 = var;
                    }

                    cont = cont + 1;

                }

                Parallel.Invoke(() =>
                {

                    Console.WriteLine("1");
                    listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar1);
                    agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                },

                 () =>
                 {
                     Console.WriteLine("2");
                     listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar2);

                     agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                 });

            }

            else if (cantidadPalabras == 3)

            {


                var process = System.Diagnostics.Process.GetCurrentProcess();
                process.ProcessorAffinity = new IntPtr(0x0007);

                int cont = 0;
                foreach (String var in listaPalabras)
                {
                    if (cont == 0)
                    {
                        palabraBuscar1 = var;
                    }

                    else if (cont == 1)
                    {
                        palabraBuscar2 = var;
                    }
                    else if (cont == 2)
                    {
                        palabraBuscar3 = var;
                    }

                    cont = cont + 1;

                }

                Parallel.Invoke(() =>
                {

                    Console.WriteLine("1");
                    listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar1);
                    agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                },



                () =>
                {

                    Console.WriteLine("1");
                    listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar3);
                    agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                },


                 () =>
                 {
                     Console.WriteLine("2");
                     listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar2);

                     agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                 });
            }

            else
            {


                var process = System.Diagnostics.Process.GetCurrentProcess();
                process.ProcessorAffinity = new IntPtr(0x0009);


                int cont = 0;
                foreach (String var in listaPalabras)
                {
                    if (cont == 0)
                    {
                        palabraBuscar1 = var;
                    }

                    else if (cont == 1)
                    {
                        palabraBuscar2 = var;
                    }
                    else if (cont == 2)
                    {
                        palabraBuscar3 = var;
                    }

                    else if (cont == 3)
                    {
                        palabraBuscar4 = var;
                    }

                    cont = cont + 1;

                }

                Parallel.Invoke(() =>
                {


                    listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar1);
                    agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                },

                 () =>

                 {


                     listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar2);
                     agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                 },

                 () =>

                 {


                     listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar3);
                     agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                 },

                 () =>

                 {
                     listaDeTodosLosResultadosParalelo = llamarFuncionParalela.recorrerListaDeFormaParalela(lista2, palabraBuscar4);
                     agregarElementoAListaimprimir(listaDeTodosLosResultadosParalelo);
                 });
            }




        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        static long tiempoTotal;
        static Stopwatch cronoTotal;

        ArrayList listaTemporalDePalabrasBuscadas = new ArrayList();

        public int TickStart { get; private set; }

        //lama a todoooooooooo
        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            verficacionBoton = 1;
            Globales global = new Globales();
            ArrayList lista = global.retornarLista();

            Globales.Puntos.Clear();

           


            valueCPUSecuencial = this.theCPUCounter.NextValue();
            if (valueCPUSecuencial != 0)
            {
                global.agregarPuntos(valueCPUSecuencial);
            }
            


            Globales.imprimirInformacionGrafico.Clear();

            DiagramaEstatico.Series.Clear();



            diagramaDinamico.GraphPane.CurveList[0].Clear();
            diagramaDinamico.Refresh();
            listaResultados.Items.Clear();
            textBoxContieneTiempoTotal.Clear();

            if (formaSecuencial.Checked == true)
            {

                listaResultados.Items.Clear();
                textBoxContieneTiempoTotal.Clear();
                Secuencial llamar = new Secuencial();
                String palabra = palabraABuscar.Text;


                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }

                string[] variasPalabra = palabra.Split(';');

                

                cronoTotal = Stopwatch.StartNew();

                int cont = 0;

                
                foreach (string unaPalabra in variasPalabra)
                {

                    valueCPUSecuencial = this.theCPUCounter.NextValue();
                    if (valueCPUSecuencial != 0)
                    {
                        global.agregarPuntos(valueCPUSecuencial);
                    }


                    Console.WriteLine("busqueda de palabra: " + cont);
                    ArrayList recorrido = llamar.recorrerListaDeFormaSecuencial(lista, unaPalabra);

                    

                    Console.WriteLine("largo de lista imprimir: " + recorrido.Count);
                    if (recorrido.Count != 0)
                    {

                        valueCPUSecuencial = this.theCPUCounter.NextValue();
                        if (valueCPUSecuencial != 0)
                        {
                            global.agregarPuntos(valueCPUSecuencial);
                        }
                        imprimir(recorrido);

                        

                    }

                   


                    cont = cont + 1; // cont de prueba
                }

                tiempoTotal = cronoTotal.ElapsedMilliseconds;


                


                String tiempoImprimirComoString = tiempoTotal.ToString();
                textBoxContieneTiempoTotal.Clear();

                textBoxContieneTiempoTotal.AppendText(tiempoImprimirComoString);


             


                ArrayList palabrasIguales = new ArrayList();
                Console.WriteLine(Globales.imprimirInformacionGrafico.Count + "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }

                foreach (String elemento in Globales.imprimirInformacionGrafico)
                {

                    Console.WriteLine(Globales.imprimirInformacionGrafico.Count + "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

                    Console.WriteLine(Globales.imprimirInformacionGrafico.Count + "ñññññññññññññññññññññññññññññññññññññññññññññññññññññññññññññ");
                    string[] infoGrafico = elemento.Split(';');



                    Console.WriteLine("infografico sub cero: " + infoGrafico[0]);
                    Console.WriteLine("infografico sub uno: " + infoGrafico[1]);
                    Console.WriteLine("infografico sub dos: " + infoGrafico[2]);

                    valueCPUSecuencial = this.theCPUCounter.NextValue();
                    if (valueCPUSecuencial != 0)
                    {
                        global.agregarPuntos(valueCPUSecuencial);
                    }


                    Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista");
                    if (palabrasIguales.Count != 0)
                    {

                        valueCPUSecuencial = this.theCPUCounter.NextValue();
                        if (valueCPUSecuencial != 0)
                        {
                            global.agregarPuntos(valueCPUSecuencial);
                        }

                        Console.WriteLine(palabrasIguales.Count + "   es el largo de palabrsas iguales");
                        int numero = 0;

                        int contadorAuxiliar = 0;




                        listaTemporalDePalabrasBuscadas.Clear();
                        foreach (string var in palabrasIguales)
                        {
                            listaTemporalDePalabrasBuscadas.Add(var);
                        }



                        while (numero < listaTemporalDePalabrasBuscadas.Count)
                        {

                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }


                            Console.WriteLine("contadorAuxiliar  ////////////////////" + contadorAuxiliar);
                            Console.WriteLine("2  ////////////////////" + Globales.imprimirInformacionGrafico.Count);
                            if (contadorAuxiliar == Globales.imprimirInformacionGrafico.Count - 1)
                            {

                                return;
                            }

                            
                            Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                            Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                            Console.WriteLine(numero + " contador");
                            int contadorNombre = 1;

                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }

                            Console.WriteLine("arriba palabrasIguales[contadorAuxiliar]" + palabrasIguales[contadorAuxiliar]);
                            Console.WriteLine("arriba  infoGrafico[0])" + infoGrafico[0]);
                            if (listaTemporalDePalabrasBuscadas[contadorAuxiliar].Equals(infoGrafico[0]))
                            {


                                infoGrafico[0] = infoGrafico[0] + palabrasIguales.Count;
                               
         
                                Console.WriteLine("con aumentar contador   infoGrafico[0])" + infoGrafico[0]);
                                Series serie2 = DiagramaEstatico.Series.Add(infoGrafico[0]);
                                int cantidadDeInsidenciasU2 = Int32.Parse(infoGrafico[2]);


                                serie2.Points.Add(cantidadDeInsidenciasU2);
                                palabrasIguales.Add(infoGrafico[0]);

                                valueCPUSecuencial = this.theCPUCounter.NextValue();
                                if (valueCPUSecuencial != 0)
                                {
                                    global.agregarPuntos(valueCPUSecuencial);
                                }

                                Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                                Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                                contadorNombre = contadorNombre + 1;
                                contadorAuxiliar = contadorAuxiliar + 1;
                                break;


                            }
                            contadorAuxiliar = contadorAuxiliar + 1;

                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }


                            numero = numero + 1;


                        }

                        if (listaTemporalDePalabrasBuscadas.Count == palabrasIguales.Count)
                        {

                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }

                            Console.WriteLine(infoGrafico[0] + "        rrrrrrrrr");
                            Console.WriteLine(infoGrafico[2] + "        rrrrrrrrr");
                            Series serie5 = DiagramaEstatico.Series.Add(infoGrafico[0]);
                            int cantidadDeInsidenciasU5 = Int32.Parse(infoGrafico[2]);


                           

                            serie5.Points.Add(cantidadDeInsidenciasU5);
                            palabrasIguales.Add(infoGrafico[0]);

                            Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                            Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                            listaTemporalDePalabrasBuscadas.Clear();
                            foreach (string var in palabrasIguales)
                            {

                                listaTemporalDePalabrasBuscadas.Add(var);
                            }
                            Console.WriteLine("*****");
                            Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                            Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                            
                        }

                        listaTemporalDePalabrasBuscadas.Clear();
                        foreach (string var in palabrasIguales)
                        {
                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }

                            listaTemporalDePalabrasBuscadas.Add(var);
                        }
                        continue;

                    }
                    Console.WriteLine(infoGrafico[0] + "        rrrrrrrrr");
                    Series serie = DiagramaEstatico.Series.Add(infoGrafico[0]);
                    int cantidadDeInsidenciasU = Int32.Parse(infoGrafico[2]);

                    

                    serie.Points.Add(cantidadDeInsidenciasU);
                    palabrasIguales.Add(infoGrafico[0]);

                    Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                    Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                    listaTemporalDePalabrasBuscadas.Clear();


                    valueCPUSecuencial = this.theCPUCounter.NextValue();
                    if (valueCPUSecuencial != 0)
                    {
                        global.agregarPuntos(valueCPUSecuencial);
                    }

                    foreach (string var in palabrasIguales)
                    {
                        listaTemporalDePalabrasBuscadas.Add(var);
                        
                    }
                    Console.WriteLine("*****");
                    Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                    Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                    
                }

                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }

                dibujar(diagramaDinamico);


            }

            else if (formaParalela.Checked == true)
            {
                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }


                Paralelo llamar = new Paralelo();
                listaResultados.Items.Clear();
                textBoxContieneTiempoTotal.Clear();



                listaDeTodosLosResultadosParalelo.Clear();
                listaPalabrasImprimir.Clear();


                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }


                String palabra = palabraABuscar.Text;
                string[] variasPalabra = palabra.Split(';');

                ArrayList listaPalabras = new ArrayList();

                listaPalabras.Clear();
                foreach (string unaPalabra in variasPalabra)
                {
                    listaPalabras.Add(unaPalabra);
                }

                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }


                int cont = 0;

                foreach (String var in listaPalabras)
                {
                    Console.WriteLine(cont + "     " + var);
                    cont = cont + 1;
                }

                int cantidadPalabras = listaPalabras.Count;
                Console.WriteLine("cantidad palabras: " + cantidadPalabras);


                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }

                Console.WriteLine("cantidad elementos lista: " + listaPalabras.Count);



                ArrayList lista2 = global.retornarLista();

                Paralelo llamarFuncionParalela = new Paralelo();



                cronoTotal = Stopwatch.StartNew();

                if (cantidadPalabras > 4)
                {
                    valueCPUSecuencial = this.theCPUCounter.NextValue();
                    if (valueCPUSecuencial != 0)
                    {
                        global.agregarPuntos(valueCPUSecuencial);
                    }

                    recursivoLlamado(listaPalabras);


                }
                else
                {

                    valueCPUSecuencial = this.theCPUCounter.NextValue();
                    if (valueCPUSecuencial != 0)
                    {
                        global.agregarPuntos(valueCPUSecuencial);
                    }

                    llamadoDeFuncionMenosDe4(listaPalabras);


                }


                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }


                tiempoTotal = cronoTotal.ElapsedMilliseconds;

                imprimir(listaPalabrasImprimir);



                String tiempoImprimirComoString = tiempoTotal.ToString();
                textBoxContieneTiempoTotal.Clear();

                textBoxContieneTiempoTotal.AppendText(tiempoImprimirComoString);




                ArrayList palabrasIguales = new ArrayList();
                Console.WriteLine(Globales.imprimirInformacionGrafico.Count + "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

                valueCPUSecuencial = this.theCPUCounter.NextValue();
                if (valueCPUSecuencial != 0)
                {
                    global.agregarPuntos(valueCPUSecuencial);
                }

                foreach (String elemento in Globales.imprimirInformacionGrafico)
                {

                    Console.WriteLine(Globales.imprimirInformacionGrafico.Count + "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

                    Console.WriteLine(Globales.imprimirInformacionGrafico.Count + "ñññññññññññññññññññññññññññññññññññññññññññññññññññññññññññññ");
                    string[] infoGrafico = elemento.Split(';');



                    Console.WriteLine("infografico sub cero: " + infoGrafico[0]);
                    Console.WriteLine("infografico sub uno: " + infoGrafico[1]);
                    Console.WriteLine("infografico sub dos: " + infoGrafico[2]);

                    valueCPUSecuencial = this.theCPUCounter.NextValue();
                    if (valueCPUSecuencial != 0)
                    {
                        global.agregarPuntos(valueCPUSecuencial);
                    }


                    Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista");
                    if (palabrasIguales.Count != 0)
                    {

                        valueCPUSecuencial = this.theCPUCounter.NextValue();
                        if (valueCPUSecuencial != 0)
                        {
                            global.agregarPuntos(valueCPUSecuencial);
                        }

                        Console.WriteLine(palabrasIguales.Count + "   es el largo de palabrsas iguales");
                        int numero = 0;

                        int contadorAuxiliar = 0;




                        listaTemporalDePalabrasBuscadas.Clear();
                        foreach (string var in palabrasIguales)
                        {
                            listaTemporalDePalabrasBuscadas.Add(var);
                        }



                        while (numero < listaTemporalDePalabrasBuscadas.Count)
                        {

                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }


                            Console.WriteLine("contadorAuxiliar  ////////////////////" + contadorAuxiliar);
                            Console.WriteLine("2  ////////////////////" + Globales.imprimirInformacionGrafico.Count);
                            if (contadorAuxiliar == Globales.imprimirInformacionGrafico.Count - 1)
                            {

                                return;
                            }


                            Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                            Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                            Console.WriteLine(numero + " contador");
                            int contadorNombre = 1;

                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }

                            Console.WriteLine("arriba palabrasIguales[contadorAuxiliar]" + palabrasIguales[contadorAuxiliar]);
                            Console.WriteLine("arriba  infoGrafico[0])" + infoGrafico[0]);
                            if (listaTemporalDePalabrasBuscadas[contadorAuxiliar].Equals(infoGrafico[0]))
                            {


                                infoGrafico[0] = infoGrafico[0] + palabrasIguales.Count;


                                Console.WriteLine("con aumentar contador   infoGrafico[0])" + infoGrafico[0]);
                                Series serie2 = DiagramaEstatico.Series.Add(infoGrafico[0]);
                                int cantidadDeInsidenciasU2 = Int32.Parse(infoGrafico[2]);


                                serie2.Points.Add(cantidadDeInsidenciasU2);
                                palabrasIguales.Add(infoGrafico[0]);

                                valueCPUSecuencial = this.theCPUCounter.NextValue();
                                if (valueCPUSecuencial != 0)
                                {
                                    global.agregarPuntos(valueCPUSecuencial);
                                }

                                Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                                Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                                contadorNombre = contadorNombre + 1;
                                contadorAuxiliar = contadorAuxiliar + 1;
                                break;


                            }
                            contadorAuxiliar = contadorAuxiliar + 1;

                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }


                            numero = numero + 1;


                        }

                        if (listaTemporalDePalabrasBuscadas.Count == palabrasIguales.Count)
                        {

                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }

                            Console.WriteLine(infoGrafico[0] + "        rrrrrrrrr");
                            Console.WriteLine(infoGrafico[2] + "        rrrrrrrrr");
                            Series serie5 = DiagramaEstatico.Series.Add(infoGrafico[0]);
                            int cantidadDeInsidenciasU5 = Int32.Parse(infoGrafico[2]);




                            serie5.Points.Add(cantidadDeInsidenciasU5);
                            palabrasIguales.Add(infoGrafico[0]);

                            Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                            Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                            listaTemporalDePalabrasBuscadas.Clear();
                            foreach (string var in palabrasIguales)
                            {

                                listaTemporalDePalabrasBuscadas.Add(var);
                            }
                            Console.WriteLine("*****");
                            Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                            Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");

                        }

                        listaTemporalDePalabrasBuscadas.Clear();
                        foreach (string var in palabrasIguales)
                        {
                            valueCPUSecuencial = this.theCPUCounter.NextValue();
                            if (valueCPUSecuencial != 0)
                            {
                                global.agregarPuntos(valueCPUSecuencial);
                            }

                            listaTemporalDePalabrasBuscadas.Add(var);
                        }
                        continue;

                    }
                    Console.WriteLine(infoGrafico[0] + "        rrrrrrrrr");
                    Series serie = DiagramaEstatico.Series.Add(infoGrafico[0]);
                    int cantidadDeInsidenciasU = Int32.Parse(infoGrafico[2]);



                    serie.Points.Add(cantidadDeInsidenciasU);
                    palabrasIguales.Add(infoGrafico[0]);

                    Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                    Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");
                    listaTemporalDePalabrasBuscadas.Clear();


                    valueCPUSecuencial = this.theCPUCounter.NextValue();
                    if (valueCPUSecuencial != 0)
                    {
                        global.agregarPuntos(valueCPUSecuencial);
                    }

                    foreach (string var in palabrasIguales)
                    {
                        listaTemporalDePalabrasBuscadas.Add(var);

                    }
                    Console.WriteLine("*****");
                    Console.WriteLine(palabrasIguales.Count + " cantidad de largo lista  palabras iguales");
                    Console.WriteLine(listaTemporalDePalabrasBuscadas.Count + " cantidad de largo lista temporal");

                }



                dibujar(diagramaDinamico);


                
            }
        }





        private void listaResultados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            String datos = listaResultados.SelectedItem.ToString();

            string[] dato = datos.Split(' ');

            string link = dato[20];


            System.Diagnostics.Process.Start(link);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxContieneTiempoTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }




        private void dibujar(ZedGraphControl zgc)
        {
           
            
          
            if (zgc.GraphPane.CurveList.Count <= 0)
                return;
          
            LineItem curvaGrafico = zgc.GraphPane.CurveList[0] as LineItem;
            if (curvaGrafico == null)
                return;


            IPointListEdit lista = curvaGrafico.Points as IPointListEdit;


            imprimir(lista);

        }

        public void imprimir(IPointListEdit lista)
        {
            Globales global = new Globales();
            ArrayList Puntos = global.retornarPuntos();

            ZedGraphControl zgc = diagramaDinamico;
            int i;

            Console.WriteLine("AAAAAAAAAAAA  LARGO DE LA LISTA PUNTOS: " + Puntos.Count + "tiene -1");

            int contVeces = 0;
            for (i = 0; i <= Puntos.Count - 1; i++)
            {
                double var = Convert.ToDouble(Puntos[i]);
                if (var == 0)
                {
                    continue;
                }
                lista.Add(i, Convert.ToDouble(Puntos[i]));
                Console.WriteLine("puntos[i]" + Puntos[i]);
                contVeces = contVeces + 1;
            }


            Scale xScale = zgc.GraphPane.XAxis.Scale;
            if (i > xScale.Max - xScale.MajorStep)
            {
            
                xScale.Max = i + xScale.MajorStep;
                xScale.Min = xScale.Max - 30.0;
            }
          
            zgc.AxisChange();

            zgc.Invalidate();



        }



        // Build the Chart
        private void CreateGraph(ZedGraphControl zgc)
        {

            GraphPane Grafico = zgc.GraphPane;


            Grafico.Title.Text = "Diagrama Dinamico De Procesadores";

            Grafico.Title.Text = "Datos";
            Grafico.XAxis.Title.Text = "Puntos";
            Grafico.YAxis.Title.Text = "Valores de X";


            RollingPointPairList Lista = new RollingPointPairList(1200);


            LineItem curva = Grafico.AddCurve("Valores de X", Lista, Color.Blue,
 SymbolType.None);

            Grafico.XAxis.Scale.Min = 0;
        
            Grafico.XAxis.Scale.Max = 30;
            Grafico.XAxis.Scale.MinorStep = 1;
            Grafico.XAxis.Scale.MajorStep = 5;



            zgc.AxisChange();

          



        }


    }

    }