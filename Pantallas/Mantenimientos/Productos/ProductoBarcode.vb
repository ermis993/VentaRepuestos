Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Imports ZXing

Public Class ProductoBarcode
    Dim Barcode As String

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Public Sub Cerrar()
        Me.Close()
    End Sub

    Private Sub BTN_GENERAR_Click(sender As Object, e As EventArgs) Handles BTN_GENERAR.Click
        Try
            Barcode = Generar_Barcode()
            Dim mensaje As String = ""

            mensaje = "Se generará un código de barras único, el código a generar es: " & Barcode & vbNewLine
            mensaje &= "¿Está seguro de realizar este código?"

            Dim pregunta = MessageBox.Show(Me, mensaje, Me.Text, vbYesNo, MessageBoxIcon.Question)
            If pregunta = DialogResult.Yes Then
                Dim Writer As New BarcodeWriter
                Writer.Format = BarcodeFormat.CODE_128
                PB_BARCODE.Image = Writer.Write(Barcode)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function Generar_Barcode() As String
        Try
            Dim Codigo_Generado As String = ""

            Dim SQL = "	SELECT T1.CODIGO	"
            SQL &= Chr(13) & "  FROM (SELECT CONVERT(VARCHAR(10),CAST(RAND() * POWER(CAST(10 as BIGINT), 10) AS decimal(10, 0))) AS CODIGO) AS T1"
            SQL &= Chr(13) & "	WHERE T1.CODIGO NOT IN																						"
            SQL &= Chr(13) & "	  (SELECT COD_BARRA																						"
            SQL &= Chr(13) & "	   FROM   PRODUCTO																						"
            SQL &= Chr(13) & "	   WHERE  COD_CIA = " & SCM(COD_CIA) & ")																						"
            SQL &= Chr(13) & "	AND T1.CODIGO NOT IN																						"
            SQL &= Chr(13) & "	  (SELECT CODIGO_BARRAS																						"
            SQL &= Chr(13) & "	   FROM   COMPANIA_CODIGOS_BARRAS																						"
            SQL &= Chr(13) & "	   WHERE  COD_CIA = " & SCM(COD_CIA) & ")																					"
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    Codigo_Generado = ITEM("CODIGO")
                Next
            End If

            Return Codigo_Generado
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub BTN_RELACION_Click(sender As Object, e As EventArgs) Handles BTN_RELACION.Click
        Try
            If Not PB_BARCODE.Image Is Nothing Then
                Dim PANTALLA As New ProductoBarcodeRelacion(Barcode, PB_BARCODE.Image, Me)
                PANTALLA.ShowDialog()
            Else
                MessageBox.Show(Me, "Es necesario primero generar el código de barras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class