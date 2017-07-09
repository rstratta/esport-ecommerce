namespace ImportTxt
{
    partial class ImportTxtUI
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
            this.btnImportTxt = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.importProductTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImportTxt
            // 
            this.btnImportTxt.Location = new System.Drawing.Point(91, 110);
            this.btnImportTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnImportTxt.Name = "btnImportTxt";
            this.btnImportTxt.Size = new System.Drawing.Size(79, 33);
            this.btnImportTxt.TabIndex = 0;
            this.btnImportTxt.Text = "Importar Txt";
            this.btnImportTxt.UseVisualStyleBackColor = true;
            this.btnImportTxt.Click += new System.EventHandler(this.btnImportTxt_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 110);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 33);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // importProductTitle
            // 
            this.importProductTitle.AutoSize = true;
            this.importProductTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importProductTitle.Location = new System.Drawing.Point(91, 38);
            this.importProductTitle.Name = "importProductTitle";
            this.importProductTitle.Size = new System.Drawing.Size(248, 24);
            this.importProductTitle.TabIndex = 2;
            this.importProductTitle.Text = "Importación de productos";
            // 
            // ImportTxtUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 157);
            this.Controls.Add(this.importProductTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImportTxt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ImportTxtUI";
            this.Text = "ImportTxtUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportTxt;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label importProductTitle;
    }
}