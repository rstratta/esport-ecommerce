using ESport.Data.Commons;
using ESport.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ESport.Data.Service
{
    public class SimpleCartDTOBuilder : IDTOBuilder<CartDTO, Cart>
    {
        IDTOBuilder<CartItemDTO, CartItem> itemDTOBuilder;

        public SimpleCartDTOBuilder()
        {
            itemDTOBuilder = new SimpleCartItemDTOBuilder();
        }

        public SimpleCartDTOBuilder(IDTOBuilder<CartItemDTO, CartItem> itemDTOBuilder)
        {
            this.itemDTOBuilder = itemDTOBuilder;
        }
        public CartDTO buildDTO(Cart entity)
        {
            CartDTO cartDTO = new CartDTO();
            cartDTO.CartId = entity.CartId;
            cartDTO.Total = entity.Total;
            cartDTO.Opendate = entity.Opendate.ToString();
            cartDTO.itemsDTO = BuildItemsDTO(entity.Items.OrderBy(item => item.ItemDescription).ToList());
            return cartDTO;
        }

        private List<CartItemDTO> BuildItemsDTO(ICollection<CartItem> items)
        {
            List<CartItemDTO> itemsDTO = new List<CartItemDTO>();
            foreach (CartItem item in items)
            {
                itemsDTO.Add(itemDTOBuilder.buildDTO(item));
            }
            return itemsDTO;
        }
    }
}
