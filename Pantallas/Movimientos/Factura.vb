Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Factura

    Dim Modo As CRF_Modos

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Public Sub Cerrar()
        Me.Close()
    End Sub

    Sub New(ByVal Modo As CRF_Modos)

        InitializeComponent()
        Me.Modo = Modo
        TXT_TIPO_CAMBIO.Text = FMCP(TC_VENTA)

        If Me.Modo = CRF_Modos.Insertar Then
            BloqueaControles()
            CMB_DOCUMENTO.SelectedIndex = 0
            CMB_FORMAPAGO.SelectedIndex = 0
            CMB_MONEDA.SelectedIndex = 0
        End If

    End Sub


    Public Sub BloqueaControles()
        Try
            TXT_NUMERO.Enabled = False
            TXT_TIPO_CAMBIO.Enabled = False
            DTPFECHA.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_DOCUMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_DOCUMENTO.SelectedIndexChanged
        If CMB_DOCUMENTO.SelectedIndex = 0 Then
            TXT_PLAZO.Text = "0"
            TXT_PLAZO.Enabled = False
        Else
            TXT_PLAZO.Enabled = True
        End If
    End Sub

    Private Sub Factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cliente.TABLA_BUSCAR = "CLIENTE"
        Cliente.CODIGO = "CEDULA"
        Cliente.DESCRIPCION = "NOMBRE"

        Producto.TABLA_BUSCAR = "CLIENTE"
        Producto.CODIGO = "COD_PROD"
        Producto.DESCRIPCION = "DESCRIPCION"
    End Sub

    Private Sub CalculoTotales()
        Try
            If String.IsNullOrEmpty(Producto.VALOR) Then
                MessageBox.Show("¡Debe seleccionar el proveedor!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Producto.Select()
            Else
                Dim Cantidad As Double
                Dim Precio_Unitario As Double
                Dim Descuento As Double
                Dim Descuento_Total As Double
                Dim Impuesto As Double
                Dim Impuesto_Total As Double
                Dim Subtotal As Double
                Dim Total As Double

                Cantidad = FMC(TXT_CANTIDAD.Text)
                Precio_Unitario = FMC(TXT_PRECIO.Text)
                Descuento = FMC(TXT_DESCUENTO.Text)
                Impuesto = FMC(TXT_IMPUESTO.Text)

                Descuento_Total = ((Precio_Unitario * Cantidad) * Descuento) / 100
                Impuesto_Total = (((Precio_Unitario * Cantidad) - Descuento_Total) * Impuesto) / 100
                Subtotal = ((Precio_Unitario * Cantidad) - Descuento_Total)
                Total = Subtotal + Impuesto_Total

                TXT_DESCUENTOTOTAL.Text = FMCP(Descuento_Total)
                TXT_IMPUESTOTOTAL.Text = FMCP(Impuesto_Total)
                TXT_SUBTOTAL.Text = FMCP(Subtotal)
                TXT_TOTAL.Text = FMCP(Total)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_CALCULAR_Click(sender As Object, e As EventArgs) Handles BTN_CALCULAR.Click
        CalculoTotales()
    End Sub

    Private Sub TXT_CANTIDAD_Leave(sender As Object, e As EventArgs) Handles TXT_CANTIDAD.Leave
        CalculoTotales()
    End Sub

    Private Sub TXT_DESCUENTO_Leave(sender As Object, e As EventArgs) Handles TXT_DESCUENTO.Leave
        CalculoTotales()
    End Sub
End Class