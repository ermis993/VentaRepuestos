Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Compania
    Dim COD_CIA As String = ""
    Private Sub Compania_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rellenar_GRID()
    End Sub
    Private Sub Rellenar_GRID()
        Try
            GRID.DataSource = Nothing
            Dim SQL = "	SELECT COD_CIA As Código,NOMBRE As Nombre,"
            SQL &= Chr(13) & "	CASE WHEN TIPO_CEDULA ='F' THEN 'Física' "
            SQL &= Chr(13) & "	WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END AS 'Tipo cédula',"
            SQL &= Chr(13) & "	CEDULA As Cédula,CORREO As Correo,PROVINCIA as Provincia,CANTON as Cantón,DISTRITO as Distrito"
            SQL &= Chr(13) & "	FROM COMPANIA"

            If RB_ACTIVAS.Checked = True Then
                SQL &= Chr(13) & "	WHERE ESTADO ='A'"
            ElseIf RB_INACTIVAS.Checked = True Then
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
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Dim PANTALLA As New LBL_CANTON(CRF_Modos.Insertar, Me)
        PANTALLA.ShowDialog()
    End Sub

    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Modificar()
    End Sub
    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                COD_CIA = seleccionado.Cells(0).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Refrescar()
        Rellenar_GRID()
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        Refrescar()
    End Sub
    Private Sub Modificar()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
                Dim PANTALLA As New LBL_CANTON(CRF_Modos.Modificar, Me, COD_CIA)
                PANTALLA.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Modificar()
    End Sub

    Private Sub RB_ACTIVAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVAS.CheckedChanged, RB_INACTIVAS.CheckedChanged, RB_TODAS.CheckedChanged
        Refrescar()
    End Sub

    Private Sub BTN_DERECHO_Click(sender As Object, e As EventArgs) Handles BTN_DERECHO.Click
        Try
            Leer_indice()
            If String.IsNullOrEmpty(COD_CIA) = False Then
                Dim Derechos As New DerechosCompania(COD_CIA)
                Derechos.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar la compañía")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class