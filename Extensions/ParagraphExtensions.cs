using MigraDoc.DocumentObjectModel;

namespace ProCivReport.Extensions
{
    public static class ParagraphExtensions
    {
        public static Paragraph AddFormattedTextToParagraph(this Paragraph p, string caption, string text, int fontSize, int lineBreaks = 2)
        {
            var fontBold = new Font { Size = fontSize, Bold = true, Color = Colors.Black };
            var fontNormal = new Font { Size = fontSize, Bold = false, Color = Colors.Black };

            p.AddFormattedText(caption, fontBold );
            //p.AddLineBreak();
            p.AddFormattedText(!string.IsNullOrEmpty(text) ? text : "N/D", fontNormal);
            //p.AddLineBreak(lineBreaks);

            return p;
        }

        public static Paragraph AddLineBreak(this Paragraph p, int nrLine)
        {
            for (var i = 0; i < nrLine; i++)
                p.AddLineBreak();

            return p;
        }

        public static Paragraph AddFormattedTextWithTab(this Paragraph p, string tabPosition, string leftText, string rightText, int fontSize, bool fontBold, string color = "Black")
        {
            p.Format.TabStops.AddTabStop(tabPosition, TabAlignment.Right);
            p.AddFormattedText(leftText, new Font { Size = fontSize, Bold = fontBold, Color = color == "White" ? Colors.White : Colors.Black });
            p.AddTab();
            p.AddFormattedText(rightText, new Font { Size = fontSize, Bold = fontBold, Color = color == "White" ? Colors.White : Colors.Black });
            return p;
        }

        public static Paragraph AddFormattedTextWithTab(this Paragraph p, string tabPositionL, string tabPositionR, string leftText, string centerText, string rightText, int fontSize, bool fontBold, string color = "Black")
        {
            p.Format.TabStops.AddTabStop(tabPositionL, TabAlignment.Right);
            p.AddFormattedText(leftText, new Font { Size = fontSize, Bold = fontBold, Color = color == "White" ? Colors.White : Colors.Black });
            p.AddTab();
            p.Format.TabStops.AddTabStop(tabPositionR, TabAlignment.Right);
            p.AddFormattedText(centerText, new Font { Size = fontSize, Bold = fontBold, Color = color == "White" ? Colors.White : Colors.Black });
            p.AddTab();
            p.AddFormattedText(rightText, new Font { Size = fontSize, Bold = fontBold, Color = color == "White" ? Colors.White : Colors.Black });
            return p;
        }
    }
}