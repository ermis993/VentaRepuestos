﻿Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ClienteMant
    Dim MODO As CRF_Modos
    Dim PADRE As Cliente
    Dim CEDULA As String
    Dim Respuesta As DialogResult
    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Cliente, Optional CEDULA As String = "")
        InitializeComponent()
        Me.MODO = MODO
        Me.CEDULA = CEDULA
        Me.PADRE = PADRE
    End Sub

    Private Sub CMB_TIPO_CEDULA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_CEDULA.SelectedIndexChanged
        Try
            TXT_CEDULA.Text = ""
            TXT_NOMBRE.Text = ""
            If CMB_TIPO_CEDULA.SelectedIndex = 0 Then 'Física
                TXT_CEDULA.Mask = "#########"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 Then 'Jurídica
                TXT_CEDULA.Mask = "##########"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 2 Then 'Nite
                TXT_CEDULA.Mask = "##########"
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 3 Then 'Dimex
                TXT_CEDULA.Mask = "############"
            End If
            TXT_CEDULA.PromptChar = "#"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function VALIDAR() As Boolean
        Try
            Dim ENTRAR As Boolean = False
            If CMB_TIPO_CEDULA.SelectedIndex = 0 And TXT_CEDULA.Text.Length < 9 Then  'F
                MessageBox.Show("¡Cédula incorrecta, una cédula de tipo Física contiene 9 dígitos!" & vbNewLine & "La cédula ingresada contiene " & TXT_CEDULA.Text.Length & " dígitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CEDULA.Select()
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 And TXT_CEDULA.Text.Length < 10 Then 'J
                MessageBox.Show("¡Cédula incorrecta, una cédula de tipo Jurídica contiene 10 dígitos!" & vbNewLine & "La cédula ingresada contiene " & TXT_CEDULA.Text.Length & " dígitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CEDULA.Select()
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 2 And TXT_CEDULA.Text.Length < 10 Then 'N
                MessageBox.Show("¡Cédula incorrecta, una cédula de tipo NITE contiene mínimo 10 dígitos!" & vbNewLine & "La cédula ingresada contiene " & TXT_CEDULA.Text.Length & " dígitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CEDULA.Select()
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 3 And TXT_CEDULA.Text.Length < 12 Then 'D
                TXT_CEDULA.Select()
                MessageBox.Show("¡Cédula incorrecta, una cédula de tipo DIMEX contiene 12 dígitos!" & vbNewLine & "La cédula ingresada contiene " & TXT_CEDULA.Text.Length & " dígitos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf MODO = CRF_Modos.Insertar And EXISTE_CEDULA() = True Then
                MessageBox.Show("¡Ya existe un cliente con la cédula : " & TXT_CEDULA.Text & "!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CEDULA.Select()
            ElseIf TXT_NOMBRE.Text.ToString.Equals("") Then
                MessageBox.Show("¡Nombre incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_NOMBRE.Select()
            ElseIf TXT_PRIMER_APELLIDO.Text.Equals("") And CMB_TIPO_CEDULA.SelectedIndex <> 1 Then
                MessageBox.Show("¡Primer apellido incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_PRIMER_APELLIDO.Select()
            ElseIf TXT_SEGUNDO_APELLIDO.Text.Equals("") And CMB_TIPO_CEDULA.SelectedIndex <> 1 Then
                MessageBox.Show("¡Segundo apellido incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_SEGUNDO_APELLIDO.Select()
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
            ElseIf CMB_PROVINCIA.Text.Equals("") Then
                MessageBox.Show("¡Provincia incorrecta!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CMB_PROVINCIA.Select()
                CMB_PROVINCIA.DroppedDown = True
            ElseIf CMB_CANTON.Text.Equals("") Then
                MessageBox.Show("¡Cantón incorrecto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CMB_CANTON.Select()
                CMB_CANTON.DroppedDown = True
            ElseIf CMB_DISTRITO.Text.Equals("") Then
                MessageBox.Show("¡Distrito incorrecto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CMB_DISTRITO.Select()
                CMB_DISTRITO.DroppedDown = True
            ElseIf TXT_SALDO.Text.Equals("") Then
                MessageBox.Show("¡Saldo incorrecto, no debe dejarse en blanco!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_SALDO.Select()
            ElseIf FMC(TXT_SALDO.Text) <= 0 Then
                MessageBox.Show("¡El saldo debe ser mayor a 0!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            Dim SQL As String = "EXEC USP_CLIENTE_MANT"
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
            SQL &= Chr(13) & ",@MONEDA = " & SCM(CMB_MONEDA.SelectedValue)
            SQL &= Chr(13) & ",@ESTADO = " & SCM(IIf(RB_ACTIVO.Checked = True, "A", "I"))
            SQL &= Chr(13) & ",@FE = " & SCM(IIf(CK_TIQUETE.Checked = True, "N", "S"))
            SQL &= Chr(13) & ",@COD_PROVINCIA = " & SCM(CMB_PROVINCIA.SelectedValue)
            SQL &= Chr(13) & ",@PROVINCIA = " & SCM(CMB_PROVINCIA.Text)
            SQL &= Chr(13) & ",@COD_CANTON = " & SCM(CMB_CANTON.SelectedValue)
            SQL &= Chr(13) & ",@CANTON = " & SCM(CMB_CANTON.Text)
            SQL &= Chr(13) & ",@COD_DISTRITO = " & SCM(CMB_DISTRITO.SelectedValue)
            SQL &= Chr(13) & ",@DISTRITO = " & SCM(CMB_DISTRITO.Text)
            SQL &= Chr(13) & ",@PRECIO_DEFECTO = " & Val(CMB_PRECIO.SelectedIndex)

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            If MODO = CRF_Modos.Insertar Then
                LIMPIAR_TODO()
                MessageBox.Show(Me, "¡Cliente agregado correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf MODO = CRF_Modos.Modificar Then
                Cerrar()
                MessageBox.Show(Me, "¡Cliente modificado correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LIMPIAR_TODO()
        CMB_TIPO_CEDULA.SelectedIndex = 0
        TXT_CEDULA.Text = ""
        TXT_NOMBRE.Text = ""
        TXT_PRIMER_APELLIDO.Text = ""
        TXT_SEGUNDO_APELLIDO.Text = ""
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
        Try
            If MODO = CRF_Modos.Insertar Or MODO = CRF_Modos.Modificar Then
                If VALIDAR() = True Then
                    If EMAIL_VALIDO(TXT_EMAIL.Text) = False Then
                        Respuesta = MessageBox.Show("¡El email ingresado parece ser un email no válido!", Me.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
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

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub ClienteMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGAR_MONEDA()
        CARGAR_PROVINCIAS()

        DTPFECHA.Format = DateTimePickerFormat.Custom
        DTPFECHA.CustomFormat = "dd/MM/yyyy HH:mm"

        If MODO = CRF_Modos.Insertar Then
            CMB_TIPO_CEDULA.SelectedIndex = 0
            CMB_PRECIO.SelectedIndex = 0
            TXT_CEDULA.Select()
        Else
            CMB_TIPO_CEDULA.Enabled = False
            TXT_CEDULA.ReadOnly = True
            BTN_BUSCAR.Enabled = True
            BTN_BUSCAR.Enabled = False
            LEER()
            RELLENAR_GRID()
        End If

        If Me.MODO = CRF_Modos.Modificar Then
            TabPage2.Parent = TabControl1
        Else
            TabPage2.Parent = Nothing
        End If

    End Sub

    Private Sub CARGAR_MONEDA()
        Try
            CMB_MONEDA.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("LOC", "LOC - Local"))
            LISTA_REF.Add(New KeyValuePair(Of String, String)("DOL", "DOL - Dólares"))

            CMB_MONEDA.DataSource = LISTA_REF
            CMB_MONEDA.ValueMember = "Key"
            CMB_MONEDA.DisplayMember = "Value"
            CMB_MONEDA.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LEER()
        Try
            Dim SQL As String = "EXEC USP_CLIENTE_MANT"
            SQL &= Chr(13) & "@COD_CIA = " & SCM(COD_CIA)
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
                    TXT_PRIMER_APELLIDO.Text = ITEM("APELLIDO1")
                    TXT_SEGUNDO_APELLIDO.Text = ITEM("APELLIDO2")
                    TXT_TELEFONO.Text = ITEM("TELEFONO")
                    TXT_DIRECCION.Text = ITEM("DIRECCION")
                    TXT_EMAIL.Text = ITEM("CORREO")
                    TXT_SALDO.Text = FMCP(ITEM("SALDO"), 2)
                    CMB_MONEDA.SelectedValue = ITEM("MONEDA")

                    If Trim(ITEM("ESTADO")).Equals("A") Then
                        RB_ACTIVO.Checked = True
                    Else
                        RB_INACTIVO.Checked = True
                    End If

                    Dim FE As String = ITEM("FE")
                    If Trim(FE).Equals("N") Then
                        CK_TIQUETE.Checked = True
                    Else
                        CK_TIQUETE.Checked = False
                    End If
                    CMB_PROVINCIA.SelectedValue = ITEM("COD_PROVINCIA")
                    CMB_CANTON.SelectedValue = ITEM("COD_CANTON")
                    CMB_DISTRITO.SelectedValue = ITEM("COD_DISTRITO")
                    CMB_PRECIO.SelectedIndex = Val(ITEM("PRECIO_DEFECTO"))
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TXT_SALDO_Leave(sender As Object, e As EventArgs) Handles TXT_SALDO.Leave
        TXT_SALDO.Text = FMCP(TXT_SALDO.Text, 2)
    End Sub

    Private Sub NUMEROS(sender As Object, e As KeyPressEventArgs) Handles TXT_TELEFONO.KeyPress, TXT_SALDO.KeyPress
        VALIDAR_SOLO_NUMEROS(e)
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
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_PROVINCIA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_PROVINCIA.SelectedIndexChanged
        Try
            CMB_DISTRITO.DataSource = Nothing
            CMB_CANTON.DataSource = Nothing
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
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMB_CANTON_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_CANTON.SelectedIndexChanged
        Try
            CMB_DISTRITO.DataSource = Nothing
            If CMB_CANTON.SelectedIndex <> 0 Then
                Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

                If IsNothing(CMB_CANTON.SelectedValue) = False Then
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        Try
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
            Else
                Cursor.Current = Cursors.WaitCursor
                Select Case CMB_TIPO_CEDULA.SelectedIndex
                    Case 0
                        BUSCAR_EN_SIC("F")
                    Case 1
                        BUSCAR_EN_SIC("J")
                    Case 2
                        BUSCAR_EN_SIC("N")
                    Case 3
                        BUSCAR_EN_SIC("D")
                End Select
                Cursor.Current = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BUSCAR_EN_SIC(ByVal TIPO As String)
        Try
            Dim SQL As String = "EXECUTE USP_OBTIENE_DATOS_SIC "
            SQL &= Chr(13) & "    @TIPO  = " & SCM(TIPO)
            SQL &= Chr(13) & "   ,@CEDULA  = " & SCM(TXT_CEDULA.Text)
            CONX_SIC.Coneccion_Abrir()
            Dim DS = CONX_SIC.EJECUTE_DS(SQL)
            CONX_SIC.Coneccion_Cerrar()

            If DS.Tables.Count > 0 Then
                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows
                        If TIPO <> "J" Then
                            TXT_NOMBRE.Text = ITEM("NOMBRE")
                            TXT_PRIMER_APELLIDO.Text = ITEM("APELLIDO1")
                            TXT_SEGUNDO_APELLIDO.Text = ITEM("APELLIDO2")
                        Else
                            TXT_NOMBRE.Text = ITEM("NOMBRE")
                        End If
                        TXT_TELEFONO.Select()
                        Exit For
                    Next
                Else
                    MessageBox.Show("¡Información del número de cédula " & TXT_CEDULA.Text & " no encontrada!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub RELLENAR_GRID()
        Try
            GRID.Rows.Clear()
            GRID.DataSource = Nothing

            GRID.ColumnCount = 6
            GRID.Columns(0).Name = "Tipo"
            GRID.Columns(1).Name = "Documento"
            GRID.Columns(2).Name = "Nombre"
            GRID.Columns(3).Name = "Fecha"
            GRID.Columns(4).Name = "Porcentaje"
            GRID.Columns(5).Name = "Estado"

            Dim SQL = "	SELECT TIPO_DOC, NUMERO_DOC, NOMBRE, CONVERT(VARCHAR(10), GETDATE(), 105) AS FECHA, PORCENTAJE, ESTADO "
            SQL &= Chr(13) & "	FROM CLIENTE_EXONERACION"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND CEDULA = " & SCM(TXT_CEDULA.Text)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

                For Each ITEM In DS.Tables(0).Rows
                    Dim row As String() = New String() {ITEM("TIPO_DOC"), ITEM("NUMERO_DOC"), ITEM("NOMBRE"), ITEM("FECHA"), ITEM("PORCENTAJE"), ITEM("ESTADO")}
                    GRID.Rows.Add(row)
                Next

                Dim btn As New DataGridViewImageColumn()
                Dim img As Image = My.Resources.borrar_button

                GRID.Columns.Add(btn)
                btn.HeaderText = ""
                btn.Name = "Eliminar"
                btn.Width = 32
                btn.Image = img
                btn.ImageLayout = DataGridViewImageCellLayout.Normal
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ACEPTAR_EXO_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR_EXO.Click
        Try
            If CMB_TIPO.SelectedIndex = -1 Then
                MessageBox.Show("Se debe elegir el tipo de documento de la exoneración", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                CMB_TIPO.Select()
            ElseIf String.IsNullOrEmpty(TXT_EXO_NUMERO.Text) Then
                MessageBox.Show("Es necesario ingresar el número de documento de la exoneración", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_EXO_NUMERO.Focus()
            ElseIf String.IsNullOrEmpty(TXT_NOMRE_INSTITUCION.Text) Then
                MessageBox.Show("Es necesario ingresar el nombre de la institución de la exoneración", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_NOMRE_INSTITUCION.Focus()
            ElseIf Val(TXT_PORCENTAJE.Text) <= 0 Then
                MessageBox.Show("El porcentaje de exoneración no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_PORCENTAJE.Focus()
            Else
                Dim SQL = "	INSERT INTO CLIENTE_EXONERACION (COD_CIA,CEDULA,TIPO_DOC,NUMERO_DOC,NOMBRE,FECHA,PORCENTAJE,ESTADO,COD_USUARIO) "
                SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(TXT_CEDULA.Text) & "," & SCM(CMB_TIPO.SelectedItem.ToString.Substring(0, 2))
                SQL &= Chr(13) & "," & SCM(TXT_EXO_NUMERO.Text) & "," & SCM(TXT_NOMRE_INSTITUCION.Text) & "," & SCM(YMDHm(DTPFECHA.Value))
                SQL &= Chr(13) & "," & Val(TXT_PORCENTAJE.Text) & "," & SCM(IIf(RB_EXO_ACTIVO.Checked = True, "A", "I")) & "," & SCM(COD_USUARIO)

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                MessageBox.Show("¡Exoneración ingresada correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                RELLENAR_GRID()
                Limpiar_Exoneracion()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GRID_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles GRID.CellClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 6 Then
                    Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                    Dim valor = MessageBox.Show(Me, "¿Seguro que desea eliminar la exoneración :" + seleccionado.Cells(1).Value.ToString + "?", "Eliminar exoneración", vbYesNo, MessageBoxIcon.Question)

                    If valor = DialogResult.Yes Then

                        Dim SQL = "	DELETE FROM CLIENTE_EXONERACION	"
                        SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                        SQL &= Chr(13) & "	AND CEDULA = " & SCM(TXT_CEDULA.Text)
                        SQL &= Chr(13) & "	AND TIPO_DOC = " & SCM(seleccionado.Cells(0).Value)
                        SQL &= Chr(13) & "	AND NUMERO_DOC = " & SCM(seleccionado.Cells(1).Value)

                        CONX.Coneccion_Abrir()
                        CONX.EJECUTE(SQL)
                        CONX.Coneccion_Cerrar()

                        RELLENAR_GRID()

                        MessageBox.Show(Me, "Exoneración eliminada correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Limpiar_Exoneracion()
        Try
            CMB_TIPO.SelectedIndex = -1
            TXT_EXO_NUMERO.Text = ""
            TXT_NOMRE_INSTITUCION.Text = ""
            TXT_PORCENTAJE.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class