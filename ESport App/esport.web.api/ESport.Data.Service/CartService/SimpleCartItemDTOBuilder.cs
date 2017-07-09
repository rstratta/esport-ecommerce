using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service
{
    public class SimpleCartItemDTOBuilder : IDTOBuilder<CartItemDTO, CartItem>
    {
        public CartItemDTO buildDTO(CartItem entity)
        {
            CartItemDTO itemDTO = new CartItemDTO();
            itemDTO.ItemId = entity.CartItemId.ToString();
            itemDTO.ItemAmount = entity.Amount;
            itemDTO.ProductDescription = entity.ItemDescription;
            itemDTO.Quantity = entity.Quantity;
            itemDTO.UnitAmount = entity.UnitPrice;
            itemDTO.ProductId = entity.Product.ProductId;
            return itemDTO;
        }
    }
}
