Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If VerificarTextBoxCompletos(GroupBox1) Then
            Try
                Dim MiCliente As New Cliente.DatosCliente
                Dim resultado As Boolean
                resultado = MiCliente.InsertarCliente(TextBox1.Text, TextBox2.Text, TextBox3.Text)

                If resultado = False Then
                    MsgBox("El cliente fue dado de alta")
                End If
            Catch ex As Exception
                MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
            End Try
            LimpiarTextBoxEnContenedor(GroupBox1)
        Else
            MsgBox("Complete los datos")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim MiCliente As New Cliente.DatosCliente

            Dim resultado As Boolean
            resultado = MiCliente.BorrarCliente(TextBox10.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text)

            If resultado = True Then
                MsgBox("El cliente fue eliminado")
            End If
        Catch ex As Exception
            MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
        End Try
        LimpiarTextBoxEnContenedor(GroupBox1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim MiCliente As New Cliente.DatosCliente
            Dim idCliente As Integer = Integer.Parse(TextBox10.Text)
            Dim nuevoNombre As String = TextBox1.Text
            Dim nuevoTelefono As String = TextBox2.Text
            Dim nuevoCorreo As String = TextBox3.Text
            Dim resultado As Boolean
            resultado = MiCliente.ModificarCliente(idCliente, nuevoNombre, nuevoTelefono, nuevoCorreo)

            If resultado = True Then
                MsgBox("El cliente fue modificado")
            End If
        Catch ex As Exception
            MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
        End Try
        LimpiarTextBoxEnContenedor(GroupBox1)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
        Dim query As String = ""

        Select Case ComboBox1.Text
            Case "ID"
                query = "SELECT * FROM clientes WHERE ID LIKE '%' + @ValorBusqueda + '%'"
            Case "Nombre"
                query = "SELECT * FROM clientes WHERE Cliente LIKE '%' + @ValorBusqueda + '%'"
            Case "Telefono"
                query = "SELECT * FROM clientes WHERE Telefono LIKE '%' + @ValorBusqueda + '%'"
            Case "Correo"
                query = "SELECT * FROM clientes WHERE Correo LIKE '%' + @ValorBusqueda + '%'"
            Case ""
                query = "SELECT * FROM clientes WHERE ID LIKE '%' + @ValorBusqueda + '%'"
        End Select
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ValorBusqueda", TextBox11.Text)

                Dim adapter As New SqlDataAdapter(command)
                Dim dataTable As New DataTable()

                adapter.Fill(dataTable)

                DataGridView1.DataSource = dataTable
            End Using
        End Using

        Dim filaSeleccionada As DataGridViewRow = Nothing

        If DataGridView1.SelectedRows.Count > 0 Then
            filaSeleccionada = DataGridView1.SelectedRows(0)
        ElseIf DataGridView1.SelectedCells.Count > 0 Then
            filaSeleccionada = DataGridView1.Rows(DataGridView1.SelectedCells(0).RowIndex)
        End If

        If filaSeleccionada IsNot Nothing Then
            TextBox10.Text = filaSeleccionada.Cells("ID").Value.ToString()
            TextBox1.Text = filaSeleccionada.Cells("Cliente").Value.ToString()
            TextBox2.Text = filaSeleccionada.Cells("Telefono").Value.ToString()
            TextBox3.Text = filaSeleccionada.Cells("Correo").Value.ToString()
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            TextBox10.Text = filaSeleccionada.Cells("ID").Value.ToString()
            TextBox1.Text = filaSeleccionada.Cells("Cliente").Value.ToString()
            TextBox2.Text = filaSeleccionada.Cells("Telefono").Value.ToString()
            TextBox3.Text = filaSeleccionada.Cells("Correo").Value.ToString()
        End If
    End Sub


    '--------------------------------------------------------------------------------------------------------------------------------
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If VerificarTextBoxCompletos(GroupBox2) Then
            Try
                Dim MiProducto As New Productos.DatosProductos

                Dim resultado As Boolean
                resultado = MiProducto.InsertarProducto(TextBox4.Text, TextBox5.Text, TextBox6.Text)

                If resultado = False Then
                    MsgBox("El producto fue dado de alta")
                End If
            Catch ex As Exception
                MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
            End Try
        Else
            MsgBox("Complete los datos")
        End If
        LimpiarTextBoxEnContenedor(GroupBox2)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim MiProducto As New Productos.DatosProductos

            Dim resultado As Boolean
            resultado = MiProducto.BorrarProducto(TextBox4.Text, TextBox5.Text, TextBox6.Text)

            If resultado = True Then
                MsgBox("El producto fue dado de baja")
            End If
        Catch ex As Exception
            MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
        End Try
        LimpiarTextBoxEnContenedor(GroupBox2)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim MiProducto As New Productos.DatosProductos
            Dim idProducto As Integer = Integer.Parse(TextBox12.Text)
            Dim nuevoNombre As String = TextBox4.Text
            Dim nuevoPrecio As String = TextBox5.Text
            Dim nuevaCategoria As String = TextBox6.Text
            Dim resultado As Boolean
            resultado = MiProducto.ModificarProducto(idProducto, nuevoNombre, nuevoPrecio, nuevaCategoria)

            If resultado = True Then
                MsgBox("El producto fue modificado")
            End If
        Catch ex As Exception
            MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
        End Try
        LimpiarTextBoxEnContenedor(GroupBox2)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
        Dim query As String = ""

        Select Case ComboBox2.Text
            Case "ID"
                query = "SELECT * FROM Productos WHERE ID LIKE '%' + @ValorBusqueda + '%'"
            Case "Nombre"
                query = "SELECT * FROM Productos WHERE Nombre LIKE '%' + @ValorBusqueda + '%'"
            Case "Precio"
                query = "SELECT * FROM Productos WHERE Precio LIKE '%' + @ValorBusqueda + '%'"
            Case "Categoria"
                query = "SELECT * FROM Productos WHERE Categoria LIKE '%' + @ValorBusqueda + '%'"
            Case ""
                query = "SELECT * FROM Productos WHERE ID LIKE '%' + @ValorBusqueda + '%'"
        End Select
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ValorBusqueda", TextBox13.Text)

                Dim adapter As New SqlDataAdapter(command)
                Dim dataTable As New DataTable()

                adapter.Fill(dataTable)

                DataGridView2.DataSource = dataTable
            End Using
        End Using

        Dim filaSeleccionada As DataGridViewRow = Nothing

        If DataGridView2.SelectedRows.Count > 0 Then
            filaSeleccionada = DataGridView2.SelectedRows(0)
        ElseIf DataGridView2.SelectedCells.Count > 0 Then
            filaSeleccionada = DataGridView2.Rows(DataGridView2.SelectedCells(0).RowIndex)
        End If

        If filaSeleccionada IsNot Nothing Then
            TextBox12.Text = filaSeleccionada.Cells("ID").Value.ToString()
            TextBox4.Text = filaSeleccionada.Cells("Nombre").Value.ToString()
            TextBox5.Text = filaSeleccionada.Cells("Precio").Value.ToString()
            TextBox6.Text = filaSeleccionada.Cells("Categoria").Value.ToString()
        End If
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = DataGridView2.Rows(e.RowIndex)

            TextBox12.Text = filaSeleccionada.Cells("ID").Value.ToString()
            TextBox4.Text = filaSeleccionada.Cells("Nombre").Value.ToString()
            TextBox5.Text = filaSeleccionada.Cells("Precio").Value.ToString()
            TextBox6.Text = filaSeleccionada.Cells("Categoria").Value.ToString()
        End If
    End Sub

    '--------------------------------------------------------------------------------------------------------------------------------


    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If VerificarTextBoxCompletos(GroupBox3) Then
            Try
                Dim MiProducto As New Ventas.VentaDatos

                Dim resultado As Boolean
                resultado = MiProducto.IncertarVenta(TextBox7.Text, DateTime.Now, TextBox9.Text)

                If resultado = False Then
                    MsgBox("La venta fue dado de alta")
                End If
            Catch ex As Exception
                MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
            End Try
        Else
            MsgBox("Complete los datos")
        End If
        LimpiarTextBoxEnContenedor(GroupBox3)
    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            Dim MiProducto As New Ventas.VentaDatos

            Dim resultado As Boolean
            resultado = MiProducto.EliminarVenta(TextBox8.Text)

            If resultado = False Then
                MsgBox("La venta fue dado de baja")
            End If
        Catch ex As Exception
            MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
        End Try
        LimpiarTextBoxEnContenedor(GroupBox3)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            Dim MiProducto As New Ventas.VentaDatos
            Dim idVenta As String = TextBox8.Text
            Dim idCliente As String = TextBox7.Text
            Dim fecha As String = DateTime.Now
            Dim total As String = TextBox9.Text
            Dim resultado As Boolean
            resultado = MiProducto.ModificarVenta(idVenta, idCliente, fecha, total)

            If resultado = True Then
                MsgBox("La venta fue dado de alta")
            End If
        Catch ex As Exception
            MsgBox(MsgBox("Ocurrió un error, ponganse en contacto con el programador ") & ex.Message)
        End Try
        LimpiarTextBoxEnContenedor(GroupBox3)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
        Dim query As String = ""

        Select Case ComboBox3.Text
            Case "ID"
                query = "SELECT * FROM Ventas WHERE ID LIKE '%' + @ValorBusqueda + '%'"
            Case "IDCliente"
                query = "SELECT * FROM Ventas WHERE IDCliente LIKE '%' + @ValorBusqueda + '%'"
            Case "Fecha"
                query = "SELECT * FROM Ventas WHERE Fecha LIKE '%' + @ValorBusqueda + '%'"
            Case "Total"
                query = "SELECT * FROM Ventas WHERE Total LIKE '%' + @ValorBusqueda + '%'"
            Case ""
                query = "SELECT * FROM Ventas WHERE ID LIKE '%' + @ValorBusqueda + '%'"
        End Select
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ValorBusqueda", TextBox14.Text)

                Dim adapter As New SqlDataAdapter(command)
                Dim dataTable As New DataTable()

                adapter.Fill(dataTable)

                DataGridView3.DataSource = dataTable
            End Using
        End Using

        Dim filaSeleccionada As DataGridViewRow = Nothing

        If DataGridView3.SelectedRows.Count > 0 Then
            filaSeleccionada = DataGridView3.SelectedRows(0)
        ElseIf DataGridView3.SelectedCells.Count > 0 Then
            filaSeleccionada = DataGridView3.Rows(DataGridView3.SelectedCells(0).RowIndex)
        End If

        If filaSeleccionada IsNot Nothing Then
            TextBox8.Text = filaSeleccionada.Cells("ID").Value.ToString()
            TextBox7.Text = filaSeleccionada.Cells("IDCliente").Value.ToString()
            TextBox9.Text = filaSeleccionada.Cells("Total").Value.ToString()
        End If
        Dim MiProducto As New Ventas.VentaDatos
        ' Calcula el total de ventas
        Dim totalVentas As Double = MiProducto.CalcularTotalVentas()

        ' Muestra el total en un control (puedes usar un Label, TextBox, etc.)
        Label12.Text = "Total de Ventas: $" & totalVentas.ToString("0.00")
    End Sub


    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = DataGridView3.Rows(e.RowIndex)

            TextBox8.Text = filaSeleccionada.Cells("ID").Value.ToString()
            TextBox7.Text = filaSeleccionada.Cells("IDCliente").Value.ToString()
            TextBox9.Text = filaSeleccionada.Cells("Total").Value.ToString()

        End If
    End Sub
    Private Sub LimpiarTextBoxEnContenedor(contenedor As Control)
        For Each control As Control In contenedor.Controls
            If TypeOf control Is TextBox Then
                Dim textBox As TextBox = DirectCast(control, TextBox)
                textBox.Text = ""
            ElseIf control.Controls.Count > 0 Then
                LimpiarTextBoxEnContenedor(control)
            End If
        Next
    End Sub
    Private Function VerificarTextBoxCompletos(groupBox As GroupBox) As Boolean
        For Each control As Control In groupBox.Controls
            If TypeOf control Is TextBox Then
                Dim textBox As TextBox = DirectCast(control, TextBox)
                If Not (textBox.Name = "TextBox10" OrElse textBox.Name = "TextBox12" OrElse textBox.Name = "TextBox11" OrElse textBox.Name = "TextBox13" OrElse textBox.Name = "TextBox8" OrElse textBox.Name = "TextBox14") AndAlso String.IsNullOrEmpty(textBox.Text) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub Generarepotesventas_Click(sender As Object, e As EventArgs) Handles Generarepotesventas.Click
        Dim rutaTrabajo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Source", "Repos", "Trabajo")
        Dim rutaCarpeta As String = Path.Combine(rutaTrabajo, "Reportes_Ventas")

        Try
            Dim idCliente As Integer = Integer.Parse(TextBox7.Text)
            Dim total As Decimal = Decimal.Parse(TextBox9.Text)
            Dim fecha As Date = DateTime.Now

            Dim nombreArchivo As String = String.Format("ReporteUltimaVenta_{0}_{1}.txt", idCliente, fecha.ToString("yyyyMMddHHmmss"))

            Dim rutaCompleta As String = Path.Combine(rutaCarpeta, nombreArchivo)

            Dim contenido As String = String.Format("IDCliente: {0}{1}Fecha: {2}{1}Total: {3}", idCliente, Environment.NewLine, fecha, total)

            If Not Directory.Exists(rutaCarpeta) Then
                Directory.CreateDirectory(rutaCarpeta)
            End If

            File.WriteAllText(rutaCompleta, contenido)

            MessageBox.Show("Reporte de la última venta guardado exitosamente en: " & rutaCompleta, "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al generar el reporte de la última venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub Generarepotesproductos_Click(sender As Object, e As EventArgs) Handles Generarepotesproductos.Click
        Dim rutaTrabajo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Source", "Repos", "Trabajo")
        Dim rutaCarpeta As String = Path.Combine(rutaTrabajo, "Reportes_productos")

        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString

            Dim query As String = "SELECT Nombre, Precio, Categoria FROM Productos" ' Reemplazar con tu consulta SQL

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            Dim nombreArchivo As String = String.Format("ReporteProductos_{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"))
                            Dim rutaCompleta As String = Path.Combine(rutaCarpeta, nombreArchivo)

                            Using file As New StreamWriter(rutaCompleta)
                                While reader.Read()
                                    Dim nombreProducto As String = reader.GetString(0)
                                    Dim precio As Double = reader.GetDouble(1)
                                    Dim categoria As String = reader.GetString(2)

                                    Dim contenido As String = String.Format("Nombre: {0}{1}Precio: {2}{1}Categoría: {3}", nombreProducto, Environment.NewLine, precio, categoria)

                                    file.WriteLine(contenido)
                                    file.WriteLine("--------------------------------------------")
                                End While
                            End Using

                            MessageBox.Show("Reporte de productos guardado exitosamente en: " & rutaCompleta, "Reporte generado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("No se encontraron productos en la base de datos", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al generar el reporte de productos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
