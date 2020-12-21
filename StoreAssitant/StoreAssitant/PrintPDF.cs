using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StoreAssitant.Class_Information;

namespace StoreAssitant
{
    class PrintPDF
    {
        private PrintPDF() { }
        static string dest = @".\Bill.pdf";
        static string dir_font = @"C:\Users\VuNgocThach\AppData\Local\Microsoft\Windows\Fonts\vuArial.ttf"; //sẽ sửa lại cái này
        public static void createBill(BillInfo info)
        {
            Rectangle defaultsize = PageSize.A5;

            //check if file is open
            try
            {
                using (FileStream r = File.OpenRead(dest)) { }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Tệp đang được mở ở tiến trình khác");
                return;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File chưa có, khởi tạo file");
            }

            //open stream to write on the file
            FileStream os = new FileStream(dest, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);

            Document doc = new Document(defaultsize);
            doc.SetMargins(0, 0, 0, 0);

            PdfWriter writer = PdfWriter.GetInstance(doc, os);

            //start write on the file
            doc.Open();

            BaseFont basef = BaseFont.CreateFont(dir_font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            //add title paragraph of the bill
            Paragraph title = new Paragraph("QUÁN ĂN ABC\n", new Font(basef, 15, Font.BOLD));
            title.Add(new Paragraph("Ký túc xá khu B Đại học QG TP HCM", new Font(basef, 10, Font.ITALIC)) { Alignment = Element.ALIGN_CENTER});
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 30;
            doc.Add(title);

            //add name and date of the bill
            Font font = new Font(basef, 12);
            PdfPTable tableName = new PdfPTable(2);
            float[] columns = new float[2];
            columns[0] = 40;
            columns[1] = 40;
            tableName.SetWidths(columns);
            tableName.AddCell(new PdfPCell(new Phrase("Số bàn: " + info.Number_table, font)) { HorizontalAlignment = PdfPCell.ALIGN_LEFT, Border = PdfPCell.NO_BORDER });
            tableName.AddCell(new PdfPCell(new Phrase("Ngày mua:" + info.DAY.ToString("dd/MM/yyyy"), font)) { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.NO_BORDER });
            tableName.SpacingAfter = 20;
            doc.Add(tableName);

            //add list product to pdf
            PdfPTable table = new PdfPTable(4);
            table.DefaultCell.Border = PdfPCell.NO_BORDER;

            //set height column of table
            float[] columnWidths = new float[4];
            columnWidths[0] = 50;
            columnWidths[1] = 40;
            columnWidths[2] = 50;
            columnWidths[3] = 40;
            table.SetWidths(columnWidths);

            table.AddCell(new Phrase("Tên món ăn", font));
            table.AddCell(new Phrase("Số lượng", font));
            table.AddCell(new Phrase("Đơn giá", font));
            table.AddCell(new Phrase("Thành tiền", font));

            //add list product
            foreach (var item in info.ProductBills)
            {
                table.AddCell(new Phrase(item.Name, font));
                table.AddCell(new Phrase(item.NumberProduct.ToString(), font));
                table.AddCell(new Phrase(item.Price.ToString("N0") + "VND", font));
                table.AddCell(new Phrase((item.Price * item.NumberProduct).ToString("N0") + "VND", font));
            }
            doc.Add(table);

            //add end paragraph of the bill
            Paragraph endpara = new Paragraph("Cảm ơn quý khách đã ghé, hẹn gặp lại quý khách!", new Font(basef, 10));
            endpara.Alignment = Element.ALIGN_CENTER;
            doc.Add(endpara);
            Console.WriteLine("ok");

            doc.Close();
            os.Close();
            writer.Close();
            Process.Start(dest);
        }
    }
}
