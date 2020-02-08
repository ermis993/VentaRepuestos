Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class DerechosUsuario
    Dim COD_USUARIO As String = ""
    Sub New(ByVal COD_USUARIO As String)
        InitializeComponent()
        Me.COD_USUARIO = COD_USUARIO
    End Sub
    Private Sub DerechosUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGAR_CHECK_BOXES()
        LVCon.Columns.Add("", 321)
        LVSin.Columns.Add("", 321)
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
                SQL &= Chr(13) & "	AND U.COD_USUARIO= " & SCM(COD_USUARIO)
                SQL &= Chr(13) & "	WHERE D.COD_SISTEMA = " & SCM(CHK.Text)

                CONX.Coneccion_Abrir()
                Dim DS = CONX.EJECUTE_DS(SQL)
                CONX.Coneccion_Cerrar()

                If DS.Tables(0).Rows.Count > 0 Then
                    For Each ITEM In DS.Tables(0).Rows

                        Dim LVI As New ListViewItem
                        If ITEM("CONTIENE") = "S" Then
                            LVI.Text = ITEM("COD_DERECHO") & " -- " & ITEM("DESCRIPCION")
                            LVI.Name = ITEM("COD_DERECHO")
                            LVI.Tag = ITEM("COD_SISTEMA")
                            LVCon.Items.Add(LVI)
                        Else
                            LVI.Text = ITEM("COD_DERECHO") & " -- " & ITEM("DESCRIPCION")
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Me.Close()
    End Sub
End Class