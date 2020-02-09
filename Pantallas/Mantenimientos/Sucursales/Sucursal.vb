﻿Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Sucursal

    Dim COD_SUCUR As String
    Dim PADRE As MenuPrincipal

    Private Sub Sucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RellenaSucursales()
    End Sub

    Sub New(ByVal PADRE As MenuPrincipal)
        InitializeComponent()
        Me.PADRE = PADRE
    End Sub

    Public Sub Refrescar()
        RellenaSucursales()
    End Sub
    Private Sub RellenaSucursales()
        Try
            Dim Estado As String

            If RB_ACTIVAS.Checked Then
                Estado = "A"
            ElseIf RB_INACTIVAS.Checked Then
                Estado = "I"
            Else
                Estado = "T"
            End If

            Dim Sql = "	SELECT COD_SUCUR AS Codigo, NOMBRE AS Nombre, DIRECCION as Direccion, TELEFONO as Telefono, CORREO as Correo, CASE WHEN ESTADO = 'I' THEN 'Inactiva' ELSE 'Activa' END AS Estado"
            Sql &= Chr(13) & "	FROM SUCURSAL"
            Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & " And (Estado = " & SCM(Estado) & " Or 'T' = " & SCM(Estado) & ")"
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            Dim Tabla As DataTable = DS.Tables(0)
            GRID.DataSource = Tabla
            GRID.AutoResizeColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
            PADRE.ActualizaSucursales()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RB_ACTIVAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVAS.CheckedChanged
        If RB_ACTIVAS.Checked Then
            RellenaSucursales()
        End If
    End Sub
    Private Sub RB_INACTIVAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_INACTIVAS.CheckedChanged
        If RB_INACTIVAS.Checked Then
            RellenaSucursales()
        End If
    End Sub
    Private Sub RB_TODAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_TODAS.CheckedChanged
        If RB_TODAS.Checked Then
            RellenaSucursales()
        End If
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        RellenaSucursales()
    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            Dim PANTALLA As New SucursalMant(CRF_Modos.Insertar, Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        MODIFICAR()
    End Sub
    Private Sub ItemSeleccionado()
        Try
            Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
            COD_SUCUR = seleccionado.Cells(0).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        MODIFICAR()
    End Sub
    Private Sub MODIFICAR()
        Try
            ItemSeleccionado()
            If COD_SUCUR = "" Then
                MessageBox.Show("Debe seleccionar la sucursal a modificar")
            Else
                Dim PANTALLA As New SucursalMant(CRF_Modos.Modificar, Me, COD_SUCUR)
                PANTALLA.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class