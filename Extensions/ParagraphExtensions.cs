using MigraDoc.DocumentObjectModel;

namespace ProCivReport.Extensions
{
    public static class ParagraphExtensions
    {
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