using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    class bar : IDisposable
    {
        // Has Dispose() already been called?
        Boolean isDisposed = false;

        bool isRed = false;
        Font font;

        string _res_id = "";
        string _room_id = "";
        float LEFT = -1;
        float TOP = -1;
        float WIDTH = -1;
        float HEIGHT = -1;

        bool _request = false;
        bool crossStart = false;
        bool crossEnd = false;

        public int relocated = 0;

        int colStartIndex = -1;
        int colEndIndex = -1;
        int start_minutes = -1;
        int end_minutes = -1;

        public int rowIndex = -1;
        public string display_data = "";
        public Brush brush;

        public string res_id { get { return _res_id; } set { _res_id = value; } }
        public string room_id { get { return _room_id; } set { _room_id = value; } }
        public bool request { get { return _request; } set { _request = value; } }

        public bar(string res_id, string room_id, Brush color, string display_data = "", int rowIndex = -1, int colStartIndex = -1, int colEndIndex = -1, int start_minutes = -1, int end_minutes = -1, bool request = false, bool crossStart = false, bool crossEnd = false)
        {
            this.res_id = res_id;
            this.room_id = room_id;
            this.brush = color;
            this.display_data = display_data;
            this.colStartIndex = colStartIndex;
            this.colEndIndex = colEndIndex;
            this.rowIndex = rowIndex;
            this.start_minutes = start_minutes;
            this.end_minutes = end_minutes;
            this.request = request;
            this.crossStart = crossStart;
            this.crossEnd = crossEnd;
        }

        public void drawBar(DataGridView table, PaintEventArgs e)
        {
            if (table.Name == "therapistTable")
            {
                float startLeft = 0;
                float theTop = 0;
                float endLeft = 0;
                float theHeight = 0;
                // START
                Rectangle startRect = table.GetCellDisplayRectangle(colStartIndex, rowIndex, true);
                startLeft = startRect.Left;
                theTop = startRect.Top;
                theHeight = table.Rows[rowIndex].Height;
                float cellWidth = table.Columns[colStartIndex].Width;

                if(!crossStart)
                    startLeft += (((float)start_minutes / (float)60) * (float)cellWidth);

                // END
                Rectangle endRect = table.GetCellDisplayRectangle(colEndIndex, rowIndex, true);
                if (theTop == 0) theTop = endRect.Top;
                if (theHeight == 0) theHeight = table.Rows[rowIndex].Height;

                //if (display_data.IndexOf("pratoom") != -1) MessageBox.Show(colStartIndex.ToString() + " : " + colEndIndex.ToString());
                if (crossEnd)
                    endLeft = endRect.Right;
                else
                {
                    endLeft = endRect.Left;
                    endLeft += (((float)end_minutes / (float)60) * (float)cellWidth);
                }
                
                Brush theBrush;
                if (isRed) theBrush = Brushes.Red;
                else theBrush = this.brush;

                LEFT = startLeft;
                TOP = theTop + 2;
                WIDTH = endLeft - startLeft;
                HEIGHT = theHeight - 5;

                if (LEFT <= 0 || TOP <= 0 || WIDTH <= 0 || HEIGHT <= 0) return;
                if (request) e.Graphics.FillRectangle(Brushes.Red, LEFT, TOP, WIDTH, HEIGHT);
                e.Graphics.FillRectangle(theBrush, LEFT + 1, TOP + 1, WIDTH - 2, HEIGHT - 2);

                //StringFormat stringFormat = new StringFormat { Alignment = StringAlignment.Center };

                String[] text = display_data.Split('|');
                int row_num = 0;
                //float top = TOP + (((HEIGHT) / 2) - (stringSize.Height / 2));

                foreach (String data in text)
                {
                    using (font = new Font("Calibri", 14, FontStyle.Bold))
                    {
                        SizeF stringSize = e.Graphics.MeasureString(data.Trim(), font);
                        while (stringSize.Width > WIDTH)
                        {
                            float tmpFontSize = font.Size - 1;
                            font = new Font("Calibri", tmpFontSize, FontStyle.Bold);
                            if (tmpFontSize <= 1) break;
                            stringSize = e.Graphics.MeasureString(data.Trim(), font);
                        }
                        e.Graphics.DrawString(data, font, Brushes.Black, new RectangleF(LEFT, TOP + (row_num * 18), stringSize.Width, stringSize.Height));
                        row_num++;
                    }
                }

                //theBrush.Dispose();
            }

            if (table.Name == "roomTable")
            {
                float startLeft = 0;
                float theTop = 0;
                float endLeft = 0;
                float theHeight = 0;
                // START
                Rectangle startRect = table.GetCellDisplayRectangle(colStartIndex, rowIndex, true);
                startLeft = startRect.Left;
                theTop = startRect.Top;
                theHeight = table.Rows[rowIndex].Height;
                float cellWidth = table.Columns[colStartIndex].Width;

                if(!crossStart)
                    startLeft += (((float)start_minutes / (float)60) * (float)cellWidth);

                // END
                Rectangle endRect = table.GetCellDisplayRectangle(colEndIndex, rowIndex, true);
                if (theTop == 0) theTop = endRect.Top;
                if (theHeight == 0) theHeight = table.Rows[rowIndex].Height;

                if (crossEnd)
                    endLeft = endRect.Right;
                else
                {
                    endLeft = endRect.Left;
                    endLeft += (((float)end_minutes / (float)60) * (float)cellWidth);
                }

                Brush theBrush;
                if (isRed) theBrush = Brushes.Red;
                else theBrush = this.brush;

                LEFT = startLeft;
                TOP = theTop + 2;
                WIDTH = endLeft - startLeft;
                HEIGHT = theHeight - 5;

                if (request) e.Graphics.FillRectangle(Brushes.Red, LEFT, TOP, WIDTH, HEIGHT);
                e.Graphics.FillRectangle(theBrush, LEFT, TOP, WIDTH, HEIGHT);
                if (this.display_data.Trim() != "")
                {
                    using (font = new Font("Calibri", 14, FontStyle.Bold))
                    {
                        StringFormat stringFormat;
                        using (stringFormat = new StringFormat { Alignment = StringAlignment.Center })
                        {
                            SizeF stringSize = e.Graphics.MeasureString(this.display_data.Trim(), font);
                            while (stringSize.Width > WIDTH && font.Size > 1)
                            {
                                font = new Font("Calibri", font.Size - 1, FontStyle.Bold);
                                 stringSize = e.Graphics.MeasureString(this.display_data.Trim(), font);
                            }

                            float top = TOP + (((HEIGHT) / 2) - (stringSize.Height / 2));
                            float left = LEFT + ((WIDTH / 2) - (stringSize.Width / 2));

                            e.Graphics.DrawString(this.display_data, font, Brushes.Black, new RectangleF(left, top, stringSize.Width, stringSize.Height), stringFormat);
                        }
                    }
                }
            }
        }

        public void toggleSelect(bool flag = true)
        {
            isRed = flag;
        }

        public bool isSelected()
        {
            return isRed;
        }

        public bool isClicked(float X, int rowIndex)
        {
            //MessageBox.Show("LEFT = " + LEFT.ToString() + "\r\n" + "X = " + X.ToString() + "\r\n" + "this.rowIndex = " + this.rowIndex.ToString() + "\r\n\r\n" + "rowIndex = " + rowIndex.ToString());
            if (LEFT <= X && X <= (LEFT + WIDTH) && (this.rowIndex == rowIndex)) return true;
            else return false;
        }

        public string getData()
        {
            String outputStr = "";
            using (Pen tmpPen = new Pen(brush))
            {
                outputStr += "RES_ID = " + this.res_id.ToString() + "\r\n";
                outputStr += "BRUSH = " + tmpPen.Color.Name.ToString() + "\r\n";
                outputStr += "DISPLAY_DATA = " + display_data.ToString() + "\r\n";
                outputStr += "COLSTARTINDEX = " + colStartIndex.ToString() + "\r\n";
                outputStr += "COLENDINDEX = " + colEndIndex.ToString() + "\r\n";
                outputStr += "ROWINDEX = " + rowIndex.ToString() + "\r\n";
                outputStr += "START_MINUTES = " + start_minutes.ToString() + "\r\n";
                outputStr += "END_MINUTES = " + end_minutes.ToString();
            }
            
            return outputStr;
        }

        public void Dispose()
        {
            ReleaseResources(true); // cleans both unmanaged and managed resources
            GC.SuppressFinalize(this); // supress finalization
        }

        protected void ReleaseResources(bool isFromDispose)
        {
            // Try to release resources only if they have not been previously released.
            if (!isDisposed)
            {
                if (isFromDispose)
                {
                    // TODO: Release managed resources here
                    // GC will automatically release Managed resources by calling the destructor,
                    // but Dispose() need to release managed resources manually
                }
                //TODO: Release unmanaged resources here
                //if(theBrush != null) theBrush.Dispose();
                //if(font != null) font.Dispose();
                //GF.doDebug("BAR IS NOW DISPOSED !!");
            }
            isDisposed = true; // Dispose() can be called numerous times
        }
        // Use C# destructor syntax for finalization code, invoked by GC only.
        ~bar()
        {
            // cleans only unmanaged stuffs
            ReleaseResources(false);
        }
    }
}
