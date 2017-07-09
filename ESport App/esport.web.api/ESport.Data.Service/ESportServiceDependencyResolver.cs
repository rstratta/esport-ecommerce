using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.DependencyResolver;
using ESport.Logger.Manager;
using ESport.Logger.Repository;
using System.ComponentModel.Composition;

namespace ESport.Data.Service
{
    [Export(typeof(IComponent))]
    public class ESportServiceDependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserService, UserServiceImpl>();
            registerComponent.RegisterType<IDTOBuilder<UserDTO,User>, UserDTOBuilder>();
            registerComponent.RegisterType<IRoleService, RoleServiceImpl>();
            registerComponent.RegisterType<IDTOBuilder<RoleDTO,Role>, RoleDTOBuilder>();
            registerComponent.RegisterType<IReviewService, ReviewServiceImpl>();
            registerComponent.RegisterType<IDTOBuilder<ReviewDTO, Review>, ReviewDTOBuilder>();
            registerComponent.RegisterType<IProductService, ProductServiceImpl>();
            registerComponent.RegisterType<IDTOBuilder<SimpleProductDTO, Product>, SimpleProductDTOBuilder>();
            registerComponent.RegisterType<IDTOBuilder<FullProductDTO, Product>, FullProductDTOBuilder>();
            registerComponent.RegisterType<ILoginService, LoginService>();
            registerComponent.RegisterType<IDTOBuilder<PendingReviewDTO, CartItem>,PendingReviewDTOBuilder>();
            registerComponent.RegisterType<ICategoryService, CategoryServiceImpl>();
            registerComponent.RegisterType<IDTOBuilder<CategoryDTO, Category>, CategoryBuilderDTO>();
            registerComponent.RegisterType<ICartService, CartServiceImpl>();
            registerComponent.RegisterType<IDTOBuilder<CartDTO, Cart>, SimpleCartDTOBuilder>();
            registerComponent.RegisterType<IDTOBuilder<CartItemDTO, CartItem>, SimpleCartItemDTOBuilder>();
            registerComponent.RegisterType<IDTOBuilder<FieldDTO, ProductFields>, FieldDTOBuilder>();
            registerComponent.RegisterType<IDTOBuilder<ProductImageDTO, ProductImage>, ImageDTOBuilder>();
            registerComponent.RegisterType<ILoggerManager, LoggerManager>();
            registerComponent.RegisterType<ILoggerRepository, DbLoggerRepository>();
        }
    }
}
