Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Public Class DatosProductos
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString

    Public Function InsertarProducto(nombre As String, precio As String, Categoria As String) As Boolean
        Dim query As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Precio", precio)
                command.Parameters.AddWithValue("@Categoria", Categoria)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Function BorrarProducto(nombre As String, precio As String, categoria As String) As Boolean
        Dim query As String = "DELETE FROM productos WHERE Nombre = @Nombre OR Precio = @Precio OR Categoria = @Categoria"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Precio", precio)
                command.Parameters.AddWithValue("@Categoria", categoria)

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

    Public Function ModificarProducto(idProducto As Integer, nombre As String, precio As String, Categoria As String) As Boolean
        Dim query As String = "UPDATE Productos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria WHERE ID = @ID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Precio", precio)
                command.Parameters.AddWithValue("@Categoria", Categoria)
                command.Parameters.AddWithValue("@ID", idProducto)

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

    Private Sub BuscarCliente(criterio As String, valorBusqueda As String)
        Dim query As String = ""

        Select Case criterio
            Case "ID"
                query = "SELECT * FROM clientes WHERE ID LIKE '%' + @ValorBusqueda + '%'"
            Case "Nombre"
                query = "SELECT * FROM clientes WHERE Cliente LIKE '%' + @ValorBusqueda + '%'"
            Case "Telefono"
                query = "SELECT * FROM clientes WHERE Telefono LIKE '%' + @ValorBusqueda + '%'"
            Case "Correo"
                query = "SELECT * FROM clientes WHERE Correo LIKE '%' + @ValorBusqueda + '%'"
        End Select
    End Sub
End Class
