Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Login
Public Class Sucursal
    Private Sub Sucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenaSucursales()
    End Sub

    Private Sub RellenaSucursales()
        Try
            Dim Estado As String

            If RB_ACTIVAS.Checked Then
                Estado = "A"
            ElseIf RB_INACTIVAS.Checked Then
                Estado = "I"
            Else
                Estado = "T"
            End If

            Dim Sql = "	SELECT COD_SUCUR AS Codigo, NOMBRE AS Nombre, DIRECCION as Direccion, TELEFONO as Telefono, CORREO as Correo"
            Sql &= Chr(13) & "	FROM SUCURSAL"
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM("001")
            Sql &= Chr(13) & " And (Estado = " & SCM(Estado) & " Or 'T' = " & SCM(Estado) & ")"
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            Dim Tabla As DataTable = DS.Tables(0)
            GRID.DataSource = Tabla
            GRID.AutoResizeColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
            MenuPrincipal.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RB_ACTIVAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVAS.CheckedChanged
        If RB_ACTIVAS.Checked Then
            RellenaSucursales()
        End If
    End Sub
    Private Sub RB_INACTIVAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_INACTIVAS.CheckedChanged
        If RB_INACTIVAS.Checked Then
            RellenaSucursales()
        End If
    End Sub
    Private Sub RB_TODAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_TODAS.CheckedChanged
        If RB_TODAS.Checked Then
            RellenaSucursales()
        End If
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        RellenaSucursales()
    End Sub
End Class