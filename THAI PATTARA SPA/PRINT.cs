using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Printing;
using System.Data;
using GenCode128;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class PRINT
    {
        static string _fileName = "";
        static string _printType = "";
        static string _printerName = "";
        static Form _owner = null;
        static string _card_no = "";
        static string _customerName = "";
        static string _expiryDate = "";
        static string _spaProgramName = "";
        static string _price = "";
        static string _from = "";
        static string _for = "";
        static string _therapist_id = "";
        static bool _isFile = false;
        static Dictionary<string, string> Params;

        static PaperSize _paperSize = null;
        static int _rawKind = 0;
        static Image _imageData = null;
        static PrintDocument _pd = null;
        static RectangleF _printableArea;
        static PrinterResolution _printerResolution;
        static PrintPreviewDialog PPD;

        static Font regular;
        static Font boldUnderline;
        static Font bold;
        static Brush brush;
        static StringFormat alignRight;

        static bool isMemberCardFront = false;
        static bool isMemberCardBack = false;
        static bool isMemberCardLetter = false;

        public static Form owner { get { return _owner; } set { _owner = value; } }
        public static string fileName { get { return _fileName; } set { _fileName = value; } }
        public static string printType { get { return _printType; } set { _printType = value; } }
        public static string printerName { get { return _printerName; } set { _printerName = value; } }
        public static PaperSize paperSize { get { return _paperSize; } set { _paperSize = value; } } // paperSize width and height = cm or mm convert to inch then x 100
        public static int rawKind { get { return _rawKind; } set { _rawKind = value; } } // for custom paper size = 999
        private static Image imageData { get { return _imageData; } set { _imageData = value; } }
        private static PrintDocument pd { get { return _pd; } set { _pd = value; } }
        public static RectangleF printableArea { get { return _printableArea; } set { _printableArea = value; } }
        private static PrinterResolution printerResolution { get { return _printerResolution; } set { _printerResolution = value; } }
        public static string card_no { get { return _card_no; } set { _card_no = value; } }
        public static string customerName { get { return _customerName; } set { _customerName = value; } }
        public static string expiryDate { get { return _expiryDate; } set { _expiryDate = value; } }
        public static string spaProgramName { get { return _spaProgramName; } set { _spaProgramName = value; } }
        public static string price { get { return _price; } set { _price = value; } }
        public static string from_txt { get { return _from; } set { _from = value; } }
        public static string for_txt { get { return _for; } set { _for = value; } }
        public static string therapist_id { get { return _therapist_id; } set { _therapist_id = value; } }
        public static bool isFile { get { return _isFile; } set { _isFile = value; } }

        public static void initPrint(bool isFile, string printType, string fileName, Form owner, bool isMemberCardFront = false, bool isMemberCardBack = false, bool isMemberCardLetter = false, string card_no = "", string expiryDate = "", string spaProgramName = "", string price = "", string from_txt = "", string for_txt = "")
        {
            if (fileName.Trim() != String.Empty)
            {
                if (!File.Exists(@"C:\SMS_CARDS\" + fileName))
                {
                    GF.doDebug("MISSING fileName : " + fileName);
                    MessageBox.Show("IMAGE FILE IS NOT EXITED !!\r\n\r\nTRYING TO GET FILES FROM SERVER ...", "ERROR");
                    using (progress progressPage = new progress())
                    {
                        progressPage.isOpening = false;
                        progressPage.ShowDialog();
                    }
                }
            }

            GF.showLoading();
            PRINT.isFile = isFile;
            PRINT.printType = printType.ToUpper();
            PRINT.fileName = fileName;
            PRINT.owner = owner;
            PRINT.card_no = card_no;
            PRINT.expiryDate = expiryDate;
            PRINT.spaProgramName = spaProgramName;
            PRINT.price = price;
            PRINT.from_txt = from_txt;
            PRINT.for_txt = for_txt;

            PRINT.isMemberCardFront = isMemberCardFront;
            PRINT.isMemberCardBack = isMemberCardBack;
            PRINT.isMemberCardLetter = isMemberCardLetter;
            
            PRINT.doPrint();
        }

        public static void doPrint()
        {
            try
            {
                PRINT.printerResolution = new PrinterResolution();
                GF.doDebug("INIT PRINT DOCUMENT FOR " + printType + " // FILE NAME : " + fileName);
                switch (printType)
                {
                    case "EMPLOYEE_BARCODE":
                        if (!setPrinter(Properties.Settings.Default.barcode_printer_name)) return;
                        PRINT.rawKind = 256;
                        //PRINT.printerResolution.Kind = PrinterResolutionKind.High;
                        /*PRINT.printerResolution.Kind = PrinterResolutionKind.Custom;
                        PRINT.printerResolution.X = 200;
                        PRINT.printerResolution.Y = 200;*/
                        initPrintDocument();
                        break;
                    case "INVOICE":
                    case "CARD_USAGE":
                    case "SPA_CARD_NEW":
                        if (!setPrinter(Properties.Settings.Default.invoice_printer_name)) return;
                        initPrintDocument();
                        break;
                    case "ATTACHMENT":
                    case "DOCUMENT":
                    case "GIFT_CERTIFICATE_LETTER":
                    case "MEMBERCARD_LETTER":
                    case "MEMBERCARD_LIMITED_EDITION_LETTER":
                    case "SPA_CARD":
                        if (!setPrinter(Properties.Settings.Default.attachment_printer_name)) return;
                        PRINT.rawKind = 9;
                        PRINT.paperSize = null;
                        initPrintDocument();
                        break;
                    case "GIFT_VOUCHER":
                    case "GIFT_CERTIFICATE":
                    case "SPECIAL CARD":
                        if (!setPrinter(Properties.Settings.Default.photo_printer_name)) return;
                        //if (!setPrinter(Properties.Settings.Default.attachment_printer_name)) return;
                        PRINT.rawKind = 9;
                        initPrintDocument();
                        break;

                    case "BARCODE":
                        if (!setPrinter(Properties.Settings.Default.barcode_printer_name)) return;
                        PRINT.paperSize = new PaperSize("MEMBERCARD", 338, 212);
                        PRINT.rawKind = 999;
                        break;

                    case "MEMBERCARD": case "MEMBERCARD_LIMITED_EDITION":
                        if (!setPrinter(Properties.Settings.Default.card_printer_name)) return;
                        //if (!setPrinter(Properties.Settings.Default.attachment_printer_name)) return;
                        PRINT.printerResolution.Kind = PrinterResolutionKind.Custom;
                        PRINT.printerResolution.X = 300;
                        PRINT.printerResolution.Y = 300;
                        PRINT.rawKind = 257;
                        if (Properties.Settings.Default.card_printer_name.IndexOf("PDF") != -1) PRINT.paperSize = new PaperSize("CARD", 341, 213);
                        //else PRINT.paperSize = new PaperSize("MEMBERCARD", 338, 212);
                        initPrintDocument();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "PRINTER ERROR !!");
                GF.closeLoading();
            }
        }

        static void initPrintDocument()
        {
            using (pd = new PrintDocument())
            {
                pd.DocumentName = printType + ":" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                pd.PrinterSettings.PrinterName = PRINT.printerName;

                //checkPaperSize(pd);
                //checkPaperSource(pd);

                GF.doDebug("THIS RAW KIND : " + PRINT.rawKind);
                GF.doDebug("THIS PAPER SIZE : " + PRINT.paperSize);
                
                if (PRINT.rawKind != 0) pd.DefaultPageSettings.PaperSize.RawKind = PRINT.rawKind;
                if (PRINT.paperSize != null) pd.DefaultPageSettings.PaperSize = PRINT.paperSize;
                //MessageBox.Show(pd.DefaultPageSettings.PaperSize.Width.ToString() + " x " + pd.DefaultPageSettings.PaperSize.Height.ToString());
                GF.doDebug("PD RAW KIND : " + pd.DefaultPageSettings.PaperSize.RawKind);
                GF.doDebug("PD PAPER SIZE : " + pd.DefaultPageSettings.PaperSize);

                if (PRINT.printerResolution != null) pd.DefaultPageSettings.PrinterResolution = PRINT.printerResolution;

                if (printType.IndexOf("MEMBERCARD") != -1 || printType == "SPA_CARD_NEW" || printType == "INVOICE" || printType == "CARD_USAGE" || printType == "MONEY_GC_USAGE") pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                else pd.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
                
                pd.PrintPage += (sender, e) =>
                {
                    if (fileName != "" && printType != "INVOICE" && printType != "CARD_USAGE" && printType != "MONEY_GC_USAGE" && printType != "SPA_CARD_NEW")
                    {
                        string folderName = printType;
                        if (printType.IndexOf("GIFT_CERTIFICATE") != -1) folderName = "GIFT_CERTIFICATE";
                        if (printType.IndexOf("MEMBERCARD") != -1) folderName = "MEMBERCARD";
                        if (printType == "SPA_CARD_NEW") folderName = "SPA_CARD";

                        System.Reflection.Assembly thisExe;
                        thisExe = System.Reflection.Assembly.GetExecutingAssembly();

                        using (imageData = Image.FromFile(@"C:\SMS_CARDS\" + fileName))
                        {

                            Rectangle marginBound = resizeBound(e, imageData);

                            if (printType.IndexOf("MEMBERCARD") != -1) e.Graphics.DrawImage(imageData, new Point(0, 0));
                            else e.Graphics.DrawImage(imageData, marginBound);
                        }

                        /*using (imageData = FTP.download(fileName, folderName))
                        {
                            Rectangle marginBound = resizeBound(e, imageData);

                            if (printType.IndexOf("MEMBERCARD") != -1) e.Graphics.DrawImage(imageData, new Point(0, 0));
                            else e.Graphics.DrawImage(imageData, marginBound);
                        }*/
                    }
                    
                    String queryString = "";
                    if (printType == "MEMBERCARD" && expiryDate != "" && fileName.IndexOf("BACK") != -1) CreateText("Годен До : " + expiryDate.Replace("/", " / "), e, 73, 166);

                    int FontSize = 10;
                    string FontName = "Calibri";
                    regular = new Font(FontName, FontSize);
                    boldUnderline = new Font(FontName, FontSize, (FontStyle.Bold | FontStyle.Underline));
                    bold = new Font(FontName, FontSize, FontStyle.Bold);
                    brush = new SolidBrush(Color.Black);
                    alignRight = new StringFormat();
                    alignRight.Alignment = StringAlignment.Far;
                    int left = 0;
                    string therapist_name = "";

                    switch (printType)
                    {
                        case "EMPLOYEE_BARCODE":
                            CreateBarcode(card_no, e);
                            break;
                        case "INVOICE":
                        case "CARD_USAGE":
                            int width = e.MarginBounds.Width;
                            //if (printType != "INVOICE") left += 15;

                            imageData = global::SPA_MANAGEMENT_SYSTEM.Properties.Resources.logo_small;
                            e.Graphics.DrawImage(imageData, (width / 2) - ((imageData.Width * 100 / imageData.HorizontalResolution) / 2) + left, 0);

                            if(printType == "INVOICE")
                                e.Graphics.DrawString("INVOICE", boldUnderline, brush, new PointF((float)((width / 2) - (e.Graphics.MeasureString("INVOICE", regular).Width / 2)) + left, 80f));
                            if (printType == "CARD_USAGE")
                                e.Graphics.DrawString("CARD USAGE", boldUnderline, brush, new PointF((float)((width / 2) - (e.Graphics.MeasureString("CARD USAGE", regular).Width / 2)) + left, 80f));

                            string bill_id = "";
                            string total_amount = "";
                            string discount_amount = "";
                            string grand_total = "";

                            queryString = "SELECT BILL_ID, TOTAL_PRICE, DISCOUNT, GRAND_TOTAL, CONVERT(NVARCHAR(MAX), BILL_DATETIME, 103) BILL_DATE FROM BILL WHERE BILL_NO = @card_no";

                            Params = new Dictionary<string, string>();
                            Params.Add("@card_no", card_no);

                            using (DataTable DT = DB.getS(queryString, Params, "GET BILL_ID FROM BILL_NO[" + card_no + "]", false))
                            {
                                if (DT.Rows.Count == 0)
                                {
                                    MessageBox.Show("NO BILL WITH THIS CODE !!", "ERROR");
                                    GF.closeLoading();
                                    return;
                                }
                                bill_id = DT.Rows[0]["BILL_ID"].ToString();
                                total_amount = DT.Rows[0]["TOTAL_PRICE"].ToString();
                                discount_amount = DT.Rows[0]["DISCOUNT"].ToString();
                                grand_total = DT.Rows[0]["GRAND_TOTAL"].ToString();

                                e.Graphics.DrawString(((char)'\u2116').ToString(), bold, brush, new PointF(left, 98));
                                e.Graphics.DrawString(": " + card_no, regular, brush, new PointF(e.Graphics.MeasureString("No", bold).Width + 1 + left, 98));

                                e.Graphics.DrawString("Date", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + DT.Rows[0]["BILL_DATE"].ToString(), regular).Width - e.Graphics.MeasureString("Date", bold).Width - 30 + left, 98));
                                e.Graphics.DrawString(": " + DT.Rows[0]["BILL_DATE"].ToString(), regular, brush, new RectangleF(left, 98, e.MarginBounds.Width - 30, 15), alignRight);
                            }

                            queryString = "SELECT DISTINCT ITEM_TYPE FROM BILL_DETAIL WHERE BILL_ID = " + bill_id;
                            using (DataTable DT = DB.getS(queryString, null, "GET ITEM_TYPE FROM BILL_ID[" + bill_id + "]", false))
                            {
                                queryString = @"
                                SELECT C.RESERVATION_ID, D.CUSTOMER_ID, D.CUSTOMER_NAME, E.CODE
                                FROM BILL_DETAIL A
                                INNER JOIN RESERVATION_DETAIL B ON A.ITEM_ID = B.RESERVATION_DETAIL_ID AND A.ITEM_TYPE = 0
                                INNER JOIN RESERVATION C ON B.RESERVATION_ID = C.RESERVATION_ID                                
                                INNER JOIN CUSTOMER D ON C.CUSTOMER_ID = D.CUSTOMER_ID
                                INNER JOIN ROOM E ON C.ROOM_ID = E.ROOM_ID
                                WHERE A.BILL_ID = " + bill_id;

                                string customer_name = "";
                                string room = "";
                                string reservation_id = "";

                                using (DataTable tmpDT = DB.getS(queryString, null, "GET RESERVATION_ID, CUSTOMER, ROOM FROM RESERVATION WITH BILL_ID[" + bill_id + "]", false))
                                {
                                    if (tmpDT.Rows.Count > 0)
                                    {
                                        reservation_id = tmpDT.Rows[0]["RESERVATION_ID"].ToString();
                                        customer_name = tmpDT.Rows[0]["CUSTOMER_NAME"].ToString();
                                        room = tmpDT.Rows[0]["CODE"].ToString();

                                        queryString = @"
                                        SELECT C.FULLNAME
                                        FROM RESERVATION_DETAIL A
                                        INNER JOIN RESERVATION_THERAPIST B ON A.RESERVATION_DETAIL_ID = B.RESERVATION_DETAIL_ID
                                        INNER JOIN EMPLOYEE C ON B.THERAPIST_ID = C.EMP_ID
                                        WHERE A.RESERVATION_ID = " + reservation_id;
                                        using (DataTable tmpDT2 = DB.getS(queryString, null, "GET THERAPIST NAME IN RESERVATION_ID[" + reservation_id + "]", false))
                                        {

                                            foreach (DataRow therapistRow in tmpDT2.Rows)
                                            {
                                                if (therapist_name.IndexOf(GF.getNickname(therapistRow["FULLNAME"].ToString())) == -1) therapist_name += GF.getNickname(therapistRow["FULLNAME"].ToString()) + ", ";
                                            }
                                            if (therapist_name != "") therapist_name = therapist_name.Substring(0, therapist_name.Length - 2);
                                            else therapist_name = "-";
                                        }
                                    }
                                    else
                                    {
                                        room = "-";
                                        therapist_name = "-";

                                        queryString = @"
                                        SELECT ISNULL(B.CUSTOMER_NAME, '-') CUSTOMER_NAME
                                        FROM BILL A
                                        LEFT OUTER JOIN CUSTOMER B ON A.CUSTOMER_ID = B.CUSTOMER_ID
                                        WHERE A.BILL_ID = " + bill_id;

                                        using (DataTable tmpDT2 = DB.getS(queryString, null, "GET CUSTOMER_NAME IN BILL_ID[" + bill_id + "]", false))
                                        {
                                            if (tmpDT2.Rows.Count > 0) customer_name = tmpDT2.Rows[0]["CUSTOMER_NAME"].ToString();
                                            else customer_name = "-";
                                        }
                                    }
                                }

                                e.Graphics.DrawString("Customer", bold, brush, new PointF(left, 111));
                                e.Graphics.DrawString(": " + customer_name, regular, brush, new PointF(e.Graphics.MeasureString("Customer", bold).Width + 1 + left, 111));

                                e.Graphics.DrawString("Room", bold, brush, new PointF(left, 124));
                                e.Graphics.DrawString(": " + room, regular, brush, new PointF(e.Graphics.MeasureString("Room", bold).Width + 1 + left, 124));

                                String current_time = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");

                                e.Graphics.DrawString("Time", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + current_time, regular).Width - e.Graphics.MeasureString("Time", bold).Width - 30 + left, 124));
                                e.Graphics.DrawString(": " + current_time, regular, brush, new RectangleF(left, 124, e.MarginBounds.Width - 30, 15), alignRight);

                                e.Graphics.DrawString("Master", bold, brush, new PointF(left, 137));
                                e.Graphics.DrawString(": " + therapist_name, regular, brush, new PointF(e.Graphics.MeasureString("Master", bold).Width + 1 + left, 137));

                                int theTop = 155;
                                //==================================== INVOICE DETAIL =======================================//
                                if (DT.Rows.Count > 0) e.Graphics.DrawString("DETAIL", boldUnderline, brush, new PointF((float)((width / 2) - (e.Graphics.MeasureString("DETAIL", regular).Width / 2)) + left, 150));

                                foreach (DataRow detailRow in DT.Rows)
                                {
                                    int item_type = Convert.ToInt32(detailRow["ITEM_TYPE"].ToString());

                                    if (item_type == 0) // MASSAGE
                                    {
                                        queryString = @"
                                        SELECT A.PRICE, B.CODE, B.PROGRAM_NAME
                                        FROM RESERVATION_DETAIL A
                                        INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                                        INNER JOIN BILL_DETAIL C ON A.RESERVATION_DETAIL_ID = C.ITEM_ID AND C.ITEM_TYPE = 0
                                        WHERE C.BILL_ID = " + bill_id;
                                        using (DataTable tmpDT = DB.getS(queryString, null, "GET SPA_PROGRAM FROM RESERVATION_ID[" + reservation_id + "]", false))
                                        {
                                            foreach (DataRow spa_program in tmpDT.Rows)
                                            {
                                                theTop += 13;
                                                e.Graphics.DrawString("#" + spa_program["CODE"].ToString(), bold, brush, new PointF(left, theTop));
                                                e.Graphics.DrawString(spa_program["PROGRAM_NAME"].ToString(), regular, brush, new PointF(e.Graphics.MeasureString("#" + spa_program["CODE"].ToString(), bold).Width + 2 + left, theTop));
                                                theTop += 13;
                                                e.Graphics.DrawString(((char)'\u2261').ToString() + " " + GF.formatNumber(Convert.ToInt32(spa_program["PRICE"].ToString())) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                            }
                                        }
                                    }

                                    if (item_type == 1) // MEMBER CARD
                                    {
                                        queryString = @"
                                        SELECT D.MEMBERCARD_TYPE_NAME, C.CARD_NO, B.PRICE
                                        FROM BILL A
                                        INNER JOIN BILL_DETAIL B ON A.BILL_ID = B.BILL_ID
                                        INNER JOIN MEMBERCARD C ON B.ITEM_ID = C.MEMBERCARD_ID AND B.ITEM_TYPE = 1
                                        INNER JOIN MEMBERCARD_TYPE D ON C.MEMBERCARD_TYPE_ID = D.MEMBERCARD_TYPE_ID
                                        WHERE A.BILL_ID = " + bill_id;
                                        using (DataTable tmpDT = DB.getS(queryString, null, "GET MEMBERCARD FROM BILL_ID[" + bill_id + "]", false))
                                        {
                                            foreach (DataRow membercard in tmpDT.Rows)
                                            {
                                                theTop += 13;
                                                e.Graphics.DrawString(membercard["MEMBERCARD_TYPE_NAME"].ToString(), bold, brush, new PointF(left, theTop));
                                                e.Graphics.DrawString("#" + membercard["CARD_NO"].ToString(), regular, brush, new PointF(e.Graphics.MeasureString(membercard["MEMBERCARD_TYPE_NAME"].ToString(), bold).Width + 2 + left, theTop));
                                                theTop += 13;
                                                e.Graphics.DrawString(((char)'\u2261').ToString() + " " + GF.formatNumber(Convert.ToInt32(membercard["PRICE"].ToString())) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                            }
                                        }
                                    }

                                    if (item_type == 2 || item_type == 6) // SPA GIFT CERTIFICATE + WEBSITE
                                    {
                                        queryString = @"
                                        SELECT D.PROGRAM_NAME, D.CODE, B.PRICE
                                        FROM BILL A
                                        INNER JOIN BILL_DETAIL B ON A.BILL_ID = B.BILL_ID
                                        INNER JOIN GIFT_CERTIFICATE C ON B.ITEM_ID = C.GIFT_CERTIFICATE_ID AND B.ITEM_TYPE = " + item_type.ToString().Trim() + @"
                                        INNER JOIN SPA_PROGRAM D ON C.SPA_PROGRAM_ID = D.SPA_PROGRAM_ID
                                        WHERE A.BILL_ID = " + bill_id;

                                        String caption = "GIFT CERTIFICATE";
                                        if (item_type == 6) caption = "WEBSITE " + caption;


                                        using (DataTable tmpDT = DB.getS(queryString, null, "GET " + caption + " FROM BILL_ID[" + bill_id + "]", false))
                                        {
                                            
                                            foreach (DataRow giftcertificate in tmpDT.Rows)
                                            {
                                                theTop += 13;
                                                e.Graphics.DrawString(caption, bold, brush, new PointF(left, theTop));
                                                e.Graphics.DrawString("#" + giftcertificate["CODE"].ToString() + " " + giftcertificate["PROGRAM_NAME"].ToString(), regular, brush, new PointF(e.Graphics.MeasureString(caption, bold).Width + 2 + left, theTop));
                                                theTop += 13;
                                                e.Graphics.DrawString(((char)'\u2261').ToString() + " " + GF.formatNumber(Convert.ToInt32(giftcertificate["PRICE"].ToString())) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                            }
                                        }
                                    }

                                    if (item_type == 3 || item_type == 9) // MONEY GIFT CERTIFICATE + WEBSITE
                                    {
                                        queryString = @"
                                        SELECT B.PRICE, C.BALANCE
                                        FROM BILL A
                                        INNER JOIN BILL_DETAIL B ON A.BILL_ID = B.BILL_ID
                                        INNER JOIN GIFT_CERTIFICATE C ON B.ITEM_ID = C.GIFT_CERTIFICATE_ID AND B.ITEM_TYPE = " + item_type.ToString().Trim() + @"
                                        WHERE A.BILL_ID = " + bill_id;

                                        String caption = "GIFT CERTIFICATE";
                                        if (item_type == 9) caption = "WEBSITE " + caption;

                                        using (DataTable tmpDT = DB.getS(queryString, null, "GET " + caption + " FROM BILL_ID[" + bill_id + "]", false))
                                        {
                                            foreach (DataRow giftcertificate in tmpDT.Rows)
                                            {
                                                theTop += 13;
                                                e.Graphics.DrawString(caption, bold, brush, new PointF(left, theTop));
                                                e.Graphics.DrawString(GF.formatNumber(Convert.ToInt32(giftcertificate["BALANCE"].ToString())) + " Rub.", regular, brush, new PointF(e.Graphics.MeasureString(caption, bold).Width + 2 + left, theTop));
                                                theTop += 13;
                                                e.Graphics.DrawString(((char)'\u2261').ToString() + " " + GF.formatNumber(Convert.ToInt32(giftcertificate["PRICE"].ToString())) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                            }
                                        }
                                    }

                                    if (item_type == 4 || item_type == 5 || item_type == 7 || item_type == 8) // PRODUCT & OTHER + DELIVERY CLUB + MANGO + RESTAURANT
                                    {
                                        queryString = @"
                                        SELECT B.PRICE, C.ITEM_NAME, B.MISC_ITEM_NAME, B.AMOUNT, D.ITEM_TYPE_NAME
                                        FROM BILL A
                                        INNER JOIN BILL_DETAIL B ON A.BILL_ID = B.BILL_ID AND B.ITEM_TYPE = " + item_type.ToString().Trim() + @"
                                        LEFT OUTER JOIN ITEM C ON B.ITEM_ID = C.ITEM_ID
                                        LEFT OUTER JOIN ITEM_TYPE D ON C.ITEM_TYPE_ID = D.ITEM_TYPE_ID
                                        WHERE A.BILL_ID = " + bill_id;

                                        String draw_string = "";
                                        switch (item_type)
                                        {
                                            case 4:
                                                draw_string = "PRODUCT & OTHER";
                                                break;
                                            case 5:
                                                draw_string = "DELIVERY CLUB";
                                                break;
                                            case 7:
                                                draw_string = "MANGO";
                                                break;
                                            case 8:
                                                draw_string = "RESTAURANT";
                                                break;
                                        }
                                        
                                        using (DataTable tmpDT = DB.getS(queryString, null, "GET " + draw_string + " ITEM FROM BILL_ID[" + bill_id + "]", false))
                                        {
                                            foreach (DataRow retailItem in tmpDT.Rows)
                                            {
                                                theTop += 13;

                                                e.Graphics.DrawString(draw_string, bold, brush, new PointF(left, theTop));

                                                string item_name = retailItem["AMOUNT"].ToString() + " x ";

                                                if (retailItem["ITEM_NAME"].ToString() != "") item_name += retailItem["ITEM_NAME"].ToString();
                                                else item_name += retailItem["MISC_ITEM_NAME"].ToString();

                                                e.Graphics.DrawString(item_name, regular, brush, new PointF(e.Graphics.MeasureString(draw_string, bold).Width + 2 + left, theTop));
                                                theTop += 13;
                                                e.Graphics.DrawString(((char)'\u2261').ToString() + " " + GF.formatNumber(Convert.ToInt32(retailItem["PRICE"].ToString())) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                            }
                                        }
                                    }
                                }

                                //==================================== INVOICE DISCOUNT =======================================//
                                queryString = @"
                                SELECT D.CODE, D.PROGRAM_NAME, A.*
                                FROM BILL_DISCOUNT A
                                LEFT OUTER JOIN BILL_DETAIL B ON A.BILL_DETAIL_ID = B.BILL_DETAIL_ID
                                LEFT OUTER JOIN RESERVATION_DETAIL C ON B.ITEM_ID = C.RESERVATION_DETAIL_ID AND B.ITEM_TYPE = 0
                                LEFT OUTER JOIN SPA_PROGRAM D ON C.SPA_PROGRAM_ID = D.SPA_PROGRAM_ID
                                WHERE A.BILL_ID = " + bill_id + @" 
                                AND A.USE_CARD_TYPE IN (0, 4, 5, 6)
                                ORDER BY A.BILL_DETAIL_ID;";
                                using (DataTable tmpDT = DB.getS(queryString, null, "GET BILL_DISCOUNT FROM BILL_ID[" + bill_id + "]", false))
                                {
                                    if (tmpDT.Rows.Count > 0)
                                    {
                                        theTop += (13 * 2);
                                        e.Graphics.DrawString("DISCOUNT", boldUnderline, brush, new PointF((float)((width / 2) - (e.Graphics.MeasureString("DISCOUNT", regular).Width / 2)) + left, theTop));
                                        theTop += 5;
                                        string[] discount_type = { "MEMBER CARD", "GIFT CERTIFICATE", "GIFT VOUCHER", "COUPON", "VIP CARD", "BARTER", "OTHER" };
                                        foreach (DataRow discount in tmpDT.Rows)
                                        {
                                            if (discount["BILL_DETAIL_ID"].ToString() != "-1")
                                            {
                                                theTop += 13;
                                                e.Graphics.DrawString(((char)'\u00AB').ToString() + (discount["USE_CARD_TYPE"].ToString() == "" ? discount["REASON"].ToString() : discount_type[Convert.ToInt32(discount["USE_CARD_TYPE"].ToString())]) + ((char)'\u00BB').ToString(), bold, brush, new PointF(left, theTop));
                                                theTop += 13;
                                                e.Graphics.DrawString("     #" + discount["CODE"].ToString(), bold, brush, new PointF(left, theTop));
                                                e.Graphics.DrawString(discount["PROGRAM_NAME"].ToString(), regular, brush, new PointF(e.Graphics.MeasureString("     #" + discount["CODE"].ToString(), bold).Width + 2 + left, theTop));
                                                theTop += 13;
                                                e.Graphics.DrawString(((char)'\u2261').ToString() + " -" + GF.formatNumber(Convert.ToInt32(discount["AMOUNT"].ToString())) + (discount["UNIT"].ToString() == "1" ? " Rub." : "%"), bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                            }
                                        }
                                        foreach (DataRow discount in tmpDT.Rows)
                                        {
                                            if (discount["BILL_DETAIL_ID"].ToString() == "-1")
                                            {
                                                theTop += 13;
                                                if (discount["IS_PROMOTION"].ToString() == "1")
                                                {
                                                    queryString = "SELECT * FROM PROMOTION WHERE PROMOTION_ID = " + discount["PROMOTION_ID"].ToString();
                                                     using (DataTable tmpPromo = DB.getS(queryString, null, "GET PROMOTION_NAME FROM PROMOTION_ID[" + discount["PROMOTION_ID"].ToString() + "]", false))
                                                    {
                                                        e.Graphics.DrawString(tmpPromo.Rows[0]["PROMOTION_NAME"].ToString(), bold, brush, new PointF(left, theTop));
                                                    }
                                                }
                                                else
                                                {
                                                    e.Graphics.DrawString(((char)'\u00AB').ToString() + (discount["USE_CARD_TYPE"].ToString() == "" ? discount["REASON"].ToString() : discount_type[Convert.ToInt32(discount["USE_CARD_TYPE"].ToString())]) + ((char)'\u00BB').ToString(), bold, brush, new PointF(left, theTop));
                                                }
                                                theTop += 13;
                                                e.Graphics.DrawString("     " + discount["RAW_TEXT"].ToString(), regular, brush, new PointF(left, theTop));
                                                theTop += 13;
                                                e.Graphics.DrawString(((char)'\u2261').ToString() + " -" + GF.formatNumber(Convert.ToInt32(discount["AMOUNT"].ToString())) + (discount["UNIT"].ToString() == "1" ? " Rub." : "%"), bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                            }
                                        }
                                    }
                                }

                                //======================================= SUB TOTAL ======================================//
                                theTop += (13 * 3);
                                e.Graphics.DrawString("SUB TOTAL", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + ((char)'\u2261').ToString() + " " + GF.formatDecimal(Convert.ToInt32(total_amount)) + " Rub.", bold).Width - e.Graphics.MeasureString("SUB TOTAL:", bold).Width - 30 + left, theTop));
                                e.Graphics.DrawString(": " + ((char)'\u2261').ToString() + " " + GF.formatDecimal(Convert.ToInt32(total_amount)) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                //======================================= DISCOUNT TOTAL ======================================//
                                theTop += 20;
                                e.Graphics.DrawString("DISCOUNT", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + ((char)'\u2261').ToString() + " " + GF.formatDecimal(Convert.ToInt32(discount_amount)) + " Rub.", bold).Width - e.Graphics.MeasureString("DISCOUNT:", bold).Width - 30 + left, theTop));
                                e.Graphics.DrawString(": " + ((char)'\u2261').ToString() + " " + GF.formatDecimal(Convert.ToInt32(discount_amount)) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                //======================================= PAID ======================================//
                                int paid_amount = 0;
                                queryString = @"
                                SELECT SUM(money_receive) PAID_AMOUNT
                                FROM BILL_PAYMENT
                                WHERE BILL_ID = " + bill_id;
                                using (DataTable tmpDT = DB.getS(queryString, null, "GET BILL_PAYMENT FROM BILL_ID[" + bill_id + "]", false))
                                {
                                    if (tmpDT.Rows.Count == 1)
                                    {
                                        if (tmpDT.Rows[0]["PAID_AMOUNT"].ToString() != "NULL" && tmpDT.Rows[0]["PAID_AMOUNT"].ToString() != "")
                                        {
                                            paid_amount = Convert.ToInt32(tmpDT.Rows[0]["PAID_AMOUNT"].ToString());
                                            theTop += 20;
                                            e.Graphics.DrawString("PAID", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + ((char)'\u2261').ToString() + " -" + GF.formatDecimal(Convert.ToInt32(discount_amount)) + " Rub.", bold).Width - e.Graphics.MeasureString("PAID:", bold).Width - 30 + left, theTop));
                                            e.Graphics.DrawString(": " + ((char)'\u2261').ToString() + " " + GF.formatDecimal(Convert.ToInt32(paid_amount)) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);
                                        }
                                    }
                                }

                                //======================================= GRAND TOTAL ======================================//
                                theTop += 20;
                                int net_total = Convert.ToInt32(total_amount) - Convert.ToInt32(discount_amount) - paid_amount;
                                e.Graphics.DrawString("GRAND TOTAL", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + ((char)'\u2261').ToString() + " " + GF.formatDecimal(net_total) + " Rub.", bold).Width - e.Graphics.MeasureString("GRAND TOTAL:", bold).Width - 30 + left, theTop));
                                e.Graphics.DrawString(": " + ((char)'\u2261').ToString() + " " + GF.formatDecimal(net_total) + " Rub.", bold, brush, new RectangleF(left, theTop, e.MarginBounds.Width - 30, 15), alignRight);

                                theTop += (13 * 3);
                                if (printType == "INVOICE")
                                {
                                    //======================================= BARCODE ==========================================//
                                    CreateBarcode(card_no, e, 0, theTop);
                                }
                                else
                                {
                                    string seps = "";
                                    while (e.Graphics.MeasureString(seps, regular).Width < e.MarginBounds.Width)
                                    {
                                        seps += "-";
                                    }

                                    queryString = "SELECT PAYMENT_TYPE FROM BILL_PAYMENT WHERE BILL_ID = " + bill_id;
                                    string payment_type = "-1";
                                    using (DataTable theDT = DB.getS(queryString, null, "GET PAYMENT_TYPE FROM BILL[" + bill_id + "]", false))
                                    {
                                        foreach (DataRow theRow in theDT.Rows)
                                        {
                                            payment_type = theRow["PAYMENT_TYPE"].ToString();

                                            if (payment_type == "3" || payment_type == "2")
                                            {

                                                string amount_left = "0";
                                                string paid = "0";
                                                string the_card_no = "??";
                                                string before_use = "0";

                                                if (payment_type == "3")
                                                {

                                                    // ================================ MONEY GIFT CERTIFICATE =================================//
                                                    queryString = @"
                                        SELECT A.MONEY_RECEIVE AMOUNT, B.BALANCE, B.CARD_NO 
                                        FROM BILL_PAYMENT A 
                                        INNER JOIN GIFT_CERTIFICATE B ON A.USE_CARD_ID = B.GIFT_CERTIFICATE_ID AND A.PAYMENT_TYPE = 3
                                        WHERE A.BILL_ID = " + bill_id;

                                                    using (DataTable theDT2 = DB.getS(queryString, null, "GET AMOUNT LEFT OF MONEY GIFT CERTIFICATE FOR BILL_ID[" + bill_id + "]", false))
                                                    {
                                                        foreach (DataRow dataRow in theDT2.Rows)
                                                        {
                                                            amount_left = dataRow["BALANCE"].ToString();
                                                            paid = dataRow["AMOUNT"].ToString();
                                                            the_card_no = dataRow["CARD_NO"].ToString();
                                                            before_use = (Convert.ToInt32(amount_left) + Convert.ToInt32(paid)).ToString();

                                                            theTop += 15;
                                                            e.Graphics.DrawString(seps, regular, brush, new PointF(left, theTop));
                                                            theTop += 15;
                                                            e.Graphics.DrawString("CARD TYPE", bold, brush, new PointF(left, theTop));
                                                            e.Graphics.DrawString(": GIFT CERTIFICATE", regular, brush, new PointF(e.Graphics.MeasureString("CARD TYPE", bold).Width + 1 + left, theTop));
                                                            theTop += 15;
                                                            e.Graphics.DrawString("CARD " + ((char)'\u2116'), bold, brush, new PointF(left, theTop));
                                                            e.Graphics.DrawString(": " + the_card_no, regular, brush, new PointF(e.Graphics.MeasureString("CARD " + ((char)'\u2116'), bold).Width + 1 + left, theTop));
                                                            theTop += 15;
                                                            e.Graphics.DrawString("BALANCE BEFORE USE ", bold, brush, new PointF(left, theTop));
                                                            e.Graphics.DrawString(": " + GF.formatDecimal(Convert.ToInt32(before_use)) + " Rub.", regular, brush, new PointF(e.Graphics.MeasureString("BALANCE BEFORE USE  ", bold).Width + 1 + left, theTop));
                                                            theTop += 15;
                                                            e.Graphics.DrawString("BALANCE AFTER USE ", bold, brush, new PointF(left, theTop));
                                                            e.Graphics.DrawString(": " + GF.formatDecimal(Convert.ToInt32(amount_left)) + " Rub.", regular, brush, new PointF(e.Graphics.MeasureString("BALANCE BEFORE USE  ", bold).Width + 1 + left, theTop));
                                                        }
                                                    }
                                                }

                                                if (payment_type == "2")
                                                {
                                                    // ================================ MEMBER =================================//
                                                    queryString = @"
                                        SELECT A.MONEY_RECEIVE, B.BALANCE, B.CARD_NO, C.MEMBERCARD_TYPE_NAME 
                                        FROM BILL_PAYMENT A 
                                        INNER JOIN MEMBERCARD B ON A.USE_CARD_ID = B.MEMBERCARD_ID AND A.PAYMENT_TYPE = 2
                                        INNER JOIN MEMBERCARD_TYPE C ON B.MEMBERCARD_TYPE_ID = C.MEMBERCARD_TYPE_ID 
                                        WHERE A.BILL_ID = " + bill_id;

                                                    amount_left = "0";
                                                    paid = "0";
                                                    the_card_no = "??";
                                                    before_use = "0";

                                                    using (DataTable theDT2 = DB.getS(queryString, null, "GET AMOUNT LEFT OF MEMBERCARD FOR BILL_ID[" + bill_id + "]", false))
                                                    {
                                                        foreach (DataRow dataRow in theDT2.Rows)
                                                        {
                                                            amount_left = dataRow["BALANCE"].ToString();
                                                            paid = dataRow["MONEY_RECEIVE"].ToString();
                                                            the_card_no = dataRow["CARD_NO"].ToString();
                                                            before_use = (Convert.ToInt32(amount_left) + Convert.ToInt32(paid)).ToString();

                                                            theTop += 15;
                                                            e.Graphics.DrawString(seps, regular, brush, new PointF(left, theTop));
                                                            theTop += 15;
                                                            e.Graphics.DrawString("CARD TYPE", bold, brush, new PointF(left, theTop));
                                                            e.Graphics.DrawString(": " + dataRow["MEMBERCARD_TYPE_NAME"].ToString(), regular, brush, new PointF(e.Graphics.MeasureString("CARD TYPE", bold).Width + 1 + left, theTop));
                                                            theTop += 15;
                                                            e.Graphics.DrawString("CARD " + ((char)'\u2116'), bold, brush, new PointF(left, theTop));
                                                            e.Graphics.DrawString(": " + the_card_no, regular, brush, new PointF(e.Graphics.MeasureString("CARD " + ((char)'\u2116'), bold).Width + 1 + left, theTop));
                                                            theTop += 15;
                                                            e.Graphics.DrawString("BALANCE BEFORE USE ", bold, brush, new PointF(left, theTop));
                                                            e.Graphics.DrawString(": " + GF.formatDecimal(Convert.ToInt32(before_use)) + " Rub.", regular, brush, new PointF(e.Graphics.MeasureString("BALANCE BEFORE USE  ", bold).Width + 1 + left, theTop));
                                                            theTop += 15;
                                                            e.Graphics.DrawString("BALANCE AFTER USE ", bold, brush, new PointF(left, theTop));
                                                            e.Graphics.DrawString(": " + GF.formatDecimal(Convert.ToInt32(amount_left)) + " Rub.", regular, brush, new PointF(e.Graphics.MeasureString("BALANCE BEFORE USE  ", bold).Width + 1 + left, theTop));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    
                                    // ======================================= END =========================================//
                                    theTop += 13;
                                    e.Graphics.DrawString(seps, regular, brush, new PointF(left, theTop));
                                }
                            }
                            
                            break;
                        case "SPA_CARD":
                        case "SPA_CARD_NEW":

                            queryString = @"
                            SELECT 
                                A.CODE,
                                A.PREFER,
                                B.CODE ROOM_NO,
                                CONVERT(NVARCHAR(MAX), A.APPOINTMENT_START, 103) START_DATE,
                                CONVERT(NVARCHAR(MAX), A.START_TIME, 108) START_TIME,
                                CONVERT(NVARCHAR(MAX), A.END_TIME, 108) END_TIME
                            FROM RESERVATION A
                            INNER JOIN ROOM B ON A.ROOM_ID = B.ROOM_ID
                            WHERE RESERVATION_ID = " + GF.selected_id.ToString();
                            string res_code = "";
                            string room_no = "";
                            string prefer = "";

                            using (DataTable DT = DB.getS(queryString, null, "GET RESERVATION[" + GF.selected_id.ToString() + "] FOR PRINT", false))
                            {

                                res_code = DT.Rows[0]["CODE"].ToString();
                                room_no = DT.Rows[0]["ROOM_NO"].ToString();

                                switch (DT.Rows[0]["PREFER"].ToString())
                                {
                                    case "0": prefer = "LOW"; break;
                                    case "1": prefer = "MEDIUM"; break;
                                    case "2": prefer = "STRONG"; break;
                                }

                                queryString = @"
                            SELECT DISTINCT
                                A.RESERVATION_DETAIL_ID,
                                A.OIL,
                                A.SCRUB,
                                B.HOURS,
                                B.MINUTES,
                                B.CODE MASSAGE_CODE
                            FROM RESERVATION_DETAIL A
                            INNER JOIN SPA_PROGRAM B ON A.SPA_PROGRAM_ID = B.SPA_PROGRAM_ID
                            WHERE RESERVATION_ID = " + GF.selected_id.ToString();

                                string massage_code = "";
                                string oil = "";
                                string scrub = "";
                                int hours = 0;
                                int minutes = 0;

                                using (DataTable tmpDT = DB.getS(queryString, null, "GET RESERVATION_DETAIL FROM RES_ID[" + GF.selected_id.ToString() + "] FOR PRINT", false))
                                {
                                    therapist_name = "";
                                    foreach (DataRow detailRow in tmpDT.Rows)
                                    {
                                        massage_code += detailRow["MASSAGE_CODE"].ToString() + ", ";
                                        if (detailRow["OIL"].ToString() != "") oil += GF.oilList[Convert.ToInt32(detailRow["OIL"].ToString())] + ", ";
                                        if (detailRow["SCRUB"].ToString() != "") scrub += GF.scrubList[Convert.ToInt32(detailRow["SCRUB"].ToString())] + ", ";
                                        hours += Convert.ToInt32(detailRow["HOURS"].ToString());
                                        minutes += Convert.ToInt32(detailRow["MINUTES"].ToString());

                                        queryString = @"
                                    SELECT B.FULLNAME 
                                    FROM RESERVATION_THERAPIST A
                                    INNER JOIN EMPLOYEE B ON A.THERAPIST_ID = B.EMP_ID
                                    WHERE A.RESERVATION_DETAIL_ID = " + detailRow["RESERVATION_DETAIL_ID"].ToString();

                                        using (DataTable tmpDT2 = DB.getS(queryString, null, "GET NAME OF THERAPIST[" + therapist_id + "]", false))
                                        {
                                            foreach (DataRow TherapistNamerow in tmpDT2.Rows)
                                            {
                                                therapist_name += GF.getNickname(TherapistNamerow["FULLNAME"].ToString()) + ", ";
                                            }
                                        }
                                    }
                                    therapist_name = therapist_name.Substring(0, therapist_name.Length - 2);

                                    while (minutes >= 60)
                                    {
                                        minutes -= 60;
                                        hours++;
                                    }

                                    massage_code = massage_code.Trim().Substring(0, massage_code.Trim().Length - 1);
                                    massage_code += " ( " + hours.ToString() + (minutes > 0 ? "." + minutes.ToString() : "") + " hrs )";

                                    if (oil.Trim() != "") oil = oil.Trim().Substring(0, oil.Trim().Length - 1);
                                    if (scrub.Trim() != "") scrub = scrub.Trim().Substring(0, scrub.Trim().Length - 1);

                                    // ************ CREATE TEXT
                                    if (printType == "SPA_CARD")
                                    {
                                        string res_dt = DT.Rows[0]["START_DATE"].ToString() + " ";
                                        string[] tmp = DT.Rows[0]["START_TIME"].ToString().Split(':');
                                        res_dt += tmp[0] + ":" + tmp[1] + " - ";
                                        tmp = DT.Rows[0]["END_TIME"].ToString().Split(':');
                                        res_dt += tmp[0] + ":" + tmp[1];

                                        CreateText(res_code, e, 70, 59);
                                        CreateText(room_no, e, 365, 59);
                                        CreateText(therapist_name, e, 154, 79);
                                        CreateText(res_dt, e, 154, 98);
                                        CreateText(massage_code, e, 154, 118);
                                        CreateText(prefer, e, 154, 136);
                                        CreateText(oil, e, 154, 155);
                                        CreateText(scrub, e, 154, 175);

                                        CreateText(res_code, e, 443, 59);
                                        CreateText(room_no, e, 738, 59);
                                        CreateText(therapist_name, e, 527, 79);
                                        CreateText(res_dt, e, 527, 98);
                                        CreateText(massage_code, e, 527, 118);
                                        CreateText(prefer, e, 527, 136);
                                        CreateText(oil, e, 527, 155);
                                        CreateText(scrub, e, 527, 175);
                                    }

                                    if (printType == "SPA_CARD_NEW")
                                    {
                                        /*e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(135, 7, 130, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(40, 29, 225, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 51, 170, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 73, 170, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 94, 170, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 116, 170, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 138, 170, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 160, 170, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 181, 170, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 203, 170, 13));
                                        e.Graphics.DrawRectangle(new Pen(Brushes.Red), new Rectangle(95, 225, 170, 13));*/

                                        string[] tmp_start = DT.Rows[0]["START_TIME"].ToString().Split(':');
                                        string[] tmp_end = DT.Rows[0]["END_TIME"].ToString().Split(':');

                                        bold = new Font("Calibri", 12, FontStyle.Bold);

                                        e.Graphics.DrawString("SPA CARD", new Font("Calibri", 22, FontStyle.Bold), brush, 0, 4);
                                        drawHr(e, 0);
                                        e.Graphics.DrawRectangle(new Pen(brush), new Rectangle((int)e.Graphics.MeasureString("SPA CARD", new Font("Calibri", 22, FontStyle.Bold)).Width, 0, 1, 44));
                                        e.Graphics.DrawString(DT.Rows[0]["START_DATE"].ToString(), bold, brush, new RectangleF(left, 4, e.MarginBounds.Width - 30, 23), alignRight);
                                        e.Graphics.DrawString(((char)'\u2116').ToString(), bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + res_code, bold).Width - e.Graphics.MeasureString(((char)'\u2116').ToString(), bold).Width - 30, 23));
                                        e.Graphics.DrawString(": " + res_code, bold, brush, new RectangleF(left, 23, e.MarginBounds.Width - 30, 15), alignRight);
                                        drawHr(e, 44);
                                        CreateText("Room " + ((char)'\u2116').ToString(), e, 0, 45);
                                        CreateText(room_no, e, 115, 45);
                                        drawHr(e, 67);
                                        CreateText("Master", e, 0, 68);
                                        CreateText(therapist_name, e, 115, 68);
                                        drawHr(e, 89);
                                        CreateText("Time", e, 0, 90);
                                        CreateText(tmp_start[0] + ":" + tmp_start[1] + " - " + tmp_end[0] + ":" + tmp_end[1], e, 115, 90);
                                        drawHr(e, 111);
                                        CreateText("Massage Code", e, 0, 112);
                                        CreateText(massage_code, e, 115, 112);
                                        drawHr(e, 133);
                                        CreateText("Prefer", e, 0, 134);
                                        CreateText(prefer, e, 115, 134);
                                        drawHr(e, 155);
                                        CreateText("OIL", e, 0, 156);
                                        CreateText(oil, e, 115, 156);
                                        drawHr(e, 176);
                                        CreateText("SCRUB", e, 0, 177);
                                        CreateText(scrub, e, 115, 177);
                                        drawHr(e, 197);

                                        using (Pen tmpPen = new Pen(Color.Black))
                                        {
                                            e.Graphics.DrawRectangle(tmpPen, new Rectangle(110, 44, 1, 197 - 44));
                                        }
                                    }
                                }
                            }
                            break;
                        case "MEMBERCARD":
                        case "MEMBERCARD_LIMITED_EDITION":
                            if (isMemberCardBack) CreateBarcode(card_no, e, 185, 120);
                            break;
                        case "MEMBERCARD_LIMITED_EDITION_LETTER":
                            break;
                        case "MEMBERCARD_LETTER":
                            break;
                        case "GIFT_CERTIFICATE":
                            if (spaProgramName.Trim() != "")
                            {
                                CreateText(spaProgramName, e, 40, 250);
                            }
                            else if (price.Trim() != "")
                            {
                                CreateText(GF.formatNumber(Convert.ToInt32(price)) + " РУБ", e, 50, 250);
                            }
                            CreateText(for_txt, e, 110, 195, 1); // NameMode 1 = For
                            CreateText(from_txt, e, 308, 322, 2); // NameMode 2 = From
                            break;
                        case "GIFT_CERTIFICATE_LETTER":
                            CreateBarcode(card_no, e, 42, 255);
                            CreateText(expiryDate.Replace("/", " / "), e, 130, 309);
                            if (spaProgramName.Trim() != "")
                            {
                                CreateText(spaProgramName, e, 360, 195);
                            }
                            else if (price.Trim() != "")
                            {
                                CreateText(GF.formatNumber(Convert.ToInt32(price)) + " РУБ", e, 500, 200);
                            }
                            break;
                        case "GIFT_VOUCHER":
                            CreateText(spaProgramName, e, 250, 270);
                            CreateBarcode(card_no, e, 530, 300);
                            CreateText("Годен до : " + expiryDate.Replace("/", " / "), e, 230, 330);
                            break;
                    }
                    e.Graphics.Dispose();
                };

                pd.EndPrint += (sender, e) =>
                {
                    if (e.PrintAction == PrintAction.PrintToPrinter)
                    {
                        if (PPD != null && !PPD.IsDisposed)
                            PPD.Close();

                        if (printType.IndexOf("MEMBERCARD") != -1)
                        {
                            if (fileName.IndexOf("FRONT") != -1) GF.disableButton(((card_print)owner).print_card1_btn);
                            if (fileName.IndexOf("BACK") != -1) GF.disableButton(((card_print)owner).print_card2_btn);
                            if (fileName.IndexOf("PAPER") != -1) GF.disableButton(((card_print)owner).attach_paper_btn);
                            if (!((card_print)owner).print_card1_btn.Enabled && !((card_print)owner).print_card2_btn.Enabled && !((card_print)owner).attach_paper_btn.Enabled) owner.Close();
                        }

                        if (printType.IndexOf("GIFT_CERTIFICATE") != -1)
                        {
                            if (fileName.IndexOf("GIFT_CERTIFICATE1") != -1) GF.disableButton(((card_print)owner).print_card1_btn);
                            if (fileName.IndexOf("GIFT_CERTIFICATE2") != -1) GF.disableButton(((card_print)owner).attach_paper_btn);
                            if (!((card_print)owner).print_card1_btn.Enabled && !((card_print)owner).attach_paper_btn.Enabled) owner.Close();
                        }

                        if (printType == "GIFT_VOUCHER")
                        {
                            GF.disableButton(((card_print)owner).print_card1_btn);
                            owner.Close();
                        }

                        if (printType == "SPA_CARD")
                        {
                            String queryString = "UPDATE RESERVATION SET SPA_CARD_ISSUE = " + GF.modDateTime(GF.NOW()) + " WHERE RESERVATION_ID = " + GF.selected_id.ToString();
                            GF.showLoading();
                            DB.beginTrans();
                            if (!DB.set(queryString, "UPDATE SPA_CARD_ISSUE IN RESERVATION[" + GF.selected_id.ToString() + "]"))
                            {
                                MessageBox.Show("ERROR UPDATE SPA_CARD_ISSUE IN RESERVATION !!", "ERROR");
                                GF.closeLoading();
                            }
                            DB.close();
                            ((RESERVATION.reservation_manage)PRINT.owner).spa_card_btn.BackColor = Color.LightCoral;
                            GF.closeLoading();
                        }

                        if (printType == "INVOICE")
                        {
                            String queryString = "UPDATE BILL SET INVOICE_DATETIME = CURRENT_TIMESTAMP WHERE BILL_NO LIKE '" + card_no + "'";
                            DB.beginTrans();
                            if (!DB.set(queryString, "UPDATE INVOICE_DATETIME IN BILL_NO[" + card_no + "]"))
                            {
                                MessageBox.Show("ERROR UPDATE INVOICE_DATETIME IN BILL !!", "ERROR");
                                GF.closeLoading();
                            }
                            DB.close();
                        }

                        if (owner.Name == "viewer") owner.Close();

                        if (owner != null) owner.Activate();

                        GF.closeLoading();
                        /*PPD.Close();
                        PPD.Dispose();*/
                    }
                };
                GF.closeLoading();
                using (PPD = new PrintPreviewDialog())
                {
                    ((Form)PPD).FormClosed += (ss, ee) =>
                    {
                        ((Form)_owner).Activate();
                    };
                    ((Form)PPD).TopMost = true;
                    ((Form)PPD).WindowState = FormWindowState.Maximized;
                    ((Form)PPD).FormBorderStyle = FormBorderStyle.None;
                    PPD.Document = pd;
                    PPD.PrintPreviewControl.Zoom = 1;
                    PPD.PrintPreviewControl.UseAntiAlias = true;
                    if (printType.IndexOf("MEMBERCARD") == -1) PPD.Document.OriginAtMargins = false;
                    else PPD.Document.OriginAtMargins = true;

                    if (printType != "SPA_CARD" && printType != "SPA_CARD_NEW" && printType != "INVOICE" && printType != "CARD_USAGE" && printType != "EMPLOYEE_BARCODE") PPD.ShowDialog();
                    else pd.Print();
                    if (printType == "SPA_CARD_NEW") pd.Print();
                }
            }
        }

        private static void CreateBarcode(string code, PrintPageEventArgs e, int x=0, int y=0)
        {
            int height = 35;
            int width = -1;

            // BARCODE
            using (StringFormat strFormat = new StringFormat { Alignment = StringAlignment.Center })
            {
                using (Image image = Code128Rendering.MakeBarcodeImage(code, 2, true))
                {

                    if (printType == "GIFT_CERTIFICATE_LETTER" || printType == "GIFT_VOUCHER") height = 35;

                    if (printType != "INVOICE" && printType != "EMPLOYEE_BARCODE")
                    {
                        if (image.Height > height)
                        {
                            float modifier = ((float)height) / ((float)image.Height);
                            width = Convert.ToInt32(((float)image.Width) * modifier);
                        }
                    }
                    else
                    {
                        width = 200; // 2 Inch
                        if (printType == "EMPLOYEE_BARCODE") width = 158;
                        if ((image.Width * 100 / image.HorizontalResolution) > width)
                        {
                            float modifier = width / ((float)(image.Width * 100 / image.HorizontalResolution));
                            height = Convert.ToInt32(((float)(image.Height * 100 / image.VerticalResolution)) * modifier);
                        }
                        else height = (int)(image.Height * 100 / image.VerticalResolution);
                    }

                    if (printType.IndexOf("MEMBERCARD") != -1)
                    {
                        x = (344 / 2) - (width / 2);
                    }

                    if (printType == "INVOICE") x = (e.MarginBounds.Width / 2) - (width / 2);

                    if (printType != "INVOICE" && printType != "EMPLOYEE_BARCODE")
                    {
                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(new Point(x, y), new Size(width, height + 10)));
                        e.Graphics.DrawImage(image, x, y + 5, width, height - 5);
                    }
                    else if (printType == "EMPLOYEE_BARCODE")
                    {
                        e.Graphics.DrawImage(image, x + 5, y + 5, width, 70);
                    }
                    else
                    {
                        e.Graphics.DrawImage(image, x, y, width, height);
                    }


                    Font font = null;

                    // CODE
                    if (printType == "EMPLOYEE_BARCODE") font = new Font("Calibri", 10);
                    else if (printType == "GIFT_VOUCHER" || printType == "INVOICE") font = new Font("Calibri", 10); // GIFT VOUCHER
                    else if (printType.IndexOf("GIFT_CERTIFICATE") != -1) font = new Font("Calibri", 10); // GIFT CERTIFICATE
                    else font = new Font("Calibri", 6); // ELSE

                    SizeF stringSize;
                    if(printType == "EMPLOYEE_BARCODE") stringSize = e.Graphics.MeasureString(spaProgramName, font);
                    else stringSize = e.Graphics.MeasureString(code, font);

                    if (printType.IndexOf("MEMBERCARD") != -1) x = (344 / 2) - ((int)stringSize.Width / 2);
                    else if (printType != "INVOICE") x = x + (width / 2) - (Convert.ToInt32(stringSize.Width) / 2);
                    else x = (e.MarginBounds.Width / 2) - ((int)stringSize.Width / 2);

                    if (printType == "EMPLOYEE_BARCODE") e.Graphics.DrawString(spaProgramName, font, Brushes.Black, new RectangleF(x + 5, 77, stringSize.Width, stringSize.Height), strFormat);
                    else e.Graphics.DrawString(code, font, Brushes.Black, new RectangleF(x, y + height, stringSize.Width, stringSize.Height), strFormat);
                    if (printType == "GIFT_CERTIFICATE_LETTER" || printType == "GIFT_VOUCHER") e.Graphics.DrawString(code, font, Brushes.Black, new RectangleF(x, y + 35, stringSize.Width, stringSize.Height), strFormat);

                    font.Dispose();
                }
            }
        }

        private static void CreateText(string text, PrintPageEventArgs e, int x, int y, int nameMode = -1)
        {
            using (StringFormat strFormat = new StringFormat { Alignment = StringAlignment.Center })
            {

                Font font = null;
                SizeF stringSize = new SizeF();
                Brush brush = null;

                double left = 0.00;
                double theWidth = 0.00;
                bool fit = false;
                Int64 tmpTxt;

                switch (printType)
                {
                    case "INVOICE":
                        font = new Font("Courier New", 6);
                        brush = new SolidBrush(Color.Black);
                        break;
                    case "SPA_CARD":
                        font = new Font("Calibri", 12, FontStyle.Bold);
                        brush = new SolidBrush(Color.Black);

                        left = x;

                        if (Int64.TryParse(text, out tmpTxt) != false) theWidth = 220;
                        else if (Int64.TryParse(text.Replace("/", ""), out tmpTxt) != false) theWidth = 45;
                        else theWidth = 255;

                        do
                        {
                            double strWidth = e.Graphics.MeasureString(text.Trim(), font).Width;
                            if (strWidth > theWidth)
                            {
                                font = new Font("Calibri", font.Size - 1, FontStyle.Bold);
                                y += 1;
                            }
                            else fit = true;
                        } while (!fit);
                        break;
                    case "SPA_CARD_NEW":
                        font = new Font("Calibri", 12, FontStyle.Bold);
                        brush = new SolidBrush(Color.Black);

                        left = x;

                        switch (nameMode)
                        {
                            case 1:
                                theWidth = 130;
                                break;
                            case 2:
                                theWidth = 225;
                                break;
                            default:
                                theWidth = 170;
                                break;
                        }

                        do
                        {
                            double strWidth = e.Graphics.MeasureString(text.Trim(), font).Width;
                            if (strWidth > theWidth)
                            {
                                font = new Font("Calibri", font.Size - 1, FontStyle.Bold);
                                y += 1;
                            }
                            else fit = true;
                        } while (!fit);
                        break;
                    case "MEMBERCARD":
                    case "MEMBERCARD_LIMITED_EDITION":
                        if (text.Trim().IndexOf("/") != -1) font = new Font("Calibri", 9, FontStyle.Bold); // EXPIRY DATE
                        else font = new Font("Calibri", 7, FontStyle.Bold);
                        brush = new SolidBrush(Color.Black);
                        break;
                    case "MEMBERCARD_LETTER":
                    case "MEMBERCARD_LIMITED_EDITION_LETTER":
                        font = new Font("Calibri", 12, FontStyle.Bold);
                        brush = new SolidBrush(Color.Black);
                        break;
                    case "GIFT_CERTIFICATE":
                        left = x;
                        if (nameMode != -1)
                        {
                            theWidth = 260;
                            font = new Font("Calibri", 15, FontStyle.Bold);
                        }
                        else
                        {
                            theWidth = 550;
                            font = new Font("Calibri", 25, FontStyle.Bold);
                        }

                        do
                        {
                            double strWidth = e.Graphics.MeasureString(text.Trim(), font).Width;
                            if (strWidth > theWidth)
                            {
                                font = new Font("Calibri", font.Size - 1, FontStyle.Bold);
                                y += 1;
                            }
                            else fit = true;
                        } while (!fit);

                        brush = new SolidBrush(Color.FromArgb(61, 32, 2));
                        break;
                    case "GIFT_CERTIFICATE_LETTER":
                        if (text.Trim().IndexOf("/") != -1) // EXPIRY DATE
                        {
                            font = new Font("Calibri", 14, FontStyle.Bold);
                        }
                        else
                        {
                            left = 300; // FOR GIFT CERTIFICATE LETTER *** ONLY ***
                            theWidth = 465; // FOR GIFT CERTIFICATE LETTER *** ONLY ***

                            font = new Font("Calibri", 25, FontStyle.Bold);
                            do
                            {
                                double strWidth = e.Graphics.MeasureString(text.Trim(), font).Width;
                                if (strWidth > theWidth)
                                {
                                    font = new Font("Calibri", font.Size - 1, FontStyle.Bold);
                                    y += 1;
                                }
                                else fit = true;
                            } while (!fit);
                        }

                        brush = new SolidBrush(Color.FromArgb(61, 32, 2));
                        break;
                    case "GIFT_VOUCHER":
                        font = new Font("Calibri", 12, FontStyle.Bold);
                        brush = new SolidBrush(Color.FromArgb(61, 32, 2));
                        break;
                }

                // ********************************* POSITIONING ********************************

                stringSize = e.Graphics.MeasureString(text.Trim(), font);

                if (printType == "MEMBERCARD") // MEMBERCARD BACK *** EXPIRY DATE
                {
                    if (text.Trim().IndexOf("/") != -1) // EXPIRY DATE
                    {
                        left = (e.MarginBounds.Width / 2) - (stringSize.Width / 2);
                        e.Graphics.DrawString(text.Trim(), font, brush, new RectangleF((int)left, y, stringSize.Width, stringSize.Height), strFormat);
                        return;
                    }
                }

                if (printType == "GIFT_CERTIFICATE") // GIFT CERTIFICATE *** ONLY
                {
                    e.Graphics.DrawString(text.Trim(), font, brush, new RectangleF(x, y, (int)theWidth, stringSize.Height), strFormat);
                    return;
                }

                if (printType == "GIFT_CERTIFICATE_LETTER") // GIFT CERTIFICATE LETTER *** ONLY
                {
                    if (text.Trim().IndexOf("/") == -1) // NOT EXPIRY DATE
                    {
                        e.Graphics.DrawString(text.Trim(), font, brush, new RectangleF((int)left, y, (int)theWidth, stringSize.Height), strFormat);
                        return;
                    }
                }

                if (printType == "GIFT_VOUCHER" && text.IndexOf("/") == -1) // GIFT VOUCHER ONLY
                {
                    x = x + ((e.MarginBounds.Width + 15 - x) / 2) - Convert.ToInt32(stringSize.Width / 2);
                }
                /*MessageBox.Show(text.Trim());
                MessageBox.Show(font.ToString());
                MessageBox.Show(brush.ToString());
                MessageBox.Show(new RectangleF(x, y, stringSize.Width, stringSize.Height).ToString());
                MessageBox.Show(strFormat.ToString());*/
                e.Graphics.DrawString(text.Trim(), font, brush, new RectangleF(x, y, stringSize.Width, stringSize.Height), strFormat);

                brush.Dispose();
                font.Dispose();
                return;
            }
        }

        static bool setPrinter(string printerName)
        {
            if (printerName == "")
            {
                MessageBox.Show("NO PRINTER !!", "ERROR");
                GF.closeLoading();
                return false;
            }
            else
            {
                if (isFile) PRINT.printerName = Properties.Settings.Default.pdf_printer;
                else PRINT.printerName = printerName;
                GF.doDebug("PRINTER : " + PRINT.printerName);
                return true;
            }
        }

        private static Rectangle resizeBound(PrintPageEventArgs e, Image tmpData)
        {
            Rectangle tmpBound = e.MarginBounds;
            if ((double)tmpData.Width / (double)tmpData.Height > (double)tmpBound.Width / (double)tmpBound.Height) // image is wider
            {
                tmpBound.Height = (int)((double)tmpData.Height / (double)tmpData.Width * (double)tmpBound.Width);
            }
            else
            {
                tmpBound.Width = (int)((double)tmpData.Width / (double)tmpData.Height * (double)tmpBound.Height);
            }
            GF.doDebug("********** " + tmpData.Size.ToString() + " : " + tmpBound.ToString());
            return tmpBound;
        }

        private static void drawHr(PrintPageEventArgs e, int top)
        {
            using (Pen tmpPen = new Pen(Color.Black))
            {
                e.Graphics.DrawRectangle(tmpPen, 0, top, e.MarginBounds.Width, 1);
            }
        }

        static void checkPaperSize(PrintDocument pd)
        {
            GF.doDebug("***************************************************************");
            foreach (PaperSize size in pd.PrinterSettings.PaperSizes)
            {
                GF.doDebug("**** [" + size.RawKind.ToString() + "][" + size.Kind.ToString() + "] " + size.Width.ToString() + "x" + size.Height.ToString());
            }
        }

        static void checkPaperSource(PrintDocument pd)
        {
            GF.doDebug("***************************************************************");
            foreach (PaperSource source in pd.PrinterSettings.PaperSources)
            {
                GF.doDebug("**** [" + source.RawKind.ToString() + "][" + source.Kind.ToString() + "] " + source.SourceName);
            }
        }
    }
}
