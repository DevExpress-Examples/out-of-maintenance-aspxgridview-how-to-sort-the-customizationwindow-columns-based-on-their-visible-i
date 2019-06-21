<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to sort the CustomizationWindow columns based on their visible index
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t248252/)**
<!-- run online end -->


<p>By design, ASPxGridView orders columns in CustomizationWindow based on a column's caption. Thus, it is necessary to change the column caption to change its order in the CustomizationWindow. Adding an index before the caption allows you to set the custom column order:</p>


```cs
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
```



<br/>


