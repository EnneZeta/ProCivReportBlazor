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
    public class PathBuilder
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

            var path = $@"{mainPath}/Path_{DateTime.Now:yyyyMMdd_hhmmss}.Pdf";
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
            rowLogo.Cells[1].AddParagraph("MONITORAGGIO PERIODICO DEL TERRITORIO");
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

            var columnReportNumber = tableReportNumber.AddColumn("18cm");
            columnReportNumber.Format.Alignment = ParagraphAlignment.Center;

            var rowReportNumber = tableReportNumber.AddRow();
            rowReportNumber.Height = 25;
            rowReportNumber.VerticalAlignment = VerticalAlignment.Center;
            rowReportNumber.HeadingFormat = true;

            var pPathNumber = new Paragraph().AddFormattedTextToParagraph("PERCORSO NR: ", persistency.Paths.NrPath, 14, 0);
            rowReportNumber.Cells[0].Add(pPathNumber);

            GetEmptyRow(tableReportNumber, 0);

            #endregion

            #region Paths

            var tablePaths = section.AddTable();
            tablePaths.Style = "Table";
            tablePaths.Borders.Width = 1;
            tablePaths.Rows.LeftIndent = Unit.FromCentimeter(leftIndentToCenterTable);

            var columnCheck = tablePaths.AddColumn("1cm");
            columnCheck.Format.Alignment = ParagraphAlignment.Right;

            var columnStreet = tablePaths.AddColumn("8cm");
            columnStreet.Format.Alignment = ParagraphAlignment.Left;

            var columnCheck1 = tablePaths.AddColumn("1cm");
            columnCheck1.Format.Alignment = ParagraphAlignment.Right;

            var columnStreet1 = tablePaths.AddColumn("8cm");
            columnStreet1.Format.Alignment = ParagraphAlignment.Left;

            var rowPaths = tablePaths.AddRow();
            rowPaths.Height = persistency.Paths.StreetList.Count * 10;
            rowPaths.VerticalAlignment = VerticalAlignment.Top;
            rowPaths.HeadingFormat = true;

            var i = 0;
            foreach (var street in persistency.Paths.StreetList)
            {
                var cells0 = 0;
                var cells1 = 1;

                if (i > 26)
                {
                    cells0 = 2;
                    cells1 = 3;
                }
                    
                var imgCheck = rowPaths.Cells[cells0].AddParagraph().AddImage("./wwwroot/Checked.png");
                imgCheck.LockAspectRatio = true;
                imgCheck.Width = Unit.FromCentimeter(0.4);
                imgCheck.Height = Unit.FromCentimeter(0.4);

                rowPaths.Cells[cells1].AddParagraph(!string.IsNullOrEmpty(street.Name) ? street.Name : "");
                i++;
            }

            GetEmptyRow(tablePaths, 3);

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
            style.Font.Size = 12;
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