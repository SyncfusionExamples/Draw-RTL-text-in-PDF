using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RTLDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void btn_Clicked(object sender, EventArgs e)
        {
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();

            //Add a new PDF page.
            PdfPage page = document.Pages.Add();

            //Load font.
            Stream fontStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("RTLDemo.Assets.arial.ttf");

            //Create PDF true type font.
            PdfFont pdfFont = new PdfTrueTypeFont(fontStream, 12);

            //String format 
            PdfStringFormat format = new PdfStringFormat();

            //Set the format as right to left.
            format.TextDirection = PdfTextDirection.RightToLeft;

            //Set the alignment.
            format.Alignment = PdfTextAlignment.Right;

            SizeF pageSize = page.GetClientSize();

            page.Graphics.DrawString("مرحبا بالعالم!", pdfFont, PdfBrushes.Black, new Syncfusion.Drawing.RectangleF(0, 0, pageSize.Width, pageSize.Height), format);
            MemoryStream ms = new MemoryStream();

            //Save the document.
            document.Save(ms);

            //Close the document 
            document.Close(true);

            ms.Position = 0;

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("RTLText.pdf", "application/pdf", ms);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("RTLText.pdf", "application/pdf", ms);

        }
    }
}
