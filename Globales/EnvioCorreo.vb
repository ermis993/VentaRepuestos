Imports System.IO
Imports VentaRepuestos.Globales

Public Class EnvioCorreo
    Public Shared Function Enviar_Proforma(ByVal COD_CIA As String, ByVal COD_SUCUR As String, ByVal NUMERO_DOC As Integer, TIPO_MOV As String, ByVal DESTINATARIO As String, ByVal CLIENTE As String, ByVal NOM_COMPANIA As String) As String
        Try
            Dim CORREO_MALO As String = ""
            Dim Enviado As String = "No"
            Dim Destinatarios As String = QUITAR_TILDES(DESTINATARIO)
            Dim Lista_destinatarios As String() = Destinatarios.Split(New Char() {";"})
            Dim Lista_Correcta As String = ""

            Dim ASUNTO As String = "Proforma Nº " & NUMERO_DOC

            Dim MENSAJE As String = "<p>Estimado cliente: <strong>{NOMBRE_CLIENTE}</strong></p> "
            MENSAJE += "<p>Por este medio<strong> {NOM_COMPANIA}</strong> le desea un excelente d&iacute;a y a su vez le adjunta la informaci&oacute;n relacionada a la proforma solicitada.</p>"
            MENSAJE += "<p>Agradecemos su inter&eacute;s en nuestros productos.</p>"
            MENSAJE += "<p><strong>Le recordamos que este documento tiene una v&aacute;lidez m&aacute;xima de una semana (7 d&iacute;as) desde su fecha de creaci&oacute;n.</strong></p><p>&nbsp;</p>"

            If IsNothing(Destinatarios) = False Then
                CORREO_MALO = ""
                For Each correo As String In Lista_destinatarios
                    If correo.Trim <> "" Then
                        If Not FormatoCorreo(correo.Trim) Then
                            CORREO_MALO = CORREO_MALO + correo.Trim + ";"
                        Else
                            Lista_Correcta = Lista_Correcta + correo.Trim + ";"
                        End If
                    End If
                Next

                If Lista_Correcta.Length > 5 Then
                    Lista_Correcta = Lista_Correcta.Trim().Substring(0, Lista_Correcta.Length - 1)

                    Enviar_Proforma = EnvioProforma(COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV, Lista_Correcta, ASUNTO, MENSAJE, CLIENTE, NOM_COMPANIA)
                Else
                    Throw New Exception("La lista de correos es inválida: " & CORREO_MALO)
                End If

                Return Enviar_Proforma
            End If
        Catch ex As Exception
            Enviar_Proforma = ex.Message
            Return Enviar_Proforma
        End Try
    End Function

    Public Shared Function EnvioProforma(ByVal COD_CIA As String, ByVal COD_SUCUR As String, ByVal NUMERO_DOC As Integer, TIPO_MOV As String,
                                  ByVal Destinatarios As String, ByVal ASUNTO As String, ByVal MENSAJE As String,
                                  ByVal Cliente As String, ByVal COMPANIA As String) As String
        Dim Impresion_doc As Object = Nothing
        Dim Ruta As String = ""
        Try
            Impresion_doc = New Imprime_proforma
            Impresion_doc.SetParameterValue("@COD_CIA", COD_CIA)
            Impresion_doc.SetParameterValue("@COD_SUCUR", COD_SUCUR)
            Impresion_doc.SetParameterValue("@NUMERO_DOC", NUMERO_DOC)
            Impresion_doc.SetParameterValue("@TIPO_MOV", TIPO_MOV)
            Impresion_doc.SummaryInfo.ReportTitle = "Proforma #" & NUMERO_DOC

            Dim Rep As New Reporte(Impresion_doc, , , "SERVICIO LOCAL")
            Rep.Destinatarios = Destinatarios
            Rep.Destinatarios_respuesta = ""

            Dim MENSAJE_FINAL = MENSAJE

            MENSAJE_FINAL = Replace(MENSAJE_FINAL, "{NOMBRE_CLIENTE}", Cliente)
            MENSAJE_FINAL = Replace(MENSAJE_FINAL, "{NOM_COMPANIA}", COMPANIA)

            Rep.Mensaje_Email = MENSAJE_FINAL
            Rep.Preparar_reporte("SERVICIO LOCAL", CONX.vUsuarioSQL, CONX.vContraseñaSQL, CONX.vBase_de_datos, CONX.vServidor)
            Ruta = Rep.Exportar_en_server(RUTA_ADJUNTOS)

            If File.Exists(Ruta) Then
                Dim lista As New List(Of String)
                lista.Add(Ruta)

                EnvioProforma = Enviar_Proforma_Correo(lista, Rep.Destinatarios, True, Rep.Mensaje_Email, ASUNTO.Trim)

                If Ruta <> "" Then
                    File.Delete(Ruta)
                End If

                Return EnvioProforma
            Else
                Throw New Exception("No existe la ruta para el documento #: " & NUMERO_DOC)
            End If
        Catch ex As Exception

            If Ruta <> "" Then
                File.Delete(Ruta)
            End If

            Return ex.Message
        End Try
    End Function

    Public Shared Function Enviar_Proforma_Correo(ByVal Lista_Archivos As List(Of String), Optional ByVal p_Destinatarios As String = "", Optional ByVal Eliminar_adjunto As Boolean = True, Optional ByVal Mensaje_Body As String = "", Optional ByVal Asunto As String = "") As String
        Try
            Dim Listo_para_enviar As Boolean = False
            Dim CREMISARIO_CONFIG = New SMTP_CONFIG

            Dim Destinatarios As String = QUITAR_TILDES(p_Destinatarios)
            Dim Lista_Destin As String() = Destinatarios.Split(New Char() {";"})
            Dim Lista_Correcta As String = ""

            If IsNothing(Destinatarios) = False Then
                For Each correo As String In Lista_Destin
                    If correo.Trim <> "" Then
                        If FormatoCorreo(correo.Trim) Then
                            Lista_Correcta = Lista_Correcta + correo.Trim + ";"
                        End If
                    End If
                Next
                If Lista_Correcta <> "" Then
                    Lista_Correcta = Lista_Correcta.Trim().Substring(0, Lista_Correcta.Length - 1)
                End If
            End If

            If Lista_Correcta <> "" Then

                Dim SERVIDOR_SMTP As String = "", USUARIO_SMTP As String = "", CLAVE_SMTP As String = ""
                Dim PUERTO_SMTP As Integer

                ObtieneInfoSMTP(SERVIDOR_SMTP, PUERTO_SMTP, USUARIO_SMTP, CLAVE_SMTP)

                If String.IsNullOrEmpty(SERVIDOR_SMTP) Then
                    Enviar_Proforma_Correo = "No se encontró la información SMTP"
                Else
                    CREMISARIO_CONFIG.SERVIDOR_SMTP = SERVIDOR_SMTP
                    CREMISARIO_CONFIG.PUERTO = PUERTO_SMTP
                    CREMISARIO_CONFIG.USUARIO = USUARIO_SMTP
                    CREMISARIO_CONFIG.CLAVE = CLAVE_SMTP
                    CREMISARIO_CONFIG.NOMBRE_VISIBLE = ""
                    CREMISARIO_CONFIG.SSL = "S"

                    If Not String.IsNullOrEmpty(CREMISARIO_CONFIG.USUARIO) Then
                        Listo_para_enviar = True
                    End If

                    If Listo_para_enviar = True Then

                        Dim Correo As New CRF_EMAIL.CRF_EMAIL With {
                            .ServidorSmtp = CREMISARIO_CONFIG.SERVIDOR_SMTP,
                            .Puerto = CREMISARIO_CONFIG.PUERTO,
                            .Usuario = CREMISARIO_CONFIG.USUARIO,
                            .Clave = CREMISARIO_CONFIG.CLAVE,
                            .Emisor = New Net.Mail.MailAddress(CREMISARIO_CONFIG.USUARIO, CREMISARIO_CONFIG.NOMBRE_VISIBLE),
                            .OpcionSSL = CREMISARIO_CONFIG.SSL,
                            .Asunto = IIf(String.IsNullOrEmpty(Asunto), "Envío Proforma", Asunto.Trim),
                            .Prioridad = Net.Mail.MailPriority.Normal
                        }

                        For Each Ruta In Lista_Archivos
                            Correo.Adjuntar(Ruta)
                        Next

                        Correo.EsMensajeHTML = True
                        Correo.Mensaje = Trim(Mensaje_Body)

                        Dim Lista_destinatarios = Destinatarios_a_lista(Lista_Correcta)

                        For Each dest As String In Lista_destinatarios
                            Correo.Agregar_destinatario(dest.ToLower())
                        Next

                        If Correo.Enviar() Then
                            If Eliminar_adjunto Then
                                Try
                                    For Each Ruta In Lista_Archivos
                                        File.Delete(Ruta)
                                    Next
                                Catch ex As Exception
                                    Throw ex
                                End Try
                            End If
                            Enviar_Proforma_Correo = "Proforma enviada satisfactoriamente"
                        Else
                            Enviar_Proforma_Correo = "No fue posible envíar la proforma"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class
