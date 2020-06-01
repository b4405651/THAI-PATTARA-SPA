using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class AUTH
    {
        public static bool mainMenuAuth(String[,] auth, String menu_id)
        {
            bool found = false;
            for (int arrayIndex = 0; arrayIndex < auth.GetLength(0); arrayIndex++)
            {
                //GF.doDebug("[ CHECK AUTH :: MAIN ] >>> " + menu_id + " : " + auth[arrayIndex, 0]);
                if (auth[arrayIndex, 0] == menu_id.ToString())
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public static bool subMenuAuth(String[,] auth, String menu_id, String sub_menu_id)
        {
            bool found = false;
            for (int arrayIndex = 0; arrayIndex < auth.GetLength(0); arrayIndex++)
            {
                //GF.doDebug("[ CHECK AUTH :: SUB1 ] >>> " + menu_id + " : " + auth[arrayIndex, 0] + " , " + sub_menu_id + " : " + auth[arrayIndex, 1]);
                if (auth[arrayIndex, 0] == menu_id.ToString() && auth[arrayIndex, 1] == sub_menu_id)
                {
                    found = true;
                    //GF.doDebug("[ CHECK AUTH :: SUB1 ] >>> F O U N D !!");
                    break;
                }
            }

            return found;
        }

        public static bool sub2MenuAuth(String[,] auth, String menu_id, String sub_menu_id, String sub_menu2_id)
        {
            bool found = false;
            for (int arrayIndex = 0; arrayIndex < auth.GetLength(0); arrayIndex++)
            {
                //GF.doDebug("[ CHECK AUTH :: SUB1 ] >>> " + menu_id + " : " + auth[arrayIndex, 0] + " , " + sub_menu_id + " : " + auth[arrayIndex, 1] + " , " + sub_menu2_id + " : " + auth[arrayIndex, 2]);
                if (auth[arrayIndex, 0] == menu_id.ToString() && auth[arrayIndex, 1] == sub_menu_id && auth[arrayIndex, 2] == sub_menu2_id)
                {
                    found = true;
                    //GF.doDebug("[ CHECK AUTH :: SUB1 ] >>> F O U N D !!");
                    break;
                }
            }

            return found;
        }

        public static void setMenu(main_page mainPage, String username, String user_id)
        {
            String[,] auth;

            //GET USER AUTH
            using (DataTable authDT = DB.getS("SELECT ISNULL(MENU_ID, -1) MENU_ID, ISNULL(SUB_MENU_ID, -1) SUB_MENU_ID, ISNULL(SUB_MENU2_ID, -1) SUB_MENU2_ID FROM USERS_AUTH WHERE user_id = " + user_id, null, "CHECK AUTH FOR USER_ID[" + user_id + "]", false))
            {
                if (authDT.Rows.Count == 0 && username != "admin") return;
                auth = new String[authDT.Rows.Count, 3];
                int index = 0;
                foreach (DataRow authRow in authDT.Rows)
                {
                    auth[index, 0] = authRow["MENU_ID"].ToString();
                    auth[index, 1] = authRow["SUB_MENU_ID"].ToString();
                    auth[index, 2] = authRow["SUB_MENU2_ID"].ToString();
                    index++;
                }
            }

            /*for (int arrayIndex = 0; arrayIndex < auth.GetLength(0); arrayIndex++)
            {
                GF.doDebug("[ " + arrayIndex + " ] >>> " + auth[arrayIndex, 0] + " , " + auth[arrayIndex, 1] + " , " + auth[arrayIndex, 2]);
            }*/

            //MAIN MENU
            foreach (ToolStripMenuItem menu in mainPage.MainMenuStrip.Items)
            {
                menu.Visible = false;

                if (menu.Tag.ToString() == String.Empty) menu.Visible = false;
                else if (menu.Tag.ToString() == "SKIP" || username == "admin" || AUTH.mainMenuAuth(auth, menu.Tag.ToString()))
                {
                    menu.Visible = true;
                    bool foundBefore = false;
                    bool foundLater = false;
                    bool foundSep = false;

                    //SUB MENU LEVEL 1
                    foreach (Object sub1Item in menu.DropDown.Items)
                    {
                        if (((ToolStripItem)sub1Item).Name.IndexOf("toolStripSeparator") != -1) foundSep = true;
                        else
                        {
                            ((ToolStripItem)sub1Item).Visible = false;
                            if (((ToolStripItem)sub1Item).Tag.ToString() == String.Empty) ((ToolStripItem)sub1Item).Visible = false;
                            else if (username == "admin" || AUTH.subMenuAuth(auth, menu.Tag.ToString(), ((ToolStripItem)sub1Item).Tag.ToString()))
                            {
                                if (((ToolStripItem)sub1Item).Tag.ToString() != "SKIP") ((ToolStripItem)sub1Item).Visible = true;
                                if (!foundSep) foundBefore = true;
                                else foundLater = true;

                                if (sub1Item.GetType().Equals(typeof(ToolStripMenuItem)))
                                //if we get the desired object type.
                                {
                                    ToolStripMenuItem sub2 = (ToolStripMenuItem)sub1Item;
                                    // cast to ToolStripMenuItem

                                    if (sub2.HasDropDownItems) // if subMenu has children
                                    {
                                        // SUB MENU LEVEL 2
                                        bool subFoundBefore = false;
                                        bool subFoundLater = false;
                                        bool subFoundSep = false;
                                        foreach (Object sub2Item in sub2.DropDown.Items)
                                        {
                                            if (((ToolStripItem)sub2Item).Name.IndexOf("toolStripSeparator") != -1) subFoundSep = true;
                                            else
                                            {
                                                //GF.doDebug("[ " + ((ToolStripItem)sub1Item).Text + " ] >>> " + ((ToolStripItem)sub2Item).Text);
                                                if (((ToolStripItem)sub1Item).Tag.ToString() == String.Empty) ((ToolStripItem)sub1Item).Visible = false;
                                                else if (((ToolStripItem)sub2Item).Tag == null) ((ToolStripItem)sub2Item).Visible = true;
                                                else
                                                {
                                                    ((ToolStripItem)sub2Item).Visible = false;
                                                    if (username == "admin" || AUTH.sub2MenuAuth(auth, menu.Tag.ToString(), ((ToolStripItem)sub1Item).Tag.ToString(), ((ToolStripItem)sub2Item).Tag.ToString()))
                                                    {
                                                        if (((ToolStripItem)sub2Item).Tag.ToString() != "SKIP") ((ToolStripItem)sub2Item).Visible = true;
                                                        if (!subFoundSep) subFoundBefore = true;
                                                        else subFoundLater = true;
                                                    }
                                                }
                                            }
                                        }

                                        foreach (ToolStripItem sub2Item in sub2.DropDown.Items)
                                        {
                                            if (sub2Item.GetType() == typeof(ToolStripSeparator))
                                            {
                                                if (subFoundBefore && subFoundLater) sub2Item.Visible = true;
                                                else sub2Item.Visible = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    foreach (ToolStripItem sub1 in menu.DropDown.Items)
                    {
                        if (sub1.GetType() == typeof(ToolStripSeparator))
                        {
                            if (foundBefore && foundLater) sub1.Visible = true;
                            else sub1.Visible = false;
                        }
                    }
                }
            }
        }
    }
}
