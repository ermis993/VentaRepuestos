Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Filtro
    Public Event Filtrar_Click As EventHandler
    Public Property VALOR As String
        Get
            Return Me.TXT.Text
        End Get
        Set(ByVal value As String)
            Me.TXT.Text = value
        End Set
    End Property
    Private Sub BTN_FILTRAR_Click(sender As Object, e As EventArgs) Handles BTN_FILTRAR.Click
        RaiseEvent Filtrar_Click(Me, e)
    End Sub
    Public Function FILTRAR() As String
        Try
            Dim CONSULTA = " AND " & CMB.SelectedValue & " LIKE '%" & TXT.Text & "%'"
            Return CONSULTA
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Sub FILTRO_CARGAR_COMBO(ByVal GRID As DataGridView)
        Try
            CMB.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            For Each COLUMN In GRID.Columns
                COLUMN.Name
                COLUMN.HeaderText

                If COLUMN.HeaderText.ToString.ToUpper.Contains("FECHA") Or COLUMN.NameToString.ToUpper.Contains("FECHA") Then
                Else
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(COLUMN.Name, COLUMN.HeaderText))
                End If
            Next
            CMB.DataSource = LISTA_REF
            CMB.ValueMember = "Key"
            CMB.DisplayMember = "Value"
            CMB.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
