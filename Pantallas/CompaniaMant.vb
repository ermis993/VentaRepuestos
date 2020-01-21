Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Login
Public Class LBL_CANTON
    Private Sub CMB_TIPO_CEDULA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_CEDULA.SelectedIndexChanged
        If CMB_TIPO_CEDULA.SelectedIndex = 0 Then 'Física
            TXT_CEDULA.Mask = "000000000"
        ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 Then 'Jurídica
            TXT_CEDULA.Mask = "0000000000"
        ElseIf CMB_TIPO_CEDULA.SelectedIndex = 2 Then 'Nite
            TXT_CEDULA.Mask = "000000000000"
        ElseIf CMB_TIPO_CEDULA.SelectedIndex = 3 Then 'Dimex
            TXT_CEDULA.Mask = "0000000000"
        End If
    End Sub
    Private Sub CompaniaMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMB_TIPO_CEDULA.SelectedIndex = 0
        CARGAR_PROVINCIAS()
    End Sub
    Private Sub CARGAR_PROVINCIAS()
        Try
            CMB_PROVINCIA.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = "SELECT CODIGO_PROVINCIA AS CODIGO,NOMBRE"
            SQL &= Chr(13) & " FROM PROVINCIA"
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()
            If DS.Tables(0).Rows.Count > 0 Then
                LISTA_REF.Add(New KeyValuePair(Of String, String)("", ""))
                For Each PROVINCIA In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(PROVINCIA("CODIGO").ToString, PROVINCIA("NOMBRE")))
                Next
            End If
            CMB_PROVINCIA.DataSource = LISTA_REF
            CMB_PROVINCIA.ValueMember = "Key"
            CMB_PROVINCIA.DisplayMember = "Value"
            CMB_PROVINCIA.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CMB_PROVINCIA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_PROVINCIA.SelectedIndexChanged
        Try
            CMB_CANTON.DataSource = Nothing
            CMB_DISTRITO.DataSource = Nothing
            If CMB_PROVINCIA.SelectedIndex <> 0 Then
                Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

                Dim SQL As String = "SELECT CODIGO_CANTON AS CODIGO,NOMBRE"
                SQL &= Chr(13) & " FROM CANTON"
                SQL &= Chr(13) & " WHERE CODIGO_PROVINCIA = " & CMB_PROVINCIA.SelectedValue

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    LISTA_REF.Add(New KeyValuePair(Of String, String)("", ""))
                    For Each CANTON In DS.Tables(0).Rows
                        LISTA_REF.Add(New KeyValuePair(Of String, String)(CANTON("CODIGO").ToString, CANTON("NOMBRE")))
                    Next
                End If

                CMB_CANTON.DataSource = LISTA_REF
                CMB_CANTON.ValueMember = "Key"
                CMB_CANTON.DisplayMember = "Value"
                CMB_CANTON.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CMB_CANTON_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_CANTON.SelectedIndexChanged
        Try
            CMB_DISTRITO.DataSource = Nothing
            If CMB_CANTON.SelectedIndex <> 0 Then
                Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

                Dim SQL As String = "SELECT CODIGO_DISTRITO AS CODIGO,NOMBRE"
                SQL &= Chr(13) & " FROM DISTRITO"
                SQL &= Chr(13) & " WHERE CODIGO_CANTON = " & CMB_CANTON.SelectedValue

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    LISTA_REF.Add(New KeyValuePair(Of String, String)("", ""))
                    For Each DISTRITO In DS.Tables(0).Rows
                        LISTA_REF.Add(New KeyValuePair(Of String, String)(DISTRITO("CODIGO").ToString, DISTRITO("NOMBRE")))
                    Next
                End If

                CMB_DISTRITO.DataSource = LISTA_REF
                CMB_DISTRITO.ValueMember = "Key"
                CMB_DISTRITO.DisplayMember = "Value"
                CMB_DISTRITO.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Private Sub CHK_FE_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_FE.CheckedChanged
        If CHK_FE.Checked = True Then
            TAB_FE.Parent = TAB_COMPANIA
        Else
            TAB_FE.Parent = Nothing
        End If
    End Sub

    Private Sub TXT_EMAIL_TextChanged(sender As Object, e As EventArgs) Handles TXT_EMAIL.TextChanged

    End Sub
End Class