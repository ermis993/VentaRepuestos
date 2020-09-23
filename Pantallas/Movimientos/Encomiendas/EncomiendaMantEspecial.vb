Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class EncomiendaMantEspecial
    Dim DESDE As String
    Dim HASTA As String
    Dim Estado_Actualizar As String

    Dim Padre As Encomienda

    Sub New(ByVal Estado As String, ByVal FEC_DESDE As String, ByVal FEC_HASTA As String, ByVal padrecito As Encomienda)
        InitializeComponent()
        Estado_Actualizar = Estado
        DESDE = FEC_DESDE
        HASTA = FEC_HASTA
        Padre = padrecito
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            Dim Sql = "	USP_ACTUALIZA_ENCOMIENDA_GLOBAL	"
            Sql &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & "	,@COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & "	,@COD_SUCUR_NUEV = " & SCM(CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3))
            Sql &= Chr(13) & "	,@DESDE = " & SCM(YMDHms(DESDE))
            Sql &= Chr(13) & "	,@HASTA = " & SCM(YMDHms(HASTA))
            Sql &= Chr(13) & "	,@ESTADO = " & SCM("T")
            Sql &= Chr(13) & "	,@COD_USUARIO = " & SCM(COD_USUARIO)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(Sql)
            CONX.Coneccion_Cerrar()

            Cerrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub EncomiendaMantEspecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGAR_SUCURSALES()
    End Sub

    Private Sub CARGAR_SUCURSALES()
        Try
            CMB_SUCURSAL.DataSource = Nothing

            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL = "	SELECT COD_SUCUR AS CODIGO, NOMBRE"
            SQL &= Chr(13) & "	FROM SUCURSAL"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND COD_SUCUR <> " & SCM(COD_SUCUR)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Row In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("CODIGO").ToString.ToUpper & " - " & Row("NOMBRE").ToString.ToUpper))
                Next

                CMB_SUCURSAL.ValueMember = "Key"
                CMB_SUCURSAL.DisplayMember = "Value"
                CMB_SUCURSAL.DataSource = LISTA_REF
                CMB_SUCURSAL.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub Cerrar()
        Padre.Refrescar()
        Me.Close()
    End Sub

End Class