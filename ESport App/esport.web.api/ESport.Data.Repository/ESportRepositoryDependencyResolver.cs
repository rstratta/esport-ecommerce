using ESport.Data.Entities;
using ESport.DependencyResolver;
using System.ComponentModel.Composition;

namespace ESport.Data.Repository
{
    [Export(typeof(IComponent))]
    public class ESportRepositoryDependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserRepository, UserRepository>();
            registerComponent.RegisterType<IRoleRepository, RoleRepository>();
            registerComponent.RegisterType<IReviewRepository, ReviewRepository>();
            registerComponent.RegisterType<IProductRepository, ProductRepository>();
            registerComponent.RegisterType<ICategoryRepository, CategoryRepository>();
            registerComponent.RegisterType<ICartRepository, CartRepository>();
            registerComponent.RegisterType<IFieldRepository, FieldRepository>();
            registerComponent.RegisterType<ICartItemRepository, CartItemRepository>();
            registerComponent.RegisterType<IPointSystemConfigurationRepository, PointSystemConfigurationRepository>();
        }
    }
}
