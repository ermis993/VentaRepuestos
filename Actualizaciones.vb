Imports FUN_CRFUSION.FUNCIONES_GENERALES
Imports VentaRepuestos.Globales
Public Class Actualizaciones
    Public Shared Sub ACTUALIZACIONES()
        CREACION_TABLAS()
        CREACION_STORED_PROCEDURE()
        CREACION_TRIGGERS()
    End Sub
    Public Shared Sub CREACION_TABLAS()
        CREACION_TABLA_COMPANIA_20200208()
    End Sub
#Region "STORED PROCEDURES"
    Public Shared Sub CREACION_STORED_PROCEDURE()
        USP_SUCURSAL_MANTENIMIENTO_20200209()
    End Sub
    Public Shared Sub USP_SUCURSAL_MANTENIMIENTO_20200209()
        Try
            If EXISTE_SP("USP_SUCURSAL_MANTENIMIENTO", "2020-02-09") = False Then
                If EXISTE_SP("USP_SUCURSAL_MANTENIMIENTO", "", False) = True Then
                    DROP_PROCEDURE("USP_SUCURSAL_MANTENIMIENTO")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_SUCURSAL_MANTENIMIENTO]	"
                SQL &= Chr(13) & "	 @COD_CIA VARCHAR(3)		"
                SQL &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)		"
                SQL &= Chr(13) & "	,@NOMBRE VARCHAR(100) = ''		"
                SQL &= Chr(13) & "	,@DIRECCION VARCHAR(250) = ''		"
                SQL &= Chr(13) & "	,@TELEFONO VARCHAR(8) = ''		"
                SQL &= Chr(13) & "	,@CORREO VARCHAR(150) = ''	"
                SQL &= Chr(13) & "	,@ESTADO CHAR(1) = ''		"
                SQL &= Chr(13) & "	,@MODO INT		"
                SQL &= Chr(13) & "	AS		"
                SQL &= Chr(13) & "	BEGIN		"
                SQL &= Chr(13) & "		IF @MODO = 1	"
                SQL &= Chr(13) & "		BEGIN	"
                SQL &= Chr(13) & "			INSERT INTO SUCURSAL(COD_CIA,COD_SUCUR,NOMBRE,DIRECCION,TELEFONO,CORREO,FECHA_INC)"
                SQL &= Chr(13) & "			SELECT @COD_CIA, @COD_SUCUR, @NOMBRE, @DIRECCION, @TELEFONO, @CORREO, GETDATE()"
                SQL &= Chr(13) & "		END	"
                SQL &= Chr(13) & "		ELSE IF @MODO = 3	"
                SQL &= Chr(13) & "		BEGIN	"
                SQL &= Chr(13) & "			UPDATE SUCURSAL"
                SQL &= Chr(13) & "			SET NOMBRE = @NOMBRE, DIRECCION = @DIRECCION, TELEFONO = @TELEFONO, CORREO = @CORREO, ESTADO = @ESTADO"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA"
                SQL &= Chr(13) & " And COD_SUCUR = @COD_SUCUR"
                SQL &= Chr(13) & "		END	"
                SQL &= Chr(13) & "		ELSE IF @MODO = 5	"
                SQL &= Chr(13) & "		BEGIN	"
                SQL &= Chr(13) & "			SELECT *"
                SQL &= Chr(13) & "			FROM SUCURSAL"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR"
                SQL &= Chr(13) & "		END	"
                SQL &= Chr(13) & "	END	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                USP_ACTIVIDAD_ECONOMICA_MANT_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub USP_ACTIVIDAD_ECONOMICA_MANT_20200209()
        Try
            If EXISTE_SP("USP_ACTIVIDAD_ECONOMICA_MANT", "2020-02-09") = False Then
                If EXISTE_SP("USP_ACTIVIDAD_ECONOMICA_MANT", "", False) = True Then
                    DROP_PROCEDURE("USP_ACTIVIDAD_ECONOMICA_MANT")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_ACTIVIDAD_ECONOMICA_MANT] "
                SQL &= Chr(13) & "	    @COD_CIA VARCHAR(3),		"
                SQL &= Chr(13) & "		@MODO INTEGER,					"
                SQL &= Chr(13) & "		@COD_ACT VARCHAR(6) = NULL,			"
                SQL &= Chr(13) & "		@DES_ACT VARCHAR(100) = NULL,	"
                SQL &= Chr(13) & "		@PRINCIPAL CHAR(1) = NULL		"
                SQL &= Chr(13) & "	AS   			"
                SQL &= Chr(13) & "	BEGIN						"
                SQL &= Chr(13) & "		DECLARE @CONTADOR INTEGER		"
                SQL &= Chr(13) & "		IF @MODO = 1				"
                SQL &= Chr(13) & "		BEGIN					"
                SQL &= Chr(13) & "			IF @PRINCIPAL ='S'				"
                SQL &= Chr(13) & "			BEGIN	"
                SQL &= Chr(13) & "				SET @CONTADOR = (SELECT COUNT(COD_ACT) FROM ACTIVIDAD_ECONOMICA WHERE COD_CIA = @COD_CIA)		"
                SQL &= Chr(13) & "				IF @CONTADOR>0		"
                SQL &= Chr(13) & "					BEGIN		"
                SQL &= Chr(13) & "							UPDATE ACTIVIDAD_ECONOMICA SET PRINCIPAL ='N' WHERE COD_CIA = @COD_CIA"
                SQL &= Chr(13) & "					END		"
                SQL &= Chr(13) & "			END				"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "			INSERT INTO ACTIVIDAD_ECONOMICA(COD_CIA,COD_ACT,DES_ACT,PRINCIPAL,FECHA_INC) 	"
                SQL &= Chr(13) & "			VALUES(@COD_CIA,@COD_ACT,@DES_ACT,@PRINCIPAL,GETDATE())		"
                SQL &= Chr(13) & "		END					"
                SQL &= Chr(13) & "		IF @MODO = 2			"
                SQL &= Chr(13) & "		BEGIN					"
                SQL &= Chr(13) & "				DELETE FROM ACTIVIDAD_ECONOMICA			"
                SQL &= Chr(13) & "				WHERE COD_CIA=@COD_CIA			"
                SQL &= Chr(13) & " And COD_ACT = @COD_ACT			"
                SQL &= Chr(13) & "		END					"
                SQL &= Chr(13) & "		IF @MODO = 3				"
                SQL &= Chr(13) & "		BEGIN					"
                SQL &= Chr(13) & "			IF @PRINCIPAL ='S'				"
                SQL &= Chr(13) & "				BEGIN			"
                SQL &= Chr(13) & "					SET @CONTADOR = (SELECT COUNT(COD_ACT) FROM ACTIVIDAD_ECONOMICA WHERE COD_CIA = @COD_CIA)	"
                SQL &= Chr(13) & "					IF @CONTADOR>0		"
                SQL &= Chr(13) & "						BEGIN	"
                SQL &= Chr(13) & "						UPDATE ACTIVIDAD_ECONOMICA SET PRINCIPAL ='N' WHERE COD_CIA = @COD_CIA	"
                SQL &= Chr(13) & "						END	"
                SQL &= Chr(13) & "				END			"
                SQL &= Chr(13) & "				UPDATE ACTIVIDAD_ECONOMICA SET	"
                SQL &= Chr(13) & "					DES_ACT   = @DES_ACT,	"
                SQL &= Chr(13) & "					PRINCIPAL = @PRINCIPAL		"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA"
                SQL &= Chr(13) & "				AND COD_ACT   = @COD_ACT	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "		IF @MODO = 5	"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			SELECT * FROM ACTIVIDAD_ECONOMICA	"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA	"
                SQL &= Chr(13) & " And COD_ACT = @COD_ACT	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "	END	"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                USP_USP_CLIENTE_MANT_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub USP_USP_CLIENTE_MANT_20200209()
        Try
            If EXISTE_SP("USP_CLIENTE_MANT", "2020-02-09") = False Then
                If EXISTE_SP("USP_CLIENTE_MANT", "", False) = True Then
                    DROP_PROCEDURE("USP_CLIENTE_MANT")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_CLIENTE_MANT] "
                SQL &= Chr(13) & "	    @COD_CIA VARCHAR(3),	"
                SQL &= Chr(13) & "		@MODO INTEGER,		"
                SQL &= Chr(13) & "		@CEDULA VARCHAR(25),		"
                SQL &= Chr(13) & "		@TIPO_CEDULA CHAR(2) = NULL,		"
                SQL &= Chr(13) & "		@NOMBRE VARCHAR(50) = NULL,		"
                SQL &= Chr(13) & "		@APELLIDO1 VARCHAR(50) = NULL,		"
                SQL &= Chr(13) & "		@APELLIDO2 VARCHAR(50) = NULL,		"
                SQL &= Chr(13) & "		@TELEFONO VARCHAR(8) = NULL,		"
                SQL &= Chr(13) & "		@DIRECCION VARCHAR(250) = NULL,		"
                SQL &= Chr(13) & "		@CORREO VARCHAR(150) = NULL,		"
                SQL &= Chr(13) & "		@SALDO MONEY = NULL,		"
                SQL &= Chr(13) & "		@MONEDA VARCHAR(3) = NULL,		"
                SQL &= Chr(13) & "		@FE CHAR(1) = NULL,		"
                SQL &= Chr(13) & "		@ESTADO CHAR(1) = NULL		"
                SQL &= Chr(13) & "	AS   			"
                SQL &= Chr(13) & "	BEGIN			"
                SQL &= Chr(13) & "		IF @MODO = 1		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			INSERT INTO CLIENTE(COD_CIA,TIPO_CEDULA,CEDULA,NOMBRE,APELLIDO1,APELLIDO2,TELEFONO,DIRECCION,CORREO,SALDO,MONEDA,FE,ESTADO,FECHA_INC) VALUES"
                SQL &= Chr(13) & "			(@COD_CIA,@TIPO_CEDULA,@CEDULA,@NOMBRE,@APELLIDO1,@APELLIDO2,@TELEFONO,@DIRECCION,@CORREO,@SALDO,@MONEDA,@FE,@ESTADO,GETDATE())	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "		IF @MODO = 3		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			UPDATE CLIENTE SET	"
                SQL &= Chr(13) & "				NOMBRE = @NOMBRE,"
                SQL &= Chr(13) & "				APELLIDO1 = @APELLIDO1,"
                SQL &= Chr(13) & "				APELLIDO2 = @APELLIDO2,"
                SQL &= Chr(13) & "				TELEFONO = @TELEFONO,"
                SQL &= Chr(13) & "				DIRECCION = @DIRECCION,"
                SQL &= Chr(13) & "				CORREO = @CORREO,"
                SQL &= Chr(13) & "				SALDO = @SALDO,"
                SQL &= Chr(13) & "				MONEDA = @MONEDA,"
                SQL &= Chr(13) & "				FE = @FE,"
                SQL &= Chr(13) & "				ESTADO = @ESTADO"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA	"
                SQL &= Chr(13) & " And CEDULA = @CEDULA	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "		IF @MODO = 5		"
                SQL &= Chr(13) & "		BEGIN	"
                SQL &= Chr(13) & "			SELECT *	"
                SQL &= Chr(13) & "			FROM CLIENTE	"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA	"
                SQL &= Chr(13) & " And CEDULA = @CEDULA	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "	END			"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                USP_COMPANIA_MANT_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub USP_COMPANIA_MANT_20200209()
        Try
            If EXISTE_SP("USP_COMPANIA_MANT", "2020-02-09") = False Then
                If EXISTE_SP("USP_COMPANIA_MANT", "", False) = True Then
                    DROP_PROCEDURE("USP_COMPANIA_MANT")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_COMPANIA_MANT] 	"
                SQL &= Chr(13) & "	    @COD_CIA VARCHAR(3),			"
                SQL &= Chr(13) & "		@MODO INTEGER,		"
                SQL &= Chr(13) & "		@NOMBRE VARCHAR(100) = NULL,		"
                SQL &= Chr(13) & "		@CEDULA VARCHAR(25) = NULL,		"
                SQL &= Chr(13) & "		@TIPO_CEDULA CHAR(2) = NULL,	"
                SQL &= Chr(13) & "		@CORREO VARCHAR(150) = NULL,		"
                SQL &= Chr(13) & "		@PROVINCIA VARCHAR(100) = NULL,		"
                SQL &= Chr(13) & "		@CANTON VARCHAR(100) = NULL,		"
                SQL &= Chr(13) & "		@DISTRITO VARCHAR(100) = NULL,		"
                SQL &= Chr(13) & "		@ESTADO CHAR(1) = NULL,		"
                SQL &= Chr(13) & "		@COD_PROVINCIA VARCHAR(10) = NULL,		"
                SQL &= Chr(13) & "		@COD_DISTRITO VARCHAR(10) = NULL,		"
                SQL &= Chr(13) & "		@COD_CANTON VARCHAR(10) = NULL,		"
                SQL &= Chr(13) & "		@FE CHAR(1) = NULL,		"
                SQL &= Chr(13) & "		@USUARIO_ATV VARCHAR(100) = NULL,		"
                SQL &= Chr(13) & "		@CLAVE_ATV VARCHAR(100) = NULL		"
                SQL &= Chr(13) & "	AS   			"
                SQL &= Chr(13) & "	BEGIN			"
                SQL &= Chr(13) & "		IF @MODO = 1		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			INSERT INTO COMPANIA(COD_CIA,NOMBRE,CEDULA,TIPO_CEDULA,CORREO,COD_PROVINCIA,PROVINCIA,COD_CANTON,CANTON,COD_DISTRITO,DISTRITO,ESTADO,FECHA_INC,FE,USUARIO_ATV,CLAVE_ATV) VALUES	"
                SQL &= Chr(13) & "			(@COD_CIA,@NOMBRE,@CEDULA,@TIPO_CEDULA,@CORREO,@COD_PROVINCIA,@PROVINCIA,@COD_CANTON,@CANTON,@COD_DISTRITO,@DISTRITO,@ESTADO,GETDATE(),@FE,@USUARIO_ATV,@CLAVE_ATV)	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "		IF @MODO = 3		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			UPDATE COMPANIA SET	"
                SQL &= Chr(13) & "				NOMBRE = @NOMBRE,"
                SQL &= Chr(13) & "				CEDULA = @CEDULA,"
                SQL &= Chr(13) & "				TIPO_CEDULA = @TIPO_CEDULA,"
                SQL &= Chr(13) & "				CORREO = @CORREO,"
                SQL &= Chr(13) & "				COD_PROVINCIA = @COD_PROVINCIA,"
                SQL &= Chr(13) & "				PROVINCIA = @PROVINCIA,"
                SQL &= Chr(13) & "				COD_CANTON = @COD_CANTON,"
                SQL &= Chr(13) & "				CANTON = @CANTON,"
                SQL &= Chr(13) & "				COD_DISTRITO = @COD_DISTRITO,"
                SQL &= Chr(13) & "				DISTRITO = @DISTRITO,"
                SQL &= Chr(13) & "				ESTADO = @ESTADO,"
                SQL &= Chr(13) & "				USUARIO_ATV = @USUARIO_ATV,"
                SQL &= Chr(13) & "				CLAVE_ATV = @CLAVE_ATV"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "		IF @MODO = 5		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			SELECT COD_CIA,NOMBRE,CEDULA,TIPO_CEDULA,CORREO,COD_PROVINCIA,PROVINCIA,COD_CANTON,CANTON,COD_DISTRITO,DISTRITO,ESTADO,FE,"
                SQL &= Chr(13) & "			ISNULL(PIN,'') AS PIN,	"
                SQL &= Chr(13) & "			ISNULL(USUARIO_ATV,'') AS USUARIO_ATV,	"
                SQL &= Chr(13) & "			ISNULL(CLAVE_ATV,'') AS CLAVE_ATV	"
                SQL &= Chr(13) & "			FROM COMPANIA	"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "	END			"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                USP_INGRESA_USUARIO_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub USP_INGRESA_USUARIO_20200209()
        Try
            If EXISTE_SP("USP_INGRESA_USUARIO", "2020-02-09") = False Then
                If EXISTE_SP("USP_INGRESA_USUARIO", "", False) = True Then
                    DROP_PROCEDURE("USP_INGRESA_USUARIO")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_INGRESA_USUARIO]"
                SQL &= Chr(13) & "	 @COD_USUARIO VARCHAR(8)"
                SQL &= Chr(13) & "	,@NOMBRE VARCHAR(50)"
                SQL &= Chr(13) & "	,@TELEFONO VARCHAR(8)"
                SQL &= Chr(13) & "	,@DIRECCION VARCHAR(250)"
                SQL &= Chr(13) & "	,@CORREO VARCHAR(150)"
                SQL &= Chr(13) & "	,@FOTO IMAGE = NULL"
                SQL &= Chr(13) & "	,@CONTRASENA VARCHAR(100)"
                SQL &= Chr(13) & "	AS"
                SQL &= Chr(13) & "	BEGIN"
                SQL &= Chr(13) & "	IF EXISTS(SELECT COD_USUARIO FROM USUARIO WHERE COD_USUARIO = @COD_USUARIO)"
                SQL &= Chr(13) & "	BEGIN"
                SQL &= Chr(13) & "	SELECT 'El [CÓDIGO] de usuario ya existe en la base de datos, por favor trate nuevamente'"
                SQL &= Chr(13) & "	END"
                SQL &= Chr(13) & "	ELSE IF EXISTS(SELECT NOMBRE FROM USUARIO WHERE NOMBRE = @NOMBRE)"
                SQL &= Chr(13) & "	BEGIN"
                SQL &= Chr(13) & "	SELECT 'El [NOMBRE] de usuario ya está siendo utilizado, por favor ingrese un nuevo nombre'"
                SQL &= Chr(13) & "	END"
                SQL &= Chr(13) & "	ELSE IF EXISTS(SELECT CORREO FROM USUARIO WHERE CORREO = @CORREO)"
                SQL &= Chr(13) & "	BEGIN"
                SQL &= Chr(13) & "	SELECT 'El [CORREO] de usuario ya está siendo utilizado, por favor ingrese un nuevo correo'"
                SQL &= Chr(13) & "	END"
                SQL &= Chr(13) & "	ELSE"
                SQL &= Chr(13) & "	BEGIN"
                SQL &= Chr(13) & "	INSERT INTO USUARIO(COD_USUARIO,NOMBRE,TELEFONO,DIRECCION,CORREO,FOTO,ESTADO,FECHA_INC, CONTRASENA)"
                SQL &= Chr(13) & "	SELECT @COD_USUARIO, @NOMBRE, @TELEFONO, @DIRECCION, @CORREO, @FOTO, 'A', GETDATE(), @CONTRASENA"
                SQL &= Chr(13) & "	END"
                SQL &= Chr(13) & "	END"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(Sql)
                CONX.Coneccion_Cerrar()
                USP_MANT_FACTURACION_TMP_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub USP_MANT_FACTURACION_TMP_20200209()
        Try
            If EXISTE_SP("USP_MANT_FACTURACION_TMP", "2020-02-09") = False Then
                If EXISTE_SP("USP_MANT_FACTURACION_TMP", "", False) = True Then
                    DROP_PROCEDURE("USP_MANT_FACTURACION_TMP")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_MANT_FACTURACION_TMP] 	"
                SQL &= Chr(13) & "	 @COD_CIA VARCHAR(3)	"
                SQL &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)		"
                SQL &= Chr(13) & "	,@CODIGO VARCHAR(20)	"
                SQL &= Chr(13) & "	,@TIPO_MOV VARCHAR(2)			"
                SQL &= Chr(13) & "	,@CEDULA VARCHAR(25)			"
                SQL &= Chr(13) & "	,@FECHA DATETIME		"
                SQL &= Chr(13) & "	,@COD_USUARIO VARCHAR(8)	"
                SQL &= Chr(13) & "	,@COD_MONEDA CHAR(1)				"
                SQL &= Chr(13) & "	,@TIPO_CAMBIO MONEY					"
                SQL &= Chr(13) & "	,@PLAZO INT					"
                SQL &= Chr(13) & "	,@FORMA_PAGO CHAR(2)					"
                SQL &= Chr(13) & "	,@DESCRIPCION VARCHAR(250)			"
                SQL &= Chr(13) & "	,@COD_PROD VARCHAR(20)			"
                SQL &= Chr(13) & "	,@COD_UNIDAD VARCHAR(10)		"
                SQL &= Chr(13) & "	,@CANTIDAD MONEY				"
                SQL &= Chr(13) & "	,@PRECIO MONEY						"
                SQL &= Chr(13) & "	,@POR_DESCUENTO INT						"
                SQL &= Chr(13) & "	,@DESCUENTO MONEY						"
                SQL &= Chr(13) & "	,@POR_IMPUESTO INT						"
                SQL &= Chr(13) & "	,@IMPUESTO MONEY						"
                SQL &= Chr(13) & "	,@SUBTOTAL MONEY							"
                SQL &= Chr(13) & "	,@TOTAL MONEY								"
                SQL &= Chr(13) & "	,@MODO INT									"
                SQL &= Chr(13) & "	AS									"
                SQL &= Chr(13) & "	BEGIN											"
                SQL &= Chr(13) & "		SET NOCOUNT ON;							"
                SQL &= Chr(13) & "		BEGIN TRY									"
                SQL &= Chr(13) & "		BEGIN TRAN TR_MANT_FACTURACION					"
                SQL &= Chr(13) & "		IF	@MODO = 1						"
                SQL &= Chr(13) & "		BEGIN											"
                SQL &= Chr(13) & "			IF NOT EXISTS(SELECT *					"
                SQL &= Chr(13) & "						  FROM DOCUMENTO_ENC_TMP				"
                SQL &= Chr(13) & "						  WHERE COD_CIA = @COD_CIA					"
                SQL &= Chr(13) & "						  AND COD_SUCUR = @COD_SUCUR					"
                SQL &= Chr(13) & " And CODIGO = @CODIGO)						"
                SQL &= Chr(13) & "			BEGIN					"
                SQL &= Chr(13) & "				INSERT INTO DOCUMENTO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION)		"
                SQL &= Chr(13) & "				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, @CEDULA, @FECHA, GETDATE(), @COD_USUARIO, @COD_MONEDA, @TIPO_CAMBIO, @PLAZO, @FORMA_PAGO,@DESCRIPCION		"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "				INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL)			"
                SQL &= Chr(13) & "				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL	"
                SQL &= Chr(13) & "				FROM DOCUMENTO_DET_TMP			"
                SQL &= Chr(13) & "				WHERE COD_CIA = @COD_CIA			"
                SQL &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR			"
                SQL &= Chr(13) & " And CODIGO = @CODIGO		 "
                SQL &= Chr(13) & "			END			"
                SQL &= Chr(13) & "			ELSE						"
                SQL &= Chr(13) & "			BEGIN					"
                SQL &= Chr(13) & "				IF EXISTS(SELECT COD_PROD FROM DOCUMENTO_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)	"
                SQL &= Chr(13) & "				BEGIN		"
                SQL &= Chr(13) & "					UPDATE DOCUMENTO_DET_TMP	"
                SQL &= Chr(13) & "					SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO	"
                SQL &= Chr(13) & "					   ,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL				"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA			"
                SQL &= Chr(13) & " And COD_SUCUR = @COD_SUCUR						"
                SQL &= Chr(13) & "					AND CODIGO = @CODIGO			"
                SQL &= Chr(13) & " And COD_PROD = @COD_PROD						"
                SQL &= Chr(13) & "				END								"
                SQL &= Chr(13) & "				ELSE						"
                SQL &= Chr(13) & "				BEGIN						"
                SQL &= Chr(13) & "					INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL)		"
                SQL &= Chr(13) & "					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL		"
                SQL &= Chr(13) & "					FROM DOCUMENTO_DET_TMP		"
                SQL &= Chr(13) & "					WHERE COD_CIA = @COD_CIA		"
                SQL &= Chr(13) & " And COD_SUCUR = @COD_SUCUR			"
                SQL &= Chr(13) & "					AND CODIGO = @CODIGO		"
                SQL &= Chr(13) & "				END				"
                SQL &= Chr(13) & "			END				"
                SQL &= Chr(13) & "		END					"
                SQL &= Chr(13) & "		COMMIT TRAN TR_MANT_FACTURACION 	"
                SQL &= Chr(13) & "		END TRY			"
                SQL &= Chr(13) & "		BEGIN CATCH 	"
                SQL &= Chr(13) & "	 		ROLLBACK TRAN		"
                SQL &= Chr(13) & "	 		DECLARE @MENSAJE VARCHAR(500)	"
                SQL &= Chr(13) & "	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())		"
                SQL &= Chr(13) & "	 		RAISERROR( @MENSAJE, 16, 1)		"
                SQL &= Chr(13) & "		END CATCH			"
                SQL &= Chr(13) & "	END		"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                USP_MANT_PRODUCTO_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub USP_MANT_PRODUCTO_20200209()
        Try
            If EXISTE_SP("USP_MANT_PRODUCTO", "2020-02-09") = False Then
                If EXISTE_SP("USP_MANT_PRODUCTO", "", False) = True Then
                    DROP_PROCEDURE("USP_MANT_PRODUCTO")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_MANT_PRODUCTO] 	"
                SQL &= Chr(13) & "	 @COD_CIA VARCHAR(3)							"
                SQL &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)			"
                SQL &= Chr(13) & "	,@COD_PROD VARCHAR(20)						"
                SQL &= Chr(13) & "	,@CEDULA VARCHAR(25) = ''					"
                SQL &= Chr(13) & "	,@DESCRIPCION VARCHAR(150) = ''					"
                SQL &= Chr(13) & "	,@COD_UNIDAD VARCHAR(10) = ''					"
                SQL &= Chr(13) & "	,@COSTO MONEY = 0								"
                SQL &= Chr(13) & "	,@POR_IMPUESTO INT = 0						"
                SQL &= Chr(13) & "	,@COD_IMPUESTO VARCHAR(4) = ''			"
                SQL &= Chr(13) & "	,@PRECIO MONEY = 0								"
                SQL &= Chr(13) & "	,@EXENTO CHAR(1) = ''							"
                SQL &= Chr(13) & "	,@ESTADO CHAR(1) = ''						"
                SQL &= Chr(13) & "	,@ESTANTE VARCHAR(3) = ''						"
                SQL &= Chr(13) & "	,@FILA VARCHAR(3) = ''						"
                SQL &= Chr(13) & "	,@COLUMNA VARCHAR(3) = ''					"
                SQL &= Chr(13) & "	,@MINIMO MONEY = 0							"
                SQL &= Chr(13) & "	,@COD_BARRA VARCHAR(25) = ''				"
                SQL &= Chr(13) & "	,@MODO INT					"
                SQL &= Chr(13) & "	AS					"
                SQL &= Chr(13) & "	BEGIN								"
                SQL &= Chr(13) & "		SET NOCOUNT ON;				"
                SQL &= Chr(13) & "		BEGIN TRY										"
                SQL &= Chr(13) & "		BEGIN TRAN TSN_PRODUCTO_MANT					"
                SQL &= Chr(13) & "												"
                SQL &= Chr(13) & "		IF	@MODO = 1							"
                SQL &= Chr(13) & "		BEGIN						"
                SQL &= Chr(13) & "			IF EXISTS(SELECT @COD_PROD FROM PRODUCTO WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND COD_PROD = @COD_PROD)	"
                SQL &= Chr(13) & "				BEGIN					"
                SQL &= Chr(13) & "					RAISERROR('El codigo ingresado ya existe en la base de datos', 5, 217)	"
                SQL &= Chr(13) & "				END								"
                SQL &= Chr(13) & "			ELSE 								"
                SQL &= Chr(13) & "				BEGIN							"
                SQL &= Chr(13) & "					INSERT INTO PRODUCTO(COD_CIA,COD_SUCUR,COD_PROD,CEDULA,DESCRIPCION,COD_UNIDAD,COSTO,POR_IMPUESTO,COD_IMPUESTO_DGTD,PRECIO,EXENTO,ESTADO,ESTANTE,FILA,COLUMNA,MINIMO,COD_BARRA,FECHA_INC)		"
                SQL &= Chr(13) & "					SELECT @COD_CIA, @COD_SUCUR, @COD_PROD, @CEDULA, @DESCRIPCION, @COD_UNIDAD, @COSTO, @POR_IMPUESTO, @COD_IMPUESTO, @PRECIO, @EXENTO, @ESTADO, @ESTANTE, @FILA, @COLUMNA, @MINIMO, @COD_BARRA, GETDATE()				"
                SQL &= Chr(13) & "				END			"
                SQL &= Chr(13) & "		END					"
                SQL &= Chr(13) & "		ELSE IF @MODO = 3						"
                SQL &= Chr(13) & "		BEGIN							"
                SQL &= Chr(13) & "			UPDATE PRODUCTO 			"
                SQL &= Chr(13) & "			SET CEDULA = @CEDULA					"
                SQL &= Chr(13) & "			,DESCRIPCION = @DESCRIPCION					"
                SQL &= Chr(13) & "			,COD_UNIDAD = @COD_UNIDAD					"
                SQL &= Chr(13) & "			,COSTO = @COSTO 								"
                SQL &= Chr(13) & "			,POR_IMPUESTO = @POR_IMPUESTO			"
                SQL &= Chr(13) & "			,COD_IMPUESTO_DGTD = @COD_IMPUESTO		"
                SQL &= Chr(13) & "			,PRECIO = @PRECIO				"
                SQL &= Chr(13) & "			,EXENTO = @EXENTO								"
                SQL &= Chr(13) & "			,ESTADO = @ESTADO					"
                SQL &= Chr(13) & "			,ESTANTE = @ESTANTE								"
                SQL &= Chr(13) & "			,FILA = @FILA									"
                SQL &= Chr(13) & "			,COLUMNA = @COLUMNA 							"
                SQL &= Chr(13) & "			,MINIMO = @MINIMO			"
                SQL &= Chr(13) & "			,COD_BARRA = @COD_BARRA							"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA			"
                SQL &= Chr(13) & " And COD_SUCUR = @COD_SUCUR				"
                SQL &= Chr(13) & "			AND COD_PROD = @COD_PROD						"
                SQL &= Chr(13) & "		END													"
                SQL &= Chr(13) & "		ELSE IF @MODO = 5					"
                SQL &= Chr(13) & "		BEGIN												"
                SQL &= Chr(13) & "			SELECT *									"
                SQL &= Chr(13) & "			FROM PRODUCTO				"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA						"
                SQL &= Chr(13) & " And COD_SUCUR = @COD_SUCUR			"
                SQL &= Chr(13) & "			AND COD_PROD = @COD_PROD	"
                SQL &= Chr(13) & "		END								"
                SQL &= Chr(13) & "		COMMIT TRAN TRN_MOV_CAMBIA 		"
                SQL &= Chr(13) & "		END TRY							"
                SQL &= Chr(13) & "		BEGIN CATCH 					"
                SQL &= Chr(13) & "	 		ROLLBACK TRAN								"
                SQL &= Chr(13) & "	 		DECLARE @MENSAJE VARCHAR(500)"
                SQL &= Chr(13) & "	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())		"
                SQL &= Chr(13) & "	 		RAISERROR( @MENSAJE, 16, 1)		"
                SQL &= Chr(13) & "		END CATCH					"
                SQL &= Chr(13) & "	END								"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                USP_PROVEEDOR_MANT_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub USP_PROVEEDOR_MANT_20200209()
        Try
            If EXISTE_SP("USP_PROVEEDOR_MANT", "2020-02-09") = False Then
                If EXISTE_SP("USP_PROVEEDOR_MANT", "", False) = True Then
                    DROP_PROCEDURE("USP_PROVEEDOR_MANT")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[USP_PROVEEDOR_MANT] 	"
                SQL &= Chr(13) & "	    @COD_CIA VARCHAR(3),			"
                SQL &= Chr(13) & "		@COD_SUCUR VARCHAR(3),		"
                SQL &= Chr(13) & "		@MODO INTEGER,		"
                SQL &= Chr(13) & "		@CEDULA VARCHAR(25),		"
                SQL &= Chr(13) & "		@TIPO_CEDULA CHAR(2) = NULL,		"
                SQL &= Chr(13) & "		@NOMBRE VARCHAR(250) = NULL,		"
                SQL &= Chr(13) & "		@DIRECCION VARCHAR(250) = NULL,		"
                SQL &= Chr(13) & "		@TELEFONO VARCHAR(8) = NULL,		"
                SQL &= Chr(13) & "		@CORREO VARCHAR(150) = NULL,		"
                SQL &= Chr(13) & "		@ESTADO CHAR(1) = NULL		"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "	AS   			"
                SQL &= Chr(13) & "	BEGIN			"
                SQL &= Chr(13) & "		IF @MODO = 1		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			INSERT INTO PROVEEDOR(COD_CIA,COD_SUCUR,TIPO_CEDULA,CEDULA,NOMBRE,DIRECCION,TELEFONO,CORREO,ESTADO,FECHA_INC) VALUES"
                SQL &= Chr(13) & "(@COD_CIA,@COD_SUCUR,@TIPO_CEDULA,@CEDULA,@NOMBRE,@DIRECCION,@TELEFONO,@CORREO,@ESTADO, GETDATE())"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "		IF @MODO = 3		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			UPDATE PROVEEDOR SET	"
                SQL &= Chr(13) & "				NOMBRE = @NOMBRE,"
                SQL &= Chr(13) & "				DIRECCION = @DIRECCION,"
                SQL &= Chr(13) & "				TELEFONO = @TELEFONO,"
                SQL &= Chr(13) & "				CORREO = @CORREO,"
                SQL &= Chr(13) & "				ESTADO = @ESTADO"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA	"
                SQL &= Chr(13) & " And CEDULA = @CEDULA	"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "		IF @MODO = 5		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			SELECT *	"
                SQL &= Chr(13) & "			FROM PROVEEDOR	"
                SQL &= Chr(13) & "			WHERE COD_CIA = @COD_CIA	"
                SQL &= Chr(13) & " And CEDULA = @CEDULA	"
                SQL &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR	"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "	END			"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                GUARDAR_CERTIFICADO_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub GUARDAR_CERTIFICADO_20200209()
        Try
            If EXISTE_SP("GUARDAR_CERTIFICADO", "2020-02-09") = False Then
                If EXISTE_SP("GUARDAR_CERTIFICADO", "", False) = True Then
                    DROP_PROCEDURE("GUARDAR_CERTIFICADO")
                End If
                Dim SQL = "	CREATE PROCEDURE [dbo].[GUARDAR_CERTIFICADO] 	"
                SQL &= Chr(13) & "	    @CERTIFICADO varbinary(MAX),   	"
                SQL &= Chr(13) & "	    @PIN VARCHAR(50),   	"
                SQL &= Chr(13) & "		@COD_CIA VARCHAR(3)  "
                SQL &= Chr(13) & "	AS   	"
                SQL &= Chr(13) & "	BEGIN	"
                SQL &= Chr(13) & "	    SET NOCOUNT ON;  	"
                SQL &= Chr(13) & "		UPDATE COMPANIA SET CERTIFICADO = @CERTIFICADO,PIN = @PIN,SUBJECT_CERT = NULL,HUELLA = NULL"
                SQL &= Chr(13) & "		WHERE COD_CIA = @COD_CIA"
                SQL &= Chr(13) & "	END	"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub DROP_PROCEDURE(ByVal NOMBRE As String)
        Dim SQL = "	DROP PROCEDURE " & NOMBRE
        CONX.Coneccion_Abrir()
        CONX.EJECUTE(SQL)
        CONX.Coneccion_Cerrar()
    End Sub
    Public Shared Function EXISTE_SP(ByVal NOMBRE As String, ByVal FECHA As String, Optional ByVal CON_FECHA As Boolean = True) As Boolean
        Try
            EXISTE_SP = False

            Dim SQL = "	SELECT * 	"
            SQL &= Chr(13) & "	FROM 	"
            SQL &= Chr(13) & "	    INFORMATION_SCHEMA.ROUTINES 	"
            SQL &= Chr(13) & "	WHERE 	"
            SQL &= Chr(13) & "	  SPECIFIC_NAME = 	" & SCM(NOMBRE)
            If CON_FECHA = True Then
                SQL &= Chr(13) & " And Convert(VARCHAR, CREATED, 111) = " & SCM(YMD(FECHA))
            End If
            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                EXISTE_SP = True
            End If
            Return EXISTE_SP
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
#End Region
#Region "TRIGGERS"
    Public Shared Sub CREACION_TRIGGERS()
        INVENTARIO_MOV_TG_20200209()
    End Sub
    Public Shared Function EXISTE_TRIGGER(ByVal NOMBRE As String, ByVal FECHA As String, Optional ByVal CON_FECHA As Boolean = True) As Boolean
        Try
            EXISTE_TRIGGER = False

            Dim SQL = "	SELECT * FROM sys.objects "
            SQL &= Chr(13) & "	WHERE name = " & SCM(NOMBRE)
            SQL &= Chr(13) & "	AND type = 'TR'"
            If CON_FECHA = True Then
                SQL &= Chr(13) & " And Convert(VARCHAR, create_date, 111) =" & SCM(YMD(FECHA))
            End If

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                EXISTE_TRIGGER = True
            End If
            Return EXISTE_TRIGGER
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
    Public Shared Sub DROP_TRIGGER(ByVal NOMBRE As String)
        Dim SQL = "	DROP TRIGGER " & NOMBRE
        CONX.Coneccion_Abrir()
        CONX.EJECUTE(SQL)
        CONX.Coneccion_Cerrar()
    End Sub
    Public Shared Sub INVENTARIO_MOV_TG_20200209()
        Try
            If EXISTE_TRIGGER("INVENTARIO_MOV_TG", "2020-02-09") = False Then
                If EXISTE_TRIGGER("INVENTARIO_MOV_TG", "", False) = True Then
                    DROP_TRIGGER("INVENTARIO_MOV_TG")
                End If
                Dim SQL = "	CREATE TRIGGER [dbo].[INVENTARIO_MOV_TG]	"
                SQL &= Chr(13) & "	ON [dbo].[DOCUMENTO_ENC]		"
                SQL &= Chr(13) & "	AFTER INSERT		"
                SQL &= Chr(13) & "	AS		"
                SQL &= Chr(13) & "	BEGIN		"
                SQL &= Chr(13) & "	DECLARE @TIPO_MOV AS VARCHAR(2)		"
                SQL &= Chr(13) & "	SET @TIPO_MOV = (SELECT TIPO_MOV FROM inserted)		"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "		IF @TIPO_MOV ='FA' OR @TIPO_MOV ='FC'	"
                SQL &= Chr(13) & "		BEGIN	"
                SQL &= Chr(13) & "			INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC)"
                SQL &= Chr(13) & "			SELECT COD_CIA,COD_SUCUR,'SPV','',TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC"
                SQL &= Chr(13) & "			FROM inserted"
                SQL &= Chr(13) & "		END	"
                SQL &= Chr(13) & "	END		"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                INVENTARIO_MOV_DET_TG_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub INVENTARIO_MOV_DET_TG_20200209()
        Try
            If EXISTE_TRIGGER("INVENTARIO_MOV_DET_TG", "2020-02-09") = False Then
                If EXISTE_TRIGGER("INVENTARIO_MOV_DET_TG", "", False) = True Then
                    DROP_TRIGGER("INVENTARIO_MOV_DET_TG")
                End If
                Dim SQL = "	CREATE TRIGGER [dbo].[INVENTARIO_MOV_DET_TG]	"
                SQL &= Chr(13) & "	ON [dbo].[DOCUMENTO_DET]	"
                SQL &= Chr(13) & "	AFTER INSERT		"
                SQL &= Chr(13) & "	AS			"
                SQL &= Chr(13) & "	BEGIN			"
                SQL &= Chr(13) & "	DECLARE @TIPO_MOV AS VARCHAR(2)			"
                SQL &= Chr(13) & "	SET @TIPO_MOV = (SELECT TIPO_MOV FROM inserted)			"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "		IF @TIPO_MOV ='FA' OR @TIPO_MOV ='FC'		"
                SQL &= Chr(13) & "		BEGIN		"
                SQL &= Chr(13) & "			DECLARE @COSTO AS MONEY	"
                SQL &= Chr(13) & "			DECLARE @NUMERO_MOV AS INTEGER	"
                SQL &= Chr(13) & "			DECLARE @COD_MOV AS VARCHAR(3)	"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "			SET @COSTO = (SELECT COSTO 	"
                SQL &= Chr(13) & "			FROM PRODUCTO P	"
                SQL &= Chr(13) & "			INNER JOIN inserted I	"
                SQL &= Chr(13) & "				ON P.COD_CIA = I.COD_CIA"
                SQL &= Chr(13) & "				AND P.COD_SUCUR = I.COD_SUCUR"
                SQL &= Chr(13) & " And P.COD_PROD = I.COD_PROD"
                SQL &= Chr(13) & "			WHERE P.COD_PROD = I.COD_PROD	"
                SQL &= Chr(13) & " And P.COD_CIA = I.COD_CIA"
                SQL &= Chr(13) & "			AND P.COD_SUCUR = I.COD_SUCUR)	"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "			SET @NUMERO_MOV = (SELECT M.NUMERO_MOV 	"
                SQL &= Chr(13) & "			FROM INVENTARIO_MOV  AS M	"
                SQL &= Chr(13) & "			INNER JOIN inserted AS I	"
                SQL &= Chr(13) & "				ON  M.COD_CIA = I.COD_CIA"
                SQL &= Chr(13) & "				AND M.COD_SUCUR = I.COD_SUCUR"
                SQL &= Chr(13) & " And M.NUMERO_DOC = I.NUMERO_DOC"
                SQL &= Chr(13) & "				AND M.TIPO_MOV = I.TIPO_MOV"
                SQL &= Chr(13) & "			WHERE M.COD_CIA = I.COD_CIA	"
                SQL &= Chr(13) & "			AND M.COD_SUCUR = I.COD_SUCUR	"
                SQL &= Chr(13) & " And M.NUMERO_DOC = I.NUMERO_DOC"
                SQL &= Chr(13) & "			AND M.TIPO_MOV = I.TIPO_MOV)	"
                SQL &= Chr(13) & ""
                SQL &= Chr(13) & "			SET @COD_MOV = (SELECT M.COD_MOV 	"
                SQL &= Chr(13) & "			FROM INVENTARIO_MOV  AS M	"
                SQL &= Chr(13) & "			INNER JOIN inserted AS I	"
                SQL &= Chr(13) & "				ON  M.COD_CIA = I.COD_CIA"
                SQL &= Chr(13) & "				AND M.COD_SUCUR = I.COD_SUCUR"
                SQL &= Chr(13) & " And M.NUMERO_DOC = I.NUMERO_DOC"
                SQL &= Chr(13) & "				AND M.TIPO_MOV = I.TIPO_MOV"
                SQL &= Chr(13) & "			WHERE M.COD_CIA = I.COD_CIA	"
                SQL &= Chr(13) & "			AND M.COD_SUCUR = I.COD_SUCUR	"
                SQL &= Chr(13) & " And M.NUMERO_DOC = I.NUMERO_DOC"
                SQL &= Chr(13) & "			AND M.TIPO_MOV = I.TIPO_MOV	"
                SQL &= Chr(13) & " And M.NUMERO_MOV = @NUMERO_MOV)	"
                SQL &= Chr(13) & "				"
                SQL &= Chr(13) & "			INSERT INTO INVENTARIO_MOV_DET(COD_CIA,COD_SUCUR,NUMERO_MOV,COD_MOV,LINEA,COD_PROD,CANTIDAD,COSTO,COSTO_ANT)	"
                SQL &= Chr(13) & "			SELECT COD_CIA,COD_SUCUR,@NUMERO_MOV,@COD_MOV,LINEA,COD_PROD,CANTIDAD,@COSTO,@COSTO	"
                SQL &= Chr(13) & "			FROM inserted	"
                SQL &= Chr(13) & "				"
                SQL &= Chr(13) & "		END		"
                SQL &= Chr(13) & "	END			"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
    Public Shared Function EXISTE_TABLA(ByVal TABLA As String) As Boolean
        Try
            EXISTE_TABLA = False

            Dim SQL = "	SELECT *  "
            SQL &= Chr(13) & "	FROM INFORMATION_SCHEMA.TABLES "
            SQL &= Chr(13) & "	WHERE TABLE_TYPE = 'BASE TABLE' "
            SQL &= Chr(13) & " And TABLE_NAME = " & SCM(TABLA)

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            If DS.Tables(0).Rows.Count > 0 Then
                EXISTE_TABLA = True
            End If

            Return EXISTE_TABLA
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Shared Sub CREACION_TABLA_COMPANIA_20200208()
        Try
            If EXISTE_TABLA("COMPANIA") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[COMPANIA](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[NOMBRE] [varchar](100) NOT NULL,"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_CEDULA] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[CORREO] [varchar](150) NOT NULL,"
                SQL &= Chr(13) & "		[PROVINCIA] [varchar](100) NULL,"
                SQL &= Chr(13) & "		[CANTON] [varchar](100) NULL,"
                SQL &= Chr(13) & "		[DISTRITO] [varchar](100) NULL,"
                SQL &= Chr(13) & "		[CERTIFICADO] [varbinary](max) NULL,"
                SQL &= Chr(13) & "		[PIN] [int] NULL,"
                SQL &= Chr(13) & "		[SUBJECT_CERT] [varchar](500) NULL,"
                SQL &= Chr(13) & "		[HUELLA] [varchar](500) NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,"
                SQL &= Chr(13) & "		[COD_PROVINCIA] [varchar](10) NULL,"
                SQL &= Chr(13) & "		[COD_DISTRITO] [varchar](10) NULL,"
                SQL &= Chr(13) & "		[COD_CANTON] [varchar](10) NULL,"
                SQL &= Chr(13) & "		[FE] [char](1) NULL,"
                SQL &= Chr(13) & "		[USUARIO_ATV] [varchar](100) NULL,"
                SQL &= Chr(13) & "		[CLAVE_ATV] [varchar](100) NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_COMPANIA] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	"
                SQL &= Chr(13) & "		[COD_CIA] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]	"
                SQL &= Chr(13) & "		"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[COMPANIA] ADD  CONSTRAINT [DF_COMPANIA_ESTADO]  DEFAULT ('A') FOR [ESTADO]	"
                SQL &= Chr(13) & "INSERT INTO COMPANIA(COD_CIA,NOMBRE,CEDULA,TIPO_CEDULA,CORREO,FECHA_INC)VALUES('GLB','COMPANIA ADMINISTRADOR','11111111','F','tommyluna02@hotmail.com',GETDATE())"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_TABLA_SUCURSAL_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_TABLA_SUCURSAL_20200208()
        Try
            If EXISTE_TABLA("SUCURSAL") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[SUCURSAL](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[NOMBRE] [varchar](100) NOT NULL,"
                SQL &= Chr(13) & "		[DIRECCION] [varchar](250) NOT NULL,"
                SQL &= Chr(13) & "		[TELEFONO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "		[CORREO] [varchar](150) NOT NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_SUCURSAL] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "	(	"
                SQL &= Chr(13) & "		[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "		"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[SUCURSAL] ADD  CONSTRAINT [DF_SUCURSAL_ESTADO]  DEFAULT ('A') FOR [ESTADO]	"
                SQL &= Chr(13) & "		"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[SUCURSAL]  WITH CHECK ADD  CONSTRAINT [FK_SUCURSAL_COMPANIA1] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "		"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[SUCURSAL] CHECK CONSTRAINT [FK_SUCURSAL_COMPANIA1]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_TABLA_CLIENTE_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_TABLA_CLIENTE_20200208()
        Try
            If EXISTE_TABLA("CLIENTE") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[CLIENTE](				"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,			"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,			"
                SQL &= Chr(13) & "		[TIPO_CEDULA] [char](2) NOT NULL,			"
                SQL &= Chr(13) & "		[NOMBRE] [varchar](50) NOT NULL,			"
                SQL &= Chr(13) & "		[APELLIDO1] [varchar](50) NOT NULL,			"
                SQL &= Chr(13) & "		[APELLIDO2] [varchar](50) NOT NULL,			"
                SQL &= Chr(13) & "		[DIRECCION] [varchar](250) NOT NULL,			"
                SQL &= Chr(13) & "		[TELEFONO] [varchar](8) NOT NULL,			"
                SQL &= Chr(13) & "		[CORREO] [varchar](150) NOT NULL,			"
                SQL &= Chr(13) & "		[FE] [char](1) NOT NULL,			"
                SQL &= Chr(13) & "		[SALDO] [money] NOT NULL,			"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,			"
                SQL &= Chr(13) & "		[FECHA_INC] [nchar](10) NOT NULL,			"
                SQL &= Chr(13) & "		[MONEDA] [varchar](3) NOT NULL,			"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 					"
                SQL &= Chr(13) & "	(				"
                SQL &= Chr(13) & "		[COD_CIA] ASC,			"
                SQL &= Chr(13) & "		[CEDULA] ASC			"
                SQL &= Chr(13) & "	)) ON [PRIMARY]				"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[CLIENTE] ADD  CONSTRAINT [DF_CLIENTE_ESTADO]  DEFAULT ('A') FOR [ESTADO]								"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[CLIENTE]  WITH CHECK ADD  CONSTRAINT [FK_CLIENTE_COMPANIA1] FOREIGN KEY([COD_CIA])									"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])				"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[CLIENTE] CHECK CONSTRAINT [FK_CLIENTE_COMPANIA1]						"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_TABLA_PROVEEDOR_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_TABLA_PROVEEDOR_20200208()
        Try
            If EXISTE_TABLA("PROVEEDOR") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[PROVEEDOR](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_CEDULA] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[NOMBRE] [varchar](150) NOT NULL,"
                SQL &= Chr(13) & "		[DIRECCION] [varchar](250) NOT NULL,"
                SQL &= Chr(13) & "		[TELEFONO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "		[CORREO] [varchar](150) NOT NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_PROVEEDOR] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	"
                SQL &= Chr(13) & "		[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[CEDULA] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROVEEDOR] ADD  CONSTRAINT [DF_PROVEEDOR_ESTADO]  DEFAULT ('A') FOR [ESTADO]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROVEEDOR]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDOR_COMPANIA1] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROVEEDOR] CHECK CONSTRAINT [FK_PROVEEDOR_COMPANIA1]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROVEEDOR]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDOR_SUCURSAL1] FOREIGN KEY([COD_CIA], [COD_SUCUR])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PROVEEDOR] CHECK CONSTRAINT [FK_PROVEEDOR_SUCURSAL1]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_USUARIO_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_USUARIO_20200208()
        Try
            If EXISTE_TABLA("USUARIO") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[USUARIO]("
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "		[NOMBRE] [varchar](50) NOT NULL,"
                SQL &= Chr(13) & "		[TELEFONO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "		[DIRECCION] [varchar](250) NOT NULL,"
                SQL &= Chr(13) & "		[CORREO] [varchar](150) NOT NULL,"
                SQL &= Chr(13) & "		[FOTO] [image] NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,"
                SQL &= Chr(13) & "		[CONTRASENA] [varchar](100) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "([COD_USUARIO] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[USUARIO] ADD  CONSTRAINT [DF_USUARIO_ESTADO]  DEFAULT ('A') FOR [ESTADO]"
                SQL &= Chr(13) & "	INSERT INTO USUARIO(COD_USUARIO,NOMBRE,TELEFONO,DIRECCION,CORREO,FOTO,FECHA_INC,CONTRASENA)"
                SQL &= Chr(13) & "	VALUES('LUNAING','Administrador','88888888','','tommy02@hotmail.com',NULL,GETDATE(),'Luna01x!')"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_COMPANIA_USUARIO_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_COMPANIA_USUARIO_20200208()
        Try
            If EXISTE_TABLA("COMPANIA_USUARIO") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[COMPANIA_USUARIO](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_COMPANIA_USUARIO] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_USUARIO] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[COMPANIA_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_COMPANIA_USUARIO_COMPANIA] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[COMPANIA_USUARIO] CHECK CONSTRAINT [FK_COMPANIA_USUARIO_COMPANIA]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[COMPANIA_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_COMPANIA_USUARIO_USUARIO] FOREIGN KEY([COD_USUARIO])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[USUARIO] ([COD_USUARIO])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[COMPANIA_USUARIO] CHECK CONSTRAINT [FK_COMPANIA_USUARIO_USUARIO]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_ACTIVIDAD_ECONOMICA_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_ACTIVIDAD_ECONOMICA_20200208()
        Try
            If EXISTE_TABLA("ACTIVIDAD_ECONOMICA") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[ACTIVIDAD_ECONOMICA](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_ACT] [varchar](6) NOT NULL,"
                SQL &= Chr(13) & "		[DES_ACT] [varchar](200) NOT NULL,"
                SQL &= Chr(13) & "		[PRINCIPAL] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_ACTIVIDAD_ECONOMICA] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_ACT] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[ACTIVIDAD_ECONOMICA]  WITH CHECK ADD  CONSTRAINT [FK_ACTIVIDAD_ECONOMICA_COMPANIA] FOREIGN KEY([COD_CIA])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[ACTIVIDAD_ECONOMICA] CHECK CONSTRAINT [FK_ACTIVIDAD_ECONOMICA_COMPANIA]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_USUARIO_CONTRA_RECUPERACION_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_USUARIO_CONTRA_RECUPERACION_20200208()
        Try
            If EXISTE_TABLA("USUARIO_CONTRA_RECUPERACION") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[USUARIO_CONTRA_RECUPERACION](	"
                SQL &= Chr(13) & "		[CORREO] [varchar](150) NOT NULL,"
                SQL &= Chr(13) & "		[CODIGO_VERIFICADOR] [varchar](6) NOT NULL"
                SQL &= Chr(13) & "	) ON [PRIMARY]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_UNIDAD_MEDIDA_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_UNIDAD_MEDIDA_20200208()
        Try
            If EXISTE_TABLA("UNIDAD_MEDIDA") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[UNIDAD_MEDIDA](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_UNIDAD] [varchar](10) NOT NULL,"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](100) NOT NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_UNIDAD_MEDIDA] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_UNIDAD] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[UNIDAD_MEDIDA] ADD  CONSTRAINT [DF_UNIDAD_MEDIDA_ESTADO]  DEFAULT ('A') FOR [ESTADO]"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[UNIDAD_MEDIDA]  WITH CHECK ADD  CONSTRAINT [FK_UNIDAD_MEDIDA_COMPANIA1] FOREIGN KEY([COD_CIA])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[UNIDAD_MEDIDA] CHECK CONSTRAINT [FK_UNIDAD_MEDIDA_COMPANIA1]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_TIPO_CAMBIO_GENERAL_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_TIPO_CAMBIO_GENERAL_20200208()
        Try
            If EXISTE_TABLA("TIPO_CAMBIO_GENERAL") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[TIPO_CAMBIO_GENERAL](	"
                SQL &= Chr(13) & "		[BANCO] [varchar](200) NULL,"
                SQL &= Chr(13) & "		[COMPRA] [money] NULL,"
                SQL &= Chr(13) & "		[VENTA] [money] NULL,"
                SQL &= Chr(13) & "		[FECHA] [datetime] NULL"
                SQL &= Chr(13) & "	) ON [PRIMARY]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_TIPO_CAMBIO_CIA_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_TIPO_CAMBIO_CIA_20200208()
        Try
            If EXISTE_TABLA("TIPO_CAMBIO_CIA") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[TIPO_CAMBIO_CIA](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA] [datetime] NOT NULL,"
                SQL &= Chr(13) & "		[COMPRA] [money] NOT NULL,"
                SQL &= Chr(13) & "		[VENTA] [money] NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_TIPO_CAMBIO_CIA] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[FECHA] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[TIPO_CAMBIO_CIA]  WITH CHECK ADD  CONSTRAINT [FK_TIPO_CAMBIO_CIA_COMPANIA] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[TIPO_CAMBIO_CIA] CHECK CONSTRAINT [FK_TIPO_CAMBIO_CIA_COMPANIA]"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_SEGU_DERECHO_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_SEGU_DERECHO_20200208()
        Try
            If EXISTE_TABLA("SEGU_DERECHO") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[SEGU_DERECHO](	"
                SQL &= Chr(13) & "		[COD_SISTEMA] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[COD_DERECHO] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](100) NOT NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_SEGU_DERECHOS] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_DERECHO] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[SEGU_DERECHO] ADD  CONSTRAINT [DF_SEGU_DERECHO_ESTADO]  DEFAULT ('A') FOR [ESTADO]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_USUARIO_DERECHO_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_USUARIO_DERECHO_20200208()
        Try
            If EXISTE_TABLA("USUARIO_DERECHO") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[USUARIO_DERECHO](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_DERECHO] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_USUARIO_DERECHO] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_DERECHO] ASC,"
                SQL &= Chr(13) & "		[COD_USUARIO] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[USUARIO_DERECHO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_DERECHO_COD_CIA] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[USUARIO_DERECHO] CHECK CONSTRAINT [FK_USUARIO_DERECHO_COD_CIA]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[USUARIO_DERECHO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_DERECHO_DERECHO] FOREIGN KEY([COD_DERECHO])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SEGU_DERECHO] ([COD_DERECHO])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[USUARIO_DERECHO] CHECK CONSTRAINT [FK_USUARIO_DERECHO_DERECHO]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[USUARIO_DERECHO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_DERECHO_USUARIO] FOREIGN KEY([COD_USUARIO])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[USUARIO] ([COD_USUARIO])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[USUARIO_DERECHO] CHECK CONSTRAINT [FK_USUARIO_DERECHO_USUARIO]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_PROVINCIA_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_PROVINCIA_20200208()
        Try
            If EXISTE_TABLA("PROVINCIA") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[PROVINCIA](	"
                SQL &= Chr(13) & "		[CODIGO_PROVINCIA] [int] NOT NULL,"
                SQL &= Chr(13) & "		[NOMBRE] [varchar](50) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_PRIVINCIAS] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[CODIGO_PROVINCIA] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_PRODUCTO_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_PRODUCTO_20200208()
        Try
            If EXISTE_TABLA("PRODUCTO") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[PRODUCTO](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](150) NOT NULL,"
                SQL &= Chr(13) & "		[COD_UNIDAD] [varchar](10) NOT NULL,"
                SQL &= Chr(13) & "		[COSTO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[POR_IMPUESTO] [int] NOT NULL,"
                SQL &= Chr(13) & "		[COD_IMPUESTO_DGTD] [varchar](4) NOT NULL,"
                SQL &= Chr(13) & "		[PRECIO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[EXENTO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[ESTANTE] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[FILA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COLUMNA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[MINIMO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[COD_BARRA] [varchar](25) NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [nchar](10) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_PRODUCTO] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[COD_PROD] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PRODUCTO] ADD  CONSTRAINT [DF_PRODUCTO_ESTADO]  DEFAULT ('A') FOR [ESTADO]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_COMPANIA] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_COMPANIA]"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_PROVEEDOR] FOREIGN KEY([COD_CIA], [COD_SUCUR], [CEDULA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[PROVEEDOR] ([COD_CIA], [COD_SUCUR], [CEDULA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_PROVEEDOR]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_SUCURSAL] FOREIGN KEY([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_SUCURSAL]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_CANTON_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_CANTON_20200208()
        Try
            If EXISTE_TABLA("CANTON") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[CANTON](	"
                SQL &= Chr(13) & "		[CODIGO_PROVINCIA] [int] NOT NULL,"
                SQL &= Chr(13) & "		[CODIGO_CANTON] [int] NOT NULL,"
                SQL &= Chr(13) & "		[NOMBRE] [varchar](50) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_CANTON] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "([CODIGO_CANTON] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[CANTON]  WITH CHECK ADD  CONSTRAINT [FK_CANTON_PROVINCIA] FOREIGN KEY([CODIGO_PROVINCIA])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[PROVINCIA] ([CODIGO_PROVINCIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[CANTON] CHECK CONSTRAINT [FK_CANTON_PROVINCIA]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_DISTRITO_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_DISTRITO_20200208()
        Try
            If EXISTE_TABLA("DISTRITO") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[DISTRITO](	"
                SQL &= Chr(13) & "		[CODIGO_CANTON] [int] NOT NULL,"
                SQL &= Chr(13) & "		[CODIGO_DISTRITO] [int] NOT NULL,"
                SQL &= Chr(13) & "		[NOMBRE] [varchar](50) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_DISTRITO] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[CODIGO_CANTON] ASC,"
                SQL &= Chr(13) & "		[CODIGO_DISTRITO] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DISTRITO]  WITH CHECK ADD  CONSTRAINT [FK_CODIGO_CANTON] FOREIGN KEY([CODIGO_CANTON])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[CANTON] ([CODIGO_CANTON])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DISTRITO] CHECK CONSTRAINT [FK_CODIGO_CANTON]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_INFORMACION_GENERAL_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_INFORMACION_GENERAL_20200208()
        Try
            If EXISTE_TABLA("INFORMACION_GENERAL") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[INFORMACION_GENERAL](	"
                SQL &= Chr(13) & "		[EMAIL] [varchar](200) NULL,"
                SQL &= Chr(13) & "		[TOKEN] [varchar](50) NULL,"
                SQL &= Chr(13) & "		[CODIGO_COMPRA] [varchar](10) NULL,"
                SQL &= Chr(13) & "		[CODIGO_VENTA] [varchar](10) NULL"
                SQL &= Chr(13) & "	) ON [PRIMARY]	"
                SQL &= Chr(13) & "	INSERT INTO INFORMACION_GENERAL(EMAIL,TOKEN,CODIGO_COMPRA,CODIGO_VENTA)VALUES('repuestosenvios@gmail.com','OEA0M02S1R','317','318')"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_DOCUMENTO_ENC_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_DOCUMENTO_ENC_20200208()
        Try
            If EXISTE_TABLA("DOCUMENTO_ENC") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[DOCUMENTO_ENC](	"
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
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](250) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_DOCUMENTO_ENC] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENTO_ENC_CLIENTE1] FOREIGN KEY([COD_CIA], [CEDULA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[CLIENTE] ([COD_CIA], [CEDULA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_ENC] CHECK CONSTRAINT [FK_DOCUMENTO_ENC_CLIENTE1]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENTO_ENC_COMPANIA1] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_ENC] CHECK CONSTRAINT [FK_DOCUMENTO_ENC_COMPANIA1]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENTO_ENC_SUCURSAL1] FOREIGN KEY([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_ENC] CHECK CONSTRAINT [FK_DOCUMENTO_ENC_SUCURSAL1]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_ENC]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENTO_ENC_USUARIO1] FOREIGN KEY([COD_USUARIO])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[USUARIO] ([COD_USUARIO])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_ENC] CHECK CONSTRAINT [FK_DOCUMENTO_ENC_USUARIO1]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_DOCUMENTO_DET_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_DOCUMENTO_DET_20200208()
        Try
            If EXISTE_TABLA("DOCUMENTO_DET") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[DOCUMENTO_DET](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[COD_UNIDAD] [varchar](10) NOT NULL,"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,"
                SQL &= Chr(13) & "		[PRECIO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[POR_DESCUENTO] [int] NOT NULL,"
                SQL &= Chr(13) & "		[DESCUENTO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[POR_IMPUESTO] [int] NOT NULL,"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[SUBTOTAL] [money] NOT NULL,"
                SQL &= Chr(13) & "		[TOTAL] [money] NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_DOCUMENTO_DET] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[NUMERO_DOC] ASC,"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,"
                SQL &= Chr(13) & "		[LINEA] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_DET]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENTO_DET_COMPANIA] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_DET] CHECK CONSTRAINT [FK_DOCUMENTO_DET_COMPANIA]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_DET]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENTO_DET_DOCUMENTO_ENC] FOREIGN KEY([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[DOCUMENTO_ENC] ([COD_CIA], [COD_SUCUR], [NUMERO_DOC], [TIPO_MOV])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_DET] CHECK CONSTRAINT [FK_DOCUMENTO_DET_DOCUMENTO_ENC]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_DET]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENTO_DET_PRODUCTO] FOREIGN KEY([COD_CIA], [COD_SUCUR], [COD_PROD])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[PRODUCTO] ([COD_CIA], [COD_SUCUR], [COD_PROD])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_DET] CHECK CONSTRAINT [FK_DOCUMENTO_DET_PRODUCTO]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_DET]  WITH CHECK ADD  CONSTRAINT [FK_DOCUMENTO_DET_SUCURSAL] FOREIGN KEY([COD_CIA], [COD_SUCUR])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[DOCUMENTO_DET] CHECK CONSTRAINT [FK_DOCUMENTO_DET_SUCURSAL]"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_DOCUMENTO_ENC_TMP_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_DOCUMENTO_ENC_TMP_20200208()
        Try
            If EXISTE_TABLA("DOCUMENTO_ENC_TMP") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[DOCUMENTO_ENC_TMP](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
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
                SQL &= Chr(13) & "	 CONSTRAINT [PK_DOCUMENTO_ENC_TMP] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "([COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[CODIGO] ASC,"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_DOCUMENTO_DET_TMP_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_DOCUMENTO_DET_TMP_20200208()
        Try
            If EXISTE_TABLA("DOCUMENTO_DET_TMP") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[DOCUMENTO_DET_TMP](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[CODIGO] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[COD_UNIDAD] [varchar](10) NOT NULL,"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,"
                SQL &= Chr(13) & "		[PRECIO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[POR_DESCUENTO] [int] NOT NULL,"
                SQL &= Chr(13) & "		[DESCUENTO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[POR_IMPUESTO] [int] NOT NULL,"
                SQL &= Chr(13) & "		[IMPUESTO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[SUBTOTAL] [money] NOT NULL,"
                SQL &= Chr(13) & "		[TOTAL] [money] NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_DOCUMENTO_DET_TMP] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[CODIGO] ASC,"
                SQL &= Chr(13) & "		[TIPO_MOV] ASC,"
                SQL &= Chr(13) & "		[LINEA] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_IMPUESTO_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_IMPUESTO_20200208()
        Try
            If EXISTE_TABLA("IMPUESTO") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[IMPUESTO](	"
                SQL &= Chr(13) & "		[COD_IMPUESTO] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_IMPUESTO_DGTD] [varchar](6) NOT NULL,"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](180) NOT NULL,"
                SQL &= Chr(13) & "		[PORCENTAJE] [money] NOT NULL,"
                SQL &= Chr(13) & "		[VERSION] [money] NOT NULL,"
                SQL &= Chr(13) & "		[ESTADO] [char](1) NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_IMPUESTO] PRIMARY KEY CLUSTERED "
                SQL &= Chr(13) & "	(	"
                SQL &= Chr(13) & "		[COD_IMPUESTO] ASC,"
                SQL &= Chr(13) & "		[COD_IMPUESTO_DGTD] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[IMPUESTO] ADD  CONSTRAINT [DF_IMPUESTO_ESTADO]  DEFAULT ('A') FOR [ESTADO]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_INVENTARIO_COD_MOV_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_INVENTARIO_COD_MOV_20200208()
        Try
            If EXISTE_TABLA("INVENTARIO_COD_MOV") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[INVENTARIO_COD_MOV](	"
                SQL &= Chr(13) & "		[COD_MOV] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[DESCRIPCION] [varchar](200) NOT NULL,"
                SQL &= Chr(13) & "	PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_MOV] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_INVENTARIO_MOV_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_INVENTARIO_MOV_20200208()
        Try
            If EXISTE_TABLA("INVENTARIO_MOV") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[INVENTARIO_MOV](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[NUMERO_MOV] [int] IDENTITY(1,1) NOT NULL,"
                SQL &= Chr(13) & "		[COD_MOV] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[CEDULA] [varchar](25) NOT NULL,"
                SQL &= Chr(13) & "		[TIPO_MOV] [char](2) NOT NULL,"
                SQL &= Chr(13) & "		[NUMERO_DOC] [int] NOT NULL,"
                SQL &= Chr(13) & "		[COD_USUARIO] [varchar](8) NOT NULL,"
                SQL &= Chr(13) & "		[FECHA_INC] [datetime] NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_INVENTARIO_MOV] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[NUMERO_MOV] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_COMPANIA] FOREIGN KEY([COD_CIA])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV] CHECK CONSTRAINT [FK_INVENTARIO_MOV_COMPANIA]"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_INVENTARIO_COD_MOV] FOREIGN KEY([COD_MOV])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[INVENTARIO_COD_MOV] ([COD_MOV])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV] CHECK CONSTRAINT [FK_INVENTARIO_MOV_INVENTARIO_COD_MOV]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_SUCURSAL] FOREIGN KEY([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV] CHECK CONSTRAINT [FK_INVENTARIO_MOV_SUCURSAL]"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_USUARIO] FOREIGN KEY([COD_USUARIO])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[USUARIO] ([COD_USUARIO])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV] CHECK CONSTRAINT [FK_INVENTARIO_MOV_USUARIO]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
                CREACION_INVENTARIO_MOV_DET_20200208()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub CREACION_INVENTARIO_MOV_DET_20200208()
        Try
            If EXISTE_TABLA("INVENTARIO_MOV_DET") = False Then
                Dim SQL = "	CREATE TABLE [dbo].[INVENTARIO_MOV_DET](	"
                SQL &= Chr(13) & "		[COD_CIA] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[COD_SUCUR] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[NUMERO_MOV] [int] NOT NULL,"
                SQL &= Chr(13) & "		[COD_MOV] [varchar](3) NOT NULL,"
                SQL &= Chr(13) & "		[LINEA] [int] NOT NULL,"
                SQL &= Chr(13) & "		[COD_PROD] [varchar](20) NOT NULL,"
                SQL &= Chr(13) & "		[CANTIDAD] [money] NOT NULL,"
                SQL &= Chr(13) & "		[COSTO] [money] NOT NULL,"
                SQL &= Chr(13) & "		[COSTO_ANT] [money] NOT NULL,"
                SQL &= Chr(13) & "	 CONSTRAINT [PK_INVENTARIO_MOV_DET] PRIMARY KEY CLUSTERED 	"
                SQL &= Chr(13) & "	(	[COD_CIA] ASC,"
                SQL &= Chr(13) & "		[COD_SUCUR] ASC,"
                SQL &= Chr(13) & "		[NUMERO_MOV] ASC,"
                SQL &= Chr(13) & "		[LINEA] ASC"
                SQL &= Chr(13) & "	)) ON [PRIMARY]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_DET_COMPANIA] FOREIGN KEY([COD_CIA])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[COMPANIA] ([COD_CIA])"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET] CHECK CONSTRAINT [FK_INVENTARIO_MOV_DET_COMPANIA]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_DET_INVENTARIO_COD_MOV] FOREIGN KEY([COD_MOV])"
                SQL &= Chr(13) & "	REFERENCES [dbo].[INVENTARIO_COD_MOV] ([COD_MOV])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET] CHECK CONSTRAINT [FK_INVENTARIO_MOV_DET_INVENTARIO_COD_MOV]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_DET_INVENTARIO_MOV] FOREIGN KEY([COD_CIA], [COD_SUCUR], [NUMERO_MOV])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[INVENTARIO_MOV] ([COD_CIA], [COD_SUCUR], [NUMERO_MOV])	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET] CHECK CONSTRAINT [FK_INVENTARIO_MOV_DET_INVENTARIO_MOV]	"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_DET_PRODUCTO] FOREIGN KEY([COD_CIA], [COD_SUCUR], [COD_PROD])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[PRODUCTO] ([COD_CIA], [COD_SUCUR], [COD_PROD])"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET] CHECK CONSTRAINT [FK_INVENTARIO_MOV_DET_PRODUCTO]"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET]  WITH CHECK ADD  CONSTRAINT [FK_INVENTARIO_MOV_DET_SUCURSAL] FOREIGN KEY([COD_CIA], [COD_SUCUR])	"
                SQL &= Chr(13) & "	REFERENCES [dbo].[SUCURSAL] ([COD_CIA], [COD_SUCUR])"
                SQL &= Chr(13) & "	ALTER TABLE [dbo].[INVENTARIO_MOV_DET] CHECK CONSTRAINT [FK_INVENTARIO_MOV_DET_SUCURSAL]	"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(SQL)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class