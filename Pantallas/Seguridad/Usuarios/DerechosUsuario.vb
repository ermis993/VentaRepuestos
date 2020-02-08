Imports System.Text
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class DerechosUsuario
    Dim COD_USUARIO As String = ""
    Public Shared DT_SISTEMAS As New DataTable
    Sub New(ByVal COD_USUARIO As String)
        InitializeComponent()
        Me.COD_USUARIO = COD_USUARIO
    End Sub
    Private Sub DerechosUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGAR_CHECK_BOXES()
        LVCon.Columns.Add("Lista de derechos", 321)
        LVSin.Columns.Add("Lista de derechos", 321)
        INICIAR_DT()
    End Sub
    Private Sub CARGAR_CHECK_BOXES()
        Try
            Dim SQL = "	SELECT DISTINCT(COD_SISTEMA) AS COD_SISTEMA FROM SEGU_DERECHO ORDER BY COD_SISTEMA ASC"
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then

                Dim LARGO = 12
                Dim ALTO = 12
                Dim CANTIDAD_EN_LINEA = 0

                For Each ITEM In DS.Tables(0).Rows

                    If CANTIDAD_EN_LINEA = 5 Then
                        ALTO += 40
                        LARGO = 12
                        CANTIDAD_EN_LINEA = 0
                    End If

                    Dim checkBox = New CheckBox()
                    checkBox.Location = New Point(LARGO, ALTO)
                    checkBox.Text = ITEM("COD_SISTEMA")
                    checkBox.Tag = ITEM("COD_SISTEMA")
                    checkBox.Size = New Size(100, 20)
                    AddHandler checkBox.CheckedChanged, AddressOf CBX_CheckedChanged
                    Controls.Add(checkBox)
                    LARGO += 124
                    CANTIDAD_EN_LINEA += 1
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CBX_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim CHK As CheckBox = DirectCast(sender, CheckBox) 'Use DirectCast to cast the sender into a checkbox

            If CHK.Checked = True Then
                Dim SQL = "	SELECT D.COD_SISTEMA,D.COD_DERECHO,D.DESCRIPCION, CASE WHEN ISNULL(U.COD_USUARIO,'')='' THEN 'N' ELSE 'S' END AS CONTIENE "
                SQL &= Chr(13) & "	FROM SEGU_DERECHO AS D"
                SQL &= Chr(13) & "	LEFT JOIN USUARIO_DERECHO AS U"
                SQL &= Chr(13) & "	ON D.COD_DERECHO = U.COD_DERECHO"
                SQL &= Chr(13) & "	AND U.COD_CIA= " & SCM(COD_CIA)
                SQL &= Chr(13) & "	AND U.COD_USUARIO= " & SCM(COD_USUARIO)
                SQL &= Chr(13) & "	WHERE D.COD_SISTEMA = " & SCM(CHK.Text)

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    AGREGAR_A_DT(CHK.Text)
                    For Each ITEM In DS.Tables(0).Rows

                        Dim LVI As New ListViewItem
                        If ITEM("CONTIENE") = "S" Then
                            LVI.Text = ITEM("DESCRIPCION")
                            LVI.Name = ITEM("COD_DERECHO")
                            LVI.Tag = ITEM("COD_SISTEMA")
                            LVCon.Items.Add(LVI)
                        Else
                            LVI.Text = ITEM("DESCRIPCION")
                            LVI.Name = ITEM("COD_DERECHO")
                            LVI.Tag = ITEM("COD_SISTEMA")
                            LVSin.Items.Add(LVI)
                        End If
                    Next
                End If
            Else
                'ELIMINAR  DE LISTA SIN
                For Each LVI In LVSin.Items
                    If LVI.TAG = CHK.Text.ToString Then
                        LVSin.Items.Remove(LVI)
                    End If
                Next
                'ELIMINAR DE LISTA CON
                For Each LVI In LVCon.Items
                    If LVI.TAG = CHK.Text.ToString Then
                        LVCon.Items.Remove(LVI)
                    End If
                Next

                For Each FILA In DT_SISTEMAS.Rows
                    If FILA("SISTEMA") = CHK.Text.ToString Then
                        DT_SISTEMAS.Rows.Remove(FILA)
                        Exit For
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
            DT_SISTEMAS.Columns.Add(New DataColumn("SISTEMA", System.Type.GetType("System.String")))

            Dim PK(1) As DataColumn
            PK(1) = DT_SISTEMAS.Columns("SISTEMA")
            DT_SISTEMAS.PrimaryKey = PK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub AGREGAR_A_DT(ByVal SISTEMA As String)
        Try
            Dim ENTRAR As Boolean = True
            If DT_SISTEMAS.Rows.Count > 0 Then
                For Each FILA As DataRow In DT_SISTEMAS.Rows
                    Dim SYS = FILA("SISTEMA")
                    If SISTEMA.ToString.Equals(SYS) Then
                        ENTRAR = False
                    End If
                Next
            End If
            If ENTRAR Then
                Dim ROW As DataRow
                ROW = DT_SISTEMAS.NewRow()
                ROW("SISTEMA") = SISTEMA
                DT_SISTEMAS.Rows.Add(ROW)
            End If
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
                Dim SQL = "	INSERT INTO USUARIO_DERECHO(COD_CIA,COD_DERECHO,COD_USUARIO)"
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
End Class