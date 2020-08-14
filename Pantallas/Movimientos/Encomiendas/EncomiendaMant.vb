Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class EncomiendaMant
    Dim Guia As Integer
    Dim Estado_Actualizar As String
    Dim Tipo_Mov As String
    Dim Numero_Doc As Integer
    Dim Padre As Encomienda

    Sub New(ByVal Num_Guia As Integer, ByVal Estado As String, ByVal Doc As Integer, ByVal Tipo As String, ByVal padrecito As Encomienda)
        InitializeComponent()
        Guia = Num_Guia
        Estado_Actualizar = Estado
        Numero_Doc = Doc
        Tipo_Mov = Tipo
        Padre = padrecito
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EncomiendaMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TXT_GUIA.Text = Guia
        RellenaCampos()
        RellenaTracking()
        CARGAR_RUTAS()

        GroupBox3.Enabled = IIf(Estado_Actualizar = "X", False, True)
    End Sub


    Private Sub RellenaCampos()
        Try
            Dim SQL = "	SELECT ENVIA.NOMBRE + ' ' + ENVIA.APELLIDO1 + ' ' + ENVIA.APELLIDO2 AS ENVIA,	"
            SQL &= Chr(13) & "	RETIRA.NOMBRE + ' ' + RETIRA.APELLIDO1 + ' ' + RETIRA.APELLIDO2 AS RETIRA,	"
            SQL &= Chr(13) & "	ORIGEN.DESC_UBICACION AS ORIGEN, DESTINO.DESC_UBICACION AS DESTINO, GUIA.CANT_BULTOS AS BULTOS"
            SQL &= Chr(13) & "	FROM DOCUMENTO_GUIA AS GUIA	"
            SQL &= Chr(13) & "	INNER JOIN DOCUMENTO_ENC AS ENC	"
            SQL &= Chr(13) & "		ON ENC.COD_CIA = GUIA.COD_CIA"
            SQL &= Chr(13) & "		AND ENC.COD_SUCUR = GUIA.COD_SUCUR"
            SQL &= Chr(13) & "      AND ENC.NUMERO_DOC = Guia.NUMERO_DOC"
            SQL &= Chr(13) & "		AND ENC.TIPO_MOV = GUIA.TIPO_MOV"
            SQL &= Chr(13) & "	INNER JOIN CLIENTE AS ENVIA	"
            SQL &= Chr(13) & "		ON ENVIA.COD_CIA = ENC.COD_CIA"
            SQL &= Chr(13) & "      AND ENVIA.CEDULA = ENC.CEDULA"
            SQL &= Chr(13) & "	INNER JOIN CLIENTE AS RETIRA	"
            SQL &= Chr(13) & "		ON RETIRA.COD_CIA = GUIA.COD_CIA"
            SQL &= Chr(13) & "		AND RETIRA.CEDULA = GUIA.CEDULA"
            SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS ORIGEN	"
            SQL &= Chr(13) & "		ON ORIGEN.COD_CIA = GUIA.COD_CIA"
            SQL &= Chr(13) & "      AND ORIGEN.COD_SUCUR = Guia.COD_SUCUR"
            SQL &= Chr(13) & "		AND ORIGEN.COD_UBICACION = GUIA.ORIGEN"
            SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS DESTINO	"
            SQL &= Chr(13) & "		ON DESTINO.COD_CIA = GUIA.COD_CIA"
            SQL &= Chr(13) & "      AND DESTINO.COD_SUCUR = Guia.COD_SUCUR"
            SQL &= Chr(13) & "		AND DESTINO.COD_UBICACION = GUIA.DESTINO"
            SQL &= Chr(13) & "	WHERE GUIA.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND GUIA.COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "  AND Guia.NUMERO_GUIA = " & Val(Guia)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    TXT_ENVIA.Text = ITEM("ENVIA")
                    TXT_RETIRA.Text = ITEM("RETIRA")
                    TXT_ORIGEN.Text = ITEM("ORIGEN")
                    TXT_DESTINO.Text = ITEM("DESTINO")
                    TXT_BULTO.Text = Val(ITEM("BULTOS"))
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RellenaTracking()
        Try
            Dim SQL = "	SELECT UBI.DESC_UBICACION, CONVERT(VARCHAR(10), DOC.FECHA_INC, 105) + ' ' + RIGHT(CONVERT(VARCHAR, DOC.FECHA_INC, 100), 7) AS FECHA,	"
            SQL &= Chr(13) & "	DOC.COD_USUARIO	"
            SQL &= Chr(13) & "	FROM DOCUMENTO_GUIA_UBICACION AS DOC 	"
            SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS UBI	"
            SQL &= Chr(13) & "		ON DOC.COD_CIA = UBI.COD_CIA"
            SQL &= Chr(13) & "      AND DOC.COD_SUCUR = UBI.COD_SUCUR"
            SQL &= Chr(13) & "		AND DOC.COD_UBICACION = UBI.COD_UBICACION"
            SQL &= Chr(13) & "	WHERE DOC.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND DOC.COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "  AND DOC.NUMERO_GUIA =  " & Val(Guia)
            SQL &= Chr(13) & "  ORDER BY DOC.FECHA_INC ASC"
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    Dim Lista_Item As ListViewItem = New ListViewItem(ITEM("DESC_UBICACION").ToString())
                    Lista_Item.SubItems.Add(ITEM("FECHA").ToString())
                    Lista_Item.SubItems.Add(ITEM("COD_USUARIO").ToString())
                    LST_TRACKING.Items.Add(Lista_Item)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CARGAR_RUTAS()
        Try
            CMB_ORIGEN.DataSource = Nothing

            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL = "	SELECT UBI.COD_UBICACION AS CODIGO, DESC_UBICACION AS NOMBRE	"
            SQL &= Chr(13) & "	FROM GUIA_UBICACION AS  UBI	"
            SQL &= Chr(13) & "	LEFT JOIN (		"
            SQL &= Chr(13) & "			SELECT COD_CIA, COD_SUCUR, COD_UBICACION"
            SQL &= Chr(13) & "			FROM DOCUMENTO_GUIA_UBICACION"
            SQL &= Chr(13) & "			WHERE COD_CIA =" & SCM(COD_CIA)
            SQL &= Chr(13) & "          And COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "          And NUMERO_GUIA = " & Val(Guia)
            SQL &= Chr(13) & "	) AS DOC	"
            SQL &= Chr(13) & "		ON DOC.COD_CIA = UBI.COD_CIA"
            SQL &= Chr(13) & "		AND DOC.COD_SUCUR = UBI.COD_SUCUR	"
            SQL &= Chr(13) & "      AND DOC.COD_UBICACION = UBI.COD_UBICACION"
            SQL &= Chr(13) & "	WHERE UBI.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "  And UBI.COD_SUCUR =" & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	AND ESTADO = 'A'	"
            SQL &= Chr(13) & "	And DOC.COD_CIA Is NULL	"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Row In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("CODIGO").ToString.ToUpper & " - " & Row("NOMBRE").ToString.ToUpper))
                Next

                CMB_ORIGEN.ValueMember = "Key"
                CMB_ORIGEN.DisplayMember = "Value"
                CMB_ORIGEN.DataSource = LISTA_REF
                CMB_ORIGEN.SelectedIndex = -1
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            Dim Sql = "INSERT INTO DOCUMENTO_GUIA_UBICACION(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,NUMERO_GUIA,COD_UBICACION,COD_USUARIO,FECHA_INC)"
            Sql &= Chr(13) & "SELECT " & SCM(COD_CIA) & "," & SCM(COD_SUCUR) & "," & Val(Numero_Doc) & "," & SCM(Tipo_Mov) & "," & Val(Guia)
            Sql &= Chr(13) & "," & SCM(CMB_ORIGEN.SelectedItem().ToString.Substring(1, 3)) & "," & SCM(COD_USUARIO) & ", GETDATE()"
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            Sql = "	UPDATE DOCUMENTO_GUIA	"
            Sql &= Chr(13) & "	SET ESTADO = " & SCM(Estado_Actualizar)
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	AND NUMERO_DOC = " & Val(Numero_Doc)
            Sql &= Chr(13) & "	AND TIPO_MOV = " & SCM(Tipo_Mov)
            Sql &= Chr(13) & "	AND NUMERO_GUIA = " & Val(Guia)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            MessageBox.Show("¡Guia actualizada correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cerrar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Cerrar()
        Padre.Refrescar()
        Me.Close()
    End Sub

End Class