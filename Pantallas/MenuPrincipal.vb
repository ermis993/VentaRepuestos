Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Public Class MenuPrincipal

    Dim Bandera_Sucursal As Boolean = True

    Private Sub BTN_COMPANIA_Click(sender As Object, e As EventArgs) Handles BTN_COMPANIA.Click
        Try
            Compania.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SUCURSAL_Click(sender As Object, e As EventArgs) Handles BTN_SUCURSAL.Click
        Try
            Dim PANTALLA As New Sucursal(Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
            Login.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGAR_SUCURSALES()
    End Sub

    Private Sub CARGAR_SUCURSALES()
        Try
            CMB_SUCURSAL.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = "SELECT COD_SUCUR AS CODIGO, NOMBRE"
            SQL &= Chr(13) & " FROM SUCURSAL"
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND ESTADO = 'A'"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Row In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("CODIGO").ToString & " - " & Row("NOMBRE").ToString.ToUpper))
                Next

                CMB_SUCURSAL.DataSource = LISTA_REF
                CMB_SUCURSAL.ValueMember = "Key"
                CMB_SUCURSAL.DisplayMember = "Value"

                If String.IsNullOrEmpty(COD_SUCUR) Then
                    CMB_SUCURSAL.SelectedIndex = 0
                    COD_SUCUR = CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3)
                Else

                    CMB_SUCURSAL.SelectedValue = COD_SUCUR

                    If CMB_SUCURSAL.SelectedIndex = -1 Then
                        CMB_SUCURSAL.SelectedIndex = 0
                        COD_SUCUR = CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ActualizaSucursales()
        Try
            Bandera_Sucursal = False
            CARGAR_SUCURSALES()
            Bandera_Sucursal = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_SUCURSAL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_SUCURSAL.SelectedIndexChanged
        Try
            If Not CMB_SUCURSAL.DataSource Is Nothing Then
                If Bandera_Sucursal = True Then
                    COD_SUCUR = CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class