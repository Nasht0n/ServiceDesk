using ClosedXML.Excel;
using Domain.Views;
using System.Collections.Generic;

namespace WebUI.Models
{
    public static class ReportManager
    {
        public static XLWorkbook CreateJournalReport(string path, List<RefillRequestJournal> journal, System.DateTime startDate, System.DateTime endDate)
        {
            var workbook = new XLWorkbook(path);
            IXLWorksheet worksheet = workbook.Worksheet("!Data");
            
            worksheet.Cell(3, 1).Value = "№ заявки";          
            worksheet.Cell(3, 2).Value = "Дата создания заявки";
            worksheet.Cell(3, 3).Value = "Дата согласования заявки";
            worksheet.Cell(3, 4).Value = "Подразделение";
            worksheet.Cell(3, 5).Value = "Учебный корпус";
            worksheet.Cell(3, 6).Value = "Место установки";
            worksheet.Cell(3, 7).Value = "ФИО";
            worksheet.Cell(3, 8).Value = "Тема";
            worksheet.Cell(3, 9).Value = "Инвентарный номер";
            worksheet.Cell(3, 10).Value = "Ответственный";
            worksheet.Cell(3, 11).Value = "Дата выполнения заявки";

            worksheet.Cell(1, 1).Value = "Дата начала выборки";
            worksheet.Cell(1, 4).Value = "Дата окончания выборки";
            worksheet.Cell(1, 2).Value = startDate.ToShortDateString();
            worksheet.Cell(1, 5).Value = endDate.ToShortDateString();

            for (int index = 1; index <= journal.Count; index++)
            {
                worksheet.Cell(index + 3, 1).Value = journal[index - 1].RequestId;
                worksheet.Cell(index + 3, 2).Value = journal[index - 1].CreateDate;
                worksheet.Cell(index + 3, 3).Value = journal[index - 1].ApprovalDate;
                worksheet.Cell(index + 3, 4).Value = journal[index - 1].Subdivision;
                worksheet.Cell(index + 3, 5).Value = journal[index - 1].Campus;
                worksheet.Cell(index + 3, 6).Value = journal[index - 1].Location;
                worksheet.Cell(index + 3, 7).Value = journal[index - 1].Client;
                worksheet.Cell(index + 3, 8).Value = journal[index - 1].Title;
                worksheet.Cell(index + 3, 9).Value = journal[index - 1].InventoryNumber;
                worksheet.Cell(index + 3, 10).Value = journal[index - 1].Executor;
                worksheet.Cell(index + 3, 11).Value = journal[index - 1].CompleteDate;
            }
            return workbook;
        }

        public static XLWorkbook CreateConsumptionReport(string path, List<RefillRequestConsumption> consumptions, System.DateTime startDate, System.DateTime endDate)
        {
            var workbook = new XLWorkbook(path);
            IXLWorksheet worksheet = workbook.Worksheet("!Data");

            worksheet.Cell(3, 1).Value = "Инвентарный номер";
            worksheet.Cell(3, 2).Value = "Наименование расходного материала";
            worksheet.Cell(3, 3).Value = "Количество";
            worksheet.Cell(3, 4).Value = "Еденица измерения";
            worksheet.Cell(3, 5).Value = "Номер заявки";
            worksheet.Cell(3, 6).Value = "Дата создания";
            worksheet.Cell(3, 7).Value = "Подразделение";
            worksheet.Cell(3, 8).Value = "Учебный корпус";
            worksheet.Cell(3, 9).Value = "Место установки";
            worksheet.Cell(3, 10).Value = "Автор заявки";

            worksheet.Cell(1, 1).Value = "Дата начала выборки";
            worksheet.Cell(1, 4).Value = "Дата окончания выборки";
            worksheet.Cell(1, 2).Value = startDate.ToShortDateString();
            worksheet.Cell(1, 5).Value = endDate.ToShortDateString();

            for (int index = 1; index <= consumptions.Count; index++)
            {
                worksheet.Cell(index + 3, 1).Value = consumptions[index - 1].InventoryNumber;
                worksheet.Cell(index + 3, 2).Value = consumptions[index - 1].Consumable;
                worksheet.Cell(index + 3, 3).Value = consumptions[index - 1].Count;
                worksheet.Cell(index + 3, 4).Value = consumptions[index - 1].Unit;
                worksheet.Cell(index + 3, 5).Value = consumptions[index - 1].RequestNumber;
                worksheet.Cell(index + 3, 6).Value = consumptions[index - 1].CreateDate;
                worksheet.Cell(index + 3, 7).Value = consumptions[index - 1].Subdivision;
                worksheet.Cell(index + 3, 8).Value = consumptions[index - 1].Campus;
                worksheet.Cell(index + 3, 9).Value = consumptions[index - 1].Location;
                worksheet.Cell(index + 3, 10).Value = consumptions[index - 1].Fullname;
            }
            return workbook;
        }
    }
}