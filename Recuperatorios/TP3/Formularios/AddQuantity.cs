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
using Excepciones;

namespace Formularios
{
    public partial class AddQuantity : Form
    {
        bool quantity;
        float priceToReturn;
        int quantityToReturn;

        public int QuantityToReturn()
        {
            return quantityToReturn;
        }
        public float PriceToReturn()
        {
            return priceToReturn;
        }

        public AddQuantity()
        {
            InitializeComponent();
        }
        public AddQuantity(bool quantity) : this()
        {
            this.quantity = quantity;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void AddQuantity_Load(object sender, EventArgs e)
        {
            if (!quantity)
            {
                this.lbl_quantity.Text = "PRECIO DEL PRODUCTO:";
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!quantity)
                {
                    priceToReturn = Validation.ValidatePrice(this.txt_quantity.Text);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    quantityToReturn = Validation.ValidateQuantity(this.txt_quantity.Text);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (ValidateDescriptionException ex)
            {
                this.lbl_messageError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
