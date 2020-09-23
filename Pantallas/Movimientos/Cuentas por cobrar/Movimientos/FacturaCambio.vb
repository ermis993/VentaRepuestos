Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class FacturaCambio
    Sub New(ByVal MONTO_COBRAR As Decimal)
        InitializeComponent()
        LBL_MONTO_COBRAR.Text = FMCP(MONTO_COBRAR)
    End Sub

    Private Sub Calcular()
        Try
            Dim Monto_Debe = FMC(LBL_MONTO_COBRAR.Text)
            Dim Monto_Paga = FMC(TXT_PAGA_CON.Text)

            If Monto_Paga > 0 Then
                LBL_CAMBIO.Text = FMCP(Monto_Paga - Monto_Debe)
            Else
                LBL_CAMBIO.Text = FMCP(Monto_Debe) * -1
            End If

            If FMC(LBL_CAMBIO.Text) < 0 Then
                LBL_CAMBIO.ForeColor = Color.Red
                Label3.ForeColor = Color.Red
            Else
                LBL_CAMBIO.ForeColor = Color.Green
                Label3.ForeColor = Color.Green
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Valida()
    End Sub

    Private Sub Valida()
        Try
            If FMC(LBL_CAMBIO.Text) >= 0 Then
                Me.Close()
            Else
                MessageBox.Show(Me, "El cambio no puede ser menor a cero (0), por favor verifique los montos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TXT_PAGA_CON_TextChanged(sender As Object, e As EventArgs) Handles TXT_PAGA_CON.TextChanged
        Try
            Calcular()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TXT_PAGA_CON_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_PAGA_CON.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Valida()
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class