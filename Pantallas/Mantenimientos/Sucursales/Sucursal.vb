Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Sucursal

    Dim COD_SUCUR As String
    Dim PADRE As MenuPrincipal
    Dim CONSULTA_FILTRO As String = ""

    Private Sub Sucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rellenar_Grid()
    End Sub

    Sub New(ByVal PADRE As MenuPrincipal)
        InitializeComponent()
        FORMATO_GRID()
        Me.PADRE = PADRE
    End Sub

    Public Sub Refrescar()
        CONSULTA_FILTRO = ""
        Rellenar_Grid()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 6
        GRID.Columns(0).HeaderText = "Código"
        GRID.Columns(0).Name = "COD_SUCUR"
        GRID.Columns(1).HeaderText = "Nombre"
        GRID.Columns(1).Name = "NOMBRE"
        GRID.Columns(2).HeaderText = "Dirección"
        GRID.Columns(2).Name = "DIRECCION"
        GRID.Columns(3).HeaderText = "Teléfono"
        GRID.Columns(3).Name = "TELEFONO"
        GRID.Columns(4).HeaderText = "Correo"
        GRID.Columns(4).Name = "CORREO"
        GRID.Columns(5).HeaderText = "Estado"
        GRID.Columns(5).Name = "CASE WHEN ESTADO = 'I' THEN 'Inactiva' ELSE 'Activa' END"
        Filtro.FILTRO_CARGAR_COMBO(GRID)
    End Sub

    Private Sub Rellenar_Grid()
        Try
            If GRID.Columns.Count > 0 Then

                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim Estado As String

                If RB_ACTIVAS.Checked Then
                    Estado = "A"
                ElseIf RB_INACTIVAS.Checked Then
                    Estado = "I"
                Else
                    Estado = "T"
                End If

                Dim Sql = "	SELECT COD_SUCUR AS Código, NOMBRE AS Nombre, DIRECCION as Dirección, TELEFONO as Teléfono, CORREO as Correo, CASE WHEN ESTADO = 'I' THEN 'Inactiva' ELSE 'Activa' END AS Estado"
                Sql &= Chr(13) & "	FROM SUCURSAL"
                Sql &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                Sql &= Chr(13) & " And (Estado = " & SCM(Estado) & " Or 'T' = " & SCM(Estado) & ")"
                Sql &= Chr(13) & CONSULTA_FILTRO

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(Sql)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("Código"), ITEM("Nombre"), ITEM("Dirección"), ITEM("Teléfono"), ITEM("Correo"), ITEM("Estado")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If

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
            Refrescar()
        End If
    End Sub
    Private Sub RB_INACTIVAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_INACTIVAS.CheckedChanged
        If RB_INACTIVAS.Checked Then
            Refrescar()
        End If
    End Sub
    Private Sub RB_TODAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_TODAS.CheckedChanged
        If RB_TODAS.Checked Then
            Refrescar()
        End If
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        Refrescar()
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

    Private Sub FILTRAR(sender As Object, e As EventArgs) Handles Filtro.Filtrar_Click
        If Filtro.VALOR <> "" Then
            CONSULTA_FILTRO = Filtro.FILTRAR()
            Rellenar_GRID()
        End If
    End Sub

    Private Sub BTN_DERECHO_Click(sender As Object, e As EventArgs) Handles BTN_DERECHO.Click
        Try
            ItemSeleccionado()
            Dim PANTALLA As New DerechosSucursal(COD_SUCUR)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class