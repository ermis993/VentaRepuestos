Imports System.Data.SqlClient
Imports System.IO
Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class LBL_CANTON
    Dim COD_CIA As String = ""
    Dim Respuesta As New DialogResult
    Dim RUTA As String = ""
    Dim CERTIFICADO As Byte() = Nothing
    Dim MODO As New CRF_Modos
    Dim PADRE As New Compania
    Dim COD_ACT As String = ""
    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Compania, Optional ByVal COD_CIA As String = "")
        Me.MODO = MODO
        Me.PADRE = PADRE
        Me.COD_CIA = COD_CIA
        InitializeComponent()
    End Sub
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
        CARGAR_PROVINCIAS()
        If MODO = CRF_Modos.Insertar Then
            CMB_TIPO_CEDULA.SelectedIndex = 0
            GENERAR_COD_CIA()
            CHK_FE.Visible = True
        ElseIf MODO = CRF_Modos.Modificar Then
            TXT_CODIGO.Text = COD_CIA
            LEER()
        End If
        REFRESCAR_ACTIVIDADES()
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
    Private Sub CHK_FE_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_FE.CheckedChanged
        If CHK_FE.Checked = True Then
            TAB_FE.Parent = TAB_COMPANIA
        Else
            TAB_FE.Parent = Nothing
        End If
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
        End Try
    End Sub
    Private Sub BTN_SELECCIONAR_Click(sender As Object, e As EventArgs) Handles BTN_SELECCIONAR.Click
        Respuesta = MessageBox.Show("¿Desea abrir el explorador de archivos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
    End Sub
    Private Sub OPD_Llave_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OPD_Llave.FileOk
        If IsNothing(OPD_Llave.FileName) = False Then
            Dim extension = Path.GetExtension(OPD_Llave.FileName)
            If extension <> ".p12" Then
                MessageBox.Show("El archivo seleccionado no corresponde a un archivo .p12", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                RUTA = OPD_Llave.FileName
            End If
        End If
    End Sub
    Private Function Bytes(ByVal PATH As String) As Byte()
        Try
            Dim FS As FileStream = File.Open(PATH, FileMode.Open, FileAccess.Read)
            Dim Archivo(FS.Length) As Byte
            If FS.Length > 0 Then
                FS.Read(Archivo, 0, FS.Length - 1)
                FS.Close()
            End If
            Return Archivo

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub GUARDAR_CERTIFICADO()
        If IsNothing(CERTIFICADO) = False And TXT_PIN.Text <> "" Then

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
    End Sub
    Private Sub GUARDAR_CIA()
        Dim SQL As String = "INSERT INTO COMPANIA(COD_CIA,NOMBRE,CEDULA,TIPO_CEDULA,CORREO,ESTADO,FECHA_INC) VALUES "
        SQL &= Chr(13) & "(" & SCM(TXT_CODIGO.Text) & "," & SCM(TXT_NOMBRE.Text) & "," & SCM(TXT_CEDULA.Text) & "," & SCM("F") & "," & SCM(TXT_EMAIL.Text) & "," & SCM("A") & "," & "GETDATE() " & ")"
        CONX.Coneccion_Abrir()
        CONX.EJECUTE(SQL)
        CONX.Coneccion_Cerrar()
    End Sub
    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If MODO = CRF_Modos.Insertar Or MODO = CRF_Modos.Modificar Then
                If VALIDAR() = True Then
                    EJECUTAR()
                End If
            End If
            'GUARDAR_CIA()
            'GUARDAR_CERTIFICADO()
        Catch ex As Exception

        End Try
    End Sub
    Private Function VALIDAR() As Boolean
        Try
            Dim ENTRAR As Boolean = False

            If TXT_NOMBRE.Text.ToString.Equals("") Then
                MessageBox.Show("¡Nombre de compañía incorrecto!")
                TXT_NOMBRE.Select()
            ElseIf TXT_CEDULA.Text.ToString.Equals("") Then
                MessageBox.Show("¡Cédula incorrecta!")
                TXT_CEDULA.Select()
            ElseIf TXT_EMAIL.Text.ToString.Equals("") Then
                MessageBox.Show("¡Correo electrónico incorrecto!")
                TXT_EMAIL.Select()
            ElseIf CMB_CANTON.Text.Equals("") Then
                MessageBox.Show("¡Cantón incorrecto!")
                CMB_CANTON.Select()
            ElseIf CMB_DISTRITO.Text.Equals("") Then
                MessageBox.Show("¡Distrito incorrecto!")
                CMB_DISTRITO.Select()
            Else
                ENTRAR = True
            End If
            Return ENTRAR
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub LEER()
        Try
            Dim SQL As String = "EXEC COMPANIA_MANT"
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
                    CMB_PROVINCIA.SelectedValue = ITEM("COD_PROVINCIA")
                    CMB_CANTON.SelectedValue = ITEM("COD_CANTON")
                    CMB_DISTRITO.SelectedValue = ITEM("COD_DISTRITO")


                    If ITEM("ESTADO") = "A" Then
                        RB_ACTIVA.Checked = True
                    Else
                        RB_INACTIVA.Checked = True
                    End If

                    Dim FE As String = ITEM("FE")
                    If Trim(FE).Equals("S") Then
                        CHK_FE.Checked = True
                    Else
                        CHK_FE.Checked = False
                        TAB_FE.Parent = Nothing
                    End If

                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub EJECUTAR()
        Dim SQL As String = "EXEC COMPANIA_MANT"
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
        CONX.Coneccion_Abrir()
        CONX.EJECUTE(SQL)
        CONX.Coneccion_Cerrar()
        If MODO = CRF_Modos.Insertar Then
            LIMPIAR_TODO()
            MessageBox.Show("¡Compañía ingresada correctamente!")
        ElseIf MODO = CRF_Modos.Modificar Then
            Cerrar()
            MessageBox.Show("¡Compañía modificada correctamente!")
        End If
    End Sub

    Private Sub Cerrar()
        Dim PANTALLA As New Compania
        Me.Close()
        PANTALLA.ShowDialog()
        PANTALLA.Refrescar()
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub LIMPIAR_TODO()
        GENERAR_COD_CIA()
        TXT_NOMBRE.Text = ""
        TXT_CEDULA.Text = ""
        CMB_TIPO_CEDULA.SelectedIndex = 0
        TXT_TELEFONO.Text = ""
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
        GRID_ACTIVIDADES.DataSource = Nothing
        Dim SQL = "	SELECT COD_ACT,DES_ACT,PRINCIPAL,FECHA_INC"
        SQL &= Chr(13) & "	FROM ACTIVIDAD_ECONOMICA"

        CONX.Coneccion_Abrir()
        Dim DS = CONX.EJECUTE_DS(SQL)
        CONX.Coneccion_Cerrar()

        If DS.Tables(0).Rows.Count > 0 Then
            GRID_ACTIVIDADES.DataSource = DS.Tables(0)
        End If
    End Sub

    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        MODIFICAR_ACTIVIDAD()
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID_ACTIVIDADES.Rows.Count > 0 Then
                Dim INDICE As DataGridViewCellCollection
                INDICE = GRID_ACTIVIDADES.SelectedRows.Item(0).Cells
                If IsNothing(INDICE) = False Then
                    COD_ACT = INDICE.Item("COD_ACT").Value
                End If
            End If
        Catch ex As Exception

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

        End Try
    End Sub
    Private Sub GRID_ACTIVIDADES_DoubleClick(sender As Object, e As EventArgs) Handles GRID_ACTIVIDADES.DoubleClick
        MODIFICAR_ACTIVIDAD()
    End Sub
End Class