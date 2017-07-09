using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESport.Data.Service;
using ESport.Data.Commons;

namespace ESport.DesktopAppUI
{
    public partial class UpdateStockControl : UserControl
    {
        private IProductService productService;
        public UpdateStockControl(IProductService productService)
        {
            this.productService = productService;
            InitializeComponent();
            InitializeView();
        }

        private void InitializeView()
        {
            productListBox.Items.Clear();
            ICollection<FullProductDTO> products = productService.GetAllFullProducts();
            FillProductList(products);
            HideComponents();
        }

        private void HideComponents()
        {
            selectedProductLabel.Visible = false;
            currentStockLabel.Visible = false;
            newStockValueLabel.Visible = false;
            stockInput.Visible = false;
            updateStockButton.Visible = false;
        }

        private void FillProductList(ICollection<FullProductDTO> products)
        {
            foreach (var product in products)
            {
                productListBox.Items.Add(product);
            }
        }

        private void productListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (productListBox.SelectedItem != null)
            {
                ShowProductSelected((FullProductDTO)productListBox.SelectedItem);
            }
        }

        private void ShowProductSelected(FullProductDTO selectedItem)
        {
            selectedProductLabel.Visible = true;
            selectedProductLabel.Text = "Producto: " + selectedItem.Description;
            currentStockLabel.Visible = true;
            currentStockLabel.Text = "Cantidad Actual " + selectedItem.AvailableStock;
            newStockValueLabel.Visible = true;
            stockInput.Visible = true;
            stockInput.Value = selectedItem.AvailableStock;
            updateStockButton.Visible = true;
        }

        private void updateStockButton_Click(object sender, EventArgs e)
        {
            if (productListBox.SelectedItem != null)
            {
                try
                {
                    productService.UpdateStockProduct(BuildProductRequest());
                    InitializeView();
                }
                catch (BadRequestException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (OperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private ProductRequest BuildProductRequest()
        {
            ProductRequest request = new ProductRequest();
            request.AvailableStock = Convert.ToInt32(stockInput.Value);
            request.ProductId = ((FullProductDTO)productListBox.SelectedItem).ProductId;
            return request;
        }
    }
}
