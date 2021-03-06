﻿Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ProveedorMant
    Dim MODO As CRF_Modos
    Dim PADRE As Proveedor
    Dim CEDULA As String
    Dim Respuesta As DialogResult
    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Proveedor, Optional CEDULA As String = "")
        InitializeComponent()
        Me.MODO = MODO
        Me.CEDULA = CEDULA
        Me.PADRE = PADRE
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
                TXT_CEDULA.Mask = "#########"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 Then 'Jurídica
                TXT_CEDULA.Mask = "##########"
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
            Dim SQL As String = "EXEC USP_PROVEEDOR_MANT"
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
                    TXT_POR_VENTA.Text = Val(ITEM("PORCENTAJE_VENTA"))

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
        Try
            If MODO = CRF_Modos.Insertar Or MODO = CRF_Modos.Modificar Then
                If VALIDAR() = True Then
                    If EMAIL_VALIDO(TXT_EMAIL.Text) = False Then
                        Respuesta = MessageBox.Show("¡El email ingresado parece ser un email no válido!", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                        If Respuesta = DialogResult.Yes Then
                            EJECUTAR()
                        End If
                    Else
                        EJECUTAR()
                    End If
                End If
            ElseIf MODO = CRF_Modos.Eliminar Then
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function VALIDAR() As Boolean
        Try
            VALIDAR = False
            If CMB_TIPO_CEDULA.SelectedIndex = 0 And TXT_CEDULA.Text.Length < 9 Then  'F
                MessageBox.Show("¡Cédula incorrecta, una cédula de tipo Física contiene 9 dígitos!" & vbNewLine & "La cédula ingresada contiene " & TXT_CEDULA.Text.Length & " dígitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CEDULA.Select()
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 And TXT_CEDULA.Text.Length < 10 Then 'J
                MessageBox.Show("¡Cédula incorrecta, una cédula de tipo Jurídica contiene 10 dígitos!" & vbNewLine & "La cédula ingresada contiene " & TXT_CEDULA.Text.Length & " dígitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CEDULA.Select()
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 2 And TXT_CEDULA.Text.Length < 11 Then 'N
                MessageBox.Show("¡Cédula incorrecta, una cédula de tipo NITE contiene mínimo 11 dígitos!" & vbNewLine & "La cédula ingresada contiene " & TXT_CEDULA.Text.Length & " dígitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CEDULA.Select()
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 3 And TXT_CEDULA.Text.Length < 10 Then 'D
                TXT_CEDULA.Select()
                MessageBox.Show("¡Cédula incorrecta, una cédula de tipo DIMEX contiene 10 dígitos!" & vbNewLine & "La cédula ingresada contiene " & TXT_CEDULA.Text.Length & " dígitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf MODO = CRF_Modos.Insertar And EXISTE_CEDULA() = True Then
                MessageBox.Show("¡Ya existe un proveedor con la cédula : " & TXT_CEDULA.Text & "!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CEDULA.Select()
            ElseIf TXT_NOMBRE.Text.ToString.Equals("") Then
                MessageBox.Show("¡Nombre incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_NOMBRE.Select()
            ElseIf TXT_TELEFONO.Text.Equals("") Then
                MessageBox.Show("¡Teléfono incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_TELEFONO.Select()
            ElseIf TXT_TELEFONO.Text.Length < 8 Then
                MessageBox.Show("¡Teléfono incorrecto, debe contener 8 dígitos!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_TELEFONO.Select()
            ElseIf TXT_DIRECCION.Text.Equals("") Then
                MessageBox.Show("¡Dirección incorrecta, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_DIRECCION.Select()
            ElseIf TXT_EMAIL.Text.ToString.Equals("") Then
                MessageBox.Show("¡Correo electrónico incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_EMAIL.Select()
            ElseIf String.IsNullOrEmpty(TXT_POR_VENTA.Text) Then
                MessageBox.Show("¡Porcentaje incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_POR_VENTA.Select()
            Else
                VALIDAR = True
            End If
            Return VALIDAR
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function EXISTE_CEDULA() As Boolean
        Try
            EXISTE_CEDULA = False
            Dim SQL = "SELECT * FROM PROVEEDOR WHERE CEDULA = " & SCM(TXT_CEDULA.Text)
            SQL &= Chr(13) & " AND COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND COD_SUCUR = " & SCM(COD_SUCUR)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                EXISTE_CEDULA = True
            End If
            Return EXISTE_CEDULA

        Catch ex As Exception
            Return True
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub EJECUTAR()
        Try
            Dim SQL As String = "EXEC USP_PROVEEDOR_MANT"
            SQL &= Chr(13) & " @COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & ",@COD_SUCUR = " & SCM(COD_SUCUR)
            SQL &= Chr(13) & ",@MODO = " & Val(MODO)
            SQL &= Chr(13) & ",@TIPO_CEDULA = " & SCM(CMB_TIPO_CEDULA.Text.ToString.Substring(0, 1).ToUpper)
            SQL &= Chr(13) & ",@CEDULA = " & SCM(TXT_CEDULA.Text)
            SQL &= Chr(13) & ",@NOMBRE = " & SCM(TXT_NOMBRE.Text)
            SQL &= Chr(13) & ",@DIRECCION = " & SCM(TXT_DIRECCION.Text)
            SQL &= Chr(13) & ",@TELEFONO = " & SCM(TXT_TELEFONO.Text)
            SQL &= Chr(13) & ",@CORREO = " & SCM(TXT_EMAIL.Text)
            SQL &= Chr(13) & ",@ESTADO = " & SCM(IIf(RB_ACTIVO.Checked = True, "A", "I"))
            SQL &= Chr(13) & ",@PORCENTAJE = " & Val(TXT_POR_VENTA.Text)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            If MODO = CRF_Modos.Insertar Then
                LIMPIAR_TODO()
                MessageBox.Show("¡Proveedor agregado correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf MODO = CRF_Modos.Modificar Then
                CERRAR()
                MessageBox.Show("¡Proveedor modificado correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LIMPIAR_TODO()
        CMB_TIPO_CEDULA.SelectedIndex = 0
        TXT_CEDULA.Text = ""
        TXT_NOMBRE.Text = ""
        TXT_DIRECCION.Text = ""
        TXT_TELEFONO.Text = ""
        TXT_EMAIL.Text = ""
        TXT_POR_VENTA.Text = ""
        RB_ACTIVO.Checked = True
    End Sub

End Class