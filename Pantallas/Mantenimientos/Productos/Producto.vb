﻿Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Producto

    Dim COD_PROD As String
    Dim MODO As CRF_Modos
    Dim BS As New Buscador
    Dim CONSULTA_FILTRO As String = ""

    Sub New(Optional ByVal MODO As CRF_Modos = CRF_Modos.Nada, Optional ByVal Bus As Buscador = Nothing)
        InitializeComponent()
        FORMATO_GRID()
        Me.MODO = MODO
        Me.BS = Bus
    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            Dim Pantalla As New ProductoMant(CRF_Modos.Insertar, Me)
            Pantalla.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 10
        GRID.Columns(0).HeaderText = "Código"
        GRID.Columns(0).Name = "COD_PROD"
        GRID.Columns(1).HeaderText = "Descripción"
        GRID.Columns(1).Name = "DESCRIPCION"
        GRID.Columns(2).HeaderText = "Costo"
        GRID.Columns(2).Name = "COSTO"
        GRID.Columns(3).HeaderText = "Precio"
        GRID.Columns(3).Name = "PRECIO"
        GRID.Columns(4).HeaderText = "Exento"
        GRID.Columns(4).Name = "EXENTO"
        GRID.Columns(5).HeaderText = "Estado"
        GRID.Columns(5).Name = "ESTADO"
        GRID.Columns(6).HeaderText = "Estante"
        GRID.Columns(6).Name = "ESTANTE"
        GRID.Columns(7).HeaderText = "Fila"
        GRID.Columns(7).Name = "FILA"
        GRID.Columns(8).HeaderText = "Columna"
        GRID.Columns(8).Name = "COLUMNA"
        GRID.Columns(9).HeaderText = "Mínimo"
        GRID.Columns(9).Name = "MINIMO"
        Filtro.FILTRO_CARGAR_COMBO(GRID)
    End Sub

    Public Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim Sql = "	SELECT COD_PROD AS Código, DESCRIPCION AS Descripción, COSTO AS Costo, PRECIO AS Precio, EXENTO AS Exento "
                Sql &= Chr(13) & "	,ESTADO AS Estado, ESTANTE AS Estante, FILA AS Fila, COLUMNA as Columna, MINIMO as Mínimo	"
                Sql &= Chr(13) & "	FROM PRODUCTO	"
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & "	AND COD_SUCUR = " & SCM(COD_SUCUR)
                If RB_ACTIVOS.Checked = True Then
                    Sql &= Chr(13) & "	AND ESTADO ='A'"
                ElseIf RB_INACTIVOS.Checked = True Then
                    Sql &= Chr(13) & "	AND ESTADO ='I'"
                End If
                Sql &= Chr(13) & CONSULTA_FILTRO

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("Código"), ITEM("Descripción"), ITEM("Costo"), ITEM("Precio"), ITEM("Exento"), ITEM("Estado"), ITEM("Estante"), ITEM("Fila"), ITEM("Columna"), ITEM("Mínimo")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        Refrescar()
    End Sub

    Private Sub Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Refrescar()
    End Sub

    Public Sub Refrescar()
        CONSULTA_FILTRO = ""
        RELLENAR_GRID()
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                COD_PROD = seleccionado.Cells(0).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Modificar()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
                If MODO = CRF_Modos.Seleccionar Then
                    SETEO_CONTROL(BS, Me, COD_PROD)
                Else
                    Dim PANTALLA As New ProductoMant(CRF_Modos.Modificar, Me, COD_PROD)
                    PANTALLA.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RB_ACTIVOS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVOS.CheckedChanged, RB_INACTIVOS.CheckedChanged, RB_TODOS.CheckedChanged
        Refrescar()
    End Sub

    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Modificar()
    End Sub

    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Modificar()
    End Sub

    Private Sub FILTRAR(sender As Object, e As EventArgs) Handles Filtro.Filtrar_Click
        If Filtro.VALOR <> "" Then
            CONSULTA_FILTRO = Filtro.FILTRAR()
            RELLENAR_GRID()
        End If
    End Sub

End Class