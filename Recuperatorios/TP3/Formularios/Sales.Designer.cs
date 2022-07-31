namespace Formularios
{
    partial class Sales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_sales = new System.Windows.Forms.DataGridView();
            this.lbl_salesTotal = new System.Windows.Forms.Label();
            this.lbl_moneyOne = new System.Windows.Forms.Label();
            this.lbl_countSales = new System.Windows.Forms.Label();
            this.lbl_moneyTwo = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Formularios.Properties.Resources.principal;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(716, 334);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_sales
            //
            this.dgv_sales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sales.Location = new System.Drawing.Point(8, 32);
            this.dgv_sales.Name = "dgv_sales";
            this.dgv_sales.RowTemplate.Height = 25;
            this.dgv_sales.Size = new System.Drawing.Size(695, 150);
            this.dgv_sales.TabIndex = 1;
            this.dgv_sales.DoubleClick += new System.EventHandler(this.dgv_sales_Click);

            // 
            // lbl_salesTotal
            // 
            this.lbl_salesTotal.AutoSize = true;
            this.lbl_salesTotal.Location = new System.Drawing.Point(251, 240);
            this.lbl_salesTotal.Name = "lbl_salesTotal";
            this.lbl_salesTotal.Size = new System.Drawing.Size(131, 15);
            this.lbl_salesTotal.TabIndex = 2;
            this.lbl_salesTotal.Text = "INGRESOS POR VENTAS";
            // 
            // lbl_moneyOne
            // 
            this.lbl_moneyOne.AutoSize = true;
            this.lbl_moneyOne.Location = new System.Drawing.Point(467, 240);
            this.lbl_moneyOne.Name = "lbl_moneyOne";
            this.lbl_moneyOne.Size = new System.Drawing.Size(22, 15);
            this.lbl_moneyOne.TabIndex = 3;
            this.lbl_moneyOne.Text = "$ 0";
            // 
            // lbl_countSales
            // 
            this.lbl_countSales.AutoSize = true;
            this.lbl_countSales.Location = new System.Drawing.Point(184, 295);
            this.lbl_countSales.Name = "lbl_countSales";
            this.lbl_countSales.Size = new System.Drawing.Size(198, 15);
            this.lbl_countSales.TabIndex = 4;
            this.lbl_countSales.Text = "ACUMULADO POR VENTAS TOTALES";
            // 
            // lbl_moneyTwo
            // 
            this.lbl_moneyTwo.AutoSize = true;
            this.lbl_moneyTwo.Location = new System.Drawing.Point(467, 295);
            this.lbl_moneyTwo.Name = "lbl_moneyTwo";
            this.lbl_moneyTwo.Size = new System.Drawing.Size(25, 15);
            this.lbl_moneyTwo.TabIndex = 5;
            this.lbl_moneyTwo.Text = "$ 0 ";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(670, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(46, 23);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);

            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 334);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_moneyTwo);
            this.Controls.Add(this.lbl_countSales);
            this.Controls.Add(this.lbl_moneyOne);
            this.Controls.Add(this.lbl_salesTotal);
            this.Controls.Add(this.dgv_sales);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTROS DE VENTAS";
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_sales;
        private System.Windows.Forms.Label lbl_salesTotal;
        private System.Windows.Forms.Label lbl_moneyOne;
        private System.Windows.Forms.Label lbl_countSales;
        private System.Windows.Forms.Label lbl_moneyTwo;
        private System.Windows.Forms.Button btn_close;
    }
}