Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Proveedor
    Dim CEDULA_PROVEEDOR As String
    Dim MODO As CRF_Modos
    Dim BS As New Buscador
    Sub New(Optional ByVal MODO As CRF_Modos = CRF_Modos.Nada, Optional ByVal Bus As Buscador = Nothing)
        Me.MODO = MODO
        Me.BS = Bus
        InitializeComponent()
    End Sub
    Private Sub Proveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rellenar_GRID()
    End Sub
    Private Sub Rellenar_GRID()
        Try
            GRID.DataSource = Nothing
            Dim SQL = "	SELECT COD_SUCUR As Sucursal,CEDULA As Cédula,"
            SQL &= Chr(13) & "	CASE WHEN TIPO_CEDULA ='F' THEN 'Física' "
            SQL &= Chr(13) & "	WHEN TIPO_CEDULA ='J' THEN 'Jurídica' END AS 'Tipo cédula',"
            SQL &= Chr(13) & "	NOMBRE As Nombre,DIRECCION As Dirección,TELEFONO as Teléfono,CORREO as Email,"
            SQL &= Chr(13) & "	CASE WHEN ESTADO ='A' THEN 'Activo' ELSE 'Inactivo' END AS Estado,FECHA_INC AS 'Fecha ingreso' "
            SQL &= Chr(13) & "	FROM PROVEEDOR"
            SQL &= Chr(13) & "	WHERE COD_SUCUR = " & SCM(COD_SUCUR)

            If RB_ACTIVOS.Checked = True Then
                SQL &= Chr(13) & "	AND ESTADO ='A'"
            ElseIf RB_INACTIVOS.Checked = True Then
                SQL &= Chr(13) & "	AND ESTADO ='I'"
            End If
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRID.DataSource = DS.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
    Public Sub REFRESCAR()
        Rellenar_GRID()
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
#End Region
End Class