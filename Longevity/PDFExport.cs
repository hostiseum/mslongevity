using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using iTextSharp.tool.xml;

namespace Longevity
{
    class PDFExport
    {

        public static void GeneratePDF(string html)
        {
            StringReader sr = new StringReader(html);

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
         
            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();

                byte[] bytes = memoryStream.ToArray();
                string directory = Path.Combine(Environment.CurrentDirectory, "reports");
                Directory.CreateDirectory(directory);
                File.WriteAllBytes(Path.Combine(directory, string.Format("{0}.pdf", DateTime.Now.ToString("yyyyMMddhhmm"))), bytes);

                memoryStream.Close();
            }
        }
    }
}
