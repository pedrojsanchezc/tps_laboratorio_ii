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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }
        private void Sales_Load(object sender, EventArgs e)
        {
            Actions.ActionsDGV(dgv_sales, Store.listSaleRecord);
            this.lbl_salesTotal.Text = Sale.CountQuantitySales().ToString();
            this.lbl_countSales.Text = "$$" + Sale.CountRaised().ToString();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgv_sales_Click(object sender, EventArgs e)
        {
            Sale sale = dgv_sales.CurrentRow.DataBoundItem as Sale;
            MessageBox.Show(sale.ShowInfoData());
        }
    }
}
