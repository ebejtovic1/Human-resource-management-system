using HRMSCrypto.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Document = iTextSharp.text.Document;
using Font = iTextSharp.text.Font;

namespace HRMSCrypto.Reports
{
    public class ReportDepartment
    {
        IWebHostEnvironment webHostEnvironment;
        List<DepartmentViewModel> departments;
      
        public ReportDepartment(IWebHostEnvironment _webHostEnvironment, List<DepartmentViewModel> _departments)
        {
            webHostEnvironment = _webHostEnvironment;
            departments = _departments;
           
        }

        #region Declaration
        int maxColumn = 4;//field i naziv
        Document document;
        Font fontStyle;
        PdfPTable pTable = new PdfPTable(4);
        PdfPCell pCell;
        MemoryStream memStream = new MemoryStream();

        #endregion

        public byte[] Report()
        {
            document = new Document();

            document.SetPageSize(PageSize.A4);
            document.SetMargins(5f, 5f, 20f, 5f);

            pTable.WidthPercentage = 100;
            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter pWriter = PdfWriter.GetInstance(document, memStream);
            document.Open();

            float[] sizes = new float[maxColumn];
            for (int i = 0; i < maxColumn; i++)
            {
                if (i == 0) sizes[i] = 50;
                else sizes[i] = 100;
            }
            pTable.SetWidths(sizes);

            pCell = new PdfPCell(new Phrase("HRMS Crypto", FontFactory.GetFont("Tahoma", 20f, 1)));
            pCell.Colspan = maxColumn;
            pCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pCell.Border = 0;
            pCell.ExtraParagraphSpace = 20;
            pTable.AddCell(pCell);
            pTable.CompleteRow();

            pCell = new PdfPCell(new Phrase("All departments", FontFactory.GetFont("Tahoma", 16f, 1)));
            pCell.Colspan = maxColumn;
            pCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pCell.Border = 0;
            pCell.ExtraParagraphSpace = 20;
            pTable.AddCell(pCell);
            pTable.CompleteRow();

            this.EmptyRow(2);
            this.ReportBody();

            pTable.HeaderRows = 2;
            document.Add(pTable);
            document.Close();

            return memStream.ToArray();
        }
        private void EmptyRow(int broj)
        {
            for (int i = 0; i < broj; i++)
            {
                pCell = new PdfPCell(new Phrase("", fontStyle));
                pCell.Colspan = maxColumn;
                pCell.Border = 0;
                pCell.ExtraParagraphSpace = 10;
                pTable.AddCell(pCell);
                pTable.CompleteRow();
            }
        }
        private void ReportBody()
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma", 10f, 1);
            fontStyle = FontFactory.GetFont("Tahoma", 10f, 0);
            #region Table Kolone

            pCell = new PdfPCell(new Phrase("Id", fontStyleBold));
            pCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pCell.ExtraParagraphSpace = 8;
            pCell.BackgroundColor = BaseColor.Cyan;
            pTable.AddCell(pCell);

            pCell = new PdfPCell(new Phrase("Name", fontStyleBold));
            pCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pCell.ExtraParagraphSpace = 8;
            pCell.BackgroundColor = BaseColor.Cyan;
            pTable.AddCell(pCell);

            pCell = new PdfPCell(new Phrase("Address", fontStyleBold));
            pCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pCell.ExtraParagraphSpace = 8;
            pCell.BackgroundColor = BaseColor.Cyan;
            pTable.AddCell(pCell);

            pCell = new PdfPCell(new Phrase("City", fontStyleBold));
            pCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pCell.ExtraParagraphSpace = 8;
            pCell.BackgroundColor = BaseColor.Cyan;
            pTable.AddCell(pCell);

            pTable.CompleteRow();

            #endregion

            #region Table Tijelo

            foreach (var department in departments)
            {

                pCell = new PdfPCell(new Phrase(department.Id.ToString(), fontStyle));
                pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pCell.ExtraParagraphSpace = 5;
                pCell.BackgroundColor = BaseColor.White;
                pTable.AddCell(pCell);

                pCell = new PdfPCell(new Phrase(department.Name, fontStyle));
                pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pCell.BackgroundColor = BaseColor.White;
                pCell.ExtraParagraphSpace = 5;
                pTable.AddCell(pCell);

                pCell = new PdfPCell(new Phrase(department.Location.Address, fontStyle));
                pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pCell.ExtraParagraphSpace = 5;
                pCell.BackgroundColor = BaseColor.White;
                pTable.AddCell(pCell);

                pCell = new PdfPCell(new Phrase(department.Location.City, fontStyle));
                pCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pCell.ExtraParagraphSpace = 5;
                pCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pCell.BackgroundColor = BaseColor.White;
                pTable.AddCell(pCell);

                pTable.CompleteRow();
            }
            #endregion
        }


    }
}
