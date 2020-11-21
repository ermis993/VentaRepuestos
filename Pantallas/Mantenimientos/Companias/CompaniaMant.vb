Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class LBL_CANTON
    Dim COD_C As String = ""
    Dim Respuesta As New DialogResult
    Dim RUTA As String = ""
    Dim CERTIFICADO As Byte()
    Dim MODO As New CRF_Modos
    Dim PADRE As New Compania
    Dim COD_ACT As String = ""

    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Compania, Optional ByVal COD_CIA As String = "")
        InitializeComponent()
        Me.MODO = MODO
        Me.PADRE = PADRE
        Me.COD_C = COD_CIA
    End Sub
    Private Sub CMB_TIPO_CEDULA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_TIPO_CEDULA.SelectedIndexChanged
        Try
            If CMB_TIPO_CEDULA.SelectedIndex = 0 Then 'Física
                TXT_CEDULA.Mask = "#########" '9     
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 1 Then 'Jurídica
                TXT_CEDULA.Mask = "##########" '10
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 2 Then 'Nite
                TXT_CEDULA.Mask = "############" '12
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 3 Then 'Dimex
                TXT_CEDULA.Mask = "##########" '10
            End If
            TXT_CEDULA.PromptChar = "#"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CompaniaMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGAR_PROVINCIAS()
        If MODO = CRF_Modos.Insertar Then
            CMB_TIPO_CEDULA.SelectedIndex = 0
            GENERAR_COD_CIA()
            CHK_FE.Enabled = True
            CHK_ENCOMIENDA.Enabled = True
            GB_ACTIVIDADES.Enabled = False
        ElseIf MODO = CRF_Modos.Modificar Then
            TXT_CODIGO.Text = COD_C
            CMB_TIPO_CEDULA.Enabled = False
            TXT_CEDULA.Enabled = False
            LEER()
            LEER_SMTP()
            REFRESCAR_ACTIVIDADES()
            RellenaImagen(PictureBox1)
        End If
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
    Private Sub CHK_FE_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_FE.CheckedChanged
        Try
            If CHK_FE.Checked = True Then
                TAB_FE.Parent = TAB_COMPANIA
            Else
                TAB_FE.Parent = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GENERAR_COD_CIA()
        Try
            Dim CARACTERES As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
            Dim RND As New Random
            Dim COD_CIA As String = ""
            For i As Integer = 1 To 3
                COD_CIA += CARACTERES.ToCharArray(RND.Next(0, CARACTERES.Length), 1)
            Next
            TXT_CODIGO.Text = COD_CIA
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_SELECCIONAR_Click(sender As Object, e As EventArgs) Handles BTN_SELECCIONAR.Click
        Try
            Dim CERT As Byte() = Nothing

            Dim SQL = "	SELECT ISNULL(CERTIFICADO,0) AS CERTIFICADO "
            SQL &= Chr(13) & "	FROM COMPANIA"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(TXT_CODIGO.Text)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    CERT = ITEM("CERTIFICADO")
                Next
            End If
            If CERT IsNot Nothing AndAlso CERT.Length > 4 Then
                Respuesta = MessageBox.Show(Me, "¡Actualmente existe un certificado importado!" & vbNewLine & "¿Desea importar uno nuevo y eliminar el actual?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Else
                Respuesta = MessageBox.Show(Me, "¿Desea abrir el explorador de archivos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If Respuesta = DialogResult.Yes Then
                OPD_Llave.Title = "Seleccione un archivo"
                OPD_Llave.InitialDirectory = "C:\"
                OPD_Llave.ShowDialog()
                If File.Exists(RUTA) Then
                    CERTIFICADO = Bytes(RUTA)
                    If IsNothing(CERTIFICADO) = False Then

                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub OPD_Llave_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OPD_Llave.FileOk
        Try
            If IsNothing(OPD_Llave.FileName) = False Then
                Dim extension = Path.GetExtension(OPD_Llave.FileName)
                If extension <> ".p12" Then
                    MessageBox.Show("El archivo seleccionado no corresponde a un archivo .p12", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    RUTA = OPD_Llave.FileName
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function Bytes(ByVal PATH As String) As Byte()
        Try
            'Dim cert As New X509Certificate2(PATH, TXT_PIN.Text, X509KeyStorageFlags.PersistKeySet)
            'Dim stringOfCertWithPrivateKey = Convert.ToBase64String(cert.Export(X509ContentType.Cert))

            'Return stringOfCertWithPrivateKey

            'Dim FS As FileStream = File.Open(PATH, FileMode.Open, FileAccess.Read)
            'Dim Archivo(FS.Length) As Byte
            'If FS.Length > 0 Then
            '    FS.Read(Archivo, 0, FS.Length - 1)
            '    FS.Close()
            'End If
            'Return Archivo

            Dim cert = New X509Certificate2(PATH, TXT_PIN.Text, X509KeyStorageFlags.PersistKeySet)
            Dim Data = cert.RawData

            Return Data

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub GUARDAR_CERTIFICADO()
        Try
            If (CERTIFICADO IsNot Nothing AndAlso CERTIFICADO.Length > 4) And TXT_PIN.Text <> "" Then
                Dim COMANDO As New SqlCommand()
                COMANDO.CommandType = CommandType.StoredProcedure
                Dim PIN As New SqlParameter("@PIN", SqlDbType.VarChar)
                PIN.Value = TXT_PIN.Text
                Dim CERT As New SqlParameter("@CERTIFICADO", SqlDbType.VarBinary)
                CERT.Value = CERTIFICADO
                Dim COD_CIA As New SqlParameter("@COD_CIA", SqlDbType.VarChar)
                COD_CIA.Value = TXT_CODIGO.Text

                COMANDO.CommandText = "GUARDAR_CERTIFICADO"
                COMANDO.Parameters.Add(CERT)
                COMANDO.Parameters.Add(PIN)
                COMANDO.Parameters.Add(COD_CIA)

                CONX.Coneccion_Abrir()
                COMANDO.Connection = CONX.Connection
                Dim AR = COMANDO.ExecuteReader()
                AR.Close()
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If MODO = CRF_Modos.Insertar Or MODO = CRF_Modos.Modificar Then
                If VALIDAR() = True Then
                    EJECUTAR()

                    If IsNothing(CERTIFICADO) = False And TXT_PIN.Text <> "" Then
                        GUARDAR_CERTIFICADO()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function VALIDAR() As Boolean
        Try
            Dim ENTRAR As Boolean = False

            If TXT_NOMBRE.Text.ToString.Equals("") Then
                MessageBox.Show("¡Nombre de compañía incorrecto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_NOMBRE.Select()
            ElseIf CMB_TIPO_CEDULA.SelectedIndex = 0 And TXT_CEDULA.Text.Length < 9 Then  'F
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
                MessageBox.Show("¡Ya existe una compañía con la cédula: " & TXT_CEDULA.Text & "!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf TXT_EMAIL.Text.ToString.Equals("") Then
                MessageBox.Show("¡Correo electrónico incorrecto!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_EMAIL.Select()
            ElseIf TXT_DIRECCION.Text.ToString.Equals("") Then
                MessageBox.Show("¡Dirrección incorrecta!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_DIRECCION.Select()
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
            ElseIf IsNothing(CERTIFICADO) = False And TXT_PIN.Text.Equals("") Then
                MessageBox.Show("¡Debe ingresar un PIN válido para el certificado importado!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ENTRAR = True
            End If
            Return ENTRAR
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub LEER()
        Try
            Dim SQL As String = "EXEC USP_COMPANIA_MANT"
            SQL &= Chr(13) & "@COD_CIA = " & SCM(TXT_CODIGO.Text)
            SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Seleccionar)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    TXT_NOMBRE.Text = ITEM("NOMBRE")
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

                    TXT_CEDULA.Text = ITEM("CEDULA")
                    TXT_EMAIL.Text = ITEM("CORREO")
                    TXT_DIRECCION.Text = ITEM("DIRECCION")

                    CMB_PROVINCIA.SelectedValue = ITEM("COD_PROVINCIA")
                    CMB_CANTON.SelectedValue = ITEM("COD_CANTON")
                    CMB_DISTRITO.SelectedValue = ITEM("COD_DISTRITO")

                    TXT_USUARIO_ATV.Text = ITEM("USUARIO_ATV")
                    TXT_CLAVE_ATV.Text = ITEM("CLAVE_ATV")

                    If ITEM("PIN") <> "0" Then
                        TXT_PIN.Text = ITEM("PIN")
                    End If

                    If ITEM("ESTADO") = "A" Then
                        RB_ACTIVA.Checked = True
                    Else
                        RB_INACTIVA.Checked = True
                    End If

                    Dim FE As String = ITEM("FE")
                    Dim ENCOMIENDA As String = ITEM("IND_ENCOMIENDA")

                    If Trim(FE).Equals("S") Then
                        CHK_FE.Checked = True
                    Else
                        CHK_FE.Checked = False
                        TAB_FE.Parent = Nothing
                    End If

                    If Trim(ENCOMIENDA).Equals("S") Then
                        CHK_ENCOMIENDA.Checked = True
                    Else
                        CHK_ENCOMIENDA.Checked = False
                    End If

                    If ITEM("IND_TIPO_DGTD") = "R" Then
                        RB_REAL.Checked = True
                    ElseIf ITEM("IND_TIPO_DGTD") = "P" Then
                        RB_PRUEBAS.Checked = True
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Sub RellenaImagen(ByRef Panel As PictureBox)
        Try
            Dim COMANDO As New SqlCommand With {
                .CommandType = CommandType.Text,
                .CommandText = "SELECT LOGO FROM COMPANIA WHERE COD_CIA = " & SCM(COD_CIA)
            }

            CONX.Coneccion_Abrir()
            COMANDO.Connection = CONX.Connection

            Dim da As New SqlDataAdapter(COMANDO)
            Dim ds As New DataSet()
            da.Fill(ds, "COMPANIA")
            Dim c As Integer = ds.Tables(0).Rows.Count
            If c > 0 Then
                Dim bytBLOBData() As Byte =
                    ds.Tables(0).Rows(c - 1)("LOGO")
                Dim stmBLOBData As New MemoryStream(bytBLOBData)
                Panel.Image = Image.FromStream(stmBLOBData)

            End If
            CONX.Coneccion_Cerrar()

        Catch ex As Exception
            CONX.Coneccion_Cerrar()
        End Try
    End Sub

    Private Sub LEER_SMTP()
        Try
            Dim SQL = "	SELECT *	"
            SQL &= Chr(13) & "	FROM SMTP_CONFIG "
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                TXT_PUERTO.Text = Val(DS.Tables(0).Rows(0).Item("PUERTO"))
                TXT_SERVIDOR.Text = DS.Tables(0).Rows(0).Item("SERVIDOR")
                TXT_USUARIO.Text = DS.Tables(0).Rows(0).Item("USUARIO")
                TXT_CONTRASENA.Text = DS.Tables(0).Rows(0).Item("CONTRASENA")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub EJECUTAR()
        Try
            Dim SQL As String = "EXEC USP_COMPANIA_MANT"
            SQL &= Chr(13) & "@COD_CIA = " & SCM(TXT_CODIGO.Text)
            SQL &= Chr(13) & ",@MODO = " & Val(MODO)
            SQL &= Chr(13) & ",@NOMBRE = " & SCM(TXT_NOMBRE.Text)
            SQL &= Chr(13) & ",@CEDULA = " & SCM(TXT_CEDULA.Text)
            SQL &= Chr(13) & ",@TIPO_CEDULA = " & SCM(CMB_TIPO_CEDULA.Text.ToString.Substring(0, 1).ToUpper)
            SQL &= Chr(13) & ",@CORREO = " & SCM(TXT_EMAIL.Text)
            SQL &= Chr(13) & ",@COD_PROVINCIA = " & SCM(CMB_PROVINCIA.SelectedValue)
            SQL &= Chr(13) & ",@PROVINCIA = " & SCM(CMB_PROVINCIA.Text)
            SQL &= Chr(13) & ",@COD_CANTON = " & SCM(CMB_CANTON.SelectedValue)
            SQL &= Chr(13) & ",@CANTON = " & SCM(CMB_CANTON.Text)
            SQL &= Chr(13) & ",@COD_DISTRITO = " & SCM(CMB_DISTRITO.SelectedValue)
            SQL &= Chr(13) & ",@DISTRITO = " & SCM(CMB_DISTRITO.Text)
            SQL &= Chr(13) & ",@ESTADO = " & SCM(IIf(RB_ACTIVA.Checked = True, "A", "I"))
            SQL &= Chr(13) & ",@FE = " & SCM(IIf(CHK_FE.Checked = True, "S", "N"))
            SQL &= Chr(13) & ",@USUARIO_ATV = " & SCM(TXT_USUARIO_ATV.Text)
            SQL &= Chr(13) & ",@CLAVE_ATV = " & SCM(TXT_CLAVE_ATV.Text)
            SQL &= Chr(13) & ",@DIRECCION = " & SCM(TXT_DIRECCION.Text)
            SQL &= Chr(13) & ",@LINK_FT = " & SCM(LINK_FT.Text)
            SQL &= Chr(13) & ",@LINK_CONSULTAS = " & SCM(LINK_CONSULTAS.Text)

            If RB_REAL.Checked = True Then
                SQL &= Chr(13) & ",@IND_TIPO_DGTD = " & SCM("R")
            ElseIf RB_PRUEBAS.Checked = True Then
                SQL &= Chr(13) & ",@IND_TIPO_DGTD = " & SCM("P")
            End If

            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            If MODO = CRF_Modos.Insertar Then
                LIMPIAR_TODO()
                Actualizar_Imagen_Compania()
                MessageBox.Show("¡Compañía ingresada correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf MODO = CRF_Modos.Modificar Then
                Cerrar()
                Actualizar_Imagen_Compania()
                MessageBox.Show("¡Compañía modificada correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Actualizar_Imagen_Compania()
        Try
            Dim MS As New MemoryStream
            PictureBox1.Image.Save(MS, PictureBox1.Image.RawFormat)

            Dim COMANDO As New SqlCommand()
            COMANDO.CommandType = CommandType.Text
            Dim FOTO As New SqlParameter("@FOTO", SqlDbType.Image)
            FOTO.Value = MS.ToArray()
            Dim COMPANIA As New SqlParameter("@COD_CIA", SqlDbType.VarChar)
            COMPANIA.Value = TXT_CODIGO.Text

            COMANDO.CommandText = "UPDATE COMPANIA SET LOGO = @FOTO WHERE COD_CIA = @COD_CIA"
            COMANDO.Parameters.Add(FOTO)
            COMANDO.Parameters.Add(COMPANIA)

            CONX.Coneccion_Abrir()
            COMANDO.Connection = CONX.Connection
            Dim AR = COMANDO.ExecuteReader()
            AR.Close()
            CONX.Coneccion_Cerrar()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Cerrar()
        Me.Close()
        PADRE.Refrescar()
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub
    Private Sub LIMPIAR_TODO()
        GENERAR_COD_CIA()
        TXT_NOMBRE.Text = ""
        TXT_CEDULA.Text = ""
        CMB_TIPO_CEDULA.SelectedIndex = 0
        TXT_EMAIL.Text = ""
        CMB_PROVINCIA.SelectedIndex = 0
        CHK_FE.Checked = True
        RB_ACTIVA.Checked = True
    End Sub
    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Leer_indice()
        If COD_ACT <> "" Then
            Dim PANTALLA As New ActEconomicaMant(Me, CRF_Modos.Eliminar, TXT_CODIGO.Text, COD_ACT)
            PANTALLA.ShowDialog()
        End If
    End Sub
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Dim PANTALLA As New ActEconomicaMant(Me, CRF_Modos.Insertar, TXT_CODIGO.Text)
        PANTALLA.ShowDialog()
    End Sub
    Public Sub REFRESCAR_ACTIVIDADES()
        Try
            GRID_ACTIVIDADES.DataSource = Nothing
            Dim SQL = "	SELECT COD_ACT as Código,DES_ACT as Descripción,PRINCIPAL as Principal,CONVERT(VARCHAR,FECHA_INC,103) as 'Fecha creación'"
            SQL &= Chr(13) & "	FROM ACTIVIDAD_ECONOMICA"
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(TXT_CODIGO.Text)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()
            If DS.Tables(0).Rows.Count > 0 Then
                GRID_ACTIVIDADES.DataSource = DS.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        MODIFICAR_ACTIVIDAD()
    End Sub
    Private Sub Leer_indice()
        Try
            If Me.GRID_ACTIVIDADES.Rows.Count > 0 Then
                Dim seleccionado = GRID_ACTIVIDADES.Rows(GRID_ACTIVIDADES.SelectedRows(0).Index)
                COD_ACT = seleccionado.Cells(0).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub MODIFICAR_ACTIVIDAD()
        Try
            Leer_indice()
            If COD_ACT <> "" Then
                Dim PANTALLA As New ActEconomicaMant(Me, CRF_Modos.Modificar, TXT_CODIGO.Text, COD_ACT)
                PANTALLA.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GRID_ACTIVIDADES_DoubleClick(sender As Object, e As EventArgs) Handles GRID_ACTIVIDADES.DoubleClick
        MODIFICAR_ACTIVIDAD()
    End Sub
    Private Function EXISTE_CEDULA() As Boolean
        Try
            EXISTE_CEDULA = False
            Dim SQL = "	SELECT * FROM COMPANIA WHERE CEDULA = " & SCM(TXT_CEDULA.Text)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                EXISTE_CEDULA = True
            End If
            Return EXISTE_CEDULA
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub RB_REAL_CheckedChanged(sender As Object, e As EventArgs) Handles RB_REAL.CheckedChanged
        If RB_REAL.Checked = True Then
            LINK_FT.Text = "https://api.comprobanteselectronicos.go.cr/recepcion/v1/recepcion"
            LINK_CONSULTAS.Text = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut/protocol/openid-connect/token"
        End If
    End Sub

    Private Sub RB_PRUEBAS_CheckedChanged(sender As Object, e As EventArgs) Handles RB_PRUEBAS.CheckedChanged
        If RB_PRUEBAS.Checked = True Then
            LINK_FT.Text = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/recepcion"
            LINK_CONSULTAS.Text = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim OPF As New OpenFileDialog With {
                .Filter = "Seleccionar Imagen(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*gif"
            }

            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OPF.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_PROBAR_Click(sender As Object, e As EventArgs) Handles BTN_PROBAR.Click
        Try
            LBL_RESULTADO.Text = ""

            If String.IsNullOrEmpty(TXT_SERVIDOR.Text) Then
                MessageBox.Show("¡Se debe ingresar la información del servidor SMTP!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_SERVIDOR.Select()
            ElseIf String.IsNullOrEmpty(TXT_USUARIO.Text) Then
                MessageBox.Show("¡Se debe ingresar el correo a configurar!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_USUARIO.Select()
            ElseIf String.IsNullOrEmpty(TXT_CONTRASENA.Text) Then
                MessageBox.Show("¡Se debe ingresar la contraseña del correo ingresado!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CONTRASENA.Select()
            ElseIf String.IsNullOrEmpty(TXT_PUERTO.Text) Or Val(TXT_PUERTO.Text) <= 0 Then
                MessageBox.Show("¡Los puertos recomendados son 25, 465, 587 y 2525!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_PUERTO.Select()
            Else
                Dim Valor As String = InputBox("Por favor, ingrese un correo destinatario al cual llegará el mensaje de confirmación", "Ingrese el destinatario")

                If FormatoCorreo(Valor.Trim) Then
                    RealizarPruebaSMTP(Valor.Trim)
                Else
                    Dim respuesta = MessageBox.Show(Me, "Parece que el correo: [" & Valor.Trim & "] tiene un formato incorrecto, ¿Desea continuar con la prueba?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If respuesta = DialogResult.Yes Then
                        RealizarPruebaSMTP(Valor.Trim)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub RealizarPruebaSMTP(Destinatario As String)
        Try

            Dim mensaje As String = "<p style='text-align: justify;'>Este correo tiene la finalidad de corroborar la informaci&oacute;n ingresada en el mantenimiento del servidor SMTP. Al recibir este correo es la confirmaci&oacute;n de la correcta configuraci&oacute;n en dicho mantenimiento.</p>"
            mensaje += "<p style='text-align: justify;'><strong>Nota importante</strong>: Recuerde que si realiza una actualizaci&oacute;n de contrase&ntilde;a, es necesario realizar la actualizaci&oacute;n en el mantenimiento del servidor SMTP en el sistema, ya que presentar&iacute;a problemas en el env&iacute;o de documentos.</p>"
            mensaje += "<p style='text-align: Left;'><strong>-Este mensaje fue realizado por un sistema automatizado, no es necesario responder el mismo-</strong></p>"

            Dim CREMISARIO_CONFIG = New SMTP_CONFIG With {
                .SERVIDOR_SMTP = TXT_SERVIDOR.Text.Trim,
                .PUERTO = Val(TXT_PUERTO.Text),
                .USUARIO = TXT_USUARIO.Text.Trim,
                .CLAVE = TXT_CONTRASENA.Text.Trim,
                .NOMBRE_VISIBLE = "",
                .SSL = "S"
            }

            Dim Correo As New CRF_EMAIL.CRF_EMAIL With {
                          .ServidorSmtp = CREMISARIO_CONFIG.SERVIDOR_SMTP,
                          .Puerto = CREMISARIO_CONFIG.PUERTO,
                          .Usuario = CREMISARIO_CONFIG.USUARIO,
                          .Clave = CREMISARIO_CONFIG.CLAVE,
                          .Emisor = New Net.Mail.MailAddress(CREMISARIO_CONFIG.USUARIO, CREMISARIO_CONFIG.NOMBRE_VISIBLE),
                          .OpcionSSL = CREMISARIO_CONFIG.SSL,
                          .Asunto = "Envío configuración SMTP",
                          .Prioridad = Net.Mail.MailPriority.Normal
                      }

            Correo.EsMensajeHTML = True
            Correo.Mensaje = Trim(mensaje)
            Correo.Agregar_destinatario(Destinatario.ToLower)
            If Correo.Enviar() Then
                LBL_RESULTADO.Text = "¡Configuración realizada exitosamente, en un momento recibirá un correo el destinatario ingresado!"
                LBL_RESULTADO.ForeColor = Color.Navy

                Dim respuesta = MessageBox.Show(Me, "La configuración se realizó correctamente, ¿Desea ingresar los datos?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If respuesta = DialogResult.Yes Then

                    CONX.Coneccion_Abrir()
                    Dim SQL = "	DELETE FROM SMTP_CONFIG WHERE COD_CIA = " & SCM(COD_CIA)
                    CONX.EJECUTE(SQL)

                    SQL &= Chr(13) & "	INSERT INTO SMTP_CONFIG(COD_CIA,SERVIDOR,USUARIO,CONTRASENA,PUERTO)			"
                    SQL &= Chr(13) & "	SELECT " & SCM(COD_CIA) & "," & SCM(TXT_SERVIDOR.Text.Trim) & "," & SCM(TXT_USUARIO.Text.Trim)
                    SQL &= Chr(13) & "," & SCM(TXT_CONTRASENA.Text.Trim) & "," & Val(TXT_PUERTO.Text)
                    CONX.EJECUTE(SQL)
                    CONX.Coneccion_Cerrar()

                    MessageBox.Show("¡Datos configurados correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                LBL_RESULTADO.Text = "¡No fue posible envíar la prueba!"
                LBL_RESULTADO.ForeColor = Color.Red
            End If

        Catch ex As Exception
            LBL_RESULTADO.Text = ex.Message
            LBL_RESULTADO.ForeColor = Color.Red
        End Try
    End Sub

End Class