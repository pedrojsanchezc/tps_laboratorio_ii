using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;

            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);

            resultado = Calculadora.Operar(operando1, operando2, char.Parse(operador));

            return resultado;
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text == "")
            {
                MessageBox.Show("Debe seleccionar un operador", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (double.TryParse(txtNumero1.Text, out double num1) && double.TryParse(txtNumero2.Text, out double num2))
            {
                lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
                lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}");
            }
            else
            {
                MessageBox.Show("Debe ingresar numeros", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (this.txtNumero2.Text == "0" && cmbOperador.Text == "/")
            {
                MessageBox.Show("Error. No se puede dividir por 0", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }
        public void Limpiar()
        {
            this.lstOperaciones.Items.Clear();
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            string numeroBinario = resultado.DecimalBinario(lblResultado.Text);
            lblResultado.Text = numeroBinario;
            lstOperaciones.Items.Add($"{numeroBinario}");
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            string numeroDecimal = resultado.BinarioDecimal(lblResultado.Text);
            lblResultado.Text = numeroDecimal;
            lstOperaciones.Items.Add($"{numeroDecimal}");
        }
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs formClose)
        {
            if (MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                formClose.Cancel = true;
            }
        }
    }
}
