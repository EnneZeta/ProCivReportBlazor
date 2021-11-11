using System;
using System.IO;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using ProCivReport.Extensions;
using ProCivReport.Models;

namespace ProCivReport.PdfBuilder
{
    public class LightingBreakdownsBuilder
    {
        private Document Document { get; set; }

        public string Build(Persistency persistency)
        {
            var year = DateTime.Now.Year.ToString("0000");
            var month = DateTime.Now.Month.ToString("00");
            var day = DateTime.Now.Day.ToString("00");
            var mainPath = $@"./wwwroot/pdf/{year}/{month}/{day}/";
            if (!Directory.Exists(mainPath))
                Directory.CreateDirectory(mainPath);

            var path = $@"{mainPath}/LightingBreakdowns_{DateTime.Now:yyyyMMdd_hhmmss}.Pdf";
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
            CreateTable(persistency);
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

        private void CreateTable(Persistency persistency)
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
            rowLogo.Cells[1].AddParagraph("SEGNALAZIONE GUASTI PUBBLICA ILLUMINAZIONE");
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
            columnReportNumberDate.Format.Alignment = ParagraphAlignment.Left;

            var rowReportNumber = tableReportNumber.AddRow();
            rowReportNumber.Height = 25;
            rowReportNumber.VerticalAlignment = VerticalAlignment.Center;
            rowReportNumber.HeadingFormat = true;

            var pReportNumber = new Paragraph().AddFormattedTextToParagraph("ALLEGATO AL VERBALE NR: ", persistency.LightingBreakdowns.ReportNumber, 14, 0);
            var pReportData = new Paragraph().AddFormattedTextToParagraph("DEL: ", persistency.LightingBreakdowns.Date.ToString("dd/MM/yyyy"), 14, 0);
            rowReportNumber.Cells[0].Add(pReportNumber);
            rowReportNumber.Cells[1].Add(pReportData);

            GetEmptyRow(tableReportNumber, 1);

            #endregion

            #region RowBreakdowns

            var tableBreak = section.AddTable();
            tableBreak.Style = "Table";
            tableBreak.Borders.Width = 0;
            tableBreak.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnNumber = tableBreak.AddColumn("7cm");
            columnNumber.Format.Alignment = ParagraphAlignment.Left;

            var columnStreet = tableBreak.AddColumn("7cm");
            columnStreet.Format.Alignment = ParagraphAlignment.Left;

            var columnStreetNumber = tableBreak.AddColumn("4cm");
            columnStreetNumber.Format.Alignment = ParagraphAlignment.Left;

            var rowBreakHeader = tableBreak.AddRow();
            rowBreakHeader.Height = 10;
            rowBreakHeader.VerticalAlignment = VerticalAlignment.Center;
            rowBreakHeader.HeadingFormat = true;

            var rowBreaks = tableBreak.AddRow();
            rowBreaks.Height = persistency.LightingBreakdowns.Breaks.Count * 10;
            rowBreaks.VerticalAlignment = VerticalAlignment.Center;
            rowBreaks.HeadingFormat = true;

            var pRowHeader = new Paragraph().AddFormattedTextWithTab("1cm", "GUASTI", "", 14, true, "White");
            rowBreakHeader.Cells[0].Add(pRowHeader);
            rowBreakHeader.Cells[0].Shading = new Shading { Color = Colors.Black };
            rowBreakHeader.Cells[0].Format.Font.Color = Colors.White;
            rowBreakHeader.Cells[1].AddParagraph("");
            rowBreakHeader.Cells[1].Shading = new Shading { Color = Colors.Black };
            rowBreakHeader.Cells[1].Format.Font.Color = Colors.White;
            rowBreakHeader.Cells[2].AddParagraph("");
            rowBreakHeader.Cells[2].Shading = new Shading { Color = Colors.Black };
            rowBreakHeader.Cells[2].Format.Font.Color = Colors.White;

            foreach (var breakObj in persistency.LightingBreakdowns.Breaks)
            {
                var pLamp = new Paragraph().AddFormattedTextToParagraph("LAMPIONE NR: ", breakObj.Light, 14, 0);
                var pStreet = new Paragraph().AddFormattedTextToParagraph("VIA: ", breakObj.Street, 14, 0);
                var pStreetNumber = new Paragraph().AddFormattedTextToParagraph("CIVICO: ", breakObj.StreetNumber, 14, 0);

                rowBreaks.Cells[0].Add(pLamp);
                rowBreaks.Cells[1].Add(pStreet);
                rowBreaks.Cells[2].Add(pStreetNumber);
            }

            tableBreak.SetEdge(0, 0, 3, 2, Edge.Left, BorderStyle.Single, 1);
            tableBreak.SetEdge(0, 0, 3, 2, Edge.Right, BorderStyle.Single, 1);
            tableBreak.SetEdge(0, 0, 3, 2, Edge.Bottom, BorderStyle.Single, 1);

            GetEmptyRow(tableBreak, 0);

            #endregion

            #region Signature

            var tableSignature = section.AddTable();
            tableSignature.Style = "Table";
            tableSignature.Borders.Width = 0;
            tableSignature.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnSignature = tableSignature.AddColumn("18cm");
            columnSignature.Format.Alignment = ParagraphAlignment.Right;

            var rowSignature = tableSignature.AddRow();
            rowSignature.Height = 10;
            rowSignature.VerticalAlignment = VerticalAlignment.Center;
            rowSignature.HeadingFormat = true;

            rowSignature.Cells[0].AddParagraph("IL CAPOSQUADRA");
            rowSignature.Cells[0].AddParagraph(persistency.ServiceReport.TeamLeader.FullName);

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