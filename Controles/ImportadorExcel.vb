Imports System.Data.OleDb
Imports System.Windows

Public Class ImportadorExcel
    Dim DatosExcel As DataTable
    Public Shared DT_R = New DataSet()

    Public Shared Property ObtieneDataSet() As DataSet
        Get
            Return DT_R
        End Get
        Set(ByVal value As DataSet)
            DT_R = value
        End Set
    End Property

    Private Sub BTN_EXAMINAR_Click(sender As Object, e As EventArgs) Handles BTN_EXAMINAR.Click

        Dim OFD As New OpenFileDialog With {
               .Filter = "Archivos .xlsx|*.xlsx",
               .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
           }

        If OFD.ShowDialog = Forms.DialogResult.OK Then
            For Each DOC In OFD.FileNames
                ImportarAGrid(DOC.ToString)
            Next
        End If
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Me.Close()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub ImportarAGrid(ByVal FilePath As String)
        Try
            Dim conStr As String = ""

            conStr = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" & FilePath & ";Extended Properties='Excel 12.0 Xml;HDR=YES';"

            Dim connExcel As New OleDbConnection(conStr)
            Dim cmdExcel As New OleDbCommand()
            Dim oda As New OleDbDataAdapter()
            Dim dt As New DataTable()

            cmdExcel.Connection = connExcel
            connExcel.Open()

            Dim dtExcelSchema As DataTable
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
            connExcel.Close()

            connExcel.Open()
            cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
            oda.SelectCommand = cmdExcel
            oda.Fill(dt)
            connExcel.Close()

            DT_R.Tables.Add(dt)

            GRID.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Try
            DatosExcel.Clear()
            GRID.DataSource = DatosExcel
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class