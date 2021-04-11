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
    public partial class Form : System.Windows.Forms.Form
    {
        Nodo p, q;
        LSEL L1, L2;
        string cadenaGenerada, cadenaGenerada2;
        int valorGenerado, count = 0; int[] array, lista;

        public Form()
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

        private void CrearArreglo()
        {
            p = L1.Inicio;
            array = new int[L1.Length(L1)];

            for (int i = 0; i < L1.Length(L1); i++)
            {
                array[i] = p.Dato;
                p = p.Liga;
            }
        }

        public int[] Getdataint(int[] arr)
        {
            count = arr.Length;
            return Combinationint(string.Join("", arr));
        }

        public int[] Combinationint(string str)
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentException("Invalid input");
            if (str.Length == 1)
                return new int[] { Convert.ToInt32(str) };

            char c = str[str.Length - 1];
             
            string[] returnArray = Array.ConvertAll(Combinationint(str.Substring(0, str.Length - 1)), x => x.ToString());
            List<string> finalArray = new List<string>();
            foreach (string s in returnArray)
                finalArray.Add(s);
            finalArray.Add(c.ToString());
            int j = 0;
            foreach (string s in returnArray)
            {
                finalArray.Add(s + c); 
                finalArray.Add(c + s);
            }
   
            returnArray = finalArray.ToArray();
            foreach (string s in returnArray)
            {
                if (str.Length == count)
                {
                    if (s.Length < str.Length - 1)
                    {
                        foreach (char k in str)
                        {
                            foreach (char m in str)
                            {
                                if (k != m && !s.Contains(k) && !s.Contains(m))
                                {
                                    finalArray.Add(s + k);
                                    finalArray.Add(s + m + k);
                                    finalArray.Add(m.ToString() + k.ToString());
                                    finalArray.Add(m + s + k);
                                }
                            }
                        }
                    }
                }
                j++;
            }

            int[] retarr = (Array.ConvertAll(finalArray.ToArray(), int.Parse)).Distinct().ToArray();
            Array.Sort(retarr);
            return retarr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            L2 = new LSEL();
            LBConvinaciones.Items.Clear();

            CrearArreglo();
            lista = Getdataint(array);

            for (int i = 0; i < lista.Length; i++)
            {
                if (Validar(lista[i])) 
                {
                    LBConvinaciones.Items.Add(lista[i]);
                }
            }
        }

        private bool Validar(int valor)
        {
            String numeros = valor.ToString();
            char[] arrayNumeros = numeros.ToCharArray();

            int suma = 0;
            foreach (char numero in arrayNumeros)
            {
                suma += int.Parse(numero.ToString());
            }

            if (suma == Convert.ToInt32(txtPS.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
