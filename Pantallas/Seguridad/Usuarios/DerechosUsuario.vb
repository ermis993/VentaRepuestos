Imports System.Text
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class DerechosUsuario
    Dim COD_USUARIO As String = ""
    Public Shared DT_SISTEMAS As New DataTable
    Sub New(Optional ByVal COD_USUARIO As String = "")
        InitializeComponent()
        Me.COD_USUARIO = COD_USUARIO
    End Sub
    Private Sub DerechosUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LVCon.Columns.Add("Lista de derechos", 321)
        LVSin.Columns.Add("Lista de derechos", 321)
        INICIAR_DT()
        Cargar_Derechos()
    End Sub

    Public Sub Cargar_Derechos()
        Try
            LVCon.Items.Clear()
            LVSin.Items.Clear()

            Dim SQL = "	SELECT D.COD_DERECHO,D.DESCRIPCION, CASE WHEN ISNULL(U.COD_USUARIO,'')='' THEN 'N' ELSE 'S' END AS CONTIENE "
            SQL &= Chr(13) & "	FROM SEGU_DERECHO AS D"
            SQL &= Chr(13) & "	LEFT JOIN USUARIO_DERECHO AS U"
            SQL &= Chr(13) & "	ON D.COD_DERECHO = U.COD_DERECHO"
            SQL &= Chr(13) & "	AND U.COD_CIA= " & SCM(COD_CIA)
            SQL &= Chr(13) & "	AND U.COD_USUARIO= " & SCM(COD_USUARIO)
            SQL &= Chr(13) & "  WHERE D.ESTADO = 'A'"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    Dim LVI As New ListViewItem
                    If ITEM("CONTIENE") = "S" Then
                        LVI.Text = ITEM("DESCRIPCION")
                        LVI.Name = ITEM("COD_DERECHO")
                        LVCon.Items.Add(LVI)
                    Else
                        LVI.Text = ITEM("DESCRIPCION")
                        LVI.Name = ITEM("COD_DERECHO")
                        LVSin.Items.Add(LVI)
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
    Public Shared Sub INICIAR_DT()
        Try
            DT_SISTEMAS = New DataTable
            DT_SISTEMAS.Columns.Add(New DataColumn("COD_DERECHO", System.Type.GetType("System.String")))

            Dim PK(1) As DataColumn
            PK(1) = DT_SISTEMAS.Columns("COD_DERECHO")
            DT_SISTEMAS.PrimaryKey = PK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LVSin_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LVSin.MouseDoubleClick
        Try
            If Not LVSin.FocusedItem Is Nothing Then
                Dim LVI As ListViewItem = LVSin.FocusedItem
                Dim INDICE = LVI.Index
                LVSin.Items.Remove(LVI)
                LVCon.Items.Add(LVI)

                If LVSin.Items.Count > INDICE Then
                    LVSin.Items(INDICE).Selected = True
                    LVSin.Items(INDICE).Focused = True

                ElseIf LVSin.Items.Count = 0 And INDICE = 0 Then

                ElseIf LVSin.Items.Count = INDICE Then
                    LVSin.Items(INDICE - 1).Selected = True
                    LVSin.Items(INDICE - 1).Focused = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub LVCon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LVCon.MouseDoubleClick
        Try
            If Not LVCon.FocusedItem Is Nothing Then
                Dim LVI As ListViewItem = LVCon.FocusedItem
                Dim INDICE = LVI.Index
                LVCon.Items.Remove(LVI)
                LVSin.Items.Add(LVI)
                LVSin.FocusedItem = LVI

                If LVCon.Items.Count > INDICE Then
                    LVCon.Items(INDICE).Selected = True
                    LVCon.Items(INDICE).Focused = True
                ElseIf LVCon.Items.Count = 0 And INDICE = 0 Then

                ElseIf LVCon.Items.Count = INDICE Then
                    LVCon.Items(INDICE - 1).Selected = True
                    LVCon.Items(INDICE - 1).Focused = True
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            If Not LVSin.FocusedItem Is Nothing Then
                Dim LVI As ListViewItem = LVSin.FocusedItem
                Dim INDICE = LVI.Index
                LVSin.Items.Remove(LVI)
                LVCon.Items.Add(LVI)
                LVCon.FocusedItem = LVI

                If LVSin.Items.Count > INDICE Then
                    LVSin.Items(INDICE).Selected = True
                    LVSin.Items(INDICE).Focused = True
                ElseIf LVSin.Items.Count = 0 And INDICE = 0 Then

                ElseIf LVSin.Items.Count = INDICE Then
                    LVSin.Items(INDICE - 1).Selected = True
                    LVSin.Items(INDICE - 1).Focused = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_QUITAR_Click(sender As Object, e As EventArgs) Handles BTN_QUITAR.Click
        If Not LVCon.FocusedItem Is Nothing Then
            Dim LVI As ListViewItem = LVCon.FocusedItem
            Dim INDICE = LVI.Index
            LVCon.Items.Remove(LVI)
            LVSin.Items.Add(LVI)
            LVSin.FocusedItem = LVI

            If LVCon.Items.Count > INDICE Then
                LVCon.Items(INDICE).Selected = True
                LVCon.Items(INDICE).Focused = True
            ElseIf LVCon.Items.Count = 0 And INDICE = 0 Then

            ElseIf LVCon.Items.Count = INDICE Then
                LVCon.Items(INDICE - 1).Selected = True
                LVCon.Items(INDICE - 1).Focused = True
            End If
        End If
    End Sub
    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            Dim EDITO As Boolean = False
            For Each ITEM In DT_SISTEMAS.Rows
                Dim SQL = "	DELETE U"
                SQL &= Chr(13) & "	FROM USUARIO_DERECHO U"
                SQL &= Chr(13) & "	INNER JOIN SEGU_DERECHO AS D"
                SQL &= Chr(13) & "	ON U.COD_DERECHO = D.COD_DERECHO"
                SQL &= Chr(13) & "	WHERE D.COD_SISTEMA = " & SCM(ITEM("SISTEMA"))
                SQL &= Chr(13) & "	AND U.COD_USUARIO = " & SCM(COD_USUARIO)
                SQL &= Chr(13) & "	AND U.COD_CIA = " & SCM(COD_CIA)
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                EDITO = True
            Next

            If LVCon.Items.Count > 0 Then

                Dim SQL = "	DELETE FROM USUARIO_DERECHO"
                SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND COD_USUARIO = " & SCM(COD_USUARIO)
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                SQL = "	INSERT INTO USUARIO_DERECHO(COD_CIA,COD_DERECHO,COD_USUARIO)"
                Dim ULTIMO As Integer = LVCon.Items.Count - 1
                Dim CANTIDAD As Integer = 0
                For Each LVI In LVCon.Items
                    SQL &= Chr(13) & "SELECT " & SCM(COD_CIA) & "," & SCM(LVI.Name) & "," & SCM(COD_USUARIO)
                    If CANTIDAD < ULTIMO Then
                        SQL &= Chr(13) & "UNION ALL"
                    End If
                    CANTIDAD += 1
                Next
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                EDITO = True
            End If

            If EDITO = True Then
                MessageBox.Show("¡Derechos actualizados correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TODOS_CON_Click(sender As Object, e As EventArgs) Handles TODOS_CON.Click
        Try
            For Each LVI In LVSin.Items

                Dim LVIT As ListViewItem = LVI
                LVSin.Items.Remove(LVIT)
                LVCon.Items.Add(LVIT)

                LVCon.Items(0).Selected = True
                LVCon.Items(0).Focused = True
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TODOS_SIN_Click(sender As Object, e As EventArgs) Handles TODOS_SIN.Click
        Try
            For Each LVI In LVCon.Items

                Dim LVIT As ListViewItem = LVI
                LVCon.Items.Remove(LVIT)
                LVSin.Items.Add(LVIT)

                LVSin.Items(0).Selected = True
                LVSin.Items(0).Focused = True
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_INCLUIR_Click(sender As Object, e As EventArgs) Handles BTN_INCLUIR.Click
        Try
            Dim PANTALLA As New DerechosUsuarioMant(Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class