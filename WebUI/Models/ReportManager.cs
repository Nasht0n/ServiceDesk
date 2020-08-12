using ClosedXML.Excel;
using Domain.Views;
using System.Collections.Generic;

namespace WebUI.Models
{
    public static class ReportManager
    {
        public static XLWorkbook CreateConsumptionReport(string path, List<RefillRequestJournal> journal)
        {
            var workbook = new XLWorkbook(path);
            IXLWorksheet worksheet = workbook.Worksheet("!Data");
            
            worksheet.Cell(1, 1).Value = "№ заявки";          
            worksheet.Cell(1, 2).Value = "Дата создания заявки";
            worksheet.Cell(1, 3).Value = "Дата согласования заявки";
            worksheet.Cell(1, 4).Value = "Подразделение";
            worksheet.Cell(1, 5).Value = "Учебный корпус";
            worksheet.Cell(1, 6).Value = "Место установки";
            worksheet.Cell(1, 7).Value = "ФИО";
            worksheet.Cell(1, 8).Value = "Тема";
            worksheet.Cell(1, 9).Value = "Инвентарный номер";
            worksheet.Cell(1, 10).Value = "Ответственный";
            worksheet.Cell(1, 11).Value = "Дата выполнения заявки";

            for (int index = 1; index <= journal.Count; index++)
            {
                worksheet.Cell(index + 1, 1).Value = journal[index - 1].RequestId;
                worksheet.Cell(index + 1, 2).Value = journal[index - 1].CreateDate;
                worksheet.Cell(index + 1, 3).Value = journal[index - 1].ApprovalDate;
                worksheet.Cell(index + 1, 4).Value = journal[index - 1].Subdivision;
                worksheet.Cell(index + 1, 5).Value = journal[index - 1].Campus;
                worksheet.Cell(index + 1, 6).Value = journal[index - 1].Location;
                worksheet.Cell(index + 1, 7).Value = journal[index - 1].Client;
                worksheet.Cell(index + 1, 8).Value = journal[index - 1].Title;
                worksheet.Cell(index + 1, 9).Value = journal[index - 1].InventoryNumber;
                worksheet.Cell(index + 1, 10).Value = journal[index - 1].Executor;
                worksheet.Cell(index + 1, 11).Value = journal[index - 1].CompleteDate;
            }

            worksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            return workbook;
        }
    }
}