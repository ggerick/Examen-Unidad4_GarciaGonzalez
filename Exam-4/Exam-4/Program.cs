using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arbolesss
{
    public class Nodo
    {
        public string dato;
        public Nodo hijo;
        public Nodo hermano;

        public Nodo()
        {
            dato = " ";
            hijo = null;
            hermano = null;

        }
    }

    public class Arbol
    {
        public Nodo raiz;
        public Nodo trabajo;
        public int i = 0;
        public int altura = 0, y = 0;

        public Arbol()
        {
            raiz = new Nodo();
        }

        public Nodo Insertar(string dato, Nodo INodo)
        {
            //Si no hay nodo donde insertar, lo definimos como raiz
            if (INodo == null)
            {
                raiz = new Nodo();
                raiz.dato = dato;

                //No hay hijo
                raiz.hijo = null;

                //No hay hermano
                raiz.hermano = null;
                y++;
                return raiz;
            }

            //Verificamos si no tiene hijo
            //Insertamos el dato como hijo
            if (INodo.hijo == null)
            {
                Nodo temporal = new Nodo();
                temporal.dato = dato;

                //Conectamos el nuevo como hijo
                INodo.hijo = temporal;
                y++;
                return temporal;

            }
            else//El nodo ya tiene un hijo y tenemos que insertarlo como hermano
            {
                trabajo = INodo.hijo;

                //Avanzamos hasta el último hermano 
                while (trabajo.hermano != null)
                {
                    trabajo = trabajo.hermano;
                }
                //Creamos un nodo temporal   
                Nodo temporal = new Nodo();
                temporal.dato = dato;

                //Unimos el temporal al ultimo hermano
                trabajo.hermano = temporal;
                y++;
                altura = (y - 2 / 2);
                return temporal;
            }
        }

        public void TransversaPreOrder(Nodo INodo)
        {
            if (INodo == null)
                return;

            //Me proceseo primero a mi? 
            for (int n = 0; n < i; n++)
                Console.Write(" ");

            Console.WriteLine(INodo.dato);

            //Lueo procesamos el hijo
            if (INodo.hijo != null)
            {
                i++;
                TransversaPreOrder(INodo.hijo);
                i--;
            }

            //Si tiene hermanos, se procesan
            if (INodo.hermano != null)
                TransversaPreOrder(INodo.hermano);
        }

        public void TransversaPostOrden(Nodo INodo)
        {
            if (INodo == null)
                return;

            //Primero se procesa al hijo
            if (INodo.hijo != null)
            {
                i++;
                TransversaPostOrden(INodo.hijo);
                i--;
            }

            //Si tengo hermanos, los procesamos
            if (INodo.hermano != null)
                TransversaPostOrden(INodo.hermano);

            //Luego hacemos un self-process
            for (int n = 0; n < i; n++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(INodo.dato);
        }

        public Nodo Buscar(string dato, Nodo INodo)
        {
            Nodo encontrado = null;
            if (INodo == null)
                return encontrado;
            if (INodo.dato.CompareTo(dato) == 0)
            {
                encontrado = INodo;
                return encontrado;
            }

            //Luegose procesa al hijo
            if (INodo.hijo != null)
            {
                encontrado = Buscar(dato, INodo.hijo);

                if (encontrado != null)
                    return encontrado;
            }

            //Si tengo hermanos, se procesan
            if (INodo.hermano != null)
            {
                encontrado = Buscar(dato, INodo.hermano);
                if (encontrado != null)
                    return encontrado;
            }

            return encontrado;
        }

        public int alturaMaxima(Nodo INodo)
        {
            if (INodo == null)
                return 0;


            int hermano = alturaMaxima(INodo.hermano);
            int hijos = alturaMaxima(INodo.hijo);

            if (hermano > hijos)
                return hermano + 1;

            else
                return hijos + 1;

        }

        public void AArboles()//Insertar los nodos en cada arbol y impresion de éstos
        {
            Console.WriteLine("\t\tArbol 1\n");
            Nodo raiz = Insertar("a", null);
            Nodo nodoB = Insertar("b", raiz);
            Insertar("c", raiz);
            Nodo nodoD = Insertar("d", raiz);
            Nodo nodoE = Insertar("e", nodoB);
            Insertar("f", nodoB);
            Nodo nodoG = Insertar("g", nodoB);
            Insertar("k", nodoE);
            Insertar("l", nodoE);
            Insertar("m", nodoE);
            Nodo nodoN = Insertar("n", nodoG);
            Insertar("r", nodoN);
            Insertar("s", nodoN);
            Nodo nodoH = Insertar("h", nodoD);
            Insertar("i", nodoD);
            Nodo nodoJ = Insertar("j", nodoD);
            Insertar("o", nodoH);
            Insertar("p", nodoJ);
            Insertar("q", nodoJ);
            Console.WriteLine("\t\tPre-order\n");
            TransversaPreOrder(raiz);
            Console.WriteLine("\t\tPost-order\n");
            TransversaPostOrden(raiz);

            Console.WriteLine("\t\tArbol 2\n");
            Nodo raiz2 = Insertar("a", null);
            Nodo nodoBB = Insertar("b", raiz2);
            Insertar("c", nodoBB);
            Insertar("d", nodoBB);
            Nodo nodoEE = Insertar("e", raiz2);
            Nodo nodoFF = Insertar("f", nodoEE);
            Insertar("g", nodoFF);
            Insertar("h", nodoFF);
            Console.WriteLine("\t\tPre-order\n");
            TransversaPreOrder(raiz2);
            Console.WriteLine("\t\tPost-order\n");
            TransversaPostOrden(raiz2);


        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Arbol arboles = new Arbol();
            arboles.AArboles();
        }
    }
}