Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class ClienteMant
    Dim MODO As CRF_Modos
    Dim PADRE As Cliente
    Dim CEDULA As String
    Sub New(ByVal MODO As CRF_Modos, Optional CEDULA As String = "")
        Me.MODO = MODO
        Me.CEDULA = CEDULA
        InitializeComponent()
    End Sub
    Private Sub CMB_TIPO_CEDULA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_CEDULA.SelectedIndexChanged
        Try
            If CMB_TIPO_CEDULA.SelectedIndex = 0 Then 'Física
                TXT_CEDULA.Mask = "000000000"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 Then 'Jurídica
                TXT_CEDULA.Mask = "0000000000"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 2 Then 'Nite
                TXT_CEDULA.Mask = "000000000000"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 3 Then 'Dimex
                TXT_CEDULA.Mask = "0000000000"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function VALIDAR() As Boolean
        Try
            Dim ENTRAR As Boolean = False
            If TXT_CEDULA.Text.ToString.Equals("") Then
                MessageBox.Show("¡Cédula incorrecta!")
                TXT_CEDULA.Select()
            ElseIf TXT_NOMBRE.Text.ToString.Equals("") Then
                MessageBox.Show("¡Nombre de compañía incorrecto!")
                TXT_NOMBRE.Select()
            ElseIf TXT_EMAIL.Text.ToString.Equals("") Then
                MessageBox.Show("¡Correo electrónico incorrecto!")
                TXT_EMAIL.Select()
            ElseIf TXT_PRIMER_APELLIDO.Text.Equals("") Then
                MessageBox.Show("¡Primer apellido incorrecto!")
                TXT_PRIMER_APELLIDO.Select()
            ElseIf TXT_SEGUNDO_APELLIDO.Text.Equals("") Then
                MessageBox.Show("¡Segundo apellido incorrecto!")
                TXT_SEGUNDO_APELLIDO.Select()
            ElseIf TXT_TELEFONO.Text.Equals("") Then
                MessageBox.Show("¡Teléfono incorrecto!")
                TXT_TELEFONO.Select()
            ElseIf TXT_DIRECCION.Text.Equals("") Then
                MessageBox.Show("¡Dirección incorrecta!")
                TXT_DIRECCION.Select()
            ElseIf TXT_EMAIL.Text.Equals("") Then
                MessageBox.Show("¡Email incorrecto!")
                TXT_EMAIL.Select()
            ElseIf TXT_SALDO.Text.Equals("") Or FMC(TXT_SALDO.Text) <= 0 Then
                MessageBox.Show("¡Saldo incorrecto!")
                TXT_SALDO.Select()
            ElseIf MODO = CRF_Modos.Insertar And EXISTE_CEDULA() = True Then
                MessageBox.Show("¡Ya existe un cliente con la cédula : " & TXT_CEDULA.Text & "!")
                TXT_SALDO.Select()
            Else
                ENTRAR = True
            End If
            Return ENTRAR
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub EJECUTAR()
        Try
            Dim SQL As String = "EXEC CLIENTE_MANT"
            SQL &= Chr(13) & " @COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & ",@MODO = " & Val(MODO)
            SQL &= Chr(13) & ",@TIPO_CEDULA = " & SCM(CMB_TIPO_CEDULA.Text.ToString.Substring(0, 1).ToUpper)
            SQL &= Chr(13) & ",@CEDULA = " & SCM(TXT_CEDULA.Text)
            SQL &= Chr(13) & ",@NOMBRE = " & SCM(TXT_NOMBRE.Text)
            SQL &= Chr(13) & ",@APELLIDO1 = " & SCM(TXT_PRIMER_APELLIDO.Text)
            SQL &= Chr(13) & ",@APELLIDO2 = " & SCM(TXT_SEGUNDO_APELLIDO.Text)
            SQL &= Chr(13) & ",@TELEFONO = " & SCM(TXT_TELEFONO.Text)
            SQL &= Chr(13) & ",@DIRECCION = " & SCM(TXT_DIRECCION.Text)
            SQL &= Chr(13) & ",@CORREO = " & SCM(TXT_EMAIL.Text)
            SQL &= Chr(13) & ",@SALDO = " & FMC(TXT_SALDO.Text, 2)
            SQL &= Chr(13) & ",@ESTADO = " & SCM(IIf(RB_ACTIVO.Checked = True, "A", "I"))
            SQL &= Chr(13) & ",@FE = " & SCM(IIf(CK_TIQUETE.Checked = True, "N", "S"))

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            If MODO = CRF_Modos.Insertar Then
                LIMPIAR_TODO()
                MessageBox.Show("¡Cliente agregado correctamente!")
            ElseIf MODO = CRF_Modos.Modificar Then
                CERRAR()
                MessageBox.Show("¡Cliente modificado correctamente!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LIMPIAR_TODO()
        CMB_TIPO_CEDULA.SelectedIndex = 0
        TXT_NOMBRE.Text = ""
        TXT_PRIMER_APELLIDO.Text = ""
        TXT_PRIMER_APELLIDO.Text = ""
        TXT_TELEFONO.Text = ""
        TXT_DIRECCION.Text = ""
        TXT_EMAIL.Text = ""
        TXT_SALDO.Text = ""
        CK_TIQUETE.Checked = False
        RB_ACTIVO.Checked = True
    End Sub
    Private Sub Cerrar()
        PADRE.REFRESCAR()
        Me.Close()
    End Sub
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

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        If MODO = CRF_Modos.Insertar Or MODO = CRF_Modos.Modificar Then
            If VALIDAR() = True Then
                EJECUTAR()
            End If
        ElseIf MODO = CRF_Modos.Eliminar Then
        End If
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        CERRAR()
    End Sub

    Private Sub ClienteMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MODO = CRF_Modos.Insertar Then
            CMB_TIPO_CEDULA.SelectedIndex = 0
            TXT_CEDULA.Select()
        End If
    End Sub
End Class