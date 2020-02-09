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
        USP_FACTURACION_TMP_A_REAL_20200209()
    End Sub

    Public Shared Sub USP_FACTURACION_TMP_A_REAL_20200209()
        Try
            If EXISTE_SP("USP_FACTURACION_TMP_A_REAL", "2020-02-09") = False Then
                DROP_PROCEDURE("USP_FACTURACION_TMP_A_REAL")

                Dim Sql = "	CREATE PROCEDURE [dbo].[USP_FACTURACION_TMP_A_REAL] 											"
                Sql &= Chr(13) & "	 @COD_CIA VARCHAR(3)											"
                Sql &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)											"
                Sql &= Chr(13) & "	,@TIPO_MOV VARCHAR(2)											"
                Sql &= Chr(13) & "	,@CODIGO VARCHAR(20)											"
                Sql &= Chr(13) & "	AS											"
                Sql &= Chr(13) & "	BEGIN											"
                Sql &= Chr(13) & "		SET NOCOUNT ON;										"
                Sql &= Chr(13) & "		BEGIN TRY										"
                Sql &= Chr(13) & "		BEGIN TRAN TR_FACTURACION_TMP_A_REAL										"
                Sql &= Chr(13) & "		DECLARE @NUMERO_DOC INTEGER										"
                Sql &= Chr(13) & "												"
                Sql &= Chr(13) & "		IF @TIPO_MOV = 'FA' OR @TIPO_MOV = 'FC'										"
                Sql &= Chr(13) & "			BEGIN									"
                Sql &= Chr(13) & "				SELECT @NUMERO_DOC =  ISNULL(MAX(NUMERO_DOC), 0) + 1								"
                Sql &= Chr(13) & "				FROM DOCUMENTO_ENC								"
                Sql &= Chr(13) & "				WHERE COD_CIA = @COD_CIA								"
                Sql &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR								"
                Sql &= Chr(13) & "				AND TIPO_MOV <> 'NC' 								"
                Sql &= Chr(13) & "			END									"
                Sql &= Chr(13) & "		ELSE IF @TIPO_MOV = 'NC'										"
                Sql &= Chr(13) & "			BEGIN									"
                Sql &= Chr(13) & "				SELECT @NUMERO_DOC = ISNULL(MAX(NUMERO_DOC), 0) + 1								"
                Sql &= Chr(13) & "				FROM DOCUMENTO_ENC								"
                Sql &= Chr(13) & "				WHERE COD_CIA = @COD_CIA								"
                Sql &= Chr(13) & "				AND COD_SUCUR = @COD_SUCUR								"
                Sql &= Chr(13) & "				AND TIPO_MOV = 'NC'								"
                Sql &= Chr(13) & "			END									"
                Sql &= Chr(13) & "												"
                Sql &= Chr(13) & "			/*INGRESA EL ENCABEZADO*/									"
                Sql &= Chr(13) & "			INSERT INTO DOCUMENTO_ENC(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,MONTO,IMPUESTO,SALDO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,ESTADO,DESCRIPCION)									"
                Sql &= Chr(13) & "			SELECT TMP.COD_CIA,TMP.COD_SUCUR,@NUMERO_DOC,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO, SUM(DET.SUBTOTAL), SUM(DET.IMPUESTO), SUM(DET.TOTAL),TMP.COD_MONEDA									"
                Sql &= Chr(13) & "			,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO, 'A' AS ESTADO,TMP.DESCRIPCION									"
                Sql &= Chr(13) & "			FROM DOCUMENTO_ENC_TMP AS TMP									"
                Sql &= Chr(13) & "			INNER JOIN DOCUMENTO_DET_TMP AS DET	 								"
                Sql &= Chr(13) & "	            ON DET.COD_CIA = TMP.COD_CIA 											"
                Sql &= Chr(13) & "	            AND DET.COD_SUCUR = TMP.COD_SUCUR 											"
                Sql &= Chr(13) & "	            AND DET.CODIGO = TMP.CODIGO 											"
                Sql &= Chr(13) & "	            AND DET.TIPO_MOV = TMP.TIPO_MOV											"
                Sql &= Chr(13) & "			WHERE TMP.COD_CIA = @COD_CIA									"
                Sql &= Chr(13) & "			AND TMP.COD_SUCUR = @COD_SUCUR									"
                Sql &= Chr(13) & "			AND TMP.TIPO_MOV = 	@TIPO_MOV								"
                Sql &= Chr(13) & "			AND TMP.CODIGO = @CODIGO									"
                Sql &= Chr(13) & "			GROUP BY TMP.COD_CIA,TMP.COD_SUCUR,TMP.TIPO_MOV,TMP.CEDULA,TMP.FECHA,TMP.FECHA_INC,TMP.COD_USUARIO,TMP.COD_MONEDA,TMP.TIPO_CAMBIO,TMP.PLAZO,TMP.FORMA_PAGO,TMP.DESCRIPCION									"
                Sql &= Chr(13) & "												"
                Sql &= Chr(13) & "			/*INGRESA EL DETALLE*/									"
                Sql &= Chr(13) & "			INSERT INTO DOCUMENTO_DET(COD_CIA,COD_SUCUR,NUMERO_DOC,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL)									"
                Sql &= Chr(13) & "			SELECT COD_CIA,COD_SUCUR,@NUMERO_DOC,TIPO_MOV,ROW_NUMBER() OVER(ORDER BY LINEA ASC) AS LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL									"
                Sql &= Chr(13) & "			FROM DOCUMENTO_DET_TMP									"
                Sql &= Chr(13) & "			WHERE COD_CIA = @COD_CIA									"
                Sql &= Chr(13) & "			AND COD_SUCUR = @COD_SUCUR									"
                Sql &= Chr(13) & "			AND CODIGO = @CODIGO									"
                Sql &= Chr(13) & "												"
                Sql &= Chr(13) & "			DELETE FROM DOCUMENTO_ENC_TMP WHERE CODIGO = @CODIGO									"
                Sql &= Chr(13) & "	        DELETE FROM DOCUMENTO_DET_TMP WHERE CODIGO = @CODIGO											"
                Sql &= Chr(13) & "												"
                Sql &= Chr(13) & "		COMMIT TRAN TR_FACTURACION_TMP_A_REAL										"
                Sql &= Chr(13) & "		END TRY										"
                Sql &= Chr(13) & "		BEGIN CATCH 										"
                Sql &= Chr(13) & "	 		ROLLBACK TRAN									"
                Sql &= Chr(13) & "	 		DECLARE @MENSAJE VARCHAR(500)									"
                Sql &= Chr(13) & "	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())									"
                Sql &= Chr(13) & "	 		RAISERROR( @MENSAJE, 16, 1)									"
                Sql &= Chr(13) & "		END CATCH										"
                Sql &= Chr(13) & "	END											"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(Sql)
                CONX.Coneccion_Cerrar()
                USP_SUCURSAL_MANTENIMIENTO_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Sub USP_SUCURSAL_MANTENIMIENTO_20200209()
        Try
            If EXISTE_SP("USP_SUCURSAL_MANTENIMIENTO", "2020-02-09") = False Then
                DROP_PROCEDURE("USP_SUCURSAL_MANTENIMIENTO")
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
                DROP_PROCEDURE("USP_MANT_FACTURACION_TMP")
                Dim Sql = "	CREATE PROCEDURE [dbo].[USP_MANT_FACTURACION_TMP] "
                Sql &= Chr(13) & "	 @COD_CIA VARCHAR(3)"
                Sql &= Chr(13) & "	,@COD_SUCUR VARCHAR(3)	"
                Sql &= Chr(13) & "	,@CODIGO VARCHAR(20) "
                Sql &= Chr(13) & "	,@TIPO_MOV VARCHAR(2) "
                Sql &= Chr(13) & "	,@CEDULA VARCHAR(25) "
                Sql &= Chr(13) & "	,@FECHA DATETIME "
                Sql &= Chr(13) & "	,@COD_USUARIO VARCHAR(8) "
                Sql &= Chr(13) & "	,@COD_MONEDA CHAR(1) "
                Sql &= Chr(13) & "	,@TIPO_CAMBIO MONEY	"
                Sql &= Chr(13) & "	,@PLAZO INT				"
                Sql &= Chr(13) & "	,@FORMA_PAGO CHAR(2)		"
                Sql &= Chr(13) & "	,@DESCRIPCION VARCHAR(250)	"
                Sql &= Chr(13) & "	,@COD_PROD VARCHAR(20)		"
                Sql &= Chr(13) & "	,@COD_UNIDAD VARCHAR(10)	"
                Sql &= Chr(13) & "	,@CANTIDAD MONEY	"
                Sql &= Chr(13) & "	,@PRECIO MONEY		"
                Sql &= Chr(13) & "	,@POR_DESCUENTO INT		"
                Sql &= Chr(13) & "	,@DESCUENTO MONEY	"
                Sql &= Chr(13) & "	,@POR_IMPUESTO INT	"
                Sql &= Chr(13) & "	,@IMPUESTO MONEY	"
                Sql &= Chr(13) & "	,@SUBTOTAL MONEY	"
                Sql &= Chr(13) & "	,@TOTAL MONEY	"
                Sql &= Chr(13) & "	,@MODO INT		"
                Sql &= Chr(13) & "	AS				"
                Sql &= Chr(13) & "	BEGIN				"
                Sql &= Chr(13) & "		SET NOCOUNT ON;	"
                Sql &= Chr(13) & "		BEGIN TRY	"
                Sql &= Chr(13) & "		BEGIN TRAN TR_MANT_FACTURACION	"
                Sql &= Chr(13) & ""
                Sql &= Chr(13) & "		IF	@MODO = 1	"
                Sql &= Chr(13) & "		BEGIN		"
                Sql &= Chr(13) & "			IF NOT EXISTS(SELECT *		"
                Sql &= Chr(13) & "						  FROM DOCUMENTO_ENC_TMP	"
                Sql &= Chr(13) & "						  WHERE COD_CIA = @COD_CIA	"
                Sql &= Chr(13) & "                        AND COD_SUCUR = @COD_SUCUR				"
                Sql &= Chr(13) & "						  AND CODIGO = @CODIGO)	"
                Sql &= Chr(13) & "			BEGIN		"
                Sql &= Chr(13) & "				INSERT INTO DOCUMENTO_ENC_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,CEDULA,FECHA,FECHA_INC,COD_USUARIO,COD_MONEDA,TIPO_CAMBIO,PLAZO,FORMA_PAGO,DESCRIPCION)	"
                Sql &= Chr(13) & "				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, @CEDULA, @FECHA, GETDATE(), @COD_USUARIO, @COD_MONEDA, @TIPO_CAMBIO, @PLAZO, @FORMA_PAGO,@DESCRIPCION		"
                Sql &= Chr(13) & "					"
                Sql &= Chr(13) & "				INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL)		"
                Sql &= Chr(13) & "				SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL	"
                Sql &= Chr(13) & "				FROM DOCUMENTO_DET_TMP	"
                Sql &= Chr(13) & "				WHERE COD_CIA = @COD_CIA	"
                Sql &= Chr(13) & "              And COD_SUCUR = @COD_SUCUR	"
                Sql &= Chr(13) & "				AND CODIGO = @CODIGO "
                Sql &= Chr(13) & "			END			"
                Sql &= Chr(13) & "			ELSE		"
                Sql &= Chr(13) & "			BEGIN		"
                Sql &= Chr(13) & "				IF EXISTS(SELECT COD_PROD FROM DOCUMENTO_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)		"
                Sql &= Chr(13) & "				BEGIN		"
                Sql &= Chr(13) & "					UPDATE DOCUMENTO_DET_TMP"
                Sql &= Chr(13) & "					SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO	"
                Sql &= Chr(13) & "					   ,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL	"
                Sql &= Chr(13) & "					WHERE COD_CIA = @COD_CIA"
                Sql &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR	"
                Sql &= Chr(13) & "                  And CODIGO = @CODIGO	"
                Sql &= Chr(13) & "					AND COD_PROD = @COD_PROD	"
                Sql &= Chr(13) & "				END	"
                Sql &= Chr(13) & "				ELSE"
                Sql &= Chr(13) & "				BEGIN	"
                Sql &= Chr(13) & "					INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL)		"
                Sql &= Chr(13) & "					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL		"
                Sql &= Chr(13) & "					FROM DOCUMENTO_DET_TMP	"
                Sql &= Chr(13) & "					WHERE COD_CIA = @COD_CIA"
                Sql &= Chr(13) & "					AND COD_SUCUR = @COD_SUCUR"
                Sql &= Chr(13) & "                  And CODIGO = @CODIGO	"
                Sql &= Chr(13) & "				END		"
                Sql &= Chr(13) & "			END		"
                Sql &= Chr(13) & "		END			"
                Sql &= Chr(13) & "		ELSE IF @MODO = 3	"
                Sql &= Chr(13) & "		BEGIN	"
                Sql &= Chr(13) & "				IF EXISTS(SELECT COD_PROD FROM DOCUMENTO_DET_TMP WHERE COD_CIA = @COD_CIA AND COD_SUCUR = @COD_SUCUR AND CODIGO = @CODIGO AND COD_PROD = @COD_PROD)		"
                Sql &= Chr(13) & "				BEGIN		"
                Sql &= Chr(13) & "					UPDATE DOCUMENTO_DET_TMP"
                Sql &= Chr(13) & "					SET CANTIDAD = @CANTIDAD, PRECIO = @PRECIO, POR_DESCUENTO = @POR_DESCUENTO, DESCUENTO = @DESCUENTO	"
                Sql &= Chr(13) & "					   ,POR_IMPUESTO = @POR_IMPUESTO, IMPUESTO = @IMPUESTO, SUBTOTAL = @SUBTOTAL, TOTAL = @TOTAL	"
                Sql &= Chr(13) & "					WHERE COD_CIA = @COD_CIA "
                Sql &= Chr(13) & "                  And COD_SUCUR = @COD_SUCUR	"
                Sql &= Chr(13) & "					AND CODIGO = @CODIGO "
                Sql &= Chr(13) & "                  And COD_PROD = @COD_PROD	"
                Sql &= Chr(13) & "				END	"
                Sql &= Chr(13) & "				ELSE "
                Sql &= Chr(13) & "				BEGIN	"
                Sql &= Chr(13) & "					INSERT INTO DOCUMENTO_DET_TMP(COD_CIA,COD_SUCUR,CODIGO,TIPO_MOV,LINEA,COD_PROD,COD_UNIDAD,CANTIDAD,PRECIO,POR_DESCUENTO,DESCUENTO,POR_IMPUESTO,IMPUESTO,SUBTOTAL,TOTAL)		"
                Sql &= Chr(13) & "					SELECT @COD_CIA, @COD_SUCUR, @CODIGO, @TIPO_MOV, ISNULL(MAX(LINEA), 0) + 1, @COD_PROD, @COD_UNIDAD, @CANTIDAD, @PRECIO, @POR_DESCUENTO, @DESCUENTO, @POR_IMPUESTO, @IMPUESTO, @SUBTOTAL, @TOTAL	"
                Sql &= Chr(13) & "					FROM DOCUMENTO_DET_TMP	"
                Sql &= Chr(13) & "					WHERE COD_CIA = @COD_CIA	"
                Sql &= Chr(13) & "                  And COD_SUCUR = @COD_SUCUR	"
                Sql &= Chr(13) & "					AND CODIGO = @CODIGO	"
                Sql &= Chr(13) & "				END		"
                Sql &= Chr(13) & "		END			"
                Sql &= Chr(13) & "		COMMIT TRAN TR_MANT_FACTURACION 	"
                Sql &= Chr(13) & "		END TRY		"
                Sql &= Chr(13) & "		BEGIN CATCH 	"
                Sql &= Chr(13) & "	 		ROLLBACK TRAN	"
                Sql &= Chr(13) & "	 		DECLARE @MENSAJE VARCHAR(500)	"
                Sql &= Chr(13) & "	 		SET @MENSAJE =( SELECT ERROR_MESSAGE())	"
                Sql &= Chr(13) & "	 		RAISERROR( @MENSAJE, 16, 1)		"
                Sql &= Chr(13) & "		END CATCH	"
                Sql &= Chr(13) & "	END			"


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
        Try
            Dim SQL = "	DROP PROCEDURE " & NOMBRE
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception

        End Try
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
        Try
            Dim SQL = "	DROP TRIGGER " & NOMBRE
            CONX.Coneccion_Abrir()
            CONX.EJECUTE(SQL)
            CONX.Coneccion_Cerrar()
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub INVENTARIO_MOV_TG_20200209()
        Try
            If EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_ENC", "2020-02-09") = False Then
                DROP_TRIGGER("TG_INGRESA_INVENTARIO_MOV_ENC")
                Dim Sql = "	CREATE TRIGGER TG_INGRESA_INVENTARIO_MOV_ENC 										"
                Sql &= Chr(13) & "	   ON  DOCUMENTO_ENC 										"
                Sql &= Chr(13) & "	   AFTER INSERT										"
                Sql &= Chr(13) & "	AS 										"
                Sql &= Chr(13) & "	BEGIN										"
                Sql &= Chr(13) & "		SET NOCOUNT ON;									"
                Sql &= Chr(13) & "											"
                Sql &= Chr(13) & "		INSERT INTO INVENTARIO_MOV(COD_CIA,COD_SUCUR,COD_MOV,CEDULA,TIPO_MOV,NUMERO_DOC,COD_USUARIO,FECHA_INC)									"
                Sql &= Chr(13) & "		SELECT I.COD_CIA, COD_SUCUR, 'SPV' AS COD_MOV, I.CEDULA, TIPO_MOV, NUMERO_DOC, COD_USUARIO, I.FECHA_INC									"
                Sql &= Chr(13) & "		FROM inserted AS I									"
                Sql &= Chr(13) & "											"
                Sql &= Chr(13) & "	END										"
                CONX.Coneccion_Abrir()
                CONX.EJECUTE(Sql)
                CONX.Coneccion_Cerrar()
                INVENTARIO_MOV_DET_TG_20200209()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Shared Sub INVENTARIO_MOV_DET_TG_20200209()
        Try
            If EXISTE_TRIGGER("TG_INGRESA_INVENTARIO_MOV_DET", "2020-02-09") = False Then
                DROP_TRIGGER("TG_INGRESA_INVENTARIO_MOV_DET")

                Dim Sql = "	CREATE TRIGGER TG_INGRESA_INVENTARIO_MOV_DET 											"
                Sql &= Chr(13) & "	   ON  DOCUMENTO_DET 											"
                Sql &= Chr(13) & "	   AFTER INSERT											"
                Sql &= Chr(13) & "	AS 											"
                Sql &= Chr(13) & "	BEGIN											"
                Sql &= Chr(13) & "		SET NOCOUNT ON;										"
                Sql &= Chr(13) & "												"
                Sql &= Chr(13) & "		INSERT INTO INVENTARIO_MOV_DET(COD_CIA,COD_SUCUR,NUMERO_MOV,COD_MOV,LINEA,COD_PROD,CANTIDAD,COSTO,COSTO_ANT)										"
                Sql &= Chr(13) & "		SELECT I.COD_CIA, I.COD_SUCUR, MOV.NUMERO_MOV, MOV.COD_MOV, I.LINEA, I.COD_PROD, I.CANTIDAD, PROD.COSTO, PROD.COSTO										"
                Sql &= Chr(13) & "		FROM inserted AS I										"
                Sql &= Chr(13) & "		INNER JOIN INVENTARIO_MOV AS MOV										"
                Sql &= Chr(13) & "			ON MOV.COD_CIA = I.COD_CIA									"
                Sql &= Chr(13) & "			AND MOV.COD_SUCUR = I.COD_SUCUR									"
                Sql &= Chr(13) & "			AND MOV.NUMERO_DOC = I.NUMERO_DOC									"
                Sql &= Chr(13) & "		INNER JOIN PRODUCTO AS PROD										"
                Sql &= Chr(13) & "			ON PROD.COD_CIA = I.COD_CIA									"
                Sql &= Chr(13) & "			AND PROD.COD_PROD = I.COD_PROD									"
                Sql &= Chr(13) & "	END											"

                CONX.Coneccion_Abrir()
                CONX.EJECUTE(Sql)
                CONX.Coneccion_Cerrar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "TABLAS"
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

                SQL &= Chr(13) & "	INSERT INTO PROVINCIA(CODIGO_PROVINCIA,NOMBRE)					"
                SQL &= Chr(13) & "	SELECT 1,'San José'					"
                SQL &= Chr(13) & "	INSERT INTO PROVINCIA(CODIGO_PROVINCIA,NOMBRE)					"
                SQL &= Chr(13) & "	SELECT 2,'Alajuela'					"
                SQL &= Chr(13) & "	INSERT INTO PROVINCIA(CODIGO_PROVINCIA,NOMBRE)					"
                SQL &= Chr(13) & "	SELECT 3,'Cartago'					"
                SQL &= Chr(13) & "	INSERT INTO PROVINCIA(CODIGO_PROVINCIA,NOMBRE)					"
                SQL &= Chr(13) & "	SELECT 4,'Heredia'					"
                SQL &= Chr(13) & "	INSERT INTO PROVINCIA(CODIGO_PROVINCIA,NOMBRE)					"
                SQL &= Chr(13) & "	SELECT 5,'Guanacaste'					"
                SQL &= Chr(13) & "	INSERT INTO PROVINCIA(CODIGO_PROVINCIA,NOMBRE)					"
                SQL &= Chr(13) & "	SELECT 6,'Puntarenas'					"
                SQL &= Chr(13) & "	INSERT INTO PROVINCIA(CODIGO_PROVINCIA,NOMBRE)					"
                SQL &= Chr(13) & "	SELECT 7,'Limon'					"
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

                SQL &= Chr(13) & "	INSERT INTO CANTON(CODIGO_PROVINCIA,CODIGO_CANTON,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 1,101,'San José'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,102,'Escazú'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,103,'Desamparados'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,104,'Puriscal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,105,'Tarrazú'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,106,'Aserrí'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,107,'Mora'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,108,'Goicoechea'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,109,'Santa Ana'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,110,'Alajuelita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,111,'Vásquez de Coronado'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,112,'Acosta'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,113,'Tibás'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,114,'Moravia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,115,'Montes de Oca'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,116,'Turrubares'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,117,'Dota'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,118,'Curridabat'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,119,'Pérez Zeledón'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 1,120,'León Cortéz Castro'						"

                SQL &= Chr(13) & "	INSERT INTO CANTON(CODIGO_PROVINCIA,CODIGO_CANTON,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 2,201,'Alajuela'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,202,'San Ramón'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,203,'Grecia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,204,'San Mateo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,205,'Atenas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,206,'Naranjo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,207,'Palmares'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,208,'Poás'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,209,'Orotina'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,210,'San Carlos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,211,'Zarcero'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,212,'Valverde Vega'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,213,'Upala'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,214,'Los Chiles'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 2,215,'Guatuso'						"

                SQL &= Chr(13) & "	INSERT INTO CANTON(CODIGO_PROVINCIA,CODIGO_CANTON,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 3,301,'Cartago'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 3,302,'Paraíso'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 3,303,'La Unión'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 3,304,'Jiménez'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 3,305,'Turrialba'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 3,306,'Alvarado'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 3,307,'Oreamuno'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 3,308,'El Guarco'						"

                SQL &= Chr(13) & "	INSERT INTO CANTON(CODIGO_PROVINCIA,CODIGO_CANTON,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 4,401,'Heredia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,402,'Barva'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,403,'Santo Domingo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,404,'Santa Bárbara'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,405,'San Rafaél'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,406,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,407,'Belén'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,408,'Flores'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,409,'San Pablo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 4,410,'Sarapiquí'						"

                SQL &= Chr(13) & "	INSERT INTO CANTON(CODIGO_PROVINCIA,CODIGO_CANTON,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 5,501,'Liberia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,502,'Nicoya'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,503,'Santa Cruz'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,504,'Bagaces'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,505,'Carrillo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,506,'Cañas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,507,'Abangáres'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,508,'Tilarán'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,509,'Nandayure'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,510,'La Cruz'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 5,511,'Hojancha'						"

                SQL &= Chr(13) & "	INSERT INTO CANTON(CODIGO_PROVINCIA,CODIGO_CANTON,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 6,601,'Puntarenas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,602,'Esparza'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,603,'Buenos Aires'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,604,'Montes de Oro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,605,'Osa'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,606,'Aguirre'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,607,'Golfito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,608,'Coto Brus'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,609,'Parrita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,610,'Corredores'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 6,611,'Garabito'						"

                SQL &= Chr(13) & "	INSERT INTO CANTON(CODIGO_PROVINCIA,CODIGO_CANTON,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 7,701,'Limón'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 7,702,'Pococí'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 7,703,'Siquirres'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 7,704,'Talamanca'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 7,705,'Matina'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 7,706,'Guácimo'						"
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

                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 101,10101,'Carmen'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10102,'Merced'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10103,'Hospital'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10104,'Catedral'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10105,'Zapote'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10106,'San Francisco de Dos Ríos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10107,'Uruca'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10108,'Mata Redonda'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10109,'Pavas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10110,'Hatillo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 101,10111,'San Sebastián'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 102,10201,'Escazú'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 102,10202,'San Antonio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 102,10203,'San Rafael'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 103,10301,'Desamparados'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10302,'San Miguel'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10303,'San Juan de Dios'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10304,'San Rafael Arriba'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10305,'San Antonio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10306,'Frailes'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10307,'Patarrá'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10308,'San Cristóbal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10309,'Rosario'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10310,'Damas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10311,'San Rafael Abajo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10312,'Gravilias'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 103,10313,'Los Guido'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 104,10401,'Santiago'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 104,10402,'Mercedes Sur'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 104,10403,'Barbacoas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 104,10404,'Grifo Alto'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 104,10405,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 104,10406,'Candelaria'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 104,10407,'Desamparaditos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 104,10408,'San Antonio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 104,10409,'Chires'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 105,10501,'San Marcos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 105,10502,'San Lorenzo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 105,10503,'San Carlos'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 106,10601,'Aserrí'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 106,10602,'Tarbaca o Praga'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 106,10603,'Vuelta de Jorco'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 106,10604,'San Gabriel'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 106,10605,'La Legua'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 106,10606,'Monterrey'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 106,10607,'Salitrillos'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 107,10701,'Colón'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 107,10702,'Guayabo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 107,10703,'Tabarcia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 107,10704,'Piedras Negras'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 107,10705,'Picagres'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 108,10801,'Guadalupe'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 108,10802,'San Francisco'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 108,10803,'Calle Blancos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 108,10804,'Mata de Plátano'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 108,10805,'Ipís'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 108,10806,'Rancho Redondo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 108,10807,'Purral'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 109,10901,'Santa Ana'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 109,10902,'Salitral'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 109,10903,'Pozos o Concepción'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 109,10904,'Uruca o San Joaquín'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 109,10905,'Piedades	'					"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 109,10906,'Brasil'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 110,11001,'Alajuelita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 110,11002,'San Josecito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 110,11003,'San Antonio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 110,11004,'Concepción'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 110,11005,'San Felipe'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 111,11101,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 111,11102,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 111,11103,'Dulce Nombre o Jesús'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 111,11104,'Patalillo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 111,11105,'Cascajal'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 112,11201,'San Ignacio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 112,11202,'Guaitil'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 112,11203,'Palmichal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 112,11204,'Cangrejal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 112,11205,'Sabanillas'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 113,11301,'San Juan'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 113,11302,'Cinco Esquinas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 113,11303,'Anselmo Llorente'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 113,11304,'León XIII	'					"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 113,11305,'Colima'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 114,11401,'San Vicente'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 114,11402,'San Jerónimo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 114,11403,'La Trinidad'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 115,11501,'San Pedro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 115,11502,'Sabanilla'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 115,11503,'Mercedes o Betania'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 115,11504,'San Rafael'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 116,11601,'San Pablo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 116,11602,'San Pedro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 116,11603,'San Juan de Mata'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 116,11604,'San Luis'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 116,11605,'Carara'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 117,11701,'Santa María'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 117,11702,'Jardín'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 117,11703,'Copey'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 118,11801,'Curridabat'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 118,11802,'Granadilla'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 118,11803,'Sánchez'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 118,11804,'Tirrases'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 119,11901,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11902,'General'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11903,'Daniel Flores'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11904,'Rivas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11905,'San Pedro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11906,'Platanares'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11907,'Pejibaye'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11908,'Cajón o Carmen'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11909,'Barú'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11910,'Río Nuevo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 119,11911,'Páramo'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 120,12001,'San Pablo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 120,12002,'San Andrés'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 120,12003,'Llano Bonito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 120,12004,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 120,12005,'Santa Cruz'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 120,12006,'San Antonio'						"

                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 201,20101,'Alajuela'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20102,'San José'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20103,'Carrizal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20104,'San Antonio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20105,'Guácima'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20106,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20107,'Sabanilla'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20108,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20109,'Río Segundo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20110,'Desamparados'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20111,'Turrucares'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20112,'Tambor'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20113,'La Garita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 201,20114,'Sarapiquí'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 202,20201,'San Ramón'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20202,'Santiago'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20203,'San Juan'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20204,'Piedades Norte'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20205,'Piedades Sur'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20206,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20207,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20208,'Angeles'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20209,'Alfaro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20210,'Volio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20211,'Concepción'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20212,'Zapotal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 202,20213,'San Isidro de Peñas Blancas'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 203,20301,'Grecia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 203,20302,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 203,20303,'San José'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 203,20304,'San Roque'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 203,20305,'Tacares'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 203,20306,'Río Cuarto'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 203,20307,'Puente Piedra'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 203,20308,'Bolívar'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 204,20401,'San Mateo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 204,20402,'Desmonte'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 204,20403,'Jesús María'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 205,20501,'Atenas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 205,20502,'Jesús'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 205,20503,'Mercedes'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 205,20504,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 205,20505,'Concepción'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 205,20506,'San José'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 205,20507,'Santa Eulalia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 205,20508,'Escobal'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 206,20601,'Naranjo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 206,20602,'San Miguel'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 206,20603,'San José'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 206,20604,'Cirrí Sur'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 206,20605,'San Jerónimo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 206,20606,'San Juan'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 206,20607,'Rosario'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 207,20701,'Palmares'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 207,20702,'Zaragoza'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 207,20703,'Buenos Aires'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 207,20704,'Santiago'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 207,20705,'Candelaria'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 207,20706,'Esquipulas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 207,20707,'La Granja'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 208,20801,'San Pedro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 208,20802,'San Juan'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 208,20803,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 208,20804,'Carrillos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 208,20805,'Sabana Redonda'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 209,20901,'Orotina'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 209,20902,'Mastate'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 209,20903,'Hacienda Vieja'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 209,20904,'Coyolar'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 209,20905,'Ceiba'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 210,21001,'Quesada'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21002,'Florencia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21003,'Buenavista'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21004,'Aguas Zarcas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21005,'Venecia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21006,'Pital'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21007,'Fortuna'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21008,'Tigra'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21009,'Palmera'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21010,'Venado'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21011,'Cutris'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21012,'Monterrey'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 210,21013,'Pocosol'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 211,21101,'Zarcero'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 211,21102,'Laguna'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 211,21103,'Tapezco'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 211,21104,'Guadalupe'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 211,21105,'Palmira'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 211,21106,'Zapote'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 211,21107,'Brisas'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 212,21201,'Sarchí Norte'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 212,21202,'Sarchí Sur'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 212,21203,'Toro Amarillo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 212,21204,'San Pedro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 212,21205,'Rodríguez'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 213,21301,'Upala'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 213,21302,'Aguas Claras'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 213,21303,'San José o Pizote'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 213,21304,'Bijagua'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 213,21305,'Delicias'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 213,21306,'Dos Ríos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 213,21307,'Yolillal'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 214,21401,'Los Chiles'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 214,21402,'Caño Negro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 214,21403,'Amparo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 214,21404,'San Jorge'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 215,21501,'San Rafae'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 215,21502,'Buenavista'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 215,21503,'Cote'						"

                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 301,30101,'Oriental'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30102,'Occidental'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30103,'Carmen'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30104,'San Nicolás'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30105,'Aguacaliente (San Francisco)'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30106,'Guadalupe (Arenilla)'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30107,'Corralillo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30108,'Tierra Blanca'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30109,'Dulce Nombre'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30110,'Llano Grande'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 301,30111,'Quebradilla'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 302,30201,'Paraíso'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 302,30202,'Santiago'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 302,30203,'Orosi'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 302,30204,'Cachí'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 302,30205,'Llanos de Sta Lucia'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 303,30301,'Tres Ríos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 303,30302,'San Diego'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 303,30303,'San Juan'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 303,30304,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 303,30305,'Concepción'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 303,30306,'Dulce Nombre'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 303,30307,'San Ramón'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 303,30308,'Río Azul'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 304,30401,'Juan Viñas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 304,30402,'Tucurrique'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 304,30403,'Pejibaye'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 305,30501,'Turrialba'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30502,'La Suiza'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30503,'Peralta'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30504,'Santa Cruz'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30505,'Santa Teresita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30506,'Pavones'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30507,'Tuis'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30508,'Tayutic'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30509,'Santa Rosa'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30510,'Tres Equis'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30511,'La Isabel'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 305,30512,'Chirripo'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 306,30601,'Pacayas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 306,30602,'Cervantes'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 306,30603,'Capellades'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 307,30701,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 307,30702,'Cot'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 307,30703,'Potrero Cerrado'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 307,30704,'Cipreses'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 307,30705,'Santa Rosa'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 308,30801,'El Tejar'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 308,30802,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 308,30803,'Tobosi'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 308,30804,'Patio de Agua'						"



                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 401,40101,'Heredia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 401,40102,'Mercedes'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 401,40103,'San Francisco'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 401,40104,'Ulloa'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 401,40105,'Vara Blanca'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 402,40201,'Barva'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 402,40202,'San Pedro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 402,40203,'San Pablo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 402,40204,'San Roque'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 402,40205,'Santa Lucía'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 402,40206,'San José de la Montaña'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 403,40301,'Santo Domingo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 403,40302,'San Vicente'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 403,40303,'San Miguel'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 403,40304,'Paracito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 403,40305,'Santo Tomás'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 403,40306,'Santa Rosa'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 403,40307,'Tures'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 403,40308,'Pará'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 404,40401,'Santa Bárbara'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 404,40402,'San Pedro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 404,40403,'San Juan'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 404,40404,'Jesús'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 404,40405,'Santo Domingo del Roble'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 404,40406,'Puraba'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 405,40501,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 405,40502,'San Josecito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 405,40503,'Santiago'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 405,40504,'Angeles'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 405,40505,'Concepción'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 406,40601,'San Isidro'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 406,40602,'San José'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 406,40603,'Concepción'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 406,40604,'San Francisco'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 407,40701,'San Antonio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 407,40702,'La Rivera'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 407,40703,'Asunción'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 408,40801,'San Joaquín'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 408,40802,'Barrantes'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 408,40803,'Llorente'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 409,40901,'San Pablo'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 410,41001,'Puerto Viejo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 410,41002,'La Virgen'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 410,41003,'Horquetas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 410,41004,'Llanuras del Gaspar'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 410,4105,'Cureña'						"


                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 501,50101,'Liberia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 501,50102,'Cañas Dulces'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 501,50103,'Mayorga'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 501,50104,'Nacascolo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 501,50105,'Curubande'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 502,50201,'Nicoya'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 502,50202,'Mansión'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 502,50203,'San Antonio'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 502,50204,'Quebrada Honda'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 502,50205,'Sámara'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 502,50206,'Nosara'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 502,50207,'Belén de Nosarita'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 503,50301,'Santa Cruz'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 503,50302,'Bolsón'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 503,50303,'Veintisiete de Abril'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 503,50304,'Tempate'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 503,50305,'Cartagena'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 503,50306,'Cuajiniquil'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 503,50307,'Diriá'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 503,50308,'Cabo Velas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 503,50309,'Tamarindo'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 504,50401,'Bagaces'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 504,50402,'Fortuna'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 504,50403,'Mogote'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 504,50404,'Río Naranjo'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 505,50501,'Filadelfia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 505,50502,'Palmira'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 505,50503,'Sardinal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 505,50504,'Belén'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 506,50601,'Cañas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 506,50602,'Palmira'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 506,50603,'San Miguel'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 506,50604,'Bebedero'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 506,50605,'Porozal'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 507,50701,'Juntas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 507,50702,'Sierra'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 507,50703,'San Juan'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 507,50704,'Colorado'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 508,50801,'Tilarán'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 508,50802,'Quebrada Grande'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 508,50803,'Tronadora'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 508,50804,'Santa Rosa'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 508,50805,'Líbano'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 508,50806,'Tierras Morenas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 508,50807,'Arenal'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 509,50901,'Carmona'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 509,50902,'Santa Rita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 509,50903,'Zapotal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 509,50904,'San Pablo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 509,50905,'Porvenir'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 509,50906,'Bejuco'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 510,51001,'La Cruz'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 510,51002,'Santa Cecilia'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 510,51003,'Garita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 510,51004,'Santa Elena'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 511,51101,'Hojancha'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 511,51102,'Monte Romo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 511,51103,'Puerto Carrillo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 511,51104,'Huacas'						"


                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 601,60101,'Puntarenas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60102,'Pitahaya'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60103,'Chomes'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60104,'Lepanto'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60105,'Paquera'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60106,'Manzanillo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60107,'Guacimal'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60108,'Barranca'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60109,'Monte Verde'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60110,'Isla del Coco'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60111,'Cóbano'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60112,'Chacarita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60113,'Chira (Isla)'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60114,'Acapulco'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60115,'El Roble'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 601,60116,'Arancibia'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 602,60201,'Espíritu Santo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 602,60202,'San Juan Grande'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 602,60203,'Macacona'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 602,60204,'San Rafael'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 602,60205,'San Jerónimo'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 603,60301,'Buenos Aires'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 603,60302,'Volcán'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 603,60303,'Potrero Grande'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 603,60304,'Boruca'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 603,60305,'Pilas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 603,60306,'Colinas o Bajo de Maíz'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 603,60307,'Chánguena'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 603,60308,'Bioley'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 603,60309,'Brunka'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 604,60401,'Miramar'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 604,60402,'Unión'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 604,60403,'San Isidro'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 605,60501,'Puerto Cortés'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 605,60502,'Palmar'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 605,60503,'Sierpe'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 605,60504,'Bahía Ballena'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 605,60505,'Piedras Blancas'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 606,60601,'Quepos'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 606,60602,'Savegre'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 606,60603,'Naranjito'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 607,60701,'Golfito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 607,60702,'Puerto Jiménez'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 607,60703,'Guaycará'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 607,60704,'Pavones o Villa Conte'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 608,60801,'San Vito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 608,60802,'Sabalito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 608,60803,'Agua Buena'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 608,60804,'Limoncito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 608,60805,'Pittier'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 609,60901,'Parrita'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 610,61001,'Corredores'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 610,61002,'La Cuesta'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 610,61003,'Paso Canoas'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 610,61004,'Laurel'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 611,61101,'Jacó'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 611,61102,'Tárcoles'						"


                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 701,70101,'Limón'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 701,701O2,'Valle La Estrella'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 701,70103,'Río Blanco'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 701,70104,'Matama'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 702,70201,'Guápiles'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 702,70202,'Jiménez'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 702,70203,'Rita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 702,70204,'Roxana'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 702,70205,'Cariari'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 702,70206,'Colorado'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 703,70301,'Siquirres'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 703,70302,'Pacuarito'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 703,70303,'Florida'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 703,70304,'Germania'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 703,70305,'Cairo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 703,70306,'Alegría'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 704,70401,'Bratsi'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 704,70402,'Sixaola'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 704,70403,'Cahuita'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 704,70405,'Telire'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 705,70501,'Matina'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 705,70502,'Batán'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 705,70503,'Carrandí'						"
                SQL &= Chr(13) & "							"
                SQL &= Chr(13) & "	INSERT INTO DISTRITO(CODIGO_CANTON,CODIGO_DISTRITO,NOMBRE)						"
                SQL &= Chr(13) & "	SELECT 706,70601,'Guácimo'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 706,70602,'Mercedes'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 706,70603,'Pocora'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 706,70604,'Río Jiménez'						"
                SQL &= Chr(13) & "	UNION ALL						"
                SQL &= Chr(13) & "	SELECT 706,70605,'Duacarí'						"

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


End Class