Imports System.Data.SqlClient
Public Class Class1
    Dim cnx As New SqlConnection("server=ELIAN\MSSQLSERVER01;integrated security=true;Database=Trabajadores")

    Public Function ListarEmpleados() As DataTable
        Dim da As New SqlDataAdapter("pb_listar", cnx)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function Insertar(nom As String, direc As String, fechaing As Date, fechasal As Date, area As Char)
        Dim da As New SqlCommand("pb_nuevo", cnx)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@nombre", nom)
        da.Parameters.AddWithValue("@direccion", direc)
        da.Parameters.AddWithValue("@fechaing", fechaing)
        da.Parameters.AddWithValue("@fechater", fechasal)
        da.Parameters.AddWithValue("@area", area)
        cnx.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            cnx.Close()
        Catch ex As Exception
            MsgBox("Error al registrar usuario")
        End Try
        Return resp
    End Function

    Public Function Eliminar(codigo As String)
        Dim elim As New SqlCommand("pb_eliminar", cnx)
        elim.CommandType = CommandType.StoredProcedure
        elim.Parameters.AddWithValue("@codigo", codigo)
        cnx.Open()
        Dim elim1 As String = elim.ExecuteNonQuery
        cnx.Close()
        Return elim1
    End Function

    Public Function Modificar(codigo As String, nombre As String, direccion As String, fechaing As Date, fechasal As Date, area As Char) As Integer
        Dim act As New SqlCommand("pb_modificar", cnx)
        act.CommandType = CommandType.StoredProcedure
        act.Parameters.AddWithValue("@codigo", codigo)
        act.Parameters.AddWithValue("@nombre", nombre)
        act.Parameters.AddWithValue("@direccion", direccion)
        act.Parameters.AddWithValue("@fechaing", fechaing)
        act.Parameters.AddWithValue("@fechater", fechasal)
        act.Parameters.AddWithValue("@area", area)
        cnx.Open()
        Dim actu1 As String = act.ExecuteNonQuery
        cnx.Close()
        Return actu1
    End Function

End Class
