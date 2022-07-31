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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
        }
        private void ProductTypeCombo_Load(object sender, EventArgs e)
        {
            cmb_Types.DataSource = Enum.GetValues(typeof(Product.ProducType));
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            float newPrice;
            int quantity;
            try
            {
                ValidationStrings(this);

                Validation.ValidateDescription(this.txt_descriptionProduct.Text);
                newPrice = Validation.ValidatePrice(this.txt_price.Text);
                quantity = Validation.ValidateQuantity(this.txt_quantity.Text);

                Product newProduct = new Product((Product.ProducType)this.cmb_Types.SelectedItem,
                this.txt_descriptionProduct.Text.FormatDescription(), newPrice, quantity);

                DataBase.AddProduct(newProduct);

                MessageBox.Show($"PRODUCTO AGREGADO:\n{newProduct.ShowInfoData()}");

                this.DialogResult = DialogResult.OK;

            }
            catch (ValidateStrings ex)
            {
                this.lbl_messageError.Text = ex.Message;
            }
            catch (ValidateDescriptionException ex)
            {
                this.lbl_messageError.Text = ex.Message;
            }
            catch (ValidationDataException ex)
            {
                this.lbl_messageError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static void ValidationStrings(Form confirm)
        {
            foreach (Control item in confirm.Controls)
            {
                if (item is TextBox && string.IsNullOrEmpty(item.Text))
                {
                    throw new ValidateStrings("Faltan campos para completar");
                }
            }
        }
    }
}
