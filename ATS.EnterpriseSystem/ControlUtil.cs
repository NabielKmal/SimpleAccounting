using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;


namespace ATS.EnterpriseSystem
{
    public class ControlUtil
    {
        /// <summary>
        /// جعل اعمدة DataGridView
        /// لا تقبل الترتيب
        /// </summary>
        /// <param name="grid"></param>
        public static void PreventDataGridViewColumnSorting(DataGridView grid)
        {
            foreach (DataGridViewColumn x in grid.Columns)
            {
                x.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
