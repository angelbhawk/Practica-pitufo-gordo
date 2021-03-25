using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_19310896TV2021
{
    public partial class Form1 : Form
    {
        Nodo p, q;
        LSEL L1, L2;
        string cadenaGenerada;
        int valorGenerado;

        public Form1()
        {
            InitializeComponent();
            L1 = new LSEL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                x = int.Parse(txtPesos.Text);
                L1.Insertar(ref L1, x);
                L1.Mostrar(L1, LBPesos);
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message);
                throw;
            }
            finally
            {
                txtPesos.Clear();
                txtPesos.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool ComprobarExistencia(string Cadena)
        {
            int valorBuscado = Convert.ToInt32(Cadena);
            q = L2.Inicio;

            for (int i = 0; i < L2.Length(L2); i++)
            {
                if(valorBuscado == q.Dato)
                {
                    return false;
                }
                q = q.Liga;
            }
            return true;
        }

        private string GenerarCadena()
        {
            int cadenaRequerida = Convert.ToInt32(txtPS.Text), e;
            p = L1.Inicio; // agarra el primer valor de la lista

            cadenaGenerada = "";
            e = 0;
            valorGenerado = 0;

            for (int i = 0; i < L1.Length(L1); i++)
            {
                e = p.Dato;
                cadenaGenerada += e; // con cada iteracion le suma un valor de la lista a la cadena

                valorGenerado += e;
                p = p.Liga; // recorre la lista


                if (valorGenerado == cadenaRequerida)
                {
                    if (ComprobarExistencia(Convert.ToString(cadenaGenerada)))
                    {
                        L1.Eliminar(ref L1, L1.Inicio.Dato);
                        int vi = Convert.ToInt32(cadenaGenerada);
                        L2.Insertar(ref L2, vi);
                        valorGenerado = 0;
                        return Convert.ToString(cadenaGenerada);
                    }
                }
            }
            L1.Eliminar(ref L1, L1.Inicio.Dato);
            return "";
        }

        private string ProcesarCadena(string c)
        {
            string r = "";
            for(int i = 0; i < c.Length; i++)
            {
                if(i+1 == c.Length) 
                {
                    r += c[i] + " = " + Convert.ToInt32(txtPS.Text);
                }
                else
                    r += c[i] + " + ";
            }
            return r;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            L2 = new LSEL();
            LBConvinaciones.Items.Clear();
            while (L1.Length(L1) != 0)
            {
                string res = GenerarCadena();
                if(res != "")
                    LBConvinaciones.Items.Add(ProcesarCadena(res));
            }
        }
    }
}
