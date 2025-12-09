Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As New MySqlConnection("server=localhost;user=root;password=root;database=carrentals_db")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRentals()
    End Sub

    Public Sub ConnectDB()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message)
        End Try
    End Sub

    Public Sub LoadRentals()
        Try
            ConnectDB()
            Dim query As String = "SELECT * FROM rentals_tbl"
            Dim cmd As New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)
            dgvRentals.DataSource = dt
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            ConnectDB()
            Dim query As String = "INSERT INTO rentals_tbl (car_model, renter_name, start_date, end_date)
                                   VALUES (@car_model, @renter_name, @start_date, @end_date)"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@car_model", txtCarModel.Text)
            cmd.Parameters.AddWithValue("@renter_name", txtRenterName.Text)
            cmd.Parameters.AddWithValue("@start_date", dtpStart.Value)
            cmd.Parameters.AddWithValue("@end_date", dtpEnd.Value)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record Added Successfully!")
            LoadRentals()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error adding record: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvRentals_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRentals.CellClick
        If e.RowIndex >= 0 Then
            txtID.Text = dgvRentals.Rows(e.RowIndex).Cells("id").Value.ToString()
            txtCarModel.Text = dgvRentals.Rows(e.RowIndex).Cells("car_model").Value.ToString()
            txtRenterName.Text = dgvRentals.Rows(e.RowIndex).Cells("renter_name").Value.ToString()
            dtpStart.Value = dgvRentals.Rows(e.RowIndex).Cells("start_date").Value
            dtpEnd.Value = dgvRentals.Rows(e.RowIndex).Cells("end_date").Value
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtID.Text = "" Then
                MessageBox.Show("Select a record to update.")
                Return
            End If

            ConnectDB()
            Dim query As String = "UPDATE rentals_tbl 
                                   SET car_model=@car_model, renter_name=@renter_name,
                                       start_date=@start_date, end_date=@end_date
                                   WHERE id=@id"

            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@car_model", txtCarModel.Text)
            cmd.Parameters.AddWithValue("@renter_name", txtRenterName.Text)
            cmd.Parameters.AddWithValue("@start_date", dtpStart.Value)
            cmd.Parameters.AddWithValue("@end_date", dtpEnd.Value)
            cmd.Parameters.AddWithValue("@id", txtID.Text)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record Updated Successfully!")
            LoadRentals()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error updating record: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txtID.Text = "" Then
                MessageBox.Show("Select a record to delete.")
                Return
            End If

            ConnectDB()
            Dim query As String = "DELETE FROM rentals_tbl WHERE id=@id"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record Deleted Successfully!")
            LoadRentals()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Public Sub ClearFields()
        txtID.Clear()
        txtCarModel.Clear()
        txtRenterName.Clear()
        dtpStart.Value = Date.Now
        dtpEnd.Value = Date.Now
    End Sub

End Class