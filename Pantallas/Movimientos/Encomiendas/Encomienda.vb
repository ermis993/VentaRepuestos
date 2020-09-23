Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Encomienda
    Dim GUIA As String = ""
    Dim ESTADO As String = ""
    Dim TIPO_MOV As String = ""
    Dim NUMERO_DOC As Integer = 0

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Sub New()
        InitializeComponent()
        FORMATO_GRID()
    End Sub

    Private Sub BTN_UBICACION_Click(sender As Object, e As EventArgs) Handles BTN_UBICACION.Click
        Try
            Dim PANTALLA As New Ruta()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL As String = ""

                SQL = "	SELECT GUIA.NUMERO_DOC, NUMERO_GUIA, ISNULL(GUIA.RETIRA, '') AS RETIRA, "
                SQL &= Chr(13) & "	UBI_ORIGEN.DESC_UBICACION AS ORIGEN, UBI_DESTINO.DESC_UBICACION AS DESTINO, "
                SQL &= Chr(13) & "	CANT_BULTOS, CASE WHEN GUIA.ESTADO = 'P' THEN 'Pendiente' WHEN GUIA.ESTADO = 'T' THEN 'Transportando' WHEN GUIA.ESTADO = 'R' THEN 'Recibido' WHEN GUIA.ESTADO = 'E' THEN 'Entregada' END AS ESTADO,"
                SQL &= Chr(13) & "	CONVERT(VARCHAR(10), GUIA.FECHA_INC, 105) + ' ' + RIGHT(CONVERT(VARCHAR, GUIA.FECHA_INC, 100), 7) AS HORA, GUIA.TIPO_MOV"
                SQL &= Chr(13) & "	FROM DOCUMENTO_GUIA AS GUIA	"
                SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS UBI_ORIGEN	"
                SQL &= Chr(13) & "		ON UBI_ORIGEN.COD_CIA = GUIA.COD_CIA"
                SQL &= Chr(13) & "      AND UBI_ORIGEN.COD_UBICACION = GUIA.ORIGEN"
                SQL &= Chr(13) & "	INNER JOIN GUIA_UBICACION AS UBI_DESTINO	"
                SQL &= Chr(13) & "		ON UBI_DESTINO.COD_CIA = GUIA.COD_CIA"
                SQL &= Chr(13) & "      AND UBI_DESTINO.COD_UBICACION = GUIA.DESTINO"
                SQL &= Chr(13) & " WHERE GUIA.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & " AND GUIA.COD_DERECHO = " & SCM(COD_SUCUR)
                If CMB_FILTRO.SelectedIndex = 1 Then
                    SQL &= Chr(13) & "	AND GUIA.ESTADO ='P'"
                ElseIf CMB_FILTRO.SelectedIndex = 2 Then
                    SQL &= Chr(13) & "	AND GUIA.ESTADO ='T'"
                ElseIf CMB_FILTRO.SelectedIndex = 3 Then
                    SQL &= Chr(13) & "	AND GUIA.ESTADO ='R'"
                ElseIf CMB_FILTRO.SelectedIndex = 4 Then
                    SQL &= Chr(13) & "	AND GUIA.ESTADO ='E'"
                End If
                SQL &= Chr(13) & "	AND GUIA.ESTADO <> 'N'"
                SQL &= Chr(13) & " AND CONVERT(VARCHAR(10), GUIA.FECHA_INC, 111) BETWEEN " & SCM(YMD(DTPINICIO.Value)) & " AND " & SCM(YMD(DTPFINAL.Value))
                SQL &= Chr(13) & " ORDER BY NUMERO_GUIA ASC"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("NUMERO_DOC"), ITEM("NUMERO_GUIA"), ITEM("RETIRA"), ITEM("ORIGEN"), ITEM("DESTINO"), ITEM("CANT_BULTOS"), ITEM("ESTADO"), ITEM("HORA"), ITEM("TIPO_MOV")}
                        GRID.Rows.Add(row)
                    Next
                End If

                'If CMB_TIPO_FACT.SelectedIndex = 0 Then
                '    PintarEstados()
                'End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FORMATO_GRID()
        Try
            GRID.ColumnCount = 9
            GRID.Columns(0).HeaderText = "Documento"
            GRID.Columns(0).Name = "NUMERO_DOC"
            GRID.Columns(1).HeaderText = "Guia"
            GRID.Columns(1).Name = "NUMERO_GUIA"
            GRID.Columns(2).HeaderText = "Retira"
            GRID.Columns(2).Name = "CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2 AS RETIRA"
            GRID.Columns(3).HeaderText = "Origen"
            GRID.Columns(3).Name = "UBI_ORIGEN.DESC_UBICACION AS ORIGEN"
            GRID.Columns(4).HeaderText = "Destino"
            GRID.Columns(4).Name = "UBI_DESTINO.DESC_UBICACION AS DESTINO"
            GRID.Columns(5).HeaderText = "Bultos"
            GRID.Columns(5).Name = "CANT_BULTOS"
            GRID.Columns(6).HeaderText = "Estado"
            GRID.Columns(6).Name = "CASE WHEN GUIA.ESTADO = 'P' THEN 'Pendiente' WHEN GUIA.ESTADO = 'T' THEN 'Transportando' WHEN GUIA.ESTADO = 'R' THEN 'Recibido'  WHEN GUIA.ESTADO = 'E' THEN 'Entregado' END AS ESTADO"
            GRID.Columns(7).HeaderText = "Fecha"
            GRID.Columns(7).Name = "CONVERT(VARCHAR(10), GUIA.FECHA_INC, 105) + ' ' + RIGHT(CONVERT(VARCHAR, GUIA.FECHA_INC, 100), 7) AS HORA"
            GRID.Columns(8).HeaderText = "Tipo"
            GRID.Columns(8).Name = "GUIA.TIPO_MOV"
            GRID.Columns(8).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DTPINICIO_KeyDown(sender As Object, e As KeyEventArgs) Handles DTPINICIO.KeyDown
        If e.KeyCode = Keys.Enter Then
            Refrescar()
        End If
    End Sub

    Private Sub DTPFINAL_KeyDown(sender As Object, e As KeyEventArgs) Handles DTPFINAL.KeyDown
        If e.KeyCode = Keys.Enter Then
            Refrescar()
        End If
    End Sub

    Private Sub Encomienda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            BTN_UBICACION.Enabled = TieneDerecho("DINRUTA")

            DTPINICIO.Format = DateTimePickerFormat.Custom
            DTPINICIO.CustomFormat = "dd-MM-yyyy hh:mm:ss tt"

            DTPFINAL.Format = DateTimePickerFormat.Custom
            DTPFINAL.CustomFormat = "dd-MM-yyyy hh:mm:ss tt"

            CMB_FILTRO.SelectedIndex = 0
            Refrescar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        Try
            Refrescar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_FILTRO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_FILTRO.SelectedIndexChanged
        Try
            Refrescar()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                NUMERO_DOC = Val(seleccionado.Cells(0).Value.ToString)
                GUIA = seleccionado.Cells(1).Value.ToString
                ESTADO = seleccionado.Cells(6).Value.ToString.Substring(0, 1)
                TIPO_MOV = seleccionado.Cells(8).Value.ToString
            Else
                ESTADO = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Refrescar()
        RELLENAR_GRID()
    End Sub

    Private Sub BTN_RECEPCION_Click(sender As Object, e As EventArgs) Handles BTN_RECEPCION.Click
        Try
            Leer_indice()
            If ESTADO = "T" Then
                Dim PANTALLA As New EncomiendaMant(GUIA, "R", NUMERO_DOC, TIPO_MOV, Me, "Recibida")
                PANTALLA.ShowDialog()
            Else
                MessageBox.Show("La encomienda debe de estar en estado de 'Transportando' para poder recibirla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ENTREGAR_Click(sender As Object, e As EventArgs) Handles BTN_ENTREGAR.Click
        Try
            Leer_indice()
            If ESTADO = "R" Then
                Dim PANTALLA As New EncomiendaMant(GUIA, "E", NUMERO_DOC, TIPO_MOV, Me, "Entregada")
                PANTALLA.ShowDialog()
            Else
                MessageBox.Show("La encomienda debe de estar en estado de 'Recibido' para poder entregar al cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ENVIAR_Click(sender As Object, e As EventArgs) Handles BTN_ENVIAR.Click
        Try
            Leer_indice()
            If ESTADO = "P" Then
                Dim PANTALLA As New EncomiendaMant(GUIA, "T", NUMERO_DOC, TIPO_MOV, Me, "Transporte")
                PANTALLA.ShowDialog()
            Else
                MessageBox.Show("La encomienda debe de estar en estado de 'Pendiente' para poder transportarla", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles GRID.MouseDoubleClick
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
                Dim PANTALLA As New EncomiendaMant(GUIA, "X", NUMERO_DOC, TIPO_MOV, Me, "")
                PANTALLA.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_REPORTE_Click(sender As Object, e As EventArgs) Handles BTN_REPORTE.Click
        Try
            Dim PANTALLA As New EncomiendaReporte()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTN_TODO.Click
        Try
            Dim mensaje As String = "Este proceso enviará a transporte todas las encomiendas pendientes en el rango de fechas digitado" & vbNewLine
            mensaje = mensaje & " ¿Está seguro que desea hacerlo?" & vbNewLine
            mensaje = mensaje & " (Este es un proceso irreversible)"

            Dim valor = MessageBox.Show(Me, mensaje, Me.Text, vbYesNo, MessageBoxIcon.Question)
            If valor = DialogResult.Yes Then
                Leer_indice()
                Dim PANTALLA As New EncomiendaMantEspecial("T", DTPINICIO.Value, DTPFINAL.Value, Me)
                PANTALLA.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class