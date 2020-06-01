using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPA_MANAGEMENT_SYSTEM
{
    public class ComboItem
    {
        public int Key; public string Value;
        public ComboItem(int key, string value)
        {
            Key = key; Value = value;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Value;
        }
    }
}
