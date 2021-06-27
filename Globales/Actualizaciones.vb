Imports System.IO
Imports VentaRepuestos.Globales
Public Class Actualizaciones
    Public Sub ACTUALIZACIONES(ByRef ProgressBar As ProgressBar)

        'IMPORTATE SIEMPRE ACTUALIZAR LA CANTIDAD DE PROCESOS
        'ESTO POR SI SE AGREGA UNA CREACION DE TABLA, PROCEDIMIENTO, TRIGGER, O CAMPO EN UN TABLA
        'CANTIDAD_PROCESOS: CANTIDAD DE MÉTODOS A EJECUTAR
        'CANTIDAD ACTUAL: ACTUALIZAR SIEMPRE CON LA CANTIDAD DE MÉTODOS QUE SE EJECUTARON

        If (Not Directory.Exists("C:\ENVIOS")) Then
            Directory.CreateDirectory("C:\ENVIOS")
        End If

        If (Not Directory.Exists("C:\BACKUPS")) Then
            Directory.CreateDirectory("C:\BACKUPS")
        End If

        RUTA_ADJUNTOS = "C:\ENVIOS"
        RUTA_BACKUP = "C:\BACKUPS"

        Dim Cantidad_Procesos As Integer = 97
        Dim Cantidad_Actual As Integer = 0
        ProgressBar.Value = 0

        'TABLAS
        Call APARTADO_ENC_TMP()
        Call APARTADO_DET_TMP()
        Call APARTADO_ENC()
        Call APARTADO_DET()
        Call COMPANIA_CODIGOS_BARRAS()
        Call CXP_DOCUMENTO_AFEC()
        Call CXP_DOCUMENTO_AFEC_DET_TMP()
        Call SUCURSAL_INDICADORES()
        Call PRODUCTO_RELACION()
        Call PROFORMA_ENC_TMP()
        Call PROFORMA_DET_TMP()
        Call PROFORMA_ENC()
        Call PROFORMA_DET()
        Call INVENTARIO_ENC_TMP()
        Call INVENTARIO_ENC()
        Call INVENTARIO_DET_TMP()
        Call INVENTARIO_DET()
        Call BITACORA_IMPRESIONES()
        Call PRODUCTO_DESECHADO()
        Call CXP_DOCUMENTOS_ELECTRONICOS_CORREO()
        Call IMAP_CONFIG()

        Cantidad_Actual += 21
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'CAMPOS EN TABLAS
        Call PRODUCTO_COD_FAMILIA()
        Call PRODUCTO_OBSERVACION()
        Call PRODUCTO_IND_PRECIO_MODIFICABLE()
        Call SUCURSAL_ETIQUETA()
        Call DOCUMENTO_GUIA_CAMPOS()
        Call INVENTARIO_MOV_SISTEMA()
        Call INVENTARIO_MOV_DET_SISTEMA()
        Call SUCURSAL_IND_AVISO_MIN_STOCK()
        Call COD_CABYS_PRODUCTO()
        Call PROVEEDOR_PORCENTAJE_VENTA()
        Call SUCURSAL_INDICADORES_CAMPOS()
        Call CLIENTE_PRECIO_DEFECTO()
        Call PRODUCTO_IMG_BARRA()
        Call IND_IMAGEN_TIQUETE()
        Call IND_AUTOCOMPLETAR_CLIENTE()
        Call MIN_VENTA()
        Call TIPO_INGRESO()
        Call IND_TIPO()
        Call DESCUENTO()


        Cantidad_Actual += 19
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'CONSTRAINTS
        Call CONSTRAINT_FK_CXP_DOCUMENTO_DET_CXP_DOCUMENTO_ENC()
        Call CONSTRAINT_FK_PROFORMA_DET_DOCUMENTO_ENC()
        Call CONSTRAINT_PK_GUIA_UBICACION()
        Call CONSTRAINT_PK_DOCUMENTO_GUIA_UBICACION()
        Cantidad_Actual += 4
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'ALTERS CAMPOS
        Call ALTER_SMTP_CONFIG_CONTRASENA()
        Call ALTER_COMPANIA_CERTIFICADO()
        Call ALTER_GUIA_UBICACION()
        Call ALTER_DOCUMENTO_GUIA_NUMERO_GUIA()
        Call ALTER_DOCUMENTO_GUIA_UBICACION_NUMERO_GUIA()
        Call CXP_DOCUMENTOS_ELECTRONICOS_DET_CABYS()
        Cantidad_Actual += 6
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'TIPOS
        Call TP_PRODUCTO_CABYS()
        Cantidad_Actual += 1
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'TRIGGERS
        Call TG_INGRESA_INVENTARIO_APARTADO_ENC()
        Call TG_INGRESA_INVENTARIO_APARTADO_DET()
        Call TG_INGRESA_INVENTARIO_MOV_CXP_ENC()
        Call TG_INGRESA_INVENTARIO_MOV_CXP_DET()
        Call TG_INGRESA_INVENTARIO_MOV_ENC()
        Call TG_INGRESA_INVENTARIO_MOV_DET()
        Call TG_INGRESA_DOCUMENTO_AFEC_DET_PRODUCTOS()
        Call TG_INGRESA_INVENTARIO_MOV_ENC_INV()
        Call TG_INGRESA_INVENTARIO_MOV_DET_INV()

        Cantidad_Actual += 9
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'PROCEDIMIENTOS
        Call USP_APARTADO_TMP_A_REAL()
        Call USP_DATOS_IMP_ENCOMIENDA_POR_FECHA()
        Call USP_FACTURACION_TMP_A_REAL()
        Call USP_INGRESO_INVENTARIO()
        Call USP_MANT_APARTADO_TMP()
        Call USP_PRODUCTO_RELACION()
        Call USP_SUCURSAL_INDICADORES_MANT()
        Call USP_MANT_PRODUCTO()
        Call USP_DATOS_RECIBO_IMPRESION()
        Call USP_DATOS_REPORTE_INVENTARIO()
        Call USP_DATOS_FACTURA_IMPRESION()
        Call USP_CXP_FACTURACION_TMP_A_REAL()
        Call USP_SUCURSAL_MANTENIMIENTO()
        Call USP_IMPRIME_FACTURA()
        Call USP_IMPRIME_NOTA_CREDITO()
        Call USP_DATOS_FACTURA_ENCOMIENDA()
        Call USP_PROVEEDOR_MANT()
        Call USP_FAMILIA_MANT()
        Call USP_CLIENTE_MANT()
        Call USP_MANT_PROFORMA_TMP()
        Call USP_PROFORMA_TMP_A_REAL()
        Call USP_IMPRIME_PROFORMA()
        Call USP_PROFORMA_A_FACTURA()
        Call USP_ImprimeFElectronica_V_4_3()
        Call USP_IMPORTA_PRODUCTO_CABYS()
        Call USP_DATOS_APARTADO_IMPRESION()
        Call USP_INVENTARIO_TMP_A_REAL()
        Call USP_COMPANIA_MANT()
        Call USP_DOCUMENTOS_CON_SALDO_A_FECHA()
        Call USP_DATOS_CXP_ANTIGUEDAD_SALDOS()
        Call USP_MANT_FACTURACION_TMP()
        Call USP_INGRESA_DOCUMENTO_XML_CORREO()
        Call USP_GUARDAR_CERTIFICADO()
        Call USP_RUTA_MANT()
        Call USP_DATOS_FACTURA_ETIQUETA()

        Cantidad_Actual += 35
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'PROCESOS ESPECIALES ANIDADOS
        Call PROC_ESPECIAL_USP_PROCESA_DOCUMENTOS_XML()

        Cantidad_Actual += 1
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'DERECHOS
        Call PROCESAR_DERECHOS()

        Cantidad_Actual += 1
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)
    End Sub

#Region "Metodos"

    Private Sub ActualizaProgressBar(ByRef ProgressBar As ProgressBar, ByVal Cantidad_Actual As Integer, ByVal Cantidad_Procesos As Integer)
        Try
            Dim Calculo As Integer = 0
            Calculo = ((Cantidad_Actual * 100) / Cantidad_Procesos)
            ProgressBar.Increment(Calculo)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Tablas"
    Private Sub APARTADO_ENC_TMP()
        Try
            If Not EXISTE_TABLA("APARTADO_ENC_TMP") Then
                Dim SQL = "	CREATE TABLE [dbo].[APARTADO_ENC_TMP](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL, "
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "		[COD_MONEDA] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_CAMBIO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[PLAZO] [int] NOT NULL,"
                SQL &= Chr(13) & "		[FORMA_PAGO] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](250) NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_NOTA] [varchar](2) NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_APARTADO_ENC_TMP] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "	(	"
                SQL &= Chr(13) & "		[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[CODIGO] ASC,"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQL &= Chr(13) & "	) ON [PRIMARY]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub APARTADO_DET_TMP()
        Try
            If Not EXISTE_TABLA("APARTADO_DET_TMP") Then
                Dim SQL = "	CREATE TABLE [dbo].[APARTADO_DET_TMP](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,	"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,	"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NOT NULL,	"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,	"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,	"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL, "
                SQL &= Chr(13) & "		[COD_UNIDAD] [varchar](10) NOT NULL,	"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,	"
                SQL &= Chr(13) & "		[PRECIO] [money] NOT NULL,	"
                SQL &= Chr(13) & "		[POR_DESCUENTO] [int] NOT NULL, "
                SQL &= Chr(13) & "		[DESCUENTO] [money] NOT NULL,	"
                SQL &= Chr(13) & "		[POR_IMPUESTO] [int] NOT NULL,	"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,	"
                SQL &= Chr(13) & "		[SUBTOTAL] [money] NOT NULL,	"
                SQL &= Chr(13) & "		[TOTAL] [money] NOT NULL,	"
                SQL &= Chr(13) & "		[ESTANTE] [varchar](3) NULL,"
                SQL &= Chr(13) & "		[FILA] [varchar](3) NULL,	"
                SQL &= Chr(13) & "		[COLUMNA] [varchar](3) NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_APARTADO_DET_TMP] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "	(		"
                SQL &= Chr(13) & "		[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,	"
                SQL &= Chr(13) & "		[CODIGO] ASC,"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,	"
                SQL &= Chr(13) & "		[LINEA] ASC	"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]"
                SQL &= Chr(13) & "	) ON [PRIMARY]		"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub APARTADO_ENC()
        Try
            If Not EXISTE_TABLA("APARTADO_ENC") Then
                Dim SQL = "	CREATE TABLE [dbo].[APARTADO_ENC](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "		[MONTO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[SALDO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[COD_MONEDA] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_CAMBIO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[PLAZO] [int] NOT NULL,"
                SQL &= Chr(13) & "		[FORMA_PAGO] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL, "
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](250) NULL,"
                SQL &= Chr(13) & "		[TIPO_NOTA] [varchar](2) NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_APARTADO_ENC] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "	(	"
                SQL &= Chr(13) & "		[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]	"
                SQL &= Chr(13) & "	) ON [PRIMARY]	"
                SQL &= Chr(13) & "		"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_APARTADO_ENC_CLIENTE1] FOREIGN KEY([COD_CIA], [CEDULA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[CLIENTE] ([COD_CIA], [CEDULA])	"
                SQL &= Chr(13) & "	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_ENC] CHECK CONSTRAINT [FK_APARTADO_ENC_CLIENTE1]	"
                SQL &= Chr(13) & "	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_APARTADO_ENC_COMPANIA1] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_ENC] CHECK CONSTRAINT [FK_APARTADO_ENC_COMPANIA1]	"
                SQL &= Chr(13) & "		"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_APARTADO_ENC_SUCURSAL1] FOREIGN KEY([COD_CIA], [COD_SUCUR])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])"
                SQL &= Chr(13) & "	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_ENC] CHECK CONSTRAINT [FK_APARTADO_ENC_SUCURSAL1]"
                SQL &= Chr(13) & "	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_APARTADO_ENC_USUARIO1] FOREIGN KEY([COD_USUARIO])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[USUARIO] ([COD_USUARIO])	"
                SQL &= Chr(13) & "	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_ENC] CHECK CONSTRAINT [FK_APARTADO_ENC_USUARIO1]"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub APARTADO_DET()
        Try
            If Not EXISTE_TABLA("APARTADO_DET") Then
                Dim SQL = "	CREATE TABLE [dbo].[APARTADO_DET](																				"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																			"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																			"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,																			"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																			"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,																			"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,																			"
                SQL &= Chr(13) & "		[COD_UNIDAD] [varchar](10) NOT NULL,																			"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,																			"
                SQL &= Chr(13) & "		[PRECIO] [money] NOT NULL,																			"
                SQL &= Chr(13) & "		[POR_DESCUENTO] [int] NOT NULL,																			"
                SQL &= Chr(13) & "		[DESCUENTO] [money] NOT NULL,																			"
                SQL &= Chr(13) & "		[POR_IMPUESTO] [int] NOT NULL,																			"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,																			"
                SQL &= Chr(13) & "		[SUBTOTAL] [money] NOT NULL,																			"
                SQL &= Chr(13) & "		[TOTAL] [money] NOT NULL,																			"
                SQL &= Chr(13) & "		[ESTANTE] [varchar](3) NULL,																			"
                SQL &= Chr(13) & "		[FILA] [varchar](3) NULL,																			"
                SQL &= Chr(13) & "		[COLUMNA] [varchar](3) NULL,																			"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_APARTADO_DET] PRIMARY KEY CLUSTERED 																				"
                SQL &= Chr(13) & "	(																				"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																			"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																			"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,																			"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,																			"
                SQL &= Chr(13) & "		[LINEA] ASC																			"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																				"
                SQL &= Chr(13) & "	) ON [PRIMARY]																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_DET]  WITH CHECK ADD  CONSTRAINT [FK_APARTADO_DET_COMPANIA] FOREIGN KEY([COD_CIA])																				"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_DET] CHECK CONSTRAINT [FK_APARTADO_DET_COMPANIA]																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_DET]  WITH CHECK ADD  CONSTRAINT [FK_APARTADO_DET_APARTADO_ENC] FOREIGN KEY([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])																				"
                SQL &= Chr(13) & "	REFERENCES [dbo].[APARTADO_ENC] ([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_DET] CHECK CONSTRAINT [FK_APARTADO_DET_APARTADO_ENC]																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_DET]  WITH CHECK ADD  CONSTRAINT [FK_APARTADO_DET_PRODUCTO] FOREIGN KEY([COD_CIA], [COD_SUCUR], [COD_PROD])																				"
                SQL &= Chr(13) & "	REFERENCES [dbo].[PRODUCTO] ([COD_CIA], [COD_SUCUR], [COD_PROD])																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_DET] CHECK CONSTRAINT [FK_APARTADO_DET_PRODUCTO]																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_DET]  WITH CHECK ADD  CONSTRAINT [FK_APARTADO_DET_SUCURSAL] FOREIGN KEY([COD_CIA], [COD_SUCUR])																				"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[APARTADO_DET] CHECK CONSTRAINT [FK_APARTADO_DET_SUCURSAL]	"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SUCURSAL_INDICADORES()
        Try
            If Not EXISTE_TABLA("SUCURSAL_INDICADORES") Then
                Dim SQL = "	CREATE TABLE SUCURSAL_INDICADORES(																				"
                SQL &= Chr(13) & "	COD_CIA VARCHAR(3) NOT NULL,																				"
                SQL &= Chr(13) & "	COD_SUCUR VARCHAR(3) NOT NULL, 																				"
                SQL &= Chr(13) & "	IND_PERMITE_VENTAS_NEGATIVO CHAR(1) NOT NULL DEFAULT ('N')																				"
                SQL &= Chr(13) & "	)																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE SUCURSAL_INDICADORES																				"
                SQL &= Chr(13) & "	ADD CONSTRAINT PK_SUCURSAL_INDICADORES PRIMARY KEY (COD_CIA, COD_SUCUR)																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	ALTER TABLE SUCURSAL_INDICADORES																				"
                SQL &= Chr(13) & "	ADD FOREIGN KEY (COD_CIA, COD_SUCUR) REFERENCES SUCURSAL(COD_CIA, COD_SUCUR)																				"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PRODUCTO_RELACION()
        Try
            If Not EXISTE_TABLA("PRODUCTO_RELACION") Then
                Dim SQL = "	CREATE TABLE PRODUCTO_RELACION(																						"
                SQL &= Chr(13) & "	COD_CIA VARCHAR(3) NOT NULL, 																						"
                SQL &= Chr(13) & "	COD_SUCUR VARCHAR(3) NOT NULL, 																						"
                SQL &= Chr(13) & "	COD_PROD_PADRE VARCHAR(20) NOT NULL, 																						"
                SQL &= Chr(13) & "	COD_PROD_HIJO VARCHAR(20) NOT NULL																						"
                SQL &= Chr(13) & "	)																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE PRODUCTO_RELACION ADD CONSTRAINT PRODUCTO_RELACION_PK PRIMARY KEY(COD_CIA, COD_SUCUR, COD_PROD_PADRE, COD_PROD_HIJO)																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE PRODUCTO_RELACION																						"
                SQL &= Chr(13) & "	ADD FOREIGN KEY (COD_CIA,COD_SUCUR,COD_PROD_PADRE) REFERENCES PRODUCTO(COD_CIA,COD_SUCUR,COD_PROD)		"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CXP_DOCUMENTO_AFEC()
        Try
            If Not EXISTE_TABLA("CXP_DOCUMENTO_AFEC") Then

                Dim SQL = "	CREATE TABLE [dbo].[CXP_DOCUMENTO_AFEC](																						"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC_AFEC] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_MOV_AFEC] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[MONTO_AFEC] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,																					"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_CXP_DOCUMENTO_AFEC] PRIMARY KEY CLUSTERED 																						"
                SQL &= Chr(13) & "	(																						"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,																					"
                SQL &= Chr(13) & "		[FECHA] ASC,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC_AFEC] ASC,																					"
                SQL &= Chr(13) & "		[TIPO_MOV_AFEC] ASC																					"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																						"
                SQL &= Chr(13) & "	) ON [PRIMARY]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[CXP_DOCUMENTO_AFEC]  WITH CHECK ADD  CONSTRAINT [FK_CXP_DOCUMENTO_AFEC_DOCUMENTO_ENC] FOREIGN KEY([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[CXP_DOCUMENTO_ENC] ([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[CXP_DOCUMENTO_AFEC] CHECK CONSTRAINT [FK_CXP_DOCUMENTO_AFEC_DOCUMENTO_ENC]		"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CXP_DOCUMENTO_AFEC_DET_TMP()
        Try
            If Not EXISTE_TABLA("CXP_DOCUMENTO_AFEC_DET_TMP") Then

                Dim SQL = "	CREATE TABLE [dbo].[CXP_DOCUMENTO_AFEC_DET_TMP](																						"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NOT NULL,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,																					"
                SQL &= Chr(13) & "		[MONTO_DOC] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[MONTO_AFEC] [money] NOT NULL,																					"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_CXP_DOCUMENTO_AFEC_DET_TMP] PRIMARY KEY CLUSTERED 																						"
                SQL &= Chr(13) & "	(																						"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																					"
                SQL &= Chr(13) & "		[CODIGO] ASC,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC																					"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																						"
                SQL &= Chr(13) & "	) ON [PRIMARY]		"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub COMPANIA_CODIGOS_BARRAS()
        Try
            If Not EXISTE_TABLA("COMPANIA_CODIGOS_BARRAS") Then

                Dim SQL = "	CREATE TABLE [dbo].[COMPANIA_CODIGOS_BARRAS](																						"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[CODIGO_BARRAS] [varchar](25) NOT NULL,																					"
                SQL &= Chr(13) & "		[IMAGEN] [image] NULL,																					"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_COMPANIA_CODIGOS_BARRAS] PRIMARY KEY CLUSTERED 																						"
                SQL &= Chr(13) & "	(																						"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																					"
                SQL &= Chr(13) & "		[CODIGO_BARRAS] ASC																					"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																						"
                SQL &= Chr(13) & "	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]																						"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PROFORMA_ENC_TMP()
        Try
            If Not EXISTE_TABLA("PROFORMA_ENC_TMP") Then

                Dim SQL = "	CREATE TABLE [dbo].[PROFORMA_ENC_TMP](																						"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,																					"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,																					"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_MONEDA] [char](1) NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_CAMBIO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[PLAZO] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[FORMA_PAGO] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](250) NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_NOTA] [varchar](2) NULL,																					"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_PROFORMA_ENC_TMP] PRIMARY KEY CLUSTERED 																						"
                SQL &= Chr(13) & "	(																						"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																					"
                SQL &= Chr(13) & "		[CODIGO] ASC,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC																					"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																						"
                SQL &= Chr(13) & "	) ON [PRIMARY]																						"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PROFORMA_DET_TMP()
        Try
            If Not EXISTE_TABLA("PROFORMA_DET_TMP") Then
                Dim SQL = "	CREATE TABLE [dbo].[PROFORMA_DET_TMP](																						"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_UNIDAD] [varchar](10) NOT NULL,																					"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[PRECIO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[POR_DESCUENTO] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[DESCUENTO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[POR_IMPUESTO] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[SUBTOTAL] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[TOTAL] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[ESTANTE] [varchar](3) NULL,																					"
                SQL &= Chr(13) & "		[FILA] [varchar](3) NULL,																					"
                SQL &= Chr(13) & "		[COLUMNA] [varchar](3) NULL,																					"
                SQL &= Chr(13) & "		[POR_EXONERACION] [int] NULL,																					"
                SQL &= Chr(13) & "		[EXONERACION] [money] NULL,																					"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_PROFORMA_DET_TMP] PRIMARY KEY CLUSTERED 																						"
                SQL &= Chr(13) & "	(																						"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																					"
                SQL &= Chr(13) & "		[CODIGO] ASC,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,																					"
                SQL &= Chr(13) & "		[LINEA] ASC																					"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																						"
                SQL &= Chr(13) & "	) ON [PRIMARY]																					"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PROFORMA_ENC()
        Try
            If Not EXISTE_TABLA("PROFORMA_ENC") Then
                Dim SQL = "	CREATE TABLE [dbo].[PROFORMA_ENC](																						"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,																					"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,																					"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,																					"
                SQL &= Chr(13) & "		[MONTO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[SALDO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_MONEDA] [char](1) NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_CAMBIO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[PLAZO] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[FORMA_PAGO] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,																					"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](250) NULL,																					"
                SQL &= Chr(13) & "		[TIPO_NOTA] [varchar](2) NULL,																					"
                SQL &= Chr(13) & "		[NUM_FACTURA] [int] NULL,																					"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_PROFORMA_ENC] PRIMARY KEY CLUSTERED 																						"
                SQL &= Chr(13) & "	(																						"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC																					"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																						"
                SQL &= Chr(13) & "	) ON [PRIMARY]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_ENC]  WITH CHECK ADD  CONSTRAINT [FK_PROFORMA_ENC_CLIENTE1] FOREIGN KEY([COD_CIA], [CEDULA])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[CLIENTE] ([COD_CIA], [CEDULA])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_ENC] CHECK CONSTRAINT [FK_PROFORMA_ENC_CLIENTE1]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_ENC]  WITH CHECK ADD  CONSTRAINT [FK_PROFORMA_ENC_COMPANIA1] FOREIGN KEY([COD_CIA])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_ENC] CHECK CONSTRAINT [FK_PROFORMA_ENC_COMPANIA1]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_ENC]  WITH CHECK ADD  CONSTRAINT [FK_PROFORMA_ENC_SUCURSAL1] FOREIGN KEY([COD_CIA], [COD_SUCUR])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_ENC] CHECK CONSTRAINT [FK_PROFORMA_ENC_SUCURSAL1]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_ENC]  WITH CHECK ADD  CONSTRAINT [FK_PROFORMA_ENC_USUARIO1] FOREIGN KEY([COD_USUARIO])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[USUARIO] ([COD_USUARIO])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_ENC] CHECK CONSTRAINT [FK_PROFORMA_ENC_USUARIO1]				"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PROFORMA_DET()
        Try
            If Not EXISTE_TABLA("PROFORMA_DET") Then
                Dim SQL = "	CREATE TABLE [dbo].[PROFORMA_DET](																						"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																					"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,																					"
                SQL &= Chr(13) & "		[COD_UNIDAD] [varchar](10) NOT NULL,																					"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[PRECIO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[POR_DESCUENTO] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[DESCUENTO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[POR_IMPUESTO] [int] NOT NULL,																					"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[SUBTOTAL] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[TOTAL] [money] NOT NULL,																					"
                SQL &= Chr(13) & "		[ESTANTE] [varchar](3) NULL,																					"
                SQL &= Chr(13) & "		[FILA] [varchar](3) NULL,																					"
                SQL &= Chr(13) & "		[COLUMNA] [varchar](3) NULL,																					"
                SQL &= Chr(13) & "		[POR_EXONERACION] [int] NULL,																					"
                SQL &= Chr(13) & "		[EXONERACION] [money] NULL,																					"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_PROFORMA_DET] PRIMARY KEY CLUSTERED 																						"
                SQL &= Chr(13) & "	(																						"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																					"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																					"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,																					"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,																					"
                SQL &= Chr(13) & "		[LINEA] ASC																					"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																						"
                SQL &= Chr(13) & "	) ON [PRIMARY]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_DET]  WITH CHECK ADD  CONSTRAINT [FK_PROFORMA_DET_COMPANIA] FOREIGN KEY([COD_CIA])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_DET] CHECK CONSTRAINT [FK_PROFORMA_DET_COMPANIA]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_DET]  WITH CHECK ADD  CONSTRAINT [FK_PROFORMA_DET_DOCUMENTO_ENC] FOREIGN KEY([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[DOCUMENTO_ENC] ([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_DET] CHECK CONSTRAINT [FK_PROFORMA_DET_DOCUMENTO_ENC]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_DET]  WITH CHECK ADD  CONSTRAINT [FK_PROFORMA_DET_PRODUCTO] FOREIGN KEY([COD_CIA], [COD_SUCUR], [COD_PROD])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[PRODUCTO] ([COD_CIA], [COD_SUCUR], [COD_PROD])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_DET] CHECK CONSTRAINT [FK_PROFORMA_DET_PRODUCTO]																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_DET]  WITH CHECK ADD  CONSTRAINT [FK_PROFORMA_DET_SUCURSAL] FOREIGN KEY([COD_CIA], [COD_SUCUR])																						"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROFORMA_DET] CHECK CONSTRAINT [FK_PROFORMA_DET_SUCURSAL] "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub INVENTARIO_ENC_TMP()
        Try
            If Not EXISTE_TABLA("INVENTARIO_ENC_TMP") Then

                Dim SQL = "	CREATE TABLE [dbo].[INVENTARIO_ENC_TMP](																									"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NOT NULL,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																								"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,																								"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,																								"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,																								"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](250) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_MOV] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_INVENTARIO_ENC_TMP] PRIMARY KEY CLUSTERED 																									"
                SQL &= Chr(13) & "	(																									"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																								"
                SQL &= Chr(13) & "		[CODIGO] ASC,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC																								"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																									"
                SQL &= Chr(13) & "	) ON [PRIMARY]																									"


                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub INVENTARIO_ENC()
        Try
            If Not EXISTE_TABLA("INVENTARIO_ENC") Then

                Dim SQL = "	CREATE TABLE [dbo].[INVENTARIO_ENC](																									"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																								"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,																								"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,																								"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,																								"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](250) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_MOV] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_INVENTARIO_ENC] PRIMARY KEY CLUSTERED 																									"
                SQL &= Chr(13) & "	(																									"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																								"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC																								"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																									"
                SQL &= Chr(13) & "	) ON [PRIMARY]																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_ENC_COMPANIA1] FOREIGN KEY([COD_CIA])																									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_ENC] CHECK CONSTRAINT [FK_INVENTARIO_ENC_COMPANIA1]																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_ENC_SUCURSAL1] FOREIGN KEY([COD_CIA], [COD_SUCUR])																									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_ENC] CHECK CONSTRAINT [FK_INVENTARIO_ENC_SUCURSAL1]																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_ENC_USUARIO1] FOREIGN KEY([COD_USUARIO])																									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[USUARIO] ([COD_USUARIO])																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_ENC] CHECK CONSTRAINT [FK_INVENTARIO_ENC_USUARIO1]							"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                SQL = "	INSERT INTO INVENTARIO_COD_MOV "
                SQL &= Chr(13) & "	SELECT 'EPA', 'Entrada por ajuste' "
                SQL &= Chr(13) & "	UNION ALL "
                SQL &= Chr(13) & "	SELECT 'SPA', 'Salida por ajuste' "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub INVENTARIO_DET()
        Try
            If Not EXISTE_TABLA("INVENTARIO_DET") Then

                Dim SQL = "	CREATE TABLE [dbo].[INVENTARIO_DET](																									"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																								"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,																								"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[ESTANTE] [varchar](3) NULL,																								"
                SQL &= Chr(13) & "		[FILA] [varchar](3) NULL,																								"
                SQL &= Chr(13) & "		[COLUMNA] [varchar](3) NULL,																								"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_INVENTARIO_DET] PRIMARY KEY CLUSTERED 																									"
                SQL &= Chr(13) & "	(																									"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																								"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,																								"
                SQL &= Chr(13) & "		[LINEA] ASC																								"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																									"
                SQL &= Chr(13) & "	) ON [PRIMARY]																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_DET_COMPANIA] FOREIGN KEY([COD_CIA])																									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_DET] CHECK CONSTRAINT [FK_INVENTARIO_DET_COMPANIA]																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_DET_DOCUMENTO_ENC] FOREIGN KEY([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])																									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[INVENTARIO_ENC] ([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_DET] CHECK CONSTRAINT [FK_INVENTARIO_DET_DOCUMENTO_ENC]																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_DET_PRODUCTO] FOREIGN KEY([COD_CIA], [COD_SUCUR], [COD_PROD])																									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[PRODUCTO] ([COD_CIA], [COD_SUCUR], [COD_PROD])																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_DET] CHECK CONSTRAINT [FK_INVENTARIO_DET_PRODUCTO]																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_DET_SUCURSAL] FOREIGN KEY([COD_CIA], [COD_SUCUR])																									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_DET] CHECK CONSTRAINT [FK_INVENTARIO_DET_SUCURSAL]					"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub INVENTARIO_DET_TMP()
        Try
            If Not EXISTE_TABLA("INVENTARIO_DET_TMP") Then

                Dim SQL = "	CREATE TABLE [dbo].[INVENTARIO_DET_TMP](																									"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NOT NULL,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,																								"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,																								"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[ESTANTE] [varchar](3) NULL,																								"
                SQL &= Chr(13) & "		[FILA] [varchar](3) NULL,																								"
                SQL &= Chr(13) & "		[COLUMNA] [varchar](3) NULL,																								"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_INVENTARIO_DET_TMP] PRIMARY KEY CLUSTERED 																									"
                SQL &= Chr(13) & "	(																									"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																								"
                SQL &= Chr(13) & "		[CODIGO] ASC,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,																								"
                SQL &= Chr(13) & "		[LINEA] ASC																								"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																									"
                SQL &= Chr(13) & "	) ON [PRIMARY]																									"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BITACORA_IMPRESIONES()
        Try
            If Not EXISTE_TABLA("BITACORA_IMPRESIONES") Then

                Dim SQL = "	CREATE TABLE [dbo].[BITACORA_IMPRESIONES](																									"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[FECHA_IMP] [datetime] NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,																								"
                SQL &= Chr(13) & "		[REPORTE] [varchar](200) NOT NULL,																								"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_BITACORA_IMPRESIONES] PRIMARY KEY CLUSTERED 																									"
                SQL &= Chr(13) & "	(																									"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																								"
                SQL &= Chr(13) & "		[FECHA_IMP] ASC,																								"
                SQL &= Chr(13) & "		[COD_USUARIO] ASC,																								"
                SQL &= Chr(13) & "		[REPORTE] ASC																								"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																									"
                SQL &= Chr(13) & "	) ON [PRIMARY]"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PRODUCTO_DESECHADO()
        Try
            If Not EXISTE_TABLA("PRODUCTO_DESECHADO") Then

                Dim SQL = "	CREATE TABLE [dbo].[PRODUCTO_DESECHADO](																									"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,																								"
                SQL &= Chr(13) & "	 CONSTRAINT [PRODUCTO_DESECHADO_PK] PRIMARY KEY CLUSTERED 																									"
                SQL &= Chr(13) & "	(																									"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																								"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,																								"
                SQL &= Chr(13) & "		[COD_PROD] ASC																								"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																									"
                SQL &= Chr(13) & "	) ON [PRIMARY]				"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CXP_DOCUMENTOS_ELECTRONICOS_CORREO()
        Try
            If Not EXISTE_TABLA("CXP_DOCUMENTOS_ELECTRONICOS_CORREO") Then

                Dim SQL = "	CREATE TABLE CXP_DOCUMENTOS_ELECTRONICOS_CORREO(																									"
                SQL &= Chr(13) & "	[COD_CIA] [varchar](3) NOT NULL,																									"
                SQL &= Chr(13) & "	[CLAVE] [varchar](50) NOT NULL,																									"
                SQL &= Chr(13) & "	[CONSECUTIVO] [varchar](20) NOT NULL,																									"
                SQL &= Chr(13) & "	[CEDULA] [varchar](25) NOT NULL,																									"
                SQL &= Chr(13) & "	[NOMBRE] [varchar](100) NOT NULL,																									"
                SQL &= Chr(13) & "	[XML] [varchar](max) NOT NULL,																									"
                SQL &= Chr(13) & "	CONSTRAINT [PK_CXP_DOCUMENTOS_ELECTRONICOS_CORREO] PRIMARY KEY CLUSTERED 																									"
                SQL &= Chr(13) & "	(																									"
                SQL &= Chr(13) & "		[COD_CIA] ASC,																								"
                SQL &= Chr(13) & "		[CLAVE] ASC																								"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																									"
                SQL &= Chr(13) & "	) ON [PRIMARY]																									"


                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IMAP_CONFIG()
        Try
            If Not EXISTE_TABLA("IMAP_CONFIG") Then

                Dim SQL = "	CREATE TABLE [dbo].[IMAP_CONFIG](																									"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,																								"
                SQL &= Chr(13) & "		[SERVIDOR] [varchar](100) NOT NULL,																								"
                SQL &= Chr(13) & "		[USUARIO] [varchar](100) NOT NULL,																								"
                SQL &= Chr(13) & "		[CONTRASENA] [varchar](100) NOT NULL,																								"
                SQL &= Chr(13) & "		[PUERTO] [int] NOT NULL,																								"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_IMAP_CONFIG] PRIMARY KEY CLUSTERED 																									"
                SQL &= Chr(13) & "	(																									"
                SQL &= Chr(13) & "		[COD_CIA] ASC																								"
                SQL &= Chr(13) & "	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]																									"
                SQL &= Chr(13) & "	) ON [PRIMARY]																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[IMAP_CONFIG]  WITH CHECK ADD  CONSTRAINT [FK_IMAP_CONFIG_COMPANIA] FOREIGN KEY([COD_CIA])																									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[IMAP_CONFIG] CHECK CONSTRAINT [FK_IMAP_CONFIG_COMPANIA]																									"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Constraints"

    Private Sub CONSTRAINT_FK_CXP_DOCUMENTO_DET_CXP_DOCUMENTO_ENC()
        Try
            If EXISTE_CONSTRAINT("FK_CXP_DOCUMENTO_AFEC_DOCUMENTO_ENC") Then
                CONX.Coneccion_Abrir()

                Dim SQL = "	ALTER TABLE CXP_DOCUMENTO_AFEC																						"
                SQL &= Chr(13) & "	DROP CONSTRAINT FK_CXP_DOCUMENTO_AFEC_DOCUMENTO_ENC																						"
                CONX.EJECUTE(SQL)

                SQL = "	ALTER TABLE CXP_DOCUMENTO_DET																						"
                SQL &= Chr(13) & "	DROP CONSTRAINT FK_CXP_DOCUMENTO_DET_CXP_DOCUMENTO_ENC																						"
                CONX.EJECUTE(SQL)

                SQL = "	ALTER TABLE CXP_DOCUMENTO_ENC																						"
                SQL &= Chr(13) & "	DROP CONSTRAINT PK_CXP_DOCUMENTO_ENC																						"
                CONX.EJECUTE(SQL)

                SQL = "	ALTER TABLE CXP_DOCUMENTO_ENC																						"
                SQL &= Chr(13) & "	ADD CONSTRAINT PK_CXP_DOCUMENTO_ENC PRIMARY KEY (COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV, CEDULA)																						"
                CONX.EJECUTE(SQL)

                SQL = "	ALTER TABLE CXP_DOCUMENTO_DET																						"
                SQL &= Chr(13) & "	ADD CEDULA VARCHAR(25) NOT NULL DEFAULT('0')																						"
                CONX.EJECUTE(SQL)

                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CONSTRAINT_FK_PROFORMA_DET_DOCUMENTO_ENC()
        Try
            If EXISTE_CONSTRAINT("FK_PROFORMA_DET_DOCUMENTO_ENC") Then
                CONX.Coneccion_Abrir()

                Dim SQL = "	ALTER TABLE PROFORMA_DET																						"
                SQL &= Chr(13) & "	DROP CONSTRAINT FK_PROFORMA_DET_DOCUMENTO_ENC																						"
                CONX.EJECUTE(SQL)

                SQL = "	ALTER TABLE PROFORMA_DET																						"
                SQL &= Chr(13) & "	ADD CONSTRAINT FK_PROFORMA_DET_PROFORMA_ENC																					"
                SQL &= Chr(13) & "  FOREIGN KEY (COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV) REFERENCES PROFORMA_ENC(COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV)"
                CONX.EJECUTE(SQL)

                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CONSTRAINT_PK_GUIA_UBICACION()
        Try
            If EXISTE_CONSTRAINT("PK_GUIA_UBICACION") Then
                If EXISTE_CAMPO_TIPO("COD_SUCUR", "GUIA_UBICACION", "VARCHAR") Then

                    CONX.Coneccion_Abrir()

                    Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA_UBICACION				"
                    SQL &= Chr(13) & "	DROP CONSTRAINT FK_DOCUMENTO_GUIA_UBICACION_GUIA_UBICACION1		"
                    CONX.EJECUTE(SQL)

                    SQL = "	ALTER TABLE GUIA_UBICACION		"
                    SQL &= Chr(13) & "	DROP CONSTRAINT FK_GUIA_UBICACION_SUCURSAL1	"
                    CONX.EJECUTE(SQL)

                    SQL = "	ALTER TABLE GUIA_UBICACION		"
                    SQL &= Chr(13) & "	DROP CONSTRAINT PK_GUIA_UBICACION	"
                    CONX.EJECUTE(SQL)

                    CONX.Coneccion_Cerrar()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CONSTRAINT_PK_DOCUMENTO_GUIA_UBICACION()
        Try
            If EXISTE_CONSTRAINT("PK_DOCUMENTO_GUIA_UBICACION") Then
                If Not EXISTE_CAMPO_TIPO("NUMERO_GUIA", "DOCUMENTO_GUIA_UBICACION", "VARCHAR", 13) Then
                    Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA_UBICACION				"
                    SQL &= Chr(13) & "	DROP CONSTRAINT PK_DOCUMENTO_GUIA_UBICACION		"
                    CONX.Coneccion_Abrir()
                    CONX.EJECUTE(SQL)
                    CONX.Coneccion_Cerrar()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CONSTRAINT_PK_GUIA_UBICACION_CREAR()
        Try
            If Not EXISTE_CONSTRAINT("PK_GUIA_UBICACION") Then
                CONX.Coneccion_Abrir()

                Dim SQL = "	ALTER TABLE GUIA_UBICACION																						"
                SQL &= Chr(13) & "	ADD CONSTRAINT PK_GUIA_UBICACION PRIMARY KEY (COD_CIA, COD_UBICACION) "
                CONX.EJECUTE(SQL)

                SQL = "	ALTER TABLE DOCUMENTO_GUIA_UBICACION				"
                SQL &= Chr(13) & "	ADD CONSTRAINT FK_DOCUMENTO_GUIA_UBICACION_GUIA_UBICACION1		"
                SQL &= Chr(13) & "  FOREIGN KEY (COD_CIA, COD_UBICACION) REFERENCES GUIA_UBICACION(COD_CIA, COD_UBICACION)"
                CONX.EJECUTE(SQL)

                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Triggers"

    Private Sub TG_INGRESA_INVENTARIO_APARTADO_DET()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_APARTADO_DET", "2020-10-14") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_APARTADO_DET")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_APARTADO_DET] 																						"
                SQL &= Chr(13) & "		ON  [dbo].[APARTADO_DET] 																					"
                SQL &= Chr(13) & "		AFTER INSERT																					"
                SQL &= Chr(13) & "	AS 																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		INSERT INTO INVENTARIO_MOV_DET(COD_CIA,COD_SUCUR,NUMERO_MOV,COD_MOV,LINEA,COD_PROD,CANTIDAD,COSTO,COSTO_ANT,ESTANTE,FILA,COLUMNA,SISTEMA)																					"
                SQL &= Chr(13) & "		SELECT I.COD_CIA, I.COD_SUCUR, MOV.NUMERO_MOV, MOV.COD_MOV, I.LINEA, I.COD_PROD, I.CANTIDAD * CASE SUBSTRING(MOV.COD_MOV,1,1) WHEN  'S' THEN -1 ELSE 1 END, PROD.COSTO, PROD.COSTO, I.ESTANTE, I.FILA, I.COLUMNA, 'CXC'																					"
                SQL &= Chr(13) & "		FROM inserted AS I																					"
                SQL &= Chr(13) & "		INNER JOIN INVENTARIO_MOV AS MOV																					"
                SQL &= Chr(13) & "			ON MOV.COD_CIA = I.COD_CIA																				"
                SQL &= Chr(13) & "			AND MOV.COD_SUCUR = I.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND MOV.NUMERO_DOC = I.NUMERO_DOC																				"
                SQL &= Chr(13) & "			AND MOV.TIPO_MOV = I.TIPO_MOV																				"
                SQL &= Chr(13) & "			AND MOV.SISTEMA = 'CXC'																				"
                SQL &= Chr(13) & "		INNER JOIN PRODUCTO AS PROD																					"
                SQL &= Chr(13) & "			ON PROD.COD_CIA = I.COD_CIA																				"
                SQL &= Chr(13) & "          AND PROD.COD_SUCUR = I.COD_SUCUR    "
                SQL &= Chr(13) & "			AND PROD.COD_PROD = I.COD_PROD																				"
                SQL &= Chr(13) & "	END																						"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_INVENTARIO_MOV_CXP_DET()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_CXP_DET", "2020-11-17") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_MOV_CXP_DET")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_MOV_CXP_DET] 																						"
                SQL &= Chr(13) & "	   ON  [dbo].[CXP_DOCUMENTO_DET] 																						"
                SQL &= Chr(13) & "	   AFTER INSERT																						"
                SQL &= Chr(13) & "	AS 																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		INSERT INTO INVENTARIO_MOV_DET(COD_CIA,COD_SUCUR,NUMERO_MOV,COD_MOV,LINEA,COD_PROD,CANTIDAD,COSTO,COSTO_ANT,ESTANTE,FILA,COLUMNA,SISTEMA)																					"
                SQL &= Chr(13) & "		SELECT I.COD_CIA, I.COD_SUCUR, MOV.NUMERO_MOV, MOV.COD_MOV, I.LINEA, I.COD_PROD, I.CANTIDAD * CASE SUBSTRING(MOV.COD_MOV,1,1) WHEN  'S' THEN -1 ELSE 1 END, I.PRECIO, PROD.COSTO, I.ESTANTE, I.FILA, I.COLUMNA, 'CXP'																					"
                SQL &= Chr(13) & "		FROM inserted AS I																					"
                SQL &= Chr(13) & "		INNER JOIN INVENTARIO_MOV AS MOV																					"
                SQL &= Chr(13) & "			ON MOV.COD_CIA = I.COD_CIA																				"
                SQL &= Chr(13) & "			AND MOV.COD_SUCUR = I.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND MOV.NUMERO_DOC = I.NUMERO_DOC																				"
                SQL &= Chr(13) & "			AND MOV.TIPO_MOV = I.TIPO_MOV																				"
                SQL &= Chr(13) & "			AND MOV.CEDULA = I.CEDULA "
                SQL &= Chr(13) & "			AND MOV.SISTEMA = 'CXP'																				"
                SQL &= Chr(13) & "		INNER JOIN PRODUCTO AS PROD																					"
                SQL &= Chr(13) & "			ON PROD.COD_CIA = I.COD_CIA																				"
                SQL &= Chr(13) & "          AND PROD.COD_SUCUR = I.COD_SUCUR    "
                SQL &= Chr(13) & "			AND PROD.COD_PROD = I.COD_PROD																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		IF (SELECT COUNT(*)																					"
                SQL &= Chr(13) & "			FROM inserted AS I																				"
                SQL &= Chr(13) & "			INNER JOIN INVENTARIO_MOV AS MOV																				"
                SQL &= Chr(13) & "				ON MOV.COD_CIA = I.COD_CIA																			"
                SQL &= Chr(13) & "				AND MOV.COD_SUCUR = I.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND MOV.NUMERO_DOC = I.NUMERO_DOC																			"
                SQL &= Chr(13) & "				AND MOV.TIPO_MOV = I.TIPO_MOV																			"
                SQL &= Chr(13) & "			    AND MOV.CEDULA = I.CEDULA "
                SQL &= Chr(13) & "			    AND MOV.SISTEMA = 'CXP'																				"
                SQL &= Chr(13) & "			INNER JOIN PROVEEDOR AS PROV																				"
                SQL &= Chr(13) & "				ON PROV.COD_CIA = MOV.COD_CIA																			"
                SQL &= Chr(13) & "				AND PROV.COD_SUCUR = MOV.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND PROV.CEDULA = MOV.CEDULA																			"
                SQL &= Chr(13) & "			WHERE PROV.PORCENTAJE_VENTA > 0) > 0																				"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			UPDATE PRODUCTO																				"
                SQL &= Chr(13) & "			SET COSTO = T1.PRECIO, PRECIO = T1.PRECIO_VENTA																				"
                SQL &= Chr(13) & "			FROM(																				"
                SQL &= Chr(13) & "				SELECT P.COD_CIA, P.COD_SUCUR, P.COD_PROD, D.PRECIO, (D.PRECIO + ((D.PRECIO * PROV.PORCENTAJE_VENTA) / 100)) AS PRECIO_VENTA																			"
                SQL &= Chr(13) & "				FROM inserted AS D																			"
                SQL &= Chr(13) & "				INNER JOIN PRODUCTO AS P 																			"
                SQL &= Chr(13) & "					ON P.COD_CIA = D.COD_CIA																		"
                SQL &= Chr(13) & "					AND P.COD_SUCUR = D.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND P.COD_PROD = D.COD_PROD																		"
                SQL &= Chr(13) & "				INNER JOIN PROVEEDOR AS PROV																			"
                SQL &= Chr(13) & "					ON PROV.COD_CIA = P.COD_CIA																		"
                SQL &= Chr(13) & "					AND PROV.COD_SUCUR = P.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND PROV.CEDULA = P.CEDULA																		"
                SQL &= Chr(13) & "				WHERE P.COSTO < D.PRECIO																			"
                SQL &= Chr(13) & "			) AS T1																				"
                SQL &= Chr(13) & "			WHERE T1.COD_CIA = PRODUCTO.COD_CIA																				"
                SQL &= Chr(13) & "			AND T1.COD_SUCUR = PRODUCTO.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND T1.COD_PROD = PRODUCTO.COD_PROD																				"
                SQL &= Chr(13) & "		END																					"
                SQL &= Chr(13) & "		ELSE																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			UPDATE PRODUCTO																				"
                SQL &= Chr(13) & "			SET COSTO = T1.PRECIO																				"
                SQL &= Chr(13) & "			FROM(																				"
                SQL &= Chr(13) & "				SELECT P.COD_CIA, P.COD_SUCUR, P.COD_PROD, D.PRECIO																			"
                SQL &= Chr(13) & "				FROM inserted AS D																			"
                SQL &= Chr(13) & "				INNER JOIN PRODUCTO AS P 																			"
                SQL &= Chr(13) & "					ON P.COD_CIA = D.COD_CIA																		"
                SQL &= Chr(13) & "					AND P.COD_SUCUR = D.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND P.COD_PROD = D.COD_PROD																		"
                SQL &= Chr(13) & "				WHERE P.COSTO < D.PRECIO																			"
                SQL &= Chr(13) & "			) AS T1																				"
                SQL &= Chr(13) & "			WHERE T1.COD_CIA = PRODUCTO.COD_CIA																				"
                SQL &= Chr(13) & "			AND T1.COD_SUCUR = PRODUCTO.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND T1.COD_PROD = PRODUCTO.COD_PROD																				"
                SQL &= Chr(13) & "		END																					"
                SQL &= Chr(13) & "	END																						"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_INVENTARIO_MOV_ENC()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_ENC", "2020-10-12") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_MOV_ENC")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_MOV_ENC] 																						"
                SQL &= Chr(13) & "	   ON  [dbo].[DOCUMENTO_ENC] 																						"
                SQL &= Chr(13) & "	   AFTER INSERT																						"
                SQL &= Chr(13) & "	AS 																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		DECLARE @TIPO_NOTA VARCHAR(2), @TIPO_MOV VARCHAR(2)																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		SELECT  @TIPO_NOTA = TIPO_NOTA, @TIPO_MOV = TIPO_MOV 																					"
                SQL &= Chr(13) & "		FROM inserted																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		IF @TIPO_MOV = 'NC'																					"
                SQL &= Chr(13) & "			BEGIN 																				"
                SQL &= Chr(13) & "				IF @TIPO_NOTA = 'DV'																			"
                SQL &= Chr(13) & "					BEGIN																		"
                SQL &= Chr(13) & "						INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC,SISTEMA)																	"
                SQL &= Chr(13) & "						SELECT COD_CIA, COD_SUCUR, CASE TIPO_NOTA WHEN 'DV' THEN 'EPD' ELSE 'SPV' END AS COD_MOV, CEDULA, TIPO_MOV, NUMERO_DOC, COD_USUARIO, FECHA_INC, 'CXC'																	"
                SQL &= Chr(13) & "						FROM inserted 																	"
                SQL &= Chr(13) & "						WHERE TIPO_MOV IN ('FA', 'FC', 'NC')																	"
                SQL &= Chr(13) & "					END																		"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		ELSE IF @TIPO_MOV IN ('FA','FC')																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC,SISTEMA)																				"
                SQL &= Chr(13) & "			SELECT COD_CIA, COD_SUCUR, 'SPV' AS COD_MOV, CEDULA, TIPO_MOV, NUMERO_DOC, COD_USUARIO, FECHA_INC,'CXC'																				"
                SQL &= Chr(13) & "			FROM inserted 																				"
                SQL &= Chr(13) & "			WHERE TIPO_MOV IN ('FA', 'FC', 'NC')																				"
                SQL &= Chr(13) & "		END																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	END																						"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_DOCUMENTO_AFEC_DET_PRODUCTOS()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_DOCUMENTO_AFEC_DET_PRODUCTOS", "2020-10-23") Then
                ELIMINA_TRIGGER("TG_INGRESA_DOCUMENTO_AFEC_DET_PRODUCTOS")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_DOCUMENTO_AFEC_DET_PRODUCTOS] 																						"
                SQL &= Chr(13) & "	   ON  [dbo].[DOCUMENTO_AFEC_DET_PRODUCTOS] 																						"
                SQL &= Chr(13) & "	   AFTER INSERT																						"
                SQL &= Chr(13) & "	AS 																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		INSERT INTO INVENTARIO_MOV_DET(COD_CIA,COD_SUCUR,NUMERO_MOV,COD_MOV,LINEA,COD_PROD,CANTIDAD,COSTO,COSTO_ANT,ESTANTE,FILA,COLUMNA,SISTEMA)																					"
                SQL &= Chr(13) & "		SELECT I.COD_CIA, I.COD_SUCUR, MOV.NUMERO_MOV, MOV.COD_MOV, I.LINEA, I.COD_PROD, I.CANTIDAD * CASE SUBSTRING(MOV.COD_MOV,1,1) WHEN  'S' THEN -1 ELSE 1 END, PROD.COSTO, PROD.COSTO, I.ESTANTE, I.FILA, I.COLUMNA,'CXC'																					"
                SQL &= Chr(13) & "		FROM inserted AS I																					"
                SQL &= Chr(13) & "		INNER JOIN INVENTARIO_MOV AS MOV																					"
                SQL &= Chr(13) & "			ON MOV.COD_CIA = I.COD_CIA																				"
                SQL &= Chr(13) & "			AND MOV.COD_SUCUR = I.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND MOV.NUMERO_DOC = I.NUMERO_DOC																				"
                SQL &= Chr(13) & "			AND MOV.TIPO_MOV = I.TIPO_MOV																				"
                SQL &= Chr(13) & "			AND MOV.SISTEMA = 'CXC'																				"
                SQL &= Chr(13) & "		INNER JOIN PRODUCTO AS PROD																					"
                SQL &= Chr(13) & "			ON PROD.COD_CIA = I.COD_CIA																				"
                SQL &= Chr(13) & "          AND PROD.COD_SUCUR = I.COD_SUCUR"
                SQL &= Chr(13) & "			AND PROD.COD_PROD = I.COD_PROD																				"
                SQL &= Chr(13) & "	END																						"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_INVENTARIO_MOV_ENC_INV()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_ENC_INV", "2020-12-20") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_MOV_ENC_INV")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_MOV_ENC_INV] 																									"
                SQL &= Chr(13) & "		   ON  [dbo].[INVENTARIO_ENC] 																								"
                SQL &= Chr(13) & "		   AFTER INSERT																								"
                SQL &= Chr(13) & "		AS 																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			DECLARE @COD_MOV VARCHAR(3)																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			SELECT  @COD_MOV = COD_MOV																							"
                SQL &= Chr(13) & "			FROM inserted																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC,SISTEMA)																							"
                SQL &= Chr(13) & "			SELECT COD_CIA, COD_SUCUR, @COD_MOV , CEDULA, TIPO_MOV, NUMERO_DOC, COD_USUARIO, FECHA_INC, 'INV'																							"
                SQL &= Chr(13) & "			FROM inserted 																							"
                SQL &= Chr(13) & "			WHERE TIPO_MOV IN ('IN')																							"
                SQL &= Chr(13) & "		END																								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_INVENTARIO_MOV_DET_INV()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_DET_INV", "2020-12-20") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_MOV_DET_INV")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_MOV_DET_INV] 																									"
                SQL &= Chr(13) & "		   ON  [dbo].[INVENTARIO_DET] 																								"
                SQL &= Chr(13) & "		   AFTER INSERT																								"
                SQL &= Chr(13) & "		AS 																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			INSERT INTO INVENTARIO_MOV_DET(COD_CIA,COD_SUCUR,NUMERO_MOV,COD_MOV,LINEA,COD_PROD,CANTIDAD,COSTO,COSTO_ANT,ESTANTE,FILA,COLUMNA,SISTEMA)																							"
                SQL &= Chr(13) & "			SELECT I.COD_CIA, I.COD_SUCUR, MOV.NUMERO_MOV, MOV.COD_MOV, I.LINEA, I.COD_PROD, I.CANTIDAD * CASE SUBSTRING(MOV.COD_MOV,1,1) WHEN  'S' THEN -1 ELSE 1 END, PROD.COSTO, PROD.COSTO, I.ESTANTE, I.FILA, I.COLUMNA,'INV'																							"
                SQL &= Chr(13) & "			FROM inserted AS I																							"
                SQL &= Chr(13) & "			INNER JOIN INVENTARIO_MOV AS MOV																							"
                SQL &= Chr(13) & "				ON MOV.COD_CIA = I.COD_CIA																						"
                SQL &= Chr(13) & "				AND MOV.COD_SUCUR = I.COD_SUCUR																						"
                SQL &= Chr(13) & "				AND MOV.NUMERO_DOC = I.NUMERO_DOC																						"
                SQL &= Chr(13) & "				AND MOV.TIPO_MOV = I.TIPO_MOV																						"
                SQL &= Chr(13) & "				AND MOV.SISTEMA = 'INV'																						"
                SQL &= Chr(13) & "			INNER JOIN PRODUCTO AS PROD																							"
                SQL &= Chr(13) & "				ON PROD.COD_CIA = I.COD_CIA																						"
                SQL &= Chr(13) & "				AND PROD.COD_SUCUR = I.COD_SUCUR																						"
                SQL &= Chr(13) & "				AND PROD.COD_PROD = I.COD_PROD																						"
                SQL &= Chr(13) & "		END																								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_INVENTARIO_MOV_DET()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_DET", "2020-10-14") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_MOV_DET")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_MOV_DET] 																						"
                SQL &= Chr(13) & "	   ON  [dbo].[DOCUMENTO_DET] 																						"
                SQL &= Chr(13) & "	   AFTER INSERT																						"
                SQL &= Chr(13) & "	AS 																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		INSERT INTO INVENTARIO_MOV_DET(COD_CIA,COD_SUCUR,NUMERO_MOV,COD_MOV,LINEA,COD_PROD,CANTIDAD,COSTO,COSTO_ANT,ESTANTE,FILA,COLUMNA,SISTEMA)																					"
                SQL &= Chr(13) & "		SELECT I.COD_CIA, I.COD_SUCUR, MOV.NUMERO_MOV, MOV.COD_MOV, I.LINEA, I.COD_PROD, I.CANTIDAD * CASE SUBSTRING(MOV.COD_MOV,1,1) WHEN  'S' THEN -1 ELSE 1 END, PROD.COSTO, PROD.COSTO, I.ESTANTE, I.FILA, I.COLUMNA,'CXC'																					"
                SQL &= Chr(13) & "		FROM inserted AS I																					"
                SQL &= Chr(13) & "		INNER JOIN INVENTARIO_MOV AS MOV																					"
                SQL &= Chr(13) & "			ON MOV.COD_CIA = I.COD_CIA																				"
                SQL &= Chr(13) & "			AND MOV.COD_SUCUR = I.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND MOV.NUMERO_DOC = I.NUMERO_DOC																				"
                SQL &= Chr(13) & "			AND MOV.TIPO_MOV = I.TIPO_MOV																				"
                SQL &= Chr(13) & "			AND MOV.SISTEMA = 'CXC'																				"
                SQL &= Chr(13) & "		INNER JOIN PRODUCTO AS PROD																					"
                SQL &= Chr(13) & "			ON PROD.COD_CIA = I.COD_CIA																				"
                SQL &= Chr(13) & "          AND PROD.COD_SUCUR = I.COD_SUCUR"
                SQL &= Chr(13) & "			AND PROD.COD_PROD = I.COD_PROD																				"
                SQL &= Chr(13) & "	END																						"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_INVENTARIO_MOV_CXP_ENC()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_CXP_ENC", "2020-10-12") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_MOV_CXP_ENC")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_MOV_CXP_ENC] 																						"
                SQL &= Chr(13) & "	   ON  [dbo].[CXP_DOCUMENTO_ENC] 																						"
                SQL &= Chr(13) & "	   AFTER INSERT																						"
                SQL &= Chr(13) & "	AS 																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		DECLARE @TIPO_NOTA VARCHAR(2), @TIPO_MOV VARCHAR(2)																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		SELECT  @TIPO_NOTA = TIPO_NOTA, @TIPO_MOV = TIPO_MOV 																					"
                SQL &= Chr(13) & "		FROM inserted																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		IF @TIPO_MOV = 'NC'																					"
                SQL &= Chr(13) & "			BEGIN 																				"
                SQL &= Chr(13) & "				IF @TIPO_NOTA = 'DV'																			"
                SQL &= Chr(13) & "					BEGIN																		"
                SQL &= Chr(13) & "						INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC,SISTEMA)																	"
                SQL &= Chr(13) & "						SELECT COD_CIA, COD_SUCUR, CASE TIPO_NOTA WHEN 'DV' THEN 'SPD' ELSE 'EPC' END AS COD_MOV, CEDULA, TIPO_MOV, NUMERO_DOC, COD_USUARIO, FECHA_INC, 'CXP'																	"
                SQL &= Chr(13) & "						FROM inserted 																	"
                SQL &= Chr(13) & "						WHERE TIPO_MOV IN ('FA', 'FC', 'NC')																	"
                SQL &= Chr(13) & "					END																		"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		ELSE IF @TIPO_NOTA IS NULL																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC,SISTEMA)																				"
                SQL &= Chr(13) & "			SELECT COD_CIA, COD_SUCUR, CASE TIPO_NOTA WHEN 'DV' THEN 'SPD' ELSE 'EPC' END AS COD_MOV, CEDULA, TIPO_MOV, NUMERO_DOC, COD_USUARIO, FECHA_INC, 'CXP'																				"
                SQL &= Chr(13) & "			FROM inserted 																				"
                SQL &= Chr(13) & "			WHERE TIPO_MOV IN ('FA', 'FC', 'NC')																				"
                SQL &= Chr(13) & "		END																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	END																						"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_INVENTARIO_APARTADO_ENC()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_APARTADO_ENC", "2020-10-13") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_APARTADO_ENC")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_APARTADO_ENC] 																						"
                SQL &= Chr(13) & "		   ON  [dbo].[APARTADO_ENC] 																					"
                SQL &= Chr(13) & "		   AFTER INSERT																					"
                SQL &= Chr(13) & "		AS 																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			DECLARE @TIPO_NOTA VARCHAR(2), @TIPO_MOV VARCHAR(2)																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT  @TIPO_NOTA = TIPO_NOTA, @TIPO_MOV = TIPO_MOV 																				"
                SQL &= Chr(13) & "			FROM inserted																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			IF @TIPO_NOTA IS NULL																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC,SISTEMA)																			"
                SQL &= Chr(13) & "				SELECT COD_CIA, COD_SUCUR, CASE TIPO_NOTA WHEN 'DV' THEN 'EPD' ELSE 'SPV' END AS COD_MOV, CEDULA, TIPO_MOV, NUMERO_DOC, COD_USUARIO, FECHA_INC, 'CXC'																			"
                SQL &= Chr(13) & "				FROM inserted 																			"
                SQL &= Chr(13) & "				WHERE TIPO_MOV IN ('AA', 'AC')																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		END																					"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Campos"

    Private Sub PRODUCTO_COD_FAMILIA()
        Try
            If Not EXISTE_CAMPO("COD_FAMILIA", "PRODUCTO") Then

                Dim SQL = "	ALTER TABLE PRODUCTO	"
                SQL &= Chr(13) & "	ADD COD_FAMILIA VARCHAR(3) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PRODUCTO_OBSERVACION()
        Try
            If Not EXISTE_CAMPO("OBSERVACION", "PRODUCTO") Then

                Dim SQL = "	ALTER TABLE PRODUCTO	"
                SQL &= Chr(13) & "	ADD OBSERVACION VARCHAR(150) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PRODUCTO_IND_PRECIO_MODIFICABLE()
        Try
            If Not EXISTE_CAMPO("IND_PRECIO_MODIFICABLE", "PRODUCTO") Then

                Dim SQL = "	ALTER TABLE PRODUCTO	"
                SQL &= Chr(13) & "	ADD IND_PRECIO_MODIFICABLE CHAR(1) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SUCURSAL_IND_AVISO_MIN_STOCK()
        Try
            If Not EXISTE_CAMPO("IND_AVISO_MIN_STOCK", "SUCURSAL_INDICADORES") Then

                Dim SQL = "	ALTER TABLE SUCURSAL_INDICADORES	"
                SQL &= Chr(13) & "	ADD IND_AVISO_MIN_STOCK CHAR(1) NOT NULL DEFAULT ('N') "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SUCURSAL_ETIQUETA()
        Try
            If Not EXISTE_CAMPO("IMPRESION_ETIQUETA", "SUCURSAL") Then

                Dim SQL = "	ALTER TABLE SUCURSAL	"
                SQL &= Chr(13) & "	ADD IMPRESION_ETIQUETA varchar(150) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

            If Not EXISTE_CAMPO("ANCHO_ETIQUETA", "SUCURSAL") Then

                Dim SQL = "	ALTER TABLE SUCURSAL	"
                SQL &= Chr(13) & "	ADD ANCHO_ETIQUETA int NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DOCUMENTO_GUIA_CAMPOS()
        Try
            If Not EXISTE_CAMPO("ENVIA", "DOCUMENTO_GUIA") Then

                Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA	"
                SQL &= Chr(13) & "	ADD ENVIA varchar(300) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

            If Not EXISTE_CAMPO("RETIRA", "DOCUMENTO_GUIA") Then

                Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA	"
                SQL &= Chr(13) & "	ADD RETIRA varchar(300) NULL"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If


            If Not EXISTE_CAMPO("DESCRIPCION", "DOCUMENTO_GUIA") Then

                Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA	"
                SQL &= Chr(13) & "	ADD DESCRIPCION varchar(300) NULL"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

            If Not EXISTE_CAMPO("VALOR_ENCOMIENDA", "DOCUMENTO_GUIA") Then

                Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA	"
                SQL &= Chr(13) & "	ADD VALOR_ENCOMIENDA money NULL"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

            If Not EXISTE_CAMPO("TELEFONO_RETIRA", "DOCUMENTO_GUIA") Then

                Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA	"
                SQL &= Chr(13) & "	ADD TELEFONO_RETIRA varchar(10) NULL"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

            If Not EXISTE_CAMPO("COD_DERECHO", "DOCUMENTO_GUIA") Then

                Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA	"
                SQL &= Chr(13) & "	ADD COD_DERECHO varchar(3) NULL"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub INVENTARIO_MOV_SISTEMA()
        Try
            If Not EXISTE_CAMPO("SISTEMA", "INVENTARIO_MOV") Then

                Dim SQL = "	ALTER TABLE INVENTARIO_MOV	"
                SQL &= Chr(13) & "	ADD SISTEMA VARCHAR(50) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub INVENTARIO_MOV_DET_SISTEMA()
        Try
            If Not EXISTE_CAMPO("SISTEMA", "INVENTARIO_MOV_DET") Then

                Dim SQL = "	ALTER TABLE INVENTARIO_MOV_DET	"
                SQL &= Chr(13) & "	ADD SISTEMA VARCHAR(50) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub COD_CABYS_PRODUCTO()
        Try
            If Not EXISTE_CAMPO("COD_CABYS", "PRODUCTO") Then

                Dim SQL = "	ALTER TABLE PRODUCTO	"
                SQL &= Chr(13) & "	ADD COD_CABYS VARCHAR(13) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PROVEEDOR_PORCENTAJE_VENTA()
        Try
            If Not EXISTE_CAMPO("PORCENTAJE_VENTA", "PROVEEDOR") Then

                Dim SQL = "	ALTER TABLE PROVEEDOR	"
                SQL &= Chr(13) & "	ADD PORCENTAJE_VENTA INT NOT NULL DEFAULT(0) "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SUCURSAL_INDICADORES_CAMPOS()
        Try
            If Not EXISTE_CAMPO("IND_RECIBO_AUTOMATICO", "SUCURSAL_INDICADORES") Then

                Dim SQL = "	ALTER TABLE SUCURSAL_INDICADORES	"
                SQL &= Chr(13) & "	ADD IND_RECIBO_AUTOMATICO CHAR(1) NOT NULL DEFAULT('N') "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

            If Not EXISTE_CAMPO("IND_MENSAJE_FACTURACION", "SUCURSAL_INDICADORES") Then

                Dim SQL = "	ALTER TABLE SUCURSAL_INDICADORES	"
                SQL &= Chr(13) & "	ADD IND_MENSAJE_FACTURACION CHAR(1) NOT NULL DEFAULT('N') "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CLIENTE_PRECIO_DEFECTO()
        Try
            If Not EXISTE_CAMPO("PRECIO_DEFECTO", "CLIENTE") Then

                Dim SQL = "	ALTER TABLE CLIENTE	"
                SQL &= Chr(13) & "	ADD PRECIO_DEFECTO INT NOT NULL DEFAULT(0) "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PRODUCTO_IMG_BARRA()
        Try
            If Not EXISTE_CAMPO("IMG_BARRA", "PRODUCTO") Then

                Dim SQL = "	ALTER TABLE PRODUCTO "
                SQL &= Chr(13) & "	ADD IMG_BARRA IMAGE NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IND_IMAGEN_TIQUETE()
        Try
            If Not EXISTE_CAMPO("IND_IMAGEN_TIQUETE", "COMPANIA") Then

                Dim SQL = "	ALTER TABLE COMPANIA "
                SQL &= Chr(13) & "	ADD IND_IMAGEN_TIQUETE CHAR(1) "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IND_AUTOCOMPLETAR_CLIENTE()
        Try
            If Not EXISTE_CAMPO("IND_AUTOCOMPLETAR_CLIENTE", "SUCURSAL_INDICADORES") Then

                Dim SQL = "	ALTER TABLE SUCURSAL_INDICADORES "
                SQL &= Chr(13) & "	ADD IND_AUTOCOMPLETAR_CLIENTE CHAR(1) NOT NULL DEFAULT('N') "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

            If Not EXISTE_CAMPO("IND_INGRESO_AUTO", "SUCURSAL_INDICADORES") Then

                Dim SQL = "	ALTER TABLE SUCURSAL_INDICADORES "
                SQL &= Chr(13) & "	ADD IND_INGRESO_AUTO CHAR(1) NOT NULL DEFAULT('N') "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

            If Not EXISTE_CAMPO("IND_SUMAR_CANTIDADES", "SUCURSAL_INDICADORES") Then

                Dim SQL = "	ALTER TABLE SUCURSAL_INDICADORES "
                SQL &= Chr(13) & "	ADD IND_SUMAR_CANTIDADES CHAR(1) NOT NULL DEFAULT('N') "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MIN_VENTA()
        Try
            If Not EXISTE_CAMPO("MIN_VENTA", "PRODUCTO") Then

                Dim SQL = "	ALTER TABLE PRODUCTO "
                SQL &= Chr(13) & "	ADD MIN_VENTA MONEY NOT NULL DEFAULT(1) "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TIPO_INGRESO()
        Try
            If Not EXISTE_CAMPO("TIPO_INGRESO", "CXP_DOCUMENTOS_ELECTRONICOS") Then

                Dim SQL = "	ALTER TABLE CXP_DOCUMENTOS_ELECTRONICOS "
                SQL &= Chr(13) & "	ADD TIPO_INGRESO VARCHAR(2) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub IND_TIPO()
        Try
            If Not EXISTE_CAMPO("IND_TIPO", "GUIA_UBICACION") Then

                Dim SQL = "	ALTER TABLE GUIA_UBICACION "
                SQL &= Chr(13) & "	ADD IND_TIPO CHAR(1) NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DESCUENTO()
        Try
            If Not EXISTE_CAMPO("DESCUENTO", "PRODUCTO") Then

                Dim SQL = "	ALTER TABLE PRODUCTO "
                SQL &= Chr(13) & "	ADD DESCUENTO INT NULL "

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Procedimientos"
    Private Sub USP_APARTADO_TMP_A_REAL()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_APARTADO_TMP_A_REAL", "2020-10-07") Then
                ELIMINA_PROCEDIMIENTO("USP_APARTADO_TMP_A_REAL")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_APARTADO_TMP_A_REAL] 																				"
                SQL &= Chr(13) & "	 @COD_CIA VARCHAR(3)																				"
                SQL &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)																				"
                SQL &= Chr(13) & "	,@TIPO_MOV VARCHAR(2)																				"
                SQL &= Chr(13) & "	,@CODIGO VARCHAR(20)																				"
                SQL &= Chr(13) & "	AS																				"
                SQL &= Chr(13) & "	BEGIN																				"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																			"
                SQL &= Chr(13) & "		BEGIN TRY																			"
                SQL &= Chr(13) & "		BEGIN TRAN TR_APARTADO_TMP_A_REAL																			"
                SQL &= Chr(13) & "		DECLARE @NUMERO_DOC INTEGER																			"
                SQL &= Chr(13) & "		DECLARE @TIPO_NOTA AS VARCHAR(2), @CEDULA VARCHAR(25)																			"
                SQL &= Chr(13) & "		DECLARE @FECHA_DOC AS DATETIME																			"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "		IF NOT EXISTS(SELECT TMP.*																			"
                SQL &= Chr(13) & "			FROM APARTADO_ENC_TMP AS TMP																		"
                SQL &= Chr(13) & "			INNER JOIN APARTADO_DET_TMP AS DET	 																	"
                SQL &= Chr(13) & "	            ON DET.COD_CIA = TMP.COD_CIA 																				"
                SQL &= Chr(13) & "	            AND DET.COD_SUCUR = TMP.COD_SUCUR 																				"
                SQL &= Chr(13) & "	            AND DET.CODIGO = TMP.CODIGO 																				"
                SQL &= Chr(13) & "	            AND DET.TIPO_MOV = TMP.TIPO_MOV																				"
                SQL &= Chr(13) & "			WHERE TMP.COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "			AND TMP.COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "			AND TMP.TIPO_MOV = 	@TIPO_MOV																	"
                SQL &= Chr(13) & "			AND TMP.CODIGO = @CODIGO)																		"
                SQL &= Chr(13) & "			BEGIN																		"
                SQL &= Chr(13) & "				RAISERROR('El código de factura no existe en los temporales', 17, 1)																	"
                SQL &= Chr(13) & "			END																		"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "		IF @TIPO_MOV = 'AA' OR @TIPO_MOV = 'AC'																			"
                SQL &= Chr(13) & "			BEGIN																		"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC =  ISNULL(MAX(NUMERO_DOC), 0) + 1 																	"
                SQL &= Chr(13) & "				FROM APARTADO_ENC																	"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "				AND TIPO_MOV <> 'NC' 																	"
                SQL &= Chr(13) & "			END																		"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			IF @TIPO_MOV = 'AA' OR @TIPO_MOV = 'AC'																		"
                SQL &= Chr(13) & "			BEGIN																		"
                SQL &= Chr(13) & "			/*INGRESA EL ENCABEZADO*/																		"
                SQL &= Chr(13) & "			INSERT INTO APARTADO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)																		"
                SQL &= Chr(13) & "			SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO, SUM(DET.SUBTOTAL), SUM(DET.IMPUESTO), SUM(DET.TOTAL),TMP.COD_MONEDA																		"
                SQL &= Chr(13) & "			,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION,TMP.TIPO_NOTA																		"
                SQL &= Chr(13) & "			FROM APARTADO_ENC_TMP AS TMP																		"
                SQL &= Chr(13) & "			INNER JOIN APARTADO_DET_TMP AS DET	 																	"
                SQL &= Chr(13) & "	            ON DET.COD_CIA = TMP.COD_CIA 																				"
                SQL &= Chr(13) & "	            AND DET.COD_SUCUR = TMP.COD_SUCUR 																				"
                SQL &= Chr(13) & "	            AND DET.CODIGO = TMP.CODIGO 																				"
                SQL &= Chr(13) & "	            AND DET.TIPO_MOV = TMP.TIPO_MOV																				"
                SQL &= Chr(13) & "			WHERE TMP.COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "			AND TMP.COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "			AND TMP.TIPO_MOV = 	@TIPO_MOV																	"
                SQL &= Chr(13) & "			AND TMP.CODIGO = @CODIGO																		"
                SQL &= Chr(13) & "			GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO,TMP.DESCRIPCION,TMP.TIPO_NOTA																		"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			/*INGRESA EL DETALLE*/																		"
                SQL &= Chr(13) & "			INSERT INTO APARTADO_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA)																		"
                SQL &= Chr(13) & "			SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA																		"
                SQL &= Chr(13) & "			FROM APARTADO_DET_TMP																		"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "			AND CODIGO = @CODIGO																		"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			DELETE FROM APARTADO_ENC_TMP WHERE CODIGO = @CODIGO																		"
                SQL &= Chr(13) & "	        DELETE FROM APARTADO_DET_TMP WHERE CODIGO = @CODIGO																				"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			SELECT @FECHA_DOC = FECHA, @CEDULA = CEDULA																		"
                SQL &= Chr(13) & "			FROM APARTADO_ENC																		"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "			AND TIPO_MOV = 	@TIPO_MOV 																	"
                SQL &= Chr(13) & "			AND NUMERO_DOC = @NUMERO_DOC																		"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			SELECT @NUMERO_DOC AS Documento																		"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			END																		"
                SQL &= Chr(13) & "		COMMIT TRAN TR_APARTADO_TMP_A_REAL																			"
                SQL &= Chr(13) & "		END TRY																			"
                SQL &= Chr(13) & "		BEGIN CATCH 																			"
                SQL &= Chr(13) & "	 		ROLLBACK TRAN																		"
                SQL &= Chr(13) & "	 		DECLARE @MENSAJE VARCHAR(500)																		"
                SQL &= Chr(13) & "	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																		"
                SQL &= Chr(13) & "	 		RAISERROR( @MENSAJE, 16, 1)																		"
                SQL &= Chr(13) & "		END CATCH																			"
                SQL &= Chr(13) & "	END																				"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DATOS_IMP_ENCOMIENDA_POR_FECHA()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_IMP_ENCOMIENDA_POR_FECHA", "2020-10-23") Then
                ELIMINA_PROCEDIMIENTO("USP_DATOS_IMP_ENCOMIENDA_POR_FECHA")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_IMP_ENCOMIENDA_POR_FECHA] 																				"
                SQL &= Chr(13) & "		    @COD_CIA VARCHAR(3),																			"
                SQL &= Chr(13) & "			@COD_SUCUR VARCHAR(3),																		"
                SQL &= Chr(13) & "			@DESDE DATETIME, 																		"
                SQL &= Chr(13) & "			@HASTA DATETIME																		"
                SQL &= Chr(13) & "		AS   																			"
                SQL &= Chr(13) & "		BEGIN																			"
                SQL &= Chr(13) & "			BEGIN TRY																		"
                SQL &= Chr(13) & "			BEGIN TRAN TSN_FAMILIA_MANT																		"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			DECLARE @NOTA AS VARCHAR(MAX)																		"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			SELECT GUIA.ENVIA AS ENVIA,																		"
                SQL &= Chr(13) & "			GUIA.RETIRA AS RETIRA,																		"
                SQL &= Chr(13) & "			ORIGEN.DESC_UBICACION AS ORIGEN, DESTINO.DESC_UBICACION AS DESTINO, GUIA.CANT_BULTOS AS BULTOS																		"
                SQL &= Chr(13) & "			,GUIA.NUMERO_GUIA, GUIA.TELEFONO_RETIRA																		"
                SQL &= Chr(13) & "			,CONCAT(@NOTA, CASE WHEN ENC.DESCRIPCION <> '' THEN 'Guia: ' + GUIA.NUMERO_GUIA + ' Detalle: ' + ENC.DESCRIPCION END) AS DETALLE_INTERNO																		"
                SQL &= Chr(13) & "          ,ENC.NUMERO_DOC"
                SQL &= Chr(13) & "			FROM DOCUMENTO_GUIA AS GUIA																		"
                SQL &= Chr(13) & "			INNER JOIN DOCUMENTO_ENC AS ENC																		"
                SQL &= Chr(13) & "				ON ENC.COD_CIA = GUIA.COD_CIA																	"
                SQL &= Chr(13) & "			    AND ENC.COD_SUCUR = GUIA.COD_SUCUR"
                SQL &= Chr(13) & "				AND ENC.NUMERO_DOC = Guia.NUMERO_DOC																	"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = GUIA.TIPO_MOV																	"
                SQL &= Chr(13) & "			INNER JOIN GUIA_UBICACION AS ORIGEN																		"
                SQL &= Chr(13) & "				ON ORIGEN.COD_CIA = GUIA.COD_CIA																	"
                SQL &= Chr(13) & "				AND ORIGEN.COD_UBICACION = GUIA.ORIGEN																	"
                SQL &= Chr(13) & "			INNER JOIN GUIA_UBICACION AS DESTINO																		"
                SQL &= Chr(13) & "				ON DESTINO.COD_CIA = GUIA.COD_CIA																	"
                SQL &= Chr(13) & "				AND DESTINO.COD_UBICACION = GUIA.DESTINO																	"
                SQL &= Chr(13) & "			WHERE GUIA.COD_CIA =  @COD_CIA																		"
                SQL &= Chr(13) & "			AND GUIA.COD_SUCUR =  @COD_SUCUR																		"
                SQL &= Chr(13) & "			AND GUIA.ESTADO = 'P'																		"
                SQL &= Chr(13) & "			AND GUIA.FECHA_INC BETWEEN @DESDE AND @HASTA																		"
                SQL &= Chr(13) & "          ORDER BY GUIA.NUMERO_GUIA ASC"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "		COMMIT TRAN TSN_FAMILIA_MANT 																			"
                SQL &= Chr(13) & "		END TRY																			"
                SQL &= Chr(13) & "		BEGIN CATCH 																			"
                SQL &= Chr(13) & "		 	ROLLBACK TRAN																		"
                SQL &= Chr(13) & "		 	DECLARE @MENSAJE VARCHAR(500)																		"
                SQL &= Chr(13) & "		 	SET @MENSAJE =( SELECT ERROR_MESSAGE())																		"
                SQL &= Chr(13) & "		 	RAISERROR( @MENSAJE, 16, 1)																		"
                SQL &= Chr(13) & "		END CATCH																			"
                SQL &= Chr(13) & "		END																			"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_FACTURACION_TMP_A_REAL()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_FACTURACION_TMP_A_REAL", "2020-11-21") Then
                ELIMINA_PROCEDIMIENTO("USP_FACTURACION_TMP_A_REAL")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_FACTURACION_TMP_A_REAL] 																						"
                SQL &= Chr(13) & "	 @COD_CIA VARCHAR(3)																						"
                SQL &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)																						"
                SQL &= Chr(13) & "	,@TIPO_MOV VARCHAR(2)																						"
                SQL &= Chr(13) & "	,@CODIGO VARCHAR(20)																						"
                SQL &= Chr(13) & "	AS																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "		BEGIN TRY																					"
                SQL &= Chr(13) & "		BEGIN TRAN TR_FACTURACION_TMP_A_REAL																					"
                SQL &= Chr(13) & "		DECLARE @NUMERO_DOC INTEGER																					"
                SQL &= Chr(13) & "		DECLARE @TIPO_NOTA AS VARCHAR(2), @CEDULA VARCHAR(25)																					"
                SQL &= Chr(13) & "		DECLARE @FECHA_DOC AS DATETIME																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		IF NOT EXISTS(SELECT TMP.*																					"
                SQL &= Chr(13) & "			FROM DOCUMENTO_ENC_TMP AS TMP																				"
                SQL &= Chr(13) & "			INNER JOIN DOCUMENTO_DET_TMP AS DET	 																			"
                SQL &= Chr(13) & "	            ON DET.COD_CIA = TMP.COD_CIA 																						"
                SQL &= Chr(13) & "	            AND DET.COD_SUCUR = TMP.COD_SUCUR 																						"
                SQL &= Chr(13) & "	            AND DET.CODIGO = TMP.CODIGO 																						"
                SQL &= Chr(13) & "	            AND DET.TIPO_MOV = TMP.TIPO_MOV																						"
                SQL &= Chr(13) & "			WHERE TMP.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND TMP.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND TMP.TIPO_MOV = 	@TIPO_MOV																			"
                SQL &= Chr(13) & "			AND TMP.CODIGO = @CODIGO) AND @TIPO_MOV IN ('FA', 'FC')																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				RAISERROR('El código de factura no existe en los temporales', 17, 1)																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'																					"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC =  ISNULL(MAX(NUMERO_DOC), 0) + 1 																			"
                SQL &= Chr(13) & "				FROM DOCUMENTO_ENC																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TIPO_MOV <> 'NC' 																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		ELSE IF @TIPO_MOV = 'NC'																					"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC = ISNULL(MAX(NUMERO_DOC), 0) + 1																			"
                SQL &= Chr(13) & "				FROM DOCUMENTO_ENC																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TIPO_MOV = 'NC'																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		ELSE IF @TIPO_MOV = 'RB'																					"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC = ISNULL(MAX(NUMERO_DOC), 0) + 1																			"
                SQL &= Chr(13) & "				FROM DOCUMENTO_ENC																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TIPO_MOV = 'RB'																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "			/*INGRESA EL ENCABEZADO*/																				"
                SQL &= Chr(13) & "			INSERT INTO DOCUMENTO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)																				"
                SQL &= Chr(13) & "			SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO, SUM(DET.SUBTOTAL), SUM(DET.IMPUESTO), SUM(DET.TOTAL) ,TMP.COD_MONEDA																				"
                SQL &= Chr(13) & "			,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION,TMP.TIPO_NOTA																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_ENC_TMP AS TMP																				"
                SQL &= Chr(13) & "			INNER JOIN DOCUMENTO_DET_TMP AS DET	 																			"
                SQL &= Chr(13) & "	            ON DET.COD_CIA = TMP.COD_CIA 																						"
                SQL &= Chr(13) & "	            AND DET.COD_SUCUR = TMP.COD_SUCUR 																						"
                SQL &= Chr(13) & "	            AND DET.CODIGO = TMP.CODIGO 																						"
                SQL &= Chr(13) & "	            AND DET.TIPO_MOV = TMP.TIPO_MOV																						"
                SQL &= Chr(13) & "			WHERE TMP.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND TMP.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND TMP.TIPO_MOV = 	@TIPO_MOV																			"
                SQL &= Chr(13) & "			AND TMP.CODIGO = @CODIGO																				"
                SQL &= Chr(13) & "			GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO,TMP.DESCRIPCION,TMP.TIPO_NOTA																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			/*INGRESA EL DETALLE*/																				"
                SQL &= Chr(13) & "			INSERT INTO DOCUMENTO_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																				"
                SQL &= Chr(13) & "			SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_DET_TMP																				"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND CODIGO = @CODIGO																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			DELETE FROM DOCUMENTO_ENC_TMP WHERE CODIGO = @CODIGO																				"
                SQL &= Chr(13) & "	        DELETE FROM DOCUMENTO_DET_TMP WHERE CODIGO = @CODIGO																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT @FECHA_DOC = FECHA, @CEDULA = CEDULA																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_ENC																				"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND TIPO_MOV = 	@TIPO_MOV 																			"
                SQL &= Chr(13) & "			AND NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			EXEC USP_INGRESA_DOCUMENTO_ELECTRONICO 																				"
                SQL &= Chr(13) & "			 @COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			,@COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			,@NUMERO_DOC = 	@NUMERO_DOC																			"
                SQL &= Chr(13) & "			,@TIPO_MOV  = @TIPO_MOV																				"
                SQL &= Chr(13) & "			,@FECHA = @FECHA_DOC 																				"
                SQL &= Chr(13) & "			,@CEDULA = @CEDULA																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT @NUMERO_DOC AS Documento																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			ELSE																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				IF @TIPO_MOV = 'NC'																			"
                SQL &= Chr(13) & "					BEGIN																		"
                SQL &= Chr(13) & "						/*INGRESA ENCABEZADO*/																	"
                SQL &= Chr(13) & "	                            INSERT INTO DOCUMENTO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)																									"
                SQL &= Chr(13) & "								SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO																		"
                SQL &= Chr(13) & "								, SUM(DET.MONTO_DOC) - ROUND(SUM(DET.MONTO_DOC) - (SUM(DET.MONTO_DOC) / (((SUM(DOC_DET.POR_IMPUESTO) / COUNT(DOC_DET.COD_CIA)) / 100.00) + 1)),2)																		"
                SQL &= Chr(13) & "								, ROUND(SUM(DET.MONTO_DOC) - (SUM(DET.MONTO_DOC) / (((SUM(DOC_DET.POR_IMPUESTO) / COUNT(DOC_DET.COD_CIA)) / 100.00) + 1)),2)																		"
                SQL &= Chr(13) & "								, SUM(DET.MONTO_DOC) - SUM(DET.MONTO_AFEC),TMP.COD_MONEDA																		"
                SQL &= Chr(13) & "								, TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION,TMP.TIPO_NOTA																		"
                SQL &= Chr(13) & "								FROM DOCUMENTO_ENC_TMP AS TMP																		"
                SQL &= Chr(13) & "								INNER JOIN DOCUMENTO_AFEC_DET_TMP AS DET																		"
                SQL &= Chr(13) & "									ON DET.COD_CIA = TMP.COD_CIA 																	"
                SQL &= Chr(13) & "	                                AND DET.COD_SUCUR = TMP.COD_SUCUR																									"
                SQL &= Chr(13) & "									AND DET.CODIGO = TMP.CODIGO																	"
                SQL &= Chr(13) & "								INNER JOIN DOCUMENTO_DET AS DOC_DET																		"
                SQL &= Chr(13) & "									ON DOC_DET.COD_CIA = DET.COD_CIA																	"
                SQL &= Chr(13) & "	                                AND DOC_DET.COD_SUCUR = DET.COD_SUCUR																									"
                SQL &= Chr(13) & "									AND DOC_DET.NUMERO_DOC = DET.NUMERO_DOC																	"
                SQL &= Chr(13) & "	                                AND DOC_DET.TIPO_MOV = DET.TIPO_MOV																									"
                SQL &= Chr(13) & "									AND DOC_DET.LINEA = 1"
                SQL &= Chr(13) & "							    WHERE TMP.COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "	                            AND TMP.COD_SUCUR = @COD_SUCUR																									"
                SQL &= Chr(13) & "							    AND TMP.TIPO_MOV = 	@TIPO_MOV																		"
                SQL &= Chr(13) & "	                            AND TMP.CODIGO = @CODIGO																									"
                SQL &= Chr(13) & "							    GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO,TMP.DESCRIPCION,TMP.TIPO_NOTA	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						/*INGRESA DOCUMENTOS AFECTADOS*/																	"
                SQL &= Chr(13) & "						INSERT INTO DOCUMENTO_AFEC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,FECHA,NUMERO_DOC_AFEC,TIPO_MOV_AFEC,MONTO_AFEC,FECHA_INC)																	"
                SQL &= Chr(13) & "						SELECT TMP.COD_CIA, TMP.COD_SUCUR, @NUMERO_DOC, ENC.TIPO_MOV, ENC.FECHA, TMP.NUMERO_DOC, TMP.TIPO_MOV, TMP.MONTO_AFEC, GETDATE() 																	"
                SQL &= Chr(13) & "						FROM DOCUMENTO_AFEC_DET_TMP AS TMP																	"
                SQL &= Chr(13) & "						INNER JOIN DOCUMENTO_ENC_TMP AS ENC																	"
                SQL &= Chr(13) & "							ON ENC.COD_CIA = TMP.COD_CIA 																"
                SQL &= Chr(13) & "							AND ENC.COD_SUCUR = TMP.COD_SUCUR 																"
                SQL &= Chr(13) & "							AND ENC.CODIGO = TMP.CODIGO 						 										"
                SQL &= Chr(13) & "						WHERE TMP.COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "						AND TMP.COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "						AND ENC.TIPO_MOV = 	@TIPO_MOV																"
                SQL &= Chr(13) & "						AND TMP.CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						/*ACTUALIZA SALDOS DOCUMENTOS*/																	"
                SQL &= Chr(13) & "						UPDATE DOCUMENTO_ENC																	"
                SQL &= Chr(13) & "						SET SALDO = (SALDO - T1.MONTO_AFEC)																	"
                SQL &= Chr(13) & "						FROM(																	"
                SQL &= Chr(13) & "							SELECT  COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV, MONTO_AFEC																"
                SQL &= Chr(13) & "							FROM DOCUMENTO_AFEC_DET_TMP																"
                SQL &= Chr(13) & "							WHERE COD_CIA = @COD_CIA																"
                SQL &= Chr(13) & "							AND COD_SUCUR = @COD_SUCUR																"
                SQL &= Chr(13) & "							AND CODIGO = @CODIGO																"
                SQL &= Chr(13) & "						) AS T1																	"
                SQL &= Chr(13) & "						WHERE T1.COD_CIA = DOCUMENTO_ENC.COD_CIA																	"
                SQL &= Chr(13) & "						AND T1.COD_SUCUR = DOCUMENTO_ENC.COD_SUCUR																	"
                SQL &= Chr(13) & "						AND T1.NUMERO_DOC = DOCUMENTO_ENC.NUMERO_DOC 																	"
                SQL &= Chr(13) & "						AND T1.TIPO_MOV = DOCUMENTO_ENC.TIPO_MOV																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						/*SETEAMOS EL TIPO DE NOTA PARA VER SI INGRESAMOS O NO MOVIMIENTO DE INVENTARIO*/																	"
                SQL &= Chr(13) & "						SELECT @TIPO_NOTA = TIPO_NOTA																	"
                SQL &= Chr(13) & "						FROM DOCUMENTO_ENC_TMP																	"
                SQL &= Chr(13) & "						WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "						AND COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "						AND TIPO_MOV = @TIPO_MOV																	"
                SQL &= Chr(13) & "						AND CODIGO = @CODIGO 																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						IF @TIPO_NOTA = 'DV'																	"
                SQL &= Chr(13) & "							BEGIN																"
                SQL &= Chr(13) & "								INSERT INTO DOCUMENTO_AFEC_DET_PRODUCTOS(COD_CIA,COD_SUCUR,TIPO_MOV,NUMERO_DOC,NUMERO_DOC_AFEC,TIPO_MOV_AFEC,COD_PROD,LINEA,PRECIO_UNITARIO,POR_DESCUENTO,POR_IMPUESTO,CANTIDAD,ESTANTE,FILA,COLUMNA)															"
                SQL &= Chr(13) & "								SELECT COD_CIA, COD_SUCUR, @TIPO_MOV, @NUMERO_DOC, NUMERO_DOC, TIPO_MOV, COD_PROD, ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA, PRECIO_UNITARIO, POR_DESCUENTO, POR_IMPUESTO, CANTIDAD, ESTANTE, FILA, COLUMNA															"
                SQL &= Chr(13) & "								FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP															"
                SQL &= Chr(13) & "								WHERE COD_CIA = @COD_CIA															"
                SQL &= Chr(13) & "								AND COD_SUCUR = @COD_SUCUR 															"
                SQL &= Chr(13) & "								AND CODIGO = @CODIGO															"
                SQL &= Chr(13) & "							END																"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						/*ACTUALIZA GUIA*/																	"
                SQL &= Chr(13) & "						UPDATE DOCUMENTO_GUIA																	"
                SQL &= Chr(13) & "						SET ESTADO = 'N'																	"
                SQL &= Chr(13) & "						FROM(																	"
                SQL &= Chr(13) & "						SELECT TMP.COD_CIA, TMP.COD_SUCUR, TMP.TIPO_MOV, TMP.NUMERO_DOC 																	"
                SQL &= Chr(13) & "						FROM DOCUMENTO_AFEC_DET_TMP AS TMP																	"
                SQL &= Chr(13) & "						INNER JOIN DOCUMENTO_ENC_TMP AS ENC																	"
                SQL &= Chr(13) & "							ON ENC.COD_CIA = TMP.COD_CIA 																"
                SQL &= Chr(13) & "							AND ENC.COD_SUCUR = TMP.COD_SUCUR 																"
                SQL &= Chr(13) & "							AND ENC.CODIGO = TMP.CODIGO 						 										"
                SQL &= Chr(13) & "						WHERE TMP.COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "						AND TMP.COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "						AND ENC.TIPO_MOV = 	@TIPO_MOV																"
                SQL &= Chr(13) & "						AND TMP.CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "						) AS T1																	"
                SQL &= Chr(13) & "						WHERE T1.COD_CIA = DOCUMENTO_GUIA.COD_CIA																	"
                SQL &= Chr(13) & "						AND T1.TIPO_MOV = DOCUMENTO_GUIA.TIPO_MOV																	"
                SQL &= Chr(13) & "						AND T1.NUMERO_DOC = DOCUMENTO_GUIA.NUMERO_DOC																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						DELETE FROM DOCUMENTO_ENC_TMP WHERE CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "						DELETE FROM DOCUMENTO_AFEC_DET_TMP WHERE CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "						DELETE FROM DOCUMENTO_AFEC_DET_PRODUCTOS_TMP WHERE CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "					SELECT @FECHA_DOC = FECHA, @CEDULA = CEDULA																		"
                SQL &= Chr(13) & "					FROM DOCUMENTO_ENC																		"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "					AND TIPO_MOV = 	@TIPO_MOV 																	"
                SQL &= Chr(13) & "					AND NUMERO_DOC = @NUMERO_DOC																		"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "					EXEC USP_INGRESA_DOCUMENTO_ELECTRONICO 																		"
                SQL &= Chr(13) & "					 @COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "					,@COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "					,@NUMERO_DOC = 	@NUMERO_DOC																	"
                SQL &= Chr(13) & "					,@TIPO_MOV  = @TIPO_MOV																		"
                SQL &= Chr(13) & "					,@FECHA = @FECHA_DOC 																		"
                SQL &= Chr(13) & "					,@CEDULA = @CEDULA																		"
                SQL &= Chr(13) & "					END																		"
                SQL &= Chr(13) & "				ELSE																			"
                SQL &= Chr(13) & "						/*INGRESA RECIBOS*/																	"
                SQL &= Chr(13) & "					BEGIN																		"
                SQL &= Chr(13) & "						/*INGRESA ENCABEZADO*/																	"
                SQL &= Chr(13) & "						INSERT INTO DOCUMENTO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)																	"
                SQL &= Chr(13) & "						SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO, SUM(DET.MONTO_DOC), 0, SUM(DET.MONTO_DOC) - SUM(DET.MONTO_AFEC),TMP.COD_MONEDA																	"
                SQL &= Chr(13) & "						,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION,TMP.TIPO_NOTA																	"
                SQL &= Chr(13) & "						FROM DOCUMENTO_ENC_TMP AS TMP																	"
                SQL &= Chr(13) & "						INNER JOIN DOCUMENTO_AFEC_DET_TMP AS DET	 																"
                SQL &= Chr(13) & "							ON DET.COD_CIA = TMP.COD_CIA 																"
                SQL &= Chr(13) & "							AND DET.COD_SUCUR = TMP.COD_SUCUR 																"
                SQL &= Chr(13) & "							AND DET.CODIGO = TMP.CODIGO 																"
                SQL &= Chr(13) & "						WHERE TMP.COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "						AND TMP.COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "						AND TMP.TIPO_MOV = 	@TIPO_MOV																"
                SQL &= Chr(13) & "						AND TMP.CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "						GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO,TMP.DESCRIPCION,TMP.TIPO_NOTA																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						/*INGRESA DOCUMENTOS AFECTADOS*/																	"
                SQL &= Chr(13) & "						INSERT INTO DOCUMENTO_AFEC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,FECHA,NUMERO_DOC_AFEC,TIPO_MOV_AFEC,MONTO_AFEC,FECHA_INC)																	"
                SQL &= Chr(13) & "						SELECT TMP.COD_CIA, TMP.COD_SUCUR, @NUMERO_DOC, ENC.TIPO_MOV, ENC.FECHA, TMP.NUMERO_DOC, TMP.TIPO_MOV, TMP.MONTO_AFEC, GETDATE() 																	"
                SQL &= Chr(13) & "						FROM DOCUMENTO_AFEC_DET_TMP AS TMP																	"
                SQL &= Chr(13) & "						INNER JOIN DOCUMENTO_ENC_TMP AS ENC																	"
                SQL &= Chr(13) & "							ON ENC.COD_CIA = TMP.COD_CIA 																"
                SQL &= Chr(13) & "							AND ENC.COD_SUCUR = TMP.COD_SUCUR 																"
                SQL &= Chr(13) & "							AND ENC.CODIGO = TMP.CODIGO 						 										"
                SQL &= Chr(13) & "						WHERE TMP.COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "						AND TMP.COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "						AND ENC.TIPO_MOV = 	@TIPO_MOV																"
                SQL &= Chr(13) & "						AND TMP.CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						/*ACTUALIZA SALDOS DOCUMENTOS*/																	"
                SQL &= Chr(13) & "						UPDATE DOCUMENTO_ENC																	"
                SQL &= Chr(13) & "						SET SALDO = (SALDO - T1.MONTO_AFEC)																	"
                SQL &= Chr(13) & "						FROM(																	"
                SQL &= Chr(13) & "							SELECT  COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV, MONTO_AFEC																"
                SQL &= Chr(13) & "							FROM DOCUMENTO_AFEC_DET_TMP																"
                SQL &= Chr(13) & "							WHERE COD_CIA = @COD_CIA																"
                SQL &= Chr(13) & "							AND COD_SUCUR = @COD_SUCUR																"
                SQL &= Chr(13) & "							AND CODIGO = @CODIGO																"
                SQL &= Chr(13) & "						) AS T1																	"
                SQL &= Chr(13) & "						WHERE T1.COD_CIA = DOCUMENTO_ENC.COD_CIA																	"
                SQL &= Chr(13) & "						AND T1.COD_SUCUR = DOCUMENTO_ENC.COD_SUCUR																	"
                SQL &= Chr(13) & "						AND T1.NUMERO_DOC = DOCUMENTO_ENC.NUMERO_DOC 																	"
                SQL &= Chr(13) & "						AND T1.TIPO_MOV = DOCUMENTO_ENC.TIPO_MOV																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						/*ACTUALIZA SALDOS DOCUMENTOS*/																	"
                SQL &= Chr(13) & "						UPDATE APARTADO_ENC																	"
                SQL &= Chr(13) & "						SET SALDO = (SALDO - T1.MONTO_AFEC)																	"
                SQL &= Chr(13) & "						FROM(																	"
                SQL &= Chr(13) & "							SELECT  COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV, MONTO_AFEC																"
                SQL &= Chr(13) & "							FROM DOCUMENTO_AFEC_DET_TMP																"
                SQL &= Chr(13) & "							WHERE COD_CIA = @COD_CIA																"
                SQL &= Chr(13) & "							AND COD_SUCUR = @COD_SUCUR																"
                SQL &= Chr(13) & "							AND CODIGO = @CODIGO																"
                SQL &= Chr(13) & "						) AS T1																	"
                SQL &= Chr(13) & "						WHERE T1.COD_CIA = APARTADO_ENC.COD_CIA																	"
                SQL &= Chr(13) & "						AND T1.COD_SUCUR = APARTADO_ENC.COD_SUCUR																	"
                SQL &= Chr(13) & "						AND T1.NUMERO_DOC = APARTADO_ENC.NUMERO_DOC 																	"
                SQL &= Chr(13) & "						AND T1.TIPO_MOV = APARTADO_ENC.TIPO_MOV																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						DELETE FROM DOCUMENTO_ENC_TMP WHERE CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "						DELETE FROM DOCUMENTO_AFEC_DET_TMP WHERE CODIGO = @CODIGO																	"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "					    SELECT @NUMERO_DOC AS Documento "
                SQL &= Chr(13) & "					END																		"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		COMMIT TRAN TR_FACTURACION_TMP_A_REAL																					"
                SQL &= Chr(13) & "		END TRY																					"
                SQL &= Chr(13) & "		BEGIN CATCH 																					"
                SQL &= Chr(13) & "	 		ROLLBACK TRAN																				"
                SQL &= Chr(13) & "	 		DECLARE @MENSAJE VARCHAR(500)																				"
                SQL &= Chr(13) & "	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																				"
                SQL &= Chr(13) & "	 		RAISERROR( @MENSAJE, 16, 1)																				"
                SQL &= Chr(13) & "		END CATCH																					"
                SQL &= Chr(13) & "	END																						"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_INGRESO_INVENTARIO()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_INGRESO_INVENTARIO", "2020-10-07") Then
                ELIMINA_PROCEDIMIENTO("USP_INGRESO_INVENTARIO")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_INGRESO_INVENTARIO] 																						"
                SQL &= Chr(13) & "		    @COD_CIA VARCHAR(3),																					"
                SQL &= Chr(13) & "			@COD_SUCUR VARCHAR(3),																				"
                SQL &= Chr(13) & "			@CLAVE VARCHAR(50)																				"
                SQL &= Chr(13) & "		AS   																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			BEGIN TRY																				"
                SQL &= Chr(13) & "			BEGIN TRAN TSN_INGRESO_INVENTARIO																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			IF (SELECT COUNT(*)																				"
                SQL &= Chr(13) & "				FROM CXP_DOCUMENTOS_ELECTRONICOS AS ENC																			"
                SQL &= Chr(13) & "				INNER JOIN CXP_DOCUMENTOS_ELECTRONICOS_DET AS DET																			"
                SQL &= Chr(13) & "					ON ENC.COD_CIA = DET.COD_CIA 																		"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = DET.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND ENC.CLAVE = DET.CLAVE																		"
                SQL &= Chr(13) & "					AND ENC.TIPO_MOV = DET.TIPO_MOV																		"
                SQL &= Chr(13) & "					AND ENC.CEDULA = DET.CEDULA																		"
                SQL &= Chr(13) & "				LEFT JOIN PRODUCTO AS PROD																			"
                SQL &= Chr(13) & "					ON PROD.COD_PROD = DET.CODIGO																		"
                SQL &= Chr(13) & "					AND PROD.COD_CIA =  DET.COD_CIA																		"
                SQL &= Chr(13) & "					AND PROD.COD_SUCUR =  DET.COD_SUCUR																		"
                SQL &= Chr(13) & "				LEFT JOIN PRODUCTO_RELACION AS REL																			"
                SQL &= Chr(13) & "					ON REL.COD_CIA = DET.COD_CIA																		"
                SQL &= Chr(13) & "					AND REL.COD_SUCUR = DET.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND REL.COD_PROD_HIJO =  DET.CODIGO																		"
                SQL &= Chr(13) & "				WHERE ENC.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND ENC.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND ENC.CLAVE = @CLAVE																			"
                SQL &= Chr(13) & "				AND (PROD.COD_PROD IS NULL AND REL.COD_PROD_PADRE IS NULL)																			"
                SQL &= Chr(13) & "				AND DETALLE NOT LIKE '%TRANSPORTE%') > 0																			"
                SQL &= Chr(13) & "				BEGIN																			"
                SQL &= Chr(13) & "					RAISERROR('No todos los productos están ingresados o relacionados en el sistema, no se puede llevar a cabo el proceso', 17, 1)																		"
                SQL &= Chr(13) & "				END																			"
                SQL &= Chr(13) & "				ELSE																			"
                SQL &= Chr(13) & "				BEGIN																			"
                SQL &= Chr(13) & "					INSERT INTO CXP_DOCUMENTO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO																		"
                SQL &= Chr(13) & "												 ,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)											"
                SQL &= Chr(13) & "					SELECT COD_CIA, COD_SUCUR, CONSECUTIVO_FE, TIPO_MOV, CEDULA, FECHA, GETDATE(), COD_USUARIO, TOTAL_VENTA, IMPUESTO, TOTAL																		"
                SQL &= Chr(13) & "					,CASE WHEN COD_MONEDA IN ('C', 'L') THEN 'L' ELSE 'D' END AS COD_MONEDA, TIPO_CAMBIO, 'EF', 'A', '', CASE WHEN TIPO_MOV = 'NC' THEN 'DV' ELSE NULL END																		"
                SQL &= Chr(13) & "					FROM CXP_DOCUMENTOS_ELECTRONICOS																		"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "					AND CLAVE = @CLAVE																		"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "					INSERT INTO CXP_DOCUMENTO_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO																		"
                SQL &= Chr(13) & "												  ,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA)											"
                SQL &= Chr(13) & "					SELECT ENC.COD_CIA, ENC.COD_SUCUR, ENC.CONSECUTIVO_FE, ENC.TIPO_MOV, LINEA, ISNULL(PROD.COD_PROD, REL.COD_PROD_PADRE) AS CODIGO, 'Unid', CANTIDAD, PRECIO_UNITARIO, ROUND((ISNULL(MONTO_DESCUENTO, 0) / MONTO_SINIV) * 100, 4)  AS POR_DESCUENTO																		"
                SQL &= Chr(13) & "					, ISNULL(MONTO_DESCUENTO, 0) AS MONTO_DESCUENTO, TARIFA, MONTO_IMP, (MONTO_SINIV-ISNULL(MONTO_DESCUENTO, 0)) AS SUBTOTAL, MONTO_TOTAL_LINEA, '1', '1', '1'																		"
                SQL &= Chr(13) & "					FROM CXP_DOCUMENTOS_ELECTRONICOS AS ENC																		"
                SQL &= Chr(13) & "					INNER JOIN CXP_DOCUMENTOS_ELECTRONICOS_DET AS DET																		"
                SQL &= Chr(13) & "						ON ENC.COD_CIA = DET.COD_CIA 																	"
                SQL &= Chr(13) & "						AND ENC.COD_SUCUR = DET.COD_SUCUR																	"
                SQL &= Chr(13) & "						AND ENC.CLAVE = DET.CLAVE																	"
                SQL &= Chr(13) & "						AND ENC.TIPO_MOV = DET.TIPO_MOV																	"
                SQL &= Chr(13) & "						AND ENC.CEDULA = DET.CEDULA																	"
                SQL &= Chr(13) & "					LEFT JOIN PRODUCTO AS PROD																		"
                SQL &= Chr(13) & "						ON PROD.COD_CIA = DET.COD_CIA																	"
                SQL &= Chr(13) & "	                 	AND PROD.COD_SUCUR = DET.COD_SUCUR																					"
                SQL &= Chr(13) & "	                 	AND PROD.COD_PROD = DET.CODIGO																					"
                SQL &= Chr(13) & "	                LEFT JOIN PRODUCTO_RELACION AS REL																						"
                SQL &= Chr(13) & "	                 	ON REL.COD_CIA = DET.COD_CIA																					"
                SQL &= Chr(13) & "	                 	AND REL.COD_SUCUR = DET.COD_SUCUR																					"
                SQL &= Chr(13) & "	                 	AND REL.COD_PROD_HIJO = DET.CODIGO																					"
                SQL &= Chr(13) & "					WHERE ENC.COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "					AND ENC.CLAVE = @CLAVE																		"
                SQL &= Chr(13) & "					AND DETALLE NOT LIKE '%TRANSPORTE%'																		"
                SQL &= Chr(13) & "				END																			"
                SQL &= Chr(13) & "			COMMIT TRAN TSN_INGRESO_INVENTARIO 																				"
                SQL &= Chr(13) & "		END TRY																					"
                SQL &= Chr(13) & "		BEGIN CATCH 																					"
                SQL &= Chr(13) & "		 	ROLLBACK TRAN																				"
                SQL &= Chr(13) & "		 	DECLARE @MENSAJE VARCHAR(500)																				"
                SQL &= Chr(13) & "		 	SET @MENSAJE =( SELECT ERROR_MESSAGE())																				"
                SQL &= Chr(13) & "		 	RAISERROR( @MENSAJE, 16, 1)																				"
                SQL &= Chr(13) & "		END CATCH																					"
                SQL &= Chr(13) & "		END																					"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_MANT_APARTADO_TMP()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_MANT_APARTADO_TMP", "2020-10-07") Then
                ELIMINA_PROCEDIMIENTO("USP_MANT_APARTADO_TMP")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_MANT_APARTADO_TMP] 																						"
                SQL &= Chr(13) & "	                	 @COD_CIA VARCHAR(3)																					"
                SQL &= Chr(13) & "	                	,@COD_SUCUR VARCHAR(3)																					"
                SQL &= Chr(13) & "	                	,@CODIGO VARCHAR(20) 																					"
                SQL &= Chr(13) & "	                	,@TIPO_MOV VARCHAR(2) 																					"
                SQL &= Chr(13) & "	                	,@CEDULA VARCHAR(25) 																					"
                SQL &= Chr(13) & "	                	,@FECHA DATETIME 																					"
                SQL &= Chr(13) & "	                	,@COD_USUARIO VARCHAR(8) 																					"
                SQL &= Chr(13) & "	                	,@COD_MONEDA CHAR(1) 																					"
                SQL &= Chr(13) & "	                	,@TIPO_CAMBIO MONEY																					"
                SQL &= Chr(13) & "	                	,@PLAZO INT																					"
                SQL &= Chr(13) & "	                	,@FORMA_PAGO CHAR(2)																					"
                SQL &= Chr(13) & "	                	,@DESCRIPCION VARCHAR(250)																					"
                SQL &= Chr(13) & "	                	,@COD_PROD VARCHAR(20)																					"
                SQL &= Chr(13) & "	                	,@COD_UNIDAD VARCHAR(10)																					"
                SQL &= Chr(13) & "	                	,@CANTIDAD MONEY																					"
                SQL &= Chr(13) & "	                	,@PRECIO MONEY																					"
                SQL &= Chr(13) & "	                	,@POR_DESCUENTO INT																					"
                SQL &= Chr(13) & "	                	,@DESCUENTO MONEY																					"
                SQL &= Chr(13) & "	                	,@POR_IMPUESTO INT																					"
                SQL &= Chr(13) & "	                	,@IMPUESTO MONEY																					"
                SQL &= Chr(13) & "	                	,@SUBTOTAL MONEY																					"
                SQL &= Chr(13) & "	                	,@TOTAL MONEY																					"
                SQL &= Chr(13) & "						,@ESTANTE VARCHAR(3)																	"
                SQL &= Chr(13) & "						,@FILA VARCHAR(3)																	"
                SQL &= Chr(13) & "						,@COLUMNA VARCHAR(3)																	"
                SQL &= Chr(13) & "	                	,@MODO INT																					"
                SQL &= Chr(13) & "	                	AS																					"
                SQL &= Chr(13) & "	                	BEGIN																					"
                SQL &= Chr(13) & "	                		SET NOCOUNT ON;																				"
                SQL &= Chr(13) & "	                		BEGIN TRY																				"
                SQL &= Chr(13) & "	                		BEGIN TRAN TR_MANT_APARTADO																				"
                SQL &= Chr(13) & "	                																						"
                SQL &= Chr(13) & "	                		IF	@MODO = 1																			"
                SQL &= Chr(13) & "	                		BEGIN																				"
                SQL &= Chr(13) & "	                			IF NOT EXISTS(SELECT *																			"
                SQL &= Chr(13) & "	                						  FROM APARTADO_ENC_TMP																"
                SQL &= Chr(13) & "	                						  WHERE COD_CIA = @COD_CIA																"
                SQL &= Chr(13) & "	                                        AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "	                						  AND CODIGO = @CODIGO)																"
                SQL &= Chr(13) & "	                			BEGIN																			"
                SQL &= Chr(13) & "	                				INSERT INTO APARTADO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION)																		"
                SQL &= Chr(13) & "	                				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, @CEDULA, @FECHA, GETDATE(), @COD_USUARIO, @COD_MONEDA, @TIPO_CAMBIO, @PLAZO, @FORMA_PAGO,@DESCRIPCION																		"
                SQL &= Chr(13) & "	                																						"
                SQL &= Chr(13) & "	                				INSERT INTO APARTADO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA)																		"
                SQL &= Chr(13) & "	                				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA																		"
                SQL &= Chr(13) & "	                				FROM APARTADO_DET_TMP																		"
                SQL &= Chr(13) & "	                				WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "	                              And COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "	                				AND CODIGO = @CODIGO 																		"
                SQL &= Chr(13) & "	                			END																			"
                SQL &= Chr(13) & "	                			ELSE																			"
                SQL &= Chr(13) & "	                			BEGIN																			"
                SQL &= Chr(13) & "	                				IF EXISTS(SELECT COD_PROD FROM APARTADO_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)																		"
                SQL &= Chr(13) & "	                				BEGIN																		"
                SQL &= Chr(13) & "	                					UPDATE APARTADO_DET_TMP																	"
                SQL &= Chr(13) & "	                					SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO																	"
                SQL &= Chr(13) & "	                					   ,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL									   								"
                SQL &= Chr(13) & "	                					WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "	                					AND COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "	                                  And CODIGO = @CODIGO																						"
                SQL &= Chr(13) & "	                					AND COD_PROD = @COD_PROD																	"
                SQL &= Chr(13) & "	                				END																		"
                SQL &= Chr(13) & "	                				ELSE																		"
                SQL &= Chr(13) & "	                				BEGIN																		"
                SQL &= Chr(13) & "	                					INSERT INTO APARTADO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA)																	"
                SQL &= Chr(13) & "	                					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA																	"
                SQL &= Chr(13) & "	                					FROM APARTADO_DET_TMP																	"
                SQL &= Chr(13) & "	                					WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "	                					AND COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "	                                  And CODIGO = @CODIGO																						"
                SQL &= Chr(13) & "	                				END																		"
                SQL &= Chr(13) & "	                			END																			"
                SQL &= Chr(13) & "	                		END																				"
                SQL &= Chr(13) & "	                		ELSE IF @MODO = 3																				"
                SQL &= Chr(13) & "	                		BEGIN																				"
                SQL &= Chr(13) & "	                				IF EXISTS(SELECT COD_PROD FROM APARTADO_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)																		"
                SQL &= Chr(13) & "	                				BEGIN																		"
                SQL &= Chr(13) & "	                					UPDATE APARTADO_DET_TMP																	"
                SQL &= Chr(13) & "	                					SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO																	"
                SQL &= Chr(13) & "	                					   ,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL									   								"
                SQL &= Chr(13) & "	                					WHERE COD_CIA = @COD_CIA 																	"
                SQL &= Chr(13) & "	                                  And COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "	                					AND CODIGO = @CODIGO 																	"
                SQL &= Chr(13) & "	                                  And COD_PROD = @COD_PROD																						"
                SQL &= Chr(13) & "	                				END																		"
                SQL &= Chr(13) & "	                				ELSE 																		"
                SQL &= Chr(13) & "	                				BEGIN																		"
                SQL &= Chr(13) & "	                					INSERT INTO APARTADO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA)																	"
                SQL &= Chr(13) & "	                					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA																	"
                SQL &= Chr(13) & "	                					FROM APARTADO_DET_TMP																	"
                SQL &= Chr(13) & "	                					WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "	                                  And COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "	                					AND CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "	                				END																		"
                SQL &= Chr(13) & "	                		END																				"
                SQL &= Chr(13) & "	                		COMMIT TRAN TR_MANT_APARTADO 																				"
                SQL &= Chr(13) & "	                		END TRY																				"
                SQL &= Chr(13) & "	                		BEGIN CATCH 																				"
                SQL &= Chr(13) & "	                	 		ROLLBACK TRAN																			"
                SQL &= Chr(13) & "	                	 		DECLARE @MENSAJE VARCHAR(500)																			"
                SQL &= Chr(13) & "	                	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																			"
                SQL &= Chr(13) & "	                	 		RAISERROR( @MENSAJE, 16, 1)																			"
                SQL &= Chr(13) & "	                		END CATCH																				"
                SQL &= Chr(13) & "	                	END																					"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_PRODUCTO_RELACION()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_PRODUCTO_RELACION", "2020-10-07") Then
                ELIMINA_PROCEDIMIENTO("USP_PRODUCTO_RELACION")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_PRODUCTO_RELACION] 																						"
                SQL &= Chr(13) & "		    @COD_CIA VARCHAR(3),																					"
                SQL &= Chr(13) & "			@COD_SUCUR VARCHAR(3),																				"
                SQL &= Chr(13) & "			@COD_PROD VARCHAR(20),																				"
                SQL &= Chr(13) & "			@COD_PROD_HIJO VARCHAR(20)																				"
                SQL &= Chr(13) & "		AS   																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			IF EXISTS(SELECT COD_PROD_HIJO 																				"
                SQL &= Chr(13) & "					FROM PRODUCTO_RELACION 																		"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA 																		"
                SQL &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR 																		"
                SQL &= Chr(13) & "					AND COD_PROD_PADRE = @COD_PROD																		"
                SQL &= Chr(13) & "					AND COD_PROD_HIJO = @COD_PROD_HIJO																		"
                SQL &= Chr(13) & "					)																		"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				RAISERROR('El código de producto hijo ya está relacionado', 17, 1)																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			ELSE																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				INSERT INTO PRODUCTO_RELACION(COD_CIA,COD_SUCUR,COD_PROD_PADRE,COD_PROD_HIJO)																			"
                SQL &= Chr(13) & "				SELECT @COD_CIA, @COD_SUCUR, @COD_PROD, @COD_PROD_HIJO																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		END																					"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_SUCURSAL_INDICADORES_MANT()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_SUCURSAL_INDICADORES_MANT", "2021-01-09") Then
                ELIMINA_PROCEDIMIENTO("USP_SUCURSAL_INDICADORES_MANT")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_SUCURSAL_INDICADORES_MANT]																									"
                SQL &= Chr(13) & "			 @COD_CIA VARCHAR(3)																							"
                SQL &= Chr(13) & "			,@COD_SUCUR VARCHAR(3)																							"
                SQL &= Chr(13) & "			,@IND_PERMITE_VENTAS_NEGATIVO CHAR(1) = 'N'																							"
                SQL &= Chr(13) & "			,@IND_AVISO_MIN_STOCK CHAR(1) = 'N'																							"
                SQL &= Chr(13) & "			,@IND_RECIBO_AUTOMATICO CHAR(1) = 'N'																							"
                SQL &= Chr(13) & "			,@IND_MENSAJE_FACTURACION CHAR(1) = 'N'																							"
                SQL &= Chr(13) & "			,@IND_AUTOCOMPLETAR_CLIENTE CHAR(1) = 'N'																							"
                SQL &= Chr(13) & "			,@IND_INGRESO_AUTO CHAR(1) = 'N'																							"
                SQL &= Chr(13) & "			,@IND_SUMAR_CANTIDADES CHAR(1) = 'N'																							"
                SQL &= Chr(13) & "			,@MODO INT = 0																							"
                SQL &= Chr(13) & "			AS																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				IF @MODO = 1 OR @MODO = 3																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "				IF NOT EXISTS(SELECT *																						"
                SQL &= Chr(13) & "						  FROM SUCURSAL_INDICADORES																				"
                SQL &= Chr(13) & "						  WHERE COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "						  AND COD_SUCUR = @COD_SUCUR)																				"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "						INSERT INTO SUCURSAL_INDICADORES(COD_CIA,COD_SUCUR,IND_PERMITE_VENTAS_NEGATIVO,IND_AVISO_MIN_STOCK,IND_RECIBO_AUTOMATICO,IND_MENSAJE_FACTURACION,IND_AUTOCOMPLETAR_CLIENTE,IND_SUMAR_CANTIDADES,IND_INGRESO_AUTO)																				"
                SQL &= Chr(13) & "						SELECT @COD_CIA, @COD_SUCUR, @IND_PERMITE_VENTAS_NEGATIVO, @IND_AVISO_MIN_STOCK, @IND_RECIBO_AUTOMATICO, @IND_MENSAJE_FACTURACION,@IND_AUTOCOMPLETAR_CLIENTE,@IND_SUMAR_CANTIDADES,@IND_INGRESO_AUTO																				"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				ELSE																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "						UPDATE SUCURSAL_INDICADORES																				"
                SQL &= Chr(13) & "						SET IND_PERMITE_VENTAS_NEGATIVO = @IND_PERMITE_VENTAS_NEGATIVO, IND_AVISO_MIN_STOCK = @IND_AVISO_MIN_STOCK																				"
                SQL &= Chr(13) & "						,IND_RECIBO_AUTOMATICO = @IND_RECIBO_AUTOMATICO, IND_MENSAJE_FACTURACION = @IND_MENSAJE_FACTURACION																				"
                SQL &= Chr(13) & "						,IND_AUTOCOMPLETAR_CLIENTE = @IND_AUTOCOMPLETAR_CLIENTE, IND_SUMAR_CANTIDADES = @IND_SUMAR_CANTIDADES																				"
                SQL &= Chr(13) & "						,IND_INGRESO_AUTO = @IND_INGRESO_AUTO																				"
                SQL &= Chr(13) & "						WHERE COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "						AND COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "				END 																						"
                SQL &= Chr(13) & "				ELSE IF @MODO = 5  																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "					SELECT *																					"
                SQL &= Chr(13) & "					FROM SUCURSAL_INDICADORES																					"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA																					"
                SQL &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR																					"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "			END																							"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_MANT_PRODUCTO()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_MANT_PRODUCTO", "2021-06-19") Then
                ELIMINA_PROCEDIMIENTO("USP_MANT_PRODUCTO")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_MANT_PRODUCTO] 																						"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@COD_PROD VARCHAR(20)																					"
                SQL &= Chr(13) & "		,@CEDULA VARCHAR(25) = ''																					"
                SQL &= Chr(13) & "		,@DESCRIPCION VARCHAR(150) = ''																					"
                SQL &= Chr(13) & "		,@COD_UNIDAD VARCHAR(10) = ''																					"
                SQL &= Chr(13) & "		,@COSTO MONEY = 0																					"
                SQL &= Chr(13) & "		,@POR_IMPUESTO INT = 0																					"
                SQL &= Chr(13) & "		,@COD_IMPUESTO VARCHAR(4) = ''																					"
                SQL &= Chr(13) & "		,@PRECIO MONEY = 0																					"
                SQL &= Chr(13) & "		,@PRECIO_2 MONEY = 0																					"
                SQL &= Chr(13) & "		,@PRECIO_3 MONEY = 0																					"
                SQL &= Chr(13) & "		,@EXENTO CHAR(1) = ''																					"
                SQL &= Chr(13) & "		,@ESTADO CHAR(1) = ''																					"
                SQL &= Chr(13) & "		,@ESTANTE VARCHAR(3) = ''																					"
                SQL &= Chr(13) & "		,@FILA VARCHAR(3) = ''																					"
                SQL &= Chr(13) & "		,@COLUMNA VARCHAR(3) = ''																					"
                SQL &= Chr(13) & "		,@MINIMO MONEY = 0																					"
                SQL &= Chr(13) & "		,@COD_BARRA VARCHAR(25) = ''																					"
                SQL &= Chr(13) & "		,@COD_FAMILIA VARCHAR(3) = ''																					"
                SQL &= Chr(13) & "		,@OBSERVACION VARCHAR(150) = ''																					"
                SQL &= Chr(13) & "      ,@IND_PRECIO_MODIFICABLE CHAR(1) = 'N'"
                SQL &= Chr(13) & "      ,@COD_CABYS VARCHAR(13) = ''"
                SQL &= Chr(13) & "      ,@MIN_VENTA MONEY = 1"
                SQL &= Chr(13) & "      ,@MAX_DESCUENTO INT = 0"
                SQL &= Chr(13) & "		,@MODO INT																					"
                SQL &= Chr(13) & "		AS																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																				"
                SQL &= Chr(13) & "			BEGIN TRY																				"
                SQL &= Chr(13) & "			BEGIN TRAN TSN_PRODUCTO_MANT																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			IF	@MODO = 1																			"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				IF EXISTS(SELECT @COD_PROD FROM PRODUCTO WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND COD_PROD = @COD_PROD)																			"
                SQL &= Chr(13) & "					BEGIN																		"
                SQL &= Chr(13) & "						RAISERROR('El codigo ingresado ya existe en la base de datos', 17, 1)																	"
                SQL &= Chr(13) & "					END																		"
                SQL &= Chr(13) & "				ELSE 																			"
                SQL &= Chr(13) & "					BEGIN																		"
                SQL &= Chr(13) & "						INSERT INTO PRODUCTO(COD_CIA,COD_SUCUR,COD_PROD,CEDULA,DESCRIPCION,COD_UNIDAD,COSTO,POR_IMPUESTO,COD_IMPUESTO_DGTD,PRECIO, PRECIO_2, PRECIO_3,EXENTO,ESTADO,MINIMO,COD_BARRA,FECHA_INC,COD_FAMILIA,OBSERVACION,IND_PRECIO_MODIFICABLE,COD_CABYS,MIN_VENTA,DESCUENTO)																	"
                SQL &= Chr(13) & "						SELECT @COD_CIA, @COD_SUCUR, @COD_PROD, @CEDULA, @DESCRIPCION, @COD_UNIDAD, @COSTO, @POR_IMPUESTO, @COD_IMPUESTO, @PRECIO, @PRECIO_2, @PRECIO_3, @EXENTO, @ESTADO, @MINIMO, @COD_BARRA, GETDATE(), @COD_FAMILIA, @OBSERVACION, @IND_PRECIO_MODIFICABLE, @COD_CABYS,@MIN_VENTA,@MAX_DESCUENTO																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "						EXECUTE USP_PRODUCTO_UBICACIONES_MANT @COD_CIA, @COD_SUCUR,	@COD_PROD, @ESTANTE, @FILA, @COLUMNA, 'A'																"
                SQL &= Chr(13) & "					END																		"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			ELSE IF @MODO = 3																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				UPDATE PRODUCTO 																			"
                SQL &= Chr(13) & "				SET CEDULA = @CEDULA																			"
                SQL &= Chr(13) & "				,DESCRIPCION = @DESCRIPCION																			"
                SQL &= Chr(13) & "				,COD_UNIDAD = @COD_UNIDAD																			"
                SQL &= Chr(13) & "				,COSTO = @COSTO 																			"
                SQL &= Chr(13) & "				,POR_IMPUESTO = @POR_IMPUESTO																			"
                SQL &= Chr(13) & "				,COD_IMPUESTO_DGTD = @COD_IMPUESTO																			"
                SQL &= Chr(13) & "				,PRECIO = @PRECIO																			"
                SQL &= Chr(13) & "				,PRECIO_2 = @PRECIO_2																			"
                SQL &= Chr(13) & "				,PRECIO_3 = @PRECIO_3																			"
                SQL &= Chr(13) & "				,EXENTO = @EXENTO																			"
                SQL &= Chr(13) & "				,ESTADO = @ESTADO																			"
                SQL &= Chr(13) & "				,MINIMO = @MINIMO																			"
                SQL &= Chr(13) & "				,COD_BARRA = @COD_BARRA																			"
                SQL &= Chr(13) & "				,COD_FAMILIA = @COD_FAMILIA																			"
                SQL &= Chr(13) & "				,OBSERVACION = @OBSERVACION																			"
                SQL &= Chr(13) & "              ,IND_PRECIO_MODIFICABLE = @IND_PRECIO_MODIFICABLE   "
                SQL &= Chr(13) & "              ,COD_CABYS = @COD_CABYS   "
                SQL &= Chr(13) & "              ,MIN_VENTA = @MIN_VENTA   "
                SQL &= Chr(13) & "              ,DESCUENTO = @MAX_DESCUENTO   "
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				And COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND COD_PROD = @COD_PROD																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			ELSE IF @MODO = 5																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT *																			"
                SQL &= Chr(13) & "				FROM PRODUCTO																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				And COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND COD_PROD = @COD_PROD																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			COMMIT TRAN TSN_PRODUCTO_MANT 																				"
                SQL &= Chr(13) & "			END TRY																				"
                SQL &= Chr(13) & "			BEGIN CATCH 																				"
                SQL &= Chr(13) & "		 		ROLLBACK TRAN																			"
                SQL &= Chr(13) & "		 		DECLARE @MENSAJE VARCHAR(500)																			"
                SQL &= Chr(13) & "		 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																			"
                SQL &= Chr(13) & "		 		RAISERROR( @MENSAJE, 16, 1)																			"
                SQL &= Chr(13) & "			END CATCH																				"
                SQL &= Chr(13) & "		END																					"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DATOS_RECIBO_IMPRESION()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_RECIBO_IMPRESION", "2021-01-12") Then
                ELIMINA_PROCEDIMIENTO("USP_DATOS_RECIBO_IMPRESION")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_RECIBO_IMPRESION] 																									"
                SQL &= Chr(13) & "			 @COD_CIA VARCHAR(3)																							"
                SQL &= Chr(13) & "			,@COD_SUCUR VARCHAR(3)																							"
                SQL &= Chr(13) & "			,@NUMERO_DOC INT																							"
                SQL &= Chr(13) & "			,@TIPO_MOV VARCHAR(2)																							"
                SQL &= Chr(13) & "		AS																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT CIA.NOMBRE AS Compania, SUC.NOMBRE AS Sucursal, CIA.CEDULA AS Cedula, SUC.TELEFONO + CASE WHEN ISNULL(SUC.TELEFONO_2, '') = '' THEN '' ELSE '/' + TELEFONO_2 END AS Telefono, CIA.PROVINCIA AS Provincia,																						"
                SQL &= Chr(13) & "				CIA.CANTON AS Canton, CIA.DISTRITO AS Distrito, SUC.DIRECCION AS Direccion, CIA.CORREO as Correo																						"
                SQL &= Chr(13) & "				FROM COMPANIA AS CIA																						"
                SQL &= Chr(13) & "				INNER JOIN SUCURSAL AS SUC																						"
                SQL &= Chr(13) & "					ON SUC.COD_CIA = CIA.COD_CIA																					"
                SQL &= Chr(13) & "				WHERE CIA.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND SUC.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT 'RECIBO DE DINERO' AS TIPO, ENC.NUMERO_DOC AS Numero, ENC.FECHA, CASE WHEN ENC.FORMA_PAGO = 'EF' THEN 'EFECTIVO' WHEN ENC.FORMA_PAGO = 'TA' THEN 'TARJETA' ELSE 'TRANSFERENCIA' END AS VENTA,																						"
                SQL &= Chr(13) & "				(CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2) AS NOMBRE, U.NOMBRE AS USUARIO, CASE WHEN ENC.COD_MONEDA = 'L' THEN 'COLONES' ELSE 'DOLARES' END AS MONEDA, ISNULL(ENC.DESCRIPCION, '') AS DETALLE																						"
                SQL &= Chr(13) & "				FROM DOCUMENTO_ENC AS ENC																						"
                SQL &= Chr(13) & "				INNER JOIN CLIENTE AS CLI																						"
                SQL &= Chr(13) & "					ON CLI.COD_CIA = ENC.COD_CIA																					"
                SQL &= Chr(13) & "					AND CLI.CEDULA = ENC.CEDULA																					"
                SQL &= Chr(13) & "				INNER JOIN USUARIO AS U																						"
                SQL &= Chr(13) & "					ON U.COD_USUARIO = ENC.COD_USUARIO																					"
                SQL &= Chr(13) & "				WHERE ENC.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND ENC.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "				AND ENC.NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT AFEC.NUMERO_DOC_AFEC, TIPO_MOV_AFEC, CONVERT(VARCHAR(10), ENC.FECHA, 103) AS FECHA, ((ENC.MONTO + ENC.IMPUESTO) - SUM(ISNULL(T1.MONTO, 0))) AS SALDO_ANTERIOR, MONTO_AFEC																						"
                SQL &= Chr(13) & "				, ((ENC.MONTO + ENC.IMPUESTO) - SUM(ISNULL(T1.MONTO, 0))) - MONTO_AFEC AS NUEVO_SALDO																						"
                SQL &= Chr(13) & "				FROM DOCUMENTO_AFEC AS AFEC																						"
                SQL &= Chr(13) & "				INNER JOIN DOCUMENTO_ENC AS ENC																						"
                SQL &= Chr(13) & "					ON ENC.COD_CIA = AFEC.COD_CIA																					"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = AFEC.COD_SUCUR																					"
                SQL &= Chr(13) & "					AND ENC.TIPO_MOV = AFEC.TIPO_MOV_AFEC																					"
                SQL &= Chr(13) & "					AND ENC.NUMERO_DOC = AFEC.NUMERO_DOC_AFEC																					"
                SQL &= Chr(13) & "				LEFT JOIN(																						"
                SQL &= Chr(13) & "					SELECT AFEC.COD_CIA, AFEC.COD_SUCUR, AFEC.NUMERO_DOC, NUMERO_DOC_AFEC, AFEC.TIPO_MOV, SUM(MONTO_AFEC) AS MONTO, AFEC.FECHA																					"
                SQL &= Chr(13) & "					FROM DOCUMENTO_AFEC	AS AFEC																				"
                SQL &= Chr(13) & "					INNER JOIN DOCUMENTO_ENC AS ENC_REC																					"
                SQL &= Chr(13) & "						ON ENC_REC.COD_CIA = AFEC.COD_CIA																				"
                SQL &= Chr(13) & "						AND ENC_REC.COD_SUCUR = AFEC.COD_SUCUR																				"
                SQL &= Chr(13) & "						AND ENC_REC.TIPO_MOV = AFEC.TIPO_MOV																				"
                SQL &= Chr(13) & "						AND ENC_REC.NUMERO_DOC = AFEC.NUMERO_DOC																				"
                SQL &= Chr(13) & "					WHERE ENC_REC.ESTADO = 'A'																					"
                SQL &= Chr(13) & "					GROUP BY AFEC.COD_CIA, AFEC.COD_SUCUR, AFEC.NUMERO_DOC, NUMERO_DOC_AFEC, AFEC.TIPO_MOV, AFEC.FECHA																					"
                SQL &= Chr(13) & "					) AS T1																					"
                SQL &= Chr(13) & "					ON T1.COD_CIA = AFEC.COD_CIA																					"
                SQL &= Chr(13) & "					AND T1.COD_SUCUR = AFEC.COD_SUCUR																					"
                SQL &= Chr(13) & "					AND T1.TIPO_MOV = AFEC.TIPO_MOV																					"
                SQL &= Chr(13) & "					AND T1.NUMERO_DOC_AFEC = AFEC.NUMERO_DOC_AFEC																					"
                SQL &= Chr(13) & "					AND T1.NUMERO_DOC < AFEC.NUMERO_DOC																					"
                SQL &= Chr(13) & "				WHERE AFEC.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND AFEC.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND AFEC.TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "				AND AFEC.NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "				GROUP BY AFEC.NUMERO_DOC_AFEC, TIPO_MOV_AFEC, ENC.FECHA, MONTO_AFEC, ENC.MONTO, ENC.IMPUESTO																						"
                SQL &= Chr(13) & "	            UNION ALL 																									"
                SQL &= Chr(13) & "				SELECT AFEC.NUMERO_DOC_AFEC, TIPO_MOV_AFEC, CONVERT(VARCHAR(10), ENC.FECHA, 103) AS FECHA, ((ENC.MONTO + ENC.IMPUESTO) - SUM(ISNULL(T1.MONTO, 0))) AS SALDO_ANTERIOR, MONTO_AFEC																					"
                SQL &= Chr(13) & "				, ((ENC.MONTO + ENC.IMPUESTO) - SUM(ISNULL(T1.MONTO, 0))) - MONTO_AFEC AS NUEVO_SALDO																					"
                SQL &= Chr(13) & "				FROM DOCUMENTO_AFEC AS AFEC																					"
                SQL &= Chr(13) & "				INNER JOIN APARTADO_ENC AS ENC																					"
                SQL &= Chr(13) & "					ON ENC.COD_CIA = AFEC.COD_CIA																				"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = AFEC.COD_SUCUR																				"
                SQL &= Chr(13) & "					AND ENC.TIPO_MOV = AFEC.TIPO_MOV_AFEC																				"
                SQL &= Chr(13) & "					AND ENC.NUMERO_DOC = AFEC.NUMERO_DOC_AFEC																				"
                SQL &= Chr(13) & "				LEFT JOIN(																					"
                SQL &= Chr(13) & "					SELECT AFEC.COD_CIA, AFEC.COD_SUCUR, AFEC.NUMERO_DOC, NUMERO_DOC_AFEC, AFEC.TIPO_MOV, SUM(MONTO_AFEC) AS MONTO, AFEC.FECHA																				"
                SQL &= Chr(13) & "					FROM DOCUMENTO_AFEC	AS AFEC																			"
                SQL &= Chr(13) & "					INNER JOIN APARTADO_ENC AS ENC_REC																				"
                SQL &= Chr(13) & "						ON ENC_REC.COD_CIA = AFEC.COD_CIA																			"
                SQL &= Chr(13) & "						AND ENC_REC.COD_SUCUR = AFEC.COD_SUCUR																			"
                SQL &= Chr(13) & "						AND ENC_REC.TIPO_MOV = AFEC.TIPO_MOV																			"
                SQL &= Chr(13) & "						AND ENC_REC.NUMERO_DOC = AFEC.NUMERO_DOC																			"
                SQL &= Chr(13) & "					WHERE ENC_REC.ESTADO = 'A'																				"
                SQL &= Chr(13) & "					GROUP BY AFEC.COD_CIA, AFEC.COD_SUCUR, AFEC.NUMERO_DOC, NUMERO_DOC_AFEC, AFEC.TIPO_MOV, AFEC.FECHA																				"
                SQL &= Chr(13) & "					) AS T1																				"
                SQL &= Chr(13) & "					ON T1.COD_CIA = AFEC.COD_CIA																				"
                SQL &= Chr(13) & "					AND T1.COD_SUCUR = AFEC.COD_SUCUR																				"
                SQL &= Chr(13) & "					AND T1.TIPO_MOV = AFEC.TIPO_MOV																				"
                SQL &= Chr(13) & "					AND T1.NUMERO_DOC_AFEC = AFEC.NUMERO_DOC_AFEC																				"
                SQL &= Chr(13) & "					AND T1.NUMERO_DOC < AFEC.NUMERO_DOC																				"
                SQL &= Chr(13) & "				WHERE AFEC.COD_CIA = @COD_CIA																					"
                SQL &= Chr(13) & "				AND AFEC.COD_SUCUR = @COD_SUCUR																					"
                SQL &= Chr(13) & "				AND AFEC.TIPO_MOV = @TIPO_MOV																					"
                SQL &= Chr(13) & "				AND AFEC.NUMERO_DOC = @NUMERO_DOC																					"
                SQL &= Chr(13) & "				GROUP BY AFEC.NUMERO_DOC_AFEC, TIPO_MOV_AFEC, ENC.FECHA, MONTO_AFEC, ENC.MONTO, ENC.IMPUESTO																					"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT COUNT(AFEC.NUMERO_DOC_AFEC) AS DOCS_AFEC, (ENC.MONTO + ENC.IMPUESTO) AS MR, SUM(AFEC.MONTO_AFEC) AS MU, ENC.SALDO AS SR																						"
                SQL &= Chr(13) & "				FROM DOCUMENTO_AFEC AS AFEC																						"
                SQL &= Chr(13) & "				INNER JOIN DOCUMENTO_ENC AS ENC																						"
                SQL &= Chr(13) & "					ON ENC.COD_CIA = AFEC.COD_CIA																					"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = AFEC.COD_SUCUR																					"
                SQL &= Chr(13) & "					AND ENC.TIPO_MOV = AFEC.TIPO_MOV																					"
                SQL &= Chr(13) & "					AND ENC.NUMERO_DOC = AFEC.NUMERO_DOC																					"
                SQL &= Chr(13) & "				WHERE AFEC.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND AFEC.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND AFEC.TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "				AND AFEC.NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "				GROUP BY ENC.MONTO, ENC.IMPUESTO, ENC.SALDO																						"
                SQL &= Chr(13) & "		END		"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DATOS_REPORTE_INVENTARIO()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_REPORTE_INVENTARIO", "2020-10-11") Then
                ELIMINA_PROCEDIMIENTO("USP_DATOS_REPORTE_INVENTARIO")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_REPORTE_INVENTARIO] 																						"
                SQL &= Chr(13) & "	@COD_CIA VARCHAR(3),																						"
                SQL &= Chr(13) & "	@COD_SUCUR VARCHAR(3),																						"
                SQL &= Chr(13) & "	@FECHA DATETIME,																						"
                SQL &= Chr(13) & "	@COD_FAMILIA VARCHAR(3)																						"
                SQL &= Chr(13) & "	AS   																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		BEGIN TRY																					"
                SQL &= Chr(13) & "		BEGIN TRAN TSN_REPORTE_INVENTARIO																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		SELECT CIA.NOMBRE, SUC.NOMBRE, PROD.COD_PROD, PROD.DESCRIPCION, SUM(ISNULL(DET.CANTIDAD, 0)) AS CANTIDAD, PROD.COSTO, PROD.PRECIO, PROD.PRECIO_2																					"
                SQL &= Chr(13) & "		,PROD.PRECIO_3, ISNULL(FAM.DESCRIPCION, 'Sin Familia') AS FAMILIA																					"
                SQL &= Chr(13) & "		FROM PRODUCTO AS PROD																					"
                SQL &= Chr(13) & "		LEFT JOIN INVENTARIO_MOV_DET AS DET																					"
                SQL &= Chr(13) & "			ON DET.COD_CIA = PROD.COD_CIA																				"
                SQL &= Chr(13) & "			AND DET.COD_SUCUR = PROD.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND DET.COD_PROD = PROD.COD_PROD																				"
                SQL &= Chr(13) & "		INNER JOIN COMPANIA AS CIA																					"
                SQL &= Chr(13) & "			ON CIA.COD_CIA = PROD.COD_CIA																				"
                SQL &= Chr(13) & "		INNER JOIN SUCURSAL AS SUC																					"
                SQL &= Chr(13) & "			ON SUC.COD_CIA = PROD.COD_CIA																				"
                SQL &= Chr(13) & "			AND SUC.COD_SUCUR = PROD.COD_SUCUR																				"
                SQL &= Chr(13) & "		LEFT JOIN FAMILIA AS FAM 																					"
                SQL &= Chr(13) & "			ON FAM.CODIGO = PROD.COD_FAMILIA																				"
                SQL &= Chr(13) & "		WHERE PROD.COD_CIA = @COD_CIA																					"
                SQL &= Chr(13) & "		AND PROD.COD_SUCUR = @COD_SUCUR																					"
                SQL &= Chr(13) & "		AND (PROD.COD_FAMILIA = @COD_FAMILIA OR @COD_FAMILIA = '')																					"
                SQL &= Chr(13) & "		GROUP BY CIA.NOMBRE, SUC.NOMBRE, PROD.COD_PROD, PROD.DESCRIPCION, FAM.DESCRIPCION, PROD.COSTO, PROD.PRECIO, PROD.PRECIO_2, PROD.PRECIO_3, PROD.COD_FAMILIA																					"
                SQL &= Chr(13) & "		ORDER BY FAMILIA ASC, DESCRIPCION ASC																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	COMMIT TRAN TSN_REPORTE_INVENTARIO 																						"
                SQL &= Chr(13) & "	END TRY																						"
                SQL &= Chr(13) & "	BEGIN CATCH 																						"
                SQL &= Chr(13) & "		ROLLBACK TRAN																					"
                SQL &= Chr(13) & "		DECLARE @MENSAJE VARCHAR(500)																					"
                SQL &= Chr(13) & "		SET @MENSAJE =( SELECT ERROR_MESSAGE())																					"
                SQL &= Chr(13) & "		RAISERROR( @MENSAJE, 16, 1)																					"
                SQL &= Chr(13) & "	END CATCH																						"
                SQL &= Chr(13) & "	END																						"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DATOS_FACTURA_IMPRESION()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_FACTURA_IMPRESION", "2021-02-22") Then
                ELIMINA_PROCEDIMIENTO("USP_DATOS_FACTURA_IMPRESION")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_FACTURA_IMPRESION] 																						"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@NUMERO_DOC INT																					"
                SQL &= Chr(13) & "		,@TIPO_MOV VARCHAR(2)																					"
                SQL &= Chr(13) & "	AS																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT CIA.NOMBRE AS Compania, SUC.NOMBRE AS Sucursal, CIA.CEDULA AS Cedula, SUC.TELEFONO + CASE WHEN ISNULL(SUC.TELEFONO_2, '') = '' THEN '' ELSE '/' + TELEFONO_2 END AS Telefono, CIA.PROVINCIA AS Provincia,																				"
                SQL &= Chr(13) & "			CIA.CANTON AS Canton, CIA.DISTRITO AS Distrito, SUC.DIRECCION AS Direccion, CIA.CORREO as Correo, CIA.FE																				"
                SQL &= Chr(13) & "			FROM COMPANIA AS CIA																				"
                SQL &= Chr(13) & "			INNER JOIN SUCURSAL AS SUC																				"
                SQL &= Chr(13) & "				ON SUC.COD_CIA = CIA.COD_CIA																			"
                SQL &= Chr(13) & "			WHERE CIA.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND SUC.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	SELECT CASE DE.TIPO_COMPROBANTE WHEN '01' THEN 'FACTURA ELECTRONICA' WHEN '04' THEN 'TIQUETE ELECTRONICO' ELSE 'FACTURA' END AS TIPO, DE.CONSECUTIVO AS Consec,																						"
                SQL &= Chr(13) & "				ENC.NUMERO_DOC AS Numero, 'CLAVE NUMERICA' AS CLAVE_S, DE.CLAVE AS Clave, ENC.FECHA, CASE WHEN ENC.TIPO_MOV = 'FC' THEN 'CONTADO' ELSE 'CREDITO' END AS VENTA,																			"
                SQL &= Chr(13) & "				(CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2) AS Nombre, U.NOMBRE AS Usuario, CASE WHEN ENC.COD_MONEDA = 'L' THEN 'COLONES' ELSE 'DOLARES' END AS MONEDA,																			"
                SQL &= Chr(13) & "				ENC.DESCRIPCION AS DETALLE																			"
                SQL &= Chr(13) & "				FROM DOCUMENTO_ENC AS ENC																			"
                SQL &= Chr(13) & "				LEFT JOIN DOCUMENTO_ELECTRONICO AS DE																			"
                SQL &= Chr(13) & "					ON ENC.COD_CIA = DE.COD_CIA																		"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = DE.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND ENC.TIPO_MOV = DE.TIPO_MOV 																		"
                SQL &= Chr(13) & "					AND ENC.NUMERO_DOC = DE.NUMERO_DOC																		"
                SQL &= Chr(13) & "				INNER JOIN CLIENTE AS CLI																			"
                SQL &= Chr(13) & "					ON CLI.COD_CIA = ENC.COD_CIA																		"
                SQL &= Chr(13) & "					AND CLI.CEDULA = ENC.CEDULA																		"
                SQL &= Chr(13) & "				INNER JOIN USUARIO AS U																			"
                SQL &= Chr(13) & "					ON U.COD_USUARIO = ENC.COD_USUARIO																		"
                SQL &= Chr(13) & "				WHERE ENC.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND ENC.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = @TIPO_MOV																			"
                SQL &= Chr(13) & "				AND ENC.NUMERO_DOC = @NUMERO_DOC																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT DET.LINEA, P.COD_PROD,  P.DESCRIPCION, DET.PRECIO, DET.CANTIDAD, DET.IMPUESTO, DET.DESCUENTO, DET.SUBTOTAL, DET.TOTAL																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_DET AS DET																				"
                SQL &= Chr(13) & "			INNER JOIN PRODUCTO AS P																				"
                SQL &= Chr(13) & "				ON P.COD_CIA = DET.COD_CIA																			"
                SQL &= Chr(13) & "				AND P.COD_SUCUR = DET.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND P.COD_PROD = DET.COD_PROD																			"
                SQL &= Chr(13) & "			WHERE DET.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND DET.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND DET.TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "			AND DET.NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT COUNT(*) AS LINEAS, SUM(CASE WHEN IMPUESTO > 0 OR (POR_IMPUESTO > 0 AND IMPUESTO = 0) THEN SUBTOTAL ELSE 0 END) AS GRAVADO, SUM(CASE WHEN IMPUESTO = 0 AND POR_IMPUESTO = 0 THEN SUBTOTAL ELSE 0 END) AS EXENTO,																				"
                SQL &= Chr(13) & "			SUM(EXONERACION) AS EXONERADO, SUM(DESCUENTO) AS DESCUENTO, SUM(SUBTOTAL) AS SUBTOTAL, SUM(IMPUESTO) AS IMPUESTO, SUM(TOTAL) AS TOTAL																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_DET																				"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "			AND NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT GUIA.NUMERO_GUIA, GUIA.ENVIA, GUIA.RETIRA, GUIA.DESCRIPCION AS DETALLE_GUIA, GUIA.VALOR_ENCOMIENDA AS VALOR																				"
                SQL &= Chr(13) & "			,substring(convert(char(8),ENC.FECHA_INC,114), 1, 8) AS HORA_INGRESO																				"
                SQL &= Chr(13) & "			, CASE WHEN convert(char(5), ENC.FECHA_INC, 108) <= '10:00' THEN '10:00' 																				"
                SQL &= Chr(13) & "			       WHEN convert(char(5), ENC.FECHA_INC, 108) > '10:00' AND  convert(char(5), ENC.FECHA_INC, 108) <= '14:00'  THEN '14:00'																				"
                SQL &= Chr(13) & "				   WHEN convert(char(5), ENC.FECHA_INC, 108) >= '14:00' AND convert(char(5), ENC.FECHA_INC, 108) <= '17:30' THEN '17:30' 																			"
                SQL &= Chr(13) & "				   ELSE '10:00' 																			"
                SQL &= Chr(13) & "				   END AS HORA_ENVIO																			"
                SQL &= Chr(13) & "			FROM DOCUMENTO_GUIA AS GUIA																				"
                SQL &= Chr(13) & "			INNER JOIN DOCUMENTO_ENC AS ENC																				"
                SQL &= Chr(13) & "				ON ENC.COD_CIA = GUIA.COD_CIA																			"
                SQL &= Chr(13) & "				AND ENC.COD_SUCUR = GUIA.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = GUIA.TIPO_MOV																			"
                SQL &= Chr(13) & "				AND ENC.NUMERO_DOC = GUIA.NUMERO_DOC																			"
                SQL &= Chr(13) & "			WHERE GUIA.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND GUIA.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND GUIA.TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "			AND GUIA.NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "	END																						"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_CXP_FACTURACION_TMP_A_REAL()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_CXP_FACTURACION_TMP_A_REAL", "2020-10-18") Then
                ELIMINA_PROCEDIMIENTO("USP_CXP_FACTURACION_TMP_A_REAL")


                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_CXP_FACTURACION_TMP_A_REAL] 																						"
                SQL &= Chr(13) & "	 @COD_CIA VARCHAR(3)																						"
                SQL &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)																						"
                SQL &= Chr(13) & "	,@TIPO_MOV VARCHAR(2)																						"
                SQL &= Chr(13) & "	,@CODIGO VARCHAR(20)																						"
                SQL &= Chr(13) & "  ,@NUMERO_DOC_ENV INT = 0"
                SQL &= Chr(13) & "	AS																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "		BEGIN TRY																					"
                SQL &= Chr(13) & "		BEGIN TRAN TR_FACTURACION_TMP_A_REAL																					"
                SQL &= Chr(13) & "		DECLARE @NUMERO_DOC INTEGER																					"
                SQL &= Chr(13) & "		DECLARE @TIPO_NOTA AS VARCHAR(2), @CEDULA VARCHAR(25)																					"
                SQL &= Chr(13) & "		DECLARE @FECHA_DOC AS DATETIME																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "	    IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'																						"
                SQL &= Chr(13) & "				BEGIN																			"
                SQL &= Chr(13) & "					IF @NUMERO_DOC_ENV = 0																		"
                SQL &= Chr(13) & "					BEGIN																		"
                SQL &= Chr(13) & "						SELECT @NUMERO_DOC =  ISNULL(MAX(NUMERO_DOC), 0) + 1 																	"
                SQL &= Chr(13) & "						FROM CXP_DOCUMENTO_ENC																	"
                SQL &= Chr(13) & "						WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "						AND COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "						AND TIPO_MOV <> 'NC'																	"
                SQL &= Chr(13) & "					END																		"
                SQL &= Chr(13) & "					ELSE																		"
                SQL &= Chr(13) & "					BEGIN																		"
                SQL &= Chr(13) & "						SET @NUMERO_DOC = @NUMERO_DOC_ENV																	"
                SQL &= Chr(13) & "					END																		"
                SQL &= Chr(13) & "				END																			"
                SQL &= Chr(13) & "		ELSE IF @TIPO_MOV = 'NC'																					"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC = ISNULL(MAX(NUMERO_DOC), 0) + 1																			"
                SQL &= Chr(13) & "				FROM CXP_DOCUMENTO_ENC																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TIPO_MOV = 'NC'																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		ELSE IF @TIPO_MOV = 'RB'																					"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC = ISNULL(MAX(NUMERO_DOC), 0) + 1																			"
                SQL &= Chr(13) & "				FROM CXP_DOCUMENTO_ENC																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TIPO_MOV = 'RB'																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "			/*INGRESA EL ENCABEZADO*/																				"
                SQL &= Chr(13) & "			INSERT INTO CXP_DOCUMENTO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)																				"
                SQL &= Chr(13) & "			SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO, SUM(DET.SUBTOTAL), SUM(DET.IMPUESTO), SUM(DET.TOTAL),TMP.COD_MONEDA																				"
                SQL &= Chr(13) & "			,TMP.TIPO_CAMBIO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION,TMP.TIPO_NOTA																				"
                SQL &= Chr(13) & "			FROM CXP_DOCUMENTO_ENC_TMP AS TMP																				"
                SQL &= Chr(13) & "			INNER JOIN CXP_DOCUMENTO_DET_TMP AS DET	 																			"
                SQL &= Chr(13) & "	            ON DET.COD_CIA = TMP.COD_CIA 																						"
                SQL &= Chr(13) & "	            AND DET.COD_SUCUR = TMP.COD_SUCUR 																						"
                SQL &= Chr(13) & "	            AND DET.CODIGO = TMP.CODIGO 																						"
                SQL &= Chr(13) & "	            AND DET.TIPO_MOV = TMP.TIPO_MOV																						"
                SQL &= Chr(13) & "			WHERE TMP.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND TMP.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND TMP.TIPO_MOV = 	@TIPO_MOV																			"
                SQL &= Chr(13) & "			AND TMP.CODIGO = @CODIGO																				"
                SQL &= Chr(13) & "			GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.FORMA_PAGO,TMP.DESCRIPCION,TMP.TIPO_NOTA																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			/*INGRESA EL DETALLE*/																				"
                SQL &= Chr(13) & "			INSERT INTO CXP_DOCUMENTO_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,CEDULA)																				"
                SQL &= Chr(13) & "			SELECT DET.COD_CIA,DET.COD_SUCUR,@NUMERO_DOC,DET.TIPO_MOV,ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,TMP.CEDULA																				"
                SQL &= Chr(13) & "	        FROM CXP_DOCUMENTO_ENC_TMP AS TMP																						"
                SQL &= Chr(13) & "				INNER JOIN CXP_DOCUMENTO_DET_TMP AS DET	 																		"
                SQL &= Chr(13) & "		            ON DET.COD_CIA = TMP.COD_CIA 																					"
                SQL &= Chr(13) & "		            AND DET.COD_SUCUR = TMP.COD_SUCUR 																					"
                SQL &= Chr(13) & "		            AND DET.CODIGO = TMP.CODIGO 																					"
                SQL &= Chr(13) & "		            AND DET.TIPO_MOV = TMP.TIPO_MOV																					"
                SQL &= Chr(13) & "				WHERE TMP.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND TMP.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TMP.TIPO_MOV = 	@TIPO_MOV																		"
                SQL &= Chr(13) & "				AND TMP.CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			DELETE FROM CXP_DOCUMENTO_ENC_TMP WHERE CODIGO = @CODIGO																				"
                SQL &= Chr(13) & "	        DELETE FROM CXP_DOCUMENTO_DET_TMP WHERE CODIGO = @CODIGO																						"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT @FECHA_DOC = FECHA, @CEDULA = CEDULA																				"
                SQL &= Chr(13) & "			FROM CXP_DOCUMENTO_ENC																				"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND TIPO_MOV = 	@TIPO_MOV 																			"
                SQL &= Chr(13) & "			AND NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT @NUMERO_DOC AS Documento																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			ELSE																				"
                SQL &= Chr(13) & "				/*INGRESA RECIBOS*/																			"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				/*INGRESA ENCABEZADO*/																			"
                SQL &= Chr(13) & "				INSERT INTO CXP_DOCUMENTO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)																			"
                SQL &= Chr(13) & "				SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO, SUM(DET.MONTO_DOC), 0, SUM(DET.MONTO_DOC) - SUM(DET.MONTO_AFEC),TMP.COD_MONEDA																			"
                SQL &= Chr(13) & "				,TMP.TIPO_CAMBIO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION,TMP.TIPO_NOTA																			"
                SQL &= Chr(13) & "				FROM CXP_DOCUMENTO_ENC_TMP AS TMP																			"
                SQL &= Chr(13) & "				INNER JOIN CXP_DOCUMENTO_AFEC_DET_TMP AS DET	 																		"
                SQL &= Chr(13) & "					ON DET.COD_CIA = TMP.COD_CIA 																		"
                SQL &= Chr(13) & "					AND DET.COD_SUCUR = TMP.COD_SUCUR 																		"
                SQL &= Chr(13) & "					AND DET.CODIGO = TMP.CODIGO 																		"
                SQL &= Chr(13) & "				WHERE TMP.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND TMP.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TMP.TIPO_MOV = 	@TIPO_MOV																		"
                SQL &= Chr(13) & "				AND TMP.CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "				GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.FORMA_PAGO,TMP.DESCRIPCION,TMP.TIPO_NOTA																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				/*INGRESA DOCUMENTOS AFECTADOS*/																			"
                SQL &= Chr(13) & "				INSERT INTO CXP_DOCUMENTO_AFEC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,FECHA,NUMERO_DOC_AFEC,TIPO_MOV_AFEC,MONTO_AFEC,FECHA_INC)																			"
                SQL &= Chr(13) & "				SELECT TMP.COD_CIA, TMP.COD_SUCUR, @NUMERO_DOC, ENC.TIPO_MOV, ENC.FECHA, TMP.NUMERO_DOC, TMP.TIPO_MOV, TMP.MONTO_AFEC, GETDATE() 																			"
                SQL &= Chr(13) & "				FROM CXP_DOCUMENTO_AFEC_DET_TMP AS TMP																			"
                SQL &= Chr(13) & "				INNER JOIN CXP_DOCUMENTO_ENC_TMP AS ENC																			"
                SQL &= Chr(13) & "					ON ENC.COD_CIA = TMP.COD_CIA 																		"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = TMP.COD_SUCUR 																		"
                SQL &= Chr(13) & "					AND ENC.CODIGO = TMP.CODIGO 						 												"
                SQL &= Chr(13) & "				WHERE TMP.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND TMP.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = 	@TIPO_MOV																		"
                SQL &= Chr(13) & "				AND TMP.CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				/*ACTUALIZA SALDOS DOCUMENTOS*/																			"
                SQL &= Chr(13) & "				UPDATE CXP_DOCUMENTO_ENC																			"
                SQL &= Chr(13) & "				SET SALDO = (SALDO - T1.MONTO_AFEC)																			"
                SQL &= Chr(13) & "				FROM(																			"
                SQL &= Chr(13) & "					SELECT  COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV, MONTO_AFEC																		"
                SQL &= Chr(13) & "					FROM CXP_DOCUMENTO_AFEC_DET_TMP																		"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "					AND CODIGO = @CODIGO																		"
                SQL &= Chr(13) & "				) AS T1																			"
                SQL &= Chr(13) & "				WHERE T1.COD_CIA = CXP_DOCUMENTO_ENC.COD_CIA																			"
                SQL &= Chr(13) & "				AND T1.COD_SUCUR = CXP_DOCUMENTO_ENC.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND T1.NUMERO_DOC = CXP_DOCUMENTO_ENC.NUMERO_DOC 																			"
                SQL &= Chr(13) & "				AND T1.TIPO_MOV = CXP_DOCUMENTO_ENC.TIPO_MOV																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				DELETE FROM CXP_DOCUMENTO_ENC_TMP WHERE CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "				DELETE FROM CXP_DOCUMENTO_AFEC_DET_TMP WHERE CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "			 END																				"
                SQL &= Chr(13) & "		COMMIT TRAN TR_FACTURACION_TMP_A_REAL																					"
                SQL &= Chr(13) & "		END TRY																					"
                SQL &= Chr(13) & "		BEGIN CATCH 																					"
                SQL &= Chr(13) & "	 		ROLLBACK TRAN																				"
                SQL &= Chr(13) & "	 		DECLARE @MENSAJE VARCHAR(500)																				"
                SQL &= Chr(13) & "	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																				"
                SQL &= Chr(13) & "	 		RAISERROR( @MENSAJE, 16, 1)																				"
                SQL &= Chr(13) & "		END CATCH																					"
                SQL &= Chr(13) & "	END																						"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_SUCURSAL_MANTENIMIENTO()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_SUCURSAL_MANTENIMIENTO", "2020-10-12") Then
                ELIMINA_PROCEDIMIENTO("USP_SUCURSAL_MANTENIMIENTO")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_SUCURSAL_MANTENIMIENTO]																						"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@NOMBRE VARCHAR(100) = ''																					"
                SQL &= Chr(13) & "		,@DIRECCION VARCHAR(250) = ''																					"
                SQL &= Chr(13) & "		,@TELEFONO VARCHAR(20) = ''																					"
                SQL &= Chr(13) & "		,@TELEFONO2 VARCHAR(20) = ''																					"
                SQL &= Chr(13) & "		,@CORREO VARCHAR(150) = ''																					"
                SQL &= Chr(13) & "		,@ESTADO CHAR(1) = ''																					"
                SQL &= Chr(13) & "		,@RUTA_TIQUETE VARCHAR(150) = ''																					"
                SQL &= Chr(13) & "		,@ANCHO_TIQUETE INT = 0																					"
                SQL &= Chr(13) & "		,@RUTA_ETIQUETA VARCHAR(150) = ''																					"
                SQL &= Chr(13) & "		,@ANCHO_ETIQUETA INT = 0																					"
                SQL &= Chr(13) & "		,@MODO INT																					"
                SQL &= Chr(13) & "		AS																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			IF @MODO = 1																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				INSERT INTO SUCURSAL(COD_CIA,COD_SUCUR,NOMBRE,DIRECCION,TELEFONO,TELEFONO_2,CORREO,FECHA_INC,IMPRESION_TIQUETE,ANCHO_TIQUETE,IMPRESION_ETIQUETA,ANCHO_ETIQUETA)																			"
                SQL &= Chr(13) & "				SELECT @COD_CIA, @COD_SUCUR, @NOMBRE, @DIRECCION, @TELEFONO, @TELEFONO2, @CORREO, GETDATE(), @RUTA_TIQUETE, @ANCHO_TIQUETE,@RUTA_ETIQUETA,@ANCHO_ETIQUETA																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			ELSE IF @MODO = 3																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				UPDATE SUCURSAL																			"
                SQL &= Chr(13) & "				SET NOMBRE = @NOMBRE, DIRECCION = @DIRECCION, TELEFONO = @TELEFONO, TELEFONO_2 = @TELEFONO2, CORREO = @CORREO, ESTADO = @ESTADO, IMPRESION_TIQUETE = @RUTA_TIQUETE, ANCHO_TIQUETE = @ANCHO_TIQUETE																			"
                SQL &= Chr(13) & "					,IMPRESION_ETIQUETA = @RUTA_ETIQUETA, ANCHO_ETIQUETA = @ANCHO_ETIQUETA																		"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			ELSE IF @MODO = 5																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT *																			"
                SQL &= Chr(13) & "				FROM SUCURSAL																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		END																					"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_IMPRIME_FACTURA()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_IMPRIME_FACTURA", "2020-11-18") Then
                ELIMINA_PROCEDIMIENTO("USP_IMPRIME_FACTURA")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_IMPRIME_FACTURA] 																						"
                SQL &= Chr(13) & "		    @COD_CIA VARCHAR(3),																					"
                SQL &= Chr(13) & "			@COD_SUCUR VARCHAR(3),																				"
                SQL &= Chr(13) & "			@NUMERO_DOC INTEGER,																				"
                SQL &= Chr(13) & "			@TIPO_MOV VARCHAR(2)																				"
                SQL &= Chr(13) & "		AS   																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "				SELECT 																			"
                SQL &= Chr(13) & "				/*INFORMACIÓN GENERAL SUCURSAL*/																			"
                SQL &= Chr(13) & "				SUCUR.COD_CIA,CIA.CEDULA,CIA.OBSERVA_TRIBUTARIA,CONVERT(IMAGE,CIA.LOGO) AS LOGO,																			"
                SQL &= Chr(13) & "				CASE WHEN CIA.TIPO_CEDULA='F' THEN 'Física' WHEN CIA.TIPO_CEDULA='F' THEN 'Jurídica' WHEN CIA.TIPO_CEDULA='D' THEN 'Dimex'WHEN CIA.TIPO_CEDULA='D' THEN 'Nite' END AS TIPO_CEDULA,																			"
                SQL &= Chr(13) & "				SUCUR.COD_SUCUR,CIA.NOMBRE,SUCUR.DIRECCION,SUCUR.CORREO,SUCUR.TELEFONO,																			"
                SQL &= Chr(13) & "				/*INFORMACIÓN GENERAL CLIENTE*/																			"
                SQL &= Chr(13) & "				CLI.NOMBRE+' '+CLI.APELLIDO1+' '+CLI.APELLIDO2 AS NOMBRE,CLI.CEDULA AS CEDULA_CLIENTE,CLI.CORREO,																			"
                SQL &= Chr(13) & "				/*INFORMACIÓN DEL ENCABEZADO DEL DOCUMENTO*/																			"
                SQL &= Chr(13) & "				ELEC.CONSECUTIVO,ELEC.CLAVE,ELEC.NUMERO_DOC,																			"
                SQL &= Chr(13) & "				CASE WHEN DOC.COD_MONEDA='L' THEN 'Local' WHEN DOC.COD_MONEDA='D' THEN 'Dólares' END AS COD_MONEDA ,																			"
                SQL &= Chr(13) & "				CASE WHEN DOC.COD_MONEDA='L' THEN '₡' WHEN DOC.COD_MONEDA='D' THEN '$' END AS SIMBOLO ,																			"
                SQL &= Chr(13) & "				CASE WHEN DOC.FORMA_PAGO ='EF' THEN 'Efectivo' WHEN DOC.FORMA_PAGO ='T' THEN 'Tarjeta' END AS FORMA_PAGO,																			"
                SQL &= Chr(13) & "				CASE WHEN DOC.TIPO_MOV ='FC' THEN 'Factura Contado' WHEN DOC.TIPO_MOV ='FA' THEN 'Factura Crédito' END AS TIPO_MOV,																			"
                SQL &= Chr(13) & "				DOC.DESCRIPCION,																			"
                SQL &= Chr(13) & "				DOC.PLAZO,DOC.TIPO_CAMBIO,FORMAT(DOC.FECHA_INC,'dd/MM/yyyy hh:mm:ss') AS FECHA_INC,																			"
                SQL &= Chr(13) & "				/*INFORMACIÓN DEL ENCABEZADO DEL DETALLE*/																			"
                SQL &= Chr(13) & "				DET.LINEA,PROD.DESCRIPCION,DET.COD_PROD,DET.COD_UNIDAD,DET.CANTIDAD,DET.PRECIO,DET.SUBTOTAL,DET.DESCUENTO,DET.IMPUESTO,DET.TOTAL																			"
                SQL &= Chr(13) & "				FROM DOCUMENTO_ENC AS DOC																			"
                SQL &= Chr(13) & "				INNER JOIN DOCUMENTO_DET AS DET																			"
                SQL &= Chr(13) & "					ON DOC.COD_CIA = DET.COD_CIA																		"
                SQL &= Chr(13) & "					AND DOC.COD_SUCUR = DET.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND DOC.NUMERO_DOC = DET.NUMERO_DOC																		"
                SQL &= Chr(13) & "					AND DOC.TIPO_MOV = DET.TIPO_MOV																		"
                SQL &= Chr(13) & "				INNER JOIN DOCUMENTO_ELECTRONICO AS ELEC																			"
                SQL &= Chr(13) & "					ON DOC.COD_CIA = ELEC.COD_CIA																		"
                SQL &= Chr(13) & "					AND DOC.COD_SUCUR = ELEC.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND DOC.NUMERO_DOC = ELEC.NUMERO_DOC																		"
                SQL &= Chr(13) & "					AND DOC.TIPO_MOV = ELEC.TIPO_MOV																		"
                SQL &= Chr(13) & "				INNER JOIN COMPANIA AS CIA																			"
                SQL &= Chr(13) & "					ON DOC.COD_CIA = CIA.COD_CIA																		"
                SQL &= Chr(13) & "				INNER JOIN SUCURSAL AS SUCUR																			"
                SQL &= Chr(13) & "					ON SUCUR.COD_CIA = DOC.COD_CIA																		"
                SQL &= Chr(13) & "					AND SUCUR.COD_SUCUR = DOC.COD_SUCUR																		"
                SQL &= Chr(13) & "				INNER JOIN CLIENTE AS CLI																			"
                SQL &= Chr(13) & "					ON CLI.COD_CIA = DOC.COD_CIA																		"
                SQL &= Chr(13) & "					AND CLI.CEDULA = DOC.CEDULA																		"
                SQL &= Chr(13) & "				INNER JOIN PRODUCTO AS PROD																			"
                SQL &= Chr(13) & "					ON DET.COD_CIA = PROD.COD_CIA																		"
                SQL &= Chr(13) & "					AND DET.COD_SUCUR = PROD.COD_SUCUR																		"
                SQL &= Chr(13) & "					AND DET.COD_PROD = PROD.COD_PROD																		"
                SQL &= Chr(13) & "				WHERE DOC.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND DOC.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND DOC.NUMERO_DOC = @NUMERO_DOC																			"
                SQL &= Chr(13) & "				AND DOC.TIPO_MOV = @TIPO_MOV																			"
                SQL &= Chr(13) & "				ORDER BY DET.LINEA																			"
                SQL &= Chr(13) & "		END																					"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_IMPRIME_NOTA_CREDITO()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_IMPRIME_NOTA_CREDITO", "2020-10-29") Then
                ELIMINA_PROCEDIMIENTO("USP_IMPRIME_NOTA_CREDITO")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_IMPRIME_NOTA_CREDITO] 																						"
                SQL &= Chr(13) & "	@COD_CIA VARCHAR(3),																						"
                SQL &= Chr(13) & "	@COD_SUCUR VARCHAR(3),																						"
                SQL &= Chr(13) & "	@NUMERO_DOC INTEGER,																						"
                SQL &= Chr(13) & "	@TIPO_MOV VARCHAR(2)																						"
                SQL &= Chr(13) & "	AS   																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SELECT 																					"
                SQL &= Chr(13) & "		/*INFORMACIÓN GENERAL SUCURSAL*/																					"
                SQL &= Chr(13) & "		SUCUR.COD_CIA,CIA.CEDULA,CIA.OBSERVA_TRIBUTARIA,CONVERT(IMAGE,CIA.LOGO) AS LOGO,																					"
                SQL &= Chr(13) & "		CASE WHEN CIA.TIPO_CEDULA='F' THEN 'Física' WHEN CIA.TIPO_CEDULA='F' THEN 'Jurídica' WHEN CIA.TIPO_CEDULA='D' THEN 'Dimex'WHEN CIA.TIPO_CEDULA='D' THEN 'Nite' END AS TIPO_CEDULA,																					"
                SQL &= Chr(13) & "		SUCUR.COD_SUCUR,SUCUR.NOMBRE,SUCUR.DIRECCION,SUCUR.CORREO,SUCUR.TELEFONO,																					"
                SQL &= Chr(13) & "		/*INFORMACIÓN GENERAL CLIENTE*/																					"
                SQL &= Chr(13) & "		CLI.NOMBRE+' '+CLI.APELLIDO1+' '+CLI.APELLIDO2 AS NOMBRE,CLI.CEDULA AS CEDULA_CLIENTE,CLI.CORREO,																					"
                SQL &= Chr(13) & "		/*INFORMACIÓN DEL ENCABEZADO DEL DOCUMENTO*/																					"
                SQL &= Chr(13) & "		ISNULL(ELEC.CONSECUTIVO, '0') AS CONSECUTIVO,ISNULL(ELEC.CLAVE, '0') AS CLAVE, ENC.NUMERO_DOC,																					"
                SQL &= Chr(13) & "		CASE WHEN ENC.COD_MONEDA='L' THEN 'Local' WHEN ENC.COD_MONEDA='D' THEN 'Dólares' END AS COD_MONEDA ,																					"
                SQL &= Chr(13) & "		CASE WHEN ENC.COD_MONEDA='L' THEN '₡' WHEN ENC.COD_MONEDA='D' THEN '$' END AS SIMBOLO ,																					"
                SQL &= Chr(13) & "		CASE WHEN ENC.FORMA_PAGO ='EF' THEN 'Efectivo' WHEN ENC.FORMA_PAGO ='T' THEN 'Tarjeta' END AS FORMA_PAGO,																					"
                SQL &= Chr(13) & "		CASE WHEN ENC.TIPO_MOV ='FC' THEN 'Factura Contado' WHEN ENC.TIPO_MOV ='FA' THEN 'Factura Crédito'  ELSE 'Nota Crédito' END AS TIPO_MOV,																					"
                SQL &= Chr(13) & "		ENC.DESCRIPCION,																					"
                SQL &= Chr(13) & "		ENC.PLAZO,ENC.TIPO_CAMBIO,FORMAT(ENC.FECHA_INC,'dd/MM/yyyy hh:mm:ss') AS FECHA_INC,																					"
                SQL &= Chr(13) & "		/*INFORMACIÓN DEL ENCABEZADO DEL DETALLE*/																					"
                SQL &= Chr(13) & "		DOC.NUMERO_DOC, DOC.TIPO_MOV, DOC.MONTO, DOC.IMPUESTO, AFEC.MONTO_AFEC, FORMAT(DOC.FECHA_INC,'dd/MM/yyyy hh:mm:ss') AS 'FECHA DET'																					"
                SQL &= Chr(13) & "		FROM DOCUMENTO_ENC AS ENC																					"
                SQL &= Chr(13) & "		LEFT JOIN DOCUMENTO_ELECTRONICO AS ELEC																					"
                SQL &= Chr(13) & "			ON ENC.COD_CIA = ELEC.COD_CIA																				"
                SQL &= Chr(13) & "			AND ENC.COD_SUCUR = ELEC.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND ENC.NUMERO_DOC = ELEC.NUMERO_DOC																				"
                SQL &= Chr(13) & "			AND ENC.TIPO_MOV = ELEC.TIPO_MOV																				"
                SQL &= Chr(13) & "		INNER JOIN COMPANIA AS CIA																					"
                SQL &= Chr(13) & "			ON ENC.COD_CIA = CIA.COD_CIA																				"
                SQL &= Chr(13) & "		INNER JOIN SUCURSAL AS SUCUR																					"
                SQL &= Chr(13) & "			ON SUCUR.COD_CIA = ENC.COD_CIA																				"
                SQL &= Chr(13) & "			AND SUCUR.COD_SUCUR = ENC.COD_SUCUR																				"
                SQL &= Chr(13) & "		INNER JOIN CLIENTE AS CLI																					"
                SQL &= Chr(13) & "			ON CLI.COD_CIA = ENC.COD_CIA																				"
                SQL &= Chr(13) & "			AND CLI.CEDULA = ENC.CEDULA																				"
                SQL &= Chr(13) & "		INNER JOIN DOCUMENTO_AFEC AS AFEC																					"
                SQL &= Chr(13) & "			ON AFEC.COD_CIA = ENC.COD_CIA																				"
                SQL &= Chr(13) & "			AND AFEC.COD_SUCUR = ENC.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND AFEC.NUMERO_DOC = ENC.NUMERO_DOC																				"
                SQL &= Chr(13) & "			AND AFEC.TIPO_MOV = ENC.TIPO_MOV																				"
                SQL &= Chr(13) & "		INNER JOIN DOCUMENTO_ENC AS DOC																					"
                SQL &= Chr(13) & "			ON DOC.COD_CIA = AFEC.COD_CIA																				"
                SQL &= Chr(13) & "			AND DOC.COD_SUCUR = AFEC.COD_SUCUR																				"
                SQL &= Chr(13) & "			AND DOC.TIPO_MOV = AFEC.TIPO_MOV_AFEC																				"
                SQL &= Chr(13) & "			AND DOC.NUMERO_DOC = AFEC.NUMERO_DOC_AFEC																				"
                SQL &= Chr(13) & "	WHERE ENC.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "	AND ENC.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "	AND ENC.NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "	AND ENC.TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "	END																						"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DATOS_FACTURA_ENCOMIENDA()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_FACTURA_ENCOMIENDA", "2020-10-23") Then
                ELIMINA_PROCEDIMIENTO("USP_DATOS_FACTURA_ENCOMIENDA")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_FACTURA_ENCOMIENDA] 																						"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@NUMERO_DOC INT																					"
                SQL &= Chr(13) & "		,@TIPO_MOV VARCHAR(2)																					"
                SQL &= Chr(13) & "	AS																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT NUMERO_GUIA , RETIRA AS RETIRA																				"
                SQL &= Chr(13) & "			,ENVIA AS ENVIA, TELEFONO_RETIRA AS TELEFONO, CANT_BULTOS																				"
                SQL &= Chr(13) & "			,GETDATE() AS FECHA_IMP, ENC.DESCRIPCION AS DETALLE																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_GUIA AS GUIA																				"
                SQL &= Chr(13) & "			INNER JOIN DOCUMENTO_ENC AS ENC																				"
                SQL &= Chr(13) & "				ON ENC.COD_CIA = GUIA.COD_CIA																			"
                SQL &= Chr(13) & "				AND ENC.COD_SUCUR = GUIA.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = GUIA.TIPO_MOV																			"
                SQL &= Chr(13) & "				AND ENC.NUMERO_DOC = GUIA.NUMERO_DOC																			"
                SQL &= Chr(13) & "			WHERE GUIA.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND GUIA.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND GUIA.NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "			AND GUIA.TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "	END																						"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_PROVEEDOR_MANT()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_PROVEEDOR_MANT", "2020-10-24") Then
                ELIMINA_PROCEDIMIENTO("USP_PROVEEDOR_MANT")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_PROVEEDOR_MANT] 																						"
                SQL &= Chr(13) & "		    @COD_CIA VARCHAR(3),																					"
                SQL &= Chr(13) & "			@COD_SUCUR VARCHAR(3),																				"
                SQL &= Chr(13) & "			@MODO INTEGER,																				"
                SQL &= Chr(13) & "			@CEDULA VARCHAR(25),																				"
                SQL &= Chr(13) & "			@TIPO_CEDULA CHAR(2) = NULL,																				"
                SQL &= Chr(13) & "			@NOMBRE VARCHAR(250) = NULL,																				"
                SQL &= Chr(13) & "			@DIRECCION VARCHAR(250) = NULL,																				"
                SQL &= Chr(13) & "			@TELEFONO VARCHAR(8) = NULL,																				"
                SQL &= Chr(13) & "			@CORREO VARCHAR(150) = NULL,																				"
                SQL &= Chr(13) & "			@ESTADO CHAR(1) = NULL,																				"
                SQL &= Chr(13) & "			@PORCENTAJE INTEGER = 0																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "		AS   																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			IF @MODO = 1																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				INSERT INTO PROVEEDOR(COD_CIA,COD_SUCUR,TIPO_CEDULA,CEDULA,NOMBRE,DIRECCION,TELEFONO,CORREO,ESTADO,FECHA_INC,PORCENTAJE_VENTA) VALUES																			"
                SQL &= Chr(13) & "				(@COD_CIA,@COD_SUCUR,@TIPO_CEDULA,@CEDULA,@NOMBRE,@DIRECCION,@TELEFONO,@CORREO,@ESTADO, GETDATE(), @PORCENTAJE)																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			IF @MODO = 3																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				UPDATE PROVEEDOR SET																			"
                SQL &= Chr(13) & "					NOMBRE = @NOMBRE,																		"
                SQL &= Chr(13) & "					DIRECCION = @DIRECCION,																		"
                SQL &= Chr(13) & "					TELEFONO = @TELEFONO,																		"
                SQL &= Chr(13) & "					CORREO = @CORREO,																		"
                SQL &= Chr(13) & "					ESTADO = @ESTADO,																		"
                SQL &= Chr(13) & "					PORCENTAJE_VENTA = @PORCENTAJE																		"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND CEDULA = @CEDULA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			IF @MODO = 5																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT *																			"
                SQL &= Chr(13) & "				FROM PROVEEDOR																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND CEDULA = @CEDULA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		END																					"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_FAMILIA_MANT()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_FAMILIA_MANT", "2020-10-31") Then
                ELIMINA_PROCEDIMIENTO("USP_FAMILIA_MANT")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_FAMILIA_MANT] 																						"
                SQL &= Chr(13) & "		    @CODIGO VARCHAR(3),																					"
                SQL &= Chr(13) & "			@DESCRIPCION VARCHAR(200) = NULL,																				"
                SQL &= Chr(13) & "			@ESTADO CHAR(1) = 'A',																				"
                SQL &= Chr(13) & "			@COD_CIA VARCHAR(3) = '',																				"
                SQL &= Chr(13) & "			@COD_SUCUR VARCHAR(3) = '',																				"
                SQL &= Chr(13) & "			@MODO AS INTEGER																				"
                SQL &= Chr(13) & "		AS   																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			BEGIN TRY																				"
                SQL &= Chr(13) & "			BEGIN TRAN TSN_FAMILIA_MANT																				"
                SQL &= Chr(13) & "			IF @MODO = 1																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				IF NOT EXISTS(SELECT * FROM FAMILIA WHERE CODIGO = @CODIGO)																			"
                SQL &= Chr(13) & "				BEGIN																			"
                SQL &= Chr(13) & "					INSERT INTO FAMILIA(CODIGO, DESCRIPCION, ESTADO) VALUES																		"
                SQL &= Chr(13) & "					(@CODIGO,@DESCRIPCION,@ESTADO)																		"
                SQL &= Chr(13) & "				END																			"
                SQL &= Chr(13) & "				ELSE																			"
                SQL &= Chr(13) & "				BEGIN																			"
                SQL &= Chr(13) & "					RAISERROR('El codigo ingresado ya existe en la base de datos', 17, 1)																		"
                SQL &= Chr(13) & "				END																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			IF @MODO = 3																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				UPDATE FAMILIA 																			"
                SQL &= Chr(13) & "				SET	DESCRIPCION = @DESCRIPCION, ESTADO = @ESTADO																		"
                SQL &= Chr(13) & "				WHERE CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				UPDATE PRODUCTO																			"
                SQL &= Chr(13) & "				SET ESTADO = @ESTADO																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND COD_FAMILIA = @CODIGO																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			IF @MODO = 5																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT *																			"
                SQL &= Chr(13) & "				FROM FAMILIA																			"
                SQL &= Chr(13) & "				WHERE CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		COMMIT TRAN TSN_FAMILIA_MANT 																					"
                SQL &= Chr(13) & "		END TRY																					"
                SQL &= Chr(13) & "		BEGIN CATCH 																					"
                SQL &= Chr(13) & "		 	ROLLBACK TRAN																				"
                SQL &= Chr(13) & "		 	DECLARE @MENSAJE VARCHAR(500)																				"
                SQL &= Chr(13) & "		 	SET @MENSAJE =( SELECT ERROR_MESSAGE())																				"
                SQL &= Chr(13) & "		 	RAISERROR( @MENSAJE, 16, 1)																				"
                SQL &= Chr(13) & "		END CATCH																					"
                SQL &= Chr(13) & "		END																					"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_CLIENTE_MANT()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_CLIENTE_MANT", "2020-10-31") Then
                ELIMINA_PROCEDIMIENTO("USP_CLIENTE_MANT")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_CLIENTE_MANT] 																						"
                SQL &= Chr(13) & "		    @COD_CIA VARCHAR(3),																					"
                SQL &= Chr(13) & "			@MODO INTEGER,																				"
                SQL &= Chr(13) & "			@CEDULA VARCHAR(25),																				"
                SQL &= Chr(13) & "			@TIPO_CEDULA CHAR(2) = NULL,																				"
                SQL &= Chr(13) & "			@NOMBRE VARCHAR(50) = NULL,																				"
                SQL &= Chr(13) & "			@APELLIDO1 VARCHAR(50) = NULL,																				"
                SQL &= Chr(13) & "			@APELLIDO2 VARCHAR(50) = NULL,																				"
                SQL &= Chr(13) & "			@TELEFONO VARCHAR(8) = NULL,																				"
                SQL &= Chr(13) & "			@DIRECCION VARCHAR(250) = NULL,																				"
                SQL &= Chr(13) & "			@CORREO VARCHAR(150) = NULL,																				"
                SQL &= Chr(13) & "			@SALDO MONEY = NULL,																				"
                SQL &= Chr(13) & "			@MONEDA VARCHAR(3) = NULL,																				"
                SQL &= Chr(13) & "			@FE CHAR(1) = NULL,																				"
                SQL &= Chr(13) & "			@ESTADO CHAR(1) = NULL,																				"
                SQL &= Chr(13) & "			@PROVINCIA VARCHAR(100) = NULL,																				"
                SQL &= Chr(13) & "			@CANTON VARCHAR(100) = NULL,																				"
                SQL &= Chr(13) & "			@DISTRITO VARCHAR(100) = NULL,																				"
                SQL &= Chr(13) & "			@COD_PROVINCIA VARCHAR(10) = NULL,																				"
                SQL &= Chr(13) & "			@COD_DISTRITO VARCHAR(10) = NULL,																				"
                SQL &= Chr(13) & "			@COD_CANTON VARCHAR(10) = NULL,																				"
                SQL &= Chr(13) & "			@PRECIO_DEFECTO INT = 0																				"
                SQL &= Chr(13) & "		AS   																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			IF @MODO = 1																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				INSERT INTO CLIENTE(COD_CIA,TIPO_CEDULA,CEDULA,NOMBRE,APELLIDO1,APELLIDO2,TELEFONO,DIRECCION,CORREO,SALDO,MONEDA,FE,ESTADO,FECHA_INC,COD_PROVINCIA,PROVINCIA,COD_CANTON,CANTON,COD_DISTRITO,DISTRITO,PRECIO_DEFECTO) VALUES																			"
                SQL &= Chr(13) & "				(@COD_CIA,@TIPO_CEDULA,@CEDULA,@NOMBRE,@APELLIDO1,@APELLIDO2,@TELEFONO,@DIRECCION,@CORREO,@SALDO,@MONEDA,@FE,@ESTADO,GETDATE(),@COD_PROVINCIA,@PROVINCIA,@COD_CANTON,@CANTON,@COD_DISTRITO,@DISTRITO,@PRECIO_DEFECTO)																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			IF @MODO = 3																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				UPDATE CLIENTE SET																			"
                SQL &= Chr(13) & "					NOMBRE = @NOMBRE,																		"
                SQL &= Chr(13) & "					APELLIDO1 = @APELLIDO1,																		"
                SQL &= Chr(13) & "					APELLIDO2 = @APELLIDO2,																		"
                SQL &= Chr(13) & "					TELEFONO = @TELEFONO,																		"
                SQL &= Chr(13) & "					DIRECCION = @DIRECCION,																		"
                SQL &= Chr(13) & "					CORREO = @CORREO,																		"
                SQL &= Chr(13) & "					SALDO = @SALDO,																		"
                SQL &= Chr(13) & "					MONEDA = @MONEDA,																		"
                SQL &= Chr(13) & "					FE = @FE,																		"
                SQL &= Chr(13) & "					ESTADO = @ESTADO,																		"
                SQL &= Chr(13) & "					PROVINCIA = @PROVINCIA,																		"
                SQL &= Chr(13) & "					COD_PROVINCIA = @COD_PROVINCIA,																		"
                SQL &= Chr(13) & "					CANTON = @CANTON,																		"
                SQL &= Chr(13) & "					COD_CANTON = @COD_CANTON,																		"
                SQL &= Chr(13) & "					DISTRITO  = @DISTRITO,																		"
                SQL &= Chr(13) & "					COD_DISTRITO = @COD_DISTRITO,																		"
                SQL &= Chr(13) & "					PRECIO_DEFECTO = @PRECIO_DEFECTO																		"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				 AND CEDULA = @CEDULA																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			IF @MODO = 5																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT *																			"
                SQL &= Chr(13) & "				FROM CLIENTE																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND CEDULA = @CEDULA																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "		END																					"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_MANT_PROFORMA_TMP()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_MANT_PROFORMA_TMP", "2020-11-10") Then
                ELIMINA_PROCEDIMIENTO("USP_MANT_PROFORMA_TMP")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_MANT_PROFORMA_TMP] 																						"
                SQL &= Chr(13) & "	                	 @COD_CIA VARCHAR(3)																					"
                SQL &= Chr(13) & "	                	,@COD_SUCUR VARCHAR(3)																					"
                SQL &= Chr(13) & "	                	,@CODIGO VARCHAR(20) 																					"
                SQL &= Chr(13) & "	                	,@TIPO_MOV VARCHAR(2) 																					"
                SQL &= Chr(13) & "	                	,@CEDULA VARCHAR(25) 																					"
                SQL &= Chr(13) & "	                	,@FECHA DATETIME 																					"
                SQL &= Chr(13) & "	                	,@COD_USUARIO VARCHAR(8) 																					"
                SQL &= Chr(13) & "	                	,@COD_MONEDA CHAR(1) 																					"
                SQL &= Chr(13) & "	                	,@TIPO_CAMBIO MONEY																					"
                SQL &= Chr(13) & "	                	,@PLAZO INT																					"
                SQL &= Chr(13) & "	                	,@FORMA_PAGO CHAR(2)																					"
                SQL &= Chr(13) & "	                	,@DESCRIPCION VARCHAR(250)																					"
                SQL &= Chr(13) & "	                	,@COD_PROD VARCHAR(20)																					"
                SQL &= Chr(13) & "	                	,@COD_UNIDAD VARCHAR(10)																					"
                SQL &= Chr(13) & "	                	,@CANTIDAD MONEY																					"
                SQL &= Chr(13) & "	                	,@PRECIO MONEY																					"
                SQL &= Chr(13) & "	                	,@POR_DESCUENTO INT																					"
                SQL &= Chr(13) & "	                	,@DESCUENTO MONEY																					"
                SQL &= Chr(13) & "	                	,@POR_IMPUESTO INT																					"
                SQL &= Chr(13) & "	                	,@IMPUESTO MONEY																					"
                SQL &= Chr(13) & "						,@POR_EXO INT																	"
                SQL &= Chr(13) & "	                	,@EXONERACION MONEY																					"
                SQL &= Chr(13) & "	                	,@SUBTOTAL MONEY																					"
                SQL &= Chr(13) & "	                	,@TOTAL MONEY																					"
                SQL &= Chr(13) & "						,@ESTANTE VARCHAR(3)																	"
                SQL &= Chr(13) & "						,@FILA VARCHAR(3)																	"
                SQL &= Chr(13) & "						,@COLUMNA VARCHAR(3)																	"
                SQL &= Chr(13) & "	                	,@MODO INT																					"
                SQL &= Chr(13) & "	                	AS																					"
                SQL &= Chr(13) & "	                	BEGIN																					"
                SQL &= Chr(13) & "	                		SET NOCOUNT ON;																				"
                SQL &= Chr(13) & "	                		BEGIN TRY																				"
                SQL &= Chr(13) & "	                		BEGIN TRAN TR_MANT_PROFORMA																				"
                SQL &= Chr(13) & "	                																						"
                SQL &= Chr(13) & "	                		IF	@MODO = 1																			"
                SQL &= Chr(13) & "	                		BEGIN																				"
                SQL &= Chr(13) & "	                			IF NOT EXISTS(SELECT *																			"
                SQL &= Chr(13) & "	                						  FROM PROFORMA_ENC_TMP																"
                SQL &= Chr(13) & "	                						  WHERE COD_CIA = @COD_CIA																"
                SQL &= Chr(13) & "	                                          AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "	                						  AND CODIGO = @CODIGO)																"
                SQL &= Chr(13) & "	                			BEGIN																			"
                SQL &= Chr(13) & "	                				INSERT INTO PROFORMA_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION)																		"
                SQL &= Chr(13) & "	                				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, @CEDULA, @FECHA, GETDATE(), @COD_USUARIO, @COD_MONEDA, @TIPO_CAMBIO, @PLAZO, @FORMA_PAGO,@DESCRIPCION																		"
                SQL &= Chr(13) & "	                																						"
                SQL &= Chr(13) & "	                				INSERT INTO PROFORMA_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																		"
                SQL &= Chr(13) & "	                				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA, @POR_EXO, @EXONERACION																		"
                SQL &= Chr(13) & "	                				FROM PROFORMA_DET_TMP																		"
                SQL &= Chr(13) & "	                				WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "	                              And COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "	                				AND CODIGO = @CODIGO 																		"
                SQL &= Chr(13) & "	                			END																			"
                SQL &= Chr(13) & "	                			ELSE																			"
                SQL &= Chr(13) & "	                			BEGIN																			"
                SQL &= Chr(13) & "	                				IF EXISTS(SELECT COD_PROD FROM PROFORMA_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)																		"
                SQL &= Chr(13) & "	                				BEGIN																		"
                SQL &= Chr(13) & "	                					UPDATE PROFORMA_DET_TMP																	"
                SQL &= Chr(13) & "	                					SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO																	"
                SQL &= Chr(13) & "	                					   ,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL																	"
                SQL &= Chr(13) & "										   ,POR_EXONERACION = @POR_EXO, EXONERACION = @EXONERACION													"
                SQL &= Chr(13) & "	                					WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "	                					AND COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "										AND CODIGO = @CODIGO													"
                SQL &= Chr(13) & "	                					AND COD_PROD = @COD_PROD																	"
                SQL &= Chr(13) & "	                				END																		"
                SQL &= Chr(13) & "	                				ELSE																		"
                SQL &= Chr(13) & "	                				BEGIN																		"
                SQL &= Chr(13) & "	                					INSERT INTO PROFORMA_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																	"
                SQL &= Chr(13) & "	                					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA, @POR_EXO, @EXONERACION																	"
                SQL &= Chr(13) & "	                					FROM PROFORMA_DET_TMP																	"
                SQL &= Chr(13) & "	                					WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "	                					AND COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "	                                  And CODIGO = @CODIGO																						"
                SQL &= Chr(13) & "	                				END																		"
                SQL &= Chr(13) & "	                			END																			"
                SQL &= Chr(13) & "	                		END																				"
                SQL &= Chr(13) & "	                		ELSE IF @MODO = 3																				"
                SQL &= Chr(13) & "	                		BEGIN																				"
                SQL &= Chr(13) & "	                				IF EXISTS(SELECT COD_PROD FROM PROFORMA_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)																		"
                SQL &= Chr(13) & "	                				BEGIN																		"
                SQL &= Chr(13) & "	                					UPDATE PROFORMA_DET_TMP																	"
                SQL &= Chr(13) & "	                					SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO																	"
                SQL &= Chr(13) & "	                					   ,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL																	"
                SQL &= Chr(13) & "										   ,POR_EXONERACION = @POR_EXO, EXONERACION = @EXONERACION													"
                SQL &= Chr(13) & "	                					WHERE COD_CIA = @COD_CIA 																	"
                SQL &= Chr(13) & "										AND COD_SUCUR = @COD_SUCUR													"
                SQL &= Chr(13) & "	                					AND CODIGO = @CODIGO 																	"
                SQL &= Chr(13) & "										AND COD_PROD = @COD_PROD													"
                SQL &= Chr(13) & "	                				END																		"
                SQL &= Chr(13) & "	                				ELSE 																		"
                SQL &= Chr(13) & "	                				BEGIN																		"
                SQL &= Chr(13) & "	                					INSERT INTO PROFORMA_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																	"
                SQL &= Chr(13) & "	                					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA, @POR_EXO, @EXONERACION																	"
                SQL &= Chr(13) & "	                					FROM PROFORMA_DET_TMP																	"
                SQL &= Chr(13) & "	                					WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "	                                  And COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "	                					AND CODIGO = @CODIGO																	"
                SQL &= Chr(13) & "	                				END																		"
                SQL &= Chr(13) & "	                		END																				"
                SQL &= Chr(13) & "	                		COMMIT TRAN TR_MANT_PROFORMA	 																			"
                SQL &= Chr(13) & "	                		END TRY																				"
                SQL &= Chr(13) & "	                		BEGIN CATCH 																				"
                SQL &= Chr(13) & "	                	 		ROLLBACK TRAN																			"
                SQL &= Chr(13) & "	                	 		DECLARE @MENSAJE VARCHAR(500)																			"
                SQL &= Chr(13) & "	                	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																			"
                SQL &= Chr(13) & "	                	 		RAISERROR( @MENSAJE, 16, 1)																			"
                SQL &= Chr(13) & "	                		END CATCH																				"
                SQL &= Chr(13) & "	                	END																					"


                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_IMPRIME_PROFORMA()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_IMPRIME_PROFORMA", "2020-11-12") Then
                ELIMINA_PROCEDIMIENTO("USP_IMPRIME_PROFORMA")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_IMPRIME_PROFORMA] 																						"
                SQL &= Chr(13) & "			    @COD_CIA VARCHAR(3),																				"
                SQL &= Chr(13) & "				@COD_SUCUR VARCHAR(3),																			"
                SQL &= Chr(13) & "				@NUMERO_DOC INTEGER,																			"
                SQL &= Chr(13) & "				@TIPO_MOV VARCHAR(2)																			"
                SQL &= Chr(13) & "			AS   																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "					SELECT 																		"
                SQL &= Chr(13) & "					/*INFORMACIÓN GENERAL SUCURSAL*/																		"
                SQL &= Chr(13) & "					SUCUR.COD_CIA,CIA.CEDULA,CONVERT(IMAGE,CIA.LOGO) AS LOGO,																		"
                SQL &= Chr(13) & "					CASE WHEN CIA.TIPO_CEDULA='F' THEN 'Física' WHEN CIA.TIPO_CEDULA='F' THEN 'Jurídica' WHEN CIA.TIPO_CEDULA='D' THEN 'Dimex'WHEN CIA.TIPO_CEDULA='D' THEN 'Nite' END AS TIPO_CEDULA,"
                SQL &= Chr(13) & "					SUCUR.COD_SUCUR,CIA.NOMBRE,SUCUR.DIRECCION,SUCUR.CORREO,SUCUR.TELEFONO,																		"
                SQL &= Chr(13) & "					/*INFORMACIÓN GENERAL CLIENTE*/																		"
                SQL &= Chr(13) & "					CLI.NOMBRE+' '+CLI.APELLIDO1+' '+CLI.APELLIDO2 AS NOMBRE,CLI.CEDULA AS CEDULA_CLIENTE,CLI.CORREO,																		"
                SQL &= Chr(13) & "					/*INFORMACIÓN DEL ENCABEZADO DEL DOCUMENTO*/																		"
                SQL &= Chr(13) & "					DOC.NUMERO_DOC,																		"
                SQL &= Chr(13) & "					CASE WHEN DOC.COD_MONEDA='L' THEN 'Local' WHEN DOC.COD_MONEDA='D' THEN 'Dólares' END AS COD_MONEDA ,																		"
                SQL &= Chr(13) & "					CASE WHEN DOC.COD_MONEDA='L' THEN '₡' WHEN DOC.COD_MONEDA='D' THEN '$' END AS SIMBOLO ,																		"
                SQL &= Chr(13) & "					CASE WHEN DOC.FORMA_PAGO ='EF' THEN 'Efectivo' WHEN DOC.FORMA_PAGO ='T' THEN 'Tarjeta' END AS FORMA_PAGO,																		"
                SQL &= Chr(13) & "					CASE WHEN DOC.TIPO_MOV ='FC' THEN 'Factura Contado' WHEN DOC.TIPO_MOV ='FA' THEN 'Factura Crédito' END AS TIPO_MOV,																		"
                SQL &= Chr(13) & "					DOC.DESCRIPCION,																		"
                SQL &= Chr(13) & "					DOC.PLAZO,DOC.TIPO_CAMBIO,FORMAT(DOC.FECHA_INC,'dd/MM/yyyy hh:mm:ss') AS FECHA_INC,																		"
                SQL &= Chr(13) & "					/*INFORMACIÓN DEL ENCABEZADO DEL DETALLE*/																		"
                SQL &= Chr(13) & "					DET.LINEA,PROD.DESCRIPCION,DET.COD_PROD,DET.COD_UNIDAD,DET.CANTIDAD,DET.PRECIO,DET.SUBTOTAL,DET.DESCUENTO,DET.IMPUESTO,DET.TOTAL																		"
                SQL &= Chr(13) & "					FROM PROFORMA_ENC AS DOC																		"
                SQL &= Chr(13) & "					INNER JOIN PROFORMA_DET AS DET																		"
                SQL &= Chr(13) & "						ON DOC.COD_CIA = DET.COD_CIA																	"
                SQL &= Chr(13) & "						AND DOC.COD_SUCUR = DET.COD_SUCUR																	"
                SQL &= Chr(13) & "						AND DOC.NUMERO_DOC = DET.NUMERO_DOC																	"
                SQL &= Chr(13) & "						AND DOC.TIPO_MOV = DET.TIPO_MOV																	"
                SQL &= Chr(13) & "					INNER JOIN COMPANIA AS CIA																		"
                SQL &= Chr(13) & "						ON DOC.COD_CIA = CIA.COD_CIA																	"
                SQL &= Chr(13) & "					INNER JOIN SUCURSAL AS SUCUR																		"
                SQL &= Chr(13) & "						ON SUCUR.COD_CIA = DOC.COD_CIA																	"
                SQL &= Chr(13) & "						AND SUCUR.COD_SUCUR = DOC.COD_SUCUR																	"
                SQL &= Chr(13) & "					INNER JOIN CLIENTE AS CLI																		"
                SQL &= Chr(13) & "						ON CLI.COD_CIA = DOC.COD_CIA																	"
                SQL &= Chr(13) & "						AND CLI.CEDULA = DOC.CEDULA																	"
                SQL &= Chr(13) & "					INNER JOIN PRODUCTO AS PROD																		"
                SQL &= Chr(13) & "						ON DET.COD_CIA = PROD.COD_CIA																	"
                SQL &= Chr(13) & "						AND DET.COD_SUCUR = PROD.COD_SUCUR																	"
                SQL &= Chr(13) & "						AND DET.COD_PROD = PROD.COD_PROD																	"
                SQL &= Chr(13) & "					WHERE DOC.COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "					AND DOC.COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "					AND DOC.NUMERO_DOC = @NUMERO_DOC																		"
                SQL &= Chr(13) & "					AND DOC.TIPO_MOV = @TIPO_MOV																		"
                SQL &= Chr(13) & "					ORDER BY DET.LINEA																		"
                SQL &= Chr(13) & "			END																				"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_PROFORMA_TMP_A_REAL()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_PROFORMA_TMP_A_REAL", "2020-11-14") Then
                ELIMINA_PROCEDIMIENTO("USP_PROFORMA_TMP_A_REAL")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_PROFORMA_TMP_A_REAL] 		"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)		"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)						"
                SQL &= Chr(13) & "		,@TIPO_MOV VARCHAR(2)						"
                SQL &= Chr(13) & "		,@CODIGO VARCHAR(20)										"
                SQL &= Chr(13) & "		,@NUMERO_DOC INTEGER = 0									"
                SQL &= Chr(13) & "		AS																			"
                SQL &= Chr(13) & "		BEGIN																		"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																			"
                SQL &= Chr(13) & "			BEGIN TRY																				"
                SQL &= Chr(13) & "			BEGIN TRAN TR_PROFORMA_TMP_A_REAL																		"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			DECLARE @CEDULA VARCHAR(25)																		"
                SQL &= Chr(13) & "			DECLARE @FECHA_DOC AS DATETIME																	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			IF NOT EXISTS(SELECT TMP.*														"
                SQL &= Chr(13) & "				FROM PROFORMA_ENC_TMP AS TMP																"
                SQL &= Chr(13) & "				INNER JOIN PROFORMA_DET_TMP AS DET	 														"
                SQL &= Chr(13) & "		            ON DET.COD_CIA = TMP.COD_CIA 																			"
                SQL &= Chr(13) & "		            AND DET.COD_SUCUR = TMP.COD_SUCUR 																		"
                SQL &= Chr(13) & "		            AND DET.CODIGO = TMP.CODIGO 																					"
                SQL &= Chr(13) & "		            AND DET.TIPO_MOV = TMP.TIPO_MOV																					"
                SQL &= Chr(13) & "				WHERE TMP.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND TMP.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TMP.TIPO_MOV = 	@TIPO_MOV																		"
                SQL &= Chr(13) & "				AND TMP.CODIGO = @CODIGO) AND @TIPO_MOV IN ('FA', 'FC')												"
                SQL &= Chr(13) & "				BEGIN																			"
                SQL &= Chr(13) & "					RAISERROR('El código de factura no existe en los temporales', 17, 1)		"
                SQL &= Chr(13) & "				END																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			IF @NUMERO_DOC > 0																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				UPDATE PROFORMA_ENC																			"
                SQL &= Chr(13) & "				SET MONTO = T1.SUBTOTAL																		"
                SQL &= Chr(13) & "				,IMPUESTO = T1.IMPUESTO																			"
                SQL &= Chr(13) & "				,SALDO = T1.SALDO																			"
                SQL &= Chr(13) & "				,COD_MONEDA = T1.COD_MONEDA																			"
                SQL &= Chr(13) & "				,TIPO_CAMBIO = T1.TIPO_CAMBIO																		"
                SQL &= Chr(13) & "				,PLAZO = T1.PLAZO																			"
                SQL &= Chr(13) & "				,FORMA_PAGO = T1.FORMA_PAGO																	"
                SQL &= Chr(13) & "				,DESCRIPCION = T1.DESCRIPCION																			"
                SQL &= Chr(13) & "				,TIPO_NOTA = T1.TIPO_NOTA																			"
                SQL &= Chr(13) & "				FROM( 																			"
                SQL &= Chr(13) & "				SELECT SUM(DET.SUBTOTAL) AS SUBTOTAL											"
                SQL &= Chr(13) & "				,SUM(DET.IMPUESTO) AS IMPUESTO																	"
                SQL &= Chr(13) & "				,SUM(DET.TOTAL) AS SALDO																		"
                SQL &= Chr(13) & "				,COD_MONEDA																			"
                SQL &= Chr(13) & "				,TIPO_CAMBIO																		"
                SQL &= Chr(13) & "				,PLAZO																			"
                SQL &= Chr(13) & "				,FORMA_PAGO																		"
                SQL &= Chr(13) & "				,DESCRIPCION																			"
                SQL &= Chr(13) & "				,TIPO_NOTA																			"
                SQL &= Chr(13) & "				FROM PROFORMA_ENC_TMP AS TMP																		"
                SQL &= Chr(13) & "				INNER JOIN PROFORMA_DET_TMP AS DET	 																"
                SQL &= Chr(13) & "		            ON DET.COD_CIA = TMP.COD_CIA 																					"
                SQL &= Chr(13) & "		            AND DET.COD_SUCUR = TMP.COD_SUCUR 																				"
                SQL &= Chr(13) & "		            AND DET.CODIGO = TMP.CODIGO 																					"
                SQL &= Chr(13) & "		            AND DET.TIPO_MOV = TMP.TIPO_MOV																					"
                SQL &= Chr(13) & "				WHERE TMP.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND TMP.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TMP.TIPO_MOV = @TIPO_MOV																			"
                SQL &= Chr(13) & "				AND TMP.CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "				GROUP BY COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION,TIPO_NOTA												"
                SQL &= Chr(13) & "				) AS T1																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				DELETE FROM PROFORMA_DET													"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																	"
                SQL &= Chr(13) & "				AND TIPO_MOV = @TIPO_MOV																			"
                SQL &= Chr(13) & "				AND NUMERO_DOC = @NUMERO_DOC																		"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				INSERT INTO PROFORMA_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)					"
                SQL &= Chr(13) & "				SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION			"
                SQL &= Chr(13) & "				FROM PROFORMA_DET_TMP																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				DELETE FROM PROFORMA_ENC_TMP WHERE CODIGO = @CODIGO											"
                SQL &= Chr(13) & "		        DELETE FROM PROFORMA_DET_TMP WHERE CODIGO = @CODIGO											"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC AS Documento "
                SQL &= Chr(13) & "			END 																				"
                SQL &= Chr(13) & "			ELSE																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "			IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'												"
                SQL &= Chr(13) & "				BEGIN																			"
                SQL &= Chr(13) & "					SELECT @NUMERO_DOC =  ISNULL(MAX(NUMERO_DOC), 0) + 1 						"
                SQL &= Chr(13) & "					FROM PROFORMA_ENC																		"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA																"
                SQL &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "					AND TIPO_MOV <> 'NC' 																		"
                SQL &= Chr(13) & "				END																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'														"
                SQL &= Chr(13) & "				BEGIN																			"
                SQL &= Chr(13) & "				/*INGRESA EL ENCABEZADO*/																		"
                SQL &= Chr(13) & "				INSERT INTO PROFORMA_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)		"
                SQL &= Chr(13) & "				SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO, SUM(DET.SUBTOTAL), SUM(DET.IMPUESTO), SUM(DET.TOTAL) ,TMP.COD_MONEDA									"
                SQL &= Chr(13) & "				,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION,TMP.TIPO_NOTA																			"
                SQL &= Chr(13) & "				FROM PROFORMA_ENC_TMP AS TMP																			"
                SQL &= Chr(13) & "				INNER JOIN PROFORMA_DET_TMP AS DET	 																	"
                SQL &= Chr(13) & "		            ON DET.COD_CIA = TMP.COD_CIA 																					"
                SQL &= Chr(13) & "		            AND DET.COD_SUCUR = TMP.COD_SUCUR 																				"
                SQL &= Chr(13) & "		            AND DET.CODIGO = TMP.CODIGO 																					"
                SQL &= Chr(13) & "		            AND DET.TIPO_MOV = TMP.TIPO_MOV																					"
                SQL &= Chr(13) & "				WHERE TMP.COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND TMP.COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TMP.TIPO_MOV = 	@TIPO_MOV																		"
                SQL &= Chr(13) & "				AND TMP.CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "				GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO,TMP.DESCRIPCION,TMP.TIPO_NOTA	"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				/*INGRESA EL DETALLE*/																		"
                SQL &= Chr(13) & "				INSERT INTO PROFORMA_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)	 "
                SQL &= Chr(13) & "				SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION"
                SQL &= Chr(13) & "				FROM PROFORMA_DET_TMP																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND CODIGO = @CODIGO																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				DELETE FROM PROFORMA_ENC_TMP WHERE CODIGO = @CODIGO											"
                SQL &= Chr(13) & "		        DELETE FROM PROFORMA_DET_TMP WHERE CODIGO = @CODIGO											"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				SELECT @FECHA_DOC = FECHA, @CEDULA = CEDULA									"
                SQL &= Chr(13) & "				FROM PROFORMA_ENC																			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																	"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "				AND TIPO_MOV = 	@TIPO_MOV 																		"
                SQL &= Chr(13) & "				AND NUMERO_DOC = @NUMERO_DOC																			"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC AS Documento																"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "				END																			"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			COMMIT TRAN TR_PROFORMA_TMP_A_REAL																"
                SQL &= Chr(13) & "			END TRY																				"
                SQL &= Chr(13) & "			BEGIN CATCH 																				"
                SQL &= Chr(13) & "		 		ROLLBACK TRAN																			"
                SQL &= Chr(13) & "		 		DECLARE @MENSAJE VARCHAR(500)																			"
                SQL &= Chr(13) & "		 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																	"
                SQL &= Chr(13) & "		 		RAISERROR( @MENSAJE, 16, 1)																			"
                SQL &= Chr(13) & "			END CATCH																				"
                SQL &= Chr(13) & "		END																					"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_PROFORMA_A_FACTURA()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_PROFORMA_A_FACTURA", "2021-06-20") Then
                ELIMINA_PROCEDIMIENTO("USP_PROFORMA_A_FACTURA")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_PROFORMA_A_FACTURA] 																									"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																								"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																								"
                SQL &= Chr(13) & "		,@TIPO_MOV VARCHAR(2)																								"
                SQL &= Chr(13) & "		,@NUMERO_DOC_PROF INT																								"
                SQL &= Chr(13) & "		AS																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																							"
                SQL &= Chr(13) & "			BEGIN TRY																							"
                SQL &= Chr(13) & "			BEGIN TRAN TR_PROFORMA_A_FACTURA																							"
                SQL &= Chr(13) & "			DECLARE @NUMERO_DOC INTEGER																							"
                SQL &= Chr(13) & "			DECLARE @CEDULA VARCHAR(25)																							"
                SQL &= Chr(13) & "			DECLARE @FECHA_DOC AS DATETIME																							"
                SQL &= Chr(13) & "			DECLARE @VENTA_NEGATIVA CHAR(1)																							"
                SQL &= Chr(13) & "			DECLARE @MFINAL VARCHAR(255)																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'																							"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "				SET @VENTA_NEGATIVA = (SELECT ISNULL(IND_PERMITE_VENTAS_NEGATIVO, 'N') FROM SUCURSAL_INDICADORES WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR)																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				IF @VENTA_NEGATIVA = 'N' AND EXISTS(																						"
                SQL &= Chr(13) & "											SELECT T1.DESCRIPCION															"
                SQL &= Chr(13) & "											FROM PROFORMA_DET AS DET															"
                SQL &= Chr(13) & "											INNER JOIN (															"
                SQL &= Chr(13) & "											SELECT P.COD_CIA, P.COD_SUCUR, P.COD_PROD, P.DESCRIPCION, ISNULL(SUM(DET.CANTIDAD), 0) AS CANTIDAD  															"
                SQL &= Chr(13) & "											FROM PRODUCTO AS P															"
                SQL &= Chr(13) & "											LEFT JOIN INVENTARIO_MOV_DET AS DET															"
                SQL &= Chr(13) & "												ON DET.COD_CIA = P.COD_CIA														"
                SQL &= Chr(13) & "												AND DET.COD_SUCUR = P.COD_SUCUR														"
                SQL &= Chr(13) & "												AND DET.COD_PROD = P.COD_PROD														"
                SQL &= Chr(13) & "											GROUP BY P.COD_CIA, P.COD_SUCUR, P.COD_PROD, P.DESCRIPCION															"
                SQL &= Chr(13) & "											)AS T1															"
                SQL &= Chr(13) & "											ON T1.COD_CIA = DET.COD_CIA															"
                SQL &= Chr(13) & "											AND T1.COD_SUCUR = DET.COD_SUCUR															"
                SQL &= Chr(13) & "											AND T1.COD_PROD = DET.COD_PROD															"
                SQL &= Chr(13) & "											WHERE DET.COD_CIA = @COD_CIA															"
                SQL &= Chr(13) & "											AND DET.COD_SUCUR = @COD_SUCUR															"
                SQL &= Chr(13) & "											AND NUMERO_DOC = @NUMERO_DOC_PROF															"
                SQL &= Chr(13) & "											AND DET.CANTIDAD > T1.CANTIDAD															"
                SQL &= Chr(13) & "				)																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "					SET @MFINAL = (SELECT 'El producto: ' + P.DESCRIPCION + ' no posee suficiente inventario para ser facturado, el saldo actual es: '	+ ISNULL(CONVERT(VARCHAR(10), T1.CANTIDAD), '0')																			"
                SQL &= Chr(13) & "					FROM PROFORMA_DET AS DET																					"
                SQL &= Chr(13) & "					LEFT JOIN (																					"
                SQL &= Chr(13) & "					    SELECT P.COD_CIA, P.COD_SUCUR, P.COD_PROD, P.DESCRIPCION, ISNULL(SUM(DET.CANTIDAD), 0) AS CANTIDAD, DET.ESTANTE, DET.FILA, DET.COLUMNA  																					"
                SQL &= Chr(13) & "					    FROM PRODUCTO AS P																					"
                SQL &= Chr(13) & "					    LEFT JOIN INVENTARIO_MOV_DET AS DET																					"
                SQL &= Chr(13) & "						    ON DET.COD_CIA = P.COD_CIA																				"
                SQL &= Chr(13) & "						    AND DET.COD_SUCUR = P.COD_SUCUR																				"
                SQL &= Chr(13) & "						    AND DET.COD_PROD = P.COD_PROD																				"
                SQL &= Chr(13) & "					    GROUP BY P.COD_CIA, P.COD_SUCUR, P.COD_PROD, P.DESCRIPCION, DET.ESTANTE, DET.FILA, DET.COLUMNA																					"
                SQL &= Chr(13) & "					)AS T1																					"
                SQL &= Chr(13) & "					    ON T1.COD_CIA = DET.COD_CIA																					"
                SQL &= Chr(13) & "					    AND T1.COD_SUCUR = DET.COD_SUCUR																					"
                SQL &= Chr(13) & "					    AND T1.COD_PROD = DET.COD_PROD																					"
                SQL &= Chr(13) & "	                    AND T1.ESTANTE = DET.ESTANTE"
                SQL &= Chr(13) & "	                    AND T1.FILA = DET.FILA"
                SQL &= Chr(13) & "	                    AND T1.COLUMNA = DET.COLUMNA"
                SQL &= Chr(13) & "                  INNER JOIN PRODUCTO AS P"
                SQL &= Chr(13) & "                  	ON P.COD_CIA = DET.COD_CIA"
                SQL &= Chr(13) & "                  	AND P.COD_SUCUR = DET.COD_SUCUR"
                SQL &= Chr(13) & "                  	AND P.COD_PROD = DET.COD_PROD"
                SQL &= Chr(13) & "					WHERE DET.COD_CIA = @COD_CIA																					"
                SQL &= Chr(13) & "					AND DET.COD_SUCUR = @COD_SUCUR																					"
                SQL &= Chr(13) & "					AND NUMERO_DOC = @NUMERO_DOC_PROF																					"
                SQL &= Chr(13) & "					AND ((DET.CANTIDAD > T1.CANTIDAD) OR T1.CANTIDAD IS NULL)																					"
                SQL &= Chr(13) & "					)																					"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "					RAISERROR(@MFINAL, 17, 1)																					"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "					SELECT @NUMERO_DOC =  ISNULL(MAX(NUMERO_DOC), 0) + 1 																					"
                SQL &= Chr(13) & "					FROM DOCUMENTO_ENC																					"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA																					"
                SQL &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR																					"
                SQL &= Chr(13) & "					AND TIPO_MOV <> 'NC' 																					"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "				/*INGRESA EL ENCABEZADO*/																						"
                SQL &= Chr(13) & "				INSERT INTO DOCUMENTO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,ESTADO,DESCRIPCION,TIPO_NOTA)																						"
                SQL &= Chr(13) & "				SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,CONVERT(VARCHAR(10), GETDATE(), 126),GETDATE(),TMP.COD_USUARIO, SUM(DET.SUBTOTAL), SUM(DET.IMPUESTO), SUM(DET.TOTAL) ,TMP.COD_MONEDA																						"
                SQL &= Chr(13) & "				,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION,TMP.TIPO_NOTA																						"
                SQL &= Chr(13) & "				FROM PROFORMA_ENC AS TMP																						"
                SQL &= Chr(13) & "				INNER JOIN PROFORMA_DET AS DET	 																					"
                SQL &= Chr(13) & "		            ON DET.COD_CIA = TMP.COD_CIA 																								"
                SQL &= Chr(13) & "		            AND DET.COD_SUCUR = TMP.COD_SUCUR 																								"
                SQL &= Chr(13) & "		            AND DET.NUMERO_DOC = TMP.NUMERO_DOC 																								"
                SQL &= Chr(13) & "		            AND DET.TIPO_MOV = TMP.TIPO_MOV																								"
                SQL &= Chr(13) & "				WHERE TMP.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND TMP.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TMP.TIPO_MOV = 	@TIPO_MOV																					"
                SQL &= Chr(13) & "				AND TMP.NUMERO_DOC = @NUMERO_DOC_PROF																						"
                SQL &= Chr(13) & "				GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO,TMP.DESCRIPCION,TMP.TIPO_NOTA																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				/*INGRESA EL DETALLE*/																						"
                SQL &= Chr(13) & "				INSERT INTO DOCUMENTO_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																						"
                SQL &= Chr(13) & "				SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION																						"
                SQL &= Chr(13) & "				FROM PROFORMA_DET																						"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "				AND NUMERO_DOC = @NUMERO_DOC_PROF																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT @FECHA_DOC = FECHA, @CEDULA = CEDULA																						"
                SQL &= Chr(13) & "				FROM DOCUMENTO_ENC																						"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TIPO_MOV = 	@TIPO_MOV 																					"
                SQL &= Chr(13) & "				AND NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				EXEC USP_INGRESA_DOCUMENTO_ELECTRONICO 																						"
                SQL &= Chr(13) & "				 @COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				,@COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				,@NUMERO_DOC = 	@NUMERO_DOC																					"
                SQL &= Chr(13) & "				,@TIPO_MOV  = @TIPO_MOV																						"
                SQL &= Chr(13) & "				,@FECHA = @FECHA_DOC 																						"
                SQL &= Chr(13) & "				,@CEDULA = @CEDULA																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				UPDATE PROFORMA_ENC																						"
                SQL &= Chr(13) & "				SET NUM_FACTURA = @NUMERO_DOC																						"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TIPO_MOV = 	@TIPO_MOV 																					"
                SQL &= Chr(13) & "				AND NUMERO_DOC = @NUMERO_DOC_PROF																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC AS Documento																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			COMMIT TRAN TR_PROFORMA_A_FACTURA																							"
                SQL &= Chr(13) & "			END TRY																							"
                SQL &= Chr(13) & "			BEGIN CATCH 																							"
                SQL &= Chr(13) & "		 		ROLLBACK TRAN																						"
                SQL &= Chr(13) & "		 		DECLARE @MENSAJE VARCHAR(500)																						"
                SQL &= Chr(13) & "		 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																						"
                SQL &= Chr(13) & "		 		RAISERROR( @MENSAJE, 16, 1)																						"
                SQL &= Chr(13) & "			END CATCH																							"
                SQL &= Chr(13) & "		END																								"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_ImprimeFElectronica_V_4_3()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_ImprimeFElectronica_V_4_3", "2020-12-20") Then
                ELIMINA_PROCEDIMIENTO("USP_ImprimeFElectronica_V_4_3")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_ImprimeFElectronica_V_4_3](																																"
                SQL &= Chr(13) & "								@COD_CIA VARCHAR(3),																									"
                SQL &= Chr(13) & "								@COD_SUCUR VARCHAR(3),																									"
                SQL &= Chr(13) & "								@TIPO_MOV CHAR(2), 																									"
                SQL &= Chr(13) & "								@NUMERO_DOC INTEGER)																									"
                SQL &= Chr(13) & "								AS 																									"
                SQL &= Chr(13) & "								BEGIN																									"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "								DECLARE @MEDIO_PAGO VARCHAR(2)																									"
                SQL &= Chr(13) & "								SET @MEDIO_PAGO= (SELECT ISNULL(FORMA_PAGO,'EF') FROM DOCUMENTO_ENC WHERE COD_CIA=@COD_CIA AND COD_SUCUR = @COD_SUCUR AND TIPO_MOV=@TIPO_MOV AND NUMERO_DOC=@NUMERO_DOC)																									"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "								DECLARE @TotalServGravados MONEY,@TotalServExentos MONEY,@TotalServExonerado MONEY,@TotalMercanciasGravadas MONEY,@TotalMercanciasExentas MONEY,@TotalMercExonerada MONEY,																									"
                SQL &= Chr(13) & "								@TotalGravado MONEY,@TotalExento MONEY,@TotalExonerado MONEY,@TotalVenta MONEY,@TotalDescuentos MONEY,@TotalVentaNeta MONEY,@TotalImpuesto MONEY,@TotalIVADevuelto MONEY,																									"
                SQL &= Chr(13) & "								@TotalOtrosCargos MONEY,@TotalComprobante MONEY																									"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "								/* TOTALES */																									"
                SQL &= Chr(13) & "								IF @TIPO_MOV='NC' 																									"
                SQL &= Chr(13) & "									BEGIN 																								"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "										IF EXISTS( SELECT TOP 1 DET.COD_CIA																							"
                SQL &= Chr(13) & "											FROM DOCUMENTO_ENC AS DOC																						"
                SQL &= Chr(13) & "											INNER JOIN DOCUMENTO_AFEC_DET_PRODUCTOS AS DET																						"
                SQL &= Chr(13) & "												ON DOC.COD_CIA = DET.COD_CIA																					"
                SQL &= Chr(13) & "												AND DOC.COD_SUCUR = DET.COD_SUCUR																					"
                SQL &= Chr(13) & "												AND DOC.TIPO_MOV = DET.TIPO_MOV																					"
                SQL &= Chr(13) & "												AND DOC.NUMERO_DOC = DET.NUMERO_DOC 																					"
                SQL &= Chr(13) & "											WHERE DET.COD_CIA=@COD_CIA																						"
                SQL &= Chr(13) & "											AND DET.COD_SUCUR=@COD_SUCUR																						"
                SQL &= Chr(13) & "											AND DET.NUMERO_DOC=@NUMERO_DOC																						"
                SQL &= Chr(13) & "											AND DET.TIPO_MOV=@TIPO_MOV																						"
                SQL &= Chr(13) & "										)																							"
                SQL &= Chr(13) & "										BEGIN																							"
                SQL &= Chr(13) & "											SELECT                                                                              																						"
                SQL &= Chr(13) & "													@TotalServGravados=      0,																				"
                SQL &= Chr(13) & "													@TotalServExentos=       0,																				"
                SQL &= Chr(13) & "													@TotalServExonerado=     0,																				"
                SQL &= Chr(13) & "													@TotalMercanciasGravadas= SUM(CASE WHEN DET.POR_IMPUESTO>0 THEN DET.CANTIDAD * DET.PRECIO_UNITARIO ELSE 0 END),																				"
                SQL &= Chr(13) & "													@TotalMercanciasExentas= SUM(CASE WHEN DET.POR_IMPUESTO=0 THEN DET.CANTIDAD * DET.PRECIO_UNITARIO ELSE 0 END),																				"
                SQL &= Chr(13) & "													@TotalMercExonerada=     0,																				"
                SQL &= Chr(13) & "													@TotalGravado =		    ISNULL(@TotalServGravados+@TotalMercanciasGravadas,0),																		"
                SQL &= Chr(13) & "													@TotalExento =			ISNULL(@TotalServExentos+@TotalMercanciasExentas,0),																	"
                SQL &= Chr(13) & "													@TotalExonerado =		ISNULL(@TotalServExonerado+@TotalMercExonerada,0),																		"
                SQL &= Chr(13) & "													@TotalVenta =			ISNULL(@TotalGravado+@TotalExento+@TotalExonerado,0),																	"
                SQL &= Chr(13) & "													@TotalDescuentos =		ISNULL(SUM(((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100),0),																		"
                SQL &= Chr(13) & "													@TotalVentaNeta =		ISNULL(@TotalVenta-@TotalDescuentos,0),																		"
                SQL &= Chr(13) & "													@TotalImpuesto =		ISNULL(SUM((((DET.CANTIDAD * DET.PRECIO_UNITARIO) - (((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100))*DET.POR_IMPUESTO)/100),0),																		"
                SQL &= Chr(13) & "													@TotalIVADevuelto=		0,																		"
                SQL &= Chr(13) & "													@TotalOtrosCargos=		0,																		"
                SQL &= Chr(13) & "													@TotalComprobante=       ISNULL((@TotalVentaNeta+@TotalImpuesto+@TotalOtrosCargos)-@TotalIVADevuelto,0)																				"
                SQL &= Chr(13) & "											FROM DOCUMENTO_ENC AS DOC																						"
                SQL &= Chr(13) & "											INNER JOIN DOCUMENTO_AFEC_DET_PRODUCTOS AS DET																						"
                SQL &= Chr(13) & "												ON DOC.COD_CIA = DET.COD_CIA																					"
                SQL &= Chr(13) & "												AND DOC.COD_SUCUR = DET.COD_SUCUR																					"
                SQL &= Chr(13) & "												AND DOC.TIPO_MOV = DET.TIPO_MOV																					"
                SQL &= Chr(13) & "												AND DOC.NUMERO_DOC = DET.NUMERO_DOC 																					"
                SQL &= Chr(13) & "											WHERE DET.COD_CIA=@COD_CIA																						"
                SQL &= Chr(13) & "												AND DET.COD_SUCUR=@COD_SUCUR																					"
                SQL &= Chr(13) & "												AND DET.NUMERO_DOC=@NUMERO_DOC																					"
                SQL &= Chr(13) & "												AND DET.TIPO_MOV=@TIPO_MOV																					"
                SQL &= Chr(13) & "										END																							"
                SQL &= Chr(13) & "										ELSE																							"
                SQL &= Chr(13) & "										BEGIN																							"
                SQL &= Chr(13) & "											SELECT                                                                              																						"
                SQL &= Chr(13) & "													@TotalServGravados=      0,																				"
                SQL &= Chr(13) & "													@TotalServExentos=       0,																				"
                SQL &= Chr(13) & "													@TotalServExonerado=     0,																				"
                SQL &= Chr(13) & "													@TotalMercanciasGravadas= SUM(CASE WHEN IMPUESTO>0 THEN MONTO ELSE 0 END),																				"
                SQL &= Chr(13) & "													@TotalMercanciasExentas=  SUM(CASE WHEN IMPUESTO=0 THEN MONTO ELSE 0 END),																				"
                SQL &= Chr(13) & "													@TotalMercExonerada=     0,																				"
                SQL &= Chr(13) & "													@TotalGravado =		    ISNULL(@TotalServGravados+@TotalMercanciasGravadas,0),																		"
                SQL &= Chr(13) & "													@TotalExento =			ISNULL(@TotalServExentos+@TotalMercanciasExentas,0),																	"
                SQL &= Chr(13) & "													@TotalExonerado =		ISNULL(@TotalServExonerado+@TotalMercExonerada,0),																		"
                SQL &= Chr(13) & "													@TotalVenta =			ISNULL(@TotalGravado+@TotalExento+@TotalExonerado,0),																	"
                SQL &= Chr(13) & "													@TotalDescuentos =		0,																		"
                SQL &= Chr(13) & "													@TotalVentaNeta =		ISNULL(@TotalVenta-@TotalDescuentos,0),																		"
                SQL &= Chr(13) & "													@TotalImpuesto =		SUM(ISNULL(IMPUESTO,0)),																		"
                SQL &= Chr(13) & "													@TotalIVADevuelto=		0,																		"
                SQL &= Chr(13) & "													@TotalOtrosCargos=		0,																		"
                SQL &= Chr(13) & "													@TotalComprobante=      ISNULL((@TotalVentaNeta+@TotalImpuesto+@TotalOtrosCargos)-@TotalIVADevuelto,0)																				"
                SQL &= Chr(13) & "											FROM DOCUMENTO_ENC																						"
                SQL &= Chr(13) & "											WHERE COD_CIA=@COD_CIA																						"
                SQL &= Chr(13) & "												AND COD_SUCUR=@COD_SUCUR																					"
                SQL &= Chr(13) & "												AND NUMERO_DOC=@NUMERO_DOC																					"
                SQL &= Chr(13) & "												AND TIPO_MOV=@TIPO_MOV																					"
                SQL &= Chr(13) & "										END																							"
                SQL &= Chr(13) & "									END																								"
                SQL &= Chr(13) & "								ELSE 																									"
                SQL &= Chr(13) & "									BEGIN																								"
                SQL &= Chr(13) & "										SELECT 	@TotalServGravados=		0,																				"
                SQL &= Chr(13) & "												@TotalServExentos=		0,																			"
                SQL &= Chr(13) & "												@TotalServExonerado=	0,																				"
                SQL &= Chr(13) & "												@TotalMercanciasGravadas= SUM(CASE WHEN DET.POR_IMPUESTO>0 AND DET.POR_EXONERACION = 0 THEN (CASE WHEN UPPER(DET.COD_UNIDAD) <> 'SP' THEN (DET.SUBTOTAL + DET.DESCUENTO) ELSE 0 END) ELSE 0 END),																					"
                SQL &= Chr(13) & "												@TotalMercanciasExentas=  SUM(CASE WHEN DET.POR_IMPUESTO=0 AND DET.POR_EXONERACION = 0 THEN (CASE WHEN UPPER(DET.COD_UNIDAD) <> 'SP' THEN (DET.SUBTOTAL + DET.DESCUENTO) ELSE 0 END) ELSE 0 END),																					"
                SQL &= Chr(13) & "												@TotalMercExonerada=	  ISNULL(SUM(CASE WHEN DET.POR_IMPUESTO>0 AND DET.POR_EXONERACION > 0 THEN (CASE WHEN UPPER(DET.COD_UNIDAD) <> 'SP' THEN (DET.SUBTOTAL + DET.DESCUENTO) ELSE 0 END) ELSE 0 END),0),																				"
                SQL &= Chr(13) & "												@TotalGravado =			ISNULL(@TotalServGravados+@TotalMercanciasGravadas,0),																		"
                SQL &= Chr(13) & "												@TotalExento =			ISNULL(@TotalServExentos+@TotalMercanciasExentas,0),																		"
                SQL &= Chr(13) & "												@TotalExonerado =		ISNULL(@TotalServExonerado+@TotalMercExonerada,0),																			"
                SQL &= Chr(13) & "												@TotalVenta =			ISNULL(@TotalGravado+@TotalExento+@TotalExonerado,0),																		"
                SQL &= Chr(13) & "												@TotalDescuentos =		ISNULL(SUM(DET.DESCUENTO),0),																			"
                SQL &= Chr(13) & "												@TotalVentaNeta =		ISNULL(@TotalVenta-@TotalDescuentos,0),																			"
                SQL &= Chr(13) & "												@TotalImpuesto =		ISNULL(SUM(CASE WHEN (DET.POR_IMPUESTO>0) THEN DET.IMPUESTO ELSE 0  END),0),																			"
                SQL &= Chr(13) & "												@TotalIVADevuelto=		0,																			"
                SQL &= Chr(13) & "												@TotalOtrosCargos=		0,																			"
                SQL &= Chr(13) & "												@TotalComprobante=       ISNULL((@TotalVentaNeta+@TotalImpuesto+@TotalOtrosCargos)-@TotalIVADevuelto,0)																					"
                SQL &= Chr(13) & "								 																									"
                SQL &= Chr(13) & "										FROM DOCUMENTO_DET as DET																							"
                SQL &= Chr(13) & "								 		WHERE DET.COD_CIA = @COD_CIA																							"
                SQL &= Chr(13) & "								 			AND DET.TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "								 			AND DET.NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "											AND DET.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "									END																								"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "							SELECT 																										"
                SQL &= Chr(13) & "								 	'4.30' as VersionDoc																								"
                SQL &= Chr(13) & "								 	,ELEC.CLAVE as Clave																								"
                SQL &= Chr(13) & "								 	,isnull(NULL,(SELECT TOP 1 COD_ACT FROM ACTIVIDAD_ECONOMICA WHERE COD_CIA=@COD_CIA ORDER BY PRINCIPAL DESC)) as CodigoActividad																								"
                SQL &= Chr(13) & "								 	,ELEC.NUMERO_DOC																								"
                SQL &= Chr(13) & "								 	,ELEC.TIPO_COMPROBANTE as TipoComprobante 																								"
                SQL &= Chr(13) & "								 	,ELEC.CONSECUTIVO as NumeroConsecutivo																								"
                SQL &= Chr(13) & "									,CONVERT(VARCHAR,GETDATE(),120) as FechaEmision																							 	"
                SQL &= Chr(13) & "									/*Emisor*/																								"
                SQL &= Chr(13) & "								 	,EMISOR.NOMBRE as NombreEmisor																								"
                SQL &= Chr(13) & "								 	,case EMISOR.TIPO_CEDULA when 'F' then '01' when 'J' then '02' when 'N' then '04' else '03' end as TipoIdentificacionEmisor																								"
                SQL &= Chr(13) & "								 	,substring(EMISOR.CEDULA,1,12) as IdentificacionEmisor																								"
                SQL &= Chr(13) & "								 	,ISNULL(SUCUR.NOMBRE,'') as NombreComercialEmisor																								"
                SQL &= Chr(13) & "								 	,isnull(EMISOR.COD_PROVINCIA,0) as ProvinciaEmisor																								"
                SQL &= Chr(13) & "								 	,convert(varchar,SUBSTRING(EMISOR.COD_CANTON,2,2)) as CantonEmisor																								"
                SQL &= Chr(13) & "								 	,convert(varchar,SUBSTRING(EMISOR.COD_DISTRITO,4,2)) as DistritoEmisor																								"
                SQL &= Chr(13) & "								 	,SUCUR.DIRECCION as OtrasSenasEmisor																								"
                SQL &= Chr(13) & "								 	,'506' as CodigoPaisEmisor																								"
                SQL &= Chr(13) & "								 	,convert(int,SUCUR.TELEFONO) as TelefonoEmisor 																								"
                SQL &= Chr(13) & "								 	,SUCUR.CORREO as CorreoElectronicoEmisor																								"
                SQL &= Chr(13) & "								 																									"
                SQL &= Chr(13) & "									--/*Receptor*/																								"
                SQL &= Chr(13) & "								 	,SUBSTRING(RECEPTOR.NOMBRE+' '+RECEPTOR.APELLIDO1+' '+RECEPTOR.APELLIDO2,1,80) as NombreReceptor																								"
                SQL &= Chr(13) & "								 	,case RECEPTOR.TIPO_CEDULA when 'F' THEN  '01' when 'J' then '02' when 'Nite' then '04' when 'D' then '03' else '05' end as TipoIdentificacionReceptor																								"
                SQL &= Chr(13) & "								 	,RECEPTOR.CEDULA as IdentificacionReceptor																								"
                SQL &= Chr(13) & "								 	,RECEPTOR.CEDULA as IdentificacionExtranjero																								"
                SQL &= Chr(13) & "								 	,ISNULL(RECEPTOR.COD_PROVINCIA,0) as ProvinciaReceptor																								"
                SQL &= Chr(13) & "								 	,ISNULL(convert(varchar,SUBSTRING(RECEPTOR.COD_CANTON,2,2)),'00') as CantonReceptor																								"
                SQL &= Chr(13) & "								 	,ISNULL(convert(varchar,SUBSTRING(RECEPTOR.COD_DISTRITO,4,2)),'00') as DistritoReceptor	 																				  			"
                SQL &= Chr(13) & "								 	,RECEPTOR.DIRECCION as OtrasSenasReceptor																								"
                SQL &= Chr(13) & "								 	,'506' as CodigoPaisReceptor																								"
                SQL &= Chr(13) & "									, RECEPTOR.TELEFONO as TelefonoReceptor																								"
                SQL &= Chr(13) & "								 	,ISNULL(RECEPTOR.CORREO,'') as CorreoElectronicoReceptor																								"
                SQL &= Chr(13) & "								 	,case DOC.TIPO_MOV when  'FC' then '01' when 'FA' then '02' else '' end as CondicionVenta 																								"
                SQL &= Chr(13) & "								 	,ISNULL(DOC.PLAZO, 0) as PlazoCredito																								"
                SQL &= Chr(13) & "								 	,CASE WHEN DOC.FORMA_PAGO ='EF' THEN '01' WHEN DOC.FORMA_PAGO ='TA' THEN '02' WHEN DOC.FORMA_PAGO ='TR' THEN '04' END AS MedioPago																								"
                SQL &= Chr(13) & "								 																									"
                SQL &= Chr(13) & "									--/*TotalesFactura */																								"
                SQL &= Chr(13) & "									,case DOC.COD_MONEDA when 'D' then 'USD' when 'E' then 'EUR' else 'CRC' end as CodigoMoneda 																								"
                SQL &= Chr(13) & "								 	,DOC.TIPO_CAMBIO as tipoCambio																								"
                SQL &= Chr(13) & "									,ISNULL(@TotalServGravados,0)		AS TotalServGravados																						"
                SQL &= Chr(13) & "									,ISNULL(@TotalServExentos,0)		AS TotalServExentos																						"
                SQL &= Chr(13) & "									,ISNULL(@TotalServExonerado,0)		AS TotalServExonerado																						"
                SQL &= Chr(13) & "									,ISNULL(@TotalMercanciasGravadas,0) AS TotalMercanciasGravadas																								"
                SQL &= Chr(13) & "									,ISNULL(@TotalMercanciasExentas,0)	AS TotalMercanciasExentas																							"
                SQL &= Chr(13) & "									,ISNULL(@TotalMercExonerada,0)		AS TotalMercExonerada																						"
                SQL &= Chr(13) & "									,ISNULL(@TotalGravado,0)			AS TotalGravado																					"
                SQL &= Chr(13) & "								 	,ISNULL(@TotalExento,0)				AS TotalExento																				"
                SQL &= Chr(13) & "									,ISNULL(@TotalExonerado,0)			AS TotalExonerado																					"
                SQL &= Chr(13) & "									,ISNULL(@TotalVenta,0)				AS TotalVenta																				"
                SQL &= Chr(13) & "									,ISNULL(@TotalDescuentos,0)			AS TotalDescuentos																					"
                SQL &= Chr(13) & "									,ISNULL(@TotalVentaNeta,0)			AS TotalVentaNeta																					"
                SQL &= Chr(13) & "									,ISNULL(@TotalImpuesto,0)			AS TotalImpuesto																					"
                SQL &= Chr(13) & "									,ISNULL(@TotalIVADevuelto,0)		AS TotalIVADevuelto																						"
                SQL &= Chr(13) & "									,ISNULL(@TotalOtrosCargos,0)		AS TotalOtrosCargos																						"
                SQL &= Chr(13) & "									,ISNULL(@TotalComprobante,0)		AS TotalComprobante																						"
                SQL &= Chr(13) & "								 																									"
                SQL &= Chr(13) & "								 	/* Autorizacion*/																								"
                SQL &= Chr(13) & "								 	,'DGT-R-33-2019' as NumeroResolucion																								"
                SQL &= Chr(13) & "								 	,'2019-06-20 00:00:00' as FechaResolucion																								"
                SQL &= Chr(13) & "								 	,'' as ID_TIPO_CERTIFICADO 																								"
                SQL &= Chr(13) & "								 	,''as RUTA_CERTIFICADO 																								"
                SQL &= Chr(13) & "								 	,'' as PASSWD																								"
                SQL &= Chr(13) & "								 	,NULL as Firma																								"
                SQL &= Chr(13) & "								 	,NULL as x509Certificado																								"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "								 	FROM DOCUMENTO_ENC AS DOC																								"
                SQL &= Chr(13) & "								 	INNER JOIN COMPANIA AS EMISOR																								"
                SQL &= Chr(13) & "								 		ON EMISOR.COD_CIA = DOC.COD_CIA 																							"
                SQL &= Chr(13) & "								 	INNER JOIN CLIENTE AS RECEPTOR																								"
                SQL &= Chr(13) & "								 		ON RECEPTOR.COD_CIA = DOC.COD_CIA																							"
                SQL &= Chr(13) & "								 		AND  RECEPTOR.CEDULA = DOC.CEDULA																							"
                SQL &= Chr(13) & "									INNER JOIN DOCUMENTO_ELECTRONICO ELEC																								"
                SQL &= Chr(13) & "										ON ELEC.COD_CIA = DOC.COD_CIA																							"
                SQL &= Chr(13) & "										AND ELEC.COD_SUCUR = DOC.COD_SUCUR																							"
                SQL &= Chr(13) & "										AND ELEC.NUMERO_DOC = DOC.NUMERO_DOC																							"
                SQL &= Chr(13) & "										AND ELEC.TIPO_MOV = DOC.TIPO_MOV																							"
                SQL &= Chr(13) & "									INNER JOIN SUCURSAL AS SUCUR																								"
                SQL &= Chr(13) & "										ON DOC.COD_CIA = SUCUR.COD_CIA																							"
                SQL &= Chr(13) & "										AND DOC.COD_SUCUR = SUCUR.COD_SUCUR																							"
                SQL &= Chr(13) & "									WHERE DOC.COD_CIA = @COD_CIA																								"
                SQL &= Chr(13) & "								 	AND DOC.TIPO_MOV = @TIPO_MOV																								"
                SQL &= Chr(13) & "								 	AND DOC.NUMERO_DOC = @NUMERO_DOC																								"
                SQL &= Chr(13) & "									AND DOC.COD_SUCUR = @COD_SUCUR																								"
                SQL &= Chr(13) & "								 																									"
                SQL &= Chr(13) & "							/* Detalle */																										"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "							IF @TIPO_MOV <>'NC'																										"
                SQL &= Chr(13) & "							BEGIN 																										"
                SQL &= Chr(13) & "								select																									"
                SQL &= Chr(13) & "								 	DET.LINEA as NumeroLinea 																								"
                SQL &= Chr(13) & "									,'N' AS IND_OTROS_CARGOS																								"
                SQL &= Chr(13) & "									,'' AS PartidaArancelaria																								"
                SQL &= Chr(13) & "								 	,'01' as TipoCodigo																								"
                SQL &= Chr(13) & "                                  ,PRO.COD_CABYS as CodigoProdDGTD                    "
                SQL &= Chr(13) & "								 	,PRO.COD_PROD  as CodigoComercial																								"
                SQL &= Chr(13) & "								 	,CANTIDAD as Cantidad																								"
                SQL &= Chr(13) & "								 	,DET.COD_UNIDAD as UnidadMedida																								"
                SQL &= Chr(13) & "								 	,PRO.DESCRIPCION as Detalle																								"
                SQL &= Chr(13) & "								 	,DET.PRECIO as PrecioUnitario																								"
                SQL &= Chr(13) & "								 	,CANTIDAD * DET.PRECIO  as MontoTotal																								"
                SQL &= Chr(13) & "								 	,DET.DESCUENTO  as MontoDescuento																								"
                SQL &= Chr(13) & "								 	,'' as NaturalezaDescuento																								"
                SQL &= Chr(13) & "								 	,DET.SUBTOTAL as Subtotal																								"
                SQL &= Chr(13) & "									,DET.SUBTOTAL as BaseImponible																								"
                SQL &= Chr(13) & "								 	,SUBSTRING(IMP.COD_IMPUESTO_DGTD,1,2) as CodigoImpuesto																								"
                SQL &= Chr(13) & "									,SUBSTRING(IMP.COD_IMPUESTO_DGTD,3,2) as CodigoTarifaImpuesto																								"
                SQL &= Chr(13) & "									,CASE WHEN IMP.PORCENTAJE = 0 THEN DET.POR_IMPUESTO ELSE IMP.PORCENTAJE END	as TarifaImpuesto																							"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "								 	,CASE WHEN  EXO.PORCENTAJE > 0 THEN DET.EXONERACION - DET.IMPUESTO ELSE DET.IMPUESTO END as MontoImpuesto 																								"
                SQL &= Chr(13) & "								 	,EXO.TIPO_DOC AS TipoDocumentoEXO																								"
                SQL &= Chr(13) & "								 	,EXO.NUMERO_DOC AS NumeroDocumentoEXO																								"
                SQL &= Chr(13) & "								 	,EXO.NOMBRE AS NombreInstitucionEXO																								"
                SQL &= Chr(13) & "								 	,EXO.FECHA AS FechaEmisionEXO																								"
                SQL &= Chr(13) & "									,EXO.PORCENTAJE AS PorcentajeExoneracion																								"
                SQL &= Chr(13) & "								 	,DET.EXONERACION AS MontoExoneracion																								"
                SQL &= Chr(13) & "									,DET.IMPUESTO  AS ImpuestoNeto																								"
                SQL &= Chr(13) & "									,DET.TOTAL	AS MontoTotalLinea																							"
                SQL &= Chr(13) & "									,NULL AS TipoDocumentoOtrosCargos																								"
                SQL &= Chr(13) & "									,NULL AS NumeroIdentidadTercero																								"
                SQL &= Chr(13) & "									,NULL AS NombreTercero																								"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "								 	FROM DOCUMENTO_ENC AS DOC																								"
                SQL &= Chr(13) & "								 	INNER JOIN DOCUMENTO_DET AS DET																								"
                SQL &= Chr(13) & "								 		ON DET.COD_CIA = DOC.COD_CIA																							"
                SQL &= Chr(13) & "										and DET.COD_SUCUR = DOC.COD_SUCUR																							"
                SQL &= Chr(13) & "								 		and DET.TIPO_MOV = DOC.TIPO_MOV																							"
                SQL &= Chr(13) & "								 		and DET.NUMERO_DOC = DOC.NUMERO_DOC																							"
                SQL &= Chr(13) & "									INNER JOIN PRODUCTO AS PRO																								"
                SQL &= Chr(13) & "										ON PRO.COD_CIA = DET.COD_CIA																							"
                SQL &= Chr(13) & "										AND PRO.COD_SUCUR = DET.COD_SUCUR																							"
                SQL &= Chr(13) & "										AND PRO.COD_PROD = DET.COD_PROD																							"
                SQL &= Chr(13) & "									LEFT JOIN IMPUESTO AS IMP																								"
                SQL &= Chr(13) & "										ON IMP.COD_IMPUESTO=PRO.COD_IMPUESTO_DGTD																							"
                SQL &= Chr(13) & "									LEFT JOIN CLIENTE_EXONERACION AS EXO 																								"
                SQL &= Chr(13) & "										ON EXO.COD_CIA = DOC.COD_CIA																							"
                SQL &= Chr(13) & "										AND EXO.CEDULA = DOC.CEDULA																							"
                SQL &= Chr(13) & "                                      AND EXO.ESTADO = 'A'"
                SQL &= Chr(13) & "								 	WHERE DOC.COD_CIA = @COD_CIA																								"
                SQL &= Chr(13) & "								 	AND DOC.TIPO_MOV = @TIPO_MOV																								"
                SQL &= Chr(13) & "									AND DOC.COD_SUCUR = @COD_SUCUR																								"
                SQL &= Chr(13) & "								 	AND DOC.NUMERO_DOC = @NUMERO_DOC																								"
                SQL &= Chr(13) & "								 	AND CANTIDAD * DET.PRECIO > 0																								"
                SQL &= Chr(13) & "								 	ORDER BY DET.LINEA	ASC																							"
                SQL &= Chr(13) & "								END																									"
                SQL &= Chr(13) & "								ELSE																									"
                SQL &= Chr(13) & "								BEGIN																									"
                SQL &= Chr(13) & "									IF EXISTS( SELECT TOP 1 DET.COD_CIA																								"
                SQL &= Chr(13) & "											FROM DOCUMENTO_ENC AS DOC																						"
                SQL &= Chr(13) & "											INNER JOIN DOCUMENTO_AFEC_DET_PRODUCTOS AS DET																						"
                SQL &= Chr(13) & "												ON DOC.COD_CIA = DET.COD_CIA																					"
                SQL &= Chr(13) & "												AND DOC.COD_SUCUR = DET.COD_SUCUR																					"
                SQL &= Chr(13) & "												AND DOC.TIPO_MOV = DET.TIPO_MOV																					"
                SQL &= Chr(13) & "												AND DOC.NUMERO_DOC = DET.NUMERO_DOC 																					"
                SQL &= Chr(13) & "											WHERE DET.COD_CIA=@COD_CIA																						"
                SQL &= Chr(13) & "											AND DET.COD_SUCUR=@COD_SUCUR																						"
                SQL &= Chr(13) & "											AND DET.NUMERO_DOC=@NUMERO_DOC																						"
                SQL &= Chr(13) & "											AND DET.TIPO_MOV=@TIPO_MOV																						"
                SQL &= Chr(13) & "										)																							"
                SQL &= Chr(13) & "									BEGIN																								"
                SQL &= Chr(13) & "									SELECT DET.LINEA as NumeroLinea 																								"
                SQL &= Chr(13) & "		                                ,'N' AS IND_OTROS_CARGOS																															"
                SQL &= Chr(13) & "		                                ,'' AS PartidaArancelaria																															"
                SQL &= Chr(13) & "		                                ,'04' as TipoCodigo																															"
                SQL &= Chr(13) & "                                      ,PROD.COD_CABYS as CodigoProdDGTD                    "
                SQL &= Chr(13) & "		                                ,PROD.COD_PROD  as CodigoComercial																															"
                SQL &= Chr(13) & "		                                ,DET.CANTIDAD as Cantidad																															"
                SQL &= Chr(13) & "		                                ,PROD.COD_UNIDAD as UnidadMedida																															"
                SQL &= Chr(13) & "		                                ,PROD.DESCRIPCION as Detalle																															"
                SQL &= Chr(13) & "		                                ,DET.PRECIO_UNITARIO as PrecioUnitario																															"
                SQL &= Chr(13) & "		                                ,DET.CANTIDAD * DET.PRECIO_UNITARIO as MontoTotal																															"
                SQL &= Chr(13) & "		                                ,((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100  as MontoDescuento																															"
                SQL &= Chr(13) & "		                                ,'OTROS' as NaturalezaDescuento																															"
                SQL &= Chr(13) & "		                                ,(DET.CANTIDAD * DET.PRECIO_UNITARIO)- (((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100) as Subtotal																															"
                SQL &= Chr(13) & "		                                ,(DET.CANTIDAD * DET.PRECIO_UNITARIO)- (((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100) as BaseImponible																															"
                SQL &= Chr(13) & "		                                ,SUBSTRING(IMP.COD_IMPUESTO_DGTD,1,2) AS CodigoImpuesto																															"
                SQL &= Chr(13) & "		                                ,SUBSTRING(IMP.COD_IMPUESTO_DGTD,3,2) AS CodigoTarifaImpuesto																															"
                SQL &= Chr(13) & "		                                ,CASE WHEN DET.POR_IMPUESTO > 0 THEN DET.POR_IMPUESTO ELSE IMP.PORCENTAJE END AS TarifaImpuesto																															"
                SQL &= Chr(13) & "		                                ,CASE WHEN DET.POR_IMPUESTO > 0 THEN ((((DET.CANTIDAD * DET.PRECIO_UNITARIO) - (((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100))*DET.POR_IMPUESTO)/100) ELSE 0 END AS MontoImpuesto																															"
                SQL &= Chr(13) & "		                                ,NULL AS TipoDocumentoEXO																															"
                SQL &= Chr(13) & "		                                ,NULL AS NumeroDocumentoEXO																															"
                SQL &= Chr(13) & "		                                ,NULL AS NombreInstitucionEXO																															"
                SQL &= Chr(13) & "		                                ,NULL AS FechaEmisionEXO																															"
                SQL &= Chr(13) & "		                                ,0 AS PorcentajeExoneracion																															"
                SQL &= Chr(13) & "		                                ,0 AS MontoExoneracion																															"
                SQL &= Chr(13) & "		                                ,((((DET.CANTIDAD * DET.PRECIO_UNITARIO) - (((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100))*DET.POR_IMPUESTO)/100) AS ImpuestoNeto																															"
                SQL &= Chr(13) & "		                                ,(DET.CANTIDAD * DET.PRECIO_UNITARIO)- (((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100) + ((((DET.CANTIDAD * DET.PRECIO_UNITARIO) - (((DET.CANTIDAD * DET.PRECIO_UNITARIO) * DET.POR_DESCUENTO)/100))*DET.POR_IMPUESTO)/100)  AS MontoTotalLinea																															"
                SQL &= Chr(13) & "		                                ,'' AS TipoDocumentoOtrosCargos																															"
                SQL &= Chr(13) & "		                                ,'' AS NumeroIdentidadTercero																															"
                SQL &= Chr(13) & "		                                ,'' AS NombreTercero 																															"
                SQL &= Chr(13) & "								FROM DOCUMENTO_ENC AS DOC																									"
                SQL &= Chr(13) & "								INNER JOIN DOCUMENTO_AFEC_DET_PRODUCTOS AS DET																									"
                SQL &= Chr(13) & "									ON DOC.COD_CIA=DET.COD_CIA																								"
                SQL &= Chr(13) & "									AND DOC.COD_SUCUR=DET.COD_SUCUR																								"
                SQL &= Chr(13) & "									AND DOC.NUMERO_DOC=DET.NUMERO_DOC																								"
                SQL &= Chr(13) & "									AND DOC.TIPO_MOV=DET.TIPO_MOV																								"
                SQL &= Chr(13) & "								INNER JOIN PRODUCTO AS PROD																									"
                SQL &= Chr(13) & "									ON PROD.COD_CIA = DET.COD_CIA 																								"
                SQL &= Chr(13) & "									AND PROD.COD_SUCUR = DET.COD_SUCUR																								"
                SQL &= Chr(13) & "									AND PROD.COD_PROD = DET.COD_PROD																								"
                SQL &= Chr(13) & "								LEFT JOIN IMPUESTO AS IMP																									"
                SQL &= Chr(13) & "									ON IMP.COD_IMPUESTO=PROD.COD_IMPUESTO_DGTD		  																						"
                SQL &= Chr(13) & "								WHERE DOC.COD_CIA=@COD_CIA																									"
                SQL &= Chr(13) & "								AND DOC.COD_SUCUR = @COD_SUCUR																								"
                SQL &= Chr(13) & "								AND DOC.NUMERO_DOC=@NUMERO_DOC																								"
                SQL &= Chr(13) & "								AND DOC.TIPO_MOV=@TIPO_MOV																								"
                SQL &= Chr(13) & "								END																									"
                SQL &= Chr(13) & "								ELSE																									"
                SQL &= Chr(13) & "								BEGIN																									"
                SQL &= Chr(13) & "									SELECT 1 AS NumeroLinea																								"
                SQL &= Chr(13) & "									,'N' AS IND_OTROS_CARGOS																								"
                SQL &= Chr(13) & "									,'' AS PartidaArancelaria																								"
                SQL &= Chr(13) & "									,'04' AS TipoCodigo																								"
                SQL &= Chr(13) & "									,PROD.COD_CABYS as CodigoProdDGTD "
                SQL &= Chr(13) & "									,PROD.COD_PROD  as CodigoComercial																								"
                SQL &= Chr(13) & "									, 1 AS Cantidad																								"
                SQL &= Chr(13) & "									,'Unid' AS UnidadMedida																								"
                SQL &= Chr(13) & "									,'ND' AS Detalle																								"
                SQL &= Chr(13) & "									, ENC.MONTO AS PrecioUnitario																								"
                SQL &= Chr(13) & "									, ENC.MONTO AS MontoTotal																								"
                SQL &= Chr(13) & "									, 0 AS MontoDescuento																								"
                SQL &= Chr(13) & "									,'Otros' AS NaturalezaDescuento																								"
                SQL &= Chr(13) & "									,ENC.MONTO AS Subtotal																								"
                SQL &= Chr(13) & "									,ENC.MONTO AS BaseImponible																								"
                SQL &= Chr(13) & "									,SUBSTRING(IMP.COD_IMPUESTO_DGTD,1,2) AS CodigoImpuesto																								"
                SQL &= Chr(13) & "									,SUBSTRING(IMP.COD_IMPUESTO_DGTD,3,2) AS CodigoTarifaImpuesto																								"
                SQL &= Chr(13) & "									,CASE WHEN DET.POR_IMPUESTO > 0 THEN DET.POR_IMPUESTO ELSE IMP.PORCENTAJE END AS TarifaImpuesto																								"
                SQL &= Chr(13) & "									,ENC.IMPUESTO AS MontoImpuesto																								"
                SQL &= Chr(13) & "									,NULL AS TipoDocumentoEXO																								"
                SQL &= Chr(13) & "									,NULL AS NumeroDocumentoEXO																								"
                SQL &= Chr(13) & "									,NULL AS NombreInstitucionEXO																								"
                SQL &= Chr(13) & "									,NULL AS FechaEmisionEXO																								"
                SQL &= Chr(13) & "									,NULL AS PorcentajeExoneracion																								"
                SQL &= Chr(13) & "									,0 AS MontoExoneracion																								"
                SQL &= Chr(13) & "									,ENC.IMPUESTO AS ImpuestoNeto																								"
                SQL &= Chr(13) & "									,ENC.MONTO + ENC.IMPUESTO AS MontoTotalLinea																								"
                SQL &= Chr(13) & "									,'' AS TipoDocumentoOtrosCargos																								"
                SQL &= Chr(13) & "									,'' AS NumeroIdentidadTercero																								"
                SQL &= Chr(13) & "									,'' AS NombreTercero																								"
                SQL &= Chr(13) & "									FROM DOCUMENTO_ENC AS ENC																								"
                SQL &= Chr(13) & "									INNER JOIN DOCUMENTO_AFEC AS AFEC																								"
                SQL &= Chr(13) & "										ON AFEC.COD_CIA = ENC.COD_CIA																							"
                SQL &= Chr(13) & "										AND AFEC.COD_SUCUR = ENC.COD_SUCUR																							"
                SQL &= Chr(13) & "										AND AFEC.TIPO_MOV = ENC.TIPO_MOV																							"
                SQL &= Chr(13) & "										AND AFEC.NUMERO_DOC = ENC.NUMERO_DOC																							"
                SQL &= Chr(13) & "									INNER JOIN DOCUMENTO_DET AS DET																								"
                SQL &= Chr(13) & "										ON DET.COD_CIA = AFEC.COD_CIA																							"
                SQL &= Chr(13) & "										AND DET.COD_SUCUR = AFEC.COD_SUCUR																							"
                SQL &= Chr(13) & "										AND DET.NUMERO_DOC = AFEC.NUMERO_DOC_AFEC																							"
                SQL &= Chr(13) & "										AND DET.TIPO_MOV = AFEC.TIPO_MOV_AFEC																							"
                SQL &= Chr(13) & "										AND DET.LINEA = 1																							"
                SQL &= Chr(13) & "									INNER JOIN PRODUCTO AS PROD																								"
                SQL &= Chr(13) & "										ON PROD.COD_CIA = DET.COD_CIA 																							"
                SQL &= Chr(13) & "										AND PROD.COD_SUCUR = DET.COD_SUCUR																							"
                SQL &= Chr(13) & "										AND PROD.COD_PROD = DET.COD_PROD																							"
                SQL &= Chr(13) & "									LEFT JOIN IMPUESTO AS IMP																								"
                SQL &= Chr(13) & "										ON IMP.COD_IMPUESTO=PROD.COD_IMPUESTO_DGTD																							"
                SQL &= Chr(13) & "									WHERE  ENC.COD_CIA = @COD_CIA 																								"
                SQL &= Chr(13) & "									AND ENC.COD_SUCUR = @COD_SUCUR 																								"
                SQL &= Chr(13) & "									AND ENC.TIPO_MOV = @TIPO_MOV 																								"
                SQL &= Chr(13) & "									AND ENC.NUMERO_DOC = @NUMERO_DOC																								"
                SQL &= Chr(13) & "								END																									"
                SQL &= Chr(13) & "								END																									"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "																																	"
                SQL &= Chr(13) & "								 	                                        /* REFERENCIAS */																								"
                SQL &= Chr(13) & "								 	SELECT DE.TIPO_COMPROBANTE as TpoDocRef 																								"
                SQL &= Chr(13) & "								 		    ,DE.CONSECUTIVO as NumeroReferencia 																							"
                SQL &= Chr(13) & "								 			,DOC.FECHA as FechaReferencia																						"
                SQL &= Chr(13) & "								 			,CASE WHEN DOC_AFEC.MONTO_AFEC = (DOC.MONTO + DOC.IMPUESTO) THEN '01' ELSE '02' END as CodigoReferencia 																						"
                SQL &= Chr(13) & "								 			,CASE WHEN DOC_AFEC.MONTO_AFEC = (DOC.MONTO + DOC.IMPUESTO) THEN 'Anula Documento de Referencia' ELSE 'Corrige monto' END as RazonReferencia																						"
                SQL &= Chr(13) & "								 	FROM DOCUMENTO_AFEC AS DOC_AFEC																								"
                SQL &= Chr(13) & "									INNER JOIN DOCUMENTO_ENC AS DOC																								"
                SQL &= Chr(13) & "										ON DOC.COD_CIA = DOC_AFEC.COD_CIA																							"
                SQL &= Chr(13) & "										AND DOC.COD_SUCUR = DOC_AFEC.COD_SUCUR																							"
                SQL &= Chr(13) & "										AND DOC.TIPO_MOV = DOC_AFEC.TIPO_MOV_AFEC																							"
                SQL &= Chr(13) & "										AND DOC.NUMERO_DOC = DOC_AFEC.NUMERO_DOC_AFEC 																							"
                SQL &= Chr(13) & "									INNER JOIN DOCUMENTO_ELECTRONICO AS DE																								"
                SQL &= Chr(13) & "										ON DE.COD_CIA = DOC_AFEC.COD_CIA																							"
                SQL &= Chr(13) & "										AND DE.COD_SUCUR = DOC_AFEC.COD_SUCUR																							"
                SQL &= Chr(13) & "										AND DE.TIPO_MOV = DOC_AFEC.TIPO_MOV																							"
                SQL &= Chr(13) & "										AND DE.NUMERO_DOC = DOC_AFEC.NUMERO_DOC																							"
                SQL &= Chr(13) & "								 	WHERE DOC_AFEC.COD_CIA = @COD_CIA																								"
                SQL &= Chr(13) & "										AND DOC_AFEC.COD_SUCUR = @COD_SUCUR																							"
                SQL &= Chr(13) & "								 		AND DOC_AFEC.TIPO_MOV = @TIPO_MOV																							"
                SQL &= Chr(13) & "								 		AND DOC_AFEC.NUMERO_DOC = @NUMERO_DOC																							"
                SQL &= Chr(13) & "					END																												"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_IMPORTA_PRODUCTO_CABYS()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_IMPORTA_PRODUCTO_CABYS", "2020-12-01") Then
                ELIMINA_PROCEDIMIENTO("USP_IMPORTA_PRODUCTO_CABYS")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_IMPORTA_PRODUCTO_CABYS]																									"
                SQL &= Chr(13) & "	@DT_DOCUMENTOS AS TP_PRODUCTO_CABYS READONLY,																									"
                SQL &= Chr(13) & "	@COD_CIA VARCHAR(3),																									"
                SQL &= Chr(13) & "	@COD_SUCUR VARCHAR(3)																									"
                SQL &= Chr(13) & "	AS																									"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "		BEGIN TRY 																								"
                SQL &= Chr(13) & "		BEGIN TRAN																								"
                SQL &= Chr(13) & "		                			                			               		                																"
                SQL &= Chr(13) & "			CREATE TABLE #TP_PRODUCTO_CABYS(																							"
                SQL &= Chr(13) & "			[COD_CIA] [varchar](3) NOT NULL,																							"
                SQL &= Chr(13) & "			[COD_SUCUR] [varchar](3) NOT NULL, 																							"
                SQL &= Chr(13) & "			[COD_PROD] [varchar](20) NOT NULL,																							"
                SQL &= Chr(13) & "			[COD_CABYS] [varchar](13) NOT NULL)         			                			               		                															"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			INSERT INTO  #TP_PRODUCTO_CABYS																							"
                SQL &= Chr(13) & "			SELECT @COD_CIA, @COD_SUCUR, COD_PROD, COD_CABYS 																							"
                SQL &= Chr(13) & "			FROM @DT_DOCUMENTOS																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			/*VALIDACIONES*/																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	        IF EXISTS(SELECT C.*																									"
                SQL &= Chr(13) & "						FROM #TP_PRODUCTO_CABYS	 AS C																				"
                SQL &= Chr(13) & "						LEFT JOIN PRODUCTO AS P																				"
                SQL &= Chr(13) & "							ON C.COD_CIA = P.COD_CIA COLLATE Latin1_General_CI_AS 																			"
                SQL &= Chr(13) & "							AND C.COD_SUCUR = P.COD_SUCUR COLLATE Latin1_General_CI_AS 																			"
                SQL &= Chr(13) & "							AND C.COD_PROD = P.COD_PROD	COLLATE Latin1_General_CI_AS 																		"
                SQL &= Chr(13) & "						WHERE P.COD_PROD IS NULL	)																			"
                SQL &= Chr(13) & "				BEGIN 																						"
                SQL &= Chr(13) & "					SELECT C.*																					"
                SQL &= Chr(13) & "					FROM #TP_PRODUCTO_CABYS	 AS C																					"
                SQL &= Chr(13) & "					LEFT JOIN PRODUCTO AS P																					"
                SQL &= Chr(13) & "						ON C.COD_CIA = P.COD_CIA COLLATE Latin1_General_CI_AS 																				"
                SQL &= Chr(13) & "						AND C.COD_SUCUR = P.COD_SUCUR COLLATE Latin1_General_CI_AS 																				"
                SQL &= Chr(13) & "						AND C.COD_PROD = P.COD_PROD	COLLATE Latin1_General_CI_AS 																			"
                SQL &= Chr(13) & "					WHERE P.COD_PROD IS NULL																					"
                SQL &= Chr(13) & "			    END																							"
                SQL &= Chr(13) & "			ELSE 																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				UPDATE PRODUCTO																						"
                SQL &= Chr(13) & "				SET COD_CABYS = T1.COD_CABYS																						"
                SQL &= Chr(13) & "				FROM (																						"
                SQL &= Chr(13) & "					SELECT C.COD_CIA, C.COD_SUCUR, C.COD_PROD, C.COD_CABYS																					"
                SQL &= Chr(13) & "					FROM PRODUCTO AS P																					"
                SQL &= Chr(13) & "					INNER JOIN #TP_PRODUCTO_CABYS AS C																					"
                SQL &= Chr(13) & "						ON C.COD_CIA = P.COD_CIA	COLLATE Latin1_General_CI_AS 																			"
                SQL &= Chr(13) & "						AND C.COD_SUCUR = P.COD_SUCUR COLLATE Latin1_General_CI_AS 																				"
                SQL &= Chr(13) & "						AND C.COD_PROD = P.COD_PROD	 COLLATE Latin1_General_CI_AS 																			"
                SQL &= Chr(13) & "				) AS T1																						"
                SQL &= Chr(13) & "				WHERE T1.COD_CIA = PRODUCTO.COD_CIA	COLLATE Latin1_General_CI_AS																					"
                SQL &= Chr(13) & "				AND T1.COD_SUCUR = PRODUCTO.COD_SUCUR COLLATE Latin1_General_CI_AS																						"
                SQL &= Chr(13) & "				AND T1.COD_PROD = PRODUCTO.COD_PROD COLLATE Latin1_General_CI_AS																						"
                SQL &= Chr(13) & "			END																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	COMMIT TRAN																									"
                SQL &= Chr(13) & "	END TRY																									"
                SQL &= Chr(13) & "	BEGIN CATCH																									"
                SQL &= Chr(13) & "		ROLLBACK TRAN																								"
                SQL &= Chr(13) & "		DECLARE @MENSAJE VARCHAR(500)																								"
                SQL &= Chr(13) & "		SET @MENSAJE =( SELECT ERROR_MESSAGE())																								"
                SQL &= Chr(13) & "		RAISERROR( @MENSAJE, 16, 1);																								"
                SQL &= Chr(13) & "	END CATCH																									"
                SQL &= Chr(13) & "	END				"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DATOS_APARTADO_IMPRESION()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_APARTADO_IMPRESION", "2020-12-09") Then
                ELIMINA_PROCEDIMIENTO("USP_DATOS_APARTADO_IMPRESION")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_APARTADO_IMPRESION] 																									"
                SQL &= Chr(13) & "			 @COD_CIA VARCHAR(3)																							"
                SQL &= Chr(13) & "			,@COD_SUCUR VARCHAR(3)																							"
                SQL &= Chr(13) & "			,@NUMERO_DOC INT																							"
                SQL &= Chr(13) & "			,@TIPO_MOV VARCHAR(2)																							"
                SQL &= Chr(13) & "		AS																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT CIA.NOMBRE AS Compania, SUC.NOMBRE AS Sucursal, CIA.CEDULA AS Cedula, SUC.TELEFONO + CASE WHEN ISNULL(SUC.TELEFONO_2, '') = '' THEN '' ELSE '/' + TELEFONO_2 END AS Telefono, CIA.PROVINCIA AS Provincia,																						"
                SQL &= Chr(13) & "				CIA.CANTON AS Canton, CIA.DISTRITO AS Distrito, SUC.DIRECCION AS Direccion, CIA.CORREO as Correo, 'N' AS FE																						"
                SQL &= Chr(13) & "				FROM COMPANIA AS CIA																						"
                SQL &= Chr(13) & "				INNER JOIN SUCURSAL AS SUC																						"
                SQL &= Chr(13) & "					ON SUC.COD_CIA = CIA.COD_CIA																					"
                SQL &= Chr(13) & "				WHERE CIA.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND SUC.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "		SELECT CASE DE.TIPO_COMPROBANTE WHEN '01' THEN 'FACTURA ELECTRONICA' WHEN '04' THEN 'TIQUETE ELECTRONICO' ELSE 'FACTURA' END AS TIPO, DE.CONSECUTIVO AS Consec,																								"
                SQL &= Chr(13) & "					ENC.NUMERO_DOC AS Numero, 'CLAVE NUMERICA' AS CLAVE_S, DE.CLAVE AS Clave, ENC.FECHA, CASE WHEN ENC.TIPO_MOV = 'FC' THEN 'CONTADO' ELSE 'CREDITO' END AS VENTA,																					"
                SQL &= Chr(13) & "					(CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2) AS Nombre, U.NOMBRE AS Usuario, CASE WHEN ENC.COD_MONEDA = 'L' THEN 'COLONES' ELSE 'DOLARES' END AS MONEDA,																					"
                SQL &= Chr(13) & "					ENC.DESCRIPCION AS DETALLE																					"
                SQL &= Chr(13) & "					FROM APARTADO_ENC AS ENC																					"
                SQL &= Chr(13) & "					LEFT JOIN DOCUMENTO_ELECTRONICO AS DE																					"
                SQL &= Chr(13) & "						ON ENC.COD_CIA = DE.COD_CIA																				"
                SQL &= Chr(13) & "						AND ENC.COD_SUCUR = DE.COD_SUCUR																				"
                SQL &= Chr(13) & "						AND ENC.TIPO_MOV = DE.TIPO_MOV 																				"
                SQL &= Chr(13) & "						AND ENC.NUMERO_DOC = DE.NUMERO_DOC																				"
                SQL &= Chr(13) & "					INNER JOIN CLIENTE AS CLI																					"
                SQL &= Chr(13) & "						ON CLI.COD_CIA = ENC.COD_CIA																				"
                SQL &= Chr(13) & "						AND CLI.CEDULA = ENC.CEDULA																				"
                SQL &= Chr(13) & "					INNER JOIN USUARIO AS U																					"
                SQL &= Chr(13) & "						ON U.COD_USUARIO = ENC.COD_USUARIO																				"
                SQL &= Chr(13) & "					WHERE ENC.COD_CIA = @COD_CIA																					"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = @COD_SUCUR																					"
                SQL &= Chr(13) & "					AND ENC.TIPO_MOV = @TIPO_MOV																					"
                SQL &= Chr(13) & "					AND ENC.NUMERO_DOC = @NUMERO_DOC																					"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT DET.LINEA, P.COD_PROD,  P.DESCRIPCION, DET.PRECIO, DET.CANTIDAD, DET.IMPUESTO, DET.DESCUENTO, DET.SUBTOTAL, DET.TOTAL																						"
                SQL &= Chr(13) & "				FROM APARTADO_DET AS DET																						"
                SQL &= Chr(13) & "				INNER JOIN PRODUCTO AS P																						"
                SQL &= Chr(13) & "					ON P.COD_CIA = DET.COD_CIA																					"
                SQL &= Chr(13) & "					AND P.COD_SUCUR = DET.COD_SUCUR																					"
                SQL &= Chr(13) & "					AND P.COD_PROD = DET.COD_PROD																					"
                SQL &= Chr(13) & "				WHERE DET.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND DET.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND DET.TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "				AND DET.NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT COUNT(*) AS LINEAS, SUM(CASE WHEN IMPUESTO > 0 OR (POR_IMPUESTO > 0 AND IMPUESTO = 0) THEN SUBTOTAL ELSE 0 END) AS GRAVADO, SUM(CASE WHEN IMPUESTO = 0 AND POR_IMPUESTO = 0 THEN SUBTOTAL ELSE 0 END) AS EXENTO,																						"
                SQL &= Chr(13) & "				0.00 AS EXONERADO, SUM(DESCUENTO) AS DESCUENTO, SUM(SUBTOTAL) AS SUBTOTAL, SUM(IMPUESTO) AS IMPUESTO, SUM(TOTAL) AS TOTAL																						"
                SQL &= Chr(13) & "				FROM APARTADO_DET																						"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "				AND NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT GUIA.NUMERO_GUIA, GUIA.ENVIA, GUIA.RETIRA, GUIA.DESCRIPCION AS DETALLE_GUIA, GUIA.VALOR_ENCOMIENDA AS VALOR																						"
                SQL &= Chr(13) & "				,substring(convert(char(8),ENC.FECHA_INC,114), 1, 8) AS HORA_INGRESO																						"
                SQL &= Chr(13) & "				, CASE WHEN convert(char(5), ENC.FECHA_INC, 108) <= '10:00' THEN '10:00' 																						"
                SQL &= Chr(13) & "				       WHEN convert(char(5), ENC.FECHA_INC, 108) > '10:00' AND  convert(char(5), ENC.FECHA_INC, 108) <= '14:30'  THEN '14:30'																						"
                SQL &= Chr(13) & "					   WHEN convert(char(5), ENC.FECHA_INC, 108) >= '14:30' AND convert(char(5), ENC.FECHA_INC, 108) <= '17:30' THEN '17:30' 																					"
                SQL &= Chr(13) & "					   ELSE '10:00' 																					"
                SQL &= Chr(13) & "					   END AS HORA_ENVIO																					"
                SQL &= Chr(13) & "				FROM DOCUMENTO_GUIA AS GUIA																						"
                SQL &= Chr(13) & "				INNER JOIN APARTADO_ENC AS ENC																						"
                SQL &= Chr(13) & "					ON ENC.COD_CIA = GUIA.COD_CIA																					"
                SQL &= Chr(13) & "					AND ENC.COD_SUCUR = GUIA.COD_SUCUR																					"
                SQL &= Chr(13) & "					AND ENC.TIPO_MOV = GUIA.TIPO_MOV																					"
                SQL &= Chr(13) & "					AND ENC.NUMERO_DOC = GUIA.NUMERO_DOC																					"
                SQL &= Chr(13) & "				WHERE GUIA.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND GUIA.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND GUIA.TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "				AND GUIA.NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "		END																								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_INVENTARIO_TMP_A_REAL()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_INVENTARIO_TMP_A_REAL", "2020-12-20") Then
                ELIMINA_PROCEDIMIENTO("USP_INVENTARIO_TMP_A_REAL")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_INVENTARIO_TMP_A_REAL] 																									"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																								"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																								"
                SQL &= Chr(13) & "		,@TIPO_MOV VARCHAR(2)																								"
                SQL &= Chr(13) & "		,@CODIGO VARCHAR(20)																								"
                SQL &= Chr(13) & "		AS																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			SET NOCOUNT ON;																							"
                SQL &= Chr(13) & "			BEGIN TRY																							"
                SQL &= Chr(13) & "			BEGIN TRAN TR_INVENTARIO_TMP_A_REAL																							"
                SQL &= Chr(13) & "			DECLARE @NUMERO_DOC INTEGER																							"
                SQL &= Chr(13) & "			DECLARE @FECHA_DOC AS DATETIME																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			IF NOT EXISTS(SELECT TMP.*																							"
                SQL &= Chr(13) & "				FROM INVENTARIO_ENC_TMP AS TMP																						"
                SQL &= Chr(13) & "				INNER JOIN INVENTARIO_DET_TMP AS DET	 																					"
                SQL &= Chr(13) & "		            ON DET.COD_CIA = TMP.COD_CIA 																								"
                SQL &= Chr(13) & "		            AND DET.COD_SUCUR = TMP.COD_SUCUR 																								"
                SQL &= Chr(13) & "		            AND DET.CODIGO = TMP.CODIGO 																								"
                SQL &= Chr(13) & "		            AND DET.TIPO_MOV = TMP.TIPO_MOV																								"
                SQL &= Chr(13) & "				WHERE TMP.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND TMP.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TMP.TIPO_MOV = 	@TIPO_MOV																					"
                SQL &= Chr(13) & "				AND TMP.CODIGO = @CODIGO)																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "					RAISERROR('El código de inventario no existe en los temporales', 17, 1)																					"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC =  ISNULL(MAX(NUMERO_DOC), 0) + 1 																						"
                SQL &= Chr(13) & "				FROM INVENTARIO_ENC																						"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				IF @TIPO_MOV = 'IN'																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				/*INGRESA EL ENCABEZADO*/																						"
                SQL &= Chr(13) & "				INSERT INTO INVENTARIO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,DESCRIPCION,COD_MOV)																						"
                SQL &= Chr(13) & "				SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,DESCRIPCION,COD_MOV																						"
                SQL &= Chr(13) & "				FROM INVENTARIO_ENC_TMP																						"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TIPO_MOV = 	@TIPO_MOV																					"
                SQL &= Chr(13) & "				AND CODIGO = @CODIGO																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				/*INGRESA EL DETALLE*/																						"
                SQL &= Chr(13) & "				INSERT INTO INVENTARIO_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,CANTIDAD,ESTANTE,FILA,COLUMNA)																						"
                SQL &= Chr(13) & "				SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,CANTIDAD,ESTANTE,FILA,COLUMNA																						"
                SQL &= Chr(13) & "				FROM INVENTARIO_DET_TMP																						"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND TIPO_MOV = 	@TIPO_MOV																					"
                SQL &= Chr(13) & "				AND CODIGO = @CODIGO																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				DELETE FROM INVENTARIO_ENC_TMP WHERE CODIGO = @CODIGO																						"
                SQL &= Chr(13) & "		        DELETE FROM INVENTARIO_DET_TMP WHERE CODIGO = @CODIGO																								"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "				SELECT @NUMERO_DOC AS Documento 																						"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "			COMMIT TRAN TR_INVENTARIO_TMP_A_REAL																							"
                SQL &= Chr(13) & "			END TRY																							"
                SQL &= Chr(13) & "			BEGIN CATCH 																							"
                SQL &= Chr(13) & "		 		ROLLBACK TRAN																						"
                SQL &= Chr(13) & "		 		DECLARE @MENSAJE VARCHAR(500)																						"
                SQL &= Chr(13) & "		 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																						"
                SQL &= Chr(13) & "		 		RAISERROR( @MENSAJE, 16, 1)																						"
                SQL &= Chr(13) & "			END CATCH																							"
                SQL &= Chr(13) & "		END																								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_COMPANIA_MANT()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_COMPANIA_MANT", "2021-06-05") Then
                ELIMINA_PROCEDIMIENTO("USP_COMPANIA_MANT")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_COMPANIA_MANT] 																									"
                SQL &= Chr(13) & "		    @COD_CIA VARCHAR(3),																								"
                SQL &= Chr(13) & "			@MODO INTEGER,																							"
                SQL &= Chr(13) & "			@NOMBRE VARCHAR(100) = NULL,																							"
                SQL &= Chr(13) & "			@CEDULA VARCHAR(25) = NULL,																							"
                SQL &= Chr(13) & "			@TIPO_CEDULA CHAR(2) = NULL,																							"
                SQL &= Chr(13) & "			@CORREO VARCHAR(150) = NULL,																							"
                SQL &= Chr(13) & "			@PROVINCIA VARCHAR(100) = NULL,																							"
                SQL &= Chr(13) & "			@CANTON VARCHAR(100) = NULL,																							"
                SQL &= Chr(13) & "			@DISTRITO VARCHAR(100) = NULL,																							"
                SQL &= Chr(13) & "			@ESTADO CHAR(1) = NULL,																							"
                SQL &= Chr(13) & "			@COD_PROVINCIA VARCHAR(10) = NULL,																							"
                SQL &= Chr(13) & "			@COD_DISTRITO VARCHAR(10) = NULL,																							"
                SQL &= Chr(13) & "			@COD_CANTON VARCHAR(10) = NULL,																							"
                SQL &= Chr(13) & "			@FE CHAR(1) = NULL,																							"
                SQL &= Chr(13) & "			@USUARIO_ATV VARCHAR(100) = NULL,																							"
                SQL &= Chr(13) & "			@CLAVE_ATV VARCHAR(100) = NULL,																							"
                SQL &= Chr(13) & "			@DIRECCION VARCHAR(255) = NULL,																							"
                SQL &= Chr(13) & "			@LINK_FT VARCHAR(255) = NULL,																							"
                SQL &= Chr(13) & "			@LINK_CONSULTAS VARCHAR(255) = NULL,																							"
                SQL &= Chr(13) & "			@IND_TIPO_DGTD CHAR(1) = NULL,																							"
                SQL &= Chr(13) & "			@IND_ENCOMIENDA CHAR(1) = NULL,																							"
                SQL &= Chr(13) & "			@IND_IMAGEN_TIQUETE CHAR(1) = NULL																							"
                SQL &= Chr(13) & "		AS   																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			IF @MODO = 1																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				INSERT INTO COMPANIA(COD_CIA,NOMBRE,CEDULA,TIPO_CEDULA,CORREO,DIRECCION,COD_PROVINCIA,PROVINCIA,COD_CANTON,CANTON,COD_DISTRITO,DISTRITO,ESTADO,FECHA_INC,FE,USUARIO_ATV,CLAVE_ATV,LINK_FT,LINK_CONSULTAS,IND_TIPO_DGTD,IND_ENCOMIENDA,IND_IMAGEN_TIQUETE) VALUES																						"
                SQL &= Chr(13) & "				(@COD_CIA,@NOMBRE,@CEDULA,@TIPO_CEDULA,@CORREO,@DIRECCION,@COD_PROVINCIA,@PROVINCIA,@COD_CANTON,@CANTON,@COD_DISTRITO,@DISTRITO,@ESTADO,GETDATE(),@FE,@USUARIO_ATV,@CLAVE_ATV,@LINK_FT,@LINK_CONSULTAS,@IND_TIPO_DGTD,@IND_ENCOMIENDA,@IND_IMAGEN_TIQUETE)																						"
                SQL &= Chr(13) & "			END																							"
                SQL &= Chr(13) & "			IF @MODO = 3																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				UPDATE COMPANIA SET																						"
                SQL &= Chr(13) & "					NOMBRE = @NOMBRE,																					"
                SQL &= Chr(13) & "					CEDULA = @CEDULA,																					"
                SQL &= Chr(13) & "					TIPO_CEDULA = @TIPO_CEDULA,																					"
                SQL &= Chr(13) & "					CORREO = @CORREO,																					"
                SQL &= Chr(13) & "					COD_PROVINCIA = @COD_PROVINCIA,																					"
                SQL &= Chr(13) & "					PROVINCIA = @PROVINCIA,																					"
                SQL &= Chr(13) & "					COD_CANTON = @COD_CANTON,																					"
                SQL &= Chr(13) & "					CANTON = @CANTON,																					"
                SQL &= Chr(13) & "					COD_DISTRITO = @COD_DISTRITO,																					"
                SQL &= Chr(13) & "					DISTRITO = @DISTRITO,																					"
                SQL &= Chr(13) & "					ESTADO = @ESTADO,																					"
                SQL &= Chr(13) & "					USUARIO_ATV = @USUARIO_ATV,																					"
                SQL &= Chr(13) & "					CLAVE_ATV = @CLAVE_ATV,																					"
                SQL &= Chr(13) & "					DIRECCION = @DIRECCION,																					"
                SQL &= Chr(13) & "					LINK_FT = @LINK_FT,																					"
                SQL &= Chr(13) & "					LINK_CONSULTAS = @LINK_CONSULTAS,																					"
                SQL &= Chr(13) & "					IND_TIPO_DGTD = @IND_TIPO_DGTD,																					"
                SQL &= Chr(13) & "					IND_ENCOMIENDA = @IND_ENCOMIENDA,																					"
                SQL &= Chr(13) & "					IND_IMAGEN_TIQUETE = @IND_IMAGEN_TIQUETE																					"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "			END																							"
                SQL &= Chr(13) & "			IF @MODO = 5																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				SELECT COD_CIA,NOMBRE,CEDULA,TIPO_CEDULA,CORREO,ISNULL(DIRECCION,'') AS DIRECCION,COD_PROVINCIA,PROVINCIA,COD_CANTON,CANTON,COD_DISTRITO,DISTRITO,ESTADO,FE,																						"
                SQL &= Chr(13) & "				ISNULL(PIN,'') AS PIN,																						"
                SQL &= Chr(13) & "				ISNULL(USUARIO_ATV,'') AS USUARIO_ATV,																						"
                SQL &= Chr(13) & "				ISNULL(CLAVE_ATV,'') AS CLAVE_ATV,																						"
                SQL &= Chr(13) & "				ISNULL(IND_TIPO_DGTD,'') AS IND_TIPO_DGTD,																						"
                SQL &= Chr(13) & "				ISNULL(IND_ENCOMIENDA,'') AS IND_ENCOMIENDA,																						"
                SQL &= Chr(13) & "				ISNULL(IND_IMAGEN_TIQUETE,'') AS IND_IMAGEN_TIQUETE,																					"
                SQL &= Chr(13) & "				CASE WHEN FECHA_INSTALACION IS NULL THEN 'Pendiente' ELSE 'Instalado' END AS ESTADO_CERT																						"
                SQL &= Chr(13) & "				FROM COMPANIA																						"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "			END																							"
                SQL &= Chr(13) & "		END																								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DOCUMENTOS_CON_SALDO_A_FECHA()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DOCUMENTOS_CON_SALDO_A_FECHA", "2021-01-09") Then
                ELIMINA_PROCEDIMIENTO("USP_DOCUMENTOS_CON_SALDO_A_FECHA")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DOCUMENTOS_CON_SALDO_A_FECHA] 																									"
                SQL &= Chr(13) & "	 @COD_CIA VARCHAR(3)																									"
                SQL &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)																									"
                SQL &= Chr(13) & "	,@TIPO_MOV VARCHAR(2)																									"
                SQL &= Chr(13) & "	,@FECHA_DESDE DATETIME																									"
                SQL &= Chr(13) & "	,@FECHA_HASTA DATETIME																									"
                SQL &= Chr(13) & "	AS																									"
                SQL &= Chr(13) & "	BEGIN																									"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																								"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "		SELECT ENC.NUMERO_DOC, CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' '+ CLI.APELLIDO2 AS CLIENTE, CONVERT(varchar(10), ENC.FECHA, 105) AS FECHA, 																								"
                SQL &= Chr(13) & "		CASE WHEN ENC.COD_MONEDA = 'L' THEN 'Local' ELSE 'Dólares' END AS MONEDA, ENC.TIPO_CAMBIO, ENC.MONTO, ENC.IMPUESTO, ENC.SALDO																								"
                SQL &= Chr(13) & "		FROM DOCUMENTO_ENC AS ENC																								"
                SQL &= Chr(13) & "		INNER JOIN CLIENTE AS CLI																								"
                SQL &= Chr(13) & "		ON CLI.COD_CIA = ENC.COD_CIA																								"
                SQL &= Chr(13) & "		AND CLI.CEDULA = ENC.CEDULA																								"
                SQL &= Chr(13) & "		WHERE ENC.COD_CIA = @COD_CIA																								"
                SQL &= Chr(13) & "		AND COD_SUCUR = @COD_SUCUR																								"
                SQL &= Chr(13) & "		AND TIPO_MOV = @TIPO_MOV																								"
                SQL &= Chr(13) & "		AND CONVERT(varchar(10), FECHA, 111) BETWEEN @FECHA_DESDE AND @FECHA_HASTA																								"
                SQL &= Chr(13) & "		AND ENC.SALDO > 1																								"
                SQL &= Chr(13) & "		ORDER BY ENC.NUMERO_DOC ASC																								"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	END																									"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DATOS_CXP_ANTIGUEDAD_SALDOS()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_CXP_ANTIGUEDAD_SALDOS", "2021-01-09") Then
                ELIMINA_PROCEDIMIENTO("USP_DATOS_CXP_ANTIGUEDAD_SALDOS")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_CXP_ANTIGUEDAD_SALDOS] 																									"
                SQL &= Chr(13) & "		@COD_CIA VARCHAR(3),																								"
                SQL &= Chr(13) & "		@COD_SUCUR VARCHAR(3),																								"
                SQL &= Chr(13) & "		@FECHA DATETIME,																								"
                SQL &= Chr(13) & "		@CEDULA VARCHAR(25)																								"
                SQL &= Chr(13) & "		AS   																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			BEGIN TRY																							"
                SQL &= Chr(13) & "			BEGIN TRAN TSN_CXP_ANTIGUEDAD_SALDOS																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			SELECT ENC.CEDULA, PROV.NOMBRE, ENC.FECHA, ENC.NUMERO_DOC, ENC.MONTO, ENC.IMPUESTO, ENC.SALDO, ENC.TIPO_CAMBIO, ENC.TIPO_MOV,																							"
                SQL &= Chr(13) & "			CASE WHEN ENC.COD_MONEDA = 'L' THEN 'Local' ELSE 'Dólares' END AS MONEDA																							"
                SQL &= Chr(13) & "			FROM CXP_DOCUMENTO_ENC AS ENC																							"
                SQL &= Chr(13) & "			INNER JOIN PROVEEDOR AS PROV																							"
                SQL &= Chr(13) & "				ON PROV.COD_CIA = ENC.COD_CIA																						"
                SQL &= Chr(13) & "				AND PROV.COD_SUCUR = ENC.COD_SUCUR																						"
                SQL &= Chr(13) & "				AND PROV.CEDULA = ENC.CEDULA																						"
                SQL &= Chr(13) & "			WHERE ENC.COD_CIA = @COD_CIA																							"
                SQL &= Chr(13) & "			AND ENC.COD_SUCUR = @COD_SUCUR																							"
                SQL &= Chr(13) & "			AND (ENC.CEDULA = @CEDULA OR @CEDULA = '')																							"
                SQL &= Chr(13) & "			AND TIPO_MOV IN ('FA', 'FC')																							"
                SQL &= Chr(13) & "			AND PROV.ESTADO = 'A'																							"
                SQL &= Chr(13) & "			AND CONVERT(varchar(10), ENC.FECHA, 111) <= @FECHA																							"
                SQL &= Chr(13) & "			AND ENC.SALDO > 0																							"
                SQL &= Chr(13) & "			ORDER BY PROV.NOMBRE ASC, ENC.FECHA ASC 																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "		COMMIT TRAN TSN_CXP_ANTIGUEDAD_SALDOS 																								"
                SQL &= Chr(13) & "		END TRY																								"
                SQL &= Chr(13) & "		BEGIN CATCH 																								"
                SQL &= Chr(13) & "			ROLLBACK TRAN																							"
                SQL &= Chr(13) & "			DECLARE @MENSAJE VARCHAR(500)																							"
                SQL &= Chr(13) & "			SET @MENSAJE =( SELECT ERROR_MESSAGE())																							"
                SQL &= Chr(13) & "			RAISERROR( @MENSAJE, 16, 1)																							"
                SQL &= Chr(13) & "		END CATCH																								"
                SQL &= Chr(13) & "		END																								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_MANT_FACTURACION_TMP()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_MANT_FACTURACION_TMP", "2021-06-09") Then
                ELIMINA_PROCEDIMIENTO("USP_MANT_FACTURACION_TMP")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_MANT_FACTURACION_TMP] 																																						"
                SQL &= Chr(13) & "		                	 @COD_CIA VARCHAR(3)																																				"
                SQL &= Chr(13) & "		                	,@COD_SUCUR VARCHAR(3)																																				"
                SQL &= Chr(13) & "		                	,@CODIGO VARCHAR(20) 																																				"
                SQL &= Chr(13) & "		                	,@TIPO_MOV VARCHAR(2) 																																				"
                SQL &= Chr(13) & "		                	,@CEDULA VARCHAR(25) 																																				"
                SQL &= Chr(13) & "		                	,@FECHA DATETIME 																																				"
                SQL &= Chr(13) & "		                	,@COD_USUARIO VARCHAR(8) 																																				"
                SQL &= Chr(13) & "		                	,@COD_MONEDA CHAR(1) 																																				"
                SQL &= Chr(13) & "		                	,@TIPO_CAMBIO MONEY																																				"
                SQL &= Chr(13) & "		                	,@PLAZO INT																																				"
                SQL &= Chr(13) & "		                	,@FORMA_PAGO CHAR(2)																																				"
                SQL &= Chr(13) & "		                	,@DESCRIPCION VARCHAR(250)																																				"
                SQL &= Chr(13) & "		                	,@COD_PROD VARCHAR(20)																																				"
                SQL &= Chr(13) & "		                	,@COD_UNIDAD VARCHAR(10)																																				"
                SQL &= Chr(13) & "		                	,@CANTIDAD MONEY																																				"
                SQL &= Chr(13) & "		                	,@PRECIO MONEY																																				"
                SQL &= Chr(13) & "		                	,@POR_DESCUENTO INT																																				"
                SQL &= Chr(13) & "		                	,@DESCUENTO MONEY																																				"
                SQL &= Chr(13) & "		                	,@POR_IMPUESTO INT																																				"
                SQL &= Chr(13) & "		                	,@IMPUESTO MONEY																																				"
                SQL &= Chr(13) & "							,@POR_EXO INT																																"
                SQL &= Chr(13) & "		                	,@EXONERACION MONEY																																				"
                SQL &= Chr(13) & "		                	,@SUBTOTAL MONEY																																				"
                SQL &= Chr(13) & "		                	,@TOTAL MONEY																																				"
                SQL &= Chr(13) & "							,@ESTANTE VARCHAR(3)																																"
                SQL &= Chr(13) & "							,@FILA VARCHAR(3)																																"
                SQL &= Chr(13) & "							,@COLUMNA VARCHAR(3)																																"
                SQL &= Chr(13) & "							,@IND_SUMAR_CANTIDAD CHAR(1)																																"
                SQL &= Chr(13) & "		                	,@MODO INT																																				"
                SQL &= Chr(13) & "		                	AS																																				"
                SQL &= Chr(13) & "		                	BEGIN																																				"
                SQL &= Chr(13) & "		                		SET NOCOUNT ON;																																			"
                SQL &= Chr(13) & "		                		BEGIN TRY																																			"
                SQL &= Chr(13) & "		                		BEGIN TRAN TR_MANT_FACTURACION																																			"
                SQL &= Chr(13) & "		                																																					"
                SQL &= Chr(13) & "		                		IF	@MODO = 1																																		"
                SQL &= Chr(13) & "		                		BEGIN																																			"
                SQL &= Chr(13) & "		                			IF NOT EXISTS(SELECT *																																		"
                SQL &= Chr(13) & "		                						  FROM DOCUMENTO_ENC_TMP																															"
                SQL &= Chr(13) & "		                						  WHERE COD_CIA = @COD_CIA																															"
                SQL &= Chr(13) & "		                                          AND COD_SUCUR = @COD_SUCUR																																					"
                SQL &= Chr(13) & "		                						  AND CODIGO = @CODIGO)																															"
                SQL &= Chr(13) & "		                			BEGIN																																		"
                SQL &= Chr(13) & "		                				INSERT INTO DOCUMENTO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION)																																	"
                SQL &= Chr(13) & "		                				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, @CEDULA, @FECHA, GETDATE(), @COD_USUARIO, @COD_MONEDA, @TIPO_CAMBIO, @PLAZO, @FORMA_PAGO,@DESCRIPCION																																	"
                SQL &= Chr(13) & "		                																																					"
                SQL &= Chr(13) & "		                				INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																																	"
                SQL &= Chr(13) & "		                				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA, @POR_EXO, @EXONERACION																																	"
                SQL &= Chr(13) & "		                				FROM DOCUMENTO_DET_TMP																																	"
                SQL &= Chr(13) & "		                				WHERE COD_CIA = @COD_CIA																																	"
                SQL &= Chr(13) & "										AND COD_SUCUR = @COD_SUCUR																													"
                SQL &= Chr(13) & "		                				AND CODIGO = @CODIGO 																																	"
                SQL &= Chr(13) & "		                			END																																		"
                SQL &= Chr(13) & "		                			ELSE																																		"
                SQL &= Chr(13) & "		                			BEGIN																																		"
                SQL &= Chr(13) & "		                				IF EXISTS(SELECT COD_PROD FROM DOCUMENTO_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)																																	"
                SQL &= Chr(13) & "		                				BEGIN																																	"
                SQL &= Chr(13) & "											IF @IND_SUMAR_CANTIDAD = 'S'																												"
                SQL &= Chr(13) & "											BEGIN																												"
                SQL &= Chr(13) & "												IF EXISTS(SELECT COD_PROD 																											"
                SQL &= Chr(13) & "														  FROM DOCUMENTO_DET_TMP 																									"
                SQL &= Chr(13) & "														  WHERE COD_CIA = @COD_CIA 																									"
                SQL &= Chr(13) & "														  AND COD_SUCUR = @COD_SUCUR 																									"
                SQL &= Chr(13) & "														  AND CODIGO = @CODIGO 																									"
                SQL &= Chr(13) & "														  AND COD_PROD = @COD_PROD																									"
                SQL &= Chr(13) & "														  AND PRECIO = @PRECIO																									"
                SQL &= Chr(13) & "														  AND POR_DESCUENTO = @POR_DESCUENTO																									"
                SQL &= Chr(13) & "														  AND POR_IMPUESTO = @POR_IMPUESTO)																									"
                SQL &= Chr(13) & "												BEGIN																											"
                SQL &= Chr(13) & "													UPDATE DOCUMENTO_DET_TMP																										"
                SQL &= Chr(13) & "		                							SET CANTIDAD = CANTIDAD + @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO																														"
                SQL &= Chr(13) & "													   ,DESCUENTO = (((CANTIDAD + @CANTIDAD) * PRECIO)* @POR_DESCUENTO) / 100																										"
                SQL &= Chr(13) & "		                							   ,POR_IMPUESTO = @POR_IMPUESTO																														"
                SQL &= Chr(13) & "													   ,IMPUESTO = (((CANTIDAD + @CANTIDAD) * PRECIO)* @POR_IMPUESTO) / 100																										"
                SQL &= Chr(13) & "													   ,SUBTOTAL = (((CANTIDAD + @CANTIDAD) * PRECIO) - ((((CANTIDAD + @CANTIDAD) * PRECIO)* @POR_DESCUENTO) / 100))																										"
                SQL &= Chr(13) & "													   ,TOTAL = (((CANTIDAD + @CANTIDAD) * PRECIO) - ((((CANTIDAD + @CANTIDAD) * PRECIO)* @POR_DESCUENTO) / 100)) + ((((CANTIDAD + @CANTIDAD) * PRECIO)* @POR_IMPUESTO) / 100)																										"
                SQL &= Chr(13) & "													   ,POR_EXONERACION = @POR_EXO																										"
                SQL &= Chr(13) & "													   ,EXONERACION = (((CANTIDAD + @CANTIDAD) * PRECIO)* @POR_EXO) / 100																										"
                SQL &= Chr(13) & "		                							WHERE COD_CIA = @COD_CIA																														"
                SQL &= Chr(13) & "		                							AND COD_SUCUR = @COD_SUCUR																														"
                SQL &= Chr(13) & "													AND CODIGO = @CODIGO																										"
                SQL &= Chr(13) & "		                							AND COD_PROD = @COD_PROD																														"
                SQL &= Chr(13) & "													AND PRECIO = @PRECIO																										"
                SQL &= Chr(13) & "													AND POR_DESCUENTO = @POR_DESCUENTO																										"
                SQL &= Chr(13) & "													AND POR_IMPUESTO = @POR_IMPUESTO																										"
                SQL &= Chr(13) & "												END																											"
                SQL &= Chr(13) & "												ELSE																											"
                SQL &= Chr(13) & "												BEGIN																											"
                SQL &= Chr(13) & "													INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																										"
                SQL &= Chr(13) & "		                							SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA, @POR_EXO, @EXONERACION																														"
                SQL &= Chr(13) & "		                							FROM DOCUMENTO_DET_TMP																														"
                SQL &= Chr(13) & "		                							WHERE COD_CIA = @COD_CIA																														"
                SQL &= Chr(13) & "													AND COD_SUCUR = @COD_SUCUR																										"
                SQL &= Chr(13) & "		                							AND CODIGO = @CODIGO 																														"
                SQL &= Chr(13) & "												END																											"
                SQL &= Chr(13) & "											END																												"
                SQL &= Chr(13) & "											ELSE																												"
                SQL &= Chr(13) & "											BEGIN																												"
                SQL &= Chr(13) & "												IF EXISTS(SELECT COD_PROD 																											"
                SQL &= Chr(13) & "														  FROM DOCUMENTO_DET_TMP 																									"
                SQL &= Chr(13) & "														  WHERE COD_CIA = @COD_CIA 																									"
                SQL &= Chr(13) & "														  AND COD_SUCUR = @COD_SUCUR 																									"
                SQL &= Chr(13) & "														  AND CODIGO = @CODIGO 																									"
                SQL &= Chr(13) & "														  AND COD_PROD = @COD_PROD																									"
                SQL &= Chr(13) & "														  AND PRECIO = @PRECIO																									"
                SQL &= Chr(13) & "														  AND POR_DESCUENTO = @POR_DESCUENTO																									"
                SQL &= Chr(13) & "														  AND POR_IMPUESTO = @POR_IMPUESTO)																									"
                SQL &= Chr(13) & "												BEGIN																											"
                SQL &= Chr(13) & "													UPDATE DOCUMENTO_DET_TMP																										"
                SQL &= Chr(13) & "		                							SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO																														"
                SQL &= Chr(13) & "		                							,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL																														"
                SQL &= Chr(13) & "													,POR_EXONERACION = @POR_EXO, EXONERACION = @EXONERACION																										"
                SQL &= Chr(13) & "		                							WHERE COD_CIA = @COD_CIA																														"
                SQL &= Chr(13) & "		                							AND COD_SUCUR = @COD_SUCUR																														"
                SQL &= Chr(13) & "													AND CODIGO = @CODIGO																										"
                SQL &= Chr(13) & "		                							AND COD_PROD = @COD_PROD																														"
                SQL &= Chr(13) & "													AND PRECIO = @PRECIO																										"
                SQL &= Chr(13) & "													AND POR_DESCUENTO = @POR_DESCUENTO																										"
                SQL &= Chr(13) & "													AND POR_IMPUESTO = @POR_IMPUESTO																										"
                SQL &= Chr(13) & "												END																											"
                SQL &= Chr(13) & "												ELSE																											"
                SQL &= Chr(13) & "												BEGIN																											"
                SQL &= Chr(13) & "													INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																										"
                SQL &= Chr(13) & "		                							SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA, @POR_EXO, @EXONERACION																														"
                SQL &= Chr(13) & "		                							FROM DOCUMENTO_DET_TMP																														"
                SQL &= Chr(13) & "		                							WHERE COD_CIA = @COD_CIA																														"
                SQL &= Chr(13) & "													AND COD_SUCUR = @COD_SUCUR																										"
                SQL &= Chr(13) & "		                							AND CODIGO = @CODIGO 																														"
                SQL &= Chr(13) & "												END																											"
                SQL &= Chr(13) & "											END                																												"
                SQL &= Chr(13) & "		                				END																																	"
                SQL &= Chr(13) & "		                				ELSE																																	"
                SQL &= Chr(13) & "		                				BEGIN																																	"
                SQL &= Chr(13) & "		                					INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																																"
                SQL &= Chr(13) & "		                					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA, @POR_EXO, @EXONERACION																																"
                SQL &= Chr(13) & "		                					FROM DOCUMENTO_DET_TMP																																"
                SQL &= Chr(13) & "		                					WHERE COD_CIA = @COD_CIA																																"
                SQL &= Chr(13) & "		                					AND COD_SUCUR = @COD_SUCUR																																"
                SQL &= Chr(13) & "		                                  And CODIGO = @CODIGO																																					"
                SQL &= Chr(13) & "		                				END																																	"
                SQL &= Chr(13) & "		                			END																																		"
                SQL &= Chr(13) & "		                		END																																			"
                SQL &= Chr(13) & "		                		ELSE IF @MODO = 3																																			"
                SQL &= Chr(13) & "		                		BEGIN																																			"
                SQL &= Chr(13) & "		                				IF EXISTS(SELECT COD_PROD FROM DOCUMENTO_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)																																	"
                SQL &= Chr(13) & "		                				BEGIN																																	"
                SQL &= Chr(13) & "		                					UPDATE DOCUMENTO_DET_TMP																																"
                SQL &= Chr(13) & "		                					SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO																																"
                SQL &= Chr(13) & "		                					   ,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL																																"
                SQL &= Chr(13) & "											   ,POR_EXONERACION = @POR_EXO, EXONERACION = @EXONERACION																												"
                SQL &= Chr(13) & "		                					WHERE COD_CIA = @COD_CIA 																																"
                SQL &= Chr(13) & "		                                  And COD_SUCUR = @COD_SUCUR																																					"
                SQL &= Chr(13) & "		                					AND CODIGO = @CODIGO 																																"
                SQL &= Chr(13) & "		                                  And COD_PROD = @COD_PROD																																					"
                SQL &= Chr(13) & "		                				END																																	"
                SQL &= Chr(13) & "		                				ELSE 																																	"
                SQL &= Chr(13) & "		                				BEGIN																																	"
                SQL &= Chr(13) & "		                					INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA,POR_EXONERACION,EXONERACION)																																"
                SQL &= Chr(13) & "		                					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL, @ESTANTE, @FILA, @COLUMNA, @POR_EXO, @EXONERACION																																"
                SQL &= Chr(13) & "		                					FROM DOCUMENTO_DET_TMP																																"
                SQL &= Chr(13) & "		                					WHERE COD_CIA = @COD_CIA																																"
                SQL &= Chr(13) & "		                                  And COD_SUCUR = @COD_SUCUR																																					"
                SQL &= Chr(13) & "		                					AND CODIGO = @CODIGO																																"
                SQL &= Chr(13) & "		                				END																																	"
                SQL &= Chr(13) & "		                		END																																			"
                SQL &= Chr(13) & "		                		COMMIT TRAN TR_MANT_FACTURACION 																																			"
                SQL &= Chr(13) & "		                		END TRY																																			"
                SQL &= Chr(13) & "		                		BEGIN CATCH 																																			"
                SQL &= Chr(13) & "		                	 		ROLLBACK TRAN																																		"
                SQL &= Chr(13) & "		                	 		DECLARE @MENSAJE VARCHAR(500)																																		"
                SQL &= Chr(13) & "		                	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())																																		"
                SQL &= Chr(13) & "		                	 		RAISERROR( @MENSAJE, 16, 1)																																		"
                SQL &= Chr(13) & "		                		END CATCH																																			"
                SQL &= Chr(13) & "		                	END																																				"


                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_INGRESA_DOCUMENTO_XML_CORREO()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_INGRESA_DOCUMENTO_XML_CORREO", "2021-05-28") Then
                ELIMINA_PROCEDIMIENTO("USP_INGRESA_DOCUMENTO_XML_CORREO")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_INGRESA_DOCUMENTO_XML_CORREO] 																									"
                SQL &= Chr(13) & "	@COD_CIA VARCHAR(3)																									"
                SQL &= Chr(13) & "	,@CLAVE VARCHAR(50)																									"
                SQL &= Chr(13) & "	,@CONSECUTIVO VARCHAR(20)																									"
                SQL &= Chr(13) & "	,@CEDULA VARCHAR(25) = ''																									"
                SQL &= Chr(13) & "	,@NOMBRE VARCHAR(100) = ''																									"
                SQL &= Chr(13) & "	,@XML VARCHAR(MAX)																									"
                SQL &= Chr(13) & "	AS																									"
                SQL &= Chr(13) & "	BEGIN																									"
                SQL &= Chr(13) & "	SET NOCOUNT ON;																									"
                SQL &= Chr(13) & "	BEGIN TRY																									"
                SQL &= Chr(13) & "	BEGIN TRAN TSN_XML_CORREO																									"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "		IF NOT EXISTS(																								"
                SQL &= Chr(13) & "			SELECT *																							"
                SQL &= Chr(13) & "			FROM CXP_DOCUMENTOS_ELECTRONICOS_CORREO																							"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																							"
                SQL &= Chr(13) & "			AND CLAVE = @CLAVE 																							"
                SQL &= Chr(13) & "			AND CEDULA = @CEDULA																							"
                SQL &= Chr(13) & "		)																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			INSERT INTO CXP_DOCUMENTOS_ELECTRONICOS_CORREO(COD_CIA,CLAVE,CONSECUTIVO,CEDULA,NOMBRE,XML)																							"
                SQL &= Chr(13) & "			SELECT @COD_CIA, @CLAVE, @CONSECUTIVO, @CEDULA, @NOMBRE, @XML																							"
                SQL &= Chr(13) & "		END																								"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "	COMMIT TRAN TSN_XML_CORREO 																									"
                SQL &= Chr(13) & "	END TRY																									"
                SQL &= Chr(13) & "	BEGIN CATCH 																									"
                SQL &= Chr(13) & "		ROLLBACK TRAN																								"
                SQL &= Chr(13) & "		DECLARE @MENSAJE VARCHAR(500)																								"
                SQL &= Chr(13) & "		SET @MENSAJE =( SELECT ERROR_MESSAGE())																								"
                SQL &= Chr(13) & "		RAISERROR( @MENSAJE, 16, 1)																								"
                SQL &= Chr(13) & "	END CATCH																									"
                SQL &= Chr(13) & "	END																									"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_GUARDAR_CERTIFICADO()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_GUARDAR_CERTIFICADO", "2021-06-06") Then

                ELIMINA_PROCEDIMIENTO("GUARDAR_CERTIFICADO")
                ELIMINA_PROCEDIMIENTO("USP_GUARDAR_CERTIFICADO")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_GUARDAR_CERTIFICADO] 																									"
                SQL &= Chr(13) & "		    @CERTIFICADO VARCHAR(MAX),   																								"
                SQL &= Chr(13) & "		    @PIN VARCHAR(50),   																								"
                SQL &= Chr(13) & "			@COD_CIA VARCHAR(3)  																							"
                SQL &= Chr(13) & "		AS   																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "		    SET NOCOUNT ON;  																								"
                SQL &= Chr(13) & "			UPDATE COMPANIA SET CERTIFICADO = @CERTIFICADO,PIN = @PIN,SUBJECT_CERT = NULL,HUELLA = NULL, FECHA_INSTALACION = NULL, PIN_ERRONEO = NULL																							"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																							"
                SQL &= Chr(13) & "		END																								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_RUTA_MANT()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_RUTA_MANT", "2021-06-05") Then

                ELIMINA_PROCEDIMIENTO("USP_RUTA_MANT")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_RUTA_MANT] 																									"
                SQL &= Chr(13) & "			@COD_CIA VARCHAR(3),																							"
                SQL &= Chr(13) & "		    @CODIGO VARCHAR(3),																								"
                SQL &= Chr(13) & "			@DESCRIPCION VARCHAR(200) = NULL,																							"
                SQL &= Chr(13) & "			@ESTADO CHAR(1) = 'A',																							"
                SQL &= Chr(13) & "			@COD_USUARIO VARCHAR(8) = NULL,																							"
                SQL &= Chr(13) & "			@TIPO CHAR(1) = NULL,																							"
                SQL &= Chr(13) & "			@MODO AS INTEGER																							"
                SQL &= Chr(13) & "		AS   																								"
                SQL &= Chr(13) & "		BEGIN																								"
                SQL &= Chr(13) & "			BEGIN TRY																							"
                SQL &= Chr(13) & "			BEGIN TRAN TSN_RUTA_MANT																							"
                SQL &= Chr(13) & "			IF @MODO = 1																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				IF NOT EXISTS(SELECT * FROM GUIA_UBICACION WHERE COD_UBICACION = @CODIGO)																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "					INSERT INTO GUIA_UBICACION(COD_CIA,COD_UBICACION,DESC_UBICACION,ESTADO,COD_USUARIO,FECHA_INC,IND_TIPO) VALUES																					"
                SQL &= Chr(13) & "					(@COD_CIA,@CODIGO,@DESCRIPCION,@ESTADO,@COD_USUARIO,GETDATE(),@TIPO)																					"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "				ELSE																						"
                SQL &= Chr(13) & "				BEGIN																						"
                SQL &= Chr(13) & "					RAISERROR('El codigo ingresado ya existe en la base de datos', 17, 1)																					"
                SQL &= Chr(13) & "				END																						"
                SQL &= Chr(13) & "			END																							"
                SQL &= Chr(13) & "			IF @MODO = 3																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				UPDATE GUIA_UBICACION SET																						"
                SQL &= Chr(13) & "					DESC_UBICACION = @DESCRIPCION,																					"
                SQL &= Chr(13) & "					ESTADO = @ESTADO,																					"
                SQL &= Chr(13) & "					COD_USUARIO = @COD_USUARIO,																					"
                SQL &= Chr(13) & "					IND_TIPO = @TIPO																					"
                SQL &= Chr(13) & "				WHERE COD_UBICACION = @CODIGO																						"
                SQL &= Chr(13) & "			END																							"
                SQL &= Chr(13) & "			IF @MODO = 5																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				SELECT *																						"
                SQL &= Chr(13) & "				FROM GUIA_UBICACION																						"
                SQL &= Chr(13) & "				WHERE COD_UBICACION = @CODIGO																						"
                SQL &= Chr(13) & "			END																							"
                SQL &= Chr(13) & "		COMMIT TRAN TSN_RUTA_MANT 																								"
                SQL &= Chr(13) & "		END TRY																								"
                SQL &= Chr(13) & "		BEGIN CATCH 																								"
                SQL &= Chr(13) & "		 	ROLLBACK TRAN																							"
                SQL &= Chr(13) & "		 	DECLARE @MENSAJE VARCHAR(500)																							"
                SQL &= Chr(13) & "		 	SET @MENSAJE =( SELECT ERROR_MESSAGE())																							"
                SQL &= Chr(13) & "		 	RAISERROR( @MENSAJE, 16, 1)																							"
                SQL &= Chr(13) & "		END CATCH																								"
                SQL &= Chr(13) & "		END																								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub USP_DATOS_FACTURA_ETIQUETA()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_FACTURA_ETIQUETA", "2021-06-07") Then

                ELIMINA_PROCEDIMIENTO("USP_DATOS_FACTURA_ETIQUETA")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_FACTURA_ETIQUETA] 																									"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																								"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																								"
                SQL &= Chr(13) & "		,@NUMERO_DOC INT																								"
                SQL &= Chr(13) & "		,@TIPO_MOV VARCHAR(2)																								"
                SQL &= Chr(13) & "	AS																									"
                SQL &= Chr(13) & "	BEGIN																									"
                SQL &= Chr(13) & "		SET NOCOUNT ON																								"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			DECLARE @cnt INT = 1																							"
                SQL &= Chr(13) & "			DECLARE @BULTOS INT = 0																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			SET @BULTOS = (SELECT CANT_BULTOS																							"
                SQL &= Chr(13) & "							FROM DOCUMENTO_GUIA																			"
                SQL &= Chr(13) & "							WHERE COD_CIA = @COD_CIA																			"
                SQL &= Chr(13) & "							AND COD_SUCUR = @COD_SUCUR																			"
                SQL &= Chr(13) & "							AND NUMERO_DOC = @NUMERO_DOC																			"
                SQL &= Chr(13) & "							AND TIPO_MOV = @TIPO_MOV)																			"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			CREATE TABLE #TEMPORAL(																							"
                SQL &= Chr(13) & "			NUMERO_GUIA VARCHAR(13), 																							"
                SQL &= Chr(13) & "			RETIRA VARCHAR(300),																							"
                SQL &= Chr(13) & "			ENVIA VARCHAR(300),																							"
                SQL &= Chr(13) & "			TELEFONO VARCHAR(10), 																							"
                SQL &= Chr(13) & "			CANT_BULTOS INT, 																							"
                SQL &= Chr(13) & "			CONTADOR INT,																							"
                SQL &= Chr(13) & "			DESC_UBICACION VARCHAR(300),																							"
                SQL &= Chr(13) & "			LETRA VARCHAR(300)																							"
                SQL &= Chr(13) & "			)																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			WHILE @cnt <= @BULTOS																							"
                SQL &= Chr(13) & "			BEGIN																							"
                SQL &= Chr(13) & "				INSERT INTO #TEMPORAL																						"
                SQL &= Chr(13) & "				SELECT NUMERO_GUIA , RETIRA AS RETIRA																						"
                SQL &= Chr(13) & "				,ENVIA AS ENVIA, TELEFONO_RETIRA AS TELEFONO, GUIA.CANT_BULTOS																						"
                SQL &= Chr(13) & "				,@cnt AS CONTADOR, UBI.DESC_UBICACION																						"
                SQL &= Chr(13) & "				,CASE WHEN CHARINDEX(' ', RETIRA) > 0 THEN CASE WHEN CHARINDEX('REP', RETIRA) > 0 THEN SUBSTRING(RETIRA,CHARINDEX(' ', RETIRA) + 1, LEN(RETIRA)) ELSE SUBSTRING(RETIRA, CHARINDEX(' ', RETIRA) + 1 , CHARINDEX(' ', RETIRA)) END ELSE RETIRA END AS LETRA																						"
                SQL &= Chr(13) & "				FROM DOCUMENTO_GUIA AS GUIA																						"
                SQL &= Chr(13) & "				INNER JOIN GUIA_UBICACION AS UBI																						"
                SQL &= Chr(13) & "					ON UBI.COD_CIA = GUIA.COD_CIA																					"
                SQL &= Chr(13) & "					AND UBI.COD_UBICACION = GUIA.DESTINO																					"
                SQL &= Chr(13) & "				WHERE GUIA.COD_CIA = @COD_CIA																						"
                SQL &= Chr(13) & "				AND GUIA.COD_SUCUR = @COD_SUCUR																						"
                SQL &= Chr(13) & "				AND GUIA.NUMERO_DOC = @NUMERO_DOC																						"
                SQL &= Chr(13) & "				AND GUIA.TIPO_MOV = @TIPO_MOV																						"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			   SET @cnt = @cnt + 1;																							"
                SQL &= Chr(13) & "			END																							"
                SQL &= Chr(13) & "																										"
                SQL &= Chr(13) & "			SELECT *																							"
                SQL &= Chr(13) & "			FROM #TEMPORAL																							"
                SQL &= Chr(13) & "	END																									"


                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Alters campos"

    Private Sub ALTER_SMTP_CONFIG_CONTRASENA()
        Try
            If Not EXISTE_CAMPO_TIPO("CONTRASENA", "SMTP_CONFIG", "VARCHAR", 100) Then
                Dim SQL = "	ALTER TABLE SMTP_CONFIG	"
                SQL &= Chr(13) & "	ALTER COLUMN CONTRASENA VARCHAR(100) NOT NULL "
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ALTER_COMPANIA_CERTIFICADO()
        Try
            If EXISTE_CAMPO_TIPO("CERTIFICADO", "COMPANIA", "VARBINARY") Then
                Dim SQL = "	ALTER TABLE COMPANIA	"
                SQL &= Chr(13) & "	ALTER COLUMN CERTIFICADO VARCHAR(MAX) NULL "
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ALTER_GUIA_UBICACION()
        Try
            If EXISTE_CAMPO_TIPO("COD_SUCUR", "GUIA_UBICACION", "VARCHAR") Then
                Dim SQL = "	ALTER TABLE GUIA_UBICACION	"
                SQL &= Chr(13) & "	DROP COLUMN COD_SUCUR "
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()

                CONSTRAINT_PK_GUIA_UBICACION_CREAR()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ALTER_DOCUMENTO_GUIA_NUMERO_GUIA()
        Try
            If Not EXISTE_CAMPO_TIPO("NUMERO_GUIA", "DOCUMENTO_GUIA", "VARCHAR", 13) Then
                Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA	"
                SQL &= Chr(13) & "	ALTER COLUMN NUMERO_GUIA VARCHAR(13) NOT NULL "
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ALTER_DOCUMENTO_GUIA_UBICACION_NUMERO_GUIA()
        Try
            If Not EXISTE_CAMPO_TIPO("NUMERO_GUIA", "DOCUMENTO_GUIA_UBICACION", "VARCHAR", 13) Then
                CONX.Coneccion_Abrir()

                Dim SQL = "	ALTER TABLE DOCUMENTO_GUIA_UBICACION	"
                SQL &= Chr(13) & "	ALTER COLUMN NUMERO_GUIA VARCHAR(13) NOT NULL "
                CONX.EJECUTE(SQL)

                SQL = "	ALTER TABLE DOCUMENTO_GUIA_UBICACION																						"
                SQL &= Chr(13) & "	ADD CONSTRAINT PK_DOCUMENTO_GUIA_UBICACION PRIMARY KEY (COD_CIA, COD_SUCUR, NUMERO_DOC, TIPO_MOV, NUMERO_GUIA, COD_UBICACION)																						"
                CONX.EJECUTE(SQL)

                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CXP_DOCUMENTOS_ELECTRONICOS_DET_CABYS()
        Try
            If Not EXISTE_CAMPO_TIPO("CABYS", "CXP_DOCUMENTOS_ELECTRONICOS_DET", "VARCHAR", 13) Then
                Dim SQL = "	ALTER TABLE CXP_DOCUMENTOS_ELECTRONICOS_DET	"
                SQL &= Chr(13) & "	ADD CABYS VARCHAR(13) NULL "
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Tipos"
    Private Sub TP_PRODUCTO_CABYS()
        Try
            If Not EXISTE_TIPO("TP_PRODUCTO_CABYS") Then

                Dim SQL = "	CREATE TYPE [dbo].[TP_PRODUCTO_CABYS] AS TABLE(						"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,							"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](150) NOT NULL,						"
                SQL &= Chr(13) & "		[COD_CABYS] [varchar](13) NOT NULL								"
                SQL &= Chr(13) & "	)										"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Procesos especiales anidados"

    Private Sub PROC_ESPECIAL_USP_PROCESA_DOCUMENTOS_XML()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_PROCESA_DOCUMENTOS_XML", "2021-06-25") Then
                ELIMINA_PROCEDIMIENTO("USP_PROCESA_DOCUMENTOS_XML")

                CONX.Coneccion_Abrir()

                Dim SQL = "	DROP TYPE [dbo].[TP_CXP_DOCUMENTOS_ELECTRONICOS]"
                CONX.EJECUTE(SQL)

                SQL = "	CREATE TYPE [dbo].[TP_CXP_DOCUMENTOS_ELECTRONICOS] AS TABLE(																									"
                SQL &= Chr(13) & "		[CLAVE] [varchar](50) NOT NULL,																								"
                SQL &= Chr(13) & "		[CONSECUTIVO_P] [varchar](20) NOT NULL,																								"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] [varchar](2) NOT NULL,																								"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,																								"
                SQL &= Chr(13) & "		[PLAZO] [int] NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_MONEDA] [char](1) NOT NULL,																								"
                SQL &= Chr(13) & "		[TOTAL_VENTA] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[DESCUENTO] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[OTROS_CARGOS] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[TOTAL] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[TIPO_CAMBIO] [money] NULL,																								"
                SQL &= Chr(13) & "		[IND_ESTADO] [char](1) NOT NULL,																								"
                SQL &= Chr(13) & "		[COD_ACT_ECO] [varchar](6) NULL,																								"
                SQL &= Chr(13) & "		[TIPO_INGRESO] [varchar](2) NULL,																								"
                SQL &= Chr(13) & "		[CONDICION_IVA] [varchar](2) NOT NULL,																								"
                SQL &= Chr(13) & "		[POR_IMPUESTO] [int] NULL,																								"
                SQL &= Chr(13) & "		[IMP_ACREDITAR] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[GASTO_APLICABLE] [money] NOT NULL,																								"
                SQL &= Chr(13) & "		[DETALLE_MENSAJE] [varchar](160) NULL,																								"
                SQL &= Chr(13) & "		[XML] [varchar](max) NOT NULL																								"
                SQL &= Chr(13) & "	)																									"
                CONX.EJECUTE(SQL)


                SQL = "	DROP TYPE [dbo].[TP_CXP_DOCUMENTOS_ELECTRONICOS_DET]"
                CONX.EJECUTE(SQL)

                SQL = " CREATE TYPE [dbo].[TP_CXP_DOCUMENTOS_ELECTRONICOS_DET] As TABLE(																									"
                SQL &= Chr(13) & "		[CLAVE] [varchar](50) Not NULL,																								"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) Not NULL,																								"
                SQL &= Chr(13) & "		[TIPO_MOV] [varchar](2) Not NULL,																								"
                SQL &= Chr(13) & "		[LINEA] [int] Not NULL,																								"
                SQL &= Chr(13) & "		[TIPO] [varchar](2) NULL,																								"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NULL,																								"
                SQL &= Chr(13) & "		[CANTIDAD] [decimal](16, 3) NULL,																								"
                SQL &= Chr(13) & "		[DETALLE] [varchar](200) NULL,																								"
                SQL &= Chr(13) & "		[PRECIO_UNITARIO] [decimal](18, 5) NULL,																								"
                SQL &= Chr(13) & "		[MONTO_SINIV] [decimal](18, 5) NULL,																								"
                SQL &= Chr(13) & "		[MONTO_DESCUENTO] [decimal](18, 5) NULL,																								"
                SQL &= Chr(13) & "		[CODIGO_IMP] [varchar](2) NULL,																								"
                SQL &= Chr(13) & "		[TARIFA] [decimal](4, 2) NULL,																								"
                SQL &= Chr(13) & "		[MONTO_IMP] [decimal](18, 5) NULL,																								"
                SQL &= Chr(13) & "		[NETO_IMP] [decimal](18, 5) NULL,																								"
                SQL &= Chr(13) & "		[TIPO_EXO] [varchar](2) NULL,																								"
                SQL &= Chr(13) & "		[NUMERO_EXO] [varchar](40) NULL,																								"
                SQL &= Chr(13) & "		[PORCENTAJE_EXO] [int] NULL,																								"
                SQL &= Chr(13) & "		[MONTO_EXO] [decimal](18, 5) NULL,																								"
                SQL &= Chr(13) & "		[MONTO_TOTAL_LINEA] [decimal](18, 5) NULL,																								"
                SQL &= Chr(13) & "		[CABYS] [varchar] (13) NULL																								"
                SQL &= Chr(13) & "	)																									"
                CONX.EJECUTE(SQL)

                SQL = "	CREATE PROCEDURE [dbo].[USP_PROCESA_DOCUMENTOS_XML]																																																																	"
                SQL &= Chr(13) & "			@DT_DOCUMENTOS As TP_CXP_DOCUMENTOS_ELECTRONICOS ReadOnly,																																																															"
                SQL &= Chr(13) & "			@DT_DOCUMENTOS_DET As TP_CXP_DOCUMENTOS_ELECTRONICOS_DET ReadOnly,																																																															"
                SQL &= Chr(13) & "			@COD_CIA VARCHAR(3),																																																															"
                SQL &= Chr(13) & "			@COD_SUCUR VARCHAR(3),																																																															"
                SQL &= Chr(13) & "			@USUARIO VARCHAR(20)																																																															"
                SQL &= Chr(13) & "			As																																																															"
                SQL &= Chr(13) & "			    BEGIN																																																															"
                SQL &= Chr(13) & "			    BEGIN Try 																																																															"
                SQL &= Chr(13) & "			    BEGIN TRAN																																																															"
                SQL &= Chr(13) & "		                			                			               		                																																																								"
                SQL &= Chr(13) & "					CREATE TABLE #TP_CXP_DOCUMENTOS_ELECTRONICOS(																																																													"
                SQL &= Chr(13) & "					[CLAVE] [varchar](50) Not NULL,																																																													"
                SQL &= Chr(13) & "					[CONSECUTIVO_P] [varchar](20) Not NULL,																																																													"
                SQL &= Chr(13) & "					[CEDULA] [varchar](25) Not NULL,																																																													"
                SQL &= Chr(13) & "					[TIPO_MOV] [varchar](2) Not NULL,																																																													"
                SQL &= Chr(13) & "					[FECHA] [datetime] Not NULL,																																																													"
                SQL &= Chr(13) & "					[PLAZO] [int] Not NULL,																																																													"
                SQL &= Chr(13) & "					[COD_MONEDA] [char](1) Not NULL,																																																													"
                SQL &= Chr(13) & "					[TOTAL_VENTA] [money] Not NULL,																																																													"
                SQL &= Chr(13) & "					[DESCUENTO] [money] Not NULL,																																																													"
                SQL &= Chr(13) & "					[OTROS_CARGOS] [money] Not NULL,																																																													"
                SQL &= Chr(13) & "					[IMPUESTO] [money] Not NULL,																																																													"
                SQL &= Chr(13) & "					[TOTAL] [money] Not NULL,																																																													"
                SQL &= Chr(13) & "					[TIPO_CAMBIO] [money] NULL,																																																													"
                SQL &= Chr(13) & "					[IND_ESTADO] [char](1) Not NULL,																																																													"
                SQL &= Chr(13) & "					[COD_ACT_ECO] [varchar](6) NULL,																																																													"
                SQL &= Chr(13) & "					[TIPO_INGRESO] [varchar](2) NULL,																																																													"
                SQL &= Chr(13) & "					[CONDICION_IVA] [varchar](2) Not NULL,																																																													"
                SQL &= Chr(13) & "					[POR_IMPUESTO] [int] NULL,																																																													"
                SQL &= Chr(13) & "					[IMP_ACREDITAR] [money] Not NULL,																																																													"
                SQL &= Chr(13) & "					[GASTO_APLICABLE] [money] Not NULL,																																																													"
                SQL &= Chr(13) & "					[DETALLE_MENSAJE] [varchar](160) NULL,																																																													"
                SQL &= Chr(13) & "					[XML] [varchar](max) Not NULL)																																																													"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "					CREATE TABLE #TP_CXP_DOCUMENTOS_ELECTRONICOS_DET(																																																													"
                SQL &= Chr(13) & "					[CLAVE] [varchar](50) Not NULL,																																																													"
                SQL &= Chr(13) & "					[CEDULA] [varchar](25) Not NULL,																																																													"
                SQL &= Chr(13) & "					[TIPO_MOV] [varchar](2) Not NULL,																																																													"
                SQL &= Chr(13) & "					[LINEA] [integer] Not NULL,																																																													"
                SQL &= Chr(13) & "					[TIPO] [varchar](2) NULL,																																																													"
                SQL &= Chr(13) & "					[CODIGO] [varchar](20) NULL,																																																													"
                SQL &= Chr(13) & "					[CANTIDAD] [decimal](16,3) NULL,																																																													"
                SQL &= Chr(13) & "					[DETALLE] [varchar](200) NULL,																																																													"
                SQL &= Chr(13) & "					[PRECIO_UNITARIO] [decimal](18,5) NULL,																																																													"
                SQL &= Chr(13) & "					[MONTO_SINIV] [decimal](18,5) NULL,																																																													"
                SQL &= Chr(13) & "					[MONTO_DESCUENTO] [decimal](18,5) NULL,																																																													"
                SQL &= Chr(13) & "					[CODIGO_IMP] [varchar](2) NULL,																																																													"
                SQL &= Chr(13) & "					[TARIFA] [decimal](4,2) NULL,																																																													"
                SQL &= Chr(13) & "					[MONTO_IMP] [decimal](18,5)  NULL,																																																													"
                SQL &= Chr(13) & "					[NETO_IMP] [decimal](18,5)  NULL,																																																													"
                SQL &= Chr(13) & "					[TIPO_EXO] [varchar](2) NULL,																																																													"
                SQL &= Chr(13) & "					[NUMERO_EXO] [varchar](40) NULL,																																																													"
                SQL &= Chr(13) & "					[PORCENTAJE_EXO] [int] NULL,																																																													"
                SQL &= Chr(13) & "					[MONTO_EXO] [decimal](18,5) NULL,																																																													"
                SQL &= Chr(13) & "					[MONTO_TOTAL_LINEA] [decimal](18,5) NULL,																																																												"
                SQL &= Chr(13) & "		            [CABYS] [varchar] (13) NULL																								"
                SQL &= Chr(13) & "	                )																									"
                SQL &= Chr(13) & "			                			                			                			               		                																																																				"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "			        INSERT INTO  #TP_CXP_DOCUMENTOS_ELECTRONICOS																																																															"
                SQL &= Chr(13) & "					Select * FROM @DT_DOCUMENTOS																																																													"
                SQL &= Chr(13) & "			                			                																																																												"
                SQL &= Chr(13) & "					INSERT INTO  #TP_CXP_DOCUMENTOS_ELECTRONICOS_DET																																																													"
                SQL &= Chr(13) & "					Select * FROM @DT_DOCUMENTOS_DET  																																																													"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "					Declare @CONSEC VARCHAR(20)																																																													"
                SQL &= Chr(13) & "					Declare @CONSEC_FE As Integer																																																													"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "					Set @CONSEC = @COD_SUCUR --CASA MATRIZ																																																													"
                SQL &= Chr(13) & "					Set @CONSEC += '00001' --TERMINAL 																																																													"
                SQL &= Chr(13) & "					SET @CONSEC += (SELECT CASE WHEN DOC.IND_ESTADO ='A' THEN '05' WHEN DOC.IND_ESTADO ='R' THEN '07' WHEN DOC.IND_ESTADO ='P' THEN '06' END --ESTADO DEL DOCUMENTO																																																													"
                SQL &= Chr(13) & "					FROM @DT_DOCUMENTOS AS DOC)																																																													"
                SQL &= Chr(13) & "					SET @CONSEC_FE = (SELECT ISNULL(MAX(CONSECUTIVO_FE)+1,1) FROM CXP_DOCUMENTOS_ELECTRONICOS WHERE COD_CIA=@COD_CIA AND COD_SUCUR = @COD_SUCUR)--ULTIMO CONSECUTIVO																																																													"
                SQL &= Chr(13) & "					SET @CONSEC += RIGHT('0000000000'+convert(varchar,@CONSEC_FE),10) --AGREGANDO 0 A LA IZQUIERDA																																																													"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "					IF NOT EXISTS (																																																													"
                SQL &= Chr(13) & "					SELECT  * 																																																													"
                SQL &= Chr(13) & "					FROM @DT_DOCUMENTOS AS DOC																																																													"
                SQL &= Chr(13) & "					INNER JOIN CXP_DOCUMENTOS_ELECTRONICOS AS ELEC																																																													"
                SQL &= Chr(13) & "						ON ELEC.COD_CIA = @COD_CIA																																																												"
                SQL &= Chr(13) & "						AND ELEC.CLAVE = DOC.CLAVE																																																												"
                SQL &= Chr(13) & "						AND ELEC.TIPO_MOV = DOC.TIPO_MOV																																																												"
                SQL &= Chr(13) & "						AND ELEC.CEDULA = DOC.CEDULA)																																																												"
                SQL &= Chr(13) & "						BEGIN																																																												"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "							INSERT INTO CXP_DOCUMENTOS_ELECTRONICOS(COD_CIA,COD_SUCUR,CLAVE,CONSECUTIVO,CONSECUTIVO_FE,CONSECUTIVO_P,CEDULA,TIPO_MOV,FECHA,FECHA_INC,PLAZO,COD_MONEDA,TOTAL_VENTA,DESCUENTO,OTROS_CARGOS,IMPUESTO,TOTAL,TIPO_CAMBIO,IND_ESTADO,COD_ACT_ECO,CONDICION_IVA,POR_IMPUESTO,IMP_ACREDITAR,GASTO_APLICABLE,DETALLE_MENSAJE,COD_USUARIO,XML,TIPO_INGRESO)																																																											"
                SQL &= Chr(13) & "							SELECT @COD_CIA,@COD_SUCUR,DOC.CLAVE,@CONSEC,@CONSEC_FE,DOC.CONSECUTIVO_P,DOC.CEDULA,DOC.TIPO_MOV,DOC.FECHA,GETDATE(),DOC.PLAZO,DOC.COD_MONEDA,DOC.TOTAL_VENTA,DOC.DESCUENTO,DOC.OTROS_CARGOS,DOC.IMPUESTO,DOC.TOTAL,DOC.TIPO_CAMBIO,DOC.IND_ESTADO,DOC.COD_ACT_ECO,DOC.CONDICION_IVA,DOC.POR_IMPUESTO,DOC.IMP_ACREDITAR,DOC.TOTAL - ISNULL(DOC.IMP_ACREDITAR,0),DOC.DETALLE_MENSAJE,@USUARIO,DOC.XML,DOC.TIPO_INGRESO																																																											"
                SQL &= Chr(13) & "							FROM @DT_DOCUMENTOS AS DOC																																																											"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "							INSERT INTO CXP_DOCUMENTOS_ELECTRONICOS_DET(COD_CIA,COD_SUCUR,CEDULA,CLAVE,TIPO_MOV,LINEA,TIPO,CODIGO,CANTIDAD,DETALLE,PRECIO_UNITARIO,MONTO_SINIV,MONTO_DESCUENTO,CODIGO_IMP,TARIFA,MONTO_IMP,NETO_IMP,TIPO_EXO,NUMERO_EXO,PORCENTAJE_EXO,MONTO_EXO,MONTO_TOTAL_LINEA,CABYS)																																																											"
                SQL &= Chr(13) & "							SELECT @COD_CIA,@COD_SUCUR,DET.CEDULA,DET.CLAVE,DET.TIPO_MOV,DET.LINEA,DET.TIPO,DET.CODIGO,DET.CANTIDAD,DET.DETALLE,DET.PRECIO_UNITARIO,DET.MONTO_SINIV,DET.MONTO_DESCUENTO,DET.CODIGO_IMP,DET.TARIFA,DET.MONTO_IMP,DET.NETO_IMP,DET.TIPO_EXO,DET.NUMERO_EXO,DET.PORCENTAJE_EXO,DET.MONTO_EXO,DET.MONTO_TOTAL_LINEA,DET.CABYS																																																											"
                SQL &= Chr(13) & "							FROM @DT_DOCUMENTOS_DET AS DET																																																											"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "						END	   																																																											"
                SQL &= Chr(13) & "					ELSE																																																													"
                SQL &= Chr(13) & "						BEGIN																																																												"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "							DECLARE @CLAVE AS VARCHAR(50)																																																											"
                SQL &= Chr(13) & "							DECLARE @TIPO_MOV AS VARCHAR(50)																																																											"
                SQL &= Chr(13) & "							DECLARE @CEDULA AS VARCHAR(25)																																																											"
                SQL &= Chr(13) & "							SELECT @CEDULA = CEDULA,@TIPO_MOV =TIPO_MOV,@CLAVE = CLAVE																																																											"
                SQL &= Chr(13) & "							FROM CXP_DOCUMENTOS_ELECTRONICOS																																																											"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "							DELETE FROM CXP_DOCUMENTOS_ELECTRONICOS_DET																																																											"
                SQL &= Chr(13) & "							WHERE COD_CIA = @COD_CIA																																																											"
                SQL &= Chr(13) & "							AND CLAVE = @CLAVE																																																											"
                SQL &= Chr(13) & "							AND TIPO_MOV = @TIPO_MOV																																																											"
                SQL &= Chr(13) & "							AND CEDULA = @CEDULA																																																											"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "							DELETE FROM CXP_DOCUMENTOS_ELECTRONICOS																																																											"
                SQL &= Chr(13) & "							WHERE COD_CIA = @COD_CIA																																																											"
                SQL &= Chr(13) & "							AND CLAVE = @CLAVE																																																											"
                SQL &= Chr(13) & "							AND TIPO_MOV = @TIPO_MOV																																																											"
                SQL &= Chr(13) & "							AND CEDULA = @CEDULA																																																											"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "							INSERT INTO CXP_DOCUMENTOS_ELECTRONICOS(COD_CIA,COD_SUCUR,CLAVE,CONSECUTIVO,CONSECUTIVO_FE,CONSECUTIVO_P,CEDULA,TIPO_MOV,FECHA,FECHA_INC,PLAZO,COD_MONEDA,TOTAL_VENTA,DESCUENTO,OTROS_CARGOS,IMPUESTO,TOTAL,TIPO_CAMBIO,IND_ESTADO,COD_ACT_ECO,CONDICION_IVA,POR_IMPUESTO,IMP_ACREDITAR,GASTO_APLICABLE,DETALLE_MENSAJE,COD_USUARIO,XML,TIPO_INGRESO)																																																											"
                SQL &= Chr(13) & "							SELECT @COD_CIA,@COD_SUCUR,DOC.CLAVE,@CONSEC,@CONSEC_FE,DOC.CONSECUTIVO_P,DOC.CEDULA,DOC.TIPO_MOV,DOC.FECHA,GETDATE(),DOC.PLAZO,DOC.COD_MONEDA,DOC.TOTAL_VENTA,DOC.DESCUENTO,DOC.OTROS_CARGOS,DOC.IMPUESTO,DOC.TOTAL,DOC.TIPO_CAMBIO,DOC.IND_ESTADO,DOC.COD_ACT_ECO,DOC.CONDICION_IVA,DOC.POR_IMPUESTO,DOC.IMP_ACREDITAR,DOC.GASTO_APLICABLE,DOC.DETALLE_MENSAJE,@USUARIO,DOC.XML,DOC.TIPO_INGRESO																																																											"
                SQL &= Chr(13) & "							FROM @DT_DOCUMENTOS AS DOC																																																											"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "							INSERT INTO CXP_DOCUMENTOS_ELECTRONICOS_DET(COD_CIA,COD_SUCUR,CEDULA,CLAVE,TIPO_MOV,LINEA,TIPO,CODIGO,CANTIDAD,DETALLE,PRECIO_UNITARIO,MONTO_SINIV,MONTO_DESCUENTO,CODIGO_IMP,TARIFA,MONTO_IMP,NETO_IMP,TIPO_EXO,NUMERO_EXO,PORCENTAJE_EXO,MONTO_EXO,MONTO_TOTAL_LINEA,CABYS)																																																											"
                SQL &= Chr(13) & "							SELECT @COD_CIA,@COD_SUCUR,DET.CEDULA,DET.CLAVE,DET.TIPO_MOV,DET.LINEA,DET.TIPO,DET.CODIGO,DET.CANTIDAD,DET.DETALLE,DET.PRECIO_UNITARIO,DET.MONTO_SINIV,DET.MONTO_DESCUENTO,DET.CODIGO_IMP,DET.TARIFA,DET.MONTO_IMP,DET.NETO_IMP,DET.TIPO_EXO,DET.NUMERO_EXO,DET.PORCENTAJE_EXO,DET.MONTO_EXO,DET.MONTO_TOTAL_LINEA,DET.CABYS																																																											"
                SQL &= Chr(13) & "							FROM @DT_DOCUMENTOS_DET AS DET																																																											"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "						END																																																												"
                SQL &= Chr(13) & "																																																																		"
                SQL &= Chr(13) & "			COMMIT TRAN																																																															"
                SQL &= Chr(13) & "			END TRY																																																															"
                SQL &= Chr(13) & "			BEGIN CATCH																																																															"
                SQL &= Chr(13) & "			    ROLLBACK TRAN																																																															"
                SQL &= Chr(13) & "			    DECLARE @MENSAJE VARCHAR(500)																																																															"
                SQL &= Chr(13) & "			    SET @MENSAJE =( SELECT ERROR_MESSAGE())																																																															"
                SQL &= Chr(13) & "			    RAISERROR( @MENSAJE, 16, 1);																																																															"
                SQL &= Chr(13) & "			END CATCH																																																															"
                SQL &= Chr(13) & "			END																																																															"
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Derechos"
    Private Sub PROCESAR_DERECHOS()
        Try
            If Not EXISTE_DERECHO("DCIA") Then
                CREAR_DERECHO("DCIA", "Derecho al mantenimiento de compañías")
            End If

            If Not EXISTE_DERECHO("DSUC") Then
                CREAR_DERECHO("DSUC", "Derecho al mantenimiento de sucursales")
            End If

            If Not EXISTE_DERECHO("DUSU") Then
                CREAR_DERECHO("DUSU", "Derecho al mantenimiento de usuarios")
            End If

            If Not EXISTE_DERECHO("DCLI") Then
                CREAR_DERECHO("DCLI", "Derecho al mantenimiento de clientes")
            End If

            If Not EXISTE_DERECHO("DPROV") Then
                CREAR_DERECHO("DPROV", "Derecho al mantenimiento de proveedores")
            End If

            If Not EXISTE_DERECHO("DFAM") Then
                CREAR_DERECHO("DFAM", "Derecho al mantenimiento de familias")
            End If

            If Not EXISTE_DERECHO("DPROD") Then
                CREAR_DERECHO("DPROD", "Derecho al mantenimiento de productos")
            End If

            If Not EXISTE_DERECHO("DVEN") Then
                CREAR_DERECHO("DVEN", "Derecho a realizar ventas")

            End If

            If Not EXISTE_DERECHO("DCOMP") Then
                CREAR_DERECHO("DCOMP", "Derecho a realizar compras")
            End If

            If Not EXISTE_DERECHO("DBACK") Then
                CREAR_DERECHO("DBACK", "Derecho a realizar Backups")
            End If

            If Not EXISTE_DERECHO("DREPT") Then
                CREAR_DERECHO("DREPT", "Derecho a realizar reportes")
            End If

            If Not EXISTE_DERECHO("DENC") Then
                CREAR_DERECHO("DENC", "Derecho al mantenimiento de encomiendas")
            End If

            If Not EXISTE_DERECHO("DCONS") Then
                CREAR_DERECHO("DCONS", "Derecho a realizar consultas de productos")
            End If

            If Not EXISTE_DERECHO("DXML") Then
                CREAR_DERECHO("DXML", "Derecho a importar XMLs")
            End If

            If Not EXISTE_DERECHO("DINV") Then
                CREAR_DERECHO("DINV", "Derecho a la pantalla de inventario")
            End If

            If Not EXISTE_DERECHO("DBITA") Then
                CREAR_DERECHO("DBITA", "Derecho a realizar consultas de bitácoras")
            End If

            If Not EXISTE_DERECHO("APART") Then
                CREAR_DERECHO("APART", "Derecho a anular documentos")
            End If

            If Not EXISTE_DERECHO("DAPAR") Then
                CREAR_DERECHO("DAPAR", "Derecho a realizar apartados")
            End If

            If Not EXISTE_DERECHO("DINRUTA") Then
                CREAR_DERECHO("DINRUTA", "Derecho al mantenimiento de rutas de encomienda")
            End If

            If Not EXISTE_DERECHO("DINVAJ") Then
                CREAR_DERECHO("DINVAJ", "Derecho a realizar ajustes de inventario")
            End If

            If Not EXISTE_DERECHO("DINVTR") Then
                CREAR_DERECHO("DINVTR", "Derecho a revisar el tracking de inventario para un producto")
            End If

            If Not EXISTE_DERECHO("DPROFOR") Then
                CREAR_DERECHO("DPROFOR", "Derecho a realizar proformas")
            End If

            If Not EXISTE_DERECHO("DRIMPETI") Then
                CREAR_DERECHO("DRIMPETI", "Derecho a reimprimir etiquetas de encomiendas")
            End If

            If Not EXISTE_DERECHO("FECREP") Then
                CREAR_DERECHO("FECREP", "Derecho a modificar las fechas de los reportes")
            End If

            If Not EXISTE_DERECHO("VFACTS") Then
                CREAR_DERECHO("VFACTS", "Derecho a realizar facturas y notas de débito")
            End If

            If Not EXISTE_DERECHO("VREB") Then
                CREAR_DERECHO("VREB", "Derecho a realizar recibos y notas de crédito")
            End If

            If Not EXISTE_DERECHO("DRFACDOC") Then
                CREAR_DERECHO("DRFACDOC", "Derecho a facturar documento por cobrar")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

End Class