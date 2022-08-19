using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConvertIamges2PDF
{
    public class Converter
    {

        private static Converter instance = null;
        private static readonly object padlock = new object();
        private Converter()
        {

        }
        public static Converter Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Converter();
                        }
                    }
                }
                return instance;
            }
        }

        public void CompressImagesPDF(int width, int height, string fileName, int pages, string imagesFolder, string typeImage)
        {
            try
            {
                var isFilesExist = Directory.GetFiles(imagesFolder, "*." + typeImage).Length > 0;
                if (!isFilesExist)
                {
                    Console.WriteLine("No files in " + imagesFolder);
                    return;
                }

                using PdfDocument pdfDocument = new PdfDocument(new PdfWriter(Path.Combine(Directory.GetCurrentDirectory(), fileName)));
                Document document = new Document(pdfDocument);
                for (int i = 0; i < pages; i++)
                {
                    string file = Path.Combine(imagesFolder, i.ToString()+"." + typeImage);
                    Console.WriteLine("Compressing " + file);
                    ImageData imageData = ImageDataFactory.Create(file);
                    Image image = new Image(imageData);
                    image.SetWidth(width);
                    image.SetHeight(height);
                    document.Add(image);
                }
                pdfDocument.Close();
                
            }
            catch (Exception ex)
            {
                LoggerMethod(ex);
                throw;
            }

        }

        private void LoggerMethod(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}
