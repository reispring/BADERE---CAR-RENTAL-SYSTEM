Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=root;database=carrentals_db;")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRentals()
    End Sub

    'Load
    Private Sub LoadRentals()
        Try
            Dim sql = "SELECT * FROM rentals ORDER BY id DESC"
            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvRentals.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Clear
    Private Sub ClearFields()
        txtID.Text = ""
        txtCarModel.Text = ""
        txtRenterName.Text = ""
        dtpStart.Value = Date.Now
        dtpEnd.Value = Date.Now
    End Sub

    'Add
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            conn.Open()
            Dim sql = "INSERT INTO rentals (car_model, renter_name, start_date, end_date) 
                       VALUES (@car, @renter, @start, @end)"
            Dim cmd As New MySqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@car", txtCarModel.Text)
            cmd.Parameters.AddWithValue("@renter", txtRenterName.Text)
            cmd.Parameters.AddWithValue("@start", dtpStart.Value.Date)
            cmd.Parameters.AddWithValue("@end", dtpEnd.Value.Date)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Rental added successfully!")
            LoadRentals()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    'Update
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If txtID.Text = "" Then
            MessageBox.Show("Select a record to update.")
            Exit Sub
        End If

        Try
            conn.Open()
            Dim sql = "UPDATE rentals SET 
                       car_model=@car, 
                       renter_name=@renter, 
                       start_date=@start, 
                       end_date=@end
                       WHERE id=@id"

            Dim cmd As New MySqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@car", txtCarModel.Text)
            cmd.Parameters.AddWithValue("@renter", txtRenterName.Text)
            cmd.Parameters.AddWithValue("@start", dtpStart.Value.Date)
            cmd.Parameters.AddWithValue("@end", dtpEnd.Value.Date)
            cmd.Parameters.AddWithValue("@id", txtID.Text)

            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Rental updated!")
            LoadRentals()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    'Delete
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If txtID.Text = "" Then
            MessageBox.Show("Select a record to delete.")
            Exit Sub
        End If

        If MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub

        Try
            conn.Open()
            Dim sql = "DELETE FROM rentals WHERE id=@id"
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@id", txtID.Text)
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Rental deleted!")
            LoadRentals()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

    End Sub

    'Clear Button
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub


    Private Sub dgvRentals_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRentals.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim row As DataGridViewRow = dgvRentals.Rows(e.RowIndex)

        txtID.Text = row.Cells("id").Value.ToString()
        txtCarModel.Text = row.Cells("car_model").Value.ToString()
        txtRenterName.Text = row.Cells("renter_name").Value.ToString()
        dtpStart.Value = Convert.ToDateTime(row.Cells("start_date").Value)
        dtpEnd.Value = Convert.ToDateTime(row.Cells("end_date").Value)
    End Sub

End Class
