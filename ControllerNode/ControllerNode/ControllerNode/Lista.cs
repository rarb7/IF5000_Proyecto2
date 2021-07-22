using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerNode
{
    /// <summary>Clase de  la Lista Circular Doblemente enlazada parte del codigo se utlizo de www.tutorialesprogramacionya.com /csharpya/detalleconcepto.php?codigo=173&inicio=40 </summary>
    class Lista
    {
        //https://www.tutorialesprogramacionya.com/csharpya/detalleconcepto.php?codigo=173&inicio=40
        class Nodo
        {
            public int info;
            public Nodo ant, sig;
        }

        private Nodo raiz;

        public Lista()
        {
            raiz = null;
        }

        /// <summary>Inserta en los nodos deacuerdo la posicion y su numero de puerto</summary>
        /// <param name="pos">The position.</param>
        /// <param name="x">The x.</param>
        public void Insertar(int pos, int x)
        {
            if (pos <= Cantidad() + 1)
            {
                Nodo nuevo = new Nodo();
                nuevo.info = x;
                if (pos == 1)
                {
                    nuevo.sig = raiz;
                    if (raiz != null)
                        raiz.ant = nuevo;
                    raiz = nuevo;
                }
                else
                    if (pos == Cantidad() + 1)
                {
                    Nodo reco = raiz;
                    while (reco.sig != null)
                    {
                        reco = reco.sig;
                    }
                    reco.sig = nuevo;
                    nuevo.ant = reco;
                    nuevo.sig = null;
                }
                else
                {
                    Nodo reco = raiz;
                    for (int f = 1; f <= pos - 2; f++)
                        reco = reco.sig;
                    Nodo siguiente = reco.sig;
                    reco.sig = nuevo;
                    nuevo.ant = reco;
                    nuevo.sig = siguiente;
                    siguiente.ant = nuevo;
                }
            }
        }

        /// <summary>Conforme la posicion se saca el numero de puerto</summary>
        /// <param name="pos">The position.</param>
        /// <returns>System.Int32.</returns>
        public int Extraer(int pos)
        {
            if (pos <= Cantidad())
            {
                int informacion;
                if (pos == 1)
                {
                    informacion = raiz.info;
                    raiz = raiz.sig;
                    if (raiz != null)
                        raiz.ant = null;
                }
                else
                {
                    Nodo reco;
                    reco = raiz;
                    for (int f = 1; f <= pos - 2; f++)
                        reco = reco.sig;
                    Nodo prox = reco.sig;
                    reco.sig = prox.sig;
                    Nodo siguiente = prox.sig;
                    if (siguiente != null)
                        siguiente.ant = reco;
                    informacion = prox.info;
                }
                return informacion;
            }
            else
                return int.MaxValue;
        }

        /// <summary>Cantidad de nodos que tiene la lista</summary>
        /// <returns>System.Int32.</returns>
        public int Cantidad()
        {
            int cant = 0;
            Nodo reco = raiz;
            while (reco != null)
            {
                reco = reco.sig;
                cant++;
            }
            return cant;
        }



        /// <summary>Verifica si existe un puerto</summary>
        /// <param name="x">The x.</param>
        /// <returns>
        ///   <c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Existe(int x)
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                if (reco.info == x)
                    return true;
                reco = reco.sig;
            }
            return false;
        }

        public bool Vacia()
        {
            if (raiz == null)
                return true;
            else
                return false;
        }

        /// <summary>Imprime los elementos de la lista</summary>
        public void Imprimir()
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                Console.Write(reco.info + "-");
                reco = reco.sig;
            }
            Console.WriteLine();
        }
        
    }
}
