Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Ruta
    Dim CODIGO As String = ""
    Dim BS As New Buscador
    Dim MODO As CRF_Modos
    Dim CONSULTA_FILTRO As String = ""

    Sub New(Optional ByVal MODO As CRF_Modos = CRF_Modos.Nada, Optional ByVal Bus As Buscador = Nothing)
        InitializeComponent()
        FORMATO_GRID()
        Me.MODO = MODO
        Me.BS = Bus
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 4
        GRID.Columns(0).HeaderText = "Código"
        GRID.Columns(0).Name = "COD_UBICACION"
        GRID.Columns(1).HeaderText = "Descripción"
        GRID.Columns(1).Name = "DESC_UBICACION"
        GRID.Columns(2).HeaderText = "Estado"
        GRID.Columns(2).Name = "ESTADO"
        GRID.Columns(3).HeaderText = "Tipo"
        GRID.Columns(3).Name = "IND_TIPO"
        Filtro.FILTRO_CARGAR_COMBO(GRID)
    End Sub

    Private Sub Ruta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RELLENAR_GRID()
    End Sub

    Private Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL = "	SELECT COD_UBICACION As Código,DESC_UBICACION As Descripción, ESTADO AS Estado, CASE WHEN IND_TIPO = 'P' THEN 'Rutas iniciales' ELSE 'Rutas intermedias' END AS Tipo"
                SQL &= Chr(13) & "	FROM GUIA_UBICACION"
                If RB_ACTIVOS.Checked = True Then
                    SQL &= Chr(13) & "	WHERE ESTADO ='A'"
                ElseIf RB_INACTIVOS.Checked = True Then
                    SQL &= Chr(13) & "	WHERE ESTADO ='I'"
                End If
                'SQL &= Chr(13) & "AND IND_TIPO = 'P'"
                SQL &= Chr(13) & CONSULTA_FILTRO

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("Código"), ITEM("Descripción"), ITEM("Estado"), ITEM("Tipo")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        REFRESCAR()
    End Sub

    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Modificar()
    End Sub

    Private Sub Modificar()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
                If MODO = CRF_Modos.Seleccionar Then
                    SETEO_CONTROL(BS, Me, CODIGO)
                Else
                    Dim PANTALLA As New RutaMant(CRF_Modos.Modificar, Me, CODIGO)
                    PANTALLA.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                CODIGO = seleccionado.Cells(0).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Modificar()
    End Sub

    Private Sub FILTRAR(sender As Object, e As EventArgs) Handles Filtro.Filtrar_Click
        If Filtro.VALOR <> "" Then
            CONSULTA_FILTRO = Filtro.FILTRAR()
            RELLENAR_GRID()
        End If
    End Sub

    Public Sub REFRESCAR()
        CONSULTA_FILTRO = ""
        RELLENAR_GRID()
    End Sub

    Private Sub RB_ACTIVOS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVOS.CheckedChanged, RB_INACTIVOS.CheckedChanged, RB_TODOS.CheckedChanged
        REFRESCAR()
    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Dim PANTALLA As New RutaMant(CRF_Modos.Insertar, Me)
        PANTALLA.ShowDialog()
    End Sub

End Class