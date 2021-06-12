Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ProductoBarcodeRelacion

    Dim Cod_Barra As String
    Dim ImagenBC As Image
    Dim PADRE As Object

    Sub New(ByVal codigo_barra As String, ByVal PB As Image, ByVal PADRECITO As Object)
        InitializeComponent()
        Cod_Barra = codigo_barra
        ImagenBC = PB
        PADRE = PADRECITO
    End Sub

    Private Sub LVResultados_DoubleClick(sender As Object, e As EventArgs) Handles LVResultados.DoubleClick
        Try
            Dim Codigo = LVResultados.SelectedItems(0).Name
            Dim Descripcion = LVResultados.SelectedItems(0).Text

            TXT_CODIGO.Text = Codigo
            LBL_PRODUCTO_SELECCIONADO.Text = Descripcion
            Busca_Producto()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Busca_Producto()
        Try
            LVResultados.Clear()
            LVResultados.Columns.Add("", 370)

            If Not String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                Dim Sql = "	SELECT COD_PROD,  DESCRIPCION "
                Sql &= Chr(13) & "	FROM PRODUCTO AS PROD	"
                Sql &= Chr(13) & "  LEFT JOIN PRODUCTO_RELACION AS REL"
                Sql &= Chr(13) & " 	    ON REL.COD_CIA = PROD.COD_CIA"
                Sql &= Chr(13) & " 	    AND REL.COD_SUCUR = PROD.COD_SUCUR"
                Sql &= Chr(13) & " 	    AND REL.COD_PROD_PADRE = PROD.COD_PROD"
                Sql &= Chr(13) & "	WHERE PROD.COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND PROD.COD_SUCUR = " & SCM(COD_SUCUR)
                Sql &= Chr(13) & "	AND (DESCRIPCION LIKE " & SCM("%" + TXT_CODIGO.Text + "%") & " Or COD_PROD = " & SCM(TXT_CODIGO.Text) & " Or COD_BARRA = " & SCM(TXT_CODIGO.Text) & " Or REL.COD_PROD_HIJO = " & SCM(TXT_CODIGO.Text) & ")"
                Sql &= Chr(13) & "	AND PROD.ESTADO = 'A'"
                Sql &= Chr(13) & "	AND ISNULL(PROD.COD_BARRA, '') = ''"
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

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If Not String.IsNullOrEmpty(LBL_PRODUCTO_SELECCIONADO.Text) Then
                Dim mensaje As String = ""

                mensaje = "Se va a relacionar el Barcode: " & Cod_Barra & vbNewLine
                mensaje &= "al producto: " & LBL_PRODUCTO_SELECCIONADO.Text & vbNewLine
                mensaje &= "¿Está seguro de realizar este proceso?"

                Dim pregunta = MessageBox.Show(Me, mensaje, Me.Text, vbYesNo, MessageBoxIcon.Question)
                If pregunta = DialogResult.Yes Then

                    Dim MS As New MemoryStream
                    ImagenBC.Save(MS, ImageFormat.Png)

                    Dim COMANDO As New SqlCommand()
                    COMANDO.CommandType = CommandType.Text
                    Dim FOTO As New SqlParameter("@FOTO", SqlDbType.Image)
                    FOTO.Value = MS.ToArray()
                    Dim CODIGO_BARRA As New SqlParameter("@CODIGO", SqlDbType.VarChar)
                    CODIGO_BARRA.Value = Cod_Barra
                    Dim COMPANIA As New SqlParameter("@COD_CIA", SqlDbType.VarChar)
                    COMPANIA.Value = COD_CIA
                    Dim SUCURSAL As New SqlParameter("@COD_SUCUR", SqlDbType.VarChar)
                    SUCURSAL.Value = COD_SUCUR
                    Dim PRODUCTO As New SqlParameter("@COD_PROD", SqlDbType.VarChar)
                    PRODUCTO.Value = TXT_CODIGO.Text

                    COMANDO.CommandText = "UPDATE PRODUCTO SET IMG_BARRA = @FOTO, COD_BARRA = @CODIGO WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND COD_PROD = @COD_PROD"
                    COMANDO.Parameters.Add(FOTO)
                    COMANDO.Parameters.Add(CODIGO_BARRA)
                    COMANDO.Parameters.Add(COMPANIA)
                    COMANDO.Parameters.Add(SUCURSAL)
                    COMANDO.Parameters.Add(PRODUCTO)

                    CONX.Coneccion_Abrir()
                    COMANDO.Connection = CONX.Connection
                    Dim AR = COMANDO.ExecuteReader()
                    AR.Close()
                    CONX.Coneccion_Cerrar()

                    MessageBox.Show("¡Se relacionó el Barcode al producto correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.PADRE.Cerrar()
                    Me.Close()
                End If
            Else
                MessageBox.Show(Me, "Se debe de buscar y seleccionar el producto a relacionar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CODIGO.Select()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TXT_CODIGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_CODIGO.KeyDown
        If e.KeyCode = Keys.Enter Then
            Busca_Producto()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
End Class