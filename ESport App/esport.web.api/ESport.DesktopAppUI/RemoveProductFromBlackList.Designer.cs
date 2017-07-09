namespace ESport.DesktopAppUI
{
    partial class RemoveProductFromBlackList
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
            this.productLabel = new System.Windows.Forms.Label();
            this.productListBox = new System.Windows.Forms.ListBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.removeProductFromBlackListButton = new System.Windows.Forms.Button();
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
            this.productListBox.Margin = new System.Windows.Forms.Padding(2);
            this.productListBox.Name = "productListBox";
            this.productListBox.Size = new System.Drawing.Size(296, 225);
            this.productListBox.TabIndex = 10;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(146, 22);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(318, 26);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Eliminar producto de lista negra";
            // 
            // removeProductFromBlackListButton
            // 
            this.removeProductFromBlackListButton.Location = new System.Drawing.Point(372, 320);
            this.removeProductFromBlackListButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeProductFromBlackListButton.Name = "removeProductFromBlackListButton";
            this.removeProductFromBlackListButton.Size = new System.Drawing.Size(74, 33);
            this.removeProductFromBlackListButton.TabIndex = 12;
            this.removeProductFromBlackListButton.Text = "Eliminar";
            this.removeProductFromBlackListButton.UseVisualStyleBackColor = true;
            this.removeProductFromBlackListButton.Click += new System.EventHandler(this.removeProductFromBlackListButton_Click);
            // 
            // RemoveProductFromBlackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeProductFromBlackListButton);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.productListBox);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RemoveProductFromBlackList";
            this.Size = new System.Drawing.Size(585, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.ListBox productListBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button removeProductFromBlackListButton;
    }
}
