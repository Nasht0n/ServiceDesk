using ClosedXML.Excel;
using Domain.Models.Requests.Equipment;
using Domain.Views;
using System.Collections.Generic;

namespace WebUI.Models
{
    public static class ReportManager
    {
        public static XLWorkbook CreateConsumptionReport(string path, List<Requests> requests)
        {
            var workbook = new XLWorkbook(path);
            IXLWorksheet worksheet = workbook.Worksheet("Лист1");
            
            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "ConsumableId";
            worksheet.Cell(1, 3).Value = "Count";
            for(int index = 1; index <= requests.Count; index++)
            {
                worksheet.Cell(index + 1, 1).Value = requests[index - 1].RequestId;


            }
            return workbook;
        }
    }
}