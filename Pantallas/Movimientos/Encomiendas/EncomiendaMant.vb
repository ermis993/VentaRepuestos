Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class EncomiendaMant
    Dim Guia As String
    Dim Estado_Actualizar As String
    Dim Tipo_Mov As String
    Dim Numero_Doc As Integer
    Dim Padre As Encomienda
    Dim Palabra_Clave As String
    Dim Cod_SUCUR_DERECHO As String

    Sub New(ByVal Num_Guia As String, ByVal Estado As String, ByVal Doc As Integer, ByVal Tipo As String, ByVal padrecito As Encomienda, ByVal Palabra As String)
        InitializeComponent()
        Guia = Num_Guia
        Estado_Actualizar = Estado
        Numero_Doc = Doc
        Tipo_Mov = Tipo
        Padre = padrecito
        Palabra_Clave = Palabra
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
        CARGAR_RUTAS(Palabra_Clave)
        CARGAR_SUCURSALES()

        Label6.Visible = IIf(Estado_Actualizar = "T", True, False)
        CMB_SUCURSAL.Visible = IIf(Estado_Actualizar = "T", True, False)

        GroupBox3.Enabled = IIf(Estado_Actualizar = "X", False, True)
        BTN_ACEPTAR.Enabled = IIf(Estado_Actualizar = "X", False, True)
    End Sub


    Private Sub RellenaCampos()
        Try
            Dim SQL = "	SELECT GUIA.COD_SUCUR,  GUIA.ENVIA AS ENVIA,	"
            SQL &= Chr(13) & "	GUIA.RETIRA AS RETIRA,	"
            SQL &= Chr(13) & "	ORIGEN.DESC_UBICACION AS ORIGEN, DESTINO.DESC_UBICACION AS DESTINO, GUIA.CANT_BULTOS AS BULTOS"
            SQL &= Chr(13) & "	FROM DOCUMENTO_GUIA AS GUIA	"
            SQL &= Chr(13) & "	INNER JOIN DOCUMENTO_ENC AS ENC	"
            SQL &= Chr(13) & "		ON ENC.COD_CIA = GUIA.COD_CIA"
            SQL &= Chr(13) & "      AND ENC.NUMERO_DOC = Guia.NUMERO_DOC"
            SQL &= Chr(13) & "		AND ENC.TIPO_MOV = GUIA.TIPO_MOV"
            SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS ORIGEN	"
            SQL &= Chr(13) & "		ON ORIGEN.COD_CIA = GUIA.COD_CIA"
            SQL &= Chr(13) & "		AND ORIGEN.COD_UBICACION = GUIA.ORIGEN"
            SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS DESTINO	"
            SQL &= Chr(13) & "		ON DESTINO.COD_CIA = GUIA.COD_CIA"
            SQL &= Chr(13) & "		AND DESTINO.COD_UBICACION = GUIA.DESTINO"
            SQL &= Chr(13) & "	WHERE GUIA.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND GUIA.COD_DERECHO = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "  AND GUIA.NUMERO_GUIA = " & SCM(Guia)
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
                    Cod_SUCUR_DERECHO = ITEM("COD_SUCUR")
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
            SQL &= Chr(13) & "		AND DOC.COD_UBICACION = UBI.COD_UBICACION"
            SQL &= Chr(13) & "	WHERE DOC.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "  AND DOC.NUMERO_GUIA =  " & SCM(Guia)
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
    Private Sub CARGAR_RUTAS(ByVal Palabra_Clave As String)
        Try
            CMB_ORIGEN.DataSource = Nothing

            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL = "	SELECT UBI.COD_UBICACION AS CODIGO, DESC_UBICACION AS NOMBRE	"
            SQL &= Chr(13) & "	FROM GUIA_UBICACION AS  UBI	"
            SQL &= Chr(13) & "	LEFT JOIN (		"
            SQL &= Chr(13) & "			SELECT COD_CIA, COD_SUCUR, COD_UBICACION"
            SQL &= Chr(13) & "			FROM DOCUMENTO_GUIA_UBICACION"
            SQL &= Chr(13) & "			WHERE COD_CIA =" & SCM(COD_CIA)
            SQL &= Chr(13) & "          AND COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "          AND NUMERO_GUIA = " & SCM(Guia)
            SQL &= Chr(13) & "	) AS DOC	"
            SQL &= Chr(13) & "		ON DOC.COD_CIA = UBI.COD_CIA"
            SQL &= Chr(13) & "      AND DOC.COD_UBICACION = UBI.COD_UBICACION"
            SQL &= Chr(13) & "	WHERE UBI.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND ESTADO = 'A'	"
            SQL &= Chr(13) & "	And DOC.COD_CIA IS NULL	"
            SQL &= Chr(13) & " AND UBI.IND_TIPO = 'S'"
            SQL &= Chr(13) & " AND DESC_UBICACION LIKE " & SCM("%" & Palabra_Clave & "%")

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

    Private Sub CARGAR_SUCURSALES()
        Try
            CMB_SUCURSAL.DataSource = Nothing

            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL = "	SELECT COD_SUCUR AS CODIGO, NOMBRE"
            SQL &= Chr(13) & "	FROM SUCURSAL"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND COD_SUCUR <> " & SCM(COD_SUCUR)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Row In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("CODIGO").ToString.ToUpper & " - " & Row("NOMBRE").ToString.ToUpper))
                Next

                CMB_SUCURSAL.ValueMember = "Key"
                CMB_SUCURSAL.DisplayMember = "Value"
                CMB_SUCURSAL.DataSource = LISTA_REF
                CMB_SUCURSAL.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            Dim Sql = "INSERT INTO DOCUMENTO_GUIA_UBICACION(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,NUMERO_GUIA,COD_UBICACION,COD_USUARIO,FECHA_INC)"
            Sql &= Chr(13) & "SELECT " & SCM(COD_CIA) & "," & SCM(Cod_SUCUR_DERECHO) & "," & Val(Numero_Doc) & "," & SCM(Tipo_Mov) & "," & SCM(Guia)
            Sql &= Chr(13) & "," & SCM(CMB_ORIGEN.SelectedItem().ToString.Substring(1, 3)) & "," & SCM(COD_USUARIO) & ", GETDATE()"
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            Sql = "	UPDATE DOCUMENTO_GUIA	"
            Sql &= Chr(13) & "	SET ESTADO = " & SCM(Estado_Actualizar)
            Sql &= Chr(13) & "	, COD_DERECHO = " & SCM(IIf(Estado_Actualizar = "T", SCM(CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3)), COD_SUCUR))
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(Cod_SUCUR_DERECHO)
            Sql &= Chr(13) & "	AND NUMERO_DOC = " & Val(Numero_Doc)
            Sql &= Chr(13) & "	AND TIPO_MOV = " & SCM(Tipo_Mov)
            Sql &= Chr(13) & "	AND NUMERO_GUIA = " & SCM(Guia)

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