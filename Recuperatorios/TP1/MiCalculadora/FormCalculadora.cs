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
            this.cmb_operador.Items.Add("");
            this.cmb_operador.Items.Add("+");
            this.cmb_operador.Items.Add("-");
            this.cmb_operador.Items.Add("*");
            this.cmb_operador.Items.Add("/");
            this.Limpiar();
        }
        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        private void Limpiar()
        {
            this.cmb_operador.SelectedIndex = 0;
            this.lbl_resultado.Text = "0";
            this.txt_numeroUno.Clear();
            this.txt_numeroDos.Clear();
            this.btn_convertirADecimal.Enabled = false;
            this.btn_convertirABinario.Enabled = false;
        }
        private static double Operar(string num1, string num2, string operador)
        {
            Operando operatorNum1 = new Operando(num1);
            Operando operatorNum2 = new Operando(num2);
            char operatorCharacter;
            double result;
            char.TryParse(operador, out operatorCharacter);
            result = Calculadora.Operar(operatorNum1, operatorNum2, operatorCharacter);
            return result;
        }
        private void btn_operar_Click(object sender, EventArgs e)
        {
            double result;
            StringBuilder sb = new StringBuilder();
            this.txt_numeroDos.Text = this.txt_numeroDos.Text.Replace('.', ',');
            this.txt_numeroUno.Text = this.txt_numeroUno.Text.Replace('.', ',');
            if (double.TryParse(this.txt_numeroUno.Text, out double numberExam) && double.TryParse(this.txt_numeroDos.Text, out numberExam))
            {
                if (this.cmb_operador.Text == " ")
                {
                    this.cmb_operador.SelectedIndex = 1;
                }
                result = Operar(this.txt_numeroUno.Text, this.txt_numeroDos.Text, cmb_operador.Text);
                if (result != double.MinValue)
                {
                    this.btn_convertirADecimal.Enabled = false;
                    this.btn_convertirABinario.Enabled = true;
                    sb.Append($"{this.txt_numeroUno.Text} ");
                    sb.Append($"{this.cmb_operador.Text} ");
                    sb.Append($"{this.txt_numeroDos.Text} = ");
                    sb.Append($"{result}");
                    lst_operaciones.Items.Add(sb.ToString());
                    this.lbl_resultado.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("It is not possible to divide by 0.",
                        "Incorrect Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The operations are not valid",
                        "Operations Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_convertirABinario_Click(object sender, EventArgs e)
        {
            string result;
            result = this.lbl_resultado.Text;
            this.lbl_resultado.Text = Operando.DecimalBinario(result);
            this.lst_operaciones.Items.Add($"{result} = {this.lbl_resultado.Text}");
            this.btn_convertirADecimal.Enabled = true;
            this.btn_convertirABinario.Enabled = false;
        }
        private void btn_convertirADecimal_Click(object sender, EventArgs e)
        {
            string result;
            result = this.lbl_resultado.Text;
            this.lbl_resultado.Text = Operando.BinarioDecimal(result);
            this.lst_operaciones.Items.Add($"{result} = {this.lbl_resultado.Text}");
            this.btn_convertirABinario.Enabled = true;
            this.btn_convertirADecimal.Enabled = false;
        }
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to close the program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Dispose();
            }
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}