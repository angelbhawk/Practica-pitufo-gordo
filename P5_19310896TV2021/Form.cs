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
        Nodo p; LSEL LstValores, LstCombinaciones;

        public Form()
        {
            InitializeComponent();
            LstValores = new LSEL();
            LstCombinaciones = new LSEL();
        }

        // Eventos

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string x = "0";
            try
            {
                x = txtPesos.Text;
                LstValores.Insertar(ref LstValores, x);
                LstValores.Mostrar(LstValores, LBPesos);
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

        private void btnConbinaciones_Click(object sender, EventArgs e)
        {
            LstCombinaciones = new LSEL();
            LBConvinaciones.Items.Clear();

            ObtenerValores();

            if (txtPS.Text != "")
            {

                p = LstCombinaciones.Inicio;
                for (int i = 0; i < LstCombinaciones.Length(LstCombinaciones); i++)
                {
                    if (Validar(p.Dato))
                    {
                        LBConvinaciones.Items.Add(p.Dato + " = " + txtPS.Text);
                    }
                    p = p.Liga;
                }
            }
            else
                MessageBox.Show("Ingrese un valor");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Métodos

        private void ObtenerValores()
        {
            LstCombinaciones = CombinarValores(ConcatenarLista());
        }

        private string ConcatenarLista()
        {
            string cadenaConcatenada = "";
            p = LstValores.Inicio;

            for (int i = 0; i < LstValores.Length(LstValores); i++)
            {
                cadenaConcatenada += p.Dato;
                p = p.Liga;
            }

            return cadenaConcatenada;
        }

        private LSEL CombinarValores(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return null;
            if (cadena.Length == 1)
            {
                LSEL LstUnitaria = new LSEL();
                LstUnitaria.Insertar(ref LstUnitaria,cadena);
                return LstUnitaria;
            }

            char c = cadena[cadena.Length - 1];

            LSEL LstCadenas = CombinarValores(cadena.Substring(0, cadena.Length - 1));
            LSEL LstFinal = new LSEL();

            p = LstCadenas.Inicio;
            for (int i = 0; i < LstCadenas.Length(LstCadenas); i++)
            {
                LstFinal.Insertar(ref LstFinal, p.Dato);
                p = p.Liga;
            }

            LstFinal.Insertar(ref LstFinal, c.ToString());

            p = LstCadenas.Inicio;
            for (int i = 0; i < LstCadenas.Length(LstCadenas); i++)
            {
                LstFinal.Insertar(ref LstFinal, p.Dato + " + " + c);
                p = p.Liga;
            }

            return LstFinal;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LBPesos.Items.Clear();
            LBConvinaciones.Items.Clear();
            txtPS.Text = "";
            txtPesos.Text = "";

            LstCombinaciones = new LSEL();
            LstValores = new LSEL();
        }

        private bool Validar(string valor)
        {
            int suma = 0;
            DataTable dt = new DataTable();
            suma = Convert.ToInt32(dt.Compute(valor, ""));

            if (suma == Convert.ToInt32(txtPS.Text))
            {
                return true;
            }
            else
                return false;
        }
    }
}