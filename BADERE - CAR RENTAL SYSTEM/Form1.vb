Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private connString As String = "server=localhost;userid=carentaldb_;password=root;database=carental_db;SslMode=none"
    Public Property DataGridViewVehicle As Object

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub LoadCustomers()
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim sql = "SELECT customer_id, fullname FROM customers"
            Using cmd As New MySqlCommand(sql, conn)
                Using reader = cmd.ExecuteReader()
                    Dim dt As New DataTable()
                    dt.Load(reader)
                    DataGridViewCustomer.DataSource = dt
                    DataGridViewCustomer.DisplayMember = "fullname"
                    DataGridViewCustomer.ValueMember = "customer_id"
                End Using
            End Using
        End Using
    End Sub

    Private Sub LoadVehicles()
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim sql = "SELECT vehicle_id, CONCAT(brand,' ',model) AS vehicle_name FROM vehicles WHERE status='Available'"
            Using cmd As New MySqlCommand(sql, conn)
                Using reader = cmd.ExecuteReader()
                    Dim dt As New DataTable()
                    dt.Load(reader)
                    DataGridViewVehicle.DataSource = dt
                    DataGridViewVehicle.DisplayMember = "vehicle_name"
                    DataGridViewVehicle.ValueMember = "vehicle_id"
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnRent_Click(sender As Object, e As EventArgs) Handles btnRent.Click
        Dim customerId As Integer = Convert.ToInt32(cmbCustomer.SelectedValue)
        Dim vehicleId As Integer = Convert.ToInt32(cmbVehicle.SelectedValue)
        Dim rentDate As DateTime = dtpRentDate.Value
        Dim returnDate As DateTime = dtpReturnDate.Value

        Using conn As New MySqlConnection(connString)
            conn.Open()
            Dim sql = "INSERT INTO rentals (customer_id, vehicle_id, rent_date, return_date) VALUES (@customerId, @vehicleId, @rentDate, @returnDate);
                       UPDATE vehicles SET status='Rented' WHERE vehicle_id=@vehicleId;"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@customerId", customerId)
                cmd.Parameters.AddWithValue("@vehicleId", vehicleId)
                cmd.Parameters.AddWithValue("@rentDate", rentDate)
                cmd.Parameters.AddWithValue("@returnDate", returnDate)

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Vehicle rented successfully!")
        LoadVehicles() ' Refresh available vehicles
    End Sub

    Private Sub ClearFields()
        txtRentalID.Text = ""
        cmbCustomer.SelectedIndex = 0
        cmbVehicle.SelectedIndex = 0
        dtpRent.Value = Date.Now
        dtpReturn.Value = Date.Now
        txtTotal.Text = ""
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dtpReturn.Value < dtpRent.Value Then
            MessageBox.Show("Return date cannot be before rent date.")
            Return
        End If

        Dim sql = "INSERT INTO rentals (customer_id, vehicle_id, rent_date, return_date, total_price)
                   VALUES (@customer,@vehicle,@rent,@return,@total)"
        Using conn As New MySqlConnection(connString)
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@customer", cmbCustomer.SelectedValue)
                cmd.Parameters.AddWithValue("@vehicle", cmbVehicle.SelectedValue)
                cmd.Parameters.AddWithValue("@rent", dtpRent.Value.Date)
                cmd.Parameters.AddWithValue("@return", dtpReturn.Value.Date)
                cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text))
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Rental added successfully!")
        ClearFields()
        LoadRentals()
        LoadVehicles() ' refresh available vehicles
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtRentalID.Text = "" Then
            MessageBox.Show("Select a rental to update.")
            Return
        End If

        Dim sql = "UPDATE rentals SET customer_id=@customer, vehicle_id=@vehicle,
                   rent_date=@rent, return_date=@return, total_price=@total
                   WHERE rental_id=@id"

        Using conn As New MySqlConnection(connString)
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@customer", cmbCustomer.SelectedValue)
                cmd.Parameters.AddWithValue("@vehicle", cmbVehicle.SelectedValue)
                cmd.Parameters.AddWithValue("@rent", dtpRent.Value.Date)
                cmd.Parameters.AddWithValue("@return", dtpReturn.Value.Date)
                cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text))
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtRentalID.Text))
                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Rental updated.")
        ClearFields()
        LoadRentals()
        LoadVehicles()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim s = txtSearch.Text.Trim()
        If s = "" Then
            LoadRentals()
            Return
        End If

        Dim query As String
        If IsNumeric(s) Then
            query = "SELECT r.rental_id, c.fullname AS Customer, CONCAT(v.brand,' ',v.model) AS Vehicle,
                     r.rent_date AS 'Rent Date', r.return_date AS 'Return Date', r.total_price AS 'Total Price'
                     FROM rentals r
                     JOIN customers c ON r.customer_id = c.customer_id
                     JOIN vehicles v ON r.vehicle_id = v.vehicle_id
                     WHERE r.is_deleted=0 AND r.rental_id=" & s
        Else
            query = "SELECT r.rental_id, c.fullname AS Customer, CONCAT(v.brand,' ',v.model) AS Vehicle,
                     r.rent_date AS 'Rent Date', r.return_date AS 'Return Date', r.total_price AS 'Total Price'
                     FROM rentals r
                     JOIN customers c ON r.customer_id = c.customer_id
                     JOIN vehicles v ON r.vehicle_id = v.vehicle_id
                     WHERE r.is_deleted=0 AND c.fullname LIKE '%" & s & "%'"
        End If

        LoadRentals(query)
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadRentals()
    End Sub

    Private Sub dgvRentals_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRentals.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row = dgvRentals.Rows(e.RowIndex)
        txtRentalID.Text = row.Cells("rental_id").Value.ToString()
        cmbCustomer.Text = row.Cells("Customer").Value.ToString()
        cmbVehicle.Text = row.Cells("Vehicle").Value.ToString()
        dtpRent.Value = Convert.ToDateTime(row.Cells("Rent Date").Value)
        dtpReturn.Value = Convert.ToDateTime(row.Cells("Return Date").Value)
        txtTotal.Text = row.Cells("Total Price").Value.ToString()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub
End Class
