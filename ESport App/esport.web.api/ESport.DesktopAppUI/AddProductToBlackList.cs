using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ESport.Data.Service;
using ESport.Data.Commons;
using System;

namespace ESport.DesktopAppUI
{
    public partial class AddProductToBlackList : UserControl
    {
        private IProductService productService;
        public AddProductToBlackList(IProductService productService)
        {
            this.productService = productService;
            InitializeComponent();
            FillProductList();
        }

        private void FillProductList()
        {
            ICollection<FullProductDTO> products = productService.GetAllFullProducts();
            ICollection<FullProductDTO> whiteProducts = products.Where(productDTO => !productDTO.BlackProduct).ToList();
            productListBox.Items.Clear();
            foreach (var dto in whiteProducts)
            {
                productListBox.Items.Add(dto);
            }
        }

        private void addProductInBlackListButton_Click(object sender, System.EventArgs e)
        {
            if (productListBox.SelectedItem != null)
            {
                FullProductDTO selectedProduct = (FullProductDTO)productListBox.SelectedItem;
                ProductRequest request = new ProductRequest() { ProductId = selectedProduct.ProductId };
                try {
                    productService.AddProductInBlackList(request);
                    FillProductList();
                }
                catch(BadRequestException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch(OperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
    }
}
