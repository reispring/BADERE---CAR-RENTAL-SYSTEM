Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=root;database=carrentals_db;")
    Private Sub LoadData()
        Try
            Dim cmd As New MySqlCommand("SELECT * FROM carrentals_tbl WHERE is_deleted = 0", conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvRentals.DataSource = table
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub


    Private Sub ClearFields()
        txtID.Clear()
        txtCarModel.Clear()
        txtRenterName.Clear()
        dtpStart.Value = Date.Now
        dtpEnd.Value = Date.Now
        txtSearch.Clear()
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim query As String =
            "INSERT INTO carrentals_db(car_model, renter_name, start_date, end_date)
             VALUES (@car, @renter, @startD, @endD)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@car", txtCarModel.Text)
            cmd.Parameters.AddWithValue("@rentername", txtRenterName.Text)
            cmd.Parameters.AddWithValue("@startD", dtpStart.Value)
            cmd.Parameters.AddWithValue("@endD", dtpEnd.Value)

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record Added Successfully!")
            LoadData()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    'Update
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim query As String =
            "UPDATE carrentals_tbl SET
                car_model=@car,
                renter_name=@renter,
                start_date=@startD,
                end_date=@endD
             WHERE id=@id"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@car", txtCarModel.Text)
            cmd.Parameters.AddWithValue("@renter", txtRenterName.Text)
            cmd.Parameters.AddWithValue("@startD", dtpStart.Value)
            cmd.Parameters.AddWithValue("@endD", dtpEnd.Value)
            cmd.Parameters.AddWithValue("@id", txtID.Text)

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record Updated!")
            LoadData()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub


    'SOFT DELETE
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim cmd As New MySqlCommand(
                "UPDATE carrentals_tbl SET is_deleted = 1 WHERE id = @id", conn)

            cmd.Parameters.AddWithValue("@id", txtID.Text)

            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()

            MessageBox.Show("Record soft deleted!")
            LoadData()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    'Search
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim cmd As New MySqlCommand(
                "SELECT * FROM carrentals_tbl 
                 WHERE car_model LIKE @search AND is_deleted = 0", conn)

            cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)

            dgvRentals.DataSource = table

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRentals.CellClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgvRentals.Rows(e.RowIndex)

                txtID.Text = row.Cells("id").Value.ToString()
                txtCarModel.Text = row.Cells("car_model").Value.ToString()
                txtRenterName.Text = row.Cells("renter_name").Value.ToString()
                dtpStart.Value = row.Cells("start_date").Value
                dtpEnd.Value = row.Cells("end_date").Value
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Clear
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    'Load All
    Private Sub btnLoadAll_Click(sender As Object, e As EventArgs) Handles btnLoadAll.Click
        LoadData()
    End Sub




End Class
