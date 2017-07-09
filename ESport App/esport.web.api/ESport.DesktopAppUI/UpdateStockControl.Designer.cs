namespace ESport.DesktopAppUI
{
    partial class UpdateStockControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.updateStockLabelTitle = new System.Windows.Forms.Label();
            this.productListLabel = new System.Windows.Forms.Label();
            this.productListBox = new System.Windows.Forms.ListBox();
            this.selectedProductLabel = new System.Windows.Forms.Label();
            this.currentStockLabel = new System.Windows.Forms.Label();
            this.stockInput = new System.Windows.Forms.NumericUpDown();
            this.newStockValueLabel = new System.Windows.Forms.Label();
            this.updateStockButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stockInput)).BeginInit();
            this.SuspendLayout();
            // 
            // updateStockLabelTitle
            // 
            this.updateStockLabelTitle.AutoSize = true;
            this.updateStockLabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateStockLabelTitle.Location = new System.Drawing.Point(177, 24);
            this.updateStockLabelTitle.Name = "updateStockLabelTitle";
            this.updateStockLabelTitle.Size = new System.Drawing.Size(212, 24);
            this.updateStockLabelTitle.TabIndex = 0;
            this.updateStockLabelTitle.Text = "Administración de Stock";
            // 
            // productListLabel
            // 
            this.productListLabel.AutoSize = true;
            this.productListLabel.Location = new System.Drawing.Point(95, 60);
            this.productListLabel.Name = "productListLabel";
            this.productListLabel.Size = new System.Drawing.Size(125, 13);
            this.productListLabel.TabIndex = 1;
            this.productListLabel.Text = "Seleccione un productos";
            // 
            // productListBox
            // 
            this.productListBox.FormattingEnabled = true;
            this.productListBox.Location = new System.Drawing.Point(32, 76);
            this.productListBox.Name = "productListBox";
            this.productListBox.Size = new System.Drawing.Size(251, 264);
            this.productListBox.TabIndex = 2;
            this.productListBox.SelectedIndexChanged += new System.EventHandler(this.productListBox_SelectedIndexChanged);
            // 
            // selectedProductLabel
            // 
            this.selectedProductLabel.AutoSize = true;
            this.selectedProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedProductLabel.Location = new System.Drawing.Point(329, 76);
            this.selectedProductLabel.Name = "selectedProductLabel";
            this.selectedProductLabel.Size = new System.Drawing.Size(73, 20);
            this.selectedProductLabel.TabIndex = 3;
            this.selectedProductLabel.Text = "Producto";
            // 
            // currentStockLabel
            // 
            this.currentStockLabel.AutoSize = true;
            this.currentStockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStockLabel.Location = new System.Drawing.Point(329, 113);
            this.currentStockLabel.Name = "currentStockLabel";
            this.currentStockLabel.Size = new System.Drawing.Size(124, 20);
            this.currentStockLabel.TabIndex = 4;
            this.currentStockLabel.Text = "Cantidad actual:";
            // 
            // stockInput
            // 
            this.stockInput.Location = new System.Drawing.Point(448, 168);
            this.stockInput.Name = "stockInput";
            this.stockInput.Size = new System.Drawing.Size(120, 20);
            this.stockInput.TabIndex = 6;
            // 
            // newStockValueLabel
            // 
            this.newStockValueLabel.AutoSize = true;
            this.newStockValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newStockValueLabel.Location = new System.Drawing.Point(329, 165);
            this.newStockValueLabel.Name = "newStockValueLabel";
            this.newStockValueLabel.Size = new System.Drawing.Size(73, 20);
            this.newStockValueLabel.TabIndex = 7;
            this.newStockValueLabel.Text = "Cantidad";
            // 
            // updateStockButton
            // 
            this.updateStockButton.Location = new System.Drawing.Point(333, 222);
            this.updateStockButton.Name = "updateStockButton";
            this.updateStockButton.Size = new System.Drawing.Size(154, 37);
            this.updateStockButton.TabIndex = 8;
            this.updateStockButton.Text = "Actualizar Stock";
            this.updateStockButton.UseVisualStyleBackColor = true;
            this.updateStockButton.Click += new System.EventHandler(this.updateStockButton_Click);
            // 
            // UpdateStockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updateStockButton);
            this.Controls.Add(this.newStockValueLabel);
            this.Controls.Add(this.stockInput);
            this.Controls.Add(this.currentStockLabel);
            this.Controls.Add(this.selectedProductLabel);
            this.Controls.Add(this.productListBox);
            this.Controls.Add(this.productListLabel);
            this.Controls.Add(this.updateStockLabelTitle);
            this.Name = "UpdateStockControl";
            this.Size = new System.Drawing.Size(585, 370);
            ((System.ComponentModel.ISupportInitialize)(this.stockInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updateStockLabelTitle;
        private System.Windows.Forms.Label productListLabel;
        private System.Windows.Forms.ListBox productListBox;
        private System.Windows.Forms.Label selectedProductLabel;
        private System.Windows.Forms.Label currentStockLabel;
        private System.Windows.Forms.NumericUpDown stockInput;
        private System.Windows.Forms.Label newStockValueLabel;
        private System.Windows.Forms.Button updateStockButton;
    }
}
