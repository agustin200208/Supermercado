Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Public Class DatosCliente
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString

    Public Function InsertarCliente(nombre As String, telefono As String, correo As String) As Boolean
        Dim query As String = "INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Telefono", telefono)
                command.Parameters.AddWithValue("@Correo", correo)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Function BorrarCliente(ID As Integer, nombre As String, telefono As String, correo As String) As Boolean
        Dim query As String = "DELETE FROM clientes WHERE @ID=ID or Cliente = @Nombre OR Telefono = @Telefono OR Correo = @Correo"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID", ID)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Telefono", telefono)
                command.Parameters.AddWithValue("@Correo", correo)

                connection.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True ' Se borró al menos una fila
                Else
                    Return False ' No se borró ninguna fila
                End If
            End Using
        End Using
    End Function

    Public Function ModificarCliente(idCliente As Integer, nombre As String, telefono As String, correo As String) As Boolean
        Dim query As String = "UPDATE clientes SET Cliente = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE ID = @ID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Telefono", telefono)
                command.Parameters.AddWithValue("@Correo", correo)
                command.Parameters.AddWithValue("@ID", idCliente)

                connection.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Return True ' Se modificó al menos una fila
                Else
                    Return False ' No se modificó ninguna fila
                End If
            End Using
        End Using
    End Function


End Class
