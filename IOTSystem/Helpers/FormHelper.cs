using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IOTSystem.Helpers
{
    internal class FormHelper
    {
        public static void SortColumnsOfDgw(DataGridView dgw, params string[] columnNames)
        {
            for (int i = 0; i < columnNames.Length; i++)
            {
                dgw.Columns[columnNames[i]].DisplayIndex = i;
            }
        }

        public static void HideColumnsOfDgw(DataGridView dgw, params string[] columnNames)
        {
            for (int i = 0; i < columnNames.Length; i++)
            {
                dgw.Columns[columnNames[i]].Visible = false;
            }
        }

        public static void RenameColumnsOfDgw(DataGridView dgw, Dictionary<string, string> columnNames)
        {
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                if (columnNames.Keys.Contains(column.Name))
                {
                    column.HeaderText = columnNames[column.Name];
                }
            }
        }
    }
}
