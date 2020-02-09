Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Compania
    Dim COD_CIA As String = ""
    Dim CONSULTA_FILTRO As String = ""
    Private Sub Compania_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rellenar_GRID()
    End Sub
    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 8
        GRID.Columns(0).HeaderText = "Código"
        GRID.Columns(0).Name = "COD_CIA"
        GRID.Columns(1).HeaderText = "Nombre"
        GRID.Columns(1).Name = "NOMBRE"
        GRID.Columns(2).HeaderText = "Tipo cédula"
        GRID.Columns(2).Name = "CASE WHEN TIPO_CEDULA ='F' THEN 'Física' WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END "
        GRID.Columns(3).HeaderText = "Cédula"
        GRID.Columns(3).Name = "CEDULA"
        GRID.Columns(4).HeaderText = "Correo"
        GRID.Columns(4).Name = "CORREO"
        GRID.Columns(5).HeaderText = "Provincia"
        GRID.Columns(5).Name = "PROVINCIA"
        GRID.Columns(6).HeaderText = "Cantón"
        GRID.Columns(6).Name = "CANTON"
        GRID.Columns(7).HeaderText = "Distrito"
        GRID.Columns(7).Name = "DISTRITO"
        FILTRO.FILTRO_CARGAR_COMBO(GRID)
    End Sub
    Private Sub Rellenar_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing

                Dim SQL As String = ""
                SQL = "	SELECT COD_CIA,NOMBRE,"
                SQL &= Chr(13) & "	CASE WHEN TIPO_CEDULA ='F' THEN 'Física' "
                SQL &= Chr(13) & "	WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END AS TIPO_CEDULA,"
                SQL &= Chr(13) & "	CEDULA,CORREO,PROVINCIA,CANTON,DISTRITO"
                SQL &= Chr(13) & "	FROM COMPANIA"
                If RB_ACTIVAS.Checked = True Then
                    SQL &= Chr(13) & "	WHERE ESTADO ='A'"
                ElseIf RB_INACTIVAS.Checked = True Then
                    SQL &= Chr(13) & "	WHERE ESTADO ='I'"
                End If
                SQL &= Chr(13) & CONSULTA_FILTRO

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("COD_CIA"), ITEM("NOMBRE"), ITEM("TIPO_CEDULA"), ITEM("CEDULA"), ITEM("CORREO"), ITEM("PROVINCIA"), ITEM("CANTON"), ITEM("DISTRITO")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            Dim PANTALLA As New LBL_CANTON(CRF_Modos.Insertar, Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Modificar()
    End Sub
    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                COD_CIA = seleccionado.Cells(0).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Refrescar()
        CONSULTA_FILTRO = ""
        Rellenar_GRID()
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        Refrescar()
    End Sub
    Private Sub Modificar()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
                Dim PANTALLA As New LBL_CANTON(CRF_Modos.Modificar, Me, COD_CIA)
                PANTALLA.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Modificar()
    End Sub
    Private Sub RB_ACTIVAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVAS.CheckedChanged, RB_INACTIVAS.CheckedChanged, RB_TODAS.CheckedChanged
        Refrescar()
    End Sub
    Private Sub BTN_DERECHO_Click(sender As Object, e As EventArgs) Handles BTN_DERECHO.Click
        Try
            Leer_indice()
            If String.IsNullOrEmpty(COD_CIA) = False Then
                Dim Derechos As New DerechosCompania(COD_CIA)
                Derechos.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar la compañía")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FILTRAR(sender As Object, e As EventArgs) Handles FILTRO.Filtrar_Click
        If FILTRO.VALOR <> "" Then
            CONSULTA_FILTRO = FILTRO.FILTRAR()
            Rellenar_GRID()
        End If
    End Sub
    Sub New()
        InitializeComponent()
        FORMATO_GRID()
    End Sub
End Class