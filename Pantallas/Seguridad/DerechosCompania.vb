Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Public Class DerechosCompania

    Dim COD_CIA As String

    Sub New(ByVal COD_CIA As String)
        InitializeComponent()
        Me.COD_CIA = COD_CIA
        CARGAR_COMPANIA()
        RellenaListViews()
    End Sub

    Private Sub CARGAR_COMPANIA()
        Try
            CMB_COMPANIA.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = "SELECT COD_CIA AS CODIGO , NOMBRE"
            SQL &= Chr(13) & " FROM COMPANIA"
            SQL &= Chr(13) & " WHERE ESTADO ='A'"
            SQL &= Chr(13) & " AND COD_CIA = " & SCM(COD_CIA)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each CANTON In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(CANTON("CODIGO").ToString, CANTON("CODIGO").ToString & " - " & CANTON("NOMBRE").ToString.ToUpper))
                Next
            End If
            CMB_COMPANIA.DataSource = LISTA_REF
            CMB_COMPANIA.ValueMember = "Key"
            CMB_COMPANIA.DisplayMember = "Value"
            CMB_COMPANIA.SelectedIndex = 0
        Catch ex As Exception
        End Try
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

            Dim Sql = "	SELECT U.COD_USUARIO AS Codigo, U.COD_USUARIO + '-' + U.NOMBRE AS Nombre	"
            Sql &= Chr(13) & "	FROM USUARIO AS U		"
            Sql &= Chr(13) & "	LEFT JOIN COMPANIA_USUARIO AS CU "
            Sql &= Chr(13) & "		ON U.COD_USUARIO = CU.COD_USUARIO	"
            Sql &= Chr(13) & "		AND CU.COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	WHERE CU.COD_USUARIO IS NULL	"
            Sql &= Chr(13) & "  ORDER BY U.NOMBRE ASC"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
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

            Dim SQL = "	SELECT U.COD_USUARIO AS Codigo, U.COD_USUARIO + '-' + U.NOMBRE AS Nombre	"
            SQL &= Chr(13) & "	FROM USUARIO AS U		"
            SQL &= Chr(13) & "	INNER JOIN COMPANIA_USUARIO AS CU	"
            SQL &= Chr(13) & "		ON U.COD_USUARIO = CU.COD_USUARIO	"
            SQL &= Chr(13) & "		AND CU.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	WHERE U.COD_USUARIO IS NOT NULL	"
            SQL &= Chr(13) & "  ORDER BY U.NOMBRE ASC"

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

                Dim SQL = "	INSERT INTO COMPANIA_USUARIO(COD_CIA, COD_USUARIO)	"
                SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(Usuario.Substring(0, Usuario.IndexOf("-")))

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

                Dim SQL = "	DELETE FROM COMPANIA_USUARIO"
                SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
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