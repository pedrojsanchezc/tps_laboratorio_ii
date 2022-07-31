namespace Formularios
{
    partial class AddQuantity
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
            this.lbl_quantity = new System.Windows.Forms.Label();
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
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(490, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_quantity
            // 
            this.lbl_quantity.AutoSize = true;
            this.lbl_quantity.Location = new System.Drawing.Point(53, 106);
            this.lbl_quantity.Name = "lbl_quantity";
            this.lbl_quantity.Size = new System.Drawing.Size(152, 15);
            this.lbl_quantity.TabIndex = 1;
            this.lbl_quantity.Text = "CANTIDAD DEL PRODUCTO";
            // 
            // txt_quantity
            // 
            this.txt_quantity.Location = new System.Drawing.Point(254, 106);
            this.txt_quantity.Name = "txt_quantity";
            this.txt_quantity.Size = new System.Drawing.Size(121, 23);
            this.txt_quantity.TabIndex = 2;
            this.txt_quantity.Text = "0";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(130, 180);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 3;
            this.btn_add.Text = "AGREGAR";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);

            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(254, 180);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 4;
            this.btn_cancel.Text = "CANCELAR";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);

            // 
            // lbl_messageError
            // 
            this.lbl_messageError.TabIndex = 6;
            this.lbl_messageError.AutoSize = true;
            this.lbl_messageError.ForeColor = System.Drawing.Color.Red;
            this.lbl_messageError.Location = new System.Drawing.Point(12, 68);
            this.lbl_messageError.Name = "lbl_messageError";
            this.lbl_messageError.Size = new System.Drawing.Size(0, 15);

            // 
            // AddQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 271);
            this.Controls.Add(this.lbl_messageError);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_quantity);
            this.Controls.Add(this.lbl_quantity);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGREGAR CANTIDAD";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Load += new System.EventHandler(this.AddQuantity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_quantity;
        private System.Windows.Forms.TextBox txt_quantity;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_messageError;
    }
}