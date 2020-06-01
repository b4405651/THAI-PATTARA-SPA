using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class attachments : Form
    {
        int _id = -1;
        public int id { get { return _id; } set { _id = value; } }
        bool _viewOnly = false;
        public bool viewOnly { get { return _viewOnly; } set { _viewOnly = value; } }
        string _owner_name = "";
        public string owner_name { get { return _owner_name; } set { _owner_name = value; } }

        public attachments()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            DGV.Width = line_sep1.Width;
            DGV.Height = this.Height - DGV.Top - 40;

            GF.disableButton(add_btn);
            GF.disableButton(delete_btn);
        }

        private void file_path_Click(object sender, EventArgs e)
        {
            file_path.Select(file_path.Text.Length, 0);

            using (OpenFileDialog fDialog = new OpenFileDialog())
            {
                fDialog.AddExtension = true;
                fDialog.CheckFileExists = true;
                fDialog.CheckPathExists = true;
                fDialog.Filter = "GIF, JPEG, PNG Files|*.gif;*.jpg;*.png";
                fDialog.InitialDirectory = Properties.Settings.Default.attachment_path.Trim();
                fDialog.Title = "Open Image File";

                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    file_path.Text = fDialog.FileName.ToString();
                    file_path.Select(file_path.Text.Length, 0);
                }
            }
        }

        private void loadAttachment()
        {
            if (Owner.Name == "shop_selling") owner_name = Owner.Name;
            else owner_name = Owner.Owner.Name;

            //GF.showLoading(this);
            this.DGV.Rows.Clear();

            if (DGV.Columns.Count == 0)
            {
                this.DGV.Columns.Add("attachment_name", "ATTACHMENT NAME");
                this.DGV.Columns.Add("file_name", "FILE NAME");
                this.DGV.Columns.Add("attachment_id", "ATTACHMENT ID");
            }

            String queryString = "SELECT ROW_NUMBER() OVER (ORDER BY attachment_name) as RowNum, attachment_id, attachment_name, file_name FROM ATTACHMENT WHERE owner_id = " + this.id.ToString() + " AND owner_form = '" + owner_name + "'";

            Dictionary<string, string> Params = new Dictionary<string, string>();
            /*Params.Add("@id", this.id.ToString());
            Params.Add("@owner_form", owner_name);*/

            using (DataTable myDT = DB.getS(queryString, Params, "GET ATTACHMENT"))
            {
                int rowNum = 0;
                foreach (DataRow myRow in myDT.Rows)
                {
                    this.DGV.Rows.Add(
                        myRow["attachment_name"],
                        myRow["file_name"],
                        myRow["attachment_id"]
                    );

                    this.DGV[0, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    this.DGV[1, rowNum].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    rowNum++;
                }
            }
            this.DGV.Columns["attachment_id"].Visible = false;
            GF.updateRowNum(DGV);
            this.DGV.ClearSelection();
            
            if (viewOnly)
            {
                file_path.Enabled = false;
                attachment_name.Enabled = false;
                GF.disableButton(add_btn);
                GF.disableButton(delete_btn);
            }
            GF.closeLoading();
        }

        private void attachments_Load(object sender, EventArgs e)
        {
            loadAttachment();
        }

        private void DGV_Paint(object sender, PaintEventArgs e)
        {
            DataGridView sndr = (DataGridView)sender;

            if (sndr.Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
            {
                using (Graphics grfx = e.Graphics)
                {
                    // create a white rectangle so text will be easily readable
                    grfx.FillRectangle(Brushes.Plum, new Rectangle(new Point(), new Size(sndr.Width, sndr.Height)));
                    // write text on top of the white rectangle just created
                    using (Font font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold))
                    {
                        grfx.DrawString("--- NO DATA ---", font, Brushes.Black, new PointF((sndr.Width / 2) - 100, (sndr.Height / 2) - 10));
                    }
                }
            }
        }

        private void file_path_TextChanged(object sender, EventArgs e)
        {
            if (file_path.Text.Trim() != "")
            {
                GF.enableButton(add_btn);
                Properties.Settings.Default.attachment_path = file_path.Text.Trim().Substring(0, file_path.Text.Trim().LastIndexOf('\\'));
                Properties.Settings.Default.Save();
            } else GF.disableButton(add_btn);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (file_path.Text.Trim() == "")
            {
                GF.disableButton(add_btn);
                MessageBox.Show("PLEASE CHOOSE A FILE !!");
                return;
            }
            if (attachment_name.Text.Trim() == "")
            {
                MessageBox.Show("PLEASE ENTER ATTACHMENT NAME !!");
                attachment_name.Focus();
                return;
            }
            string filename = genFileName(file_path.Text.Trim());
            if (FTP.upload(file_path.Text.Trim(), filename, "ATTACHMENT"))
            {
                string queryString = "INSERT INTO ATTACHMENT ( ATTACHMENT_NAME, FILE_NAME, OWNER_ID, OWNER_FORM ) VALUES (";
                queryString += "'" + attachment_name.Text.Trim() + "', ";
                queryString += "'" + filename + "', ";
                queryString += id.ToString() + ", ";
                queryString += "'" + owner_name + "')";
                DB.beginTrans();
                if (DB.set(queryString, "INSERT ATTACHMENT[" + filename + "]"))
                {
                    DB.close();
                    GF.disableButton(add_btn);
                    GF.disableButton(delete_btn);
                    file_path.Text = "";
                    attachment_name.Text = "";
                    loadAttachment();
                }
                else
                {
                    FTP.delete(filename, "ATTACHMENT");
                }
            }
        }

        private string genFileName(string input)
        {
            string filename = DateTime.Now.Year.ToString();
            filename += DateTime.Now.Month.ToString("D2");
            filename += DateTime.Now.Day.ToString("D2");
            filename += "_";
            filename += DateTime.Now.Hour.ToString("D2");
            filename += DateTime.Now.Minute.ToString("D2");
            filename += DateTime.Now.Second.ToString("D2");
            filename += "_";
            filename += DateTime.Now.Millisecond.ToString();
            filename += input.Substring(input.LastIndexOf('.'));

            return filename;
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS ATTACHMENT ?", "DELETE ATTACHMENT", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string fileName = DGV.SelectedRows[0].Cells["file_name"].Value.ToString();
                if (FTP.delete(fileName, "ATTACHMENT"))
                {
                    string queryString = "DELETE FROM ATTACHMENT WHERE FILE_NAME LIKE '" + fileName + "'";
                    DB.beginTrans();
                    if (DB.set(queryString, "DELETE ATTACHMENT[" + fileName + "]"))
                    {
                        DB.close();
                        GF.disableButton(add_btn);
                        GF.disableButton(delete_btn);
                        file_path.Text = "";
                        attachment_name.Text = "";
                        loadAttachment();
                    }
                }
                else
                {
                    MessageBox.Show("CANNOT DELETE ATTACHMENT FILE via FTP !!", "ERROR");
                    return;
                }
            }
        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!viewOnly) GF.enableButton(delete_btn);
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                GF.showLoading(this);

                string filename = DGV.SelectedRows[0].Cells["file_name"].Value.ToString();

                using (viewer viewerPage = new viewer())
                {
                    viewerPage.Owner = this;
                    viewerPage.filename = filename;

                    GF.closeLoading();
                    viewerPage.Show();
                }
            }
        }
    }
}
