Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class ProductoEnlaze

    Dim PADRE As Object

    Sub New(ByVal Cod_hijo As String, ByVal Desc_hijo As String, ByVal PADRECITO As Object)
        InitializeComponent()
        TXT_COD_PROD_HIJO.Text = Cod_hijo
        TXT_DESC_PROD_HIJO.Text = Desc_hijo
        PADRE = PADRECITO
    End Sub

    Private Sub TXT_CODIGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_CODIGO.KeyDown
        If e.KeyCode = Keys.Enter Then
            Busca_Producto()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Busca_Producto()
        Try
            LVResultados.Clear()
            LVResultados.Columns.Add("", 370)

            If Not String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                Dim Sql = "	SELECT COD_PROD,  DESCRIPCION "
                Sql &= Chr(13) & "	FROM PRODUCTO	"
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	AND (DESCRIPCION LIKE " & SCM("%" + TXT_CODIGO.Text + "%") & " Or COD_PROD = " & SCM(TXT_CODIGO.Text) & " Or COD_BARRA = " & SCM(TXT_CODIGO.Text) & ")"
                Sql &= Chr(13) & "  ORDER BY DESCRIPCION ASC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim LVI As New ListViewItem With {
                            .Text = "(" & ITEM("COD_PROD") & ") " & ITEM("DESCRIPCION"),
                            .Name = ITEM("COD_PROD")
                        }
                        LVResultados.Items.Add(LVI)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LVResultados_DoubleClick(sender As Object, e As EventArgs) Handles LVResultados.DoubleClick
        Try
            Dim Codigo = LVResultados.SelectedItems(0).Name
            Dim Descripcion = LVResultados.SelectedItems(0).Text

            TXT_CODIGO.Text = Codigo
            LBL_PRODUCTO_SELECCIONADO.Text = Descripcion
            Busca_Producto()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                TXT_CODIGO.Select()
                MessageBox.Show(Me, "Es necesario buscar y seleccionar el producto padre", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                TXT_CODIGO.Select()
                MessageBox.Show(Me, "Es necesario buscar y seleccionar el producto padre", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Dim Mensaje As String
                Mensaje = "¿Está seguro en ligar el código: " & TXT_COD_PROD_HIJO.Text & vbNewLine
                Mensaje &= " con descripción: " & TXT_DESC_PROD_HIJO.Text & vbNewLine
                Mensaje &= " al código : " & TXT_CODIGO.Text & vbNewLine
                Mensaje &= " con descripción: " & LBL_PRODUCTO_SELECCIONADO.Text & "?"

                Dim valor = MessageBox.Show(Me, Mensaje, "Aviso", vbYesNo, MessageBoxIcon.Question)
                If valor = DialogResult.Yes Then

                    Dim Sql = "EXEC	USP_PRODUCTO_RELACION "
                    Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
                    Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
                    Sql &= Chr(13) & "	,@COD_PROD = " & SCM(TXT_CODIGO.Text)
                    Sql &= Chr(13) & "	,@COD_PROD_HIJO = " & SCM(TXT_COD_PROD_HIJO.Text)

                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(Sql)
                    CONX.Coneccion_Cerrar()

                    MessageBox.Show("¡Producto enlazado correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.PADRE.RELLENAR_GRID()
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class