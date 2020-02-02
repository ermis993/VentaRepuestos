Imports FUN_CRFUSION.FUNCIONES_GENERALES

Public Class ProductoMant

    Dim MODO As CRF_Modos
    Dim PADRE As Producto
    Dim COD_PROD As String

    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Producto, Optional COD_PROD As String = "")
        InitializeComponent()

        Me.MODO = MODO
        Me.COD_PROD = COD_PROD
        Me.PADRE = PADRE

        Buscador.TABLA_BUSCAR = "Proveedor"
        Buscador.CODIGO = "CEDULA"
        Buscador.DESCRIPCION = "NOMBRE"
        Buscador.PANTALLA = New Cliente()
        Buscador.refrescar()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub Cerrar()
        Me.Close()
    End Sub

End Class