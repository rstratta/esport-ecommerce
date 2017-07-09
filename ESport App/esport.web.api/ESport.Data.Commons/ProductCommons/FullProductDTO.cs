using System.Collections.Generic;


namespace ESport.Data.Commons
{
    
    public class FullProductDTO : SimpleProductDTO
    {
        public string CategoryId { get; set; }
        public bool Eliminated { get; set; }
        public List<FieldDTO> Fields { get; set; }

        public override string ToString()
        {
            return "Código: " + ProductId + " - Descripción: " + Description;
        }
    }
}
