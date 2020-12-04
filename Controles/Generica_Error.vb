Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Public Class Generica_Error

    Dim Tabla_Error As New DataTable
    Dim Nombre_Pantalla As String

    Sub New(ByVal TABLA As DataTable, ByVal PANTALLA As String)
        InitializeComponent()
        Tabla_Error = TABLA
        Nombre_Pantalla = PANTALLA
    End Sub

    Private Sub Generica_Error_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GRID.DataSource = Tabla_Error
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_EXPORTAR_Click(sender As Object, e As EventArgs) Handles BTN_EXPORTAR.Click
        Try
            Dim DS = New DataSet
            DS.Tables.Add(Tabla_Error)

            If EXPORTAR_EXCEL(DS, "Errores en proceso {" & Nombre_Pantalla & "}") Then
                MessageBox.Show(Me, "Registro generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class