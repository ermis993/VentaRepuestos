Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Producto

    Dim COD_PROD As String
    Dim MODO As CRF_Modos
    Dim BS As New Buscador

    Sub New(Optional ByVal MODO As CRF_Modos = CRF_Modos.Nada, Optional ByVal Bus As Buscador = Nothing)
        InitializeComponent()
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

    Public Sub RELLENAR_GRID()
        Try
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

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                GRID.DataSource = DS.Tables(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_REFRESCAR_Click(sender As Object, e As EventArgs) Handles BTN_REFRESCAR.Click
        RELLENAR_GRID()
    End Sub

    Private Sub Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        RELLENAR_GRID()
    End Sub
    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Modificar()
    End Sub
    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Modificar()
    End Sub

End Class