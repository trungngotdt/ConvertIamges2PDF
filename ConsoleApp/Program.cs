using System;
namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string parameterFolderImages = "--folder";
            const string parameterHeight = "--height";
            const string parameterWidth = "--width";
            const string parameterFileName = "--file";
            const string parameterPagesIndex = "--page-index";
            const string parameterType = "--type";

            Console.WriteLine("Working");
            int pages = -1;
            string folderImage = String.Empty;
            int height = -1;
            int width = -1;
            string fileName = String.Empty;
            string typeImage = string.Empty;

            var length = args.Length;

            for (int i = 0; i < length; i++)
            {
                switch (args[i])
                {
                    case parameterPagesIndex:
                        int.TryParse(args[i + 1], out pages);
                        break;
                    case parameterHeight:
                        int.TryParse(args[i + 1], out height);
                        break;
                    case parameterWidth:
                        int.TryParse(args[i + 1], out width);
                        break;
                    case parameterType:
                        typeImage = args[i + 1];
                        break;
                    case parameterFileName:
                        fileName = args[i + 1];
                        break;
                    case parameterFolderImages:
                        folderImage = args[i + 1];
                        break;

                    default:
                        break;
                }
            }
            if (pages == -1 || height == -1 || width == -1 || string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(folderImage) || string.IsNullOrEmpty(typeImage))
            {
                Console.WriteLine("Empty parameters!");
                return;
            }

            ConvertIamges2PDF.Converter.Instance.CompressImagesPDF(width, height, fileName,pages, folderImage, typeImage);
        }
    }
}