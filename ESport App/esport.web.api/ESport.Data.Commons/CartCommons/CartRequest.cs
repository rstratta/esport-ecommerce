namespace ESport.Data.Commons
{
    public class CartRequest
    {
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
    }
}
