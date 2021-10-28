using System;
using System.Collections.Generic;
using System.Linq;
using ProCivReport.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using ProCivReport.Extensions;

namespace ProCivReport.PdfBuilder
{
    public class ServiceReportBuilder
    {
        private Document Document { get; set; }

        public string Build(ServiceReportDto serviceReport)
        {
            var path = $@"C:\temp\ServiceReport_{DateTime.Now:yyyyMMdd_hhmmss}.Pdf";
            Document = new Document
            {
                Info = { Author = "Nello Zazzaro VPCC Calderara di Reno" },
                DefaultPageSetup =
                {
                    BottomMargin = 10,
                    TopMargin = 10,
                    RightMargin = 1,
                    LeftMargin = 1,
                    PageFormat = PageFormat.A4,
                    Orientation = Orientation.Portrait
                }
            };
            DefineStyles();
            CreateTable(serviceReport);
            try
            {
                var renderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always) { Document = Document };
                renderer.RenderDocument();
                renderer.PdfDocument.Save(path);

                return path;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void CreateTable(ServiceReportDto serviceReport)
        {
            var section = Document.AddSection();
            section.PageSetup = Document.DefaultPageSetup.Clone();
            section.PageSetup.Orientation = Orientation.Portrait;
            var tableWidth = Unit.FromCentimeter(18);
            var leftIndentToCenterTable = (section.PageSetup.PageWidth.Centimeter -
                                           section.PageSetup.LeftMargin.Centimeter -
                                           section.PageSetup.RightMargin.Centimeter -
                                           tableWidth.Centimeter) / 2;

            #region LogoAndHeader

            var tableLogo = section.AddTable();
            tableLogo.Style = "Table";
            tableLogo.Borders.Width = 0;
            tableLogo.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnLogoSx = tableLogo.AddColumn("4cm");
            columnLogoSx.Format.Alignment = ParagraphAlignment.Left;

            var columnHeader = tableLogo.AddColumn("9cm");
            columnHeader.Format.Alignment = ParagraphAlignment.Center;

            var columnLogoDx = tableLogo.AddColumn("4cm");
            columnLogoDx.Format.Alignment = ParagraphAlignment.Right;

            var rowLogo = tableLogo.AddRow();
            rowLogo.Height = 100;
            rowLogo.VerticalAlignment = VerticalAlignment.Center;
            rowLogo.HeadingFormat = true;

            var imgSx = rowLogo.Cells[0].AddParagraph().AddImage("./wwwroot/vpcc.jpg");
            imgSx.LockAspectRatio = true;
            imgSx.Width = Unit.FromCentimeter(3);
            imgSx.Height = Unit.FromCentimeter(3);

            rowLogo.Cells[1].AddParagraph("VOLONTARI PROTEZIONE CIVILE");
            rowLogo.Cells[1].AddParagraph("CALDERARA DI RENO");
            rowLogo.Cells[1].AddParagraph("RAPPORTO DI SERVIZIO");
            rowLogo.Cells[1].Format.Font.Size = 16;
            rowLogo.Cells[1].Format.Font.Bold = true;

            var imgDx = rowLogo.Cells[2].AddParagraph().AddImage("./wwwroot/pcv.jpg");
            imgDx.LockAspectRatio = true;
            imgDx.Width = Unit.FromCentimeter(3);
            imgDx.Height = Unit.FromCentimeter(3);

            #endregion

            #region ReportNumber

            var tableReportNumber = section.AddTable();
            tableReportNumber.Style = "Table";
            tableReportNumber.Borders.Width = 1;
            tableReportNumber.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnReportNumber = tableReportNumber.AddColumn("9cm");
            columnReportNumber.Format.Alignment = ParagraphAlignment.Left;

            var columnReportNumberDate = tableReportNumber.AddColumn("9cm");
            columnReportNumberDate.Format.Alignment = ParagraphAlignment.Right;

            var rowReportNumber = tableReportNumber.AddRow();
            rowReportNumber.Height = 25;
            rowReportNumber.VerticalAlignment = VerticalAlignment.Center;
            rowReportNumber.HeadingFormat = true;

            rowReportNumber.Cells[0].AddParagraph($"VERBALE N. {serviceReport.ReportNumber}");
            rowReportNumber.Cells[1].AddParagraph($"DATA: {serviceReport.Date.ToString("dd/MM/yyyy")}");

            GetEmptyRow(tableReportNumber, 1);

            #endregion

            #region ReportType

            var dictType = new Dictionary<string, bool>
            {
                {"MONITORAGGIO TERRITORIO", serviceReport.LandMonitoring},
                {"COR/SOUP", serviceReport.CorSoup},
                {"ESERCITAZIONE", serviceReport.Drill},
                {"GESTIONE ATTREZZATURA/SEDE", serviceReport.ToolOfficeManagement},
                {"CORSO FORMAZIONE", serviceReport.TrainingCourse},
                {"ALTRO", serviceReport.Other.IsChecked},
                {"EMERGENZA", serviceReport.Emergency.IsChecked},
            };

            var tableType = section.AddTable();
            tableType.Style = "Table";
            tableType.Borders.Width = 1;
            tableType.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnReportType = tableType.AddColumn("18cm");
            columnReportType.Format.Alignment = ParagraphAlignment.Left;

            var rowReportType = tableType.AddRow();
            rowReportType.Height = dictType.Count(dict => dict.Value) * 10;
            rowReportType.VerticalAlignment = VerticalAlignment.Center;
            rowReportType.HeadingFormat = true;

            foreach (var dict in dictType.Where(dict => dict.Value))
                rowReportType.Cells[0].AddParagraph($"{dict.Key}{(dict.Key == "ALTRO" ? " - [" + serviceReport.Other.Note + "]" : dict.Key == "EMERGENZA" ? " - [" + serviceReport.Emergency.Note + "]" : string.Empty)}");

            GetEmptyRow(tableType, 0);

            #endregion

            #region Operators

            var tableOperators = section.AddTable();
            tableOperators.Style = "Table";
            tableOperators.Borders.Width = 1;
            tableOperators.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnOperators = tableOperators.AddColumn("18cm");
            columnOperators.Format.Alignment = ParagraphAlignment.Left;

            var rowOperators = tableOperators.AddRow();
            rowOperators.Height = (serviceReport.Operators.Count + 1) * 10;
            rowOperators.VerticalAlignment = VerticalAlignment.Center;
            rowOperators.HeadingFormat = true;

            var p = new Paragraph().AddFormattedTextWithTab("17.7cm", $"CAPOSQUADRA: {serviceReport.TeamLeader.FullName}",
                $"MATRICOLA: {serviceReport.TeamLeader.BadgeId}", 14, false);
            rowOperators.Cells[0].Add(p);

            foreach (var reportOperator in serviceReport.Operators)
            {
                var pOps = new Paragraph().AddFormattedTextWithTab("17.7cm", $"ADDETTO: {reportOperator.FullName}",
                    $"MATRICOLA: {reportOperator.BadgeId}", 14, false);
                rowOperators.Cells[0].Add(pOps);
            }

            GetEmptyRow(tableOperators, 0);

            #endregion

            #region Vehicles

            var tableVehicles = section.AddTable();
            tableVehicles.Style = "Table";
            tableVehicles.Borders.Width = 1;
            tableVehicles.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnVehicles = tableVehicles.AddColumn("18cm");
            columnVehicles.Format.Alignment = ParagraphAlignment.Left;

            var rowVehicleHeader = tableVehicles.AddRow();
            rowVehicleHeader.Height = 10;
            rowVehicleHeader.VerticalAlignment = VerticalAlignment.Center;
            rowVehicleHeader.HeadingFormat = true;

            var rowVehicles = tableVehicles.AddRow();
            rowVehicles.Height = (serviceReport.Vehicles.Count) * 10;
            rowVehicles.VerticalAlignment = VerticalAlignment.Center;
            rowVehicles.HeadingFormat = true;

            rowVehicleHeader.Cells[0].AddParagraph("VEICOLI");

            foreach (var vehicle in serviceReport.Vehicles)
            {
                var pv = new Paragraph().AddFormattedTextWithTab("9.7cm", "17.7cm", $"MEZZO: {vehicle.Type}", $"TARGA: {vehicle.Plate}", $"TOT KM: {vehicle.TotKm}", 14, false);
                rowVehicles.Cells[0].Add(pv);
            }

            GetEmptyRow(tableVehicles, 0);

            #endregion

            #region Time

            var tableTime = section.AddTable();
            tableTime.Style = "Table";
            tableTime.Borders.Width = 0;
            tableTime.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnTime = tableTime.AddColumn("18cm");
            columnTime.Format.Alignment = ParagraphAlignment.Left;

            var rowTimeHeader1 = tableTime.AddRow();
            rowTimeHeader1.Height = 7;
            rowTimeHeader1.VerticalAlignment = VerticalAlignment.Center;
            rowTimeHeader1.HeadingFormat = true;

            var rowTime1 = tableTime.AddRow();
            rowTime1.Height = 10;
            rowTime1.VerticalAlignment = VerticalAlignment.Center;
            rowTime1.HeadingFormat = true;

            var rowTimeHeader2 = tableTime.AddRow();
            rowTimeHeader2.Height = 7;
            rowTimeHeader2.VerticalAlignment = VerticalAlignment.Center;
            rowTimeHeader2.HeadingFormat = true;

            var rowTime2 = tableTime.AddRow();
            rowTime2.Height = 10;
            rowTime2.VerticalAlignment = VerticalAlignment.Center;
            rowTime2.HeadingFormat = true;

            var firstGroup = new Paragraph();
            firstGroup.AddFormattedText("1° GRUPPO", new Font { Size = 10, Bold = true, Color = Colors.Black });
            rowTimeHeader1.Cells[0].Add(firstGroup);

            var time1 = new Paragraph().AddFormattedTextWithTab("12.7cm", "17.7cm", $"ORA DI PARTENZA: {serviceReport.FirstGroup.DepartureTime:HH:mm}", $"ORA DI ARRIVO: {serviceReport.FirstGroup.ArrivalTime:HH:mm}", $"ORE TOTALI: {serviceReport.FirstGroup.TotalHours}", 14, false);
            rowTime1.Cells[0].Add(time1);

            var secondGroup = new Paragraph();
            secondGroup.AddFormattedText("2° GRUPPO", new Font { Size = 10, Bold = true, Color = Colors.Black });
            rowTimeHeader2.Cells[0].Add(secondGroup);

            var time2 = new Paragraph().AddFormattedTextWithTab("12.7cm", "17.7cm", $"ORA DI PARTENZA: {serviceReport.SecondGroup.DepartureTime:HH:mm}", $"ORA DI ARRIVO: {serviceReport.SecondGroup.ArrivalTime:HH:mm}", $"ORE TOTALI: {serviceReport.SecondGroup.TotalHours}", 14, false);
            rowTime2.Cells[0].Add(time2);

            tableTime.SetEdge(0, 0, 1, 4, Edge.Left, BorderStyle.Single, 1);
            tableTime.SetEdge(0, 0, 1, 4, Edge.Right, BorderStyle.Single, 1);
            tableTime.SetEdge(0, 0, 1, 4, Edge.Top, BorderStyle.Single, 1);
            tableTime.SetEdge(0, 0, 1, 4, Edge.Bottom, BorderStyle.Single, 1);
            
            GetEmptyRow(tableTime, 0);

            #endregion

            #region Note

            var tableNote = section.AddTable();
            tableNote.Style = "Table";
            tableNote.Borders.Width = 0;
            tableNote.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnNote = tableNote.AddColumn("18cm");
            columnNote.Format.Alignment = ParagraphAlignment.Left;

            var rowNoteHeader = tableNote.AddRow();
            rowNoteHeader.Height = 10;
            rowNoteHeader.VerticalAlignment = VerticalAlignment.Center;
            rowNoteHeader.HeadingFormat = true;

            var rowNote = tableNote.AddRow();
            rowNote.Height = 150;
            rowNote.VerticalAlignment = VerticalAlignment.Center;
            rowNote.HeadingFormat = true;

            rowNoteHeader.Cells[0].AddParagraph("NOTE");

            rowNote.Cells[0].AddParagraph(serviceReport.Note);

            GetEmptyRow(tableNote, 0);


            #endregion
        }

        private void DefineStyles()
        {
            // Get the predefined style Normal.
            var style = Document.Styles["Normal"];
            style.Font.Name = "Calibri";

            // Create a new style called Table based on style Normal
            style = Document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Calibri";
            style.Font.Size = 14;
        }

        private static void GetEmptyRow(Table table, int merge)
        {
            var emptyRow = table.AddRow();
            emptyRow.Borders.Width = 0;
            emptyRow.Cells[0].AddParagraph(" ");
            emptyRow.Cells[0].Format.Font.Size = 3;
            emptyRow.Cells[0].MergeRight = merge;
        }
    }
}