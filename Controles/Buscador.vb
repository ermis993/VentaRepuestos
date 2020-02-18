Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Buscador
    Public Property PANTALLA As Form
    Public Property TABLA_BUSCAR As String
    Public Property CODIGO As String
    Public Property DESCRIPCION As String
    Public Property OTROS_CAMP0S As String
    Private Property DESC As String
    Public Property VALOR As String
        Get
            Return Me.TXT_BUSCADOR.Text
        End Get
        Set(ByVal value As String)
            Me.TXT_BUSCADOR.Text = value
        End Set
    End Property
    Public Property VALOR_DESCRIPCION As String
        Get
            Return Me.DESC
        End Get
        Set(ByVal value As String)
            Me.CMB.SelectedItem = value
        End Set
    End Property

    Public Sub ACTUALIZAR_COMBO()
        BUSCAR_EN_COMBOBOX()
    End Sub

    Public Sub refrescar()

        If VALIDAR() Then
            Dim SQL As String = "SELECT " & CODIGO & "," & DESCRIPCION
            SQL &= Chr(13) & " FROM " & TABLA_BUSCAR
            SQL &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()
            If DS.Tables(0).Rows.Count > 0 Then
                Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
                CMB.DataSource = Nothing
                LISTA_REF.Add(New KeyValuePair(Of String, String)("", ""))
                For Each ITEM In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(ITEM(CODIGO).ToString, ITEM(DESCRIPCION).ToString.ToUpper))
                Next
                CMB.DataSource = LISTA_REF
                CMB.ValueMember = "Key"
                CMB.DisplayMember = "Value"
                CMB.SelectedIndex = 0
                TXT_BUSCADOR.Text = ""
            End If
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        refrescar()
    End Sub

    Private Function VALIDAR() As Boolean
        Try
            Dim ENTRAR As Boolean
            If TABLA_BUSCAR.Equals("") Then
                ENTRAR = False
            ElseIf CODIGO.Equals("") Then
                ENTRAR = False
            ElseIf DESCRIPCION.Equals("") Then
                ENTRAR = False
            Else
                ENTRAR = True
            End If
            Return ENTRAR
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub CMB_SelectedValueChanged(sender As Object, e As EventArgs) Handles CMB.SelectedValueChanged
        Try
            If IsNothing(CMB.SelectedValue) = False Then
                DESC = CMB.SelectedText.ToString
                TXT_BUSCADOR.Text = CMB.SelectedValue.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TXT_BUSCADOR_Leave(sender As Object, e As EventArgs) Handles TXT_BUSCADOR.Leave
        BUSCAR_EN_COMBOBOX()
    End Sub
    Private Sub BUSCAR_EN_COMBOBOX()
        Try
            Dim ENCONTRADO As Boolean = False
            If TXT_BUSCADOR.Text <> "" Then
                For x = 0 To CMB.Items.Count - 1
                    If TXT_BUSCADOR.Text.ToString.Equals(CMB.Items(x).Key.ToString) Then
                        CMB.SelectedValue = TXT_BUSCADOR.Text
                        ENCONTRADO = True
                        Exit For
                    End If
                Next
            Else
                CMB.SelectedIndex = -1
            End If
            If ENCONTRADO = False Then
                If TXT_BUSCADOR.Text <> "" Then
                    MessageBox.Show("¡Código no encontrado!")
                End If
                TXT_BUSCADOR.Text = ""
                CMB.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TXT_BUSCADOR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_BUSCADOR.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            BUSCAR_EN_COMBOBOX()
        End If
    End Sub

    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        If IsNothing(Me.PANTALLA) = False Then
            Me.PANTALLA.ShowDialog()
        End If
    End Sub
End Class
