Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub gridView_BeforeGetCallbackResult(ByVal sender As Object, ByVal e As EventArgs)
        Dim currentIndex As Integer = 0
        For Each column As GridViewDataColumn In gridView.DataColumns
            If column.Visible = False Then
                currentIndex += 1
            End If
            Dim caption As String = System.Text.RegularExpressions.Regex.Replace(column.FieldName, "(?=[A-Z][a-z])|(?<=[a-z])(?=[A-Z])", " ", System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
            column.Caption = If((Not column.Visible), String.Format("{0}) {1}", currentIndex.ToString("D2"), caption), caption)
        Next column
    End Sub
End Class