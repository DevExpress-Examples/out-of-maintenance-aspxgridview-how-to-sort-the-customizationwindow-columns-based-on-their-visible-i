using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public partial class _Default : System.Web.UI.Page
{

    protected void gridView_BeforeGetCallbackResult(object sender, EventArgs e)
    {
        int currentIndex = 0;
        foreach (GridViewDataColumn column in gridView.DataColumns)
        {
            if (column.Visible == false)
                currentIndex++;
            string caption = System.Text.RegularExpressions.Regex.Replace(column.FieldName, "(?=[A-Z][a-z])|(?<=[a-z])(?=[A-Z])",
                " ", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
            column.Caption = !column.Visible ? string.Format("{0}) {1}", currentIndex.ToString("D2"), caption) : caption;
        }
    }
}