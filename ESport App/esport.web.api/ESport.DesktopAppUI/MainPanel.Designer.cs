namespace ESport.DesktopAppUI
{
    partial class MainPanel
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
            this.mainArea = new System.Windows.Forms.Panel();
            this.lableTitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.queryLogButton = new System.Windows.Forms.Button();
            this.btnSeeBlackList = new System.Windows.Forms.Button();
            this.btnRemoveProductFromBlackList = new System.Windows.Forms.Button();
            this.btnAddProductToBlackList = new System.Windows.Forms.Button();
            this.pointSystemConfigurationButton = new System.Windows.Forms.Button();
            this.updateStockButton = new System.Windows.Forms.Button();
            this.importProductButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainArea
            // 
            this.mainArea.Location = new System.Drawing.Point(261, 70);
            this.mainArea.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.mainArea.Name = "mainArea";
            this.mainArea.Size = new System.Drawing.Size(627, 372);
            this.mainArea.TabIndex = 2;
            // 
            // lableTitle
            // 
            this.lableTitle.AutoSize = true;
            this.lableTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableTitle.Location = new System.Drawing.Point(382, 16);
            this.lableTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lableTitle.Name = "lableTitle";
            this.lableTitle.Size = new System.Drawing.Size(0, 26);
            this.lableTitle.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(100, 410);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 32);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // queryLogButton
            // 
            this.queryLogButton.Location = new System.Drawing.Point(18, 370);
            this.queryLogButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.queryLogButton.Name = "queryLogButton";
            this.queryLogButton.Size = new System.Drawing.Size(227, 26);
            this.queryLogButton.TabIndex = 19;
            this.queryLogButton.Text = "Consultar log";
            this.queryLogButton.UseVisualStyleBackColor = true;
            this.queryLogButton.Click += new System.EventHandler(this.queryLogButton_Click);
            // 
            // btnSeeBlackList
            // 
            this.btnSeeBlackList.Location = new System.Drawing.Point(18, 220);
            this.btnSeeBlackList.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSeeBlackList.Name = "btnSeeBlackList";
            this.btnSeeBlackList.Size = new System.Drawing.Size(227, 26);
            this.btnSeeBlackList.TabIndex = 15;
            this.btnSeeBlackList.Text = "Ver lista negra";
            this.btnSeeBlackList.UseVisualStyleBackColor = true;
            this.btnSeeBlackList.Click += new System.EventHandler(this.btnSeeBlackList_Click);
            // 
            // btnRemoveProductFromBlackList
            // 
            this.btnRemoveProductFromBlackList.Location = new System.Drawing.Point(18, 170);
            this.btnRemoveProductFromBlackList.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnRemoveProductFromBlackList.Name = "btnRemoveProductFromBlackList";
            this.btnRemoveProductFromBlackList.Size = new System.Drawing.Size(227, 26);
            this.btnRemoveProductFromBlackList.TabIndex = 14;
            this.btnRemoveProductFromBlackList.Text = "Eliminar producto de lista negra";
            this.btnRemoveProductFromBlackList.UseVisualStyleBackColor = true;
            this.btnRemoveProductFromBlackList.Click += new System.EventHandler(this.btnRemoveProductFromBlackList_Click);
            // 
            // btnAddProductToBlackList
            // 
            this.btnAddProductToBlackList.Location = new System.Drawing.Point(18, 120);
            this.btnAddProductToBlackList.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnAddProductToBlackList.Name = "btnAddProductToBlackList";
            this.btnAddProductToBlackList.Size = new System.Drawing.Size(227, 26);
            this.btnAddProductToBlackList.TabIndex = 13;
            this.btnAddProductToBlackList.Text = "Agregar producto a lista negra";
            this.btnAddProductToBlackList.UseVisualStyleBackColor = true;
            this.btnAddProductToBlackList.Click += new System.EventHandler(this.btnAddProductToBlackList_Click);
            // 
            // pointSystemConfigurationButton
            // 
            this.pointSystemConfigurationButton.Location = new System.Drawing.Point(18, 70);
            this.pointSystemConfigurationButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pointSystemConfigurationButton.Name = "pointSystemConfigurationButton";
            this.pointSystemConfigurationButton.Size = new System.Drawing.Size(227, 26);
            this.pointSystemConfigurationButton.TabIndex = 12;
            this.pointSystemConfigurationButton.Text = "Modificar sistema de puntos";
            this.pointSystemConfigurationButton.UseVisualStyleBackColor = true;
            this.pointSystemConfigurationButton.Click += new System.EventHandler(this.pointSystemConfigurationButton_Click);
            // 
            // updateStockButton
            // 
            this.updateStockButton.Location = new System.Drawing.Point(18, 270);
            this.updateStockButton.Name = "updateStockButton";
            this.updateStockButton.Size = new System.Drawing.Size(227, 23);
            this.updateStockButton.TabIndex = 0;
            this.updateStockButton.Text = "Actualizar Stock";
            this.updateStockButton.UseVisualStyleBackColor = true;
            this.updateStockButton.Click += new System.EventHandler(this.updateStockButton_Click);
            // 
            // importProductButton
            // 
            this.importProductButton.Location = new System.Drawing.Point(18, 320);
            this.importProductButton.Name = "importProductButton";
            this.importProductButton.Size = new System.Drawing.Size(227, 23);
            this.importProductButton.TabIndex = 21;
            this.importProductButton.Text = "Importar Productos";
            this.importProductButton.UseVisualStyleBackColor = true;
            this.importProductButton.Click += new System.EventHandler(this.importProductButton_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 482);
            this.ControlBox = false;
            this.Controls.Add(this.importProductButton);
            this.Controls.Add(this.updateStockButton);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.queryLogButton);
            this.Controls.Add(this.btnSeeBlackList);
            this.Controls.Add(this.btnRemoveProductFromBlackList);
            this.Controls.Add(this.btnAddProductToBlackList);
            this.Controls.Add(this.pointSystemConfigurationButton);
            this.Controls.Add(this.lableTitle);
            this.Controls.Add(this.mainArea);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPanel";
            this.Text = "MainPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainArea;
        private System.Windows.Forms.Label lableTitle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button queryLogButton;
        private System.Windows.Forms.Button btnSeeBlackList;
        private System.Windows.Forms.Button btnRemoveProductFromBlackList;
        private System.Windows.Forms.Button btnAddProductToBlackList;
        private System.Windows.Forms.Button pointSystemConfigurationButton;
        private System.Windows.Forms.Button updateStockButton;
        private System.Windows.Forms.Button importProductButton;
    }
}