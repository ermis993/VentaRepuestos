Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Actualizaciones
    Public Sub ACTUALIZACIONES(ByRef ProgressBar As ProgressBar)

        'IMPORTATE SIEMPRE ACTUALIZAR LA CANTIDAD DE PROCESOS
        'ESTO POR SI SE AGREGA UNA CREACION DE TABLA, PROCEDIMIENTO, TRIGGER, O CAMPO EN UN TABLA
        'EL PROCESO SERIA: CANTIDAD_PROCESOS = CANTIDAD DE MÉTODOS A EJECUTAR
        'CANTIDAD ACTUAL: ACTUALIZAR SIEMPRE CON LA CANTIDAD DE MÉTODOS QUE SE EJECUTARON

        Dim Cantidad_Procesos As Integer = 34
        Dim Cantidad_Actual As Integer = 0
        ProgressBar.Value = 0

        'TABLAS
        Call APARTADO_ENC()
        Call APARTADO_DET()
        Call APARTADO_ENC_TMP()
        Call APARTADO_DET_TMP()
        Call SUCURSAL_INDICADORES()
        Call PRODUCTO_RELACION()
        Call CXP_DOCUMENTO_AFEC()
        Call CXP_DOCUMENTO_AFEC_DET_TMP()

        Cantidad_Actual += 8
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'CAMPOS EN TABLAS
        Call PRODUCTO_COD_FAMILIA()
        Call PRODUCTO_OBSERVACION()
        Call PRODUCTO_IND_PRECIO_MODIFICABLE()
        Call SUCURSAL_ETIQUETA()
        Call DOCUMENTO_GUIA_CAMPOS()
        Call INVENTARIO_MOV_SISTEMA()
        Call INVENTARIO_MOV_DET_SISTEMA()

        Cantidad_Actual += 7
        ActualizaProgressBar(ProgressBar, Cantidad_Actual, Cantidad_Procesos)

        'TRIGGERS
        Call TG_INGRESA_INVENTARIO_APARTADO_ENC()
        Call TG_INGRESA_INVENTARIO_APARTADO_DET()
        Call TG_INGRESA_INVENTARIO_MOV_CXP_ENC()
        Call TG_INGRESA_INVENTARIO_MOV_CXP_DET()
        Call TG_INGRESA_INVENTARIO_MOV_ENC()
        Call TG_INGRESA_INVENTARIO_MOV_DET()

        Cantidad_Actual += 6
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

        Cantidad_Actual += 13
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

#End Region

#Region "Triggers"
    Private Sub TG_INGRESA_INVENTARIO_APARTADO_ENC()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_APARTADO_ENC", "2020-10-07") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_APARTADO_ENC")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_APARTADO_ENC] 																				"
                SQL &= Chr(13) & "	   ON  [dbo].[APARTADO_ENC] 																				"
                SQL &= Chr(13) & "	   AFTER INSERT																				"
                SQL &= Chr(13) & "	AS 																				"
                SQL &= Chr(13) & "	BEGIN																				"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																			"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "		DECLARE @TIPO_NOTA VARCHAR(2), @TIPO_MOV VARCHAR(2)																			"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "		SELECT  @TIPO_NOTA = TIPO_NOTA, @TIPO_MOV = TIPO_MOV 																			"
                SQL &= Chr(13) & "		FROM inserted																			"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "		IF @TIPO_NOTA IS NULL																			"
                SQL &= Chr(13) & "		BEGIN																			"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "			INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC)																		"
                SQL &= Chr(13) & "			SELECT COD_CIA, COD_SUCUR, CASE TIPO_NOTA WHEN 'DV' THEN 'EPD' ELSE 'SPV' END AS COD_MOV, CEDULA, TIPO_MOV, NUMERO_DOC, COD_USUARIO, FECHA_INC																		"
                SQL &= Chr(13) & "			FROM inserted 																		"
                SQL &= Chr(13) & "			WHERE TIPO_MOV IN ('AA', 'AC')																		"
                SQL &= Chr(13) & "		END																			"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "	END																				"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TG_INGRESA_INVENTARIO_APARTADO_DET()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_APARTADO_DET", "2020-10-07") Then
                ELIMINA_TRIGGER("TG_INGRESA_INVENTARIO_APARTADO_DET")

                Dim SQL = "	CREATE TRIGGER [dbo].[TG_INGRESA_INVENTARIO_APARTADO_DET] 																				"
                SQL &= Chr(13) & "	   ON  [dbo].[APARTADO_DET] 																				"
                SQL &= Chr(13) & "	   AFTER INSERT																				"
                SQL &= Chr(13) & "	AS 																				"
                SQL &= Chr(13) & "	BEGIN																				"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																			"
                SQL &= Chr(13) & "																					"
                SQL &= Chr(13) & "		INSERT INTO INVENTARIO_MOV_DET(COD_CIA,COD_SUCUR,NUMERO_MOV,COD_MOV,LINEA,COD_PROD,CANTIDAD,COSTO,COSTO_ANT,ESTANTE,FILA,COLUMNA)																			"
                SQL &= Chr(13) & "		SELECT I.COD_CIA, I.COD_SUCUR, MOV.NUMERO_MOV, MOV.COD_MOV, I.LINEA, I.COD_PROD, I.CANTIDAD * CASE SUBSTRING(MOV.COD_MOV,1,1) WHEN  'S' THEN -1 ELSE 1 END, PROD.COSTO, PROD.COSTO, I.ESTANTE, I.FILA, I.COLUMNA																			"
                SQL &= Chr(13) & "		FROM inserted AS I																			"
                SQL &= Chr(13) & "		INNER JOIN INVENTARIO_MOV AS MOV																			"
                SQL &= Chr(13) & "			ON MOV.COD_CIA = I.COD_CIA																		"
                SQL &= Chr(13) & "			AND MOV.COD_SUCUR = I.COD_SUCUR																		"
                SQL &= Chr(13) & "			AND MOV.NUMERO_DOC = I.NUMERO_DOC																		"
                SQL &= Chr(13) & "			AND MOV.TIPO_MOV = I.TIPO_MOV																		"
                SQL &= Chr(13) & "		INNER JOIN PRODUCTO AS PROD																			"
                SQL &= Chr(13) & "			ON PROD.COD_CIA = I.COD_CIA																		"
                SQL &= Chr(13) & "			AND PROD.COD_PROD = I.COD_PROD																		"
                SQL &= Chr(13) & "	END																				"

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
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_CXP_DET", "2020-10-13") Then
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
                SQL &= Chr(13) & "			AND MOV.SISTEMA = 'CXP'																				"
                SQL &= Chr(13) & "		INNER JOIN PRODUCTO AS PROD																					"
                SQL &= Chr(13) & "			ON PROD.COD_CIA = I.COD_CIA																				"
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
                SQL &= Chr(13) & "				WHERE P.COSTO <> D.PRECIO																			"
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
                SQL &= Chr(13) & "				WHERE P.COSTO <> D.PRECIO																			"
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

    Private Sub TG_INGRESA_INVENTARIO_MOV_DET()
        Try
            If Not EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_DET", "2020-10-12") Then
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
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_IMP_ENCOMIENDA_POR_FECHA", "2020-10-08") Then
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
            If Not EXISTE_PROCEDIMIENTO("USP_FACTURACION_TMP_A_REAL", "2020-10-08") Then
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
                SQL &= Chr(13) & "			SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO, SUM(DET.SUBTOTAL), SUM(DET.IMPUESTO), SUM(DET.TOTAL),TMP.COD_MONEDA																				"
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
            If Not EXISTE_PROCEDIMIENTO("USP_SUCURSAL_INDICADORES_MANT", "2020-10-07") Then
                ELIMINA_PROCEDIMIENTO("USP_SUCURSAL_INDICADORES_MANT")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_SUCURSAL_INDICADORES_MANT]																						"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@IND_PERMITE_VENTAS_NEGATIVO CHAR(1) = 'N'																					"
                SQL &= Chr(13) & "		,@MODO INT = 0																					"
                SQL &= Chr(13) & "		AS																					"
                SQL &= Chr(13) & "		BEGIN																					"
                SQL &= Chr(13) & "			IF @MODO = 1 OR @MODO = 3																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "			IF NOT EXISTS(SELECT *																				"
                SQL &= Chr(13) & "					  FROM SUCURSAL_INDICADORES																		"
                SQL &= Chr(13) & "					  WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "					  AND COD_SUCUR = @COD_SUCUR)																		"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "					INSERT INTO SUCURSAL_INDICADORES(COD_CIA,COD_SUCUR,IND_PERMITE_VENTAS_NEGATIVO)																		"
                SQL &= Chr(13) & "					SELECT @COD_CIA, @COD_SUCUR, @IND_PERMITE_VENTAS_NEGATIVO																		"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			ELSE																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "					UPDATE SUCURSAL_INDICADORES																		"
                SQL &= Chr(13) & "					SET IND_PERMITE_VENTAS_NEGATIVO = @IND_PERMITE_VENTAS_NEGATIVO																		"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA																		"
                SQL &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR																		"
                SQL &= Chr(13) & "			END																				"
                SQL &= Chr(13) & "			END 																				"
                SQL &= Chr(13) & "			ELSE IF @MODO = 5  																				"
                SQL &= Chr(13) & "			BEGIN																				"
                SQL &= Chr(13) & "				SELECT *																			"
                SQL &= Chr(13) & "				FROM SUCURSAL_INDICADORES																			"
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

    Private Sub USP_MANT_PRODUCTO()
        Try
            If Not EXISTE_PROCEDIMIENTO("USP_MANT_PRODUCTO", "2020-10-11") Then
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
                SQL &= Chr(13) & "						INSERT INTO PRODUCTO(COD_CIA,COD_SUCUR,COD_PROD,CEDULA,DESCRIPCION,COD_UNIDAD,COSTO,POR_IMPUESTO,COD_IMPUESTO_DGTD,PRECIO, PRECIO_2, PRECIO_3,EXENTO,ESTADO,MINIMO,COD_BARRA,FECHA_INC,COD_FAMILIA,OBSERVACION,IND_PRECIO_MODIFICABLE)																	"
                SQL &= Chr(13) & "						SELECT @COD_CIA, @COD_SUCUR, @COD_PROD, @CEDULA, @DESCRIPCION, @COD_UNIDAD, @COSTO, @POR_IMPUESTO, @COD_IMPUESTO, @PRECIO, @PRECIO_2, @PRECIO_3, @EXENTO, @ESTADO, @MINIMO, @COD_BARRA, GETDATE(), @COD_FAMILIA, @OBSERVACION, @IND_PRECIO_MODIFICABLE																	"
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
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_RECIBO_IMPRESION", "2020-10-08") Then
                ELIMINA_PROCEDIMIENTO("USP_DATOS_RECIBO_IMPRESION")

                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_DATOS_RECIBO_IMPRESION] 																						"
                SQL &= Chr(13) & "		 @COD_CIA VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@COD_SUCUR VARCHAR(3)																					"
                SQL &= Chr(13) & "		,@NUMERO_DOC INT																					"
                SQL &= Chr(13) & "		,@TIPO_MOV VARCHAR(2)																					"
                SQL &= Chr(13) & "	AS																						"
                SQL &= Chr(13) & "	BEGIN																						"
                SQL &= Chr(13) & "		SET NOCOUNT ON;																					"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT CIA.NOMBRE AS Compania, SUC.NOMBRE AS Sucursal, CIA.CEDULA AS Cedula, SUC.TELEFONO + CASE WHEN ISNULL(SUC.TELEFONO_2, '') = '' THEN '' ELSE '/' + TELEFONO_2 END AS Telefono, CIA.PROVINCIA AS Provincia,																				"
                SQL &= Chr(13) & "			CIA.CANTON AS Canton, CIA.DISTRITO AS Distrito, SUC.DIRECCION AS Direccion, CIA.CORREO as Correo																				"
                SQL &= Chr(13) & "			FROM COMPANIA AS CIA																				"
                SQL &= Chr(13) & "			INNER JOIN SUCURSAL AS SUC																				"
                SQL &= Chr(13) & "				ON SUC.COD_CIA = CIA.COD_CIA																			"
                SQL &= Chr(13) & "			WHERE CIA.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND SUC.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT 'RECIBO DE DINERO' AS TIPO, ENC.NUMERO_DOC AS Numero, ENC.FECHA, CASE WHEN ENC.FORMA_PAGO = 'EF' THEN 'EFECTIVO' WHEN ENC.FORMA_PAGO = 'TA' THEN 'TARJETA' ELSE 'TRANSFERENCIA' END AS VENTA,																				"
                SQL &= Chr(13) & "			(CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2) AS NOMBRE, U.NOMBRE AS USUARIO, CASE WHEN ENC.COD_MONEDA = 'L' THEN 'COLONES' ELSE 'DOLARES' END AS MONEDA, ISNULL(ENC.DESCRIPCION, '') AS DETALLE																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_ENC AS ENC																				"
                SQL &= Chr(13) & "			INNER JOIN CLIENTE AS CLI																				"
                SQL &= Chr(13) & "				ON CLI.COD_CIA = ENC.COD_CIA																			"
                SQL &= Chr(13) & "				AND CLI.CEDULA = ENC.CEDULA																			"
                SQL &= Chr(13) & "			INNER JOIN USUARIO AS U																				"
                SQL &= Chr(13) & "				ON U.COD_USUARIO = ENC.COD_USUARIO																			"
                SQL &= Chr(13) & "			WHERE ENC.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND ENC.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND ENC.TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "			AND ENC.NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT AFEC.NUMERO_DOC_AFEC, TIPO_MOV_AFEC, CONVERT(VARCHAR(10), ENC.FECHA, 103) AS FECHA, ((ENC.MONTO + ENC.IMPUESTO) - SUM(ISNULL(T1.MONTO, 0))) AS SALDO_ANTERIOR, MONTO_AFEC																				"
                SQL &= Chr(13) & "			, ((ENC.MONTO + ENC.IMPUESTO) - SUM(ISNULL(T1.MONTO, 0))) - MONTO_AFEC AS NUEVO_SALDO																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_AFEC AS AFEC																				"
                SQL &= Chr(13) & "			INNER JOIN DOCUMENTO_ENC AS ENC																				"
                SQL &= Chr(13) & "				ON ENC.COD_CIA = AFEC.COD_CIA																			"
                SQL &= Chr(13) & "				AND ENC.COD_SUCUR = AFEC.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = AFEC.TIPO_MOV_AFEC																			"
                SQL &= Chr(13) & "				AND ENC.NUMERO_DOC = AFEC.NUMERO_DOC_AFEC																			"
                SQL &= Chr(13) & "			LEFT JOIN(																				"
                SQL &= Chr(13) & "				SELECT COD_CIA, COD_SUCUR, NUMERO_DOC, NUMERO_DOC_AFEC, TIPO_MOV, SUM(MONTO_AFEC) AS MONTO, FECHA																			"
                SQL &= Chr(13) & "				FROM DOCUMENTO_AFEC																			"
                SQL &= Chr(13) & "				GROUP BY COD_CIA, COD_SUCUR, NUMERO_DOC, NUMERO_DOC_AFEC, TIPO_MOV, FECHA																			"
                SQL &= Chr(13) & "				) AS T1																			"
                SQL &= Chr(13) & "				ON T1.COD_CIA = AFEC.COD_CIA																			"
                SQL &= Chr(13) & "				AND T1.COD_SUCUR = AFEC.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND T1.TIPO_MOV = AFEC.TIPO_MOV																			"
                SQL &= Chr(13) & "				AND T1.NUMERO_DOC_AFEC = AFEC.NUMERO_DOC_AFEC																			"
                SQL &= Chr(13) & "				AND T1.NUMERO_DOC < AFEC.NUMERO_DOC																			"
                SQL &= Chr(13) & "			WHERE AFEC.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND AFEC.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND AFEC.TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "			AND AFEC.NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "			GROUP BY AFEC.NUMERO_DOC_AFEC, TIPO_MOV_AFEC, ENC.FECHA, MONTO_AFEC, ENC.MONTO, ENC.IMPUESTO																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT COUNT(AFEC.NUMERO_DOC_AFEC) AS DOCS_AFEC, (ENC.MONTO + ENC.IMPUESTO) AS MR, SUM(AFEC.MONTO_AFEC) AS MU, ENC.SALDO AS SR																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_AFEC AS AFEC																				"
                SQL &= Chr(13) & "			INNER JOIN DOCUMENTO_ENC AS ENC																				"
                SQL &= Chr(13) & "				ON ENC.COD_CIA = AFEC.COD_CIA																			"
                SQL &= Chr(13) & "				AND ENC.COD_SUCUR = AFEC.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = AFEC.TIPO_MOV																			"
                SQL &= Chr(13) & "				AND ENC.NUMERO_DOC = AFEC.NUMERO_DOC																			"
                SQL &= Chr(13) & "			WHERE AFEC.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND AFEC.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND AFEC.TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "			AND AFEC.NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "			GROUP BY ENC.MONTO, ENC.IMPUESTO, ENC.SALDO																				"
                SQL &= Chr(13) & "	END																						"
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
            If Not EXISTE_PROCEDIMIENTO("USP_DATOS_FACTURA_IMPRESION", "2020-10-12") Then
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
                SQL &= Chr(13) & "			SELECT CASE DE.TIPO_COMPROBANTE WHEN '01' THEN 'FACTURA ELECTRONICA' WHEN '04' THEN 'TIQUETE ELECTRONICO' END AS TIPO, DE.CONSECUTIVO AS Consec,																				"
                SQL &= Chr(13) & "			DE.NUMERO_DOC AS Numero, 'CLAVE NUMERICA' AS CLAVE_S, DE.CLAVE AS Clave, ENC.FECHA, CASE WHEN ENC.TIPO_MOV = 'FC' THEN 'CONTADO' ELSE 'CREDITO' END AS VENTA,																				"
                SQL &= Chr(13) & "			(CLI.NOMBRE + ' ' + CLI.APELLIDO1 + ' ' + CLI.APELLIDO2) AS Nombre, U.NOMBRE AS Usuario, CASE WHEN ENC.COD_MONEDA = 'L' THEN 'COLONES' ELSE 'DOLARES' END AS MONEDA,																				"
                SQL &= Chr(13) & "			ENC.DESCRIPCION AS DETALLE																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_ELECTRONICO AS DE																				"
                SQL &= Chr(13) & "			INNER JOIN DOCUMENTO_ENC AS ENC																				"
                SQL &= Chr(13) & "				ON ENC.COD_CIA = DE.COD_CIA																			"
                SQL &= Chr(13) & "				AND ENC.COD_SUCUR = DE.COD_SUCUR																			"
                SQL &= Chr(13) & "				AND ENC.TIPO_MOV = DE.TIPO_MOV 																			"
                SQL &= Chr(13) & "				AND ENC.NUMERO_DOC = DE.NUMERO_DOC																			"
                SQL &= Chr(13) & "			INNER JOIN CLIENTE AS CLI																				"
                SQL &= Chr(13) & "				ON CLI.COD_CIA = ENC.COD_CIA																			"
                SQL &= Chr(13) & "				AND CLI.CEDULA = ENC.CEDULA																			"
                SQL &= Chr(13) & "			INNER JOIN USUARIO AS U																				"
                SQL &= Chr(13) & "				ON U.COD_USUARIO = ENC.COD_USUARIO																			"
                SQL &= Chr(13) & "			WHERE DE.COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND DE.COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND DE.TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "			AND DE.NUMERO_DOC = @NUMERO_DOC																				"
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
                SQL &= Chr(13) & "			SELECT COUNT(*) AS LINEAS, SUM(CASE WHEN IMPUESTO > 0 THEN SUBTOTAL ELSE 0 END) AS GRAVADO, SUM(CASE WHEN IMPUESTO = 0 THEN SUBTOTAL ELSE 0 END) AS EXENTO,																				"
                SQL &= Chr(13) & "			0.00 AS EXONERADO, SUM(DESCUENTO) AS DESCUENTO, SUM(SUBTOTAL) AS SUBTOTAL, SUM(IMPUESTO) AS IMPUESTO, SUM(TOTAL) AS TOTAL																				"
                SQL &= Chr(13) & "			FROM DOCUMENTO_DET																				"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND TIPO_MOV = @TIPO_MOV																				"
                SQL &= Chr(13) & "			AND NUMERO_DOC = @NUMERO_DOC																				"
                SQL &= Chr(13) & "																							"
                SQL &= Chr(13) & "			SELECT GUIA.NUMERO_GUIA, GUIA.ENVIA, GUIA.RETIRA, GUIA.DESCRIPCION AS DETALLE_GUIA, GUIA.VALOR_ENCOMIENDA AS VALOR																				"
                SQL &= Chr(13) & "			,substring(convert(char(8),ENC.FECHA_INC,114), 1, 8) AS HORA_INGRESO																				"
                SQL &= Chr(13) & "			, CASE WHEN convert(char(5), ENC.FECHA_INC, 108) <= '10:00' THEN '10:00' 																				"
                SQL &= Chr(13) & "			       WHEN convert(char(5), ENC.FECHA_INC, 108) > '10:00' AND  convert(char(5), ENC.FECHA_INC, 108) <= '14:30'  THEN '14:30'																				"
                SQL &= Chr(13) & "				   WHEN convert(char(5), ENC.FECHA_INC, 108) >= '14:30' AND convert(char(5), ENC.FECHA_INC, 108) <= '17:30' THEN '17:30' 																			"
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
            If Not EXISTE_PROCEDIMIENTO("USP_CXP_FACTURACION_TMP_A_REAL", "2020-10-11") Then
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
                SQL &= Chr(13) & "			INSERT INTO CXP_DOCUMENTO_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA)																				"
                SQL &= Chr(13) & "			SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL,ESTANTE,FILA,COLUMNA																				"
                SQL &= Chr(13) & "			FROM CXP_DOCUMENTO_DET_TMP																				"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA																				"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR																				"
                SQL &= Chr(13) & "			AND CODIGO = @CODIGO																				"
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

#End Region
#End Region
End Class