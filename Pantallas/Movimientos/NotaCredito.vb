Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class NotaCredito

    Sub New()
        InitializeComponent()

        Cliente.TABLA_BUSCAR = "CLIENTE"
        Cliente.CODIGO = "CEDULA"
        Cliente.DESCRIPCION = "NOMBRE"
        Cliente.refrescar()
        CMB_DOCUMENTO.SelectedIndex = 0

        BloqueaControles()

    End Sub

    Public Sub BloqueaControles()
        Try
            TXT_NUMERO.Enabled = False
            TXT_TIPO_CAMBIO.Enabled = False
            DTPFECHA.Enabled = False
            'CMB_DOCUMENTO.Enabled = IIf(Modo = CRF_Modos.Insertar, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub CMB_DOCUMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_DOCUMENTO.SelectedIndexChanged
        If CMB_DOCUMENTO.SelectedIndex = 1 Then
            LBLTIPO.Visible = True
            CMB_TIPO.Visible = True
            CMB_TIPO.SelectedIndex = 0
        Else
            LBLTIPO.Visible = False
            CMB_TIPO.Visible = False
            CMB_TIPO.SelectedIndex = -1
        End If
    End Sub

    Private Sub RellenaFacturas()
        Try
            If Not CMB_MONEDA.SelectedIndex <= -1 And String.IsNullOrEmpty(Cliente.VALOR) = False Then

                GRID.DataSource = Nothing

                Dim SQL = "	SELECT TIPO_MOV AS Tipo, NUMERO_DOC AS Número, CONVERT(VARCHAR(10),FECHA, 105) AS Fecha, MONTO AS Subtotal	"
                SQL &= Chr(13) & "	, IMPUESTO as Impuesto, (MONTO+IMPUESTO) AS Total, SALDO as Saldo"
                SQL &= Chr(13) & "	FROM DOCUMENTO_ENC	"
                SQL &= Chr(13) & "	WHERE CEDULA = " & SCM(Cliente.VALOR)
                SQL &= Chr(13) & "	AND COD_MONEDA = " & SCM(CMB_MONEDA.SelectedItem.ToString.Substring(0, 1))
                SQL &= Chr(13) & "  AND SALDO > 0 "

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    GRID.DataSource = DS.Tables(0)
                End If

            Else
                GRID.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Cliente_Leave(sender As Object, e As EventArgs) Handles Cliente.Leave
        RellenaFacturas()
    End Sub

    Private Sub CMB_MONEDA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_MONEDA.SelectedIndexChanged
        RellenaFacturas()
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub Cerrar()
        Me.Close()
    End Sub

End Class