using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace ATS.EnterpriseSystem
{
    public static class DataSetExtensions
    {
        public static void ClearErrors(DataSet dataset)
        {
            foreach (DataTable x in dataset.Tables)
            {
                foreach (DataRow x2 in x.Rows)
                {
                    x2.ClearErrors();
                }
            }
        }

        public static void ClearErrors(DataTable tbl)
        {

            foreach (DataRow x in tbl.Rows)
            {
                x.ClearErrors();
            }

        }
    }
}
