using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM.USER_CONTROL
{
    public partial class btn_dgv : UserControl
    {
        public bool _preventDGVSelectionChanged = false;
        public btn_dgv()
        {
            InitializeComponent();

            this.Top = 35;
            this.Left = 13;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 20;

            btn_panel.Top = 0;
            btn_panel.Left = 0;
            btn_panel.Width = this.Width;

            del_btn.Left = btn_panel.Width - del_btn.Width - 5;
            edit_btn.Left = del_btn.Left - edit_btn.Width - 5;
            add_btn.Left = edit_btn.Left - add_btn.Width - 5;
        }

        public bool preventDGVSelectionChanged { get { return _preventDGVSelectionChanged; } set { _preventDGVSelectionChanged = value; } }

        // DELEGATE PART :: BEGIN
        public delegate void AddClickHandler(object sender, EventArgs e);
        public event AddClickHandler AddClick;
        public delegate void EditClickHandler(object sender, EventArgs e);
        public event EditClickHandler EditClick;
        public delegate void DeleteClickHandler(object sender, EventArgs e);
        public event DeleteClickHandler DeleteClick;
        public delegate void RefreshClickHandler(object sender, EventArgs e);
        public event RefreshClickHandler RefreshClick;
        public delegate void SearchClickHandler(object sender, EventArgs e);
        public event SearchClickHandler SearchClick;
        public delegate void firstClickHandler(object sender, EventArgs e);
        public event firstClickHandler firstClick;
        public delegate void prevClickHandler(object sender, EventArgs e);
        public event prevClickHandler prevClick;
        public delegate void nextClickHandler(object sender, EventArgs e);
        public event nextClickHandler nextClick;
        public delegate void lastClickHandler(object sender, EventArgs e);
        public event lastClickHandler lastClick;
        public delegate void pageNumberChangedHandler(object sender, EventArgs e);
        public event pageNumberChangedHandler pageNumberChanged;

        public Button getAddBtn { get { return add_btn; } }

        public void OnAddClick(EventArgs e)
        {
            if (AddClick != null)
            {
                AddClick(this, e);
            }
        }

        public void OnEditClick(EventArgs e)
        {
            if (EditClick != null)
            {
                EditClick(this, e);
            }
        }

        public void OnDeleteClick(EventArgs e)
        {
            if (DeleteClick != null)
            {
                DeleteClick(this, e);
            }
        }

        public void OnRefreshClick(EventArgs e)
        {
            if (RefreshClick != null)
            {
                RefreshClick(this, e);
            }
        }

        public void OnSearchClick(EventArgs e)
        {
            if (SearchClick != null)
            {
                SearchClick(this, e);
            }
        }

        public void onFirstClick(EventArgs e)
        {
            if (firstClick != null)
            {
                firstClick(this, e);
            }
        }
        public void onPrevClick(EventArgs e)
        {
            if (prevClick != null)
            {
                prevClick(this, e);
            }
        }
        public void onNextClick(EventArgs e)
        {
            if (nextClick != null)
            {
                nextClick(this, e);
            }
        }
        public void onLastClick(EventArgs e)
        {
            if (lastClick != null)
            {
                lastClick(this, e);
            }
        }
        public void onPageNumberChanged(EventArgs e)
        {
            if (pageNumberChanged != null)
            {
                pageNumberChanged(this, e);
            }
        }
        // DELEGATE PART :: END

        public void add_btn_Click(object sender, EventArgs e)
        {
            OnAddClick(EventArgs.Empty);
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            OnEditClick(EventArgs.Empty);
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            OnDeleteClick(EventArgs.Empty);
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            OnRefreshClick(EventArgs.Empty);
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            OnSearchClick(EventArgs.Empty);
        }

        private void first_btn_Click(object sender, EventArgs e)
        {
            GF.showLoading();

            page_txt.Text = "1";
            int.TryParse(page_txt.Text, out GF.currentPage);

            GF.disableButton(first_btn);
            GF.disableButton(prev_btn);

            if (page_txt.Text != total_lbl.Text)
            {
                GF.enableButton(next_btn);
                GF.enableButton(last_btn);
            }

            onFirstClick(EventArgs.Empty);
        }
        private void prev_btn_Click(object sender, EventArgs e)
        {
            GF.showLoading();

            page_txt.Text = (Convert.ToInt32(page_txt.Text) - 1).ToString();
            int.TryParse(page_txt.Text, out GF.currentPage);

            if (page_txt.Text == "1")
            {
                GF.disableButton(first_btn);
                GF.disableButton(prev_btn);
            }

            if (page_txt.Text != total_lbl.Text)
            {
                GF.enableButton(next_btn);
                GF.enableButton(last_btn);
            }

            onPrevClick(EventArgs.Empty);
        }
        private void next_btn_Click(object sender, EventArgs e)
        {
            GF.showLoading();

            page_txt.Text = (Convert.ToInt32(page_txt.Text) + 1).ToString();
            int.TryParse(page_txt.Text, out GF.currentPage);

            if (page_txt.Text == total_lbl.Text)
            {
                GF.disableButton(last_btn);
                GF.disableButton(next_btn);
            }

            if (page_txt.Text != "1")
            {
                GF.enableButton(first_btn);
                GF.enableButton(prev_btn);
            }

            onNextClick(EventArgs.Empty);
        }
        private void last_btn_Click(object sender, EventArgs e)
        {
            GF.showLoading();

            page_txt.Text = total_lbl.Text;
            int.TryParse(page_txt.Text, out GF.currentPage);

            GF.disableButton(last_btn);
            GF.disableButton(next_btn);

            if (page_txt.Text != "1")
            {
                GF.enableButton(first_btn);
                GF.enableButton(prev_btn);
            }

            onLastClick(EventArgs.Empty);
        }
        private void page_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                page_txt_Leave(sender, new EventArgs());
            }
        }
        private void page_txt_Leave(object sender, EventArgs e)
        {
            page_txt.Text = page_txt.Text.Trim();
            if (Convert.ToInt32(page_txt.Text) != GF.currentPage)
            {
                if (!int.TryParse(page_txt.Text, out GF.currentPage))
                {
                    MessageBox.Show("PAGE NUMBER MUST BE NUMBER ONLY !!");
                    page_txt.Select();
                }
                else
                {
                    GF.showLoading();

                    int.TryParse(page_txt.Text, out GF.currentPage);

                    onPageNumberChanged(EventArgs.Empty);
                }
            }
        }

        private void total_lbl_TextChanged(object sender, EventArgs e)
        {
            if (total_lbl.Text.Trim() != "1")
            {
                GF.enableButton(next_btn);
                GF.enableButton(last_btn);
            }
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
                    grfx.DrawString("--- NO DATA ---", new Font("Microsoft Sans Serif", 18, FontStyle.Bold), Brushes.Black, new PointF((sndr.Width / 2) - 100, (sndr.Height / 2) - 50));
                }
            }
            else
            {
                foreach (DataGridViewColumn column in sndr.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (!preventDGVSelectionChanged)
            {
                if (DGV.SelectedRows.Count == 1)
                {
                    GF.disableButton(this.ParentForm.Controls.Find("add_btn", true)[0] as Button);
                    GF.enableButton(this.ParentForm.Controls.Find("edit_btn", true)[0] as Button);
                    GF.enableButton(this.ParentForm.Controls.Find("del_btn", true)[0] as Button);
                }
                else
                {
                    GF.enableButton(this.ParentForm.Controls.Find("add_btn", true)[0] as Button);
                    GF.disableButton(this.ParentForm.Controls.Find("edit_btn", true)[0] as Button);
                    GF.disableButton(this.ParentForm.Controls.Find("del_btn", true)[0] as Button);
                }
            }
        }

        private void btn_dgv_Load(object sender, EventArgs e)
        {
            GF.disableButton(first_btn);
            GF.disableButton(prev_btn);
            GF.disableButton(next_btn);
            GF.disableButton(last_btn);
        }
    }
}
