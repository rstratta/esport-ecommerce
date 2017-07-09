using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ESport.Data.Service;
using ESport.Data.Commons;

namespace ESport.DesktopAppUI
{
    public partial class RemoveProductFromBlackList : UserControl
    {
        private IProductService productService;

        public RemoveProductFromBlackList(IProductService productService)
        {
            this.productService = productService;
            InitializeComponent();
            FillProductList();
            
        }

        public RemoveProductFromBlackList(IProductService productService, string title):this(productService)
        {
            titleLabel.Text = title;
            productLabel.Visible = false;
        }

        public void HideButton()
        {
            removeProductFromBlackListButton.Visible = false;
        }
        private void FillProductList()
        {
            ICollection<FullProductDTO> products = productService.GetAllFullProducts();
            ICollection<FullProductDTO> whiteProducts = products.Where(productDTO => productDTO.BlackProduct).ToList();
            productListBox.Items.Clear();
            foreach (var dto in whiteProducts)
            {
                productListBox.Items.Add(dto);
            }
        }

        private void removeProductFromBlackListButton_Click(object sender, EventArgs e)
        {
            if (productListBox.SelectedItem != null)
            {
                FullProductDTO selectedProduct = (FullProductDTO)productListBox.SelectedItem;
                ProductRequest request = new ProductRequest() { ProductId = selectedProduct.ProductId };
                try
                {
                    productService.RemoveProductFromBlackList(request);
                    FillProductList();
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
    }
}
