using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Printing;

namespace BrushesBitmapsPrinting
{
    public partial class TestVectorPrinting : UserControl
    {
        public TestVectorPrinting()
        {
            InitializeComponent();
        }

        private void cmdPrintBitmap_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += document_PrintPage;

            // The PrintBitmap() method always uses bitmap printing.
            document.PrintBitmap("My Document - Bitmap Version");
        }

        private void cmdPrintVector_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += document_PrintPage;

            // The Print() method may or may not use vector printing, depending on the
            // document and printer driver.
            document.Print("My Document");
        }

        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Use a Canvas for the printing surface.
            Canvas printSurface = new Canvas();
            e.PageVisual = printSurface;

            double topPosition = e.PageMargins.Top + extraMargin;
            for (int i = 0; i < 20; i++)
            {
                // Create a TextBlock.
                TextBlock txt = new TextBlock();
                txt.FontSize = 30;
                txt.Text = "This is a test of vector printing.";

                double measuredHeight = txt.ActualHeight;

                // Place the TextBlock on the Canvas.
                txt.SetValue(Canvas.TopProperty, topPosition);
                txt.SetValue(Canvas.LeftProperty, e.PageMargins.Left + extraMargin);
                printSurface.Children.Add(txt);

                topPosition += measuredHeight;
            }
            e.HasMorePages = false;
        }

        // Add some extra margin space.
        private int extraMargin = 50;
    }
}
