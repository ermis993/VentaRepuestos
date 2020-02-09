Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Proveedor
    Dim CEDULA_PROVEEDOR As String
    Dim MODO As CRF_Modos
    Dim BS As New Buscador
    Dim CONSULTA_FILTRO As String = ""

    Sub New(Optional ByVal MODO As CRF_Modos = CRF_Modos.Nada, Optional ByVal Bus As Buscador = Nothing)
        InitializeComponent()
        FORMATO_GRID()
        Me.MODO = MODO
        Me.BS = Bus
    End Sub
    Private Sub Proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rellenar_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 8
        GRID.Columns(0).HeaderText = "Sucursal"
        GRID.Columns(0).Name = "COD_SUCUR"
        GRID.Columns(1).HeaderText = "Cédula"
        GRID.Columns(1).Name = "CEDULA"
        GRID.Columns(2).HeaderText = "Tipo cédula"
        GRID.Columns(2).Name = "CASE WHEN TIPO_CEDULA ='F' THEN 'Física' WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END"
        GRID.Columns(3).HeaderText = "Nombre"
        GRID.Columns(3).Name = "NOMBRE"
        GRID.Columns(4).HeaderText = "Dirección"
        GRID.Columns(4).Name = "DIRECCION"
        GRID.Columns(5).HeaderText = "Teléfono"
        GRID.Columns(5).Name = "TELEFONO"
        GRID.Columns(6).HeaderText = "Correo"
        GRID.Columns(6).Name = "CORREO"
        GRID.Columns(7).HeaderText = "Estado"
        GRID.Columns(7).Name = "CASE WHEN ESTADO ='A' THEN 'Activo' ELSE 'Inactivo' END"
        Filtro.FILTRO_CARGAR_COMBO(GRID)
    End Sub

    Private Sub Rellenar_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL = "	SELECT COD_SUCUR As Sucursal,CEDULA As Cédula,"
                SQL &= Chr(13) & "	CASE WHEN TIPO_CEDULA ='F' THEN 'Física' "
                SQL &= Chr(13) & "	WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END AS 'Tipo cédula',"
                SQL &= Chr(13) & "	NOMBRE As Nombre,DIRECCION As Dirección,TELEFONO as Teléfono,CORREO as Correo,"
                SQL &= Chr(13) & "	CASE WHEN ESTADO ='A' THEN 'Activo' ELSE 'Inactivo' END AS Estado, CONVERT(VARCHAR(10), FECHA_INC, 105) AS 'Fecha ingreso' "
                SQL &= Chr(13) & "	FROM PROVEEDOR"
                SQL &= Chr(13) & "	WHERE COD_SUCUR = " & SCM(COD_SUCUR)
                SQL &= Chr(13) & "  AND COD_CIA = " & SCM(COD_CIA)

                If RB_ACTIVOS.Checked = True Then
                    SQL &= Chr(13) & " And Estado ='A'"
                ElseIf RB_INACTIVOS.Checked = True Then
                    SQL &= Chr(13) & "	AND ESTADO ='I'"
                End If

                SQL &= Chr(13) & CONSULTA_FILTRO

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("Sucursal"), ITEM("Cédula"), ITEM("Tipo cédula"), ITEM("Nombre"), ITEM("Dirección"), ITEM("Teléfono"), ITEM("Correo"), ITEM("Estado"), ITEM("Fecha ingreso")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Refrescar()
        CONSULTA_FILTRO = ""
        Rellenar_GRID()
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                CEDULA_PROVEEDOR = seleccionado.Cells(1).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#Region "MODIFICAR"
    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Modificar()
    End Sub
    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Modificar()
    End Sub
    Private Sub Modificar()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
                If MODO = CRF_Modos.Seleccionar Then
                    SETEO_CONTROL(BS, Me, CEDULA_PROVEEDOR)
                Else
                    Dim PANTALLA As New ProveedorMant(CRF_Modos.Modificar, Me, CEDULA_PROVEEDOR)
                    PANTALLA.ShowDialog()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Dim PANTALLA As New ProveedorMant(CRF_Modos.Insertar, Me)
        PANTALLA.ShowDialog()
    End Sub

    Private Sub RB_ACTIVOS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVOS.CheckedChanged, RB_INACTIVOS.CheckedChanged, RB_TODOS.CheckedChanged
        REFRESCAR()
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        REFRESCAR()
    End Sub

    Private Sub FILTRAR(sender As Object, e As EventArgs) Handles Filtro.Filtrar_Click
        If Filtro.VALOR <> "" Then
            CONSULTA_FILTRO = Filtro.FILTRAR()
            Rellenar_GRID()
        End If
    End Sub

#End Region
End Class