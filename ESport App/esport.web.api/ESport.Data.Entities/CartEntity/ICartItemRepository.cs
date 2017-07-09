using System;

namespace ESport.Data.Entities
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        CartItem GetCartItemById(Guid cartItemId);
    }
}
