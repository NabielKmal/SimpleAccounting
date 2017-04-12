using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace ATS.EnterpriseSystem.AppService
{
    public class DataTableHelper
    {
        public delegate void Action(System.Data.DataRow obj);

        public static void DoDataTableAction(System.Data.DataTable tbl, Action action)
        {
            foreach (System.Data.DataRow x in tbl.Rows)
            {
                switch (x.RowState)
                {
                    case DataRowState.Added:
                    case DataRowState.Modified:
                    case DataRowState.Unchanged:
                        action(x);
                        break;
                }
            }
        }
    }
}
