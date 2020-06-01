using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPA_MANAGEMENT_SYSTEM.CUSTOMER;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class btn_dgv : UserControl
    {
        public bool allowDeleteRow = false;
        public bool _preventDGVSelectionChanged = false;
        public bool preventEnable = false;
        public bool useDefaultEnable = true;

        public btn_dgv()
        {
            InitializeComponent();

            GF.currentPage = 1;
            //doResize(Screen.PrimaryScreen.Bounds.Width);
        }

        public void doResize(int Width)
        {
            //this.Top = 35;
            this.Left = 13;
            this.Width = Width - 20;
            paging_panel.Width = this.Width;

            btn_panel.Top = 0;
            btn_panel.Left = 0;
            btn_panel.Width = this.Width;
            DGV.Width = btn_panel.Width;

            del_btn.Left = btn_panel.Width - del_btn.Width - 5;
            edit_btn.Left = del_btn.Left - edit_btn.Width - 5;
            add_btn.Left = edit_btn.Left - add_btn.Width - 5;
            enable_btn.Left = add_btn.Left - enable_btn.Width - 5;
        }

        public bool preventDGVSelectionChanged { get { return _preventDGVSelectionChanged; } set { _preventDGVSelectionChanged = value; } }

        private void btn_dgv_Load(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width - (this.Left * 2);
            paging_panel.Top = this.Height - this.Top - 165;
            DGV.Height = paging_panel.Top - 70;

            GF.disableButton(first_btn);
            GF.disableButton(prev_btn);
            GF.disableButton(next_btn);
            GF.disableButton(last_btn);

            page_txt.Text = "1";

            int tmp;
            Int32.TryParse(total_lbl.Text.Trim(), out tmp);
            if (tmp > 1)
            {
                GF.enableButton(next_btn);
                GF.enableButton(last_btn);
            }
            //preventDGVSelectionChanged = true;
        }

        // DELEGATE PART :: BEGIN
        public delegate void EnableClickHandler(object sender, EventArgs e);
        public event EnableClickHandler EnableClick;
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

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (!preventDGVSelectionChanged)
            {
                if (DGV.SelectedRows.Count == 1)
                {
                    GF.disableButton(this.ParentForm.Controls.Find("add_btn", true)[0] as Button);
                    GF.enableButton(this.ParentForm.Controls.Find("edit_btn", true)[0] as Button);

                    if (!preventEnable) // USE ENABLE BUTTON
                    {
                        if (DGV.Columns.Contains("is_use"))
                        {
                            if (DGV.SelectedRows[0].Cells["is_use"].Value.ToString() == "ACTIVE")
                            {
                                GF.enableButton(this.ParentForm.Controls.Find("del_btn", true)[0] as Button);
                                if (useDefaultEnable) this.ParentForm.Controls.Find("enable_btn", true)[0].Visible = false;
                            }

                            if (DGV.SelectedRows[0].Cells["is_use"].Value.ToString() == "INACTIVE")
                            {
                                GF.disableButton(this.ParentForm.Controls.Find("del_btn", true)[0] as Button);
                                if (useDefaultEnable) this.ParentForm.Controls.Find("enable_btn", true)[0].Visible = true;
                            }
                        }
                        else
                        {
                            GF.enableButton(this.ParentForm.Controls.Find("del_btn", true)[0] as Button);
                        }
                    }
                    else // NOT USE ENABLE BUTTON
                    {
                        if (DGV.SelectedRows[0].DefaultCellStyle.BackColor != Color.Khaki && DGV.SelectedRows[0].DefaultCellStyle.BackColor != Color.LightCoral) GF.enableButton(this.ParentForm.Controls.Find("del_btn", true)[0] as Button);
                        else GF.disableButton(this.ParentForm.Controls.Find("del_btn", true)[0] as Button);
                    }
                }
                else
                {
                    GF.enableButton(this.ParentForm.Controls.Find("add_btn", true)[0] as Button);
                    GF.disableButton(this.ParentForm.Controls.Find("edit_btn", true)[0] as Button);
                    GF.disableButton(this.ParentForm.Controls.Find("del_btn", true)[0] as Button);
                    if(preventEnable) this.ParentForm.Controls.Find("enable_btn", true)[0].Visible = false;
                }
            }
        }

        public void OnEnableClick(EventArgs e)
        {
            if (EnableClick != null)
            {
                EnableClick(this, e);
            }
        }

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
            GF.currentPage = 1;
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

        private void enable_btn_Click(object sender, EventArgs e)
        {
            OnEnableClick(EventArgs.Empty);
        }

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

        private void page_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (page_txt.Text.Trim() == String.Empty)
                    page_txt.Text = "1";
                else
                    page_txt.Text = page_txt.Text.Trim();

                if (page_txt.Text.Trim() != "")
                {
                    if (Convert.ToInt32(page_txt.Text) > Convert.ToInt32(total_lbl.Text) || Convert.ToInt32(page_txt.Text) == 0)
                    {
                        page_txt.Text = GF.currentPage.ToString();
                        return;
                    }
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
            }
        }

        private void page_txt_Leave(object sender, EventArgs e)
        {
            if (page_txt.Text.Trim() == String.Empty)
                page_txt.Text = "1";
            else
                page_txt.Text = page_txt.Text.Trim();
        }

        private void total_lbl_TextChanged(object sender, EventArgs e)
        {
            int tmp;
            Int32.TryParse(total_lbl.Text.Trim(), out tmp);
            if (tmp > 1)
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
                    using (Font font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold))
                    {
                        grfx.DrawString("--- NO DATA ---", font, Brushes.Black, new PointF((sndr.Width / 2) - 100, (sndr.Height / 2)));
                    }
                }
            }
            else
            {
                foreach (DataGridViewColumn column in sndr.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (DGV.Columns.Contains("is_use"))
                {
                    foreach(DataGridViewRow row in sndr.Rows){
                        if(row.Cells["is_use"].Value.ToString() == "ACTIVE") row.Cells["is_use"].Style.ForeColor = Color.Green;
                        if(row.Cells["is_use"].Value.ToString() == "INACTIVE") row.Cells["is_use"].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void page_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                page_txt_Leave(sender, new EventArgs());
            }
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DGV.ClearSelection();
                    break;
                case Keys.Enter:
                    OnEditClick(EventArgs.Empty);
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    if (DGV.SelectedRows.Count == 1)
                    {
                        if (!allowDeleteRow) e.Handled = true;
                    }
                    break;
            }
        }

        private void DGV_Scroll(object sender, ScrollEventArgs e)
        {
            DGV.Invalidate();
        }

        public void hideTopPanel()
        {
            btn_panel.Visible = false;
            DGV.Height += DGV.Top - btn_panel.Top;
            DGV.Top = btn_panel.Top;
        }

        public void rearrange(int newTop)
        {
            Top = newTop;
            Height = Screen.PrimaryScreen.WorkingArea.Height - Top - 120;
            if (paging_panel.Visible)
            {
                paging_panel.Top = Height - paging_panel.Height - 10;
                DGV.Height = Height - paging_panel.Height - 80;
            }
            else DGV.Height = Height - 0 - 80;
        }
    }
}
