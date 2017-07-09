using ESport.Data.Commons;
using ESport.Data.Service;
using ESport.Logger.Manager;
using System;
using System.Windows.Forms;

namespace ESport.DesktopAppUI
{
    public partial class Login : Form
    {
        private ILoginService loginService;
        private ServiceFactory serviceFactory;
       
        
        public Login(ServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
            loginService = serviceFactory.CreateLoginService();
            InitializeComponent();

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            LoginUserRequest loginRequest = BuildLoginRequest();
            try
            {
                UserContextDTO userContext = loginService.LoginUser(loginRequest);
                ValidateUserRole(userContext.UserDTO);
                ShowMainPanel(userContext);
            }
            catch (BadRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (OperationException ex)
            {
                MessageBox.Show(ex.Message);
            }catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar loguearse");
            }
        }

        private void ShowMainPanel(UserContextDTO userContext)
        {
            MainPanel window = new MainPanel(userContext, serviceFactory);
            window.Show();
            Hide();
        }

        private void ValidateUserRole(UserDTO userDTO)
        {
            bool isAdmin = false;
            foreach(var role in userDTO.Roles)
            {
                if (role.RoleId.Equals(ESportUtils.ADMIN_ROLE))
                {
                    return;
                }
            }
            if (!isAdmin)
            {
                throw new OperationException("No tiene permisos suficientes para este módulo");
            }
        }

        private LoginUserRequest BuildLoginRequest()
        {
            LoginUserRequest loginRequest = new LoginUserRequest();
            loginRequest.UserId = textBoxUserName.Text;
            loginRequest.UserPassword = textBoxPassword.Text;
            return loginRequest;
        }
    }
}
