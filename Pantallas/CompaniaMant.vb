Public Class LBL_CANTON
    Private Sub CMB_TIPO_CEDULA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_CEDULA.SelectedIndexChanged
        If CMB_TIPO_CEDULA.SelectedIndex = 0 Then 'Física
            CEDULA.Mask = "000000000"
        ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 Then 'Jurídica
            CEDULA.Mask = "0000000000"
        ElseIf CMB_TIPO_CEDULA.SelectedIndex = 2 Then 'Nite
            CEDULA.Mask = "000000000000"
        ElseIf CMB_TIPO_CEDULA.SelectedIndex = 3 Then 'Dimex
            CEDULA.Mask = "0000000000"
        End If
    End Sub
    Private Sub CompaniaMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMB_TIPO_CEDULA.SelectedIndex = 0
    End Sub

    Private Sub CARGAR_PROVINCIAS()
        Try
            CMB_PROVINCIA.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("01", "San José"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("02", "Cartago"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("03", "Alajuela"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("04", "Heredia"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("05", "Puntarenas"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("06", "Guanacaste"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("07", "Limón"))
            CMB_PROVINCIA.DataSource = LISTA_REF
            CMB_PROVINCIA.ValueMember = "Key"
            CMB_PROVINCIA.DisplayMember = "Value"
            CMB_PROVINCIA.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CARGAR_CANTONES_SAN_JOSE()
        Try
            CMB_CANTON.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("01", "San José"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("02", "Escazú"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("03", "Desamparados"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("04", "Puriscal"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("04", "Tarrazú"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("04", "Aserrí"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("04", "Limón"))
            CMB_CANTON.DataSource = LISTA_REF
            CMB_CANTON.ValueMember = "Key"
            CMB_CANTON.DisplayMember = "Value"
            CMB_CANTON.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub


End Class