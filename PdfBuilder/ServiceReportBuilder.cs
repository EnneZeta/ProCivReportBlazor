using System;
using ProCivReport.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

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
            CreateTable();
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

        private void CreateTable()
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
            columnLogoSx.Format.Alignment = ParagraphAlignment.Center;

            var columnHeader = tableLogo.AddColumn("9cm");
            columnHeader.Format.Alignment = ParagraphAlignment.Center;

            var columnLogoDx = tableLogo.AddColumn("4cm");
            columnLogoDx.Format.Alignment = ParagraphAlignment.Center;

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
    }
}