Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Compania
    Dim COD_CIA As String = ""
    Private Sub Compania_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rellenar_GRID()
    End Sub
    Private Sub Rellenar_GRID()
        GRID.DataSource = Nothing
        Dim SQL = "	SELECT COD_CIA,NOMBRE,"
        SQL &= Chr(13) & "	CASE WHEN TIPO_CEDULA ='F' THEN 'Física' "
        SQL &= Chr(13) & "	WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END AS TIPO_CEDULA,"
        SQL &= Chr(13) & "	CEDULA,CORREO,PROVINCIA,CANTON,DISTRITO"
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
                Dim INDICE As DataGridViewCellCollection
                INDICE = GRID.SelectedRows.Item(0).Cells
                If IsNothing(INDICE) = False Then
                    COD_CIA = INDICE.Item("COD_CIA").Value
                End If
            End If
        Catch ex As Exception

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
        If Me.GRID.Rows.Count > 0 Then
            Leer_indice()
            Dim PANTALLA As New LBL_CANTON(CRF_Modos.Modificar, Me, COD_CIA)
            PANTALLA.ShowDialog()
        End If
    End Sub
    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Modificar()
    End Sub
End Class