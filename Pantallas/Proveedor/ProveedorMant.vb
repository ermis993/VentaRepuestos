Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ProveedorMant
    Dim MODO As CRF_Modos
    Dim PADRE As Proveedor
    Dim CEDULA As String
    Dim Respuesta As DialogResult
    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Proveedor, Optional CEDULA As String = "")
        Me.MODO = MODO
        Me.CEDULA = CEDULA
        Me.PADRE = PADRE
        InitializeComponent()
    End Sub
    Private Sub ProveedorMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MODO = CRF_Modos.Insertar Then
            CMB_TIPO_CEDULA.SelectedIndex = 0
            TXT_CEDULA.Select()
        Else
            CMB_TIPO_CEDULA.Enabled = False
            TXT_CEDULA.ReadOnly = True
            LEER()
            TXT_NOMBRE.Select()
        End If
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        CERRAR()
    End Sub
    Private Sub CERRAR()
        PADRE.REFRESCAR()
        Me.Close()
    End Sub
    Private Sub TXT_TELEFONO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_TELEFONO.KeyPress
        VALIDAR_SOLO_NUMEROS(e)
    End Sub
    Private Sub CMB_TIPO_CEDULA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_CEDULA.SelectedIndexChanged
        Try
            If CMB_TIPO_CEDULA.SelectedIndex = 0 Then 'Física
                TXT_CEDULA.Mask = "#-####-####"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 Then 'Jurídica
                TXT_CEDULA.Mask = "#-###-######"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 2 Then 'Nite
                TXT_CEDULA.Mask = "############"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 3 Then 'Dimex
                TXT_CEDULA.Mask = "##########"
            End If
            TXT_CEDULA.PromptChar = "#"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LEER()
        Try
            Dim SQL As String = "EXEC PROVEEDOR_MANT"
            SQL &= Chr(13) & " @COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & ",@COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Seleccionar)
            SQL &= Chr(13) & ",@CEDULA = " & SCM(CEDULA)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows

                    Dim TIPO As String = ITEM("TIPO_CEDULA")
                    If Trim(TIPO.ToUpper.ToString).Equals("F") Then
                        CMB_TIPO_CEDULA.SelectedIndex = 0
                    ElseIf Trim(TIPO.ToUpper.ToString).Equals("J") Then
                        CMB_TIPO_CEDULA.SelectedIndex = 1
                    ElseIf Trim(TIPO.ToUpper.ToString).Equals("N") Then
                        CMB_TIPO_CEDULA.SelectedIndex = 2
                    ElseIf Trim(TIPO.ToUpper.ToString).Equals("D") Then
                        CMB_TIPO_CEDULA.SelectedIndex = 3
                    End If

                    TXT_CEDULA.Text = CEDULA
                    TXT_NOMBRE.Text = ITEM("NOMBRE")
                    TXT_TELEFONO.Text = ITEM("TELEFONO")
                    TXT_DIRECCION.Text = ITEM("DIRECCION")
                    TXT_EMAIL.Text = ITEM("CORREO")

                    If Trim(ITEM("ESTADO")).Equals("A") Then
                        RB_ACTIVO.Checked = True
                    Else
                        RB_INACTIVO.Checked = True
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click

    End Sub

    Private Function VALIDAR() As Boolean
        Try
            VALIDAR = False
            If TXT_CEDULA.Text.Contains("#") Then
                MessageBox.Show("¡Cédula incorrecta, debe ingresar todos los dígitos!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_CEDULA.Select()
            ElseIf MODO = CRF_Modos.Insertar And EXISTE_CEDULA() = True Then
                MessageBox.Show("¡Ya existe un cliente con la cédula : " & TXT_CEDULA.Text & "!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_CEDULA.Select()
            ElseIf TXT_NOMBRE.Text.ToString.Equals("") Then
                MessageBox.Show("¡Nombre incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_NOMBRE.Select()
            ElseIf TXT_TELEFONO.Text.Equals("") Then
                MessageBox.Show("¡Teléfono incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_TELEFONO.Select()
            ElseIf TXT_TELEFONO.Text.Length < 8 Then
                MessageBox.Show("¡Teléfono incorrecto, debe contener 8 dígitos!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_TELEFONO.Select()
            ElseIf TXT_DIRECCION.Text.Equals("") Then
                MessageBox.Show("¡Dirección incorrecta, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_DIRECCION.Select()
            ElseIf TXT_EMAIL.Text.ToString.Equals("") Then
                MessageBox.Show("¡Correo electrónico incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_EMAIL.Select()
            End If
            Return VALIDAR
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function EXISTE_CEDULA() As Boolean
        Try
            Dim EXISTE As Boolean = False
            Dim SQL = "SELECT * FROM CLIENTE WHERE CEDULA = " & SCM(TXT_CEDULA.Text)
            SQL &= Chr(13) & " AND COD_CIA = " & SCM(COD_CIA)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                EXISTE = True
            End If
            Return EXISTE
        Catch ex As Exception
            Return True
            MessageBox.Show(ex.Message)
        End Try
    End Function
End Class