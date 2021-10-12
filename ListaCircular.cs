using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace appListaCircularConsolaCS
{
    class ListaCircular
    {
        Nodo head;
        private Nodo nodo;
        public Nodo Head
        {
            get { return nodo; }
            set { nodo = value; }
        }

        public ListaCircular()
        {
            head = null;
        }
        public void Agregar(Nodo n)
        {
            if (head == null)
            {
                head = n;
                head.Siguiente = n;
                return;
            }
            Nodo h = head;
            //insertar al inicio
            if (n.Numero < head.Numero)
            {
                n.Siguiente = head;
                //recorrer la lista y buscar el ultimo nodo


                while (h.Siguiente != head)
                {
                    h = h.Siguiente;
                }
                h.Siguiente = n;
                //Al encontrarlo hacer que el sig de ese nodo sea n
                head = n;
                return;
            }
            while (h.Siguiente != head)
            {
                if (n.Numero < h.Siguiente.Numero)
                {
                    break;
                }
                h = h.Siguiente;
            }
            n.Siguiente = h.Siguiente;
            h.Siguiente = n;
        }
        public void Eliminar(int d)
        {
            //revisar que la lista no este vacia!!!
            if (head == null)
            {
                return;
            }
            Nodo h = head;
            if (head.Numero == d)
            {
                if (head.Siguiente == head)
                {
                    head = null;
                    return;
                }
                while (h.Siguiente == head)
                {
                    h = h.Siguiente;
                }
                h.Siguiente = head.Siguiente;
                head = head.Siguiente;
                return;
            }
            while (h.Siguiente != head)
            {
                if (h.Siguiente.Numero == d)
                {
                    break;
                }
                h = h.Siguiente;
            }
            if (h.Siguiente != head)
            {
                h.Siguiente = h.Siguiente.Siguiente;
            }
        }

        public bool Buscar(int d, ref Nodo b)
        {
            //revisar que la lista no este vacia!!!
            if (head == null)
            {
                return false;
            }
            //si el nodo a eliminar es el primero (head)
            if (head.Numero == d)
            {
                b = head;
                return true;
            }
            Nodo h = head;
            while (h.Siguiente != null)
            {
                if (h.Siguiente.Numero == d)
                {
                    return true;
                }
                h = h.Siguiente;
            }
            return false;
        }
        public void Guardar(string nombreArchivo)
        {
            Nodo h = head;
            if (head == null)
            {
                return;
            }
           nombreArchivo = "ListaCircular ";
            string path = @"C:\" +nombreArchivo+ ".txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                do
                {
                    sw.WriteLine(h.Numero + "-" + h.Nombre + " \n  ");
                    h = h.Siguiente;
                }
                while (h != head);
            }
            return;
        }
    
        public void Cargar(string nombreArchivo)
        {
            nombreArchivo = " ListaCircular ";

         string[] lineas= File.ReadAllLines(@"C:\" +nombreArchivo+ ".txt");
            foreach (string linea in lineas)
            {
                if (linea.Length==0)
                {
                    continue;
                }
                string[] datos = linea.Split('-');
                int numero = int.Parse( datos[0]);
                string nombre = datos[1];
                Nodo n = new Nodo(numero, nombre);
                Agregar(n);
            }
        }

        public override string ToString()
        {
            string lista = "Nodos : \n";
            Nodo h = head;
            if (head == null)
            {
                return lista;
            }
            do
            {
                lista += h.Numero + " - " + h.Nombre + " \n";
                h = h.Siguiente;
            }
            while (h != head);          

            return lista;
        }
    }
}
