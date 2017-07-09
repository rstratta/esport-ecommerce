using System.Collections.Generic;

namespace ESport.Data.Commons
{
    public class ProductReportDTO : AbstractReportDTO
    {
        public List<ProductItemReportDTO> Result { get; set; }


        public ProductReportDTO(string reportName, List<ProductItemReportDTO> items)
        {
            base.ReportName = reportName;
            Result = items;
        }

        

        
    }
}
