namespace ESport.DesktopAppUI
{
    partial class ProductImporter
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
            this.productImporterTitleLable = new System.Windows.Forms.Label();
            this.productImporterTypeComboBox = new System.Windows.Forms.ComboBox();
            this.invokeProductImporterButton = new System.Windows.Forms.Button();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // productImporterTitleLable
            // 
            this.productImporterTitleLable.AutoSize = true;
            this.productImporterTitleLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productImporterTitleLable.Location = new System.Drawing.Point(176, 25);
            this.productImporterTitleLable.Name = "productImporterTitleLable";
            this.productImporterTitleLable.Size = new System.Drawing.Size(225, 24);
            this.productImporterTitleLable.TabIndex = 0;
            this.productImporterTitleLable.Text = "Importación de Productos";
            // 
            // productImporterTypeComboBox
            // 
            this.productImporterTypeComboBox.FormattingEnabled = true;
            this.productImporterTypeComboBox.Location = new System.Drawing.Point(27, 76);
            this.productImporterTypeComboBox.Name = "productImporterTypeComboBox";
            this.productImporterTypeComboBox.Size = new System.Drawing.Size(332, 21);
            this.productImporterTypeComboBox.TabIndex = 1;
            // 
            // invokeProductImporterButton
            // 
            this.invokeProductImporterButton.Location = new System.Drawing.Point(421, 69);
            this.invokeProductImporterButton.Name = "invokeProductImporterButton";
            this.invokeProductImporterButton.Size = new System.Drawing.Size(96, 33);
            this.invokeProductImporterButton.TabIndex = 2;
            this.invokeProductImporterButton.Text = "Importar";
            this.invokeProductImporterButton.UseVisualStyleBackColor = true;
            this.invokeProductImporterButton.Click += new System.EventHandler(this.invokeProductImporterButton_Click);
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(27, 131);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(490, 225);
            this.logListBox.TabIndex = 3;
            // 
            // ProductImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.invokeProductImporterButton);
            this.Controls.Add(this.productImporterTypeComboBox);
            this.Controls.Add(this.productImporterTitleLable);
            this.Name = "ProductImporter";
            this.Size = new System.Drawing.Size(585, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label productImporterTitleLable;
        private System.Windows.Forms.ComboBox productImporterTypeComboBox;
        private System.Windows.Forms.Button invokeProductImporterButton;
        private System.Windows.Forms.ListBox logListBox;
    }
}
