Imports System.IO
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class RespuestaDGTD
    Dim NumeroDocumento As Integer
    Dim TipoDocumento As String
    Sub New(ByVal numero_doc As Integer, ByVal tipo_Doc As String)
        InitializeComponent()
        NumeroDocumento = numero_doc
        TipoDocumento = tipo_Doc
    End Sub
    Private Sub RespuestaDGTD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenaDatosDGTD()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub RellenaDatosDGTD()
        Try
            Dim SQL = "	SELECT SUBSTRING(XML_RESPUESTA, CHARINDEX('<DetalleMensaje>', XML_RESPUESTA) + 16, CHARINDEX('</DetalleMensaje>', XML_RESPUESTA) - (CHARINDEX('<DetalleMensaje>', XML_RESPUESTA) + 16)) AS RECHAZO	"
            SQL &= Chr(13) & "	, CONSECUTIVO, CLAVE	"
            SQL &= Chr(13) & "	FROM DOCUMENTO_ELECTRONICO	"
            SQL &= Chr(13) & "	WHERE RESPUESTA_DGTD = 'R'	"
            SQL &= Chr(13) & "	AND COD_CIA = 	" & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	AND NUMERO_DOC = " & Val(NumeroDocumento)
            SQL &= Chr(13) & " AND TIPO_MOV = " & SCM(TipoDocumento)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    TXT_DOCUMENTO.Text = Val(NumeroDocumento)
                    TXT_CONSECUTIVO.Text = ITEM("CONSECUTIVO")
                    TXT_CLAVE.Text = ITEM("CLAVE")
                    TXT_RECHAZO.Text = ITEM("RECHAZO")
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_DESCARGAR_XML_Click(sender As Object, e As EventArgs) Handles BTN_DESCARGAR_XML.Click
        Try
            Dim SQL = "	SELECT XML, CONSECUTIVO	"
            SQL &= Chr(13) & "	FROM DOCUMENTO_ELECTRONICO	"
            SQL &= Chr(13) & "	WHERE RESPUESTA_DGTD = 'R'	"
            SQL &= Chr(13) & "	AND COD_CIA = 	" & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & "	AND NUMERO_DOC = " & Val(NumeroDocumento)
            SQL &= Chr(13) & " AND TIPO_MOV = " & SCM(TipoDocumento)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

                For Each ITEM In DS.Tables(0).Rows
                    Dim Ruta As New SaveFileDialog With {
                    .FileName = "Documento_" + ITEM("CONSECUTIVO"),
                    .Filter = "XML |*.xml"
                    }

                    If Ruta.ShowDialog() = DialogResult.OK Then
                        File.WriteAllText(Ruta.FileName, ITEM("XML"))
                        MessageBox.Show(Me, "Xml descargado correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class