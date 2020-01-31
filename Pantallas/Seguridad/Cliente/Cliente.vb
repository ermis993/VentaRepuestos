Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Cliente
    Private Sub Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RELLENAR_GRID()
    End Sub
    Private Sub RELLENAR_GRID()
        Try
            GRID.DataSource = Nothing
            Dim SQL = "	SELECT COD_CIA As Código,CEDULA As Cédula,"
            SQL &= Chr(13) & "	CASE WHEN TIPO_CEDULA ='F' THEN 'Física' "
            SQL &= Chr(13) & "	WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END AS 'Tipo cédula',"
            SQL &= Chr(13) & "	NOMBRE As Nombre,APELLIDO1 As 'Primer apellido',APELLIDO2 as 'Segundo apellido',TELEFONO as Teléfono,CORREO as Email,SALDO as Saldo,ESTADO as Estado,FECHA_INC AS 'Fecha ingreso'"
            SQL &= Chr(13) & "	FROM CLIENTE"
            If RB_ACTIVOS.Checked = True Then
                SQL &= Chr(13) & "	WHERE ESTADO ='A'"
            ElseIf RB_INACTIVOS.Checked = True Then
                SQL &= Chr(13) & "	WHERE ESTADO ='I'"
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRID.DataSource = DS.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        REFRESCAR()
    End Sub
    Private Sub RB_ACTIVOS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVOS.CheckedChanged, RB_INACTIVOS.CheckedChanged, RB_TODOS.CheckedChanged
        REFRESCAR()
    End Sub
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click

    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
    Public Sub REFRESCAR()
        RELLENAR_GRID()
    End Sub
End Class