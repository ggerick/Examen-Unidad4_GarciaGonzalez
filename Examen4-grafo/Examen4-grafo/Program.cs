using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen4_Grafos
{
    class Grafo
    {

        public int Vertices;
        List<int>[] lista;
        public Grafo(int valor) 
        {
            Vertices = valor; 
            lista = new List<int>[valor]; 
            for (int i = 0; i < valor; i++) 
            {
                lista[i] = new List<int>();
            }
        }

        public void Agregar(int Indice, int Valor) 
        {
            lista[Indice].Add(Valor); 
        }



        public void DFS(int value, int Dato) // Deep First Search
        {
            List<string> arrive = new List<string>();
            if (Dato == 1 || Dato == 2)
            {
                arrive.Add("Boston");
                arrive.Add("Chicago");
                arrive.Add("Denver");
                arrive.Add("LA");
                arrive.Add("New York");
                arrive.Add("San Francisco");
                arrive.Add("Miami");
                arrive.Add("Atlanta");
            }
            if (Dato == 3)
            {
                arrive.Add("Atlanta");
                arrive.Add("Chicago");
                arrive.Add("San Francisco");
                arrive.Add("Boston");
                arrive.Add("Denver");
                arrive.Add("LA");
                arrive.Add("New York");
                arrive.Add("Miami");
            }
            if (Dato == 4)
            {
                arrive.Add("Denver");
                arrive.Add("Chicago");
                arrive.Add("New York");
                arrive.Add("Atlanta");
                arrive.Add("San Francisco");
                arrive.Add("Boston");
                arrive.Add("LA");
                arrive.Add("Miami");
            }

            bool[] Visita = new bool[Vertices]; //  arreglo boleano del tamaño de nuestros vertices 
            Stack<int> stck = new Stack<int>(); // creamos una pila
            Visita[value] = true; // el valor del arreglo para saber si visitamos la ciudad
            stck.Push(value); // agrega el valor parametro a la pila
            Console.WriteLine("La ruta más corta es: ");          
            while (stck.Count != 0) // mientras la pila tenga elementos
            {
                value = stck.Pop(); // el valor se iguala al ultimo valor de la pila qe va a sacar
                Console.Write("{0}-> ", arrive[value]); // agrega el valor                
                foreach (int item in lista[value])
                {
                    if (!Visita[item]) 
                    {
                        Visita[item] = true; 
                        stck.Push(item); 
                    }
                }
            }
          
        }
    }
    class Exammm
    {

        public void Grafo()
        {
            Ciclo:
            Console.Clear();
            Console.WriteLine("Elige un destino:\n1.- Boston -> LA\n2.- New York -> San Francisco\n3.- Atlanta -> San Francisco\n4.- Denver -> New York");
            int opc = int.Parse(Console.ReadLine());
            if (opc == 1)
            {
                Grafo BostonLA = new Grafo(5);
                BostonLA.Agregar(0, 1);
                BostonLA.Agregar(1, 2);
                BostonLA.Agregar(2, 3);
                BostonLA.DFS(0, 1);
                Console.ReadKey();
                goto Ciclo;
            }

            if (opc == 2)
            {
                Grafo NYSF = new Grafo(7);
                NYSF.Agregar(0, 1);
                NYSF.Agregar(1, 2);
                NYSF.Agregar(2, 3);
                NYSF.Agregar(4, 5);
                NYSF.DFS(4, 2);
                Console.ReadKey();
                goto Ciclo;
            }

            if (opc == 3)
            {
                Grafo AtlSF = new Grafo(4);
                AtlSF.Agregar(0, 1);
                AtlSF.Agregar(1, 2);
                AtlSF.DFS(0, 3);
                Console.ReadKey();
                goto Ciclo;
            }

            if (opc == 4)
            {
                Grafo DnverNY = new Grafo(4);
                DnverNY.Agregar(0, 1);
                DnverNY.Agregar(1, 2);
                DnverNY.DFS(0, 4);
              
                Console.ReadKey();
                goto Ciclo;
            }



        }




    }
    class Program
    {
        public static void Main()
        {
            Exammm grafo = new Exammm();
            grafo.Grafo();


        }
  
        }
    }
