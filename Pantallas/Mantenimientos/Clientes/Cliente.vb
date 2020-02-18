Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Cliente
    Dim CEDULA_CLIENTE As String = ""
    Dim BS As New Buscador
    Dim MODO As CRF_Modos
    Dim CONSULTA_FILTRO As String = ""
    Sub New(Optional ByVal MODO As CRF_Modos = CRF_Modos.Nada, Optional ByVal Bus As Buscador = Nothing)
        InitializeComponent()
        FORMATO_GRID()
        Me.MODO = MODO
        Me.BS = Bus
    End Sub
    Private Sub Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RELLENAR_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 11
        GRID.Columns(0).HeaderText = "Código"
        GRID.Columns(0).Name = "COD_CIA"
        GRID.Columns(1).HeaderText = "Cédula"
        GRID.Columns(1).Name = "CEDULA"
        GRID.Columns(2).HeaderText = "Tipo cédula"
        GRID.Columns(2).Name = "CASE WHEN TIPO_CEDULA ='F' THEN 'Física' WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END"
        GRID.Columns(3).HeaderText = "Nombre"
        GRID.Columns(3).Name = "NOMBRE"
        GRID.Columns(4).HeaderText = "Primer apellido"
        GRID.Columns(4).Name = "APELLIDO1"
        GRID.Columns(5).HeaderText = "Segundo apellido"
        GRID.Columns(5).Name = "APELLIDO2"
        GRID.Columns(6).HeaderText = "Teléfono"
        GRID.Columns(6).Name = "TELEFONO"
        GRID.Columns(7).HeaderText = "Correo"
        GRID.Columns(7).Name = "CORREO"
        GRID.Columns(8).HeaderText = "Saldo"
        GRID.Columns(8).Name = "SALDO"
        GRID.Columns(9).HeaderText = "Estado"
        GRID.Columns(9).Name = "ESTADO"
        GRID.Columns(10).HeaderText = "Fecha ingreso"
        GRID.Columns(10).Name = "CONVERT(VARCHAR(10), FECHA_INC, 105)"
        Filtro.FILTRO_CARGAR_COMBO(GRID)
    End Sub

    Private Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL = "	SELECT COD_CIA As Código,CEDULA As Cédula,"
                SQL &= Chr(13) & "	CASE WHEN TIPO_CEDULA ='F' THEN 'Física' "
                SQL &= Chr(13) & "	WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END AS 'Tipo cédula',"
                SQL &= Chr(13) & "	NOMBRE As Nombre,APELLIDO1 As 'Primer apellido',APELLIDO2 as 'Segundo apellido',TELEFONO as Teléfono,CORREO as Correo,SALDO as Saldo,ESTADO as Estado, CONVERT(VARCHAR(10), FECHA_INC, 105) AS 'Fecha ingreso'"
                SQL &= Chr(13) & "	FROM CLIENTE"
                SQL &= Chr(13) & "	WHERE COD_CIA =" & SCM(COD_CIA)
                If RB_ACTIVOS.Checked = True Then
                    SQL &= Chr(13) & "	AND ESTADO ='A'"
                ElseIf RB_INACTIVOS.Checked = True Then
                    SQL &= Chr(13) & "	AND ESTADO ='I'"
                End If
                SQL &= Chr(13) & CONSULTA_FILTRO

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("Código"), ITEM("Cédula"), ITEM("Tipo cédula"), ITEM("Nombre"), ITEM("Primer apellido"), ITEM("Segundo apellido"), ITEM("Teléfono"), ITEM("Correo"), ITEM("Saldo"), ITEM("Estado"), ITEM("Fecha ingreso")}
                        GRID.Rows.Add(row)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        REFRESCAR()
    End Sub

    Private Sub RB_ACTIVOS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_ACTIVOS.CheckedChanged, RB_INACTIVOS.CheckedChanged, RB_TODOS.CheckedChanged
        REFRESCAR()
    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Dim PANTALLA As New ClienteMant(CRF_Modos.Insertar, Me)
        PANTALLA.ShowDialog()
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
    Public Sub REFRESCAR()
        CONSULTA_FILTRO = ""
        RELLENAR_GRID()
    End Sub
    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Modificar()
    End Sub
    Private Sub Modificar()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()
                If MODO = CRF_Modos.Seleccionar Then
                    SETEO_CONTROL(BS, Me, CEDULA_CLIENTE)
                Else
                    Dim PANTALLA As New ClienteMant(CRF_Modos.Modificar, Me, CEDULA_CLIENTE)
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
                CEDULA_CLIENTE = seleccionado.Cells(1).Value.ToString
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

End Class