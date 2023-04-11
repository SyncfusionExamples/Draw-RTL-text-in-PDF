# Adding RTL Support to PDF in Xamarin

The [Syncfusion Essential PDF](https://www.syncfusion.com/document-processing/pdf-framework/net) is a .NET PDF library  from the Essential Studio can be used to draw right-to-left (RTL) and bi-directional (Bidi) text in a PDF document.


## What is right-to-left support?

In a right-to-left script, writing starts from the right side of the PDF page and continues to the left. The most commonly used RTL scripts are Arabic, Hebrew, Persian, and Urdu. 

                     مرحبا بالعالم      

## What is bi-directional support?  

Bi-directional text contains both right-to-left and left-to-right formats. For instance, a line may contain both Arabic and English texts. As you might imagine, there are several possibilities when dealing with Bidi text. Arabic text is written from right-to-left, but numbers are generally written left-to-right.

                   هناك 10 تفاحات 

## Adding RTL support to your PDF

While this post deals with the overall understanding of right-to-left, left-to-right, and bi-directional text, a little bit of code can help to understand how things works in the PDF.

1.Create a cross-platform app in Xamarin.Forms.

<img src="RTLDemo/Images/RTL-1.png" alt="Xamarin forms" width="100%" Height="Auto"/>

2.Select the Blank App template and the .NET Standard option under Code Sharing Strategy. 

<img src="RTLDemo/Images/RTL-2.png" alt="Blank App" width="100%" Height="Auto"/>

3.Add the [Syncfusion.Xamarin.PDF](https://www.nuget.org/packages/Syncfusion.Xamarin.Pdf/) NuGet packages as a reference to the .Net Standard project in your Xamarin application.

<img src="RTLDemo/Images/RTL-3.png" alt="NuGet Package" width="100%" Height="Auto"/>

4.Since the PDF standard font does not support Unicode character, you will need to add the TrueType font file to the assets folder in the .NET Standard project. Right click the font, select properties, and set its build action as embedded resource.

5.Add a button in the MainPage.xaml file.

```csharp

<?xml version="1.0" encoding="utf-8"?>
<ContentPage font-weight: bold;">//xamarin.com/schemas/2014/forms"
             >:x="http://schemas.microsoft.com/winfx/2009/xaml"
             >:local="clr-namespace:RTLSample"
             x:Class="RTLSample.MainPage">

    <StackLayout Padding="10">
        <Label x:Name="Content_heading" Text="Right-to-left text in PDF" FontSize="Large" FontAttributes="Bold" HorizontalOptions="Center" VerticalOptions="Center"></Label>
        <Label x:Name="Content_1" Text="This sample demonstrates how to add RTL text in the PDF document." FontSize="Medium" VerticalOptions="Center"></Label>
        <Button x:Name="btnGenerate" Text="Generate PDF" HorizontalOptions="Center" VerticalOptions="Center"></Button>
    </StackLayout>

</ContentPage>
```

6.Add the following code with the onButtonClicked method in the MainPage.xaml.cs file.

```csharp
//Create a new PDF document.
PdfDocument document = new PdfDocument();
//Add a new PDF page.
PdfPage page = document.Pages.Add();
//Load font.
Stream fontStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("RTLDemo.Assets.arial.ttf");

//Create PDF TrueType font.
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
```

The following screenshot shows the output of the RTL support.

<img src="RTLDemo/Images/RTL-4.png" alt="Output Document" width="100%" Height="Auto"/>



