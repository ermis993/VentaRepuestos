Imports CRF_CONEXIONES.CONEXIONES

Public Class Globales

    Public Shared CONX As New SQLCON
    Public Shared COD_CIA As String

    Public Property CONEXION() As SQLCON
        Get
            Return CONX
        End Get
        Set(ByVal value As SQLCON)
            CONX = value
        End Set
    End Property


    Public Shared Function GeneraCodigoSucursal()
        Try

            Dim SQL = "	SELECT ISNULL(MAX(COD_SUCUR),0) + 1 AS COD_SUCUR "
            SQL &= Chr(13) & "	FROM SUCURSAL "

            CONX.Coneccion_Abrir()
            Dim DS = CONX.EJECUTE_DS(SQL)
            CONX.Coneccion_Cerrar()

            Dim Codigo As String = DS.Tables(0).Rows(0).Item("COD_SUCUR")
            Return RellenaEspacioIzquierda(3, "0", Codigo)

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function RellenaEspacioIzquierda(ByVal Cantidad As String, ByVal Caracter As String, ByVal Texto As String) As String
        Try
            Return Texto.PadLeft(Cantidad, Caracter)
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
