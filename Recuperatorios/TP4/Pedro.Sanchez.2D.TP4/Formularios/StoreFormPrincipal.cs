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
using System.Threading;


namespace Formularios
{
    public partial class StoreFormPrincipal : Form
    {
        List<Product> cart;
        float price;
        CancellationTokenSource cancellationToken;


        public StoreFormPrincipal()
        {
            InitializeComponent();
            cart = new List<Product>();
            price = 0;
        }
        private async void StoreFormPrincipal_Load(object sender, EventArgs e)
        {   
            cancellationToken = new CancellationTokenSource();
            this.lbl_charging.Text = "CONECTANDO A LA DATABASE";
            this.dgv_Products.Enabled = false;
            this.list_ventas.Enabled = false;
            this.btn_addProduct.Enabled = false;
            this.btn_addQuantity.Enabled = false;
            this.btn_deleteProduct.Enabled = false;
            this.btn_changePrice.Enabled = false;
            this.btn_cancel.Enabled = false;
            this.btn_generateSale.Enabled = false;
            this.btn_deleteSale.Enabled = false;
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                List<Product> list = DataBase.GetProducts();
                if (this.btn_addProduct.InvokeRequired)
                {
                    this.btn_addProduct.BeginInvoke(new Action(() =>
                    {
                        ConnectionBBDD(list, EnableControls, ConnectionFail);
                    }));
                }
            }, cancellationToken.Token);
        }
        private void ConnectionBBDD(List<Product> list, ConnectionBBDD funcBien, ConnectionBBDD funcMal)
        {
            if (list != null)
            {
                Actions.ActionsDGV(dgv_Products, list);
                funcBien("CONEXION CORRECTA");
            }
            else
            {
                funcMal("CONEXION ERRONEA");
            }
        }
        private void EnableControls(string mensaje)
        {
            this.lbl_charging.Text = mensaje;
            this.dgv_Products.Enabled = true;
            this.list_ventas.Enabled = true;
            this.btn_addProduct.Enabled = true;
            this.btn_addQuantity.Enabled = true;
            this.btn_deleteProduct.Enabled = true;
            this.btn_changePrice.Enabled = true;
            this.btn_cancel.Enabled = true;
            this.btn_generateSale.Enabled = true;
            this.btn_deleteSale.Enabled = true;
            this.btn_records.Enabled = true;
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                if (this.lbl_charging.InvokeRequired)
                {
                    this.lbl_charging.BeginInvoke(new Action(() =>
                    {
                        this.lbl_charging.Visible = false;
                    }));
                }
            });
        }
        private void ConnectionFail(string mensaje)
        {
            MessageBox.Show(mensaje + ". COMPRUEBE SU CONEXION Y REINICIE.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.lbl_charging.Text = mensaje;
        }
        private void dgv_Products_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Product addProduct = GetProductToDGV();
                addProduct.endProduct += NotProducts;
                if (addProduct.AddProductToCart(cart))
                {
                    addProduct.RestarStock(1);
                    DataBase.ModifyProductQuantity(addProduct.Id, addProduct.Quantity);
                    this.price += addProduct.Price;
                    Actions.ActionsDGV(dgv_Products, DataBase.GetProducts());
                    ActualizationList();
                    this.lbl_price.Text = "$" + this.price.ToString();
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_generateSale_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                Sale newSale = new Sale(this.price, Sale.ProductsSold(cart));
                DataBase.AddSale(newSale);
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
                Actions.ActionsDGV(dgv_Products, DataBase.GetProducts());
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
            try
            {
                Product.ReturnProduct(cart);
                FinishSales();
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    sb.AppendLine(ex.Message);
                }

                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                Actions.ActionsDGV(dgv_Products, DataBase.GetProducts());
                addProduct.Dispose();
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cart.Count == 0)
                {
                    Product deleteProduct = GetProductToDGV();
                    if (MessageBox.Show($"¿DESEA BORRAR EL PRODUCTO?\n{deleteProduct.ShowInfoData()}",
                        "ELIMINAR PRODUCTO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataBase.DeleteProduct(deleteProduct.Id);
                        Actions.ActionsDGV(dgv_Products, DataBase.GetProducts());
                    }
                }
                else
                {
                    MessageBox.Show("Termine la venta antes de cerrar",
                        "ELIMINAR PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_changePrice_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = GetProductToDGV();
                float newPriceProduct = 0;
                AddQuantity quantityPrice = new AddQuantity(false);
                if (quantityPrice.ShowDialog() == DialogResult.OK)
                {
                    newPriceProduct = quantityPrice.QuantityToReturn();
                    quantityPrice.Dispose();
                    DataBase.ModifyProductPrice(product.Id, newPriceProduct);
                    Actions.ActionsDGV(dgv_Products, DataBase.GetProducts());
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Product GetProductToDGV()
        {
            if (dgv_Products.CurrentRow != null)
            {
                return (Product)dgv_Products.CurrentRow.DataBoundItem;
            }

            throw new ValidateProducts("No se han elegido productos");
        }
        private void btn_addQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = GetProductToDGV();

                AddQuantity quantityPrice = new AddQuantity(true);
                if (quantityPrice.ShowDialog() == DialogResult.OK)
                {
                    product.Quantity += quantityPrice.QuantityToReturn();
                    DataBase.ModifyProductQuantity(product.Id, product.Quantity);
                    quantityPrice.Dispose();
                    Actions.ActionsDGV(dgv_Products, DataBase.GetProducts());
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_deleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product Product = GetProductToDGV();
                Product.endProduct += NotProducts;
                AddQuantity quantityPrice = new AddQuantity(true);
                if (quantityPrice.ShowDialog() == DialogResult.OK)
                {
                    Product.RestarStock(quantityPrice.QuantityToReturn());
                    quantityPrice.Dispose();
                    DataBase.ModifyProductQuantity(Product.Id, Product.Quantity);
                    Actions.ActionsDGV(dgv_Products, DataBase.GetProducts());
                }
            }
            catch (ValidateProducts ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void list_ventas_Click(object sender, EventArgs e)
        {
            Product deleteProduct = (Product)list_ventas.SelectedItem;
            if (deleteProduct != null)
            {
                Product.DeleteProductToCart(deleteProduct, cart);
                price -= deleteProduct.Price;
                this.lbl_price.Text = "$" + this.price.ToString();
                ActualizationList();
                Actions.ActionsDGV(dgv_Products, DataBase.GetProducts());
            }
        }
        //private void btn_save_Click(object sender, EventArgs e)
        //{
        //    if (cart.Count == 0)
        //    {
        //        File<List<Product>>.WriteJson("listProducts", Store.listProducts);
        //        File<List<Sale>>.WriteXml("ListaSales", Store.listSaleRecord);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Guarde antes de salir",
        //            "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        //}
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void StoreFormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show($"¿DESEA SALIR?", "SALIR",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                cancellationToken.Cancel();
                if (this.cart.Count > 0)
                {
                    CancelSale();
                }
                this.Dispose();
            }
        }
        private void NotProducts(string descripcionProduct)
        {
            MessageBox.Show($"{descripcionProduct} NO HAY MAS PRODUCTOS.\n" +
                $"ACUDIR AL RESPONSABLE.");
        }
    }
}
