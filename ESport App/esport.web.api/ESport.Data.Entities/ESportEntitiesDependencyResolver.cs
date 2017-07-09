using ESport.DependencyResolver;
using System.ComponentModel.Composition;

namespace ESport.Data.Entities
{
    [Export(typeof(IComponent))]
    public class ESportEntitiesDependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserManager, UserManager>();
            registerComponent.RegisterType<IRoleManager, RoleManager>();
            registerComponent.RegisterType<IReviewManager, ReviewManager>();
            registerComponent.RegisterType<IProductManager, ProductManager>();
            registerComponent.RegisterType<ICategoryManager, CategoryManager>();
            registerComponent.RegisterType<ICartManager, CartManager>();
            registerComponent.RegisterType<IPointSystemConfigurationManager, PointSystemConfigurationManager>();
        }
    }
}
