Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class DerechosUsuarioMant
    Dim PADRE As New DerechosUsuario
    Dim Estado As String

    Dim CODIGO As String
    Dim DESCRIPCION As String

    Sub New(ByVal PADRE As DerechosUsuario)
        InitializeComponent()
        Me.PADRE = PADRE
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If RB_ACTIVA.Checked Then
                Estado = "A"
            Else
                Estado = "I"
            End If

            Dim SQL As String = "EXEC USP_DERECHO_MANTENIMIENTO"
            SQL &= Chr(13) & "@COD_DERECHO = " & SCM(TXT_COD_DERECHO.Text)
            SQL &= Chr(13) & ",@DESCRIPCION = " & SCM(TXT_DESCRIPCION.Text)
            SQL &= Chr(13) & ",@ESTADO = " & SCM(Estado)
            SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Insertar)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            Limpiar()
            Rellenar_Grid()
            MessageBox.Show("Derecho procesado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DerechosUsuarioMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FORMATO_GRID()
        Rellenar_Grid()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 3
        GRID.Columns(0).HeaderText = "Código"
        GRID.Columns(0).Name = "COD_DERECHO"
        GRID.Columns(1).HeaderText = "Descripcion"
        GRID.Columns(1).Name = "DESCRIPCION"
        GRID.Columns(2).HeaderText = "Estado"
        GRID.Columns(2).Name = "ESTADO"
    End Sub

    Private Sub Rellenar_Grid()
        Try
            If GRID.Columns.Count > 0 Then

                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim Sql = "	SELECT COD_DERECHO, DESCRIPCION, CASE WHEN ESTADO = 'I' THEN 'Inactivo' ELSE 'Activo' END AS ESTADO"
                Sql &= Chr(13) & "	FROM SEGU_DERECHO"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("COD_DERECHO"), ITEM("DESCRIPCION"), ITEM("ESTADO")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub Cerrar()
        Try
            PADRE.Cargar_Derechos()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Limpiar()
        TXT_COD_DERECHO.Text = ""
        TXT_DESCRIPCION.Text = ""
    End Sub

    Private Sub ItemSeleccionado()
        Try
            Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
            TXT_COD_DERECHO.Text = seleccionado.Cells(0).Value.ToString
            TXT_DESCRIPCION.Text = seleccionado.Cells(1).Value.ToString

            If seleccionado.Cells(2).Value.ToString = "Activo" Then
                RB_ACTIVA.Checked = True
            Else
                RB_INACTIVA.Checked = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        ItemSeleccionado()
    End Sub
End Class