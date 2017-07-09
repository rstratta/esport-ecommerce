using ESport.Data.Commons;
using ESport.Data.Service;
using ESport.Logger.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESport.DesktopAppUI
{
    public partial class MainPanel : Form
    {
        private UserContextDTO userContext;
        private ServiceFactory serviceFactory;
        private ILoginService loginService;

        public MainPanel(UserContextDTO userContext,ServiceFactory serviceFactory)
        {
            this.userContext = userContext;
            this.serviceFactory = serviceFactory;
            loginService = serviceFactory.CreateLoginService();
            InitializeComponent();
            LoadMainPanel();
        }

        private void LoadMainPanel()
        {
            this.lableTitle.Text = "Bienvenido " + GetUserName() + " a ESport";
            mainArea.Controls.Clear();
            UserControl startPage = new StartPage();
            mainArea.Controls.Add(startPage);
        }

        private string GetUserName()
        {
            return userContext.UserDTO.UserName;
        }

        private void btnAddProductToBlackList_Click(object sender, EventArgs e)
        {
            mainArea.Controls.Clear();
            UserControl addToBlackList = new AddProductToBlackList(serviceFactory.CreateProductService());
            mainArea.Controls.Add(addToBlackList);
        }

        private void btnRemoveProductFromBlackList_Click(object sender, EventArgs e)
        {
            mainArea.Controls.Clear();
            UserControl removeFromBlackList = new RemoveProductFromBlackList(serviceFactory.CreateProductService());
            mainArea.Controls.Add(removeFromBlackList);
        }

        private void btnSeeBlackList_Click(object sender, EventArgs e)
        {
            mainArea.Controls.Clear();
            UserControl removeFromBlackList = new RemoveProductFromBlackList(serviceFactory.CreateProductService(),"Lista negra de productos");
            ((RemoveProductFromBlackList)removeFromBlackList).HideButton();
            mainArea.Controls.Add(removeFromBlackList);
        }
        

        private void btnConsultLog_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                loginService.Logout(userContext.Token);
                Close();
                Login loginWindow = new Login(serviceFactory);
                loginWindow.Show();
            }
            catch(OperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pointSystemConfigurationButton_Click(object sender, EventArgs e)
        {
            mainArea.Controls.Clear();
            UserControl editPointsSystem = new PointsSystem(serviceFactory.CreatePointSystemConfigurationService());
            mainArea.Controls.Add(editPointsSystem);
        }

        private void queryLogButton_Click(object sender, EventArgs e)
        {
            mainArea.Controls.Clear();
            UserControl consultLog = new ConsultLog(serviceFactory.CreateLoggerManager());
            mainArea.Controls.Add(consultLog);
        }

        private void importProductButton_Click(object sender, EventArgs e)
        {
            mainArea.Controls.Clear();
            UserControl consultLog = new ProductImporter(serviceFactory.CreateProductImporter(), userContext);
            mainArea.Controls.Add(consultLog);
        }

        private void updateStockButton_Click(object sender, EventArgs e)
        {
            mainArea.Controls.Clear();
            UserControl stockControl = new UpdateStockControl(serviceFactory.CreateProductService());
            mainArea.Controls.Add(stockControl);
        }
    }
}
