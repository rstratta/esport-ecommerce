namespace ESport.DesktopAppUI
{
    partial class AddProductToBlackList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.productLabel = new System.Windows.Forms.Label();
            this.productListBox = new System.Windows.Forms.ListBox();
            this.labeltitulo = new System.Windows.Forms.Label();
            this.addProductInBlackListButton = new System.Windows.Forms.Button();
            this.fullProductDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fullProductDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(148, 60);
            this.productLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(120, 13);
            this.productLabel.TabIndex = 11;
            this.productLabel.Text = "Seleccione un producto";
            // 
            // productListBox
            // 
            this.productListBox.FormattingEnabled = true;
            this.productListBox.Location = new System.Drawing.Point(150, 75);
            this.productListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productListBox.Name = "productListBox";
            this.productListBox.Size = new System.Drawing.Size(296, 225);
            this.productListBox.TabIndex = 10;
            // 
            // labeltitulo
            // 
            this.labeltitulo.AutoSize = true;
            this.labeltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltitulo.Location = new System.Drawing.Point(146, 22);
            this.labeltitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeltitulo.Name = "labeltitulo";
            this.labeltitulo.Size = new System.Drawing.Size(303, 26);
            this.labeltitulo.TabIndex = 9;
            this.labeltitulo.Text = "Agregar producto a lista negra";
            // 
            // addProductInBlackListButton
            // 
            this.addProductInBlackListButton.Location = new System.Drawing.Point(372, 320);
            this.addProductInBlackListButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addProductInBlackListButton.Name = "addProductInBlackListButton";
            this.addProductInBlackListButton.Size = new System.Drawing.Size(74, 33);
            this.addProductInBlackListButton.TabIndex = 12;
            this.addProductInBlackListButton.Text = "Agregar";
            this.addProductInBlackListButton.UseVisualStyleBackColor = true;
            this.addProductInBlackListButton.Click += new System.EventHandler(this.addProductInBlackListButton_Click);
            // 
            // fullProductDTOBindingSource
            // 
            this.fullProductDTOBindingSource.DataSource = typeof(ESport.Data.Commons.FullProductDTO);
            // 
            // AddProductToBlackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addProductInBlackListButton);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.productListBox);
            this.Controls.Add(this.labeltitulo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AddProductToBlackList";
            this.Size = new System.Drawing.Size(585, 370);
            ((System.ComponentModel.ISupportInitialize)(this.fullProductDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.ListBox productListBox;
        private System.Windows.Forms.Label labeltitulo;
        private System.Windows.Forms.Button addProductInBlackListButton;
        private System.Windows.Forms.BindingSource fullProductDTOBindingSource;
    }
}
