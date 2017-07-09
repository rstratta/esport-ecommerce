using System;
using System.IO;
using System.Windows.Forms;

namespace ImportXml
{
    public partial class ImportXmlUI : Form
    {
        private ImportXml xmlImporter;
        public ImportXmlUI(ImportXml xmlImporter)
        {
            this.xmlImporter = xmlImporter;
            InitializeComponent();
            
        }

        private void btnImportXml_Click(object sender, EventArgs e)
        {
            ReadAndProcessFile();
        }

        private void ReadAndProcessFile()
        {
            var FileDialog = new System.Windows.Forms.OpenFileDialog();
            if (FileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = FileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(fileToOpen, FileMode.Open))
                    {
                        xmlImporter.ProcessFile(fileStream); 
                    }
                    MessageBox.Show("Se cargaron " + xmlImporter.GetQuantityLoaded() + " productos.", "OK");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }
            }
        
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
