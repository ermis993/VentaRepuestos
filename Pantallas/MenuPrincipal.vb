Imports VentaRepuestos.Globales
Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports System.Threading

Public Class MenuPrincipal

    Dim Bandera_Sucursal As Boolean = True

    Private Sub BTN_COMPANIA_Click(sender As Object, e As EventArgs) Handles BTN_COMPANIA.Click
        Try
            Compania.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_SUCURSAL_Click(sender As Object, e As EventArgs) Handles BTN_SUCURSAL.Click
        Try
            Dim PANTALLA As New Sucursal(Me)
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_SALIR_Click(sender As Object, e As EventArgs) Handles BTN_SALIR.Click
        Try
            Me.Close()
            Login.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Habilita_Botones()
        CARGAR_SUCURSALES()
        CARGAR_TIPO_CAMBIO()
        CARGAR_SALUDO()
        RellenaImagen(PB_IMAGEN)
    End Sub

    Private Sub Habilita_Botones()
        Try
            BTN_COMPANIA.Enabled = TieneDerecho("DCIA")
            BTN_SUCURSAL.Enabled = TieneDerecho("DSUC")
            BTN_USUARIO.Enabled = TieneDerecho("DUSU")
            BTN_CLIENTE.Enabled = TieneDerecho("DCLI")
            BTN_PROVEEDOR.Enabled = TieneDerecho("DPROV")
            BTN_FAMILIA.Enabled = TieneDerecho("DFAM")
            BTN_PRODUCTO.Enabled = TieneDerecho("DPROD")
            BTN_FE.Enabled = TieneDerecho("DVEN")
            BTN_COMPRAS.Enabled = TieneDerecho("DCOMP")
            BTN_BACKUP.Enabled = TieneDerecho("DBACK")
            BTN_REPORTES.Enabled = TieneDerecho("DREPT")
            BTN_ENCOMIENDA.Enabled = TieneDerecho("DENC")
            BTN_CONSULTA.Enabled = TieneDerecho("DCONS")
            BTN_XML.Enabled = TieneDerecho("DXML")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CARGAR_TIPO_CAMBIO()
        Dim SQL = "	SELECT * FROM TIPO_CAMBIO_CIA"
        SQL &= Chr(13) & "	WHERE COD_CIA = " & SCM(COD_CIA)
        SQL &= Chr(13) & "	AND FECHA = " & SCM(YMD(FECHA_HOY()))

        CONX.Coneccion_Abrir()
        Dim DS = CONX.EJECUTE_DS(SQL)
        CONX.Coneccion_Cerrar()
        If DS.Tables(0).Rows.Count > 0 Then
            For Each ITEM In DS.Tables(0).Rows
                TXT_COMPRA.Text = FMCP(ITEM("COMPRA"), 2)
                TXT_VENTA.Text = FMCP(ITEM("VENTA"), 2)
                TC_COMPRA = FMCP(ITEM("COMPRA"), 2)
                TC_VENTA = FMCP(ITEM("VENTA"), 2)
                Exit For
            Next
        End If
    End Sub

    Private Sub CARGAR_SALUDO()
        Dim SQL = "	SELECT NOMBRE"
        SQL &= Chr(13) & "	FROM USUARIO"
        SQL &= Chr(13) & "	WHERE COD_USUARIO =" & SCM(COD_USUARIO)
        CONX.Coneccion_Abrir()
        Dim DS = CONX.EJECUTE_DS(SQL)
        CONX.Coneccion_Cerrar()

        Dim DIA = DateTime.Now.ToString("dd")
        Dim MES = DateTime.Now.ToString("MM")
        Dim ANO = DateTime.Now.ToString("yyyy")
        Dim DIA_LETRAS = DIA_ESPANOL(DateTime.Now.DayOfWeek)
        Dim MES_LETRA = MES_ESPANOL(Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames(MES - 1))

        If DS.Tables(0).Rows.Count > 0 Then
            For Each ITEM In DS.Tables(0).Rows
                LBL_SALUDO.Text = "Bienvenid@ " & ITEM("NOMBRE") & ", la fecha actual es: " & DIA_LETRAS & " " & DIA & " de " & MES_LETRA & " del " & ANO
                Exit For
            Next
        End If
    End Sub



    Private Sub CARGAR_SUCURSALES()
        Try
            CMB_SUCURSAL.DataSource = Nothing
            Dim LISTA_REF As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

            Dim SQL As String = "SELECT SUC.COD_SUCUR AS CODIGO, NOMBRE"
            SQL &= Chr(13) & " FROM SUCURSAL AS SUC"
            SQL &= Chr(13) & " INNER JOIN SUCURSAL_USUARIO AS USU"
            SQL &= Chr(13) & " 	    ON SUC.COD_CIA = USU.COD_CIA"
            SQL &= Chr(13) & " 	    AND SUC.COD_SUCUR = USU.COD_SUCUR"
            SQL &= Chr(13) & "	    AND USU.COD_USUARIO =" & SCM(COD_USUARIO)
            SQL &= Chr(13) & " WHERE SUC.COD_CIA = " & SCM(COD_CIA)
            SQL &= Chr(13) & " AND ESTADO = 'A'"

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Row In DS.Tables(0).Rows
                    LISTA_REF.Add(New KeyValuePair(Of String, String)(Row("CODIGO").ToString, Row("CODIGO").ToString & " - " & Row("NOMBRE").ToString.ToUpper))
                Next

                CMB_SUCURSAL.ValueMember = "Key"
                CMB_SUCURSAL.DisplayMember = "Value"
                CMB_SUCURSAL.DataSource = LISTA_REF

                If String.IsNullOrEmpty(COD_SUCUR) Then
                    CMB_SUCURSAL.SelectedIndex = 0
                    COD_SUCUR = CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3)
                Else

                    CMB_SUCURSAL.SelectedValue = COD_SUCUR

                    If CMB_SUCURSAL.SelectedIndex = -1 Then
                        CMB_SUCURSAL.SelectedIndex = 0
                        COD_SUCUR = CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub ActualizaSucursales()
        Try
            Bandera_Sucursal = False
            CARGAR_SUCURSALES()
            Bandera_Sucursal = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CMB_SUCURSAL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_SUCURSAL.SelectedIndexChanged
        Try
            If Not CMB_SUCURSAL.DataSource Is Nothing Then
                If Bandera_Sucursal = True Then
                    COD_SUCUR = CMB_SUCURSAL.SelectedItem().ToString.Substring(1, 3)
                    INDICADORES_SUCURSAL(COD_CIA, COD_SUCUR)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub BTN_CLIENTE_Click(sender As Object, e As EventArgs) Handles BTN_CLIENTE.Click
    '    Try
    '        Dim PANTALLA As New Cliente()
    '        PANTALLA.ShowDialog()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Private Sub BTN_FE_Click(sender As Object, e As EventArgs) Handles BTN_FE.Click
        Try
            Dim PANTALLA As New Facturacion()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_PRODUCTO_Click(sender As Object, e As EventArgs) Handles BTN_PRODUCTO.Click
        Try
            Dim PANTALLA As New Producto()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_PROVEEDOR_Click(sender As Object, e As EventArgs) Handles BTN_PROVEEDOR.Click
        Try
            Dim PANTALLA As New Proveedor()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BTN_USUARIO_Click(sender As Object, e As EventArgs) Handles BTN_USUARIO.Click
        Try
            Dim PANTALLA As New Usuario()
            AddHandler PANTALLA.FormClosed, AddressOf Proceso_Botones
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Proceso_Botones(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Habilita_Botones()
    End Sub

    Private Sub BTN_CONSULTA_Click(sender As Object, e As EventArgs) Handles BTN_CONSULTA.Click
        Try
            Dim PANTALLA As New ConsultaSaldos()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_REPORTES_Click(sender As Object, e As EventArgs) Handles BTN_REPORTES.Click
        Try
            Dim PANTALLA As New Reportes()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_XML_Click(sender As Object, e As EventArgs) Handles BTN_XML.Click
        Try
            Dim PANTALLA As New DocumentoElectronico()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_FAMILIA_Click(sender As Object, e As EventArgs) Handles BTN_FAMILIA.Click
        Try
            Dim PANTALLA As New Familia()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_CLIENTE_Click(sender As Object, e As EventArgs) Handles BTN_CLIENTE.Click
        Try
            Dim PANTALLA As New Cliente()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_ENCOMIENDA_Click(sender As Object, e As EventArgs) Handles BTN_ENCOMIENDA.Click
        Try
            Dim PANTALLA As New Encomienda()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_COMPRAS_Click(sender As Object, e As EventArgs) Handles BTN_COMPRAS.Click
        Try
            Dim PANTALLA As New CXP_Facturacion()
            PANTALLA.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN_BACKUP_Click(sender As Object, e As EventArgs) Handles BTN_BACKUP.Click
        Try
            'Dim Ruta As New SaveFileDialog With {
            '    .FileName = "BackUp_" + DMA(FECHA_HOY()).Replace("/", "-"),
            '    .Filter = "SQL Server database backup files |*.bak"
            '}

            'If Ruta.ShowDialog() = DialogResult.OK Then
            '    Dim SQL As String = "BACKUP DATABASE VR TO disk=" & SCM(Ruta.FileName)
            '    CONX.Coneccion_Abrir()
            '    CONX.EJECUTE(SQL)
            '    CONX.Coneccion_Cerrar()

            '    MessageBox.Show("BackUp generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If

            Dim SQL As String = "BACKUP DATABASE VR TO disk=" & SCM(RUTA_BACKUP & "\" & "BackUp_" + DMA(FECHA_HOY()).Replace("/", "-"))
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()

            MessageBox.Show("BackUp generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class