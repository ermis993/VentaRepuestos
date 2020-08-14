Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales

Public Class FamiliaMant

    Dim MODO As CRF_Modos
    Dim PADRE As Familia
    Dim CODIGO As String
    Dim Respuesta As DialogResult

    Sub New(ByVal MODO As CRF_Modos, ByVal PADRE As Familia, Optional CODIGO As String = "")
        InitializeComponent()
        Me.MODO = MODO
        Me.CODIGO = CODIGO
        Me.PADRE = PADRE
    End Sub

    Private Sub BTN_ACEPTAR_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Try
            If String.IsNullOrEmpty(TXT_CODIGO.Text) Then
                MessageBox.Show("¡Debe de ingresar el código de la familia!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_CODIGO.Select()
            ElseIf String.IsNullOrEmpty(TXT_DESCRIPCION.Text) Then
                MessageBox.Show("¡Debe de ingresar la descripción de la familia!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_DESCRIPCION.Select()
            Else
                Dim SQL As String = "EXEC USP_FAMILIA_MANT"
                SQL &= Chr(13) & " @CODIGO = " & SCM(TXT_CODIGO.Text)
                SQL &= Chr(13) & ",@DESCRIPCION = " & SCM(TXT_DESCRIPCION.Text)
                SQL &= Chr(13) & ",@ESTADO = " & SCM(IIf(RB_ACTIVO.Checked = True, "A", "I"))
                SQL &= Chr(13) & ",@MODO = " & Val(MODO)
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                If MODO = CRF_Modos.Insertar Then
                    LIMPIAR_TODO()
                    MessageBox.Show("¡Familia agregada correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf MODO = CRF_Modos.Modificar Then
                    Cerrar()
                    MessageBox.Show("¡Familia modificada correctamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LIMPIAR_TODO()
        TXT_CODIGO.Text = ""
        TXT_DESCRIPCION.Text = ""
        RB_ACTIVO.Checked = True
    End Sub

    Private Sub Cerrar()
        PADRE.REFRESCAR()
        Me.Close()
    End Sub

    Private Sub FamiliaMant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TXT_CODIGO.Enabled = MODO = CRF_Modos.Insertar
        If MODO = CRF_Modos.Modificar Then
            LEER()
        End If
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Cerrar()
    End Sub

    Private Sub LEER()
        Try
            Dim SQL As String = "EXEC USP_FAMILIA_MANT"
            SQL &= Chr(13) & " @CODIGO = " & SCM(Me.CODIGO)
            SQL &= Chr(13) & ",@MODO = " & Val(CRF_Modos.Seleccionar)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each ITEM In DS.Tables(0).Rows
                    TXT_CODIGO.Text = CODIGO
                    TXT_DESCRIPCION.Text = ITEM("DESCRIPCION")
                    If Trim(ITEM("ESTADO")).Equals("A") Then
                        RB_ACTIVO.Checked = True
                    Else
                        RB_INACTIVO.Checked = True
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class