namespace ESport.Data.Commons
{

    public class CartItemDTO
    {
        public string ItemId { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public double ItemAmount { get; set; }
        public double UnitAmount { get; set; }
        public string ProductId { get; set; }
    }
}
