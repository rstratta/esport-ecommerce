namespace ESport.Data.Commons
{
    public class CategoryRequest
    {
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public bool Eliminated { get; set; }
        public string ProductId { get; set; }

        public CategoryRequest()
        {
          
        }


        public override bool Equals(object obj)
        {
            return CategoryId.Equals(((CategoryRequest)obj).CategoryId);
        }

    }
}
