using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StoreAssitant.Class_Information;
using StoreAssitant.StoreAssistant_Helper;

namespace StoreAssitant
{
    class PrintPDF
    {
        static string dest = @".\Bill.pdf";
        static string dir_font = @"C:\Users\VuNgocThach\AppData\Local\Microsoft\Windows\Fonts\vuArial.ttf"; //sẽ sửa lại cái này
        static NumberFormatInfo nfi;
        private Rectangle defaultSize;
        FileStream os;
        Document doc;
        PdfWriter writer;
        BaseFont basef;

        private static PrintPDF instance;
        public static PrintPDF Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new PrintPDF();
                }
                return instance;
            }
        }

        private PrintPDF()
        {
            basef = BaseFont.CreateFont(dir_font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberGroupSeparator = " ";

            //check if file is open
            try
            {
                using (FileStream r = File.OpenRead(dest)) { }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("File is used by another process");
                return;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not exists, create new file");
            }

            //open stream to write on the file
        }
        public void createBill(BillInfo info)
        {
            os = new FileStream(dest, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            defaultSize = new Rectangle(PageSize.A5.Width, 312 + info.ProductBills.Count * 24 + info.ProductBills.Count(i=>i.Name.Length > 14) * 15);
            doc = new Document(defaultSize);
            doc.SetMargins(0, 0, 0, 0);

            writer = PdfWriter.GetInstance(doc, os);

            //start write
            doc.Open();

            //add title paragraph
            doc.Add(this.createTitle());

            //add name and date of the bill
            doc.Add(createInfoPurchase(info));

            //add product table 
            doc.Add(this.createTableInfoProduct(info));

            //add end paragraph
            doc.Add(createEndBill());

            //end write
            doc.Close();
            os.Close();
            writer.Close();

            doc.Dispose();
            os.Dispose();
            writer.Dispose();

            Process.Start(dest);
        }
        private Paragraph createTitle()
        {
            int spaceTwoParagraph = 10;
            Paragraph title = new Paragraph();
            title.Add(new Paragraph(AppManager.StoreInformation.Name, new Font(basef, 18, Font.BOLD)) 
            { Alignment = Element.ALIGN_CENTER, SpacingAfter = spaceTwoParagraph/2});
            title.Add(new Paragraph("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ THÔNG TIN", new Font(basef, 10, Font.ITALIC)) 
            { Alignment = Element.ALIGN_CENTER, SpacingAfter = spaceTwoParagraph/2 });
            title.Add(new Paragraph("Phone: " + AppManager.StoreInformation.PhoneNumber, new Font(basef, 10, Font.ITALIC))
            { Alignment = Element.ALIGN_CENTER, SpacingAfter = spaceTwoParagraph * 2 });
            title.Add(new Paragraph("HOÁ ĐƠN THANH TOÁN", new Font(basef, 16, Font.BOLD)) 
            { Alignment = Element.ALIGN_CENTER, SpacingAfter = spaceTwoParagraph});
            return title;
        }
        private PdfPTable createTableInfoProduct(BillInfo info)
        {
            Font font = new Font(basef, 12);
            PdfPTable table = new PdfPTable(4);
            table.DefaultCell.Border = PdfPCell.NO_BORDER;

            //set height column of table
            int[] columnWidths = new int[4];
            columnWidths[0] = 50;
            columnWidths[1] = 40;
            columnWidths[2] = 50;
            columnWidths[3] = 40;
            table.SetWidths(columnWidths);
            int defaultBorder = PdfPCell.BOTTOM_BORDER | PdfPCell.TOP_BORDER;

            table.AddCell(new PdfPCell(new Phrase("Tên món ăn", new Font(basef,12,Font.BOLD)))
            { Border = defaultBorder, VerticalAlignment = PdfPCell.ALIGN_MIDDLE, PaddingBottom = 10 });
            table.AddCell(new PdfPCell(new Phrase("Số lượng", new Font(basef, 12, Font.BOLD)))
            { HorizontalAlignment = PdfPCell.ALIGN_CENTER, Border = defaultBorder, VerticalAlignment = PdfPCell.ALIGN_MIDDLE, PaddingBottom = 10 });
            table.AddCell(new PdfPCell(new Phrase("Đơn giá", new Font(basef, 12, Font.BOLD)))
            { HorizontalAlignment = PdfPCell.ALIGN_CENTER, Border = defaultBorder, VerticalAlignment = PdfPCell.ALIGN_MIDDLE, PaddingBottom = 10 });
            table.AddCell(new PdfPCell(new Phrase("Thành tiền", new Font(basef, 12, Font.BOLD)))
            { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = defaultBorder, VerticalAlignment = PdfPCell.ALIGN_MIDDLE, PaddingBottom = 10 });

            //add list product
            foreach (var item in info.ProductBills)
            {
                table.AddCell(new PdfPCell(new Phrase(item.Name, font))
                { Border = PdfPCell.NO_BORDER, VerticalAlignment = PdfPCell.ALIGN_MIDDLE, PaddingBottom = 10 });

                table.AddCell(new PdfPCell(new Phrase(item.NumberProduct.ToString(), font))
                { Border = PdfPCell.NO_BORDER, HorizontalAlignment = PdfPCell.ALIGN_CENTER, VerticalAlignment = PdfPCell.ALIGN_MIDDLE, PaddingBottom = 10 });

                table.AddCell(new PdfPCell(new Phrase(item.Price.ToString("N0", nfi), font))
                { Border = PdfPCell.NO_BORDER, HorizontalAlignment = PdfPCell.ALIGN_CENTER, VerticalAlignment = PdfPCell.ALIGN_MIDDLE, PaddingBottom = 10 });

                table.AddCell(new PdfPCell(new Phrase((item.Price * item.NumberProduct).ToString("N0", nfi), font))
                { Border = PdfPCell.NO_BORDER, HorizontalAlignment = PdfPCell.ALIGN_RIGHT, VerticalAlignment = PdfPCell.ALIGN_MIDDLE, PaddingBottom = 10 });
            }
            //----------------------------------------------------------------------------------------------------
            //add table sum price of bill
            table.AddCell(new PdfPCell(new Phrase("Thành tiền:", new Font(basef, 12, Font.BOLD)))
            { Colspan = 3, Border = PdfPCell.TOP_BORDER, PaddingTop = 5});

            table.AddCell(new PdfPCell(new Phrase(info.TOTAL.ToString("N0", nfi), new Font(basef, 12, Font.BOLD)))
            { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.TOP_BORDER, PaddingTop = 5});

            table.AddCell(new PdfPCell(new Phrase("Giảm giá: ", new Font(basef, 10)))
            { Colspan = 3, Border = PdfPCell.NO_BORDER, PaddingBottom = 10 });

            table.AddCell(new PdfPCell(new Phrase((info.TOTAL - info.Price_Bill).ToString("N0", nfi), new Font(basef, 10)))
            { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.NO_BORDER, PaddingBottom = 10 });
            //-----------------------------------------------------------------------------------------------------
            table.AddCell(new PdfPCell(new Phrase("Tổng cộng:", new Font(basef, 13, Font.BOLD)))
            { Colspan = 3, Border = PdfPCell.TOP_BORDER, PaddingTop = 5 });

            table.AddCell(new PdfPCell(new Phrase(info.Price_Bill.ToString("N0", nfi), new Font(basef, 13, Font.BOLD)))
            { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.TOP_BORDER, PaddingTop = 5 });

            table.AddCell(new PdfPCell(new Phrase("Tiền khách đưa:", new Font(basef, 12, Font.BOLD)))
            { Colspan = 3, Border = PdfPCell.NO_BORDER });

            table.AddCell(new PdfPCell(new Phrase(info.Take.ToString("N0", nfi), new Font(basef, 12, Font.BOLD)))
            { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.NO_BORDER });

            table.AddCell(new PdfPCell(new Phrase("Tiền trả khách:", new Font(basef, 10, Font.BOLD)))
            { Colspan = 3, Border = PdfPCell.BOTTOM_BORDER, PaddingBottom = 20 });

            table.AddCell(new PdfPCell(new Phrase(info.Give.ToString("N0", nfi), new Font(basef, 10, Font.BOLD)))
            { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.BOTTOM_BORDER, PaddingBottom = 20 });
            //-----------------------------------------------------------------------------------------------------           
            return table;
        }
        private Paragraph createEndBill()
        {
            Paragraph para = new Paragraph("Cảm ơn quý khách đã ghé, hẹn gặp lại quý khách!", new Font(basef, 10));
            para.Alignment = Element.ALIGN_CENTER;
            return para;
        }
        private PdfPTable createInfoPurchase(BillInfo info)
        {
            Font font = new Font(basef, 12);
            PdfPTable table = new PdfPTable(2);
            float[] columns = new float[2];
            columns[0] = 40;
            columns[1] = 40;
            table.SetWidths(columns);
            table.AddCell(new PdfPCell(new Phrase("Số bàn: " + info.Number_table, font)) { HorizontalAlignment = PdfPCell.ALIGN_LEFT, Border = PdfPCell.NO_BORDER });
            table.AddCell(new PdfPCell(new Phrase("Ngày mua:" + info.DAY.ToString("dd/MM/yyyy"), font)) { HorizontalAlignment = PdfPCell.ALIGN_RIGHT, Border = PdfPCell.NO_BORDER });
            table.SpacingAfter = 20;
            return table;
        }
    }
}
