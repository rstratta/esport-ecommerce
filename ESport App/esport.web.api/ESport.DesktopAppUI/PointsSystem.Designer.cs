namespace ESport.DesktopAppUI
{
    partial class PointsSystem
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
            this.labeltitulo = new System.Windows.Forms.Label();
            this.pointSystemConfigurationButton = new System.Windows.Forms.Button();
            this.pointSystemConfigurationValue = new System.Windows.Forms.NumericUpDown();
            this.labelvalor = new System.Windows.Forms.Label();
            this.currentConfigurationLabel = new System.Windows.Forms.Label();
            this.currentPointConfigurationValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pointSystemConfigurationValue)).BeginInit();
            this.SuspendLayout();
            // 
            // labeltitulo
            // 
            this.labeltitulo.AutoSize = true;
            this.labeltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltitulo.Location = new System.Drawing.Point(146, 22);
            this.labeltitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeltitulo.Name = "labeltitulo";
            this.labeltitulo.Size = new System.Drawing.Size(283, 26);
            this.labeltitulo.TabIndex = 7;
            this.labeltitulo.Text = "Modificar sistema de puntos";
            // 
            // pointSystemConfigurationButton
            // 
            this.pointSystemConfigurationButton.Location = new System.Drawing.Point(259, 241);
            this.pointSystemConfigurationButton.Margin = new System.Windows.Forms.Padding(2);
            this.pointSystemConfigurationButton.Name = "pointSystemConfigurationButton";
            this.pointSystemConfigurationButton.Size = new System.Drawing.Size(74, 33);
            this.pointSystemConfigurationButton.TabIndex = 6;
            this.pointSystemConfigurationButton.Text = "Aceptar";
            this.pointSystemConfigurationButton.UseVisualStyleBackColor = true;
            this.pointSystemConfigurationButton.Click += new System.EventHandler(this.pointSystemConfigurationButton_Click);
            // 
            // pointSystemConfigurationValue
            // 
            this.pointSystemConfigurationValue.Location = new System.Drawing.Point(323, 146);
            this.pointSystemConfigurationValue.Margin = new System.Windows.Forms.Padding(2);
            this.pointSystemConfigurationValue.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.pointSystemConfigurationValue.Name = "pointSystemConfigurationValue";
            this.pointSystemConfigurationValue.Size = new System.Drawing.Size(80, 20);
            this.pointSystemConfigurationValue.TabIndex = 5;
            // 
            // labelvalor
            // 
            this.labelvalor.AutoSize = true;
            this.labelvalor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelvalor.Location = new System.Drawing.Point(147, 142);
            this.labelvalor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelvalor.Name = "labelvalor";
            this.labelvalor.Size = new System.Drawing.Size(168, 24);
            this.labelvalor.TabIndex = 4;
            this.labelvalor.Text = "Valor del punto:   $";
            // 
            // currentConfigurationLabel
            // 
            this.currentConfigurationLabel.AutoSize = true;
            this.currentConfigurationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentConfigurationLabel.Location = new System.Drawing.Point(65, 101);
            this.currentConfigurationLabel.Name = "currentConfigurationLabel";
            this.currentConfigurationLabel.Size = new System.Drawing.Size(255, 24);
            this.currentConfigurationLabel.TabIndex = 8;
            this.currentConfigurationLabel.Text = "Valor del punto actualmente :";
            // 
            // currentPointConfigurationValue
            // 
            this.currentPointConfigurationValue.AutoSize = true;
            this.currentPointConfigurationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPointConfigurationValue.Location = new System.Drawing.Point(319, 101);
            this.currentPointConfigurationValue.Name = "currentPointConfigurationValue";
            this.currentPointConfigurationValue.Size = new System.Drawing.Size(0, 24);
            this.currentPointConfigurationValue.TabIndex = 9;
            // 
            // PointsSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currentPointConfigurationValue);
            this.Controls.Add(this.currentConfigurationLabel);
            this.Controls.Add(this.labeltitulo);
            this.Controls.Add(this.pointSystemConfigurationButton);
            this.Controls.Add(this.pointSystemConfigurationValue);
            this.Controls.Add(this.labelvalor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PointsSystem";
            this.Size = new System.Drawing.Size(585, 370);
            ((System.ComponentModel.ISupportInitialize)(this.pointSystemConfigurationValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labeltitulo;
        private System.Windows.Forms.Button pointSystemConfigurationButton;
        private System.Windows.Forms.NumericUpDown pointSystemConfigurationValue;
        private System.Windows.Forms.Label labelvalor;
        private System.Windows.Forms.Label currentConfigurationLabel;
        private System.Windows.Forms.Label currentPointConfigurationValue;
    }
}
