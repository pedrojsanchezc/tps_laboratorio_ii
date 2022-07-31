namespace Formularios
{
    partial class AddProduct
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
            this.lbl_product = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_price = new System.Windows.Forms.Label();
            this.lbl_quantityProduct = new System.Windows.Forms.Label();
            this.cmb_Types = new System.Windows.Forms.ComboBox();
            this.txt_descriptionProduct = new System.Windows.Forms.TextBox();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_quantity = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_messageError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Formularios.Properties.Resources.principal;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(655, 332);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_product
            // 
            this.lbl_product.AutoSize = true;
            this.lbl_product.Location = new System.Drawing.Point(166, 71);
            this.lbl_product.Name = "lbl_product";
            this.lbl_product.Size = new System.Drawing.Size(113, 15);
            this.lbl_product.TabIndex = 1;
            this.lbl_product.Text = "TIPO DE PRODUCTO";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(117, 122);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(162, 15);
            this.lbl_description.TabIndex = 2;
            this.lbl_description.Text = "DESCRIPCION DE PRODUCTO";
            // 
            // lbl_price
            // 
            this.lbl_price.AutoSize = true;
            this.lbl_price.Location = new System.Drawing.Point(232, 163);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(47, 15);
            this.lbl_price.TabIndex = 3;
            this.lbl_price.Text = "PRECIO";
            // 
            // lbl_quantityProduct
            // 
            this.lbl_quantityProduct.AutoSize = true;
            this.lbl_quantityProduct.Location = new System.Drawing.Point(214, 209);
            this.lbl_quantityProduct.Name = "lbl_quantityProduct";
            this.lbl_quantityProduct.Size = new System.Drawing.Size(65, 15);
            this.lbl_quantityProduct.TabIndex = 4;
            this.lbl_quantityProduct.Text = "CANTIDAD";
            // 
            // cmb_Types
            // 
            this.cmb_Types.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Types.FormattingEnabled = true;
            this.cmb_Types.Location = new System.Drawing.Point(302, 63);
            this.cmb_Types.Name = "cmb_Types";
            this.cmb_Types.Size = new System.Drawing.Size(121, 23);
            this.cmb_Types.TabIndex = 5;
            // 
            // txt_descriptionProduct
            // 
            this.txt_descriptionProduct.Location = new System.Drawing.Point(302, 114);
            this.txt_descriptionProduct.Name = "txt_descriptionProduct";
            this.txt_descriptionProduct.Size = new System.Drawing.Size(121, 23);
            this.txt_descriptionProduct.TabIndex = 6;
            // 
            // txt_price
            // 
            this.txt_price.Location = new System.Drawing.Point(302, 160);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(121, 23);
            this.txt_price.TabIndex = 7;
            // 
            // txt_quantity
            // 
            this.txt_quantity.Location = new System.Drawing.Point(302, 209);
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.Size = new System.Drawing.Size(121, 23);
            this.txt_quantity.TabIndex = 8;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(214, 274);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "AGREGAR";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);

            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(319, 274);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "CANCELAR";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);

            // 
            // lbl_messageError
            // 
            this.lbl_messageError.AutoSize = true;
            this.lbl_messageError.ForeColor = System.Drawing.Color.Red;
            this.lbl_messageError.Location = new System.Drawing.Point(150, 174);
            this.lbl_messageError.Name = "lbl_messageError";
            this.lbl_messageError.Size = new System.Drawing.Size(0, 15);
            this.lbl_messageError.TabIndex = 12;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 330);
            this.Controls.Add(this.lbl_messageError);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_quantity);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.txt_descriptionProduct);
            this.Controls.Add(this.cmb_Types);
            this.Controls.Add(this.lbl_quantityProduct);
            this.Controls.Add(this.lbl_price);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.lbl_product);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CARGA DE PRODUCTOS";
            this.Load += new System.EventHandler(this.ProductTypeCombo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_product;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.Label lbl_price;
        private System.Windows.Forms.Label lbl_quantityProduct;
        private System.Windows.Forms.ComboBox cmb_Types;
        private System.Windows.Forms.TextBox txt_descriptionProduct;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.TextBox txt_quantity;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_messageError;
    }
}