namespace Formularios
{
    partial class StoreFormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgv_Products = new System.Windows.Forms.DataGridView();
            this.btn_records = new System.Windows.Forms.Button();
            this.btn_addProduct = new System.Windows.Forms.Button();
            this.btn_addQuantity = new System.Windows.Forms.Button();
            this.btn_changePrice = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_deleteProduct = new System.Windows.Forms.Button();
            this.list_ventas = new System.Windows.Forms.ListBox();
            this.btn_generateSale = new System.Windows.Forms.Button();
            this.btn_deleteSale = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_totalPrice = new System.Windows.Forms.Label();
            this.lbl_price = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Products)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Formularios.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(927, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Formularios.Properties.Resources.principal;
            this.pictureBox2.Location = new System.Drawing.Point(-2, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(927, 376);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // dgv_Products
            // 
            this.dgv_Products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Products.Location = new System.Drawing.Point(20, 116);
            this.dgv_Products.Name = "dgv_Products";
            this.dgv_Products.RowTemplate.Height = 25;
            this.dgv_Products.Size = new System.Drawing.Size(430, 185);
            this.dgv_Products.TabIndex = 2;
            this.dgv_Products.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Products_Click);
            // 
            // btn_records
            // 
            this.btn_records.Location = new System.Drawing.Point(20, 326);
            this.btn_records.Name = "btn_records";
            this.btn_records.Size = new System.Drawing.Size(75, 23);
            this.btn_records.TabIndex = 3;
            this.btn_records.Text = "REGISTROS";
            this.btn_records.UseVisualStyleBackColor = true;
            this.btn_records.Click += new System.EventHandler(this.btn_records_Click);
            // 
            // btn_addProduct
            // 
            this.btn_addProduct.Location = new System.Drawing.Point(115, 326);
            this.btn_addProduct.Name = "btn_addProduct";
            this.btn_addProduct.Size = new System.Drawing.Size(149, 23);
            this.btn_addProduct.TabIndex = 4;
            this.btn_addProduct.Text = "AGREGAR PRODUCTO";
            this.btn_addProduct.UseVisualStyleBackColor = true;
            this.btn_addProduct.Click += new System.EventHandler(this.btn_addProduct_Click);
            // 
            // btn_addQuantity
            // 
            this.btn_addQuantity.Location = new System.Drawing.Point(270, 326);
            this.btn_addQuantity.Name = "btn_addQuantity";
            this.btn_addQuantity.Size = new System.Drawing.Size(154, 23);
            this.btn_addQuantity.TabIndex = 5;
            this.btn_addQuantity.Text = "AGREGAR CANTIDAD";
            this.btn_addQuantity.UseVisualStyleBackColor = true;
            this.btn_addQuantity.Click += new System.EventHandler(this.btn_addQuantity_Click);
            // 
            // btn_changePrice
            // 
            this.btn_changePrice.Location = new System.Drawing.Point(20, 392);
            this.btn_changePrice.Name = "btn_changePrice";
            this.btn_changePrice.Size = new System.Drawing.Size(120, 23);
            this.btn_changePrice.TabIndex = 6;
            this.btn_changePrice.Text = "CAMBIAR PRECIO";
            this.btn_changePrice.UseVisualStyleBackColor = true;
            this.btn_changePrice.Click += new System.EventHandler(this.btn_changePrice_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(177, 392);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "CANCELAR PRODUCTO";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_deleteProduct
            // 
            this.btn_deleteProduct.Location = new System.Drawing.Point(283, 392);
            this.btn_deleteProduct.Name = "btn_deleteProduct";
            this.btn_deleteProduct.Size = new System.Drawing.Size(141, 23);
            this.btn_deleteProduct.TabIndex = 8;
            this.btn_deleteProduct.Text = "ELIMINAR PRODUCTO";
            this.btn_deleteProduct.UseVisualStyleBackColor = true;
            this.btn_deleteProduct.Click += new System.EventHandler(this.btn_deleteProduct_Click);
            // 
            // list_ventas
            // 
            this.list_ventas.FormattingEnabled = true;
            this.list_ventas.ItemHeight = 15;
            this.list_ventas.Location = new System.Drawing.Point(475, 116);
            this.list_ventas.Name = "list_ventas";
            this.list_ventas.Size = new System.Drawing.Size(421, 184);
            this.list_ventas.TabIndex = 9;
            this.list_ventas.DoubleClick += new System.EventHandler(this.list_ventas_Click);
            // 
            // btn_generateSale
            // 
            this.btn_generateSale.Location = new System.Drawing.Point(494, 392);
            this.btn_generateSale.Name = "btn_generateSale";
            this.btn_generateSale.Size = new System.Drawing.Size(118, 23);
            this.btn_generateSale.TabIndex = 10;
            this.btn_generateSale.Text = "GENERAR VENTA";
            this.btn_generateSale.UseVisualStyleBackColor = true;
            this.btn_generateSale.Click += new System.EventHandler(this.btn_generateSale_Click);
            // 
            // btn_deleteSale
            // 
            this.btn_deleteSale.Location = new System.Drawing.Point(657, 392);
            this.btn_deleteSale.Name = "btn_deleteSale";
            this.btn_deleteSale.Size = new System.Drawing.Size(122, 23);
            this.btn_deleteSale.TabIndex = 11;
            this.btn_deleteSale.Text = "ELIMINAR VENTA";
            this.btn_deleteSale.UseVisualStyleBackColor = true;
            this.btn_deleteSale.Click += new System.EventHandler(this.btn_deleteSale_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(821, 392);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "GUARDAR";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_totalPrice
            // 
            this.lbl_totalPrice.AutoSize = true;
            this.lbl_totalPrice.Location = new System.Drawing.Point(608, 305);
            this.lbl_totalPrice.Name = "lbl_totalPrice";
            this.lbl_totalPrice.Size = new System.Drawing.Size(85, 15);
            this.lbl_totalPrice.TabIndex = 13;
            this.lbl_totalPrice.Text = "PRECIO TOTAL:";
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Location = new System.Drawing.Point(733, 305);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(19, 15);
            this.lbl_price.TabIndex = 14;
            this.lbl_price.Text = "$0";
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(883, -1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(42, 23);
            this.btn_close.TabIndex = 15;
            this.btn_close.Text = "X";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // StoreFormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 450);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.lbl_price);
            this.Controls.Add(this.lbl_totalPrice);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_deleteSale);
            this.Controls.Add(this.btn_generateSale);
            this.Controls.Add(this.list_ventas);
            this.Controls.Add(this.btn_deleteProduct);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_changePrice);
            this.Controls.Add(this.btn_addQuantity);
            this.Controls.Add(this.btn_addProduct);
            this.Controls.Add(this.btn_records);
            this.Controls.Add(this.dgv_Products);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StoreFormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MINI SHOP STORE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StoreFormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.StoreFormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgv_Products;
        private System.Windows.Forms.Button btn_records;
        private System.Windows.Forms.Button btn_addProduct;
        private System.Windows.Forms.Button btn_addQuantity;
        private System.Windows.Forms.Button btn_changePrice;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_deleteProduct;
        private System.Windows.Forms.ListBox list_ventas;
        private System.Windows.Forms.Button btn_generateSale;
        private System.Windows.Forms.Button btn_deleteSale;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_totalPrice;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Button btn_close;
    }
}
