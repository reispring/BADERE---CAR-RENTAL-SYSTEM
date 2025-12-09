Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As New MySqlConnection("server=localhost;user id=root;password=yourpassword;database=carrentals_db")

    Public Sub ConnectDB()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message)
        End Try
    End Sub

    ' READ
    Public Sub LoadRecords()
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

    ' ADD RECORD (CREATE)
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            ConnectDB()
            Dim query As String =
                "INSERT INTO rentals_tbl (car_model, renter_name, start_date, end_date) 
                 VALUES (@car, @renter, @start, @end)"

            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@car", txtCarModel.Text)
            cmd.Parameters.AddWithValue("@renter", txtRenterName.Text)
            cmd.Parameters.AddWithValue("@start", dtpStart.Value)
            cmd.Parameters.AddWithValue("@end", dtpEnd.Value)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record Added Successfully!")
            LoadRecords()

        Catch ex As Exception
            MessageBox.Show("Error adding record: " & ex.Message)
        End Try
    End Sub

    ' READ RECORDS 
    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click
        LoadRecords()
    End Sub

    ' UPDATE RECORD
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If txtID.Text = "" Then
                MessageBox.Show("Please select a record to update.")
                Return
            End If

            ConnectDB()
            Dim query As String =
                "UPDATE rentals_tbl 
                 SET car_model=@car, renter_name=@renter, start_date=@start, end_date=@end 
                 WHERE id=@id"

            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@car", txtCarModel.Text)
            cmd.Parameters.AddWithValue("@renter", txtRenterName.Text)
            cmd.Parameters.AddWithValue("@start", dtpStart.Value)
            cmd.Parameters.AddWithValue("@end", dtpEnd.Value)
            cmd.Parameters.AddWithValue("@id", txtID.Text)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record Updated Successfully!")
            LoadRecords()

        Catch ex As Exception
            MessageBox.Show("Error updating record: " & ex.Message)
        End Try
    End Sub

    ' DELETE RECORD
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If txtID.Text = "" Then
                MessageBox.Show("Please select a record to delete.")
                Return
            End If

            ConnectDB()
            Dim query As String = "DELETE FROM rentals_tbl WHERE id=@id"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record Deleted Successfully!")
            LoadRecords()

        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvRentals_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRentals.CellClick
        Try
            If e.RowIndex >= 0 Then
                txtID.Text = dgvRentals.CurrentRow.Cells("id").Value.ToString()
                txtCarModel.Text = dgvRentals.CurrentRow.Cells("car_model").Value.ToString()
                txtRenterName.Text = dgvRentals.CurrentRow.Cells("renter_name").Value.ToString()

                dtpStart.Value = dgvRentals.CurrentRow.Cells("start_date").Value
                dtpEnd.Value = dgvRentals.CurrentRow.Cells("end_date").Value
            End If
        Catch
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRecords()
    End Sub

End Class