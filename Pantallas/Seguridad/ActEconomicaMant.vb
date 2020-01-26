Imports System.Data.SqlClient
Imports System.IO
Imports CRF_CONEXIONES.CONEXIONES
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class ActEconomicaMant
    Dim PADRE As LBL_CANTON
    Dim COD_CIA As String = ""
    Dim MODO As CRF_Modos
    Dim COD_ACT As String = ""
    Sub New(ByVal PADRE As LBL_CANTON, ByVal MODO As CRF_Modos, ByVal COD_CIA As String, Optional ByVal COD_ACT As String = "")
        InitializeComponent()
        Me.MODO = MODO

        Me.COD_CIA = COD_CIA
        Me.COD_ACT = COD_ACT
        Me.PADRE = PADRE
    End Sub
    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        If VALIDAR() = True Then
            If MODO = CRF_Modos.Insertar Then
                INSERTAR()
            ElseIf MODO = CRF_Modos.Modificar Then
                MODIFICAR()
            ElseIf MODO = CRF_Modos.Eliminar Then
                EJECUTAR()
            End If
        End If
    End Sub
    Private Sub ActEconomicaMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MODO = CRF_Modos.Modificar Then
            TXT_COD_ACT.ReadOnly = True
            Leer()
        ElseIf MODO = CRF_Modos.Eliminar Then
            TXT_COD_ACT.ReadOnly = True
            TXT_DES_ACT.ReadOnly = True
            CK_PRINCIPAL.Enabled = False
            Leer()
        End If
    End Sub
    Private Sub Leer()
        Dim SQL As String = "EXECUTE ACTIVIDAD_ECONOMICA_MANT "
        SQL &= Chr(13) & "@COD_CIA = " & SCM(COD_CIA)
        SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Seleccionar)
        SQL &= Chr(13) & ",@COD_ACT = " & SCM(COD_ACT)

        CONX.Coneccion_Abrir()
        Dim DS = CONX.EJECUTE_DS(SQL)
        CONX.Coneccion_Cerrar()

        If DS.Tables(0).Rows.Count > 0 Then
            For Each ITEM In DS.Tables(0).Rows
                TXT_COD_ACT.Text = ITEM("COD_ACT")
                TXT_DES_ACT.Text = ITEM("DES_ACT")

                Dim CK As String = ITEM("PRINCIPAL")

                If Trim(CK).Equals("S") Then
                    CK_PRINCIPAL.Checked = True
                Else
                    CK_PRINCIPAL.Checked = False
                End If
            Next
        End If
    End Sub
    Private Function VALIDAR() As Boolean
        Try
            Dim ENTRAR As Boolean = False
            If TXT_COD_ACT.Text.Equals("") Then
                MessageBox.Show("Error en el código de actividad")
                TXT_COD_ACT.Select()
            ElseIf TXT_DES_ACT.Text.Equals("") Then
                MessageBox.Show("Error en la descripción de actividad")
                TXT_DES_ACT.Select()
            Else
                ENTRAR = True
            End If
            Return ENTRAR
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub INSERTAR()
        Dim SQL As String = "SELECT * FROM ACTIVIDAD_ECONOMICA "
        SQL &= Chr(13) & "WHERE COD_CIA = " & SCM(COD_CIA)
        SQL &= Chr(13) & "AND COD_ACT = " & SCM(TXT_COD_ACT.Text)
        CONX.Coneccion_Abrir()
        Dim DS = CONX.EJECUTE_DS(SQL)
        CONX.Coneccion_Cerrar()

        If DS.Tables(0).Rows.Count > 0 Then
            MessageBox.Show("Ya existe una actividad económica con el código " & TXT_COD_ACT.Text)
        Else
            EJECUTAR()
        End If
    End Sub
    Private Sub MODIFICAR()
        EJECUTAR()
    End Sub
    Private Sub LIMPIAR()
        TXT_COD_ACT.Text = ""
        TXT_DES_ACT.Text = ""
        CK_PRINCIPAL.Checked = False
    End Sub
    Private Sub EJECUTAR()
        Dim Sql = "EXECUTE ACTIVIDAD_ECONOMICA_MANT "
        Sql &= Chr(13) & "@COD_CIA = " & SCM(COD_CIA)
        Sql &= Chr(13) & ",@MODO = " & SCM(MODO)
        Sql &= Chr(13) & ",@COD_ACT = " & SCM(TXT_COD_ACT.Text)
        Sql &= Chr(13) & ",@DES_ACT = " & SCM(TXT_DES_ACT.Text)
        Sql &= Chr(13) & ",@PRINCIPAL = " & SCM(IIf(CK_PRINCIPAL.Checked = True, "S", "N"))
        CONX.Coneccion_Abrir()
        CONX.EJECUTE(Sql)
        CONX.Coneccion_Cerrar()
        If MODO = CRF_Modos.Insertar Then
            MessageBox.Show("Actividad económica agregada correctamente")
            LIMPIAR()
        ElseIf MODO = CRF_Modos.Modificar Then
            MessageBox.Show("Actividad económica modificada correctamente")
            CERRAR()
        ElseIf MODO = CRF_Modos.Eliminar Then
            MessageBox.Show("Actividad económica eliminada correctamente")
            CERRAR()
        End If
    End Sub
    Private Sub ELIMINAR()
        EJECUTAR()
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        CERRAR()
    End Sub
    Private Sub CERRAR()
        Me.Close()
        PADRE.REFRESCAR_ACTIVIDADES()
    End Sub
End Class