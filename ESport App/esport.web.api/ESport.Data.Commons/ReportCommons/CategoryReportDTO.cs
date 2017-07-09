using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Commons
{
    public class CategoryReportDTO : AbstractReportDTO
    {
        public List<CategoryItemReportDTO> Result { get; set; }

        public double TotalAmount { get; set; }

        public CategoryReportDTO(string reportName, List<CategoryItemReportDTO> items)
        {
            base.ReportName = reportName;
            Result = items;
            foreach (var item in Result)
            {
                TotalAmount += item.Amount;
            }
        }
    }
}
