using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace Formularios
{
    public partial class StoreFormPrincipal : Form
    {
        List<Product> cart;
        float price;

        public StoreFormPrincipal()
        {
            InitializeComponent();
            cart = new List<Product>();
            price = 0;
        }
        private void StoreFormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Store.AddProducts();
                Actions.ActionsDGV(dgv_Products, Store.listProducts);
                Store.UploadSales();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                while (ex.InnerException != null)
                {
                    sb.AppendLine(ex.Message);
                    ex = ex.InnerException;
                }

                MessageBox.Show(sb.ToString(), "Error a la hora de abrir el Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgv_Products_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Product product = GetProductToDGV();

                if (product.AddProductToCart(cart))
                {
                    product.Quantity--;
                    this.price += product.Price;
                    Actions.ActionsDGV(dgv_Products, Store.listProducts);
                    ActualizationList();
                    this.lbl_price.Text = "$$" + this.price.ToString();
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error a la hora de mostrar el DGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_generateSale_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                Sale newSale = new Sale(this.price, Sale.ProductsSold(cart));
                Store.listSaleRecord.Add(newSale);
                MessageBox.Show($"VENTA REGISTRADA CORRECTAMENTE \n{newSale.ShowInfoData()}", "", MessageBoxButtons.OK);
                FinishSales();
            }
        }
        private void btn_deleteSale_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0 &&
                MessageBox.Show("¿DESEA CANCELAR?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CancelSale();
                Actions.ActionsDGV(dgv_Products, Store.listProducts);
            }
        }
        private void ActualizationList()
        {
            list_ventas.DataSource = null;
            list_ventas.DataSource = cart;
        }
        private void FinishSales()
        {
            cart.Clear();
            this.price = 0;
            this.lbl_price.Text = "$$" + this.price.ToString();
            ActualizationList();
        }
        private void CancelSale()
        {
            Product.ReturnProduct(cart);
            FinishSales();
        }
        private void btn_records_Click(object sender, EventArgs e)
        {
            Sales records = new Sales();

            if (records.ShowDialog() == DialogResult.OK)
            {
                records.Dispose();
            }
        }
        private void btn_addProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();

            if (addProduct.ShowDialog() == DialogResult.OK)
            {
                Actions.ActionsDGV(dgv_Products, Store.listProducts);
                addProduct.Dispose();
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cart.Count == 0)
                {
                    Product productToDelete = GetProductToDGV();

                    if (MessageBox.Show($"¿SEGURO QUE DESEA BORRAR?\n{productToDelete.ShowInfoData()}",
                        "BORRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Store.listProducts.Remove(productToDelete);
                        Actions.ActionsDGV(dgv_Products, Store.listProducts);
                    }
                }
                else
                {
                    MessageBox.Show("TERMINE LA VENTA PRIMERO, ANTES DE CERRAR.",
                        "BORRAR PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_changePrice_Click(object sender, EventArgs e)
        {
            try
            {
                Product Product = GetProductToDGV();

                AddQuantity addProduct = new AddQuantity(false);
                if (addProduct.ShowDialog() == DialogResult.OK)
                {
                    Product.Price = addProduct.PriceToReturn();
                    addProduct.Dispose();
                    Actions.ActionsDGV(dgv_Products, Store.listProducts);
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error a la hora de cambiar el precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Product GetProductToDGV()
        {
            if (dgv_Products.CurrentRow != null)
            {
                return (Product)dgv_Products.CurrentRow.DataBoundItem;
            }

            throw new ValidateProducts("No ha seleccionado un producto");
        }
        private void btn_addQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                Product Product = GetProductToDGV();

                AddQuantity addProduct = new AddQuantity(true);
                if (addProduct.ShowDialog() == DialogResult.OK)
                {
                    Product.Quantity += addProduct.QuantityToReturn();
                    addProduct.Dispose();
                    Actions.ActionsDGV(dgv_Products, Store.listProducts);
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error a la hora de ingresar la cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_deleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product Product = GetProductToDGV();

                AddQuantity addProduct = new AddQuantity(true);
                if (addProduct.ShowDialog() == DialogResult.OK)
                {
                    Product.Quantity -= addProduct.QuantityToReturn();
                    if (Product.Quantity < 0)
                    {
                        Product.Quantity = 0;
                    }
                    addProduct.Dispose();
                    Actions.ActionsDGV(dgv_Products, Store.listProducts);
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error a la hora de borrar un producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void list_ventas_Click(object sender, EventArgs e)
        {
            Product productToDelete = (Product)list_ventas.SelectedItem;

            if (productToDelete != null)
            {
                Product.DeleteProductToCart(productToDelete, cart);
                price -= productToDelete.Price;

                this.lbl_price.Text = "$$" + this.price.ToString();
                ActualizationList();
                Actions.ActionsDGV(dgv_Products, Store.listProducts);

            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                File<List<Product>>.WriteJson("listProducts", Store.listProducts);
                File<List<Sale>>.WriteXml("ListaSales", Store.listSaleRecord);
            }
            else
            {
                MessageBox.Show("Guarde primero antes de cerrar",
                    "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void StoreFormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"¿Seguro que desea salir?", "Salir",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
