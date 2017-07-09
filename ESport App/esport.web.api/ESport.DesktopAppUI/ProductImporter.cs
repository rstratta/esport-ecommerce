using System;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Reflection;
using ESport.Product.Importer;
using System.Collections.Generic;
using ESport.Data.Service;
using ESport.Data.Commons;

namespace ESport.DesktopAppUI
{
    internal struct ReflectionComboItem
    {
        public string LoadClass { get; set; }
        public string AssemblyPath { get; set; }
        public string ShowName { get; set; }

        public override string ToString()
        {
            return ShowName;
        }
    }
    public partial class ProductImporter : UserControl, IObserver
    {
        private IProductImporterService productImporterService;
        private UserContextDTO userContextDTO;
        public ProductImporter(IProductImporterService productImporterService, UserContextDTO userContextDTO)
        {
            this.userContextDTO = userContextDTO;
            this.productImporterService = productImporterService;
            this.productImporterService.AddObserver(this);
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            string dllRepository = ConfigurationManager.AppSettings["ReflectionPath"];
            if (dllRepository != null)
            {
                DirectoryInfo dllDirectory = new DirectoryInfo(dllRepository);
                if (dllDirectory.Exists)
                {
                    ProcessDllRepository(dllDirectory);
                }
                else
                {
                    MessageBox.Show("No se encontró el repository de dll especificado");
                }

            }
            else
            {
                MessageBox.Show("Error en configuración del sistema. Falta propiedad ReflectionPath");
            }
        }

        private void ProcessDllRepository(DirectoryInfo dllDirectory)
        {
            foreach (FileInfo file in dllDirectory.GetFiles("*.dll"))
            {
                Assembly assembly = Assembly.LoadFile(file.FullName);
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IProductImporter).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        ReflectionComboItem comboItemImporter = new ReflectionComboItem() { LoadClass = type.FullName, AssemblyPath = file.FullName, ShowName = GetImporterType(type) };
                        productImporterTypeComboBox.Items.Add(comboItemImporter);
                    }
                }
            }
        }

        private string GetImporterType(Type type)
        {
            try
            {
                MethodInfo metodo = type.GetMethod("GetImporterType");
                var instance = Activator.CreateInstance(type);
                return (string)metodo.Invoke(instance, null);
            }

            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al cargar el nombre del dll");
                return "";
            }
        }

        private void invokeProductImporterButton_Click(object sender, EventArgs e)
        {
            logListBox.Items.Clear();
            if (productImporterTypeComboBox.SelectedItem!=null)
            {
                ReflectionComboItem selectedImporter = (ReflectionComboItem)productImporterTypeComboBox.SelectedItem;

                try
                {
                    string assemblyPath = selectedImporter.AssemblyPath;
                    string className = selectedImporter.LoadClass;

                    Assembly assembly = Assembly.LoadFile(assemblyPath);
                    Type type = assembly.GetType(className);

                    MethodInfo method = type.GetMethod("LoadProducts");
                    var instance = Activator.CreateInstance(type);

                    object productsLoaded = method.Invoke(instance, null);

                    ICollection<ProductToImport> productsToImport = (ICollection<ProductToImport>)productsLoaded;

                    if (productsToImport != null)
                    {
                        ImportProduct(productsToImport);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error interno de libreria, seleccione otra.", "ERROR");
                    productImporterTypeComboBox.Items.Remove(selectedImporter);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de importador");
            }
        }

        private void ImportProduct(ICollection<ProductToImport> productsToImport)
        {
            try
            {
                productImporterService.ImportProducts(ConvertToProductRequest(productsToImport), userContextDTO.UserDTO);
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(OperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private ICollection<ProductRequest> ConvertToProductRequest(ICollection<ProductToImport> productsToImport)
        {
            ICollection<ProductRequest> result = new List<ProductRequest>();
            foreach (var productToImport in productsToImport)
            {
                result.Add(BuildRequest(productToImport));
            }
            return result;
        }

        private ProductRequest BuildRequest(ProductToImport productToImport)
        {
            ProductRequest request = new ProductRequest();
            request.ProductId = productToImport.ProductId;
            request.ProductName = productToImport.ProductName;
            request.Factory = productToImport.Factory;
            request.Description = productToImport.Description;
            request.Price = productToImport.Price;
            request.CategoryId = productToImport.CategetoryId;
            request.AvailableStock = productToImport.AvailableStock;
            return request;
        }

        public void Update(string message)
        {
            logListBox.Items.Add(message);
        }
    }
}
