using System.Diagnostics;

using OfficeOpenXml;
using OfficeOpenXml.Style;

using RestaurantChain.Domain.Models.Reports;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Repository;

namespace RestaurantChain.DomainServices.Services;

internal class ReportsService : IReportsService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReportsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public string GetDishesSumByPeriod(DateTime startDate, DateTime endDate)
    {
        IReadOnlyCollection<DishesSumByPeriod> data = _unitOfWork.ReportsRepository.GetDishesSumByPeriod(startDate, endDate);

        string? folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
        var fileName = $@"{folder}\Dishes-{Guid.NewGuid():N}.xlsx";
        var newFile = new FileInfo(fileName);

        // If you use EPPlus in a noncommercial context
        // according to the Polyform Noncommercial license:
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var xlPackage = new ExcelPackage(newFile);
        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Отчет");

        //Заголовок
        var row = 1;
        worksheet.Cells["A1:F1"].Merge = true;//Объединить
        worksheet.Cells["A1"].Style.Font.Bold = true;
        worksheet.Cells["A1"].Style.Font.Size = 14;
        worksheet.Cells["A1"].Value = $"Выручка по блюдам за период {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}";

        //Шапка
        row++;
        row++;
        int startTableRow = row;
        var index = 0;

        //Жирное
        worksheet.Cells[$"A{row}:F{row}"].Style.Font.Bold = true;

        worksheet.Cells[$"A{row}"].Value = "№";
        worksheet.Cells[$"B{row}"].Value = "Дата";
        worksheet.Cells[$"C{row}"].Value = "Группа блюд";
        worksheet.Cells[$"D{row}"].Value = "Блюдо";
        worksheet.Cells[$"E{row}"].Value = "Количество";
        worksheet.Cells[$"F{row}"].Value = "Стоимость";

        //Данные
        foreach (DishesSumByPeriod item in data)
        {
            index++;
            row++;
            worksheet.Cells[$"A{row}"].Value = index;
            worksheet.Cells[$"B{row}"].Value = item.Date.ToString("dd.MM.yyyy");
            worksheet.Cells[$"C{row}"].Value = item.GroupName;
            worksheet.Cells[$"D{row}"].Value = item.DishName;
            worksheet.Cells[$"E{row}"].Value = item.SaleCount;
            worksheet.Cells[$"F{row}"].Value = item.Price;
        }

        //Таблицу нарисовать
        worksheet.Cells[$"A{startTableRow}:F{row}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        worksheet.Cells[$"A{startTableRow}:F{row}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        worksheet.Cells[$"A{startTableRow}:F{row}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        worksheet.Cells[$"A{startTableRow}:F{row}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

        //Сумма
        row++;
        worksheet.Cells[$"B{row}"].Value = "Итог:";
        worksheet.Cells[$"E{row}"].Value = data.Sum(x => x.SaleCount);
        worksheet.Cells[$"F{row}"].Value = data.Sum(x => x.Price);

        worksheet.Cells[$"A2:F{row}"].AutoFitColumns();
        worksheet.Column(3).Width = 30;
        worksheet.Column(4).Width = 30;

        xlPackage.Save();

        return fileName;
    }

    public string GetRestaurantSumByPeriods(DateTime startDate, DateTime endDate)
    {
        IReadOnlyCollection<RestaurantSumByPeriod> data = _unitOfWork.ReportsRepository.GetRestaurantSumByPeriods(startDate, endDate);

        string? folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName);
        var fileName = $@"{folder}\Rest-{Guid.NewGuid():N}.xlsx";
        var newFile = new FileInfo(fileName);

        // If you use EPPlus in a noncommercial context
        // according to the Polyform Noncommercial license:
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var xlPackage = new ExcelPackage(newFile);
        ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Отчет");

        //Заголовок
        var row = 1;
        worksheet.Cells["A1:E1"].Merge = true;
        worksheet.Cells["A1"].Style.Font.Bold = true;
        worksheet.Cells["A1"].Style.Font.Size = 14;
        worksheet.Cells["A1"].Value = $"Выручка по ресторанам за период {startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}";

        //Шапка
        row++;
        row++;
        int startTableRow = row;
        var index = 0;

        //Жирное
        worksheet.Cells[$"A{row}:E{row}"].Style.Font.Bold = true;

        worksheet.Cells[$"A{row}"].Value = "№";
        worksheet.Cells[$"B{row}"].Value = "Дата";
        worksheet.Cells[$"C{row}"].Value = "Ресторан";
        worksheet.Cells[$"D{row}"].Value = "Количество";
        worksheet.Cells[$"E{row}"].Value = "Стоимость";

        //Данные
        foreach (RestaurantSumByPeriod item in data)
        {
            index++;
            row++;
            worksheet.Cells[$"A{row}"].Value = index;
            worksheet.Cells[$"B{row}"].Value = item.Date.ToString("dd.MM.yyyy");
            worksheet.Cells[$"C{row}"].Value = item.RestaurantName;
            worksheet.Cells[$"D{row}"].Value = item.SaleCount;
            worksheet.Cells[$"E{row}"].Value = item.Price;
        }

        //Таблицу нарисовать
        worksheet.Cells[$"A{startTableRow}:E{row}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        worksheet.Cells[$"A{startTableRow}:E{row}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        worksheet.Cells[$"A{startTableRow}:E{row}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        worksheet.Cells[$"A{startTableRow}:E{row}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

        //Сумма
        row++;
        worksheet.Cells[$"B{row}"].Value = "Итог:";
        worksheet.Cells[$"D{row}"].Value = data.Sum(x => x.SaleCount);
        worksheet.Cells[$"E{row}"].Value = data.Sum(x => x.Price);

        worksheet.Cells[$"A2:E{row}"].AutoFitColumns();
        worksheet.Column(3).Width = 70;

        xlPackage.Save();

        return fileName;
    }
}