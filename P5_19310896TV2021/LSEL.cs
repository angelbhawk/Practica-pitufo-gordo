using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_19310896TV2021
{
    class LSEL
    {
        private Nodo inicio;

        public LSEL()
        {
            Inicio = null;
        }

        internal Nodo Inicio { get => inicio; set => inicio = value; }

        public void Insertar(ref LSEL lis, int x)
        {
            Nodo p = new Nodo(x);
            if (lis.Inicio == null)
            {
                lis.Inicio = p;
            }
            else
            {
                p.Liga = lis.Inicio;
                lis.Inicio = p;
            }
        }
        public void Mostrar(LSEL lis, ListBox L)
        {
            Nodo p = null;
            L.Items.Clear();
            if (lis.Inicio != null)
            {
                p = lis.Inicio;
                while (p != null)
                {
                    L.Items.Add(p.Dato);
                    p = p.Liga;
                }
            }
        }
        public void Eliminar(ref LSEL lis, int x)
        {
            Nodo p = null, q = null;
            if (lis.Inicio != null)
            {
                p = lis.Inicio;
                while (p != null)
                {
                    if (p.Dato == x)
                    {
                        if (p == lis.Inicio)
                        {
                            lis.Inicio = lis.Inicio.Liga;
                        }
                        else
                        {
                            q.Liga = p.Liga;
                        }
                        p.Liga = null;
                        p = null;
                    }
                    else
                    {
                        q = p;
                        p = p.Liga;
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay lista");
            }
        }
        public int Length(LSEL lis)
        {
            int ct = 0;
            Nodo p = null;
            if (lis.Inicio != null)
            {
                ct = 0;
                p = lis.Inicio;
                while (p != null)
                {
                    ct++;
                    p = p.Liga;
                }
            }
            return ct;
        }

        //public string EncontrarCombinacion(ref LSEL lis, int valor)
        //{
        //    Nodo p = null;
        //    LSEL aux = lis;
        //    p = lis.Inicio;
        //    int c = p.Dato;

        //    while (lis.Length(lis) != 0)
        //    {
                
        //        if(c == valor)
        //        {
        //            if()
        //        }
        //    }

        //    return "";
        //}
    }
}
