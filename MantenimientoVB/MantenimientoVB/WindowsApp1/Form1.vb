Imports ClassLibrary1
Public Class Form1

    Dim obj As New Class1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = obj.ListarEmpleados

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        lblcodigo.Text = DataGridView1.Item(0, e.RowIndex).Value
        txtnombre.Text = DataGridView1.Item(1, e.RowIndex).Value
        txtdireccion.Text = DataGridView1.Item(2, e.RowIndex).Value
        DateTimePicker1.Text = DataGridView1.Item(3, e.RowIndex).Value
        DateTimePicker2.Text = DataGridView1.Item(4, e.RowIndex).Value
        txtarea.Text = DataGridView1.Item(5, e.RowIndex).Value

    End Sub

    Private Sub btnregistrar_Click(sender As Object, e As EventArgs) Handles btnregistrar.Click

        Try
            obj.Insertar(txtnombre.Text, txtdireccion.Text, (CDate(DateTimePicker1.Text)), (CDate(DateTimePicker2.Text)), txtarea.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Se registro el usuario: " + txtnombre.Text)

            txtnombre.Text = ""
            txtdireccion.Text = ""
            txtarea.Text = ""
            lblcodigo.Text = "E0000"
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now

        Catch ex As Exception
            MsgBox("404 Error al registrar ")
        End Try

    End Sub

    Private Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click

        Try
            obj.Modificar(lblcodigo.Text, txtnombre.Text, txtdireccion.Text, DateTimePicker1.Text, DateTimePicker2.Text, txtarea.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Se modifico el usuario con código: " + lblcodigo.Text)

            txtnombre.Text = ""
            txtdireccion.Text = ""
            txtarea.Text = ""
            lblcodigo.Text = "E0000"
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now

        Catch ex As Exception
            MsgBox("404 Error al modificar ")
        End Try

    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click

        Try
            obj.Eliminar(lblcodigo.Text)
            DataGridView1.DataSource = obj.ListarEmpleados
            MsgBox("Se elimino el usuario con código: " + lblcodigo.Text)

            txtnombre.Text = ""
            txtdireccion.Text = ""
            txtarea.Text = ""
            lblcodigo.Text = "E0000"
            DateTimePicker1.Value = DateTime.Now
            DateTimePicker2.Value = DateTime.Now
        Catch ex As Exception

            MsgBox("404 Error al eliminar ")

        End Try

    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        txtnombre.Text = ""
        txtdireccion.Text = ""
        txtarea.Text = ""
        lblcodigo.Text = "E0000"
        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now
    End Sub
End Class
