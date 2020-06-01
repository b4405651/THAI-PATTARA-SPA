using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace SPA_MANAGEMENT_SYSTEM
{
    public partial class autocomplete : UserControl
    {
        public autocomplete()
        {
            InitializeComponent();
        }

        public bool preventTextChanged = false;
        int _value = -1;
        public int value { get { return this._value; } set { _value = value; } }
        int _maxWidth = -1;
        public int maxWidth { get { return _maxWidth; } set { _maxWidth = value; } }
        
        public delegate void textChangedHandler(object sender, EventArgs e);
        public event textChangedHandler textChanged;

        public void OnMyTextChanged(EventArgs e)
        {
            if (textChanged != null)
            {
                textChanged(this, e);
            }
        }

        public void acTxt_TextChanged(object sender, System.EventArgs e)
        {
            if (!preventTextChanged)
            {
                value = -1;
                acBox.Visible = false;
                acBox.Items.Clear();
                OnMyTextChanged(EventArgs.Empty);
                if (acTxt.Text.Length == 0)
                {
                    hideResults();
                    return;
                }
                if (acBox.Items.Count > 0)
                {
                    acBox.Top = acTxt.Top + acTxt.Height - 5;
                    int rowCount = acBox.Items.Count;
                    if (acBox.Items.Count > 4) rowCount = 4;
                    acBox.Height = (acBox.ItemHeight + 4) * rowCount;
                    this.Height = acBox.Height + acTxt.Height + 6;

                    this.Width = (acTxt.Width > acBox.Width) ? acTxt.Width : acBox.Width;
                    if (maxWidth != -1)
                    {
                        if (this.Width > maxWidth) this.Width = maxWidth;
                    }

                    acBox.SelectedIndex = 0;
                    acBox.BringToFront();
                    acBox.Visible = true;
                }
                else hideResults();
            }
            else
            {
                preventTextChanged = false;
            }
        }

        void hideResults()
        {
            acBox.Visible = false;
            this.Height = acTxt.Height + 1;
        }

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        private void acTxt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up) && acBox.Visible && acBox.Items.Count > 1 && acBox.SelectedIndex > 0) 
            {
                acBox.SelectedIndex--;
                return;
            }
            if (e.KeyCode.Equals(Keys.Down) && acBox.Visible && acBox.Items.Count > 1 && acBox.SelectedIndex < acBox.Items.Count-1)
            {
                acBox.SelectedIndex++;
                return;
            }
            if (e.KeyCode.Equals(Keys.Home)) acBox.SelectedIndex = 0;
            if (e.KeyCode.Equals(Keys.End))
            {
                acBox.SelectedIndex = acBox.Items.Count - 1;
            }
            if (e.KeyCode.Equals(Keys.Back))
            {
                value = -1;
                acBox.Items.Clear();
                acTxt.Text = "";
            }
            //acTxt.Select(acTxt.Text.Length, 0);
        }

        private void acTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && acBox.SelectedItems.Count > 0)
            {
                preventTextChanged = true;
                acTxt.Text = acBox.Text;
                acTxt.Select(acTxt.Text.Length, 0);
                _value = ((KeyValuePair<int, string>)acBox.SelectedItem).Key;
                hideResults();
                ((ac_data)this.Parent).next();
                preventTextChanged = false;
            }
        }

        private void acTxt_Leave(object sender, EventArgs e)
        {
            if (!acBox.Focused)
            {
                if (_value == -1)
                {
                    _value = -1;
                    acTxt.Text = "";
                }
                else
                {
                    bool found = false;
                    for (int index = 0; index < acBox.Items.Count; index++)
                    {
                        if (((KeyValuePair<int, string>)acBox.Items[index]).Value == acTxt.Text.Trim()) found = true;
                    }
                    if (!found)
                    {
                        _value = -1;
                        acTxt.Text = "";
                    }
                }
                hideResults();
            }
        }

        private void acBox_Click(object sender, EventArgs e)
        {
            if (acBox.SelectedItems.Count > 0)
            {
                preventTextChanged = true;
                acTxt.Text = acBox.Text;
                acTxt.Select(acTxt.Text.Length, 0);
                _value = ((KeyValuePair<int, string>)acBox.SelectedItem).Key;
                hideResults();
            }
        }

        public void setText(string text)
        {
            acTxt.Text = text;
            if (acBox.Items.Count > 0)
            {
                preventTextChanged = true;
                acBox.SelectedIndex = 0;
                _value = ((KeyValuePair<int, string>)acBox.SelectedItem).Key;
            }
            else _value = -1;
            hideResults();
        }
    }
}
