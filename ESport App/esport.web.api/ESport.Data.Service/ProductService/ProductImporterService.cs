using System.Collections.Generic;
using System.Linq;
using ESport.Data.Commons;
using ESport.Logger.Manager;

namespace ESport.Data.Service
{
    public class ProductImporterService : IProductImporterService
    {
        private ICollection<IObserver> observers;
        private IProductService productService;
        private ICategoryService categoryService;
        private ILoggerManager loggerManager;
        private string message;

        public ProductImporterService(IProductService productService,
            ICategoryService categoryService, ILoggerManager loggerManager)
        {
            message = "";
            observers = new List<IObserver>();
            this.productService = productService;
            this.categoryService = categoryService;
            this.loggerManager = loggerManager;
        }

        public void ImportProducts(ICollection<ProductRequest> productsToImport, UserDTO userDTO)
        {
            NotifyObservers("Comienza la importación");
            loggerManager.AddLog(ESportLoggerUtils.IMPORT_PRODUCT_ACTION, userDTO.UserId, userDTO.UserName);
            foreach (var prodRequest in productsToImport)
            {
                NotifyObservers("Importación de producto: cod " + prodRequest.ProductId);
                ImportProducts(prodRequest);
                if (prodRequest.CategoryId != null)
                {
                    ImportProductCategory(prodRequest);
                }
            }
            NotifyObservers("Finaliza Importación");
        }

        private void ImportProductCategory(ProductRequest prodRequest)
        {
            FullProductDTO product = productService.GetAllFullProducts().Where(prod => prod.ProductId == prodRequest.ProductId).First();
            try
            {
                if (product.CategoryId != null)
                {
                    categoryService.RemoveProductFromCategory(new CategoryRequest() { ProductId = prodRequest.ProductId, CategoryId = product.CategoryId });
                }
                if (!string.IsNullOrWhiteSpace(prodRequest.CategoryId))
                {
                    categoryService.AddProductOnCategory(new CategoryRequest() { ProductId = prodRequest.ProductId, CategoryId = prodRequest.CategoryId });
                }
            }
            catch (OperationException e)
            {
                NotifyObservers(e.Message);
            }
        }

        private void ImportProducts(ProductRequest prodRequest)
        {
            try
            {
                productService.SimpleUpdateProduct(prodRequest);
                productService.UpdateStockProduct(prodRequest);
            }
            catch (OperationException)
            {
                try
                {
                    productService.AddProduct(prodRequest);
                }
                catch (OperationException e)
                {
                    NotifyObservers("Error al importar producto: " + prodRequest.ProductId + " " + e.Message);
                }
            }
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }


    }
}
