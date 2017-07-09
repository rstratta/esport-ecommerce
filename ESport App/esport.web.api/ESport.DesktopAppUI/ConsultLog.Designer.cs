namespace ESport.DesktopAppUI
{
    partial class ConsultLog
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.finishDateFilter = new System.Windows.Forms.DateTimePicker();
            this.initDateFilter = new System.Windows.Forms.DateTimePicker();
            this.filterLogButton = new System.Windows.Forms.Button();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.labeltitulo = new System.Windows.Forms.Label();
            this.allLogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Seleccione las fechas entre las cuales desea consultar el log";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Desde:";
            // 
            // finishDateFilter
            // 
            this.finishDateFilter.Location = new System.Drawing.Point(282, 71);
            this.finishDateFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.finishDateFilter.Name = "finishDateFilter";
            this.finishDateFilter.Size = new System.Drawing.Size(135, 20);
            this.finishDateFilter.TabIndex = 17;
            // 
            // initDateFilter
            // 
            this.initDateFilter.Location = new System.Drawing.Point(87, 71);
            this.initDateFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.initDateFilter.Name = "initDateFilter";
            this.initDateFilter.Size = new System.Drawing.Size(135, 20);
            this.initDateFilter.TabIndex = 16;
            // 
            // filterLogButton
            // 
            this.filterLogButton.Location = new System.Drawing.Point(430, 69);
            this.filterLogButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filterLogButton.Name = "filterLogButton";
            this.filterLogButton.Size = new System.Drawing.Size(75, 27);
            this.filterLogButton.TabIndex = 15;
            this.filterLogButton.Text = "Filtrar";
            this.filterLogButton.UseVisualStyleBackColor = true;
            this.filterLogButton.Click += new System.EventHandler(this.filterLogButton_Click);
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.Location = new System.Drawing.Point(47, 111);
            this.logListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(535, 225);
            this.logListBox.TabIndex = 14;
            // 
            // labeltitulo
            // 
            this.labeltitulo.AutoSize = true;
            this.labeltitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltitulo.Location = new System.Drawing.Point(221, 10);
            this.labeltitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeltitulo.Name = "labeltitulo";
            this.labeltitulo.Size = new System.Drawing.Size(140, 26);
            this.labeltitulo.TabIndex = 13;
            this.labeltitulo.Text = "Consultar log";
            // 
            // allLogButton
            // 
            this.allLogButton.Location = new System.Drawing.Point(507, 69);
            this.allLogButton.Name = "allLogButton";
            this.allLogButton.Size = new System.Drawing.Size(75, 26);
            this.allLogButton.TabIndex = 21;
            this.allLogButton.Text = "Todos";
            this.allLogButton.UseVisualStyleBackColor = true;
            this.allLogButton.Click += new System.EventHandler(this.allLogButton_Click);
            // 
            // ConsultLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.allLogButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finishDateFilter);
            this.Controls.Add(this.initDateFilter);
            this.Controls.Add(this.filterLogButton);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.labeltitulo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ConsultLog";
            this.Size = new System.Drawing.Size(585, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker finishDateFilter;
        private System.Windows.Forms.DateTimePicker initDateFilter;
        private System.Windows.Forms.Button filterLogButton;
        private System.Windows.Forms.ListBox logListBox;
        private System.Windows.Forms.Label labeltitulo;
        private System.Windows.Forms.Button allLogButton;
    }
}
