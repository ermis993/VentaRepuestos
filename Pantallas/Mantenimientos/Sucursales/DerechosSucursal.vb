Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Public Class DerechosSucursal
    Dim COD_SUCUR As String

    Sub New(ByVal COD_SUCUR As String)
        InitializeComponent()
        Me.COD_SUCUR = COD_SUCUR
        RellenaListViews()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaUsuarioSinDerecho()
        Try

            LVSin.Clear()
            LVSin.Columns.Add("Usuario", 287)
            Dim SQL As String = ""
            If COD_USUARIO = "LUNAING" Then
                SQL = "	SELECT U.COD_USUARIO AS Codigo, U.COD_USUARIO + '-' + U.NOMBRE AS Nombre	"
                SQL &= Chr(13) & "	FROM USUARIO AS U		"
                SQL &= Chr(13) & "	LEFT JOIN SUCURSAL_USUARIO AS CU "
                SQL &= Chr(13) & "		ON U.COD_USUARIO = CU.COD_USUARIO	"
                SQL &= Chr(13) & "		AND CU.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "		AND CU.COD_SUCUR = " & SCM(Me.COD_SUCUR)
                SQL &= Chr(13) & "	WHERE CU.COD_USUARIO IS NULL	"
                SQL &= Chr(13) & "  ORDER BY U.NOMBRE ASC"
            Else
                SQL = "	SELECT U.COD_USUARIO AS Codigo, U.COD_USUARIO + '-' + U.NOMBRE AS Nombre	"
                SQL &= Chr(13) & "	FROM USUARIO AS U		"
                SQL &= Chr(13) & "	LEFT JOIN SUCURSAL_USUARIO AS CU "
                SQL &= Chr(13) & "		ON U.COD_USUARIO = CU.COD_USUARIO	"
                SQL &= Chr(13) & "		AND CU.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "		AND CU.COD_SUCUR = " & SCM(Me.COD_SUCUR)
                SQL &= Chr(13) & "	WHERE CU.COD_USUARIO IS NULL	"
                SQL &= Chr(13) & "	AND U.COD_USUARIO <> 'LUNAING'	"
                SQL &= Chr(13) & "  ORDER BY U.NOMBRE ASC"
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            For Each Row In DS.Tables(0).Rows
                LVSin.Items.Add(Row.Item(1))
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub RellenaUsuarioConDerecho()
        Try
            LVCon.Clear()
            LVCon.Columns.Add("Usuario", 287)
            Dim SQL As String = ""
            If COD_USUARIO = "LUNAING" Then
                SQL = "	SELECT U.COD_USUARIO AS Codigo, U.COD_USUARIO + '-' + U.NOMBRE AS Nombre	"
                SQL &= Chr(13) & "	FROM USUARIO AS U		"
                SQL &= Chr(13) & "	INNER JOIN SUCURSAL_USUARIO AS CU	"
                SQL &= Chr(13) & "		ON U.COD_USUARIO = CU.COD_USUARIO	"
                SQL &= Chr(13) & "		AND CU.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "		AND CU.COD_SUCUR = " & SCM(Me.COD_SUCUR)
                SQL &= Chr(13) & "	WHERE U.COD_USUARIO IS NOT NULL	"
                SQL &= Chr(13) & "  ORDER BY U.NOMBRE ASC"
            Else
                SQL = "	SELECT U.COD_USUARIO AS Codigo, U.COD_USUARIO + '-' + U.NOMBRE AS Nombre	"
                SQL &= Chr(13) & "	FROM USUARIO AS U		"
                SQL &= Chr(13) & "	INNER JOIN SUCURSAL_USUARIO AS CU	"
                SQL &= Chr(13) & "		ON U.COD_USUARIO = CU.COD_USUARIO	"
                SQL &= Chr(13) & "		AND CU.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "		AND CU.COD_SUCUR = " & SCM(Me.COD_SUCUR)
                SQL &= Chr(13) & "	WHERE U.COD_USUARIO IS NOT NULL	"
                SQL &= Chr(13) & "	AND U.COD_USUARIO <> 'LUNAING'	"
                SQL &= Chr(13) & "  ORDER BY U.NOMBRE ASC"
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            For Each Row In DS.Tables(0).Rows
                LVCon.Items.Add(Row.Item(1))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            If Not LVSin.FocusedItem Is Nothing Then
                Dim Usuario = LVSin.Items(LVSin.FocusedItem.Index).SubItems(0).Text

                Dim SQL = "	INSERT INTO SUCURSAL_USUARIO(COD_CIA, COD_SUCUR, COD_USUARIO)	"
                SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(Me.COD_SUCUR) & "," & SCM(Usuario.Substring(0, Usuario.IndexOf("-")))

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                RellenaListViews()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_QUITAR_Click(sender As Object, e As EventArgs) Handles BTN_QUITAR.Click
        Try
            If Not LVCon.FocusedItem Is Nothing Then
                Dim Usuario = LVCon.Items(LVCon.FocusedItem.Index).SubItems(0).Text

                Dim SQL = "	DELETE FROM SUCURSAL_USUARIO"
                SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & " AND COD_SUCUR = " & SCM(Me.COD_SUCUR)
                SQL &= Chr(13) & " AND COD_USUARIO = " & SCM(Usuario.Substring(0, Usuario.IndexOf("-")))

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                RellenaListViews()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaListViews()
        RellenaUsuarioSinDerecho()
        RellenaUsuarioConDerecho()
    End Sub


End Class