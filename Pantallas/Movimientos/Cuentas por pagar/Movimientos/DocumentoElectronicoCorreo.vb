Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class DocumentoElectronicoCorreo

    Dim CLAVE_USAR As String
    Dim CEDULA_USAR As String
    Dim CONSECUTIVO As String

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub

    Sub New()
        InitializeComponent()
        FORMATO_GRID()
    End Sub

    Private Sub FORMATO_GRID()
        GRID.ColumnCount = 4
        GRID.Columns(0).HeaderText = "Proveedor"
        GRID.Columns(0).Name = "NOMBRE"
        GRID.Columns(1).HeaderText = "Cédula"
        GRID.Columns(1).Name = "CEDULA"
        GRID.Columns(2).HeaderText = "Clave"
        GRID.Columns(2).Name = "CLAVE"
        GRID.Columns(3).HeaderText = "Consecutivo"
        GRID.Columns(3).Name = "CONSECUTIVO"
    End Sub

    Public Sub RELLENAR_GRID()
        Try
            If GRID.Columns.Count > 0 Then
                GRID.Rows.Clear()
                GRID.DataSource = Nothing
                Dim SQL = "	SELECT NOMBRE, COR.CEDULA, COR.CLAVE, COR.CONSECUTIVO																									"
                SQL &= Chr(13) & "	FROM CXP_DOCUMENTOS_ELECTRONICOS_CORREO AS COR																									"
                SQL &= Chr(13) & "	LEFT JOIN CXP_DOCUMENTOS_ELECTRONICOS AS CXP_DOC																									"
                SQL &= Chr(13) & "		ON CXP_DOC.COD_CIA = COR.COD_CIA																								"
                SQL &= Chr(13) & "		AND CXP_DOC.CLAVE = COR.CLAVE																								"
                SQL &= Chr(13) & "		AND CXP_DOC.CEDULA = COR.CEDULA																					"
                SQL &= Chr(13) & "	WHERE COR.COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND CXP_DOC.COD_CIA IS NULL		"

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then

                    LBL_CANTIDAD_CORREOS.Text = "Cantidad de documentos pendientes de procesar: " & Val(DS.Tables(0).Rows.Count)

                    For Each ITEM In DS.Tables(0).Rows
                        Dim row As String() = New String() {ITEM("NOMBRE"), ITEM("CEDULA"), ITEM("CLAVE"), ITEM("CONSECUTIVO")}
                        GRID.Rows.Add(row)
                    Next
                Else
                    LBL_CANTIDAD_CORREOS.Text = "Cantidad de documentos pendientes de procesar: " & Val(DS.Tables(0).Rows.Count)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub BTN_PROCESAR_Click(sender As Object, e As EventArgs) Handles BTN_PROCESAR.Click

    '    Dim ImapUsuario As Imap = Nothing

    '    Try
    '        Dim SQL = "	SELECT *	"
    '        SQL &= Chr(13) & "	FROM IMAP_CONFIG "
    '        SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
    '        CONX.Coneccion_Abrir()
    '        Dim DS = CONX.EJECUTE_DS(SQL)
    '        CONX.Coneccion_Cerrar()

    '        If DS.Tables(0).Rows.Count > 0 Then
    '            Dim Calculo As Integer = 0
    '            Dim Cantidad_Registros As Integer = 0
    '            Dim Vueltas As Integer = 0
    '            Dim Cantidad_Documentos As Integer = 0
    '            Dim XML As New XmlDocument
    '            Dim ProcesoXML As Boolean = False

    '            Dim mensaje As String = ""
    '            mensaje &= "¿Seguro que desea realizar el poceso de lectura del correo electrónico?" & vbNewLine
    '            mensaje &= "Este proceso leerá la bandeja de entrada del correo configurado" & vbNewLine
    '            mensaje &= "si posee XMLs sin leer estos será procesados por el sistema"
    '            Dim valor = MessageBox.Show(Me, mensaje, "Lectura correo", vbYesNo, MessageBoxIcon.Question)

    '            If valor = DialogResult.Yes Then

    '                ImapUsuario = MetodosImap.ConectarIMAP(DS.Tables(0).Rows(0).Item("SERVIDOR"), DS.Tables(0).Rows(0).Item("USUARIO"), DS.Tables(0).Rows(0).Item("CONTRASENA"), Val(DS.Tables(0).Rows(0).Item("PUERTO")), True)

    '                If Not IsNothing(ImapUsuario) Then

    '                    ImapUsuario.SelectInbox()
    '                    Dim uids As List(Of Long) = ImapUsuario.Search(Flag.Unseen)

    '                    Cantidad_Registros = uids.Count

    '                    For Each uid As Long In uids
    '                        Vueltas += 1
    '                        Calculo = ((Vueltas * 100) / Cantidad_Registros)
    '                        PB_CARGA.Increment(Calculo)

    '                        Dim eml = ImapUsuario.GetMessageByUID(uid)
    '                        Dim email As IMail = New MailBuilder().CreateFromEml(eml)

    '                        For Each mime As MimeData In email.Attachments
    '                            If Not IsNothing(mime.FileName) Then
    '                                If mime.FileName.Contains(".xml") Then

    '                                    mime.Save(RUTA_ADJUNTOS + "\" + mime.SafeFileName)

    '                                    Dim sr As StreamReader = New StreamReader(RUTA_ADJUNTOS + "\" + mime.SafeFileName)
    '                                    Dim TEXTO As String = sr.ReadToEnd()
    '                                    sr.Close()
    '                                    XML.LoadXml(TEXTO)

    '                                    Try
    '                                        Dim CEDULA_RECEPTOR As String = ""
    '                                        Dim TIPO_MOV As String = ""

    '                                        Dim CLAVE = XML.GetElementsByTagName("Clave").Item(0).InnerXml
    '                                        Dim ACTIVIDAD = XML.GetElementsByTagName("CodigoActividad").Item(0).InnerXml
    '                                        Dim CONSECUTIVO = XML.GetElementsByTagName("NumeroConsecutivo").Item(0).InnerXml
    '                                        Dim NODO_RECEPTOR = XML.GetElementsByTagName("Receptor").Item(0)

    '                                        Dim EMISOR = XML.GetElementsByTagName("Emisor").Item(0)
    '                                        Dim NOMBRE_EMISOR = EMISOR.Item("Nombre").InnerXml
    '                                        Dim CEDULA_EMISOR = EMISOR.Item("Identificacion").Item("Numero").InnerXml

    '                                        If Mid(CONSECUTIVO, 9, 2) = "01" Or Mid(CONSECUTIVO, 9, 2) = "04" Then
    '                                            Select Case XML.GetElementsByTagName("CondicionVenta").Item(0).InnerXml
    '                                                Case "01"
    '                                                    TIPO_MOV = "FC"
    '                                                Case "02"
    '                                                    TIPO_MOV = "FA"
    '                                                Case Else
    '                                                    TIPO_MOV = "FC"
    '                                            End Select
    '                                        ElseIf Mid(CONSECUTIVO, 9, 2) = "02" Then
    '                                            TIPO_MOV = "ND"
    '                                        ElseIf Mid(CONSECUTIVO, 9, 2) = "03" Then
    '                                            TIPO_MOV = "NC"
    '                                        End If

    '                                        If IsNothing(NODO_RECEPTOR) Then
    '                                            CEDULA_RECEPTOR = "00-0000-0000"
    '                                        Else
    '                                            If IsNothing(NODO_RECEPTOR.Item("Identificacion")) Then
    '                                                If IsNothing(NODO_RECEPTOR.Item("IdentificacionExtranjero")) Then
    '                                                    CEDULA_RECEPTOR = "00-0000-0000"
    '                                                Else
    '                                                    CEDULA_RECEPTOR = NODO_RECEPTOR.Item("IdentificacionExtranjero").InnerXml
    '                                                End If
    '                                            Else
    '                                                CEDULA_RECEPTOR = NODO_RECEPTOR.Item("Identificacion").Item("Numero").InnerXml
    '                                            End If
    '                                        End If

    '                                        If Not IsNothing(CLAVE) And Not IsNothing(ACTIVIDAD) Then

    '                                            If VALIDAR(CONSECUTIVO, CEDULA_RECEPTOR, CLAVE, TIPO_MOV, CEDULA_EMISOR) Then

    '                                                SQL = "EXEC	USP_INGRESA_DOCUMENTO_XML_CORREO	"
    '                                                SQL &= Chr(13) & "	 @COD_CIA = " & SCM(COD_CIA)
    '                                                Sql &= Chr(13) & "	,@CLAVE = " & SCM(CLAVE)
    '                                                Sql &= Chr(13) & "	,@CONSECUTIVO = " & SCM(CONSECUTIVO)
    '                                                Sql &= Chr(13) & "	,@CEDULA  = " & SCM(CEDULA_EMISOR)
    '                                                Sql &= Chr(13) & "	,@NOMBRE = 	" & SCM(NOMBRE_EMISOR)
    '                                                Sql &= Chr(13) & "	,@XML = " & SCM(TEXTO)
    '                                                CONX.Coneccion_Abrir()
    '                                                CONX.EJECUTE(Sql)
    '                                                CONX.Coneccion_Cerrar()

    '                                                Cantidad_Documentos += 1
    '                                                ProcesoXML = True
    '                                            End If

    '                                            File.Delete(RUTA_ADJUNTOS + "\" + mime.SafeFileName)
    '                                        End If
    '                                    Catch ex As Exception
    '                                    End Try
    '                                End If
    '                            End If
    '                        Next

    '                        If ProcesoXML = False Then
    '                            ImapUsuario.MarkMessageUnseenByUID(uid)
    '                        End If

    '                        ProcesoXML = False
    '                    Next

    '                    If Cantidad_Documentos > 0 Then
    '                        MessageBox.Show("Se lograron procesar " & Cantidad_Documentos & " de " & Cantidad_Registros & " correos exitosamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        RELLENAR_GRID()
    '                    Else
    '                        MessageBox.Show("Sin correos para procesar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    End If
    '                    MetodosImap.DesconectarImap(ImapUsuario)
    '                    PB_CARGA.Value = 0
    '                End If
    '            End If
    '        Else

    '        End If
    '    Catch ex As Exception
    '        MetodosImap.DesconectarImap(ImapUsuario)
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Function VALIDAR(ByVal CONSECUTIVO As String, ByVal CEDULA_RECEPTOR As String, ByVal CLAVE As String, ByVal TIPO_MOV As String, ByVal CEDULA_EMISOR As String) As Boolean
        Try
            Dim Verificado As Boolean = True

            If Mid(CONSECUTIVO, 9, 2) = "04" Then
                Verificado = False
            ElseIf VALIDAR_CEDULA_RECEPTOR(CEDULA_RECEPTOR) = False Then
                Verificado = False
            ElseIf EXISTE_DOCUMENTO(CLAVE, TIPO_MOV, CEDULA_EMISOR) = True Then
                Verificado = False
            End If

            Return Verificado

        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Function VALIDAR_CEDULA_RECEPTOR(ByVal CEDULA_RECEPTOR As String) As Boolean
        Try
            VALIDAR_CEDULA_RECEPTOR = False

            Dim SQL = "	SELECT * FROM COMPANIA "
            SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND CEDULA    = " & SCM(CEDULA_RECEPTOR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                VALIDAR_CEDULA_RECEPTOR = True
            End If

            Return VALIDAR_CEDULA_RECEPTOR
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function

    Private Function EXISTE_DOCUMENTO(ByVal CLAVE As String, ByVal TIPO_MOV As String, ByVal CEDULA_EMISOR As String) As Boolean
        Try
            EXISTE_DOCUMENTO = False
            Dim Sql = " SELECT ISNULL(RESPUESTA_DGTD,'') AS RESPUESTA_DGTD FROM CXP_DOCUMENTOS_ELECTRONICOS "
            Sql &= Chr(13) & " WHERE COD_CIA = " & SCM(COD_CIA)
            Sql &= Chr(13) & " AND COD_SUCUR = " & SCM(COD_SUCUR)
            Sql &= Chr(13) & " AND CLAVE = " & SCM(CLAVE)
            Sql &= Chr(13) & " AND TIPO_MOV = " & SCM(TIPO_MOV)
            Sql &= Chr(13) & " AND CEDULA = " & SCM(CEDULA_EMISOR)
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(Sql)
            CONX.Coneccion_Cerrar()

            Dim ESTADO As String = ""
            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    ESTADO = ITEM("RESPUESTA_DGTD")
                Next
                If Trim(ESTADO) = "A" Then
                    EXISTE_DOCUMENTO = True
                ElseIf Trim(ESTADO) = "" Then
                    EXISTE_DOCUMENTO = True
                End If
            End If

            Return EXISTE_DOCUMENTO
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub DocumentoElectronicoCorreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RELLENAR_GRID()
    End Sub

    Private Sub GRID_DoubleClick(sender As Object, e As EventArgs) Handles GRID.DoubleClick
        Try
            If Me.GRID.Rows.Count > 0 Then
                Leer_indice()

                Dim mensaje As String = ""
                mensaje &= "¿Desea procesar el documento: " & CONSECUTIVO & "?"
                Dim valor = MessageBox.Show(Me, mensaje, "Lectura correo", vbYesNo, MessageBoxIcon.Question)
                If valor = DialogResult.Yes Then

                    Dim PANTALLA As New DocumentoElectronicoImp(True, CLAVE_USAR)
                    AddHandler PANTALLA.FormClosed, AddressOf Pantalla_Cerrada
                    PANTALLA.ShowDialog()

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Leer_indice()
        Try
            If Me.GRID.Rows.Count > 0 Then
                Dim seleccionado = GRID.Rows(GRID.SelectedRows(0).Index)
                CLAVE_USAR = seleccionado.Cells(2).Value.ToString
                CEDULA_USAR = seleccionado.Cells(1).Value.ToString
                CONSECUTIVO = seleccionado.Cells(3).Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Pantalla_Cerrada(sender As Object, e As FormClosedEventArgs)
        RELLENAR_GRID()
    End Sub
End Class