Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Text
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class Reporte
    Public Enum Crystal_Salida
        CR_Pantalla
        CR_Email
        CR_Opciones
        CR_Emisario
        CR_Exportar_en_server
        CR_Descarga_directa
    End Enum


#Region "Propiedades"

    Public Property Obj_Reporte As ReportClass
    Public Property Parametros As List(Of CrystalDecisions.Shared.ParameterField)
        Get
            Dim lista_parametros As New List(Of CrystalDecisions.Shared.ParameterField)
            For Each par As CrystalDecisions.Shared.ParameterField In Obj_Reporte.ParameterFields
                lista_parametros.Add(par)
            Next
            Return lista_parametros
        End Get
        Set(ByVal value As List(Of CrystalDecisions.Shared.ParameterField))
            For Each par As CrystalDecisions.Shared.ParameterField In value
                'Obj_Reporte.ParameterFields.Add(par)
                Obj_Reporte.SetParameterValue(par.Name, par.CurrentValues(0))
            Next
        End Set
    End Property
    Public Property ID_Reporte As Long
    Public Property Tipo_Salida As Crystal_Salida
    Private Property Formato As ExportFormatType
    Public Property Record_selection_Formula As String = ""


    Public Property Lista_parametros As New List(Of Str_Parametro)
    Public Lista_Formulas As New List(Of Str_Parametro)
    Public Property Titulo_reporte As String


#End Region

#Region "Constructores"

    Sub New(ByVal pReporte As ReportClass, Optional ByVal Tipo_salida As Crystal_Salida = Crystal_Salida.CR_Opciones, Optional ByVal Record_selection_Formula As String = "", Optional ByVal SISTEMA As String = "")
        Me.Obj_Reporte = pReporte
        Me.Tipo_Salida = Tipo_salida
        Almacenar_parametros()
        Me.Record_selection_Formula = Record_selection_Formula
        Titulo_reporte = Me.Obj_Reporte.SummaryInfo.ReportTitle
    End Sub


#End Region


#Region "Funciones"

    Public Property Mensaje_Email As String
    Public Property Destinatarios As String

    Private Property Ruta_archivo_exportado As String

    Public Property Destinatarios_respuesta As String

    Property asunto As String

    ''' <summary>
    ''' Prepara el reporte, loguea las tablas, lee los parámetros, etc
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Preparar_reporte(Optional ByVal SISTEMA As String = "", Optional ByVal LOGIN As String = "", Optional ByVal PASSWOR As String = "", Optional ByVal DATABASE As String = "", Optional ByVal SERVER As String = "")
        Try
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            Dim serverName1 As String = ""
            Dim userID As String = ""
            Dim password As String = ""

            If SISTEMA = "SERVICIO LOCAL" Then
                Obj_Reporte.SetDatabaseLogon(Trim(LOGIN), Trim(PASSWOR), Trim(SERVER), Trim(DATABASE), True)
                Obj_Reporte.SummaryInfo.ReportAuthor = SISTEMA
                Obj_Reporte.SummaryInfo.ReportTitle = Me.Titulo_reporte
                With crConnectionInfo
                    .ServerName = SERVER
                    .DatabaseName = DATABASE
                    .UserID = LOGIN
                    .Password = PASSWOR
                End With
                CrTables = Obj_Reporte.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                serverName1 = SERVER
                userID = LOGIN
                password = PASSWOR
            Else
                Obj_Reporte.SetDatabaseLogon(Trim(LOGIN), Trim(PASSWOR), Trim(SERVER), Trim(DATABASE), True)
                Obj_Reporte.SummaryInfo.ReportAuthor = "SERVICIO"
                Obj_Reporte.SummaryInfo.ReportTitle = Me.Titulo_reporte
                With crConnectionInfo
                    .ServerName = SERVER
                    .DatabaseName = DATABASE
                    .UserID = LOGIN
                    .Password = PASSWOR
                End With
                CrTables = Obj_Reporte.Database.Tables
                For Each CrTable In CrTables
                    crtableLogoninfo = CrTable.LogOnInfo
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo
                    CrTable.ApplyLogOnInfo(crtableLogoninfo)
                Next
                serverName1 = SERVER
                userID = LOGIN
                password = PASSWOR
            End If


            ' Set Database Logon to main report
            For Each connection In Obj_Reporte.DataSourceConnections
                Select Case connection.ServerName
                    Case serverName1
                        connection.SetLogon(userID, password)
                End Select
            Next
            ' Set Database Logon to subreport
            For Each subreport In Obj_Reporte.Subreports
                For Each connection In subreport.DataSourceConnections
                    Select Case connection.ServerName
                        Case serverName1
                            connection.SetLogon(userID, password)
                    End Select
                Next
            Next
            Obj_Reporte.RecordSelectionFormula = Me.Record_selection_Formula
            Asignar_valores_de_parametros()
            Asignar_valores_de_Formulas()

        Catch ex As Exception
        End Try
    End Sub



#End Region


    Public Function Exportar_en_server(Optional ByVal RUTA As String = "") As String
        Try

            Dim dFileDOpts = New DiskFileDestinationOptions()
            Dim sDesPath As String
            ' Generate unique name for output file
            Dim Nombre_archivo As String = Trim(Me.Titulo_reporte) & "_ID_" & Format((Rnd() * 100), "000")

            Dim sFileName = New StringBuilder(Nombre_archivo)

            sFileName.Replace(" ", "_")
            sFileName.Replace(":", "_")
            sFileName.Replace("/", "")
            sFileName.Replace(".", "")
            sFileName.Replace("#", "")
            sFileName.Replace("á", "a")
            sFileName.Replace("é", "e")
            sFileName.Replace("í", "i")
            sFileName.Replace("ó", "o")
            sFileName.Replace("ú", "u")
            sFileName.Replace("Ñ", "N")
            sFileName.Replace("ñ", "n")

            Dim sResultFileName = sFileName.ToString()

            sDesPath = RUTA + "\" + sResultFileName

            Dim extension = ".PDF"

            If File.Exists(sDesPath + extension) = True Then
                sDesPath &= "_" & Val(Rnd().ToString)
            End If

            sDesPath = Replace(sDesPath, extension, "")

            sDesPath = Replace(sDesPath, """", "")

            sDesPath &= extension 'aquí si le tiene que poner extension

            dFileDOpts.DiskFileName = sDesPath

            Dim eOpts = New ExportOptions()
            eOpts = Obj_Reporte.ExportOptions
            eOpts.ExportDestinationType = ExportDestinationType.DiskFile
            eOpts.ExportFormatType = 5
            eOpts.DestinationOptions = dFileDOpts

            Obj_Reporte.Export(eOpts)
            Obj_Reporte.Close()
            Obj_Reporte.Dispose()
            Me.Ruta_archivo_exportado = sDesPath
            Return sDesPath
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function



    Private Sub Almacenar_parametros()
        Try
            Lista_parametros.Clear()
            For Each par As CrystalDecisions.Shared.ParameterField In Obj_Reporte.ParameterFields
                If par.HasCurrentValue = True Then
                    Dim parx As New Str_Parametro()
                    parx.Nombre = par.Name
                    parx.Valor = par.CurrentValues(0)
                    parx.Tipo = par.ParameterValueType()
                    Lista_parametros.Add(parx)
                End If
            Next par
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Asignar_valores_de_parametros()
        For Each parx As Str_Parametro In Lista_parametros
            Try
                If (parx.Nombre_Subreporte = "") Then
                    Obj_Reporte.SetParameterValue(parx.Nombre, parx.Valor)
                Else
                    Obj_Reporte.SetParameterValue(parx.Nombre, parx.Valor, parx.Nombre_Subreporte)
                    Obj_Reporte.SetParameterValue(parx.Nombre, parx.Valor)
                End If
            Catch ex As Exception
                'hacerse el ruso
            End Try
        Next parx
    End Sub

    Private Sub Asignar_valores_de_Formulas()
        Try
            If Not IsNothing(Lista_Formulas) Then
                Dim Ms_error As String = ""
                Obj_Reporte.DataDefinition.FormulaFields.Reset()
                For Each Formula In Lista_Formulas

                    If Trim(Formula.Nombre) <> "" Then
                        Try
                            Dim Sintaxis As String
                            If (IsNothing(Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text) = False) Then
                                Sintaxis = IIf(InStr(Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text.ToUpper, "FORMULA") > 0, "BASIC", "CRYSTAL")
                            Else
                                Sintaxis = IIf(InStr(Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text, "formula") > 0, "BASIC", "CRYSTAL")
                            End If

                            If Sintaxis = "BASIC" Then
                                If IsDate(Formula.Valor) Then
                                    Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text = "formula =#" & Formula.Valor & "#"

                                ElseIf IsNumeric(Formula.Valor) And Formula.Tipo <> "T" Then
                                    Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text = "formula =" & FMC(Formula.Valor, 4)
                                Else
                                    'segun basic syntax
                                    Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text = "formula =" & """" & Trim(Formula.Valor.ToString) & """"
                                    If Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Check(Ms_error) = False Then
                                        Throw New Exception(Ms_error)
                                    End If
                                End If
                            Else
                                If IsDate(Formula.Valor) Then
                                    Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text = "#" & Formula.Valor & "#"
                                ElseIf IsNumeric(Formula.Valor) And Formula.Tipo <> "T" Then
                                    Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text = FMC(Formula.Valor, 4)
                                Else
                                    'segun basic syntax
                                    If (Trim(Formula.Valor.ToString) = "") Then
                                        Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text = "" & Trim(Formula.Valor.ToString) & ""
                                    Else
                                        Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Text = """" & Trim(Formula.Valor.ToString) & """"
                                    End If
                                    If Obj_Reporte.DataDefinition.FormulaFields.Item(Formula.Nombre).Check(Ms_error) = False Then
                                        Throw New Exception(Ms_error)
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next Formula
            End If
        Catch ex As Exception
            Throw New Exception("¡Error asignando las formulas!" & Chr(13) & ex.Message)
        End Try
    End Sub

    Public Sub Eliminar_Reporte_Temp()
        Try
            If Not IsDBNull(Me.Obj_Reporte) And Me.Obj_Reporte.IsLoaded Then
                'crystal.Dispose()
                'crystal = Nothing
                Me.Obj_Reporte.Close()
                Me.Obj_Reporte.Dispose()
            End If
            GC.Collect()
        Catch ex As Exception

        End Try
    End Sub

End Class

Public Class Str_Parametro
    Public Property Nombre As String
    Public Property Valor As Object
    Public Property Tipo As String
    Public Property Nombre_Subreporte As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal Nombre As String, ByVal Valor As Object, Optional ByVal Tipo As String = "T", Optional ByVal Nombre_Subreporte As String = "")
        Me.Nombre = Nombre
        Me.Valor = Valor
        Me.Tipo = Tipo
        Me.Nombre_Subreporte = Nombre_Subreporte
    End Sub

End Class
