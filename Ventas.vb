Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Public Class VentaDatos
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString

    Public Function IncertarVenta(idCliente As Integer, fecha As DateTime, total As Double) As Boolean
        Dim query As String = "INSERT INTO ventas (IDCliente, Fecha, Total) VALUES (@IDCliente, @Fecha, @Total)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IDCliente", idCliente)
                command.Parameters.AddWithValue("@Fecha", fecha)
                command.Parameters.AddWithValue("@Total", total)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Function EliminarVenta(idVenta As Integer) As Boolean
        Dim query As String = "DELETE FROM ventas WHERE ID = @IDVenta"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IDVenta", idVenta)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Function ModificarVenta(idVenta As Integer, idCliente As Integer, fecha As DateTime, total As Double) As Boolean
        Dim query As String = "UPDATE ventas SET IDCliente = @IDCliente, Fecha = @Fecha, Total = @Total WHERE ID = @IDVenta"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IDCliente", idCliente)
                command.Parameters.AddWithValue("@Fecha", fecha)
                command.Parameters.AddWithValue("@Total", total)
                command.Parameters.AddWithValue("@IDVenta", idVenta)

                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Function CalcularTotalVentas() As Double
        Dim total As Double = 0.0
        Dim query As String = "SELECT SUM(Total) FROM ventas"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    total = Convert.ToDouble(result)
                End If
            End Using
        End Using

        Return total
    End Function
End Class

