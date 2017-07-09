using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Data.Repository;
using ESport.Data.Service;
using ESport.Data.Service.PointSystem;
using ESport.Logger.Manager;
using ESport.Logger.Repository;

namespace ESport.DesktopAppUI
{
    public class ServiceFactory
    {

        public ILoginService CreateLoginService()
        {
            IUserManager userManager = CreateUserManager();
            IDTOBuilder<UserDTO, User> userDtoBuilder = CreateUserDTOBuilder();
            ILoggerManager loggerManager = CreateLoggerManager();
            return new SimpleLoginService(userManager, userDtoBuilder, loggerManager);
        }

        public IProductService CreateProductService()
        {
            IProductManager productManager = CreateProductManager();
            return new ProductServiceImpl(productManager,
                new SimpleProductDTOBuilder(new ImageDTOBuilder()),CreateFullProductDTOBuilder());
        }
        public IProductImporterService CreateProductImporter()
        {
            return new ProductImporterService(CreateProductService(), CreateCategoryService(), CreateLoggerManager());
        }

        private ICategoryService CreateCategoryService()
        {
            ICategoryManager categoryManager = new CategoryManager(new CategoryRepository(), new ProductRepository());
            return  new CategoryServiceImpl(categoryManager, new CategoryBuilderDTO(CreateFullProductDTOBuilder()));
        }

        private IDTOBuilder<FullProductDTO, Data.Entities.Product> CreateFullProductDTOBuilder()
        {
            return new FullProductDTOBuilder(new FieldDTOBuilder(), new ImageDTOBuilder());
        }

        public IPointSystemConfigurationService CreatePointSystemConfigurationService()
        {
            IPointSystemConfigurationManager pointSystemConfigurationManager = new PointSystemConfigurationManager(new PointSystemConfigurationRepository());
            return new PointSystemConfigurationService(pointSystemConfigurationManager);
        }

        private IProductManager CreateProductManager()
        {
            return new ProductManager(new ProductRepository(), new FieldRepository());
        }

        public ILoggerManager CreateLoggerManager()
        {
            ILoggerRepository loggerRepository = new DbLoggerRepository();
            return new LoggerManager(loggerRepository);
        }

        private IDTOBuilder<UserDTO, User> CreateUserDTOBuilder()
        {
            return new UserDTOBuilder();
        }

        private IUserManager CreateUserManager()
        {
            IUserRepository userRepository = new UserRepository();
            IRoleRepository roleRepository = new RoleRepository();
            return new UserManager(userRepository, roleRepository);
        }
    }
}
