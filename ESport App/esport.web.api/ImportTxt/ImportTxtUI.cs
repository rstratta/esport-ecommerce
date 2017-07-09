using System;
using System.Windows.Forms;

namespace ImportTxt
{
    public partial class ImportTxtUI : Form
    {
        private ImportTxt txtImporter;
        public ImportTxtUI(ImportTxt txtImporter)
        {
            this.txtImporter = txtImporter;
            InitializeComponent();
        }

        private void btnImportTxt_Click(object sender, EventArgs e)
        {
            ReadFile();
        }

        private void ReadFile()
        {
            var FileDialog = new System.Windows.Forms.OpenFileDialog();
            if (FileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string fileToOpen = FileDialog.FileName;
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(fileToOpen);
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        txtImporter.ProcessLine(line);
                    }
                    MessageBox.Show("Se cargaron " + txtImporter.GetQuantityLoaded() + " productos.", "OK");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo abrir el archivo.", "ERROR");
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
