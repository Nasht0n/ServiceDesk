using ClosedXML.Excel;
using Domain.Models.Requests.Equipment;
using System.Collections.Generic;

namespace WebUI.Models
{
    public static class ReportManager
    {
        public static XLWorkbook CreateConsumptionReport(string path, List<EquipmentRefillRequestConsumption> consumptions)
        {
            var workbook = new XLWorkbook(path);
            IXLWorksheet worksheet = workbook.Worksheets.Add("Data");
            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "ConsumableId";
            worksheet.Cell(1, 3).Value = "Count";
            for(int index = 1; index <= consumptions.Count; index++)
            {
                worksheet.Cell(index + 1, 1).Value = consumptions[index - 1].Id;
                worksheet.Cell(index + 1, 2).Value = consumptions[index - 1].ConsumableId;
                worksheet.Cell(index + 1, 3).Value = consumptions[index - 1].Count;
            }
            return workbook;
        }
    }
}