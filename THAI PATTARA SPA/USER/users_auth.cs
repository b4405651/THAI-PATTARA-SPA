using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace SPA_MANAGEMENT_SYSTEM.USER
{
    public partial class users_auth : Form
    {
        int user_id = 0;
        public users_auth()
        {
            InitializeComponent();
            GF.doDebug("===== CHILD FORM :: " + this.Name + " IS OPENED =====");
            this.FormClosing += (s, e) =>
            {
                GF.doDebug("===== CHILD FORM :: " + this.Name + " IS CLOSED =====");
            };

            emp_data.parentForm = this;

            emp_data_lbl.Top = GF.pageTop;
            emp_data.Top = emp_data_lbl.Top - 7;

            go_btn.Top = emp_data.Top;

            authTV.Width = Screen.PrimaryScreen.Bounds.Width - 20;
            authTV.Height = Screen.PrimaryScreen.Bounds.Height - 200;

            save_btn.Top = emp_data_lbl.Top - 2;
            save_btn.Left = authTV.Left + authTV.Width - save_btn.Width;

            authTV.Top = save_btn.Top + save_btn.Height + 7;

            loadTree(authTV);
        }

        private void loadTree(TreeView tree)
        {
            GF.showLoading(this);
            string queryString = @"SELECT *
            FROM MENU ORDER BY SORT";
            using (DataTable myDT = DB.getS(DB.insertRowNum("menu_id", queryString, false), null, "GET MENUS", false))
            {
                tree.Nodes.Clear();
                TreeNode node;
                TreeNode subNode;

                foreach (DataRow row in myDT.Rows) // 1st level
                {
                    node = tree.Nodes.Add(row["MENU_ID"].ToString() + "/NULL/NULL", row["MENU_NAME"].ToString());

                    queryString = @"SELECT *
                    FROM SUB_MENU
                    WHERE menu_id = " + row["MENU_ID"].ToString() + " ORDER BY SORT";
                    using (DataTable mySubDT = DB.getS(DB.insertRowNum("sub_menu_id", queryString, false), null, "GET SUB MENUS", false))
                    {
                        foreach (DataRow sub_row in mySubDT.Rows) // 2nd level
                        {
                            subNode = node.Nodes.Add(row["MENU_ID"].ToString() + "/" + sub_row["SUB_MENU_ID"].ToString() + "/NULL", sub_row["SUB_MENU_NAME"].ToString());

                            queryString = @"SELECT *
                            FROM SUB_MENU2
                            WHERE MENU_ID = " + row["MENU_ID"].ToString() + @"
                            AND SUB_MENU_ID = " + sub_row["SUB_MENU_ID"].ToString() + @"
                            ORDER BY SORT";
                            using (DataTable mySub2DT = DB.getS(DB.insertRowNum("sort", queryString, false), null, "GET SUB_MENU2 IN SUB MENU", false))
                            {
                                foreach (DataRow sub2_row in mySub2DT.Rows) // 3rd level
                                {
                                    subNode.Nodes.Add(row["MENU_ID"].ToString() + "/" + sub2_row["SUB_MENU_ID"].ToString() + "/" + sub2_row["SUB_MENU2_ID"].ToString(), sub2_row["SUB_MENU2_NAME"].ToString());
                                }
                            }

                            /*queryString = @"SELECT *
                    FROM MENU_ACTION
                    WHERE MENU_ID = " + row["MENU_ID"].ToString() + @"
                    AND SUB_MENU_ID = " + sub_row["SUB_MENU_ID"].ToString() + @"
                    ORDER BY SORT";
                            using (DataTable myActDT = DB.get(DB.insertRowNum("menu_action_id", queryString, false), "GET MENU ACTION IN SUB MENU", false))
                            {
                                foreach (DataRow act_row in myActDT.Rows)
                                {
                                    node.Nodes.Add(row["MENU_ID"].ToString() + "/" + sub_row["SUB_MENU_ID"].ToString() + "/" + act_row["MENU_ACTION_ID"].ToString(), act_row["MENU_ACTION_NAME"].ToString());
                                }
                            }*/
                        }
                    }

                    /*queryString = @"SELECT *
                    FROM MENU_ACTION
                    WHERE MENU_ID = " + row["MENU_ID"].ToString() + @"
                    AND SUB_MENU_ID IS NULL
                    ORDER BY SORT";
                    using (DataTable myActDT = DB.get(DB.insertRowNum("menu_action_id", queryString, false), "GET MENU ACTION IN SUB MENU", false))
                    {
                        foreach (DataRow act_row in myActDT.Rows)
                        {
                            node.Nodes.Add(row["MENU_ID"].ToString() + "/NULL/" + act_row["MENU_ACTION_NAME"].ToString(), act_row["MENU_ACTION_NAME"].ToString());
                        }
                    }*/
                }
            }
            tree.ExpandAll();
            GF.closeLoading();
        }

        private void authTV_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown) manageCheck(e.Node);
        }

        private void go_btn_Click(object sender, EventArgs e)
        {
            authTV.Visible = false;
            save_btn.Visible = false;
            if (emp_data.currentID == -1)
            {
                MessageBox.Show("PLEASE CHOOSE EMPLOYEE !!", "ERROR");
                return;
            }

            foreach (TreeNode parent_node in authTV.Nodes)
            {
                if (parent_node.Checked) parent_node.Checked = false;
                foreach (TreeNode node in parent_node.Nodes)
                {
                    if (node.Checked) node.Checked = false;
                    foreach (TreeNode sub_node in node.Nodes)
                    {
                        if (sub_node.Checked) sub_node.Checked = false;
                    }
                }

            }

            using (DataTable myDT = DB.getS("SELECT user_id FROM USERS WHERE emp_id = " + emp_data.currentID.ToString(), null, "GET USER_ID TO BE MANAGED FOR AUTH", false))
            {
                user_id = Convert.ToInt32(myDT.Rows[0]["user_id"]);
            }
            loadChecked();
            authTV.Visible = true;
        }

        private void loadChecked()
        {
            using (DataTable myDT = DB.getS("SELECT * FROM USERS_AUTH WHERE user_id = " + user_id.ToString(), null, "GET AUTH OF USER[" + user_id + "]", false))
            {
                foreach (DataRow row in myDT.Rows)
                {
                    string nodeName = row["menu_id"].ToString() + "/" + (row["sub_menu_id"].ToString() == "" ? "NULL" : row["sub_menu_id"].ToString()) + "/" + (row["sub_menu2_id"].ToString() == "" ? "NULL" : row["sub_menu2_id"].ToString());
                    TreeNode[] theNode = authTV.Nodes.Find(nodeName, true);
                    if (theNode.Count<TreeNode>() > 0)
                    {
                        theNode[0].Checked = true;
                        manageCheck(theNode[0]);
                    }
                }
            }
            save_btn.Visible = true;
        }

        private void manageCheck(TreeNode myNode)
        {
            if (myNode.Level == 0)
            {
                foreach (TreeNode node in myNode.Nodes)
                {
                    node.Checked = myNode.Checked;
                }
            }
            if (myNode.Level == 1)
            {
                foreach (TreeNode node in myNode.Nodes)
                {
                    node.Checked = myNode.Checked;
                }
                int friendCheckedCount = 0;
                foreach (TreeNode node in myNode.Parent.Nodes)
                {
                    if (node.Level == 1 && node.Checked)
                    {
                        friendCheckedCount++;
                    }
                }
                if (friendCheckedCount == 0)
                {
                    myNode.Parent.Checked = false;
                }
                else
                {
                    myNode.Parent.Checked = true;
                }
            }
            if (myNode.Level == 2)
            {
                // LV 1
                int friendCheckedCount = 0;
                foreach (TreeNode node in myNode.Parent.Nodes)
                {
                    if (node.Level == 2 && node.Checked)
                    {
                        friendCheckedCount++;
                    }
                }
                if (friendCheckedCount == 0)
                {
                    myNode.Parent.Checked = false;
                }
                else
                {
                    myNode.Parent.Checked = true;
                }

                // LV 0
                int rootCheckedCount = 0;
                foreach (TreeNode node in myNode.Parent.Parent.Nodes)
                {
                    if (node.Level == 1 && node.Checked)
                    {
                        rootCheckedCount++;
                    }
                }
                if (rootCheckedCount == 1)
                {
                    myNode.Parent.Parent.Checked = false;
                }
                else
                {
                    myNode.Parent.Parent.Checked = true;
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string queryString;

            GF.showLoading(this);
            DB.beginTrans();

            queryString = "DELETE FROM USERS_AUTH WHERE user_id = " + user_id.ToString();

            if (!DB.set(queryString, "DELETE USER AUTH [" + user_id.ToString() + "]"))
            {
                MessageBox.Show("ERROR DELETE USER AUTHS !!", "ERROR");
                return;
            }

            foreach (TreeNode parent_node in authTV.Nodes)
            {
                // LV0
                if (parent_node.Nodes.Count > 0)
                {
                    // HAS LV1
                    foreach (TreeNode node in parent_node.Nodes)
                    {
                        // LV1
                        if (node.Nodes.Count > 0)
                        {
                            // HAS LV2
                            foreach (TreeNode sub_node in node.Nodes)
                            {
                                // LV2
                                queryString = "";
                                string[] id = sub_node.Name.Split('/');

                                if (sub_node.Checked)
                                {
                                    queryString = @"INSERT INTO USERS_AUTH
                                ( user_id, menu_id, sub_menu_id, sub_menu2_id, auth )
                                VALUES (" +
                                        user_id.ToString() + @", " +
                                        id[0] + @", " +
                                        id[1] + @", " +
                                        id[2] + @", 0)";
                                    if (!DB.set(queryString, "ADD USER AUTH [" + user_id.ToString() + " > " + sub_node.Name + "]"))
                                    {
                                        MessageBox.Show("ERROR INSERT USER AUTH !!", "ERROR");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // NO LV2
                            queryString = "";
                            string[] id = node.Name.Split('/');

                            if (node.Checked)
                            {
                                queryString = @"INSERT INTO USERS_AUTH
                            ( user_id, menu_id, sub_menu_id, sub_menu2_id, auth )
                            VALUES (" +
                                    user_id.ToString() + @", " +
                                    id[0] + @", " +
                                    id[1] + @", " +
                                    id[2] + @", 0)";
                                if (!DB.set(queryString, "ADD USER AUTH [" + user_id.ToString() + " > " + node.Name + "]"))
                                {
                                    MessageBox.Show("ERROR INSERT USER AUTH !!", "ERROR");
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    // NO LV1
                    queryString = "";
                    string[] id = parent_node.Name.Split('/');

                    if (parent_node.Checked)
                    {
                        queryString = @"INSERT INTO USERS_AUTH
                            ( user_id, menu_id, sub_menu_id, sub_menu2_id, auth )
                            VALUES (" +
                            user_id.ToString() + @", " +
                            id[0] + @", " +
                            id[1] + @", " +
                            id[2] + @", 0)";
                        if (!DB.set(queryString, "ADD USER AUTH [" + user_id.ToString() + " > " + parent_node.Name + "]"))
                        {
                            MessageBox.Show("ERROR INSERT USER AUTH !!", "ERROR");
                            return;
                        }
                    }
                }
            }
            DB.close();

            //AUTH.setMenu(GF.mainPage, GF.username, GF.user_id.ToString());
            MessageBox.Show("SAVED !!", "COMPLETED");
            GF.closeLoading();
        }
    }
}

namespace System.Windows.Forms
{
    public class myTreeView : TreeView
    {
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203) // identified double click
                m.Result = IntPtr.Zero;
            else
                base.WndProc(ref m);
        }
    }
}
