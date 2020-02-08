Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Usuario
    Dim COD_USUARIO As String = ""
    Private Sub UsuariosDerechos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_usuarios()
    End Sub

    Private Sub Cargar_usuarios()
        Try
            GRID.DataSource = Nothing
            Dim SQL = "	            SELECT U.COD_USUARIO AS Codigo,U.NOMBRE AS Nombre, CORREO AS Email,ESTADO AS Estado,CONVERT(VARCHAR,FECHA_INC,103) AS 'Fecha ingreso' "
            SQL &= Chr(13) & "	            	FROM USUARIO AS U	"
            SQL &= Chr(13) & "	            	INNER JOIN COMPANIA_USUARIO AS CU	"
            SQL &= Chr(13) & "	            		ON U.COD_USUARIO = CU.COD_USUARIO	"
            SQL &= Chr(13) & "	            		AND CU.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	              ORDER BY U.NOMBRE ASC		"
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

    Private Sub BTN_DERECHO_Click(sender As Object, e As EventArgs) Handles BTN_DERECHO.Click
        Try
            Leer_indice()
            If COD_USUARIO <> "" Then
                Dim PANTALLA As New DerechosUsuario(COD_USUARIO)
                PANTALLA.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                COD_USUARIO = seleccionado.Cells(0).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class